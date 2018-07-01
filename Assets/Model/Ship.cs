using System;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Ship : IShip
{
    
    private static IShip _ship;

    const float FuelTick = 0.01f;

    const float SteamTick = 0.04f;
    const float SteamTickCooling = 0.01f;
    const float ShieldTick = 0.2f;
    const float MaxSteamDamageTick = 0.03f;
    const float SteamReleaseTick = 5f;

    const float SteamOverloadThreshold = 75f;

    const float MaxValueFuelForSteam = 100f;
    const float MaxValueShield = 100f;
    const float MaxValueSteam = 100f;
    const float MaxValueStardust = 3f;

    public static IShip Instance
    {
        get { return _ship ?? (_ship = new Ship()); }
    }

    private Ship()
    {
        Health = 100f;
        Fuel = 80f;
        Shield = 20f;
    }
    
    public float Fuel { get; private set; }
    public float Shield { get; private set; }
    public float Health { get; private set; }
    public float Steam { get; private set; }

    public void GenerateShield()
    {
        Fuel = Math.Max(Fuel - FuelTick, 0f);
        Shield = Math.Min(MaxValueShield, Shield + ShieldTick);
    }

    public void ReleaseSteam()
    {
        Steam = Math.Max(Steam - SteamReleaseTick, 0);
    }

    public void InsertFuel(float value)
    {
        Fuel = Math.Min(MaxValueFuelForSteam, Fuel + value);
    }

    public void Update()
    {
        FuelSteamEngine();
        HandleSteamOverload();
    }

    private void HandleSteamOverload()
    {
        if (Steam > SteamOverloadThreshold)
        {
            var excessSteam = Steam - SteamOverloadThreshold;
            var maxExcessSteam = MaxValueSteam - SteamOverloadThreshold;
            var damageMultiplier = excessSteam / maxExcessSteam;
            Health = Health - damageMultiplier * MaxSteamDamageTick;
        }
    }

    private void FuelSteamEngine()
    {
        if(Fuel > FuelTick)
        { 
            Steam = Math.Min(Steam + SteamTick, MaxValueSteam);
            Fuel = Math.Max(Fuel - FuelTick, 0f);
        }
        else
        {
            Steam = Math.Max(Steam - SteamTickCooling, 0f);
        }
    }
}
