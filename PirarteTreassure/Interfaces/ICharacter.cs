namespace PirarteTreassure.Interfaces
{
    public interface ICharacter : IStatus
    {
        IBackpack<IItem>? Backpack { get; set; }
        int Gold { get; set; }
        string Name { get; init; }
    }
}
