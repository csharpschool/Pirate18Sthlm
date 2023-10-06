namespace Lektion18Sthlm.Interfaces;

public enum Genres
{
    Horror,
    Fantasy,
    Comedy,
    Action,
    Animated,
    Drama
}

public interface IMovie //: IMoviePlayer
{
    public int Id { get; init; }
    public string Title { get; }
    public Genres Genre { get; set; }
}

public interface IMoviePlayer
{
    string Play();
}