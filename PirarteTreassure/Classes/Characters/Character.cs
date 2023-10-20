using PirarteTreassure.Interfaces;

namespace PirarteTreassure.Classes.Characters
{
    public abstract class Character : ICharacter
    {
        public IBackpack<IItem>? Backpack { get; set; } 
            = new Backpack<IItem>();
        public int HP { get; set; }
        public int Energy { get; set; }
        public int Strength { get; set; }
        public int Level { get; set; }
        public int Stamina { get; set; }
        public int Speed { get; set; }
        public int Stealth { get; set; }
        public int Intelligence { get; set; }

        public Character(List<IItem>? items) => Backpack.AddRange(items);
        
    }
}
