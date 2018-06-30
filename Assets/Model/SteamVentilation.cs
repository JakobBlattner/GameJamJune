using UnityEngine;

public class SteamVentilation : IInteractable
{
    public void Interact(IPlayer player, IShip ship)
    {
        Debug.Log("Interacting with 'PowerGenerator'...");
        Debug.Log("Steam before: " + ship.Steam);
        ship.ReleaseSteam();
        Debug.Log("Steam after: " + ship.Steam);
    }
}