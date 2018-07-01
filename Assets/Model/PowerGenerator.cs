using UnityEngine;

public class PowerGenerator : IInteractable
{
    public void Interact(IPlayer player, IShip ship)
    {
        Debug.Log("Interacting with 'PowerGenerator'...");
        Debug.Log("Power before: " + ship.Fuel);
        ship.InsertFuel(1);
        Debug.Log("Power after: " + ship.Fuel);
    }
}