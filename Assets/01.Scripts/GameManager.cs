using System;
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
        SetData("ChangTiger", 10f, 5f, 100f, 35f,new List<ItemData>());
    }


    private void SetData(string name, float attackPower, float defensePower, float health, float critical,List<ItemData> inventory)
    {
        player.Init(name, attackPower, defensePower, health, critical, inventory);
    }
}
