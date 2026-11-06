using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float pushPower = 2f;

    Rigidbody2D rb;
    Vector2 currentInput;

    public bool isMovementLocked = false;

    public string pushableObject;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(!isMovementLocked)
        {
           currentInput = GetInput();
           rb.linearVelocity = currentInput.normalized * moveSpeed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
        /*
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        movement = new Vector2(moveX, moveY).normalized;
        */
    }

    void FixedUpdate()
    {
        /*
        rb.MovePosition(
            rb.position + movement * moveSpeed * Time.fixedDeltaTime
        );
        */
    }
    Vector2 GetInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        return new Vector2 (moveX, moveY);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(isMovementLocked)
            return;

        if(collision.gameObject.CompareTag(pushableObject))
        {
            Rigidbody2D objectRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();

            if(objectRigidbody != null && currentInput != Vector2.zero)
            {
                Vector2 pushDirection = currentInput.normalized;
                objectRigidbody.linearVelocity = pushDirection;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(pushableObject))
        {
            Rigidbody2D objectRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();

            if(objectRigidbody != null)
            {
                objectRigidbody.linearVelocity = Vector2.zero;
            }
        }
    }
}
