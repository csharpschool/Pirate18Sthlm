namespace PirarteTreassure.Interfaces;

public interface IStorage<T>
{
    int Id { get; set; }
    int MaxSize { get; set; }
    int SquareSize { get; set; }
    int FreeWeight { get; }
    int MaxWeight { get; init; }
    int FreeSpace { get; }

    void Remove(T item);
    void Add(T item);
}
