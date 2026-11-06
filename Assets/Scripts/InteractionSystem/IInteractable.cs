using UnityEngine;

public interface IInteractable
{
    public string InteractionPrompt {get;}

    public bool Interact(Interactor interactor);

    public bool HoldInteract(Interactor interactor);
}
