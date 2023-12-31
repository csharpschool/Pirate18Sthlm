﻿namespace PirarteTreassure.Interfaces
{
    public interface IStatus
    {
        int HP { get; set; } // Hälsa
        int Energy { get; set; } // Energi/Mat
        double Strength { get; set; }
        int Level { get; set; }
        int XP { get; set; }
        int Stamina { get; set; }
        int Speed { get; set; }
        int Stealth { get; set; }
        int Intelligence { get; set; }
        int MaxBackpackWeight { get; init; }
        int MaxBackpackSize { get; init; }
        double MissFactor { get; init; }
        int AdrenalineBoost { get; set; }
    }
}
