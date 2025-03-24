using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public ItemData data;

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

        equipStateText.SetActive(equiped);
    }

    public void Clear()
    {
        data = null;
        icon.gameObject.SetActive(false);
        equipStateText.SetActive(false);
    }
    public void OnClickEquipButton()
    {
        GameManager.Instance.Player.Equip(index);
    }

    public void OnClickUnEquipButton()
    {
        GameManager.Instance.Player.UnEquip(index);
    }
    public void OnClickButton()
    {
        uiInventory.SelectItem(index);
    }
}
