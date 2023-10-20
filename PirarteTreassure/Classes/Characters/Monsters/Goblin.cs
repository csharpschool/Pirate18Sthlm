using PirarteTreassure.Interfaces;

namespace PirarteTreassure.Classes.Characters.Monsters;

public class Goblin : Character
{
    public Goblin(List<IItem>? items = null) : base(items)
    {
        HP = 34;
        Energy = 50;
        Strength = 45;
        Level = 1;
        Stamina = 23;
        Speed = 5;
        Stealth = 21;
        Intelligence = -1;
    }

}
