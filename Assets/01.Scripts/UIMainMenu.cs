using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : UIBase
{
    [SerializeField] private Button statusButton;
    [SerializeField] private Button inventoryButton;

    private void Start()
    {
        statusButton.onClick.AddListener(OnClickStatusButton);
        inventoryButton.onClick.AddListener(OnClickInventoryButton);
    }

    public void OnClickStatusButton()
    {
        uiManager.OpenStatus();
    }

    public void OnClickInventoryButton()
    {
        uiManager.OpenInventory();
    }

    protected override UIState GetUIState()
    {
        return UIState.MainMenu;
    }
}
