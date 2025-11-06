// using TMPro;
// using UnityEngine;

// public class ScoreManager : MonoBehaviour
// {
//     public TextMeshProUGUI scoreText; // Updated to TextMeshProUGUI for UI text
//     public int score;

//     private void Start()
//     {
//         score = 0;
//         UpdateScoreText();
//     }

//     public void AddScore(int points)
//     {
//         score += points;
//         UpdateScoreText();
//     }

//     private void UpdateScoreText()
//     {
//         scoreText.text = "Score: " + score;
//     }

// }
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score;

    [Header("State/Backend")]
    public GameStateService stateService;
    public int currentLevel = 1; // contoh sistem level sederhana

    private void Start()
    {
        if (stateService == null) stateService = FindFirstObjectByType<GameStateService>();
        score = 0;
        UpdateScoreText();

        // Load/Resume
        StartCoroutine(ResumeFlow());
    }

    private System.Collections.IEnumerator ResumeFlow()
    {
        // pastikan player ada
        yield return stateService.EnsurePlayer("Axel");
        // ambil state terakhir
        yield return stateService.LoadLastState(st =>
        {
            if (st != null)
            {
                // Resume nilai
                currentLevel = st.level;
                score = st.score;
                UpdateScoreText();

                // TODO: trigger LevelManager untuk masuk ke level = currentLevel
                // contoh: FindObjectOfType<LevelManager>()?.LoadLevel(currentLevel);
            }
            else
            {
                // belum ada state: mulai fresh
                currentLevel = 1;
                score = 0;
                UpdateScoreText();
            }
        });
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    // Panggil saat player mati / game over
    public void OnGameOver()
    {
        // submit skor ke leaderboard
        StartCoroutine(stateService.SubmitScore(score));
        // simpan state terakhir (resume point)
        StartCoroutine(stateService.SaveState(currentLevel, score));
    }

    // Contoh naik level (panggil ketika lulus ambang tertentu)
    public void OnLevelUp()
    {
        currentLevel++;
        // opsional: simpan checkpoint
        StartCoroutine(stateService.SaveState(currentLevel, score));
    }
}
