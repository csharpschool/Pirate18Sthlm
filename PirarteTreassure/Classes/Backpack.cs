﻿using PirarteTreassure.Interfaces;

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

    public void Position(T item)
    {
        throw new NotImplementedException();
    }

    public new void Remove(T item)
    {
        throw new NotImplementedException();
    }
}