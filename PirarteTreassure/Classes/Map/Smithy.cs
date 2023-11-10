using PirarteTreassure.Classes.Items.Valuables;
using PirarteTreassure.Classes.Items.Weapons;
using PirarteTreassure.Interfaces;
using PirarteTreassure.Structs;
using System;
using System.ComponentModel.DataAnnotations;

namespace PirarteTreassure.Classes.Map;

public class Smithy : Place
{
    public Smithy(string name, List<IItem>? items) : base(name, items)
    {
    }

    public override Place Get(int gold)
    {
        foreach (IItem item in this)
        {
            item.CanBuy = gold >= item.Price;
        }

        return this;
    }

    public override void Buy(ICharacter character, IItem item, string? name)
    {
        var iron = character.Backpack?.Single(
            b => b.GetType() == typeof(Iron));

        ShopEventArgs args = new(
        item.Price, item.Name, Structs.Action.Failed);

        if (iron is null || iron.Weight < item.Weight ||
            character.Gold < item.Price)
        {
            TriggerEvent(args);
            return;
        }

        var weapon = new Weapon(
            name ?? "Weapon", random.NextDouble(), iron.Price + item.Price / 2);

        character.Backpack?.Add(weapon);
        character.Gold -= item.Price;
        iron.Weight -= item.Weight;

        if(iron.Weight <= 0) Remove(iron);

        args = new ShopEventArgs(
            item.Price, weapon.Name, Structs.Action.Craft);

        TriggerEvent(args);
    }

    /*public override void Sell(ICharacter character, IItem item)
    {
    }*/

}
