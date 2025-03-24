using UnityEngine;

public enum UIState
{
    MainMenu,
    Status,
    Inventory,
}

public class UIManager : MonoBehaviour
{
    UIBase[] UIArr;
    private UIState curState;

    private void Awake()
    {
        UIArr = GetComponentsInChildren<UIBase>(true);

        foreach(var ui in UIArr)
        {
            ui.Init(this);
        }
    }

    private void OpenMainMenu()
    {
        ChangeState(UIState.MainMenu);
    }

    private void OpenStatus()
    {
        ChangeState(UIState.Status);
    }

    private void OpenInventory()
    {
        ChangeState(UIState.Inventory);
    }

    public void ChangeState(UIState state)
    {
        curState = state;

        foreach(var ui in UIArr)
        {
            ui.SetActive(curState);
        }
    }
}
