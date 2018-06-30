using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DoorTriggerTilemapCollisionControler : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("Collision started", gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        Tilemap map = this.GetComponent<Tilemap>();
        
        //Vector3Int cellPosition = map.WorldToCell(transform.position);
        Vector3Int cellPosition = new Vector3Int(
                 Mathf.RoundToInt(transform.position.x),
                 Mathf.RoundToInt(transform.position.y),
                 Mathf.RoundToInt(transform.position.z)
        );

        UnityEngine.Tilemaps.TileBase tile = map.GetTile(cellPosition);

        string tiletype = map.GetTile(cellPosition).name;

        Debug.Log("Collision: " + tiletype, gameObject);
    }
}
