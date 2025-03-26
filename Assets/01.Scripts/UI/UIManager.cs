using System.Runtime.CompilerServices;
using UnityEngine;

public enum UIState
{
    MainMenu,
    Status,
    Inventory,
}

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private UIMainMenu uiMainMenu;
    [SerializeField] private UIStatus uiStatus;
    [SerializeField] private UIInventory uiInventory;

    private void Start()
    {
        OpenMainMenu();
    }

    public void OpenMainMenu()
    {
        ChangeState(UIState.MainMenu);
    }

    public void OpenStatus()
    {
        ChangeState(UIState.Status);
    }

    public void OpenInventory()
    {
        ChangeState(UIState.Inventory);
    }

    /// <summary>
    /// 현재 UI의 상태에 따른 UI를 출력함
    /// </summary>
    /// <param name="state"> 현재 UI 상태 </param>
    public void ChangeState(UIState state)
    {
        uiMainMenu.SetActive(state);
        uiStatus.SetActive(state);
        uiInventory.SetActive(state);
    }
}
