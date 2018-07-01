using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    void FixedUpdate()
    {
        var ship = GetShip();
        ship.Update();
    }

    private IShip GetShip()
    {
        return Ship.Instance;
    }
}
