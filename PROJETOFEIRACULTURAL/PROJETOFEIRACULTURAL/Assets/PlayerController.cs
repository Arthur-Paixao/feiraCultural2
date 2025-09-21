using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private bool isGrounded;

    public Transform groundCheck;
    public float checkRadius = 0.2f;
    public LayerMask groundLayer;

    public TextMeshProUGUI scoreText;
    private float score = 0f;
    public float scoreMultiplier = 1f;

    public GameObject gameOverPanel;
    public GameOverManager gameOverManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score = 0f;
        UpdateScoreDisplay();

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    void Update()
    {
        rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        score += Time.deltaTime * speed * scoreMultiplier;
        UpdateScoreDisplay();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
    }

    void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = "Pontuação: " + Mathf.FloorToInt(score).ToString();
        }
    }

    public void PlayerHit()
    {
        rb.linearVelocity = Vector2.zero;
        speed = 0;

        this.enabled = false;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);

            if (gameOverManager != null)
            {
                gameOverManager.DisplayScore(score);
            }
        }
    }
}
