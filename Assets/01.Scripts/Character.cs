using Unity.VisualScripting;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string Name { get; private set; }
    public int Level { get; private set; } = 1;
    public int CurExp { get; private set; } = 0;
    public int MaxExp { get; private set; } = 0;
    public int Gold { get; private set; } = 0;
    public float AttackPower { get; private set; }
    public float DefensePower { get; private set; }
    public float Health { get; private set; }
    public float Critical { get; private set; }

    public void Init(string name, float attackPower, float defensePower, float health, float critical)
    {
        Name = name;
        AttackPower = attackPower;
        DefensePower = defensePower;
        Health = health;
        Critical = critical;
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
}
