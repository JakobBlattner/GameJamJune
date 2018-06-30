using UnityEngine;

public class ShieldGenerator : IInteractable
{
    public void Interact(IPlayer player, IShip ship)
    {
        Debug.Log("Interacting with 'ShieldGenerator'...");
        Debug.Log("Shield before: " + ship.Shield);
        ship.AddShield(1);
        Debug.Log("Shield after: " + ship.Shield);
    }
}