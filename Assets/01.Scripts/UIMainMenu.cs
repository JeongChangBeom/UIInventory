using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : UIBase
{
    [SerializeField] private Button statusButton;
    [SerializeField] private Button inventoryButton;

    private void Start()
    {
        statusButton.onClick.AddListener(OnClickStatusButton);
        statusButton.onClick.AddListener(OnClickInventoryButton);
    }

    public void OnClickStatusButton()
    {
        statusButton.gameObject.SetActive(false);
        inventoryButton.gameObject.SetActive(false);
    }

    public void OnClickInventoryButton()
    {
        statusButton.gameObject.SetActive(false);
        inventoryButton.gameObject.SetActive(false);
    }

    protected override UIState GetUIState()
    {
        return UIState.MainMenu;
    }
}
