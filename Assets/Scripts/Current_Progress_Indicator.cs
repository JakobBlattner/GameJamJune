using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Current_Progress_Indicator : MonoBehaviour {

    public GameObject start;
    public GameObject end;
    private Transform startTransform;
    private Transform endTransform;
    private float currentTime;
    private float travelledInPercent;
    private float startTime;
    private float totalDistance;
    public float levelTimeInMs;

    // Use this for initialization
    void Start () {
        if (start == null || end == null)
            Debug.LogError(this.gameObject.name+": No Start or End GameObject defined.");

        //position vectors
        this.transform.position = start.transform.position;        
        totalDistance = Vector2.Distance(start.transform.position, end.transform.position);
        startTransform = start.transform;
        endTransform = end.transform;

        startTime = Time.time;
    }

    void FixedUpdate () {

        currentTime = Time.time;
        travelledInPercent = (currentTime*1000 - startTime*1000)/(float)levelTimeInMs;

        //lerp between start and end
        this.transform.position = Vector2.Lerp(startTransform.position, endTransform.position, travelledInPercent);

        //Progress Bar has reached end position
		if(this.transform.position.x >= endTransform.position.x)
        {
            Debug.Log("End reached!");
        }
	}
}
