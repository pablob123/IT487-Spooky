using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float moveSpeed = 2f;

    public Transform player;
    public float detectionRange = 4f;
    public float chaseSpeed = 4f;

    public float catchDistance = 0.6f;
    private bool playerCaught = false;

    private Transform targetPoint;
    private Rigidbody2D rb;

    public GameObject gameOverPanel;
    public MonoBehaviour playerMovement;

    void Start()
    {
        targetPoint = pointA;
        rb = GetComponent<Rigidbody2D>();
        gameOverPanel.SetActive(false);
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

            gameOverPanel.SetActive(true);
            playerMovement.enabled = false;

            return;
        }

        if (targetPoint == null)
            return;

        float distance = Vector2.Distance(rb.position, player.position);

        Vector2 newPosition;

        if (distance <= detectionRange)
        {
            newPosition = Vector2.MoveTowards(
                rb.position,
                player.position,
                chaseSpeed * Time.fixedDeltaTime
            );
        }
        else
        {
            newPosition = Vector2.MoveTowards(
                rb.position,
                targetPoint.position,
                moveSpeed * Time.fixedDeltaTime
            );

            if (Vector2.Distance(newPosition, targetPoint.position) < 0.1f)
            {
                if (targetPoint == pointA)
                    targetPoint = pointB;
                else
                    targetPoint = pointA;
            }
        }
        rb.MovePosition(newPosition);
    }
}
