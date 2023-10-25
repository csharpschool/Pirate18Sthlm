using PirarteTreassure.Classes.Characters;
using PirarteTreassure.Classes.Characters.Heros;
using PirarteTreassure.Classes.Characters.Monsters;
using PirarteTreassure.Classes.Items.Valuables;
using PirarteTreassure.Extensions;
using PirarteTreassure.Interfaces;
using System.Collections.Concurrent;

namespace PirarteTreassure.Classes;
/// TODO: Visa Attackknappen bara om det finns motståndare
/// TODO: Challenge knappen lägger till nya motståndare
/// TODO: Kontrollera ledigt utrymme i ryggsäcken
/// TODO: Gör så att BArbarian lootar när monstren dör
/// TODO: Vikt hantering

public class GameEngine
{
    public IHero Hero { get; init; } = new Barbarian();

    public List<ICharacter> Adversaries { get; init; } = new()
    {
        new Kraken(),
        new Goblin(new List<IItem>
            {
                new Coin(1, 23, 1, 25, "Large Gold Coin 1"),
                new Coin(2, 23, 1, 25, "Large Gold Coin 2"),
                new Coin(3, 23, 1, 25, "Large Gold Coin 3")
            }
        )
    };

    public GameEngine()
    {
        Hero.Backpack?.Add(new Coin(1, 23, 1, 25, "Small Coin"));
    }

    public Backpack<IItem> LootedItems { get; set; } = new();

    public bool Challenge()
    {
        var a = Adversaries.Sum(a => a.AttackStrength());
        var h = Hero.AttackStrength();
        return h >= a;
    }

    public (bool Hit, double Damage, bool Dead) Attack() 
    {
        var random = new Random();
        var hit = random.NextDouble() > 0.2;
        if (!hit) return (false, 0, false);

        var minHP = Adversaries.Min(a => a.HP);
        var a = Adversaries.First(s => s.HP == minHP);
        var inflictedDamage = (int)(Hero.AttackStrength() - a.DefenseValue());
        a.HP -= inflictedDamage;

        if(a.HP <= 0) Adversaries.Remove(a);

        return (true, inflictedDamage, a.HP <= 0);
    }
}
