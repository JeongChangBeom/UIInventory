using System;
using UnityEngine;

public enum EffType
{
    Attack,
    Defense,
    Health,
    Critical,
}

[Serializable]
public class ItemValue
{
    public EffType valueType;
    public float value;
}

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObject/New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public Sprite icon;
    public string itemName;
    public string itemDescription;
    public ItemValue[] values;
}
