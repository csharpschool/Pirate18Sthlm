using PirarteTreassure.Interfaces;

namespace PirarteTreassure.Classes.Items.Consumables;

public enum PotionStrength
{
    Lesser = 20,
    Greater = 50,
    Super = 75
}
public class HealthPotion : IItem
{
    public int Id { get; set; }
    public int Value { get; set; }
    public string Name { get; set; }
    public int Size { get; set; }
    public int MaxCount { get; set; }
    public int Weight { get; set; }
    public double DropChance { get; set; }
    public PotionStrength Strength { get; init; }
    public bool CanBuy { get; set; }
    public int Price { get; set; }

    public HealthPotion(int id, int value, int size, int weight,
        int maxCount, double dropChance, string name, int price,
        PotionStrength strength = PotionStrength.Lesser)
        => (Id, Value, Size, Weight, MaxCount, DropChance, Price, Name, Strength)
        = (id, value, size, weight, maxCount, dropChance, price,
            $"{name} ({Enum.GetName(typeof(PotionStrength), strength)}: {(int)strength})", strength);

}
