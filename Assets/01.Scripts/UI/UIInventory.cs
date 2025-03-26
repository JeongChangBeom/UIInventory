using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : UIBase
{
    public ItemSlot slotPrefabs;
    public List<ItemSlot> slots;
    public Transform slotPanel;
    public int initSlotCount = 30;

    [SerializeField] private Button exitButton;

    private Character player;

    private void Start()
    {
        player = GameManager.Instance.Player;
        slots = new List<ItemSlot>();
        InitInventory();

        exitButton.onClick.AddListener(OnClickExitButton);
    }

    /// <summary>
    /// Ư�� ������ŭ slot�� ����
    /// </summary>
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

    /// <summary>
    /// ���� ���Ե��� ���¸� �ʱ�ȭ
    /// </summary>
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

    /// <summary>
    /// �κ��丮���� ������ Ŭ������ ��
    /// </summary>
    /// <param name="index"> ������ �������� �ּ� </param>
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

    /// <summary>
    /// �κ��丮���� �� ������ ã����
    /// </summary>
    /// <returns> �� ������ �����ϸ� �󽽷� ��ȯ, ������ null ��ȯ </returns>
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

    /// <summary>
    /// Resources�������� �������� �ϳ��� ������ �����͸� �����ͼ� �� ���Կ� ����
    /// </summary>
    public void AddItem()
    {
        ItemData[] allItems = Resources.LoadAll<ItemData>("Items");

        if (allItems.Length == 0)
        {
            print("Resources ������ �������� �������� �ʽ��ϴ�.");
            return;
        }

        ItemSlot emptySlot = GetEmptySlot();

        if (emptySlot != null)
        {
            int randomIndex = Random.Range(0, allItems.Length);
            ItemData randomItem = allItems[randomIndex];

            GameManager.Instance.Player.inventory.Insert(emptySlot.index,randomItem);
            slots[emptySlot.index].data = randomItem;

            UpdateSlots();
            return;
        }

        Debug.Log("�κ��丮�� ��á���ϴ�.");
    }

    /// <summary>
    /// �κ��丮���� ������ ������ �̿��� ������ ������ �ϳ��� ����
    /// </summary>
    public void DropItem()
    {
        if (player.inventory.Count > 0)
        {
            List<int> checkList = new List<int>();

            for (int i = 0; i < slots.Count; i++)
            {
                if (!slots[i].equiped && slots[i].data != null)
                {
                    checkList.Add(i);
                }
            }

            if (checkList.Count == 0)
            {
                Debug.Log("������ ������ �̿��� �������� �������� �ʽ��ϴ�.");
                return;
            }

            int randomIndex = checkList[Random.Range(0, checkList.Count)];
            ItemSlot randomSlot = slots[randomIndex];

            // �κ��丮���� randomSlot�� �����ϴ� �����۰� ������ �������� index�� ã��
            int inventoryIndex = player.inventory.IndexOf(randomSlot.data);

            // randomSlot�� �������� inventory�� �����ϴ� �� Ȯ�� �� �����ϸ� ����
            if (inventoryIndex >= 0)
            {
                player.inventory.RemoveAt(inventoryIndex);
            }

            randomSlot.data = null;
            randomSlot.selected = false;
            slots[randomIndex].data = null;
            UpdateSlots();
        }
        else
        {
            Debug.Log("�κ��丮�� �������� �������� �ʽ��ϴ�.");
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
