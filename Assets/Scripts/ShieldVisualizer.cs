using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldVisualizer : MonoBehaviour {

    private float shieldValue;
    private SpriteRenderer spr;

    void Start () {
        spr = this.GetComponent<SpriteRenderer>();
    }
	
    //changes opacity of shield according to current shield value
	void LateUpdate () {
        shieldValue = Ship.Instance.Shield;
        spr.color = new Color(255, 255, 255, shieldValue / 100);
    }
}
