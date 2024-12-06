// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using AssetTracker;
AssetManager manager = new AssetManager();

generateDefaultAssets(manager);


//manager.GetAssets().OrderBy(item  => item.Office.Name).ToList();

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
    else if (monthsLeft<=6)
    {
        color = ConsoleColor.Yellow;
    }

    CS.PrintLn(color,$"{item.GetType().Name,-20}{item.Brand,-20}{item.Model,-20}{item.Office.Name,-10}{item.PurchaseDate.ToShortDateString(),-12}{item.PurchasePrice.Cost,-10}{monthsLeft,-10}");

}





static void generateDefaultAssets(AssetManager manager)
{
    manager.AddAsset(new Smartphone(new Price(200, Currency.USD), DateTime.Now.AddMonths(-36 + 4), "Motorola", "X3", "USA"));
    manager.AddAsset(new Smartphone(new Price(400, Currency.USD), DateTime.Now.AddMonths(-36 + 5), "Motorola", "X3", "USA"));
    manager.AddAsset(new Smartphone(new Price(400, Currency.USD), DateTime.Now.AddMonths(-36 + 10), "Motorola", "X2", "USA"));
    manager.AddAsset(new Smartphone(new Price(4500, Currency.SEK), DateTime.Now.AddMonths(-36 + 6), "Samsung", "Galaxy 10", "Sweden"));
    manager.AddAsset(new Smartphone(new Price(4500, Currency.SEK), DateTime.Now.AddMonths(-36 + 7), "Samsung", "Galaxy 10", "Sweden"));
    manager.AddAsset(new Smartphone(new Price(3000, Currency.SEK), DateTime.Now.AddMonths(-36 + 4), "Sony", "XPeria 7", "Sweden"));
    manager.AddAsset(new Smartphone(new Price(3000, Currency.SEK), DateTime.Now.AddMonths(-36 + 5), "Sony", "XPeria 7", "Sweden"));
    manager.AddAsset(new Smartphone(new Price(220, Currency.EUR), DateTime.Now.AddMonths(-36 + 12), "Siemens", "Brick", "Germany"));
    manager.AddAsset(new Computer(new Price(100, Currency.USD), DateTime.Now.AddMonths(-38), "Dell", "Desktop 900", "USA"));
    manager.AddAsset(new Computer(new Price(100, Currency.USD), DateTime.Now.AddMonths(-37), "Dell", "Desktop 900", "USA"));
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