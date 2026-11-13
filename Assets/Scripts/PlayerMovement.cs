
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    Rigidbody2D rb;
    Vector2 currentInput;
    private Vector2 lastMoveDirection = Vector2.down;

    public bool isMovementLocked = false;

    [SerializeField] private Interactor interactor;

    public AudioSource footsteps;
    public AudioClip normalWalking;
    public AudioClip dirtWalking;
    public bool onDirt = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        footsteps.clip = normalWalking;
        footsteps.loop = true;
        footsteps.playOnAwake = false;

        footsteps.Play();
        footsteps.Pause();
    }

    void Update()
    {
        if (!isMovementLocked)
        {
            currentInput = GetInput();
            rb.linearVelocity = currentInput.normalized * moveSpeed;

            if (currentInput != Vector2.zero)
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

        AudioClip walkingSound = onDirt ? dirtWalking : normalWalking;
        footsteps.volume = onDirt ? .3f : .3f;

        if (footsteps.clip != walkingSound)
        {
            footsteps.Stop();
            footsteps.clip = walkingSound;

            footsteps.Play();
            footsteps.Pause();
        }

        if (currentInput != Vector2.zero)
        {
            if (!footsteps.isPlaying)
                footsteps.UnPause();
        }
        else
        {
            footsteps.Pause();
        }
    }

    void FixedUpdate()
    {
    }

    Vector2 GetInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        return new Vector2(moveX, moveY);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Dirt"))
            onDirt = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Dirt"))
            onDirt = false;
    }
}
