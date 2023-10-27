using PirarteTreassure.Classes.Characters;
using PirarteTreassure.Classes.Characters.Heros;
using PirarteTreassure.Classes.Characters.Monsters;
using PirarteTreassure.Classes.Items.Valuables;
using PirarteTreassure.Extensions;
using PirarteTreassure.Interfaces;
using System.Collections.Concurrent;

namespace PirarteTreassure.Classes;
/// TODO: Fixa meddelandena för attack (interpolerad sträng för meddelandena)
/// TODO: Kontrollera ledigt utrymme i ryggsäcken
/// TODO: Vikt hantering
/// TODO: Monster ska inte alltid släppa värdesaker när de besegras

public class GameEngine
{
    public IHero Hero { get; init; } = new Barbarian();

    List<ICharacter> Monsters { get; init; } = new()
    {
        new Kraken(),
        new Goblin()
    };

    public List<ICharacter> Adversaries { get; private set; } = new();

    public GameEngine()
    {
        Hero.Backpack?.Add(new Coin(1, 23, 1, 25, "Small Coin"));
    }

    public (int Gold, Backpack<IItem> Items) LootedItems { get; set; } = new() 
        { Gold = 0, Items = new Backpack<IItem>() };

    public bool Challenge()
    {
        AddNewMonsters();
        var a = Adversaries.Sum(a => a.AttackStrength());
        var h = Hero.AttackStrength();
        return h >= a;
    }

    void AddNewMonsters()
    {
        Adversaries.AddRange(Monsters);
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

        if (a.HP <= 0)
        {
            LootedItems.Items.AddRange(a.Backpack?.GetBackpack());

            (int Gold, Backpack<IItem> Items) items = new()
            {
                Gold = LootedItems.Gold + a.Gold,
                Items = LootedItems.Items
            };
            LootedItems = items;

            Adversaries.Remove(a);
        }

        return (true, inflictedDamage, a.HP <= 0);
    }
}
