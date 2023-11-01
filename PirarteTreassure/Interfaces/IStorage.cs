namespace PirarteTreassure.Interfaces;

public interface IStorage<T>
{
    public int Id { get; set; }
    public int MaxSize { get; set; }
    public int SquareSize { get; set; }
    public int FreeWeight { get; }
    public int MaxWeight { get; init; }

    void Remove(T item);
    void Add(T item);
}
