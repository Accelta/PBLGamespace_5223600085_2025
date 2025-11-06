using System.Collections;
using UnityEngine;

public class GameStateService : MonoBehaviour
{
    public ApiClient api;
    public int playerId; // simpan hasil register (atau load dari PlayerPrefs)

    const string KeyPlayerId = "FLAPPY_PLAYER_ID";

    private void Awake()
    {
        if (api == null) api = FindFirstObjectByType<ApiClient>();
        playerId = PlayerPrefs.GetInt(KeyPlayerId, 0);
    }

    public IEnumerator EnsurePlayer(string playerName = "Player")
    {
        if (playerId != 0) yield break;

        var dto = new CreatePlayerDto { name = playerName };
        string json = JsonUtility.ToJson(dto);
        yield return api.PostJson("/api/players", json, (code, text) =>
        {
            if (code >= 200 && code < 300)
            {
                var p = JsonUtility.FromJson<PlayerDto>(text);
                playerId = p.id;
                PlayerPrefs.SetInt(KeyPlayerId, playerId);
                PlayerPrefs.Save();
            }
            else
            {
                Debug.LogError($"Register failed: {code} {text}");
            }
        });
    }

    public IEnumerator LoadLastState(System.Action<StateDto?> onLoaded)
    {
        yield return api.Get($"/api/states/{playerId}", (code, text) =>
        {
            if (code == 200)
            {
                var st = JsonUtility.FromJson<StateDto>(text);
                onLoaded?.Invoke(st);
            }
            else
            {
                onLoaded?.Invoke(null); // belum ada state
            }
        });
    }

    public IEnumerator SaveState(int level, int score)
    {
        var dto = new UpsertStateDto { level = level, score = score };
        string json = JsonUtility.ToJson(dto);
        yield return api.PutJson($"/api/states/{playerId}", json, (code, text) =>
        {
            if (code < 200 || code >= 300)
                Debug.LogError($"Save state failed: {code} {text}");
        });
    }

    public IEnumerator SubmitScore(int score)
    {
        var dto = new SubmitScoreDto { playerId = playerId, score = score };
        string json = JsonUtility.ToJson(dto);
        yield return api.PostJson($"/api/scores", json, (code, text) =>
        {
            if (code < 200 || code >= 300)
                Debug.LogError($"Submit score failed: {code} {text}");
        });
    }
}
