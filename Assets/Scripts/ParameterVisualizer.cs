using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParameterVisualizer : MonoBehaviour {

    public Slider healthBar;
    public Slider shieldBar;
    public Slider powerBar;
    public Slider steamBar;
    private Image steamFillImage;
    private Procedural_Background_Generator backgroundAnim;
    private GameObject engineFireLeft;
    private GameObject engineFireRight;

    // Use this for initialization
    void Start () {
        if (healthBar == null || shieldBar == null || powerBar == null || steamBar == null)
            Debug.Log("Not all parameter bars set in script. Add via Editor");

        backgroundAnim= GameObject.Find("Backgrounds").GetComponent<Procedural_Background_Generator>();
        Transform trans = steamBar.transform.Find("Fill Area").transform.Find("Fill");
        steamFillImage = trans.gameObject.GetComponent<Image>();

        engineFireLeft = GameObject.Find("EngineFire_Left");
        engineFireRight = GameObject.Find("EngineFire_Right");
    }
	
	void LateUpdate () {
        healthBar.value = Ship.Instance.Health;
        shieldBar.value = Ship.Instance.Shield;
        powerBar.value = Ship.Instance.Vuel;
        steamBar.value = Ship.Instance.Steam;

        //TODO get value from config
        if (steamBar.value < 70)
        {
            //grey
            steamFillImage.color = Color.grey;
            backgroundAnim.Speed = 0.1f;
            this.SetEngineFireActive(1);
        }
        else if (steamBar.value < 90)
        {
            //green
            steamFillImage.color = Color.green;
            backgroundAnim.Speed = 0.25f;
            this.SetEngineFireActive(2);
        }
        else
        {
            //red
            steamFillImage.color = Color.red;
            backgroundAnim.Speed = 0.5f;
            this.SetEngineFireActive(3);
        }
    }

    private void SetEngineFireActive(int v)
    {
        foreach (Transform child in engineFireRight.transform)
        {
            if (child.name.Contains("engine" + v))
                child.gameObject.SetActive(true);
            else
                child.gameObject.SetActive(false);
        }

        foreach (Transform child in engineFireLeft.transform) {
            if (child.name.Contains("engine" + v))
                child.gameObject.SetActive(true);
            else
                child.gameObject.SetActive(false);
        }
    }
}
