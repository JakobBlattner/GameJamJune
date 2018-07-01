using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageStorage : MonoBehaviour, IInteractable
{
    public float CurrentDamage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Interact(IPlayer player, IShip ship)
    {
        CurrentDamage = CurrentDamage - ship.Config.RepairTick;
        ship.ApplyRapairTick(ship.Config.RepairTick);
        Debug.Log("Damage: " + CurrentDamage);
    }
}
