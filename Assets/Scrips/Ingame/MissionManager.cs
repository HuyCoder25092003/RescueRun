using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : BYSingletonMono<MissionManager>
{
    public ConfigMissionRecord cf_mission;
    [SerializeField] int number_cat_follow;
    [SerializeField] int spwanTitle;
    [SerializeField] List<GameObject> titlePrefabs;
    float zSpawn = 0;
    [SerializeField] float tileLength = 30;
    IEnumerator Start()
    {
        cf_mission = GameManager.instance.cur_cf_mission;
        yield return new WaitForSeconds(4);
        StartCoroutine("CreateTitle");
        StartCoroutine("CreatePlayer");
        StartCoroutine("SpwanSun");
    }
    IEnumerator CreateTitle()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < spwanTitle; i++)
        {
            BYPool p = new BYPool(titlePrefabs[i].name, 1, titlePrefabs[i].transform);
            BYPoolManager.instance.AddPool(p);
            SpawnTile(i);
        }
    }
    void SpawnTile(int index)
    {
        Transform title = BYPoolManager.instance.GetPool(titlePrefabs[index].name).Spawn();
        title.position = Vector3.forward * zSpawn;
        title.rotation = Quaternion.identity;
        zSpawn += tileLength;
    }
    IEnumerator CreatePlayer()
    {
        yield return new WaitForSeconds(0.5f);
        ConfigPlayerRecord cf_player = ConfigManager.instance.configPlayer.GetRecordBykeySearch(1);
        GameObject go_player = Instantiate(Resources.Load("Player/Logic", typeof(GameObject))) as GameObject;
    }
    IEnumerator SpwanSun()
    {
        yield return new WaitForSeconds(1f);
        Transform sun = BYPoolManager.instance.GetPool("sun").Spawn();
        sun.position = ConfigScene.instance.spwanSun.position;
        sun.rotation = Quaternion.identity;
    }
    public void DetectCat() 
    {
        number_cat_follow++;
        if(number_cat_follow == cf_mission.CatDetect)
        {
            WinDialogParam param = new WinDialogParam();
            param.cf_mission = cf_mission;
            DialogManager.instance.ShowDialog(DialogIndex.WinDialog, param);
        }
    }
}
