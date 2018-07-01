using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageStorage : MonoBehaviour, IInteractable
{
    public Sprite SpriteDamageLow;
    public Sprite SpriteDamageMed;
    public Sprite SpriteDamageHigh;
    public Sprite SpriteDamageSuperHigh;

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
        SetSpriteToMatchCurrentDamage();
        ship.ApplyRapairTick(ship.Config.RepairTick);
    }

    private void SetSpriteToMatchCurrentDamage()
    {
        var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (CurrentDamage < 20)
            spriteRenderer.sprite = SpriteDamageLow;
        else if (CurrentDamage < 55)
            spriteRenderer.sprite = SpriteDamageMed;
        else if (CurrentDamage < 75)
            spriteRenderer.sprite = SpriteDamageHigh;
        else if (CurrentDamage < 95)
            spriteRenderer.sprite = SpriteDamageSuperHigh;

    }

    public void ApplyDamage(float value)
    {
        CurrentDamage = Math.Min(CurrentDamage + value, 100);
        SetSpriteToMatchCurrentDamage();
    }
}
