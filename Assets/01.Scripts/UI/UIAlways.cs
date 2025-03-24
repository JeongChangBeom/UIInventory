using TMPro;
using UnityEngine;

public class UIAlways : MonoBehaviour
{
    private Character player;

    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI expText;
    [SerializeField] private TextMeshProUGUI goldText;

    private void Awake()
    {
        player = GameManager.Instance.Player;
    }
    private void Start()
    { 
        SetDisplayUI();
    }

    public void SetDisplayUI()
    {
        playerNameText.text = player.Name;
        levelText.text = $"{player.Level}";
        expText.text = $"{player.CurExp}/{player.MaxExp}";
        goldText.text = $"{player.Gold}";
    }
}
