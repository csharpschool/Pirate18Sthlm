using PirarteTreassure.Classes.Map;

namespace PirarteTreassure.Interfaces;

public interface ILocation
{
    List<Location> Locations { get; }
    string Name { get; init; }
    Place? Place { get; set; }
    void AddLocations(params Location[] locations);
}
