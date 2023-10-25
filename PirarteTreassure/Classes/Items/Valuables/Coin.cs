using PirarteTreassure.Interfaces;

namespace PirarteTreassure.Classes.Items.Valuables
{
    public class Coin : IItem, IStackable
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public int MaxCount { get; set; }

        public Coin(int id, int value, int size, int maxCount, string name)
            => (Id, Value, Size, MaxCount, Name) 
            = (id, value, size, maxCount, name);
    }
}
