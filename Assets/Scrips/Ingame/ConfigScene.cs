using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigScene : BYSingletonMono<ConfigScene>
{
    public Transform targetFinished;
    public Transform spwanSun;
    public List<Transform> spwanObject;
    public List<List<Transform>> spawnPositionsPerMap = new List<List<Transform>>();
    public List<int> spawnCountsPerMap;
    private void Awake()
    {
        SetupSpawnPositions();
    }
    void SetupSpawnPositions()
    {
        int currentIndex = 0;

        for (int mapIndex = 0; mapIndex < spawnCountsPerMap.Count; mapIndex++)
        {
            int spawnCount = spawnCountsPerMap[mapIndex];
            List<Transform> positionsForMap = new List<Transform>();

            for (int i = 0; i < spawnCount; i++)
            {
                if (currentIndex < spwanObject.Count)
                {
                    positionsForMap.Add(spwanObject[currentIndex]);
                    currentIndex++;
                }
                else
                    break;
            }
            spawnPositionsPerMap.Add(positionsForMap);
        }
    }
}
