namespace PirarteTreassure.Interfaces;

public interface IBackpack<T> : IStorage<T>
{
    void Sort();
    void Position(T item);
    void AddRange(List<T>? items);
    void Empty();
    List<T> GetItems();
}
