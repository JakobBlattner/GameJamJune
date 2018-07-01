using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClosedCollisionControler : MonoBehaviour {

    private const string ParameterIsOpening = "IsOpening";
    private bool visible;

    void Start()
    {
        visible = true;
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Door:opening");

        if (other.gameObject.name == "Player")
        {
            Animator myAnimator = this.GetComponent<Animator>();
            myAnimator.SetBool(ParameterIsOpening, true);
            Debug.Log("Door opening");

            new WaitForSeconds(1f);

            visible = false;
            SetComponents(visible);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        Debug.Log("Door:closing");

        if (other.gameObject.name == "Player")
        {
            Animator myAnimator = this.GetComponent<Animator>();
            myAnimator.SetBool(ParameterIsOpening, false);
            Debug.Log("Door closing");

            visible = true;
            SetComponents(visible);
        }
    }

    IEnumerator WaitAndSetComponents()
    {
        yield return new WaitForSeconds(1f);
        this.SetComponents(visible);
    }

    private void SetComponents(bool v)
    {
        this.GetComponents<BoxCollider2D>()[0].enabled = v;
        //this.GetComponent<SpriteRenderer>().enabled = v;
    }
}
