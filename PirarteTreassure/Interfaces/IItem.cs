namespace PirarteTreassure.Interfaces;

public interface IItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Size { get; set; }
    public int Weight { get; set; }

}
