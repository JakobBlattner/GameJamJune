public interface IPlayer
{
    void Interact();
    void Attach(IInteractable interactable);
    void Detach(IInteractable interactable);
}