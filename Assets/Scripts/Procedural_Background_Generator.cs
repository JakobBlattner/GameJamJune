using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Procedural_Background_Generator : MonoBehaviour {

    public Sprite first;
    public Sprite second;
    public Sprite third;
    public Sprite fourth;
    private Sprite[] availableBackgrounds;

	// Use this for initialization
	void Start () {
        if (first == null ||second == null || third==null ||fourth == null)
            Debug.LogError(this.name + ": You have to define four background sprites.");

        availableBackgrounds[0] = first;
        availableBackgrounds[1] = second;
        availableBackgrounds[2] = third;
        availableBackgrounds[3] = fourth;
    }

	void FixedUpdate () {
        //move this GO slowly from right to left

        //if vorderster background.transform.position.x < 135
            //choose random background
		    //spawn location: x=135 y=2 z=0
        //if there is a background on this position --> delete
	}
}
