using PirarteTreassure.Classes.Characters;
using PirarteTreassure.Classes.Characters.Heros;
using PirarteTreassure.Classes.Characters.Monsters;
using PirarteTreassure.Classes.Items.Valuables;
using PirarteTreassure.Extensions;
using PirarteTreassure.Interfaces;
using System.Collections.Concurrent;

namespace PirarteTreassure.Classes;
/// TODO: Monster fight back
/// TODO: Monster ska inte alltid släppa värdesaker när de besegras

public class GameEngine
{
    public IHero Hero { get; init; } = new Barbarian("Conan", 25, 36);

    List<ICharacter> Monsters { get; init; } = new()
    {
        new Kraken("Bob", 25, 300),
        new Goblin("Floof", 0, 0)
    };

    public List<ICharacter> Adversaries { get; private set; } = new();

    public List<Attack> BattleLog { get; private set; } = new();

    public GameEngine()
    {
        Hero.Backpack?.Add(new Ruby(1, 23, 1, 10, 25, "Ruby"));
        Hero.Backpack?.Add(new Ruby(1, 23, 1, 10, 25, "Ruby"));
        Hero.Backpack?.Add(new Ruby(1, 23, 1, 10, 25, "Ruby"));
    }

    public (int Gold, Backpack<IItem> Items) LootedItems { get; set; } = new() 
        { Gold = 0, Items = new Backpack<IItem>(1000, 1000) };

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

    public void Attack() 
    {
        var random = new Random();
        var hit = random.NextDouble() > 0.2;
        var minHP = Adversaries.Min(a => a.HP);
        var a = Adversaries.First(s => s.HP == minHP);
        var attack = new Attack()
        {
            Adversary = a.Name,
            AdversaryHP = a.HP,
            Attacker = Hero.Name,
            AttackerHP = Hero.HP,
            Damage = 0,
            Dead = false
        };

        if (!hit)//return (false, 0, false);
        {
            BattleLog.Add(attack);
            return;
        }

        var inflictedDamage = (int)(Hero.AttackStrength() - a.DefenseValue());
        a.HP -= inflictedDamage;

        if (a.HP <= 0)
        {
            a.HP = 0;
            LootedItems.Items.AddRange(a.Backpack?.GetBackpack());

            (int Gold, Backpack<IItem> Items) items = new()
            {
                Gold = LootedItems.Gold + a.Gold,
                Items = LootedItems.Items
            };
            LootedItems = items;

            Adversaries.Remove(a);
        }

        attack.Damage = inflictedDamage;
        attack.AdversaryHP = a.HP;
        attack.Dead = a.HP == 0;
        BattleLog.Add(attack);
    }
}
