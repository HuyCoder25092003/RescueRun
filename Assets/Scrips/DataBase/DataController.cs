using System;
using System.Collections.Generic;
using UnityEngine;

public class DataController : BYSingletonMono<DataController>
{
    public DataModel dataModel;
    public void InitData(Action callback)
    {
        dataModel.InitData(callback);
    }
    public PlayerInfo GetPlayerInfo()
    {
        PlayerInfo info = dataModel.ReadData<PlayerInfo>(DataSchema.INFO);
        return info;
    }
    public int GetGem()
    { 
        return dataModel.ReadData<int>(DataSchema.GEM);
    }
    public int GetGold()
    {
       return dataModel.ReadData<int>(DataSchema.GOLD);
    }
    public void AddGold(int number)
    {
        int gold = GetGold();
        gold += number;
        if (gold < 0)
            gold = 0;
        dataModel.UpdateData(DataSchema.GOLD, gold);
    }
    public void AddGem(int number)
    {
        int gem = GetGem();
        gem += number;
        if (gem < 0)
            gem = 0;
        dataModel.UpdateData(DataSchema.GEM, gem);
    }
    public void ReduceGold(int number)
    {
        int gold = GetGold();
        if (gold > 0)
        {
            gold -= number;
            dataModel.UpdateData(DataSchema.GOLD, gold);
        }
    }
    public void ReduceGem(int number)
    {
        int gem = GetGem();
        if (gem > 0)
        {
            gem -= number;
            dataModel.UpdateData(DataSchema.GEM, gem);
        }
    }
    public void OnShopBuy(ConfigShopRecord cf)
    {
        if(cf.Shop_type==1)
        {
            AddGold(cf.Value);
        }
        else
        {
            AddGem(cf.Value);
        }
    }
    public void UpdateInfo(int gold_run, int gold_stamina, int gol_incomine, float speed)
    {
        PlayerInfo info = GetPlayerInfo();
        info.run_buy = gold_run;
        info.stanina_buy = gold_stamina;
        info.inconome_buy = gol_incomine;
        info.speed = speed;
        dataModel.UpdateData(DataSchema.INFO, info);
    }
}
