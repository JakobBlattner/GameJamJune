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
        healthBar.value = Ship.Instance.Health;
        shieldBar.value = Ship.Instance.Shield;
        powerBar.value = Ship.Instance.VuelForSteam;
        steamBar.value = Ship.Instance.Steam;
	}
}
