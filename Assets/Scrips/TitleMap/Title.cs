using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    [SerializeField] int spawnPrefab;
    [SerializeField] int id;
    [SerializeField] Transform parent;
    public List<GameObject> spawnObjects;
    private void Start()
    {
        for (int i = 0; i < spawnObjects.Count; i++)
        {
            BYPool p = new BYPool(spawnObjects[i].name,10,spawnObjects[i].transform);
            BYPoolManager.instance.AddPool(p);
        }
        SpawnObject(id);
    }
    void SpawnObject(int id)
    {
        if (id < ConfigScene.instance.spawnPositionsPerMap.Count)
        {
            List<Transform> spawnPositions = ConfigScene.instance.spawnPositionsPerMap[id];

            int numberOfSpawns = spawnPrefab;

            for (int i = 0; i < numberOfSpawns; i++)
            {
                Debug.Log(spawnObjects[i].name);
                Transform spawn = BYPoolManager.instance.GetPool(spawnObjects[i].name).Spawn();
                spawn.position = spawnPositions[i].position;
                if (spawnObjects[i].name == "TrafficCone")
                    spawn.rotation = Quaternion.Euler(-89.98f, 0, 0);
                else if (spawnObjects[i].name == "Painting_1" || spawnObjects[i].name == "Painting_2"
                    || spawnObjects[i].name == "Book_1")
                    spawn.rotation = Quaternion.Euler(0,180f,0);
                spawn.transform.SetParent(parent, false);
            }
        }
    }
}
