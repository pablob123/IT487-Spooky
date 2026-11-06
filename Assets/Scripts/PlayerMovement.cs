using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    Rigidbody2D rb;
    Vector2 currentInput;
    private Vector2 lastMoveDirection = Vector2.down;

    public bool isMovementLocked = false;

    [SerializeField] private Interactor interactor;

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

                interactor.SetFacingDirection(lastMoveDirection);
            }

        }
        else
        {
            currentInput = Vector2.zero;
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
}
