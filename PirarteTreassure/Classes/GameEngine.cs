using PirarteTreassure.Classes.Characters.Heros;
using PirarteTreassure.Classes.Characters.Monsters;
using PirarteTreassure.Extensions;
using PirarteTreassure.Interfaces;

namespace PirarteTreassure.Classes;

public class GameEngine
{
    ICharacter hero = new Barbarian();
    List<ICharacter> adversaries = new()
    {
        new Kraken(),
        new Goblin()
    };

    public bool Challenge()
    {
        var a = adversaries.Sum(a => a.AttackStrength());
        var h = hero.AttackStrength();
        return h >= a;
    }

    public (bool Hit, double Damage, bool Dead) Attack() 
    {
        var random = new Random();
        var hit = random.NextDouble() > 0.2;
        if (!hit) return (false, 0, false);

        var minHP = adversaries.Min(a => a.HP);
        var a = adversaries.First(s => s.HP == minHP);
        var inflictedDamage = (int)(hero.AttackStrength() - a.DefenseValue());
        a.HP -= inflictedDamage;

        if(a.HP <= 0) adversaries.Remove(a);

        return (true, inflictedDamage, a.HP <= 0);
    }
}
