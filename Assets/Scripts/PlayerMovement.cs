using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    Rigidbody2D rb;
    Vector2 currentInput;

    public bool isMovementLocked = false;

    private PushableObject pushableObject;
    private bool isPressingPushButton = false;

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

        if(Input.GetKey(KeyCode.E))
        {
            isPressingPushButton = true;
        }
        else
        {
            isPressingPushButton = false;
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
        if(isPressingPushButton && pushableObject != null)
        {
            pushableObject.Push(currentInput);
        }
    }
    Vector2 GetInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        return new Vector2 (moveX, moveY);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        pushableObject = collision.gameObject.GetComponent<PushableObject>();
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PushableObject>() != null)
        {
            pushableObject = null;
        }
    }
}
