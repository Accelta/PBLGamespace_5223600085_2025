using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        // Load the game scene (assuming it's the first scene in the build settings)
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    public void quit(){
        Application.Quit();
        Debug.Log("Quit Game"); // Log to the console for debugging
    }
}
