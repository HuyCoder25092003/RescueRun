using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigManager : BYSingletonMono<ConfigManager>
{
    public ConfigMission configMission;
    public ConfigShop configShop;
    public ConfigPlayer configPlayer;
    public void InitConfig(Action callback)
    {
        StartCoroutine(ProgressLoadConfig(callback));
    }
    IEnumerator ProgressLoadConfig(Action callback)
    {
        configShop = Resources.Load("Config/ConfigShop", typeof(ScriptableObject)) as ConfigShop;
        yield return new WaitUntil(() => configShop != null);

        configMission = Resources.Load("Config/ConfigMission", typeof(ScriptableObject)) as ConfigMission;
        yield return new WaitUntil(() => configMission != null);

        configPlayer = Resources.Load("Config/ConfigPlayer", typeof(ScriptableObject)) as ConfigPlayer;
        yield return new WaitUntil(() => configPlayer != null);

        callback?.Invoke();
    }
}
