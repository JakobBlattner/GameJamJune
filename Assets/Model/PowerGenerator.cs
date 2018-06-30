using UnityEngine;

public class PowerGenerator : IInteractable
{
    public void Interact(IPlayer player, IShip ship)
    {
        Debug.Log("Interacting with 'PowerGenerator'...");
        Debug.Log("Power before: " + ship.Power);
        ship.AddPower(1);
        Debug.Log("Power after: " + ship.Power);
    }
}