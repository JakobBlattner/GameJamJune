using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldVisualizer : MonoBehaviour {

    private float shieldValue;
    private SpriteRenderer spr;
    private PolygonCollider2D pc;

    void Start () {
        spr = this.GetComponent<SpriteRenderer>();
        pc = this.GetComponent<PolygonCollider2D>();
    }
	
    //changes opacity of shield according to current shield value
	void LateUpdate () {
        shieldValue = Ship.Instance.Shield;
        spr.color = new Color(255, 255, 255, shieldValue / 100);

        //deactivates sprite if shieldValue is zero
        if (shieldValue == 0)
            pc.enabled = false;
        else if (spr.enabled == false)
            pc.enabled = true;
    }
}
