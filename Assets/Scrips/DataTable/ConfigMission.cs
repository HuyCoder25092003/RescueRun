using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class ConfigMissionRecord
{
    [SerializeField] int id;
    public int ID => id;
    [SerializeField] string sceneName;
    public string SceneName => sceneName;
    [SerializeField] int catDetect;
    public int CatDetect => catDetect;
}
public class ConfigMission : BYDataTable<ConfigMissionRecord>
{
    public override ConfigCompare<ConfigMissionRecord> DefindCompare()
    {
        configCompare = new ConfigCompare<ConfigMissionRecord>("id");
        return configCompare;
    }
}
