using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIAlways : MonoBehaviour
{
    private Character player;

    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI expText;
    [SerializeField] private TextMeshProUGUI goldText;

    [SerializeField] private Image expImage;

    private void Awake()
    {
        player = GameManager.Instance.Player;
    }
    private void Update()
    {
        SetDisplayUI();
        expImage.fillAmount = (float)player.CurExp / (float)player.MaxExp;
    }

    public void SetDisplayUI()
    {
        playerNameText.text = player.Name;
        levelText.text = $"{player.Level}";
        expText.text = $"{player.CurExp}/{player.MaxExp}";
        goldText.text = $"{player.Gold}";
    }
}
