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
        attackPowerText.text = $"{player.AttackPower}{(player.ItemAttackPower != 0 ? $" +({player.ItemAttackPower})" : "")}";
        defensePowerText.text = $"{player.DefensePower}{(player.ItemDefensePower != 0 ? $" +({player.ItemDefensePower})" : "")}";
        healthText.text = $"{player.Health}{(player.ItemHealth != 0 ? $" +({player.ItemHealth})" : "")}";
        criticalText.text = $"{player.Critical}{(player.ItemCritical != 0 ? $" +({player.ItemCritical})" : "")}";
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
