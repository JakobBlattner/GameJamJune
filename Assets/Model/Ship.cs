using System;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Ship : IShip
{
    
    private static IShip _ship;

    const float VuelForSteamTick = 0.01f;
    const float SteamTick = 0.03f;
    const float SteamTickCooling = 0.01f;
    const float VuelShieldTick = 0.1f;
    const float ShieldTick = 0.2f;
    const float MaxSteamDamageTick = 0.1f;
    const float SteamReleaseTick = 5f;

    const float SteamOverloadThreshold = 85f;

    const float MaxValueVuelForSteam = 100f;
    const float MaxValueShield = 100f;
    const float MaxValueVuelForShield = 100;
    const float MaxValueHealth = 100f;
    const float MaxValueSteam = 100f;

    public static IShip Instance
    {
        get { return _ship ?? (_ship = new Ship()); }
    }

    private Ship()
    {
        Health = 100f;
        VuelForSteam = 80f;
        VuelForShield = 30f;
        Shield = 20f;
    }
    
    public float VuelForSteam { get; private set; }
    public float VuelForShield { get; private set; }
    public float Shield { get; private set; }
    public float Health { get; private set; }
    public float Steam { get; private set; }

    public void AddShield(int value)
    {
        Shield = Math.Min(MaxValueShield, Shield + value);
    }

    public void ReleaseSteam()
    {
        Steam = Math.Max(Steam - SteamReleaseTick, 0);
    }

    public void InsertVuelForSteam(int value)
    {
        VuelForSteam = Math.Min(MaxValueVuelForSteam, VuelForSteam + value);
    }

    public void InsertVuelForShield(int value)
    {
        VuelForShield = Math.Min(MaxValueVuelForShield, VuelForShield + value);
    }

    public void Update()
    {
        VuelSteamEngine();
        VuelShieldGenerator();
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
        if(VuelForSteam > VuelForSteamTick)
        { 
            Steam = Math.Min(Steam + SteamTick, MaxValueHealth);
            VuelForSteam = Math.Max(VuelForSteam - VuelForSteamTick, 0f);
        }
        else
        {
            Steam = Math.Max(Steam - SteamTickCooling, 0f);
        }
    }
    private void VuelShieldGenerator()
    {
        if(VuelForShield > VuelShieldTick)
        {
            Shield = Math.Min(Shield + ShieldTick, MaxValueShield);
            VuelForShield = Math.Max(VuelForShield - VuelShieldTick, 0f);
        }
    }
}
