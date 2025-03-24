using System.Runtime.CompilerServices;
using UnityEngine;

public enum UIState
{
    MainMenu,
    Status,
    Inventory,
}

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
                if(instance == null)
                {
                    GameObject obj = new GameObject { name = typeof(UIManager).Name };
                    instance = obj.AddComponent<UIManager>();
                }
            }
            return instance;
        }
    }

    [SerializeField] private UIMainMenu uiMainMenu;
    [SerializeField] private UIStatus uiStatus;
    [SerializeField] private UIInventory uiInventory;

    private UIState curState;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this as UIManager;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

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

    public void ChangeState(UIState state)
    {
        curState = state;

        uiMainMenu.SetActive(state);
        uiStatus.SetActive(state);
        uiInventory.SetActive(state);
    }
}
