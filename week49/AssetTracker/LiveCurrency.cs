using System;
using System.Net;
using System.Xml;
using System.Globalization;
using System.Xml.Serialization;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.Metadata;
using System.Data.SqlTypes;

namespace AssetTracker
{
    public class LiveCurrency // Class that handles fetching the exchange rates and converting currencies
    {
        private static Dictionary<string,decimal> currencyList = new Dictionary< string, decimal>();

        public static void FetchRates()
        {
            string url = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml"; // Exchange rate XML document

            XmlTextReader reader = new XmlTextReader(url);
            while (reader.Read()) // Goes through the XML document and saves the currency exchange rates to the local list
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    while (reader.MoveToNextAttribute()) 
                    {
                        if (reader.Name == "currency") // Identifies each currency attribute and saves the currency code and rate as an object
                        {
                            string currencyCode = reader.Value;

                            reader.MoveToNextAttribute();
                            decimal rate = decimal.Parse(reader.Value, CultureInfo.InvariantCulture);
                            currencyList.Add(currencyCode, rate);
                        }
                    }
                }
            }
        }


        public static decimal ConvertToCurrency(decimal input, string toCurrency) // Method that uses the fetched rates to convert between the given rates via Euro
        {
            decimal rateTo;

            if (toCurrency == "EUR") // local currency is EUR so just return value
            {
                return input;
            }

            if (currencyList.TryGetValue(toCurrency, out rateTo))
            {
                return input * rateTo;
            }

            return -1; //error

        }
    }
}