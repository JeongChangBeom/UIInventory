using UnityEngine;
using UnityEngine.UI;

public class UIStatus : UIBase
{
    [SerializeField] private Button exitButton;

    private void Start()
    {
        exitButton.onClick.AddListener(OnClickExitButton);
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
