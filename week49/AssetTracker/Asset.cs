
using System.Globalization;

internal abstract class Asset
{
    private Price _purchasePrice;
    private DateTime _purchaseDate;
    private string _model;
    private string _brand;
    private Office _office;

    protected Asset(Price purchasePrice, DateTime purchaseDate, string brand, string model, string office)
    {
        _purchasePrice = new Price(purchasePrice.Cost, Currency.EUR);
        _purchaseDate = purchaseDate;
        _model = model;
        _brand = brand;
        TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
        _office = new Office(ti.ToTitleCase(office), purchasePrice.Currency);
    }

    public string Brand 
    {
        get { return _brand; }
    }

    public string Model
    {
        get { return _model; }
    }

    public Price PurchasePrice
    {
        get
        {
            return _purchasePrice;
        }
    }

    public DateTime PurchaseDate
    {
        get
        {
            return _purchaseDate;
        }
    }

    public Office Office
    {
        get
        {
            return _office;
        }
    }
}