namespace PirarteTreassure.Interfaces;

public enum Hands
{
    Left,
    Right
}

public interface IHand : IStorage<IItem>
{
    public Hands Hand { get; set; }

}
