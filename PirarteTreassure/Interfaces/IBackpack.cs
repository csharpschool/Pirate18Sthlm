namespace PirarteTreassure.Interfaces;

public interface IBackpack : IStorage
{
    void Sort();
    void Position(IItem item);

}
