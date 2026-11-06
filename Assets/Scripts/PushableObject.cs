using UnityEngine;

public class PushableObject : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    public float pushSpeed = 3f;
    private Rigidbody2D pushableObjectRigidbody;


    public string InteractionPrompt => _prompt;

    void Awake()
    {
        pushableObjectRigidbody = GetComponent<Rigidbody2D>();
    }

    public bool Interact(Interactor interactor)
    {
        return true;
    }
    public bool HoldInteract(Interactor interactor)
    {
        Vector2 direction = interactor.GetFacingDirecton();

        if(!interactor.IsMoving())
            return false;
        
        Push(direction);

        return true;
    }

    public void Push(Vector2 direction)
    {
        pushableObjectRigidbody.MovePosition(pushableObjectRigidbody.position + direction.normalized * pushSpeed * Time.fixedDeltaTime);
    }
    
}
