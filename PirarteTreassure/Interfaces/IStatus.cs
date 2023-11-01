namespace PirarteTreassure.Interfaces
{
    public interface IStatus
    {
        public int HP { get; set; } // Hälsa
        public int Energy { get; set; } // Energi/Mat
        public int Strength { get; set; }
        public int Level { get; set; }
        public int Stamina { get; set; }
        public int Speed { get; set; }
        public int Stealth { get; set; }
        public int Intelligence { get; set; }
        public int MaxBackpackWeight { get; init; }
    }
}
