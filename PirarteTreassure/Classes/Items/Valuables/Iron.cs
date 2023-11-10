using PirarteTreassure.Interfaces;

namespace PirarteTreassure.Classes.Items.Valuables;

public class Iron : IItem
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

    public Iron(int weight, string name)
        => (Weight, Name, Price)
        = (weight, name, weight);

}
