using PirarteTreassure.Interfaces;

namespace PirarteTreassure.Classes.Characters.Heros;

public class Barbarian : Character, IHero
{
    public Barbarian(List<IItem>? items = null) : base(items)
    {
        HP = 45;
        Energy = 76;
        Strength = 49;
        Level = 5;
        Stamina = 23;
        Speed = 10;
        Stealth = 34;
        Intelligence = 20;
    }

    public List<IHand> Hands { get; }

    /// TODO: Gör Loot async och anv. WhenAll för att loota all monster
    /// TODO: Gör så att BArbarian lootar när monstren dör
    /// TODO: Vikt hantering
    public async Task<Backpack<IItem>> Loot(ICharacter character)
    {
        try
        {
            //var loot = character.Backpack?.GetItemsAsync();
            //var empty = character.Backpack?.EmptyAsync();
            //await Task.WhenAll(loot, empty);
            //return loot?.Result ?? new List<IItem>();

            var loot = await character.Backpack?.GetItemsAsync();
            //await character.Backpack?.EmptyAsync();
            return loot ?? new Backpack<IItem>();
        }
        catch
        {
            return new Backpack<IItem>();
        }
        
        //if(loot is null) return new List<IItem>();
        //return loot;
    }
    public void Drop()
    {
        throw new NotImplementedException();
    }

    public void PickUp()
    {
        throw new NotImplementedException();
    }
}
