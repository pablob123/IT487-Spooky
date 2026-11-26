using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed = 2f;

    public Transform player;
    public float detectionRange = 4f;
    public float chaseSpeed = 4f;

    public float warningRange = 8f;

    public float catchDistance = 0.6f;
    private bool playerCaught = false;

    private Transform targetPoint;
    private Rigidbody2D rb;

    public GameObject gameOverPanel;
    private PlayerMovement playerMovement;

    public AudioSource chaseMusic;
    public AudioSource gameOverMusic;

    public Shake cameraShake;

    public bool isChasing = false;

    public bool forcedChase = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        gameOverPanel.SetActive(false);

        ChooseRandomPoint();
    }

    void ChooseRandomPoint()
    {
        if (patrolPoints.Length > 0)
        {
            targetPoint = patrolPoints[
                Random.Range(0, patrolPoints.Length)
            ];
        }
    }

    void FixedUpdate()
    {
        if (playerCaught)
            return;

        if (player != null &&
            Vector2.Distance(rb.position, player.position) <= catchDistance)
        {
            playerCaught = true;

            Debug.Log("GAME OVER! PLAYER GOT TOUCHED!");

            isChasing = false;
            forcedChase = false;

            if (cameraShake != null)
            {
                cameraShake.Shaking = false;
                cameraShake.lightShaking = false;
            }

            if (chaseMusic != null)
                chaseMusic.Stop();

            if (gameOverMusic != null)
                gameOverMusic.Play();

            gameOverPanel.SetActive(true);

            playerMovement.isMovementLocked = true;

            return;
        }

        if (targetPoint == null)
            return;

        float distance = Vector2.Distance(rb.position, player.position);

        Vector2 newPosition;

        if (distance <= detectionRange || forcedChase)
        {
            isChasing = true;

            if (cameraShake != null)
            {
                cameraShake.Shaking = true;
                cameraShake.lightShaking = false;
            }

            if (chaseMusic != null && !chaseMusic.isPlaying)
                chaseMusic.Play();

            newPosition = Vector2.MoveTowards(
                rb.position,
                player.position,
                chaseSpeed * Time.fixedDeltaTime
            );
        }
        else
        {
            isChasing = false;

            if (cameraShake != null)
            {
                cameraShake.Shaking = false;
                cameraShake.lightShaking = distance <= warningRange;
            }

            if (chaseMusic != null && chaseMusic.isPlaying)
                chaseMusic.Stop();

            newPosition = Vector2.MoveTowards(
                rb.position,
                targetPoint.position,
                moveSpeed * Time.fixedDeltaTime
            );

            if (Vector2.Distance(newPosition, targetPoint.position) < 0.1f)
            {
                ChooseRandomPoint();
            }
        }

        rb.MovePosition(newPosition);
    }

    public void StartAmbush(Vector2 spawnPosition)
    {
        if (playerCaught)
            return;

        rb.position = spawnPosition;
        transform.position = spawnPosition;

        forcedChase = true;
        isChasing = true;

        if (cameraShake != null)
        {
            cameraShake.Shaking = true;
            cameraShake.lightShaking = false;
        }

        if (chaseMusic != null && !chaseMusic.isPlaying)
            chaseMusic.Play();

        Debug.Log("MONSTER AMBUSH ACTIVATED!");
    }
}