using PirarteTreassure.Interfaces;
using PirarteTreassure.Structs;

namespace PirarteTreassure.Classes;

public class Shop : List<IItem>
{
    public event EventHandler<ShopEventArgs>? ShopEvent;
    Random random = new();

    public Shop Get(int gold)
    {    
        foreach (IItem item in this) 
        {
            item.CanBuy = gold >= item.Price;
        }

        return this;
    }

    public void Buy(ICharacter character, IItem item)
    {
        double priceModifier = random.Next(75, 125) / (double)100;
        var price = priceModifier * item.Price;
        character.Gold -= (int)price;
        character.Backpack?.Add(item);
        Remove(item);
        var args = new ShopEventArgs(
            (int)price, item.Name, Structs.Action.Buy);

        if (ShopEvent is not null) ShopEvent(this, args);
    }

    /// TODO: Event
    public void Sell(ICharacter character, IItem item)
    {       
        double priceDeflator = random.Next(25, 75) / (double)100;
        var profit = priceDeflator * item.Price;
        character.Gold += (int)profit;
        Add(item);
        character.Backpack?.Remove(item);
        if (ShopEvent is not null) ShopEvent(this,
            new ShopEventArgs((int)profit, item.Name, Structs.Action.Sell));

    }

}
