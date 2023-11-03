using Microsoft.AspNetCore.Components.Web;
using PirarteTreassure.Classes.Characters.Heros;
using PirarteTreassure.Classes.Characters.Monsters;
using PirarteTreassure.Classes.Items.Consumables;
using PirarteTreassure.Classes.Items.Valuables;
using PirarteTreassure.Classes.Items.Weapons;
using PirarteTreassure.Extensions;
using PirarteTreassure.Interfaces;
using System.Net.Http.Headers;

namespace PirarteTreassure.Classes;
/// TODO: Monster fight back
/// TODO: Avatar för karaktärer
/// TODO: Shop
/// TODO: Slänga prylar
/// TODO: Starta om spelet då hjälten dör


public class GameEngine
{
    public IHero Hero { get; init; } = new Barbarian("Conan", 25, 36, 0.2);

    List<ICharacter> Monsters { get; init; } = new()
    {
        new Kraken("Bob", 25, 300, 0.25),
        new Goblin("Floof", 0, 0, 0.8)
    };

    public List<ICharacter> Adversaries { get; private set; } = new();

    public List<Attack> BattleLog { get; private set; } = new();

    public (int Gold, Backpack<IItem> Items) LootedItems { get; set; } = new()
    { Gold = 0, Items = new Backpack<IItem>(1000, 1000) };

    public GameEngine()
    {
        Hero.Backpack?.Add(new Ruby(1, 23, 1, 10, 25, 0.3, "Ruby"));
        Hero.Backpack?.Add(new Ruby(2, 23, 1, 10, 25, 0.25, "Small Ruby"));
        Hero.Backpack?.Add(new HealthPotion(3, 23, 1, 3, 25, 0.5, 
            "Health Potion", PotionStrength.Super));
        var kraken = Monsters.Single(m => m.Name == "Bob");
        kraken.Backpack?.Add(new Sword(0.95, "Jack"));
    }


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
        var hit = random.NextDouble() > Hero.MissFactor;
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
            MonsterAttack();
            return;
        }

        var inflictedDamage = (int)(Hero.AttackStrength() - a.DefenseValue());
        a.HP -= inflictedDamage;

        if (a.HP <= 0)
        {
            a.HP = 0;
            // Loot based on DropChance
            var lootedItems =
                a.Backpack?.GetBackpack().Where(
                    i => i.DropChance > random.NextDouble());

            LootedItems.Items.AddRange(lootedItems);

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
        attack.Message = attack.Dead ? "Dead" : "Alive";
        BattleLog.Add(attack);

        MonsterAttack();
    }
    public void MonsterAttack()
    {
        var random = new Random();
        var orderedAdversaries = 
            Adversaries.OrderByDescending(a => a.HP);

        foreach (var a in orderedAdversaries)
        {
            var attack = new Attack()
            {
                Adversary = Hero.Name,
                AdversaryHP = Hero.HP,
                Attacker = a.Name,
                AttackerHP = a.HP,
                Damage = 0,
                Dead = false
            };

            var hit = random.NextDouble() > a.MissFactor;

            if (!hit)
            {
                BattleLog.Add(attack);
                continue;
            }

            var inflictedDamage = (int)(a.AttackStrength() - Hero.DefenseValue());
            Hero.HP -= inflictedDamage;
            attack.Damage = inflictedDamage;

            if (Hero.HP <= 0)
            {
                Hero.HP = 0;
                attack.Dead = Hero.HP == 0;
                attack.Message = attack.Dead ? "Dead" : "Alive";
                BattleLog.Add(attack);
                return;
            }

            BattleLog.Add(attack);
        }
    }
    public void RemoveFromLoot(IItem item)
    {
        LootedItems.Items.Remove(item);
    }

    public void DrinkPotion(HealthPotion potion)
    {
        var remainingStrength =
            (int)potion.Strength - (100 - Hero.HP);
        
        Hero.HP += (int)potion.Strength;
        if(Hero.HP > 100) Hero.HP = 100;

        if (remainingStrength > 0) 
            Hero.AdrenalineBoost = remainingStrength;

        BattleLog.Add(new Attack
        {
            Message = remainingStrength <= 0
                ? $"Drank a Helth Potion ({(int)potion.Strength})"
                : $"Adrenaline Boost ({remainingStrength})",
            Adversary = "",
            AdversaryHP = 0,
            Attacker = Hero.Name,
            AttackerHP = Hero.HP,
            Damage = 0,
            Dead = false
        });

        Hero.Backpack?.Remove(potion);
    }
}
