using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : UIBase
{
    public ItemSlot slotPrefabs;
    public List<ItemSlot> slots;
    public Transform slotPanel;

    [SerializeField] private Button exitButton;

    private void Start()
    {
        slots = new List<ItemSlot>();
        UpdateInventory();

        exitButton.onClick.AddListener(OnClickExitButton);
    }

    public void UpdateInventory()
    {
        for (int i = 0; i < GameManager.Instance.Player.inventory.Count; i++)
        {
            if (slots.Count <= i)
            {
                ItemSlot temp = Instantiate(slotPrefabs, slotPanel);
                temp.data = GameManager.Instance.Player.inventory[i];
                temp.index = i;
                temp.uiInventory = this;

                slots.Add(temp);
            }
        }
        UpdateSlots();
    }

    public void UpdateSlots()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].data != null)
            {
                slots[i].Set();
            }
            else
            {
                slots[i].Clear();
            }
        }
    }

    public void SelectItem(int index)
    {
        if (slots[index].data == null)
        {
            return;
        }

        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i] == slots[index])
            {
                slots[i].selected = true;
            }
            else
            {
                slots[i].selected = false;
            }
        }
    }

    public void AddItem()
    {
        ItemData[] allItems = Resources.LoadAll<ItemData>("Items");

        if (allItems.Length == 0)
        {
            print("Resources 폴더에 아이템이 존재하지 않습니다.");
            return;
        }

        int randomIndex = Random.Range(0, allItems.Length);
        ItemData randomItem = allItems[randomIndex];

        GameManager.Instance.Player.inventory.Add(randomItem);
        UpdateInventory();
    }

    public void OnClickExitButton()
    {
        uiManager.OpenMainMenu();
    }

    protected override UIState GetUIState()
    {
        return UIState.Inventory;
    }
}
