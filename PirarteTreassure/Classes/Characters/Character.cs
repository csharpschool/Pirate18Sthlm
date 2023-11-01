using PirarteTreassure.Classes.Items.Valuables;
using PirarteTreassure.Interfaces;

namespace PirarteTreassure.Classes.Characters
{
    public abstract class Character : ICharacter
    {
        public IBackpack<IItem>? Backpack { get; set; }
        public int HP { get; set; }
        public int Energy { get; set; }
        public int Strength { get; set; }
        public int Level { get; set; }
        public int Stamina { get; set; }
        public int Speed { get; set; }
        public int Stealth { get; set; }
        public int Intelligence { get; set; }
        public int Gold { get; set; }
        public string Name { get; init; }
        public int MaxBackpackWeight { get; init; }

        Random rnd = new();

        protected int GenerateStat(int min, int max) => rnd.Next(min, max);
        /*protected void GenerateValuables()
        {
            if(Level > 0)
            {
                if(rnd.NextInt64(0, 1) == 1)
                {
                    
                    

                }

            }
        }*/


        public Character(List<IItem>? items, string name, int maxWeight)
        { 
            Name = name;
            MaxBackpackWeight = maxWeight;
            Backpack = new Backpack<IItem>(maxWeight);
            Backpack?.AddRange(items);
        }

    }
}
