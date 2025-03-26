using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public ItemData data;
    private Character Player;

    [SerializeField] private Image icon;
    [SerializeField] private GameObject equipStateText;
    [SerializeField] private Button button;
    [SerializeField] private Button equipButton;
    [SerializeField] private Button unequipButton;

    private Outline outline;

    public UIInventory uiInventory;

    public int index;
    public bool selected;
    public bool equiped;

    private void Awake()
    {
        outline = GetComponent<Outline>();
        Player = GameManager.Instance.Player;
    }

    private void Start()
    {
        equipButton.onClick.AddListener(OnClickEquipButton);
        unequipButton.onClick.AddListener(OnClickUnEquipButton);
        button.onClick.AddListener(OnClickButton);
    }

    private void Update()
    {
        outline.enabled = selected;
        equipStateText.SetActive(equiped);

        if (selected)
        {
            equipButton.gameObject.SetActive(!equiped);
            unequipButton.gameObject.SetActive(equiped);
        }
        else
        {
            equipButton.gameObject.SetActive(false);
            unequipButton.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        equipStateText.SetActive(equiped);
    }

    public void Set()
    {
        icon.gameObject.SetActive(true);
        icon.sprite = data.icon;
    }

    public void Clear()
    {
        data = null;
        icon.gameObject.SetActive(false);
    }

    /// <summary>
    /// 장착 버튼을 누르면 현재 착용하고 있는 장비가 해제 되고 지금 선택한 장비가 장착됨
    /// </summary>
    public void OnClickEquipButton()
    {
        if (Player.curEquipItemSlot != null)
        {
            Player.curEquipItemSlot.equiped = false;
            Player.UnEquip(Player.curEquipItemSlot);

        }
        equiped = true;
        Player.Equip(this);
        Set();
    }

    public void OnClickUnEquipButton()
    {
        equiped = false;
        Player.UnEquip(this);
        Set();
    }
    public void OnClickButton()
    {
        uiInventory.SelectItem(index);
    }
}
