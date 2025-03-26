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

    /// <summary>
    /// 초기 플레이어 상태 초기화
    /// </summary>
    /// <param name="name"> 플레이어 이름 </param>
    /// <param name="attackPower"> 플레이어 공격력 </param>
    /// <param name="defensePower"> 플레이어 방어력 </param>
    /// <param name="health"> 플레이어 체력 </param>
    /// <param name="critical"> 플레이어 치명타 </param>
    /// <param name="inventory"> 플레이어 인벤토리 </param>
    private void SetData(string name, float attackPower, float defensePower, float health, float critical,List<ItemData> inventory)
    {
        player.Init(name, attackPower, defensePower, health, critical, inventory);
    }
}
