using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : UIBase
{
    public ItemSlot slotPrefabs;
    public List<ItemSlot> slots;
    public Transform slotPanel;

    private ItemData selectedItem;
    private int selectedIndex;

    [SerializeField] private Button exitButton;

    private void Start()
    {
        slots = new List<ItemSlot>();

        for (int i = 0; i < GameManager.Instance.Player.inventory.Count; i++)
        {
            ItemSlot temp = Instantiate(slotPrefabs, slotPanel);
            temp.data = GameManager.Instance.Player.inventory[i];
            temp.index = i;
            temp.uiInventory = this;

            slots.Add(temp);
        }

        UpdateSlots();

        exitButton.onClick.AddListener(OnClickExitButton);
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

        selectedItem = slots[index].data;
        selectedIndex = index;
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
