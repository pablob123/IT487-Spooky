using UnityEngine;

public class PushableObject : MonoBehaviour
{
    public float pushSpeed = 3f;

    private Rigidbody2D pushableObjectRigidbody;

    void Awake()
    {
        pushableObjectRigidbody = GetComponent<Rigidbody2D>();
    }

    public void Push(Vector2 direction)
    {
        pushableObjectRigidbody.MovePosition(pushableObjectRigidbody.position + direction.normalized * pushSpeed * Time.fixedDeltaTime);
    }

    
}
