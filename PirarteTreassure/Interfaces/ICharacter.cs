namespace PirarteTreassure.Interfaces
{
    public interface ICharacter : IStatus
    {
        IBackpack<IItem>? Backpack { get; set; }

        //bool Challenge(List<ICharacter> adversaries);

    }
}
