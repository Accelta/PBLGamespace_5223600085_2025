using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float flapForce = 5f;
    public float maxYPosition = 4.5f;
    public float minYPosition = -4.5f;
    public int scoreadded;

    private Rigidbody2D rb;
    private Animator animator;
    private bool hasStarted = false;
    public static bool HasGameStarted { get; set; } = false;
    [SerializeField] private AudioManager audioManager; // Reference to the AudioManager
    [SerializeField] private ScoreManager scoreManager; // Reference to the ScoreManager
    [SerializeField] private GameOverManager gameOverManager;
    [SerializeField] private MenuManager menuManager;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rb.gravityScale = 0;
        scoreManager = FindFirstObjectByType<ScoreManager>(); // Find the ScoreManager in the scene
        audioManager = FindFirstObjectByType<AudioManager>();
        gameOverManager = FindFirstObjectByType<GameOverManager>();
        menuManager = FindFirstObjectByType<MenuManager>();

    }
    public void OnFlap(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (!hasStarted)
            {
                rb.gravityScale = 3;
                hasStarted = true;
                HasGameStarted = true;
            }

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, flapForce);
            animator.SetTrigger("Flap");
            audioManager.PlayFlapSound(); // Play the flap sound effect
            menuManager.disablecanvas(menuManager.GetComponent<Canvas>());
        }
    }

    void Update()
    {
        if (rb.linearVelocity.y < 0)
        {
            animator.SetBool("Falling", true);
        }
        else
        {
            animator.SetBool("Falling", false);
        }

        // Batasi posisi Y agar tidak keluar dari batas atas

        if (transform.position.y > maxYPosition)
        {
            transform.position = new Vector3(transform.position.x, maxYPosition, transform.position.y);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        }
        else if (transform.position.y < minYPosition)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ScoreTag"))
        {
            audioManager.PlayScoreSound();
            scoreManager.AddScore(scoreadded); // Add score to the ScoreManager
        }
        else if (other.CompareTag("TopPipe") || other.CompareTag("BottomPipe"))
        {
            // Play the crash sound effect and set the game over flag to true
            audioManager.PlayCrashSound(); // Play the crash sound effect
            gameOverManager.TriggerGameOver();
        }
        // else if (other.CompareTag("Ground") || other.CompareTag("Ceiling"))
        // {
        //     audioManager.PlayCrashSound();
        //     gameOverManager.isGameOver = true; // Set the game over flag to true
        //     // gameOverManager.
        // }
    }
    public static void ResetGameStartFlag()
{
    HasGameStarted = false;
}
}
