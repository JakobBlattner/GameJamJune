using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void FixedUpdate()
    {
        var ship = GetShip();
        ship.Update();
    }

    private IShip GetShip()
    {
        return Ship.Instance;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
