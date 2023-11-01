using PirarteTreassure.Classes.Characters;
using PirarteTreassure.Interfaces;

namespace PirarteTreassure.Classes;

public class Backpack<T> : List<T>, IBackpack<T> where T : class, IItem
{
    public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int MaxSize { get; set; }
    public int SquareSize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int MaxWeight { get; init; }
    public int FreeWeight => MaxWeight - this.Sum(w => w.Weight);
    public int FreeSpace => MaxSize - Count;

    public Backpack(int maxWeight, int maxSize)
    {
        MaxWeight = maxWeight;
        MaxSize = maxSize;
    }
    public new void Add(T item)
    {
        if(item.Weight <= FreeWeight && item.Size <= FreeSpace)
            base.Add(item);
    }

    public void AddRange(List<T>? items)
    {
        if (items is null) return;
        base.AddRange(items);
    }

    public async Task AddRangeAsync(List<T>? items)
    {
        if (items is null) return;
        await Task.Run(() => base.AddRange(items));
    }

    public void Empty() => Clear();

    public List<T> GetItems() => this;
    public Backpack<T> GetBackpack() => this;

    public async Task EmptyAsync() => await Task.Run(Clear);
    public async Task<Backpack<T>> GetItemsAsync() => await Task.Run(() => this);

    public void Position(T item)
    {
        throw new NotImplementedException();
    }

    public new void Remove(T item)
    {
        base.Remove(item);
    }
}
