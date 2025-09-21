using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveDistance = 5f;
    public bool startsMovingRight = false;

    private Rigidbody2D rb;
    private Vector2 startPosition;
    private int moveDirection = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;

        if (startsMovingRight)
        {
            moveDirection = 1;
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            moveDirection = -1;
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    void FixedUpdate()
    {

        if (FindObjectOfType<PlayerController>() != null && FindObjectOfType<PlayerController>().enabled)
        {
            float targetX = startPosition.x + (moveDirection * moveDistance);

            Vector2 targetVelocity = new Vector2(moveDirection * moveSpeed, rb.linearVelocity.y);
            rb.linearVelocity = targetVelocity;

            if (moveDirection == 1 && transform.position.x >= targetX)
            {
                moveDirection = -1;
                startPosition = transform.position;
                FlipEnemy();
            }
            else if (moveDirection == -1 && transform.position.x <= targetX)
            {
                moveDirection = 1;
                startPosition = transform.position;
                FlipEnemy();
            }
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    void FlipEnemy()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.PlayerHit();
            }
        }
    }
}