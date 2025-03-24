using UnityEngine;

public class Character : MonoBehaviour
{
    private float attackPower;
    public float AttackPower
    {
        get => attackPower;
        private set => attackPower = value;
    }

    private float defensePower;
    public float DefensePower
    {
        get => defensePower;
        private set => defensePower = value;
    }

    private float health;
    public float Health
    {
        get => health;
        private set => health = value;
    }

    private float critical;
    public float Critical
    {
        get => critical;
        private set => critical = value;
    }
}
