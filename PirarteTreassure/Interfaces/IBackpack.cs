using PirarteTreassure.Classes;

namespace PirarteTreassure.Interfaces;

public interface IBackpack<T> : IStorage<T> where T : class, IItem
{
    void Sort();
    void Position(T item);
    void AddRange(List<T>? items);
    Task AddRangeAsync(List<T>? items);
    void Empty();
    List<T> GetItems();
    T? Single(Func<T, bool> filter);
    Backpack<T> GetBackpack();
    Task<Backpack<T>> GetItemsAsync();
    Task EmptyAsync();
}
