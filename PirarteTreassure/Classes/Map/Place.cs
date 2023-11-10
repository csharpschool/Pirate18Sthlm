using PirarteTreassure.Interfaces;
using PirarteTreassure.Structs;
using System;

namespace PirarteTreassure.Classes.Map;

public abstract class Place : List<IItem>
{
    public event EventHandler<ShopEventArgs>? PlaceEvent;
    protected Random random = new();

    public string Name { get; init; }
    public abstract Place Get(int gold);

    public void TriggerEvent(ShopEventArgs e)
    {
        if (PlaceEvent is not null) PlaceEvent(this, e);
    }

    public virtual void Buy(ICharacter character, IItem item, string? name)
    {
    }

    public virtual void Sell(ICharacter character, IItem item)
    {
    }

    public Place(string name, List<IItem>? items)
    {
        Name = name;
        if(items != null) AddRange(items);
    }
}
