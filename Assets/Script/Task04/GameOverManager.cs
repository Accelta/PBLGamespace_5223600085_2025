using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverManager     : MonoBehaviour
{
public Canvas gameovercanvas;
private static GameOverManager instance;
public bool isGameOver = false; // Flag to check if the game is over
    private void Start()
    {
        gameovercanvas.enabled = false;
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Make this object persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void restart(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    Time.timeScale = 1f; // Resume the game time
}
public void ReturntoMenu(){
    SceneManager.LoadScene(0);
    Time.timeScale =1f;
}
    private void Update()
    {
        if (isGameOver)
        {
            gameovercanvas.enabled = true; // Show the game over canvas
             Time.timeScale = 0;
        }
    }
}
