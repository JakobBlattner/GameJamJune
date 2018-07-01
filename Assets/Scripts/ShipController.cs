using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameSettings
{
    float FuelTick { get; } 
    float SteamTick { get; } 
    float SteamTickCooling { get; } 
    float ShieldTick { get; } 
    float MaxSteamDamageTick { get; } 
    float SteamReleaseTick { get; }
    float SteamOverloadThreshold { get; } 
    float MaxValueFuelForSteam { get; } 
    float MaxValueShield { get; } 
    float MaxValueSteam { get; } 
    float DamageTileMultiplier { get; }
    float RepairTick { get; }
}

public class ShipController : MonoBehaviour, IGameSettings {
    public float SteamTick
    {
        get { return _steamTick; }
    }

    public float SteamTickCooling
    {
        get { return _steamTickCooling; }
    }

    public float ShieldTick
    {
        get { return _shieldTick; }
    }

    public float MaxSteamDamageTick
    {
        get { return _maxSteamDamageTick; }
    }

    public float SteamReleaseTick
    {
        get { return _steamReleaseTick; }
    }

    public float SteamOverloadThreshold
    {
        get { return _steamOverloadThreshold; }
    }

    public float MaxValueFuelForSteam
    {
        get { return _maxValueFuelForSteam; }
    }

    public float MaxValueShield
    {
        get { return _maxValueShield; }
    }

    public float MaxValueSteam
    {
        get { return _maxValueSteam; }
    }

    public float DamageTileMultiplier
    {
        get { return _damageTileMultiplier; }
    }

    public float RepairTick

    {
        get { return _repairTick; }
    }

    public float FuelTick
    {
        get { return _fuelTick; }
    }

    [SerializeField]
    private float _fuelTick;
    [SerializeField]
    private float _steamTick;
    [SerializeField]
    private float _steamTickCooling;
    [SerializeField]
    private float _shieldTick;
    [SerializeField]
    private float _maxSteamDamageTick;
    [SerializeField]
    private float _steamReleaseTick;
    [SerializeField]
    private float _steamOverloadThreshold;
    [SerializeField]
    private float _maxValueFuelForSteam;
    [SerializeField]
    private float _maxValueShield;
    [SerializeField]
    private float _maxValueSteam;
    [SerializeField]
    private float _damageTileMultiplier;
    [SerializeField]
    private float _repairTick;

    private IShip _ship;


    // Use this for initialization
    void Start ()
    {
        _ship = Ship.Instance;
        _ship.SetConfig(this);
    }

    void FixedUpdate()
    {
        _ship.Update();
    }

    // Update is called once per frame
    void Update () {
		
	}

}
