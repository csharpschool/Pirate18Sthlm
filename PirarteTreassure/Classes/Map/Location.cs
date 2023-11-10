using PirarteTreassure.Interfaces;

namespace PirarteTreassure.Classes.Map;

public class Location : ILocation
{
    public List<Location>? Locations { get; private set; } = new();
    public string Name { get; init; }
    public Place? Place { get; set; }

    public void AddLocations(params Location[] locations)
    { 
        foreach (var location in locations)
            Locations?.Add(location);
    }

    public Location(string name, Place? place = null)
    {
        Name = name;
        Place = place;
    }
}
