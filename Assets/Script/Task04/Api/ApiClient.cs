using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class ApiClient : MonoBehaviour
{
    [Header("API Base URL (tanpa slash akhir)")]
    public string baseUrl = "http://localhost:5000";

    public IEnumerator Get(string path, System.Action<long, string> done)
    {
        using var req = UnityWebRequest.Get($"{baseUrl}{path}");
        yield return req.SendWebRequest();
        done(req.responseCode, req.downloadHandler.text);
    }

    public IEnumerator PostJson(string path, string json, System.Action<long, string> done)
    {
        var body = new System.Text.UTF8Encoding().GetBytes(json);
        using var req = new UnityWebRequest($"{baseUrl}{path}", "POST");
        req.uploadHandler = new UploadHandlerRaw(body);
        req.downloadHandler = new DownloadHandlerBuffer();
        req.SetRequestHeader("Content-Type", "application/json");
        yield return req.SendWebRequest();
        done(req.responseCode, req.downloadHandler.text);
    }

    public IEnumerator PutJson(string path, string json, System.Action<long, string> done)
    {
        var body = new UTF8Encoding().GetBytes(json);
        using var req = new UnityWebRequest($"{baseUrl}{path}", "PUT");
        req.uploadHandler = new UploadHandlerRaw(body);
        req.downloadHandler = new DownloadHandlerBuffer();
        req.SetRequestHeader("Content-Type", "application/json");
        yield return req.SendWebRequest();
        done(req.responseCode, req.downloadHandler.text);
    }
}
