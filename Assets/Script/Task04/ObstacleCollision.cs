using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    [SerializeField] private GameObject obstacle; // Assign in the Unity Inspector
    [SerializeField] private Canvas gameovercanvas; // Speed at which the obstacle moves
    void Start()
    {
        if (obstacle == null)
        {
            Debug.LogError("Obstacle is not assigned in the Inspector!");
            return;
        }
        obstacle.GetComponent<Rigidbody2D>();
        gameovercanvas.enabled = false; // Disable the game over canvas at the start
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the collider belongs to the player
        {
            Debug.Log("Game Over!"); // Log a message for debugging
            // Add your game over logic here, e.g., load a Game Over screen or stop the game
            Time.timeScale = 0; // Example: Pause the game
            gameovercanvas.enabled = true; // Show the game over canvas
        }
    }
}
