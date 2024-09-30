using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HomeView : BaseView
{
    [SerializeField] TMP_Text value_gold, value_gem;
    [SerializeField] TMP_Text run_buy, stamina_buy, incomine_buy;
    int gold_run_buy, gold_stamina_buy, gold_incomine_buy;
    [SerializeField] float speed;
    public override void Setup(ViewParam param)
    {
        base.Setup(param);
        speed = DataController.instance.GetPlayerInfo().speed;
        value_gold.text = DataController.instance.GetGold().ToString();
        value_gem.text = DataController.instance.GetGem().ToString();
        gold_run_buy = DataController.instance.GetPlayerInfo().run_buy;
        gold_stamina_buy = DataController.instance.GetPlayerInfo().stanina_buy;
        gold_incomine_buy = DataController.instance.GetPlayerInfo().inconome_buy;
        run_buy.text = gold_run_buy.ToString() + " gold";
        stamina_buy.text = gold_stamina_buy.ToString() + " gold";
        incomine_buy.text = gold_incomine_buy.ToString() + " gold";
    }
    private void OnEnable()
    {
        DataTrigger.RegisterValueChange(DataSchema.GOLD, OnChangeGold);
        DataTrigger.RegisterValueChange(DataSchema.GEM, OnChangeGem);
    }
    private void OnDisable()
    {
        DataTrigger.UnRegisterValueChange(DataSchema.GOLD, OnChangeGold);
        DataTrigger.RegisterValueChange(DataSchema.GEM, OnChangeGem);
    }
    void OnChangeGem(object data)
    {
        UpdateGem();
    }
    void OnChangeGold(object data)
    {
        UpdateGold();
    }
    void UpdateGold()
    {
        value_gold.text = DataController.instance.GetGold().ToString();
    }
    void UpdateGem()
    {
        value_gem.text = DataController.instance.GetGem().ToString();
    }
    public void PLayGames(int id)
    {
        ConfigMissionRecord cf_mission = ConfigManager.instance.configMission.GetRecordBykeySearch(id);
        GameManager.instance.cur_cf_mission = cf_mission;
        ViewManager.instance.SwitchView(ViewIndex.EmptyView);
        LoadSceneManager.instance.LoadSceneByName(cf_mission.SceneName, () =>
        {
            ViewManager.instance.SwitchView(ViewIndex.IngameView);
        });
    }
    public void OnSettings()
    {
        DialogManager.instance.ShowDialog(DialogIndex.SettingsDialog);
    }
    public void Upgrade(int id)
    {
        if (id == 0)
        {
            if (DataController.instance.GetGold() >= gold_run_buy)
            {
                DataController.instance.ReduceGold(gold_run_buy);
                gold_run_buy += 10;
                run_buy.text = gold_run_buy.ToString() + " gold";
                speed += 0.01f;
            }
        }
        else if (id == 1)
        {
            if (DataController.instance.GetGold() >= gold_stamina_buy)
            {
                DataController.instance.ReduceGold(gold_stamina_buy);
                gold_stamina_buy += 10;
                stamina_buy.text = gold_stamina_buy.ToString() + " gold";
            }
        }
        else if (id == 2)
        {
            if (DataController.instance.GetGold() >= gold_incomine_buy)
            {
                DataController.instance.ReduceGold(gold_stamina_buy);
                gold_incomine_buy += 10;
                incomine_buy.text = gold_incomine_buy.ToString() + " gold";
            }
        }
        value_gold.text = DataController.instance.GetGold().ToString();
        DataController.instance.UpdateInfo(gold_run_buy, gold_stamina_buy, gold_incomine_buy, speed);
    }
}
