using PirarteTreassure.Classes;

namespace PirarteTreassure.Interfaces;

public interface IHero: ICharacter
{
    List<IHand> Hands { get; }
    public (int Gold, Backpack<IItem> Items) PickUp((int Gold, Backpack<IItem> Items) loot);
    void Drop();
    Task<(int Gold, Backpack<IItem> Items)> Loot(ICharacter character);
    void AddToBackpack(IItem item);
    
}
