using PirarteTreassure.Interfaces;

namespace PirarteTreassure.Classes.Characters.Monsters;

public class Kraken : Character
{
    public Kraken(List<IItem>? items = null) : base(items)
    {
        HP = GenerateStat(63, 70);
        Energy = GenerateStat(45, 55);
        Strength = GenerateStat(75, 89);
        Level = GenerateStat(1, 3);
        Stamina = GenerateStat(60, 70);
        Speed = GenerateStat(2, 5);
        Stealth = GenerateStat(80, 90);
        Intelligence = GenerateStat(7, 12);
        Gold = GenerateStat(100, 200) * Level;
    }

}
