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
        Health = 100f;
    }
    
    public float Vuel { get; private set; }
    public float Shield { get; private set; }
    public float Health { get; private set; }
    public float Steam { get; private set; }

    public void AddShield(int value)
    {
        const float maxShield = 100;
        Shield = Math.Min(maxShield, Shield + value);
    }

    public void ReleaseSteam()
    {
        const float steamReleaseValue = 5;
        Steam = Math.Max(Steam - steamReleaseValue, 0);
    }

    public void InsertVuel(int value)
    {
        throw new NotImplementedException();
    }

    public void Update()
    {
        Steam = Math.Min(Steam + 0.2f, 100f);
        Vuel = Math.Max(Vuel - 0.1f, 0f);

        if (Math.Abs(Steam - 100) < 0.1f)
        {
            Health = Health - 0.05f;
        }

    }
}
