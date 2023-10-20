﻿using PirarteTreassure.Classes;

namespace PirarteTreassure.Interfaces;

public interface IHero: ICharacter
{
    List<IHand> Hands { get; }
    void PickUp();
    void Drop();
    List<IItem> Loot(ICharacter character);

}
