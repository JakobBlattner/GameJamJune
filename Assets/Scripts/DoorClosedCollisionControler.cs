using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClosedCollisionControler : MonoBehaviour {
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Player")
        {
            this.SetComponents(false);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        Debug.Log(other.gameObject.name, gameObject);
        if (other.gameObject.name == "Player")
        {
            this.SetComponents(true);
        }
    }

    private void SetComponents(bool v)
    {
        this.GetComponents<BoxCollider2D>()[0].enabled = v;
        this.GetComponent<SpriteRenderer>().enabled = v;
    }
}
