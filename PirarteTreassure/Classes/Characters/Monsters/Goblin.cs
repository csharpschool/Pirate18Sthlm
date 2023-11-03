using PirarteTreassure.Classes.Items.Valuables;
using PirarteTreassure.Interfaces;

namespace PirarteTreassure.Classes.Characters.Monsters;

public class Goblin : Character
{

    public Goblin(string name, int backpackMaxWeight, int maxBackpackSize, double missFactor) 
        : base(null, name, backpackMaxWeight, maxBackpackSize, missFactor)
    {
        HP = GenerateStat(63, 70);
        Energy = GenerateStat(47, 53);
        Strength = GenerateStat(42, 48);
        Level = GenerateStat(1, 3);
        Stamina = GenerateStat(20, 23);
        Speed = GenerateStat(2, 7);
        Stealth = GenerateStat(15, 25);
        Intelligence = GenerateStat(1, 3) * - 1;
        Gold = GenerateStat(3, 5) * Level;
        //GenerateValuables();
    }

}
