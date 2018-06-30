using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableComponent : MonoBehaviour
{
    public Interactable InteractableType;
    private IInteractable _interactable;

    public IInteractable GetInteractable()
    {
        if(_interactable == null)
        {
            switch (InteractableType)
            {
                case Interactable.ShieldGenerator:
                    _interactable = new ShieldGenerator();
                    break;
                case Interactable.SteamVentilation:
                    _interactable = new SteamVentilation();
                    break;
                case Interactable.PowerGenerator:
                    _interactable = new PowerGenerator();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        return _interactable;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
