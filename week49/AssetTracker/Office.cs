public class Office(string officeName, Currency localCurrency)
{
    private readonly string _officeName = officeName;
    private readonly Currency _localCurrency = localCurrency;

    public string Name { get { return _officeName; } }
    public Currency LocalCurrency { get { return _localCurrency; } }
}