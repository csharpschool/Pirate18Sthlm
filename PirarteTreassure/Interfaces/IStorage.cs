namespace PirarteTreassure.Interfaces;

public interface IStorage
{
    public int Id { get; set; }
    public int MaxSize { get; set; }
    public int SquareSize { get; set; }
    void Remove(IItem item);
    void Add(IItem item);
}
