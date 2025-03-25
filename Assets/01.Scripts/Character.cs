using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string Name { get; private set; }
    public int Level { get; private set; } = 1;
    public int CurExp { get; private set; } = 0;
    public int MaxExp { get; private set; } = 0;
    public int Gold { get; private set; } = 0;
    public float AttackPower { get; private set; }
    public float ItemAttackPower { get; private set; } = 0;
    public float DefensePower { get; private set; }
    public float ItemDefensePower { get; private set; } = 0;
    public float Health { get; private set; }
    public float ItemHealth { get; private set; } = 0;
    public float Critical { get; private set; }
    public float ItemCritical { get; private set; } = 0;

    public List<ItemData> inventory;

    public ItemSlot curEquipItemSlot;
    public ItemData curEquipItem;

    public void Init(string name, float attackPower, float defensePower, float health, float critical, List<ItemData> inventory)
    {
        Name = name;
        AttackPower = attackPower;
        DefensePower = defensePower;
        Health = health;
        Critical = critical;

        this.inventory = inventory;
    }

    private void Awake()
    {
        GameManager.Instance.Player = this;
    }

    public void SetName(string name)
    {
        Name = name;
    }
    
    public void LevelUp()
    {
        Level++;
        UpAttackPower(2);
        UpDefensePower(1);
        UpHealth(10);
        UpCritical(1);
    }

    public void GainExp(int exp)
    {
        int tempExp = CurExp + exp;

        while(tempExp >= MaxExp)
        {
            LevelUp();
            tempExp -= MaxExp;
        }

        CurExp = tempExp;
    }

    public void GainGold(int gold)
    {
        Gold += gold;
    }

    public void UpAttackPower(int attackPower)
    {
        AttackPower += attackPower;
    }

    public void UpDefensePower(int defencePower)
    {
        DefensePower += defencePower;
    }

    public void UpHealth(int health)
    {
        Health += health;
    }

    public void UpCritical(int critical)
    {
        Critical += critical;
    }

    public void Equip(ItemSlot slot)
    {
        curEquipItemSlot = slot;
        curEquipItem = inventory[slot.index];

        for (int i = 0; i < curEquipItem.values.Length; i++)
        {
            EffType effType = curEquipItem.values[i].valueType;

            switch (effType)
            {
                case EffType.Attack:
                    AttackPower += curEquipItem.values[i].value;
                    ItemAttackPower += curEquipItem.values[i].value;
                    break;
                case EffType.Defense:
                    DefensePower += curEquipItem.values[i].value;
                    ItemDefensePower += curEquipItem.values[i].value;
                    break;
                case EffType.Health:
                    Health += curEquipItem.values[i].value;
                    ItemHealth += curEquipItem.values[i].value;
                    break;
                case EffType.Critical:
                    Critical += curEquipItem.values[i].value;
                    ItemCritical += curEquipItem.values[i].value;
                    break;
            }
        }
    }

    public void UnEquip(ItemSlot slot)
    {
        curEquipItem = inventory[slot.index];

        for (int i = 0; i < curEquipItem.values.Length; i++)
        {
            EffType effType = curEquipItem.values[i].valueType;

            switch (effType)
            {
                case EffType.Attack:
                    AttackPower -= curEquipItem.values[i].value;
                    ItemAttackPower -= curEquipItem.values[i].value;
                    break;
                case EffType.Defense:
                    DefensePower -= curEquipItem.values[i].value;
                    ItemDefensePower -= curEquipItem.values[i].value;
                    break;
                case EffType.Health:
                    Health -= curEquipItem.values[i].value;
                    ItemHealth -= curEquipItem.values[i].value;
                    break;
                case EffType.Critical:
                    Critical -= curEquipItem.values[i].value;
                    ItemCritical -= curEquipItem.values[i].value;
                    break;
            }
        }

        curEquipItemSlot = null;
        curEquipItem = null;
    }
}
