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
    /// 특정 개수만큼 slot을 생성
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
    /// 현재 슬롯들의 상태를 초기화
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
    /// 인벤토리에서 슬롯을 클릭했을 때
    /// </summary>
    /// <param name="index"> 선택한 아이템의 주소 </param>
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
    /// 인벤토리에서 빈 슬롯을 찾아줌
    /// </summary>
    /// <returns> 빈 슬롯이 존재하면 빈슬롯 반환, 없으면 null 반환 </returns>
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
    /// Resources폴더에서 랜덤으로 하나의 아이템 데이터를 가져와서 빈 슬롯에 넣음
    /// </summary>
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

            GameManager.Instance.Player.inventory.Insert(emptySlot.index,randomItem);
            slots[emptySlot.index].data = randomItem;

            UpdateSlots();
            return;
        }

        Debug.Log("인벤토리가 꽉찼습니다.");
    }

    /// <summary>
    /// 인벤토리에서 장착한 아이템 이외의 랜덤한 아이템 하나를 버림
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
                Debug.Log("장착한 아이템 이외의 아이템이 존재하지 않습니다.");
                return;
            }

            int randomIndex = checkList[Random.Range(0, checkList.Count)];
            ItemSlot randomSlot = slots[randomIndex];

            // 인벤토리에서 randomSlot에 존재하는 아이템과 동일한 아이템의 index를 찾음
            int inventoryIndex = player.inventory.IndexOf(randomSlot.data);

            // randomSlot의 아이템이 inventory에 존재하는 지 확인 후 존재하면 제거
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
