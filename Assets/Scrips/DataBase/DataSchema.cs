using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSchema 
{
    public const string INFO = "info";
    public const string INVENTORY = "inventory";
    public const string GOLD = "inventory/gold";
    public const string GEM = "inventory/gem";
}
[Serializable]
public class PlayerData
{
    [SerializeField]
    public PlayerInfo info;
    [SerializeField]
    public PlayerInventory inventory;
}
[Serializable]
public class PlayerInfo
{
    public string nickname;
    public int level;
    public int exp;
    public float speed;
    public int run_buy, stanina_buy, inconome_buy;
}
[Serializable]
public class PlayerInventory
{
    public int gold;
    public int gem;
}