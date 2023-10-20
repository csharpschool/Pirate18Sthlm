using PirarteTreassure.Interfaces;

namespace PirarteTreassure.Classes.Characters.Monsters;

public class Kraken : Character
{
    public Kraken(List<IItem>? items = null) : base(items)
    {
        HP = 67;
        Energy = 50;
        Strength = 89;
        Level = 3;
        Stamina = 67;
        Speed = 2;
        Stealth = 88;
        Intelligence = 10;
    }

}
