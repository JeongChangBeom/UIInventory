using UnityEngine;

public abstract class UIBase : MonoBehaviour
{
    protected UIManager uiManager;

    protected virtual void Awake()
    {
        uiManager = UIManager.Instance;
    }

    protected abstract UIState GetUIState();

    public void SetActive(UIState state)
    {
        this.gameObject.SetActive(GetUIState() == state);
    }
}
