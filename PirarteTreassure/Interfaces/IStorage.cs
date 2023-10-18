namespace PirarteTreassure.Interfaces;

public interface IStorage<T>
{
    public int Id { get; set; }
    public int MaxSize { get; set; }
    public int SquareSize { get; set; }
    void Remove(T item);
    void Add(T item);
}
