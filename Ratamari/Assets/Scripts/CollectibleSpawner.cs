using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    public float yPos;

    public float numberOfCollectiblesToSpawn;
    public List<GameObject> collectiblePrefabs;
    public Transform collectibleParent;
    public float angleToTiltParent;

    void Start()
    {
        SpawnItems();
    }

    public void SpawnItems()
    {
        for (int i = 0; i < numberOfCollectiblesToSpawn; i++)
        {
            int rand = Random.Range(0, collectiblePrefabs.Count);

            GameObject collectibleToSpawn = collectiblePrefabs[rand];

            float randX = Random.Range(minX, maxX);
            float randZ = Random.Range(minZ, maxZ);

            Vector3 spawnPos = new Vector3(randX, yPos, randZ);

            Instantiate(collectibleToSpawn, spawnPos, transform.rotation, collectibleParent);
        }

        collectibleParent.eulerAngles = new Vector3 (angleToTiltParent, 0, 0);
    }
}
