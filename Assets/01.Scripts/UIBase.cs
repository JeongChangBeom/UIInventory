using UnityEngine;

public abstract class UIBase : MonoBehaviour
{
    protected UIManager uiManager;

    private void Awake()
    {
        uiManager = UIManager.Instance;
    }

    protected abstract UIState GetUIState();

    public void SetActive(UIState state)
    {
        this.gameObject.SetActive(GetUIState() == state);
    }
}
