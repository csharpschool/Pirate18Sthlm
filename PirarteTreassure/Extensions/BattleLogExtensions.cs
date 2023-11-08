using PirarteTreassure.Classes;

namespace PirarteTreassure.Extensions;

public static class BattleLogExtensions
{
    public static List<Attack> ReverseTake(this List<Attack> attacks, int count)
    {
        attacks.Reverse();
        return attacks.Take(count).ToList();
    }
}
