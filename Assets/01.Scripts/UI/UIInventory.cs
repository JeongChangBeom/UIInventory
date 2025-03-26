using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : UIBase
{
    public ItemSlot slotPrefabs;
    public List<ItemSlot> slots;
    public Transform slotPanel;
    public int initSlotCount = 12;

    [SerializeField] private Button exitButton;

    private Character player;

    private void Start()
    {
        player = GameManager.Instance.Player;
        slots = new List<ItemSlot>();
        InitInventory();

        exitButton.onClick.AddListener(OnClickExitButton);
    }

    public void InitInventory()
    {
        for (int i = 0; i < initSlotCount; i++)
        {
            ItemSlot temp = Instantiate(slotPrefabs, slotPanel);
            temp.index = i;
            temp.uiInventory = this;

            slots.Add(temp);
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

    private ItemSlot GetEmptySlot()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].data == null)
            {
                return slots[i];
            }
        }
        return null;
    }


    public void AddItem()
    {
        ItemData[] allItems = Resources.LoadAll<ItemData>("Items");

        if (allItems.Length == 0)
        {
            print("Resources 폴더에 아이템이 존재하지 않습니다.");
            return;
        }

        ItemSlot emptySlot = GetEmptySlot();

        if (emptySlot != null)
        {
            int randomIndex = Random.Range(0, allItems.Length);
            ItemData randomItem = allItems[randomIndex];

            GameManager.Instance.Player.inventory.Add(randomItem);
            emptySlot.data = randomItem;

            slots.Insert(emptySlot.index, emptySlot);

            UpdateSlots();
            return;
        }

        Debug.Log("인벤토리가 꽉찼습니다.");
    }

    public void DropItem()
    {
        if (player.inventory.Count > 0)
        {
            int randomIndex = Random.Range(0, player.inventory.Count);
            ItemSlot randomSlot = slots[randomIndex];

            while (randomSlot.equiped == true)
            {
                if (player.inventory.Count <= 1)
                {
                    Debug.Log("장착한 아이템 이외의 아이템이 존재하지 않습니다.");
                    return;
                }

                randomIndex = Random.Range(0, player.inventory.Count);
                randomSlot = slots[randomIndex];
            }

            randomSlot.data = null;
            randomSlot.selected = false;

            player.inventory.RemoveAt(randomIndex);
            UpdateSlots();
            slots.RemoveAt(randomIndex);
        }
        else
        {
            Debug.Log("인벤토리에 아이템이 존재하지 않습니다.");
        }
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
