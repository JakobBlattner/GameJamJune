using UnityEngine;

public class PowerGenerator : IInteractable
{
    public void Interact(IPlayer player, IShip ship)
    {
        Debug.Log("Interacting with 'PowerGenerator'...");
        Debug.Log("Vuel before: " + ship.Vuel);
        ship.InsertVuel(1);
        Debug.Log("Vuel after: " + ship.Vuel);
    }
}