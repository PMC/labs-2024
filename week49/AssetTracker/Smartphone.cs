internal class Smartphone : Asset
{
    private Price _purchasePrice;
    private DateTime _purchaseDate;
    private string _model;
    private string _brand;
    private Office _office;

    public Smartphone(Price purchasePrice, DateTime purchaseDate, string brand, string model, string office)
    {
        _purchasePrice = purchasePrice;
        _purchaseDate = purchaseDate;
        _model = model;
        _brand = brand;
        _office = new Office(office, purchasePrice.Currency);
    }


    public override string Brand
    {
        get { return _brand; }
    }

    public override string Model
    {
        get { return _model; }
    }

    public override Price PurchasePrice
    {
        get
        {
            return _purchasePrice;
        }
    }
    public override DateTime PurchaseDate
    {
        get
        {
            return _purchaseDate;
        }
    }
    public override Office Office
    {
        get
        {
            return _office;
        }
    }
}