namespace PirarteTreassure.Interfaces;

public enum Hands
{
    Left,
    Right
}

public interface IHand : IStorage
{
    public Hands Hand { get; set; }

}
