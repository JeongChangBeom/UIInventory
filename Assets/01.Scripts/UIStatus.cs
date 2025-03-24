using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStatus : UIBase
{
    private Character player;

    [SerializeField] private TextMeshProUGUI attackPowerText;
    [SerializeField] private TextMeshProUGUI defensePowerText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI criticalText;
    [SerializeField] private Button exitButton;

    protected override void Awake()
    {
        base.Awake();
        player = GameManager.Instance.Player;
    }

    private void Start()
    {
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    public void SetDisplayUI()
    {
        attackPowerText.text = $"{player.AttackPower}";
        defensePowerText.text = $"{player.DefensePower}";
        healthText.text = $"{player.Health}";
        criticalText.text = $"{player.Critical}";
    }

    public void OnClickExitButton()
    {
        uiManager.OpenMainMenu();
    }
    protected override UIState GetUIState()
    {
        return UIState.Status;
    }
}
