using PirarteTreassure.Classes.Map;
using PirarteTreassure.Interfaces;
using PirarteTreassure.Structs;

namespace PirarteTreassure.Classes;

public class Shop : Place
{
    

    public Shop(string name, List<IItem>? items) : base(name, items)
    {
    }

    public override Shop Get(int gold)
    {    
        foreach (IItem item in this) 
        {
            item.CanBuy = gold >= item.Price;
        }

        return this;
    }

    public override void Buy(ICharacter character, IItem item, string? name)
    {
        double priceModifier = random.Next(75, 125) / (double)100;
        var price = priceModifier * item.Price;
        character.Gold -= (int)price;
        character.Backpack?.Add(item);
        Remove(item);
        var args = new ShopEventArgs(
            (int)price, item.Name, Structs.Action.Buy);

        TriggerEvent(args);
    }

    public override void Sell(ICharacter character, IItem item)
    {       
        double priceDeflator = random.Next(25, 75) / (double)100;
        var profit = priceDeflator * item.Price;
        character.Gold += (int)profit;
        Add(item);
        character.Backpack?.Remove(item);

        var args = new ShopEventArgs((int)profit, item.Name, Structs.Action.Sell);
        TriggerEvent(args);

    }

}
