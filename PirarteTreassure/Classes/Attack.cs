namespace PirarteTreassure.Classes;

public class Attack
{
    public string? Attacker { get; set; }
    public string? Adversary { get; set; }
    public string? Message { get; set; }
    public int AttackerHP { get; set; }
    public int AdversaryHP { get; set; }
    public double Damage { get; set; }
    public bool Dead { get; set; }
}
