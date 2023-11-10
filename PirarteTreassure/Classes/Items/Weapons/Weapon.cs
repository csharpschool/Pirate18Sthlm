using PirarteTreassure.Interfaces;

namespace PirarteTreassure.Classes.Items.Weapons
{
    // Basklass
    public class Weapon : IItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public int Durability { get; set; }
        public double BaseDamage { get; set; } // Vapnets skada
        public int Weight { get; set; }
        public double DropChance { get; set; }
        public bool CanBuy { get; set; }
        public int Price { get; set; }

        public Weapon(string name, double dropChance, int price)
        {
            Name = name;
            DropChance = dropChance;
            Price = price;
            Weight = 10;
        }
    }
}
