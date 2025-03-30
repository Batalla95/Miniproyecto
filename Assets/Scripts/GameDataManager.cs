using UnityEngine;

public static class GameDataManager
{
    public static float PlayerHealth { get; set; }
    public static float CurrentAmmo { get; set; }
    public static float CurrentMag { get; set; }

    public static void SaveGameData(float health, float ammo, float mag)
    {
        PlayerHealth = health;
        CurrentAmmo = ammo;
        CurrentMag = mag;
    }

    public static void ResetData()
    {
        PlayerHealth = 0;
        CurrentAmmo = 0;
        CurrentMag = 0;
    }
}
