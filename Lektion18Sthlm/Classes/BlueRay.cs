using Lektion18Sthlm.Interfaces;

namespace Lektion18Sthlm.Classes;

public class BlueRay : IMovie, IMoviePlayer
{
    public int Id { get; init; }
    public string Title { get; private set; }
    public Genres Genre { get; set; }

    public BlueRay(int id, string title, Genres genre) =>
        (Id, Title, Genre) = (id, title, genre);
   
    public string Play() => $"Playing {Title}, {Genre}";

    public void Burn() { }

    public string SelectMenuItem(int id)
    {
        return "Menu 1";
    }
}
