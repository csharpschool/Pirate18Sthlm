namespace PirarteTreassure.Structs;

public enum Action
{
    Sell,
    Buy
}

public struct ShopEventArgs
{
    public int Price { get; set; }
    public string Name { get; set; }
    public Action Action { get; set; }

    public ShopEventArgs(int price, string name, Action action)
    {
        Price = price;
        Name = name;
        Action = action;
    }
}
