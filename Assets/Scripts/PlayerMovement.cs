using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    Rigidbody2D rb;
    Vector2 currentInput;
    private Vector2 lastMoveDirection = Vector2.down;

    public bool isMovementLocked = false;

    private PushableObject pushableObject;
    private Vector2 pushDirection;
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

            if(currentInput != Vector2.zero)
            {
                lastMoveDirection = currentInput.normalized;
            }

        }
        else
        {
            currentInput = Vector2.zero;
            rb.linearVelocity = Vector2.zero;
        }

        isPressingPushButton = Input.GetKey(KeyCode.E);

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
            pushableObject.Push(pushDirection);
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
        PushableObject foundObject = collision.gameObject.GetComponent<PushableObject>();

        if(foundObject != null)
        {
            pushableObject = foundObject;

            Vector2 direction = (Vector2)collision.transform.position - rb.position;

            if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                pushDirection = new Vector2(Mathf.Sign(direction.x), 0);
            }
            else
            {
                pushDirection = new Vector2(0, Mathf.Sign(direction.y));
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
     PushableObject exitedObject = collision.gameObject.GetComponent<PushableObject>();

        if(exitedObject != null && exitedObject == pushableObject)
        {
            pushableObject = null;
        }
    }
}
