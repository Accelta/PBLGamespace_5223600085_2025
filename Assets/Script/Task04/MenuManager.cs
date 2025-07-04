using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    public void quit()
    {
        Application.Quit();
        Debug.Log("Quit Game"); // Log to the console for debugging
    }
    
    public void disablecanvas(Canvas canvas)
    {
        this.gameObject.SetActive(false);
    }
}
