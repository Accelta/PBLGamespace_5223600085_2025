using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverManager     : MonoBehaviour
{

public void restart(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    Time.timeScale = 1f; // Resume the game time
}
public void ReturntoMenu(){
    SceneManager.LoadScene(0);
    Time.timeScale =1f;
}
}
