using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParameterVisualizer : MonoBehaviour {

    public Slider healthBar;
    public Slider shieldBar;
    public Slider powerBar;
    public Slider steamBar;

    // Use this for initialization
    void Start () {
        if (healthBar == null || shieldBar == null || powerBar == null || steamBar == null)
            Debug.Log("Not all parameter bars set in script. Add via Editor");
	}
	
	void LateUpdate () {
        healthBar.value = 0; //Ship.Health;
        shieldBar.value = 0; //Ship.Shield;
        powerBar.value = 0; //Ship.Power;
        steamBar.value = 0; //Ship.Steam;
	}
}
