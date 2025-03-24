using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private Character player;
    public Character Player
    {
        get => player;
        set => player = value;
    }

    private void Awake()
    {
        player = FindObjectOfType<Character>();
        SetData("ChangTiger", 10f, 5f, 100f, 35f);
    }

    private void SetData(string name, float attackPower, float defensePower, float health, float critical)
    {
        player.Init(name, attackPower, defensePower, health, critical);
    }
}
