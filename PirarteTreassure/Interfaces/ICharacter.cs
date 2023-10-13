namespace PirarteTreassure.Interfaces
{
    public interface ICharacter : IStatus
    {
        IBackpack? Backpack { get; set; }

        //bool Challenge(List<ICharacter> adversaries);

    }
}
