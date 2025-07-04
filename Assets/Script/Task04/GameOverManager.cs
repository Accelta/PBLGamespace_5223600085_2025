// using UnityEngine;
// using UnityEngine.SceneManagement;
// public class GameOverManager : MonoBehaviour
// {
//     public Canvas gameovercanvas;
//     private static GameOverManager instance;
//     public bool isGameOver = false; // Flag to check if the game is over

//     private void Start()
//     {
//         // If not assigned, find by name
//         if (gameovercanvas == null)
//             gameovercanvas = GameObject.Find("GameOverCanvas")?.GetComponent<Canvas>();
//         if (gameovercanvas != null && isGameOver == false)
//             gameovercanvas.enabled = false;
//     }

//     private void Awake()
//     {
//         // if (instance == null)
//         // {
//         //     instance = this;
//         //     DontDestroyOnLoad(gameObject); // Make this object persist across scenes
//         // }
//         // else
//         // {
//         //     Destroy(gameObject);
//         // }
//     }

//     private void Update()
//     {
//         if (isGameOver)
//         {
//             // If not assigned, find by name
//             if (gameovercanvas == null)
//                 gameovercanvas = GameObject.Find("GameOverCanvas")?.GetComponent<Canvas>();
//             if (gameovercanvas != null)
//                 gameovercanvas.enabled = true; // Show the game over canvas
//             Time.timeScale = 0;
//         }
//     }
// }
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private Canvas gameOverCanvas;
    private CanvasGroup canvasGroup;
    public static GameOverManager Instance { get; private set; }

    private bool isGameOver = false;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else { Destroy(gameObject); return; }
    }

    private void Start()
    {
        if (gameOverCanvas == null)
            gameOverCanvas = GameObject.Find("GameOverCanvas")?.GetComponent<Canvas>();

        canvasGroup = gameOverCanvas.GetComponent<CanvasGroup>();

        if (gameOverCanvas != null)
        {
            gameOverCanvas.enabled = false;
            if (canvasGroup != null)
            {
                canvasGroup.alpha = 0f;
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
            }
        }

        Time.timeScale = 1f;
    }

    public void TriggerGameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        if (gameOverCanvas != null)
        {
            gameOverCanvas.enabled = true;
            if (canvasGroup != null)
                StartCoroutine(FadeInCanvas());
        }

        Time.timeScale = 0f;
    }

    private IEnumerator FadeInCanvas()
    {
        float duration = 1f;
        float elapsed = 0f;

        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

        while (elapsed < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, elapsed / duration);
            elapsed += Time.unscaledDeltaTime; // use unscaled because timeScale = 0
            yield return null;
        }

        canvasGroup.alpha = 1f;
    }

    public void ResetGameOver()
    {
        isGameOver = false;

        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }

        if (gameOverCanvas != null)
            gameOverCanvas.enabled = false;

        Time.timeScale = 1f;
    }
}

