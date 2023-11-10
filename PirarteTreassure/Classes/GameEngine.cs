using Microsoft.AspNetCore.Components.Web;
using PirarteTreassure.Classes.Characters.Heros;
using PirarteTreassure.Classes.Characters.Monsters;
using PirarteTreassure.Classes.Items.Consumables;
using PirarteTreassure.Classes.Items.Valuables;
using PirarteTreassure.Classes.Items.Weapons;
using PirarteTreassure.Classes.Map;
using PirarteTreassure.Extensions;
using PirarteTreassure.Interfaces;
using PirarteTreassure.Structs;
using System.ComponentModel;
using System.Net.Http.Headers;

namespace PirarteTreassure.Classes;
/// TODO: Starta om spelet då hjälten dör


public class GameEngine
{
    public IHero Hero { get; init; } = new Barbarian("Conan", 25, 36, 0.2);

    public Location CurrentLocation { get; private set; }

    List<ICharacter> Monsters { get; init; } = new()
    {
        new Kraken("Bob", 25, 300, 0.25),
        new Goblin("Floof", 0, 0, 0.8)
    };

    public List<ICharacter> Adversaries { get; private set; } = new();

    public List<Attack> BattleLog { get; private set; } = new();

    public (int Gold, Backpack<IItem> Items) LootedItems { get; set; } = new()
    { Gold = 0, Items = new Backpack<IItem>(1000, 1000) };

    public string Message { get; set; }

    public GameEngine()
    {
        Hero.Backpack?.Add(new Iron(10, "Iron Bar"));
        Hero.Backpack?.Add(new Ruby(1, 23, 1, 10, 25, 0.3, "Ruby", 100));
        Hero.Backpack?.Add(new Ruby(2, 23, 1, 10, 25, 0.25, "Small Ruby", 50));
        Hero.Backpack?.Add(new HealthPotion(3, 23, 1, 3, 25, 0.5,
            "Health Potion", 75, PotionStrength.Super));
        var kraken = Monsters.Single(m => m.Name == "Bob");
        kraken.Backpack?.Add(new Sword(0.95, "Jack", 200));

        #region Map
        Shop shop = new("Shop", new()
        {
            new Sword(0.75, "Percy", 45),
            new HealthPotion(3, 23, 1, 3, 25, 0.5,
            "Super Health Potion", 100, PotionStrength.Super)
        });
        shop.PlaceEvent += PlaceEvent;

        Smithy smithy = new("Smithy", new()
        {
            new Sword(0.75, "Ollie", 45),
            new Sword(0.75, "Bloodstained Blade", 45)
        });
        smithy.PlaceEvent += PlaceEvent;


        var hamlet = new Location("Hamlet", shop);
        var smithy1 = new Location("Smithy", smithy);
        var third = new Location("Third");
        var fourth = new Location("Fourth");

        hamlet.AddLocations(smithy1, fourth);
        smithy1.AddLocations(hamlet, third);
        third.AddLocations(smithy1, fourth);

        CurrentLocation = hamlet;
        #endregion
    }

    void PlaceEvent(object? sender, ShopEventArgs e)
    {
        Message = $"{e.Action}: {e.Name} {e.Price}";
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
            AdversaryAvatar = a.Avatar,
            Attacker = Hero.Name,
            AttackerHP = Hero.HP,
            AttackerAvatar = Hero.Avatar,
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
        Hero.AdrenalineBoost = 0;

        if (a.HP <= 0)
        {
            a.HP = 0;
            // XP
            var xp = a.Strength - Hero.Strength;
            Hero.XP += (int)(10 + xp);
            if(Hero.XP >= 100)
            {
                Hero.Level++;
                Hero.XP = 0;
                Hero.Strength += Hero.Strength * 1.1;
            }

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
                AdversaryAvatar = Hero.Avatar,
                Attacker = a.Name,
                AttackerHP = a.HP,
                AttackerAvatar = a.Avatar,
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
    public void Move(Location location)
    {
        CurrentLocation = location;
    }

}
