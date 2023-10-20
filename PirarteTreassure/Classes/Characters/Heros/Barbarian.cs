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

    // TODO: Gör Loot async och anv. WhenAll för att loota all monster
    // TODO: Gör så att BArbarian lootar när monstren dör
    public List<IItem> Loot(ICharacter character)
    {
        var loot = character.Backpack?.GetItems();
        character.Backpack?.Empty();

        return loot ?? new List<IItem>();

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
