using System.Collections.Generic;

public class Player : IPlayer
{
    private static IPlayer _player;
    private readonly HashSet<IInteractable> _interactables = new HashSet<IInteractable>();

    public static IPlayer Instance
    {
        get { return _player ?? (_player = new Player()); }
    }

    private Player()
    {

    }

    public void Interact()
    {
        foreach (var interactable in _interactables)
        {
            interactable.Interact(this, Ship.Instance);
        }
    }

    public void Attach(IInteractable interactable)
    {
        _interactables.Add(interactable);
    }

    public void Detach(IInteractable interactable)
    {
        _interactables.Remove(interactable);
    }
}