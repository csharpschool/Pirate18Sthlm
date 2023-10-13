using PirarteTreassure.Interfaces;

namespace PirarteTreassure.Extensions;

public static class CharacterExtensions
{
    public static double AttackStrength(this ICharacter character) =>
        character.Strength + character.Energy * 0.1;

    public static double DefenseValue(this ICharacter character) =>
        character.Speed + character.Stamina * 0.2;

}
