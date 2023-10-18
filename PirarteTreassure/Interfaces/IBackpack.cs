namespace PirarteTreassure.Interfaces;

public interface IBackpack<T> : IStorage<T>
{
    void Sort();
    void Position(T item);

}
