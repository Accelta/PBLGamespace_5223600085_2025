using TMPro;
using UnityEngine;

public class PlayerHUDController : MonoBehaviour
{
    [Header("UI Refs")]
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI playerLevelText;

    public void SetName(string name)
    {
        if (playerNameText != null)
            playerNameText.text = $"Name: {name}";
    }

    public void SetLevel(int level)
    {
        if (playerLevelText != null)
            playerLevelText.text = $"Level: {level}";
    }
}
