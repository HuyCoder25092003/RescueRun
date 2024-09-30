using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : BYSingletonMono<DataManager>
{
    public PlayerData InitNewData()
    {
        PlayerData playerData = new PlayerData();
        PlayerInfo info = new PlayerInfo();
        info.nickname = "Huy";
        info.level = 1;
        info.exp = 0;
        info.speed = 1f;
        info.run_buy = info.stanina_buy = info.inconome_buy = 10;       
        playerData.info = info;

        PlayerInventory inventory = new PlayerInventory();
        inventory.gold = 100;
        inventory.gem = 100;
        playerData.inventory = inventory;
        return playerData;
    }
}
