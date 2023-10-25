﻿using PirarteTreassure.Classes.Characters;
using PirarteTreassure.Interfaces;

namespace PirarteTreassure.Classes;

public class Backpack<T> : List<T>, IBackpack<T> where T : class
{
    public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int MaxSize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int SquareSize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public new void Add(T item)
    {
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

    public async Task EmptyAsync() => await Task.Run(Clear);
    public async Task<Backpack<T>> GetItemsAsync() => await Task.Run(() => this);

    public void Position(T item)
    {
        throw new NotImplementedException();
    }

    public new void Remove(T item)
    {
        throw new NotImplementedException();
    }
}
