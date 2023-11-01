namespace PirarteTreassure.Interfaces;

public interface IItem
{
    int Id { get; set; }
    string Name { get; set; }
    int Size { get; set; }
    int Weight { get; set; }
    double DropChance { get; set; }
}
