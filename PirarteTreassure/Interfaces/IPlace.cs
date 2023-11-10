namespace PirarteTreassure.Interfaces;

public interface IPlace
{
    string Name { get; init; }
    List<IItem>? Items { get; set; }
}
