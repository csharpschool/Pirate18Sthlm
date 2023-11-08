using PirarteTreassure.Interfaces;

namespace PirarteTreassure.Classes.Items.Valuables
{
    public class Ruby : IItem, IStackable
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public int MaxCount { get; set; }
        public int Weight { get; set; }
        public double DropChance { get; set; }
        public bool CanBuy { get; set; }
        public int Price { get; set; }

        public Ruby(int id, int value, int size, int weight, int maxCount, double dropChance, string name, int price)
            => (Id, Value, Size, Weight, MaxCount, DropChance, Name, Price) 
            = (id, value, size, weight, maxCount, dropChance, name, price);
    }
}
