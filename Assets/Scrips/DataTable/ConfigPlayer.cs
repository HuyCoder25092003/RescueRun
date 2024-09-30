using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ConfigPlayerRecord
{
    [SerializeField] int id;

    public int ID => id;

    [SerializeField] string name;
    public string Name => name;

    [SerializeField] string prefab;
    public string Prefab => prefab;
}
public class ConfigPlayer : BYDataTable<ConfigPlayerRecord>
{
    public override ConfigCompare<ConfigPlayerRecord> DefindCompare()
    {
        configCompare = new ConfigCompare<ConfigPlayerRecord>("id");
        return configCompare;
    }
}

