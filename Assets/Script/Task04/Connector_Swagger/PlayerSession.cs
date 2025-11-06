using System.Collections;
using UnityEngine;

public class PlayerSession : MonoBehaviour
{
    [Header("Services")]
    public ApiClient api;
    public GameStateService stateService;

    [Header("HUD")]
    public PlayerHUDController hud;

    [Header("Defaults")]
    public string defaultName = "Player";
    public int currentLevel = 1;

    public string PlayerName { get; private set; }
    public int PlayerId => stateService != null ? stateService.playerId : 0;

    const string KeyPlayerName = "FLAPPY_PLAYER_NAME";

    private void Awake()
    {
        if (api == null) api = FindFirstObjectByType<ApiClient>();
        if (stateService == null) stateService = FindFirstObjectByType<GameStateService>();

        // load nama lokal (biar tidak selalu bikin player baru)
        PlayerName = PlayerPrefs.GetString(KeyPlayerName, defaultName);
    }

    private void Start()
    {
        StartCoroutine(Bootstrap());
    }

    private IEnumerator Bootstrap()
    {
        // 1) Pastikan player terdaftar dengan nama lokal
        yield return stateService.EnsurePlayer(PlayerName);

        // 2) Load state terakhir (level+score) dari API
        yield return stateService.LoadLastState(st =>
        {
            if (st != null)
            {
                currentLevel = st.level;
                // score akan diisi oleh ScoreManager saat resume (opsional)
            }
            else
            {
                currentLevel = 1;
            }
        });

        // 3) Update HUD awal
        hud?.SetName(PlayerName);
        hud?.SetLevel(currentLevel);
    }

    /// <summary>Panggil saat pemain mengganti nama di UI (InputField).</summary>
    public void ChangePlayerName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName)) return;
        PlayerName = newName.Trim();
        PlayerPrefs.SetString(KeyPlayerName, PlayerName);
        PlayerPrefs.Save();

        // catatan: backend kita identifikasi berdasarkan playerId.
        // Mengganti nama di sini hanya mengubah nama lokal & HUD.
        // Jika perlu fitur rename di backend, tambahkan endpoint PATCH di API.
        hud?.SetName(PlayerName);
    }

    /// <summary>Panggil saat naik level (mis. setelah n poin/pipe).</summary>
    public void LevelUp()
    {
        currentLevel++;
        hud?.SetLevel(currentLevel);
        // simpan checkpoint state (level & skor saat ini)
        var scoreMgr = FindFirstObjectByType<ScoreManager>();
        int curScore = scoreMgr != null ? scoreMgr.score : 0;
        StartCoroutine(stateService.SaveState(currentLevel, curScore));
    }

    /// <summary>Panggil jika ingin sinkron ulang HUD (mis. setelah resume/scene load).</summary>
    public void RefreshHUD()
    {
        hud?.SetName(PlayerName);
        hud?.SetLevel(currentLevel);
    }
}
