using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TitleMapManager : MonoBehaviour
{
    [SerializeField] List<GameObject> activeTiles;
    public List<GameObject> titlePrefabs;
    public float tileLength = 30;
    public int numberOfTiles = 3;
    public float zSpawn = 0;
    public int totalNumOfTiles = 10;
    [SerializeField] Transform playerTransform;
    public float zSpawnPrefab = 0;
    int previousIndex;
    void Start()
    {
        for (int i = 0; i < titlePrefabs.Count; i++)
        {
            BYPool pool = new BYPool(titlePrefabs[i].name, 1, titlePrefabs[i].transform);
            BYPoolManager.instance.AddPool(pool);
        }
        for (int i = 0; i < numberOfTiles; i++)
            SpawnTile(i);
    }
    void Update()
    {
        if (playerTransform.position.z - 30 >= zSpawn - (numberOfTiles * tileLength))
        {
            int index = Random.Range(0, totalNumOfTiles);
            while (index == previousIndex)
                index = Random.Range(0, totalNumOfTiles);

            DeleteTile();
            SpawnTile(index);
        }
    }
    void SpawnTile(int index)
    {
        Transform title = BYPoolManager.instance.GetPool(titlePrefabs[index].name).Spawn();
        title.position = Vector3.forward * zSpawn;
        title.rotation = Quaternion.identity;
        activeTiles.Add(titlePrefabs[index]); 
        zSpawn += tileLength;
        previousIndex = index;
    }
    void DeleteTile()
    {
        if (activeTiles.Count == 0 || activeTiles == null)
            return;
        for (int i = activeTiles.Count - 1; i >= 0; i--)
        {
            bool tileMatched = false;
            foreach(var prefab in titlePrefabs)
            {
                if(prefab.name.Equals(activeTiles[i].name))
                {
                    BYPoolManager.instance.GetPool(activeTiles[i].name).Despawn(activeTiles[i].transform);
                    activeTiles.RemoveAt(i);
                    tileMatched = true;
                    break;
                }
            }
            if (tileMatched)
                break;
        }
    }
}
