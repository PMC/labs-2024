
using AssetTracker;

internal class Computer : Asset
{
    public Computer(Price purchasePrice, DateTime purchaseDate, string brand, string model, string office) : base(purchasePrice, purchaseDate, brand, model, office)
    {
    }
}