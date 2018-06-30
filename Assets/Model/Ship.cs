using System;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Ship : IShip
{
    
    private static IShip _ship;

    const float VuelTick = 0.01f;

    const float SteamTick = 0.04f;
    const float SteamTickCooling = 0.01f;
    const float ShieldTick = 0.2f;
    const float MaxSteamDamageTick = 0.03f;
    const float SteamReleaseTick = 5f;

    const float SteamOverloadThreshold = 75f;

    const float MaxValueVuelForSteam = 100f;
    const float MaxValueShield = 100f;
    const float MaxValueSteam = 100f;

    public static IShip Instance
    {
        get { return _ship ?? (_ship = new Ship()); }
    }

    private Ship()
    {
        Health = 100f;
        Vuel = 80f;
        Shield = 20f;
    }
    
    public float Vuel { get; private set; }
    public float Shield { get; private set; }
    public float Health { get; private set; }
    public float Steam { get; private set; }

    public void GenerateShield()
    {
        Vuel = Math.Max(Vuel - VuelTick, 0f);
        Shield = Math.Min(MaxValueShield, Shield + ShieldTick);
    }

    public void ReleaseSteam()
    {
        Steam = Math.Max(Steam - SteamReleaseTick, 0);
    }

    public void InsertVuel(float value)
    {
        Vuel = Math.Min(MaxValueVuelForSteam, Vuel + value);
    }

    public void Update()
    {
        VuelSteamEngine();
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

    private void VuelSteamEngine()
    {
        if(Vuel > VuelTick)
        { 
            Steam = Math.Min(Steam + SteamTick, MaxValueSteam);
            Vuel = Math.Max(Vuel - VuelTick, 0f);
        }
        else
        {
            Steam = Math.Max(Steam - SteamTickCooling, 0f);
        }
    }
}
