public class Security : IEquatable<Security>
{
    private string _symbol { get; set; }
    private decimal _price { get; set; }

    public Security(string symbol, decimal price)
    {
        _symbol = symbol;
        _price = price;
    }

    public override bool Equals(Object? other)
    {
        if (other == null) return false;
        return (other is Security o) && _symbol == o._symbol && _price == o._price;
    }

    public bool Equals(Security? o)
    {
        if (o == null) return false;
        return _symbol == o._symbol && _price == o._price;
    }

    public override int GetHashCode()
    {
        return (_symbol, _price).GetHashCode();
        //return HashCode.Combine(_symbol, _price);
    }

    public static bool operator ==(Security? a, Security? b)
    {
        if (a is null && b is null) return true;
        if (a is null || b is null) return false;
        return a.Equals(b);
    }

    public static bool operator !=(Security? a, Security? b)
    {
        if (a is null && b is null) return false;
        if (a is null || b is null) return true;
        return !a.Equals(b);
    }

}