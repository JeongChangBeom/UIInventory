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
        AddItem();
        AddItem();
        AddItem();
        AddItem();
        AddItem();
        AddItem();
        AddItem();
        AddItem();
        AddItem();
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

    public void AddItem()
    {
        ItemData[] allItems = Resources.LoadAll<ItemData>("Items");

        if (allItems.Length == 0)
        {
            return;
        }

        int randomIndex = Random.Range(0, allItems.Length);
        ItemData randomItem = allItems[randomIndex];

        inventory.Add(randomItem);
    }

    public void Equip(int index)
    {
        for (int i = 0; i < inventory[index].values.Length; i++)
        {
            EffType effType = inventory[index].values[i].valueType;

            switch (effType)
            {
                case EffType.Attack:
                    AttackPower += inventory[index].values[i].value;
                    ItemAttackPower += inventory[index].values[i].value;
                    break;
                case EffType.Defense:
                    DefensePower += inventory[index].values[i].value;
                    ItemDefensePower += inventory[index].values[i].value;
                    break;
                case EffType.Health:
                    Health += inventory[index].values[i].value;
                    ItemHealth += inventory[index].values[i].value;
                    break;
                case EffType.Critical:
                    Critical += inventory[index].values[i].value;
                    ItemCritical += inventory[index].values[i].value;
                    break;
            }
        }
    }

    public void UnEquip(int index)
    {
        for (int i = 0; i < inventory[index].values.Length; i++)
        {
            EffType effType = inventory[index].values[i].valueType;

            switch (effType)
            {
                case EffType.Attack:
                    AttackPower -= inventory[index].values[i].value;
                    ItemAttackPower -= inventory[index].values[i].value;
                    break;
                case EffType.Defense:
                    DefensePower -= inventory[index].values[i].value;
                    ItemDefensePower -= inventory[index].values[i].value;
                    break;
                case EffType.Health:
                    Health -= inventory[index].values[i].value;
                    ItemHealth -= inventory[index].values[i].value;
                    break;
                case EffType.Critical:
                    Critical -= inventory[index].values[i].value;
                    ItemCritical -= inventory[index].values[i].value;
                    break;
            }
        }
    }
}
