
internal class Price
{
    private decimal _cost;
    private Currency _currency;

    public Price(decimal price, Currency currency)
    {
        _cost = price;
        _currency = currency;
    }
    public decimal Cost
    {
        get { return _cost; }
    }
    public Currency Currency
    {
        get { return _currency; }
        set { _currency = value; }
    }
}