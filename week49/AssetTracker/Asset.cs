
internal abstract class Asset
{
    public abstract string Brand { get; }
    public abstract string Model { get; }
    public abstract Price PurchasePrice { get; }
    public abstract DateTime PurchaseDate { get; }
    public abstract Office Office { get; }
}