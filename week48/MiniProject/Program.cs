// See https://aka.ms/new-console-template for more information
using MiniProject;
ProductList list = new ProductList();
bool keeepRunning = true;
string searchFor = "";

ConsoleKeyInfo menuInput;

CS.PrintLn(ConsoleColor.Green,"Welcome to Checkpoint 2 solution");

list.AddProduct("Mobile", "Samsung S23", 10000);
list.AddProduct("Camera", "Sony A7IV", 25000);

CS.PrintLn(ConsoleColor.Green, "* Added example Products");


while (keeepRunning)
{
    list.Print(searchFor);
    searchFor = ""; //after print, reset search string

    PrintMainCommands();
    menuInput = Console.ReadKey();
    Console.WriteLine(); //new line after keypress

    //trying something new, readkey instead of readline
    switch (menuInput.Key)
    {
        case ConsoleKey.Enter:
        case ConsoleKey.Escape:
        case ConsoleKey.Q:
            keeepRunning = false;
            break;
        case ConsoleKey.P:
            handleNewProduct();
            break;
        case ConsoleKey.S:
            searchFor = handleSearch();
            break;
        default:
            CS.PrintLn(ConsoleColor.Red, "Wrong menu entry, please try again:");
            break;

    }
    
}

string handleSearch()
{
    Console.Clear();
    Console.Write("Enter a Product Name to search for: ");
    return readInput();
}

void handleNewProduct()
{
    string menuText = "To enter a new product - follow the steps | enter [Q]uit or [RETURN] to exit menu: ";
    string input = "";
    string category = "";
    string productName = "";
    decimal price = 0;

    Console.Clear();
    while (true)
    {
        CS.PrintLn(ConsoleColor.Green, menuText);
        Console.Write("Enter a Category: ");
        category = readInput();
        if (category == "")
                break;

        Console.Write("Enter a Product Name: ");
        productName = readInput();
        if (productName == "")
            break;

        Console.Write("Enter a Price: ");
        input = readInput();
        if (input == "")
            break;

        if (!Decimal.TryParse(input, out price))
        {
            CS.PrintLn(ConsoleColor.Red, "Invalid Price format, restarting--");
            continue;
        }

        list.AddProduct(category, productName, price);

        CS.PrintLn("* Product added");
    }
}

    void PrintMainCommands()
    {
        CS.Print(ConsoleColor.Blue, ">> Commands: To enter a new [P]roduct | To [S]earch for a product | [Q]uit or press [ENTER] to quit: ");
    }

    string readInput()
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

 