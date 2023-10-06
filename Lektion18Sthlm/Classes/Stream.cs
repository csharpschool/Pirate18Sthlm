using Lektion18Sthlm.Interfaces;

namespace Lektion18Sthlm.Classes;

public class Stream : IMovie
{
    public int Id { get; init; }
    public string Title { get; private set; }
    public Genres Genre { get; set; }

    public Stream(int id, string title, Genres genre) =>
        (Id, Title, Genre) = (id, title, genre);

    void Slask()
    {
        Title = "fgh";
    }

    public string Play() => $"Streaming {Title}, {Genre}";
    
}
