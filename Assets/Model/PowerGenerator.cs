using UnityEngine;

public class PowerGenerator : IInteractable
{
    public void Interact(IPlayer player, IShip ship)
    {
        Debug.Log("Interacting with 'PowerGenerator'...");
        Debug.Log("VuelForSteam before: " + ship.VuelForShield);
        ship.InsertVuelForSteam(1);
        Debug.Log("VuelForSteam after: " + ship.VuelForShield);
    }
}