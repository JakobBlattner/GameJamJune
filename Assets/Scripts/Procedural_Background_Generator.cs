using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Procedural_Background_Generator : MonoBehaviour {

    private float speed = 0.1f;
    public GameObject first;
    public GameObject second;
    private GameObject[] availableBackgrounds;
    private GameObject[] availableAdditions;
    private bool dontSpawnNewBG;
    private Random rnd;

    // Use this for initialization
    void Start () {
        if (first == null ||second == null)
            Debug.LogError(this.name + ": You have to define four background sprites.");

        availableBackgrounds = new GameObject[2];
        availableBackgrounds[0] = first;
        availableBackgrounds[1] = second;
        dontSpawnNewBG = true;
        rnd = new Random();
    }

	void FixedUpdate () {
        dontSpawnNewBG = false;

        //move the children of this GO slowly from right to left
        foreach (Transform child in this.transform)
        {
            //only uses child if selected Backgrounds GO instantiate is not selected
            if (!child.name.Equals("InstiateThisBackgrounds"))
            {
                child.position = new Vector3(child.position.x - speed, child.position.y, child.position.z);

                //if child.position.x < -140 --> destroy
                if (child.position.x < -140)
                    Destroy(child.gameObject);
                //if no child 
                if (child.position.x > 120)
                    dontSpawnNewBG = true;
            }
        }

        if (!dontSpawnNewBG)
        {
            //choose random background and set this transform as parent
            GameObject newChild = Instantiate(availableBackgrounds[Random.Range(0, 1)], this.transform);
            //set position and localScale
            newChild.transform.position = new Vector3(135, 0, 0);
            newChild.transform.localScale = new Vector3(1.75f, 1.75f, 1f);
        }      
    }

    public float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }
}
