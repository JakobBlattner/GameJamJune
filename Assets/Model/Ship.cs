using System;
using System.Diagnostics;
using UnityEngine;

public class Ship : IShip
{

    private static IShip _ship;

    public static IShip Instance
    {
        get { return _ship ?? (_ship = new Ship()); }
    }

    private Ship()
    {
        
    }

    public float Power { get; private set; }
    public float Shield { get; private set; }
    public float Health { get; private set; }
    public float Steam { get; private set; }
    public float Water { get; private set; }

    public void AddShield(int value)
    {
        Shield = Math.Min(100, Shield + value);
    }

    public void ReleaseSteam()
    {
        Steam = Math.Max(Steam--, 0);
    }

    public void AddPower(int value)
    {
        throw new NotImplementedException();
    }
}
