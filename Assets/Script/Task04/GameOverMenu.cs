// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class GameOverMenu : MonoBehaviour
// {
//     [SerializeField] private GameOverManager gameOverManager;
//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     private void Start()
//     {
//         if (gameOverManager == null)
//         {
//             gameOverManager = FindFirstObjectByType<GameOverManager>();
//         }
//     }

//     public void restart()
//     {
//         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
//         Time.timeScale = 1f; // Resume the game time
//         gameOverManager.isGameOver = false;
//     }

//     public void ReturntoMenu()
//     {
//         SceneManager.LoadScene(0);
//         Time.timeScale = 1f;
//         gameOverManager.isGameOver = false;
//     }
// }
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void Restart()
    {
        GameOverManager.Instance?.ResetGameOver();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerController.ResetGameStartFlag();
    }

    public void ReturnToMenu()
    {
        GameOverManager.Instance?.ResetGameOver();
        SceneManager.LoadScene(1); // Ganti 0 dengan index menu utama jika berbeda
    }
}
