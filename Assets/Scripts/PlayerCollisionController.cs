using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    private IPlayer _player;

    // Use this for initialization
	void Start ()
	{
	    _player = Player.Instance;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        var interactable = GetInteractable(coll);
        if (interactable != null)
            _player.Attach(interactable);
    }


    void OnTriggerExit2D(Collider2D coll)
    {
        var interactable = GetInteractable(coll);
        
        if (interactable != null)
            _player.Detach(interactable);
    }

    private static IInteractable GetInteractable(Collider2D coll)
    {
        var interactableComponent = coll.GetComponent<InteractableComponent>();
        return interactableComponent != null ? interactableComponent.GetInteractable() : null;
    }
}
