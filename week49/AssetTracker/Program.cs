// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Drawing;
using AssetTracker;
AssetManager manager = new AssetManager();
string input;
ConsoleKeyInfo menuInput;
LiveCurrency.FetchRates();

generateDefaultAssets(manager);

// since LiveCurrency was a bit broken i assume all items are in EURO, and convert to Office Currency
bool exit = false;
ViewAllAssets(manager);
while (!exit)
{

    PrintMainCommands();

    menuInput = Console.ReadKey();
    Console.WriteLine(); //new line after keypress

    //trying something new, readkey instead of readline
    switch (menuInput.Key)
    {
        case ConsoleKey.Enter:
        case ConsoleKey.Escape:
        case ConsoleKey.Q:
            exit = true;
            break;
        case ConsoleKey.N:
            addNewAsset(manager);
            ViewAllAssets(manager);
            break;
        default:
            CS.PrintLn(ConsoleColor.Red, "Wrong menu entry, please try again:");
            break;

    }
}

//Really ugly code but i just want basic input for now since the whole lab thing was using inheritance off classes 
void addNewAsset(AssetManager manager)
{
    CS.PrintLn("Enter asset type: ");
    CS.PrintLn("1. Smartphone");
    CS.PrintLn("2. Computer");
    CS.Print("Select 1 or 2: ");
    string type = readInput();
    Asset asset;
    int days=0;


    if (type == "1" || type == "2")
    {
        CS.Print("Enter brand name: ");
        string brand = readInput();
        CS.Print("Enter model name: ");
        string model = readInput();
        CS.Print("Enter price in EURO: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal value))
        {
            Console.WriteLine("Invalid value. Please enter a numeric value.");
            return;
        }
        CS.Print("Enter office location: ");
        string location = readInput();
        CS.PrintLn("Enter office currency: ");
        CS.PrintLn("1: " + Currency.USD.ToString());
        CS.PrintLn("2: " + Currency.SEK.ToString());
        CS.PrintLn("3: " + Currency.EUR.ToString());
        string currency = readInput();
        Currency officeCurrency;
        switch (currency)
            {
            case "1":
                officeCurrency = Currency.USD;
                break;
            case "2":
                officeCurrency = Currency.SEK;
                break;
            case "3":
                officeCurrency = Currency.EUR;
                break;
            default:
                throw new Exception("Wrong currency selection");

        }
        CS.Print("Enter how many days old the Asset is: ");
        string daysInput = readInput();

        int.TryParse(daysInput, out days);
        if (type.Equals("1"))
        {
            manager.AddAsset(new Smartphone(new Price(value, officeCurrency), DateTime.Now.AddDays(0 - days), brand, model, location));
        }
        else
        {
            manager.AddAsset(new Computer(new Price(value, officeCurrency), DateTime.Now.AddMonths(0 - days), brand, model, location));

        }
    }
}


static void generateDefaultAssets(AssetManager manager)
{
    manager.AddAsset(new Smartphone(new Price(200, Currency.USD), DateTime.Now.AddMonths(-36 + 4), "Motorola", "X3", "USA"));
    manager.AddAsset(new Smartphone(new Price(400, Currency.USD), DateTime.Now.AddMonths(-36 + 5), "Motorola", "X3", "USA"));
    manager.AddAsset(new Smartphone(new Price(400, Currency.USD), DateTime.Now.AddMonths(-36 + 10), "Motorola", "X2", "USA"));
    manager.AddAsset(new Smartphone(new Price(450, Currency.SEK), DateTime.Now.AddMonths(-36 + 6), "Samsung", "Galaxy 10", "Sweden"));
    manager.AddAsset(new Smartphone(new Price(450, Currency.SEK), DateTime.Now.AddMonths(-36 + 7), "Samsung", "Galaxy 10", "Sweden"));
    manager.AddAsset(new Smartphone(new Price(300, Currency.SEK), DateTime.Now.AddMonths(-36 + 4), "Sony", "XPeria 7", "Sweden"));
    manager.AddAsset(new Smartphone(new Price(300, Currency.SEK), DateTime.Now.AddMonths(-36 + 5), "Sony", "XPeria 7", "Sweden"));
    manager.AddAsset(new Smartphone(new Price(220, Currency.EUR), DateTime.Now.AddMonths(-36 + 12), "Siemens", "Brick", "Germany"));
    manager.AddAsset(new Computer(new Price(1000, Currency.USD), DateTime.Now.AddMonths(-38), "Dell", "Desktop 900", "USA"));
    manager.AddAsset(new Computer(new Price(1000, Currency.USD), DateTime.Now.AddMonths(-37), "Dell", "Desktop 900", "USA"));
    manager.AddAsset(new Computer(new Price(300, Currency.USD), DateTime.Now.AddMonths(-36 + 1), "Lenovo", "X100", "USA"));
    manager.AddAsset(new Computer(new Price(300, Currency.USD), DateTime.Now.AddMonths(-36 + 4), "Lenovo", "X200", "USA"));
    manager.AddAsset(new Computer(new Price(500, Currency.USD), DateTime.Now.AddMonths(-36 + 9), "Lenovo", "X300", "USA"));
    manager.AddAsset(new Computer(new Price(1500, Currency.SEK), DateTime.Now.AddMonths(-36 + 7), "Dell", "Optiplex 100", "Sweden"));
    manager.AddAsset(new Computer(new Price(1400, Currency.SEK), DateTime.Now.AddMonths(-36 + 8), "Dell", "Optiplex 200", "Sweden"));
    manager.AddAsset(new Computer(new Price(1300, Currency.SEK), DateTime.Now.AddMonths(-36 + 9), "Dell", "Optiplex 300", "Sweden"));
    manager.AddAsset(new Computer(new Price(1600, Currency.EUR), DateTime.Now.AddMonths(-36 + 14), "Asus", "ROG 600", "Germany"));
    manager.AddAsset(new Computer(new Price(1200, Currency.EUR), DateTime.Now.AddMonths(-36 + 4), "Asus", "ROG 500", "Germany"));
    manager.AddAsset(new Computer(new Price(1200, Currency.EUR), DateTime.Now.AddMonths(-36 + 3), "Asus", "ROG 500", "Germany"));
    manager.AddAsset(new Computer(new Price(1300, Currency.EUR), DateTime.Now.AddMonths(-36 + 2), "Asus", "ROG 500", "Germany"));
}
static string readInput()
{
    string input;
    try
    {
        input = Console.ReadLine();

        if (String.IsNullOrEmpty(input) || input.ToLower().Equals("q"))
            return "";

    }
    catch (Exception ex)
    {
        return "";
    }
    return input;
}
static void PrintMainCommands()
{
    CS.Print(ConsoleColor.Blue, ">> Commands: enter [N]ew for new Asset | [Q]uit or press [ENTER] to quit: ");
}
static void ViewAllAssets(AssetManager manager)
{
    CS.PrintLn($"{"Type",-20}{"Brand",-20}{"Model",-20}{"Office",-10}{"Date",-12}{"Price EUR",-10}{"Currency",-10}{"Local Price Today",-10}");

    foreach (var item in manager.GetAssets()
        .OrderBy(item => item.Office.Name)
        .ThenBy(item => item.PurchaseDate))
    {
        ConsoleColor color = Console.ForegroundColor;
        DateTime expiryDate = item.PurchaseDate.AddYears(3);
        TimeSpan remainingWarranty = expiryDate - DateTime.Now;
        int monthsLeft = (int)(remainingWarranty.TotalDays / 30);

        if (monthsLeft <= 3)
        {
            color = ConsoleColor.Red;
        }
        else if (monthsLeft <= 6)
        {
            color = ConsoleColor.Yellow;
        }

        CS.PrintLn(color, $"{item.GetType().Name,-20}{item.Brand,-20}{item.Model,-20}{item.Office.Name,-10}{item.PurchaseDate.ToShortDateString(),-12}{item.PurchasePrice.Cost,-10}{item.Office.LocalCurrency.ToString(),-10}{LiveCurrency.ConvertToCurrency(item.PurchasePrice.Cost, item.Office.LocalCurrency.ToString()).ToString("F2"),-10}");

    }
}