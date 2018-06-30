using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    private IPlayer _player;
    private IShip _ship;

    // Use this for initialization
	void Start ()
	{
	    _player = Player.Instance;
	    _ship = Ship.Instance;
	    Debug.Log("Start");

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("Something triggered with me!!!");
        var interactable = GetInteractable(coll);
        if (interactable != null)
        {
            Debug.Log(interactable);
            _player.Attach(interactable);
        }
        else
        {
            Debug.Log("Interactable is  null");

        }

    }

    private static IInteractable GetInteractable(Collider2D coll)
    {
        var interactableComponent = coll.GetComponent<InteractableComponent>();
        return interactableComponent != null ? interactableComponent.GetInteractable() : null;
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        Debug.Log("Something triggered with me!!!");
        var interactable = GetInteractable(coll);
        
        if (interactable != null)
        {
            Debug.Log("Triggered by " +interactable);
            _player.Detach(interactable);
        }
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("Something collided with me!!!");
    }
}
