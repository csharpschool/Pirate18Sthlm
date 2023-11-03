using PirarteTreassure.Interfaces;

namespace PirarteTreassure.Classes.Characters.Heros;

public class Barbarian : Character, IHero
{
    public Barbarian(string name, int backpackMaxWeight, int maxBackpackSize, double missFactor, List<IItem>? items = null) 
        : base(items, name, backpackMaxWeight, maxBackpackSize, missFactor)
    {
        HP = 45;
        Energy = 76;
        Strength = 49;
        Level = 5;
        Stamina = 23;
        Speed = 10;
        Stealth = 34;
        Intelligence = 20;
        Gold = 0;
    }

    public List<IHand> Hands { get; }

    public async Task<(int Gold, Backpack<IItem> Items)> Loot(ICharacter character)
    {
        try
        {
            var loot = await character.Backpack?.GetItemsAsync();

            character.Backpack = new Backpack<IItem>(character.MaxBackpackWeight, character.MaxBackpackSize);

            return loot is null 
                ? (character.Gold, new Backpack<IItem>(character.MaxBackpackWeight, character.MaxBackpackSize))
                : (character.Gold, loot);
        }
        catch
        {
            return (character.Gold, new Backpack<IItem>(character.MaxBackpackWeight, character.MaxBackpackSize));
        }
        
        //if(loot is null) return new List<IItem>();
        //return loot;
    }
    public void Drop()
    {
        throw new NotImplementedException();
    }

    public (int Gold, Backpack<IItem> Items) PickUp((int Gold, Backpack<IItem> Items) loot)
    { 
        Gold += loot.Gold;

        (int Gold, Backpack<IItem> Items) items = new()
        {
            Gold = 0,
            Items = loot.Items
        };

        return items;
    }
    
    public void AddToBackpack(IItem item)
    {
        Backpack?.Add(item);
    }
}
