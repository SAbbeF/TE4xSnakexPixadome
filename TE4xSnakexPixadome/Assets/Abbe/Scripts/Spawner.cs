using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    private GameObject fruit;

    [SerializeField]
    private GameObject bomb;

    [SerializeField]
    private Vector3 center;

    [SerializeField]
    private Vector3 size;

    [SerializeField]
    private int maxFruitNumber;

    private int currentFruitNumber;

    [SerializeField]
    private int maxBombNumber;

    private int currentBombNumber;

    [SerializeField]
    private float timeToSpawn;

    private float currentTimeToSpawn;

    private void Start()
    {
        currentTimeToSpawn = timeToSpawn;
        currentFruitNumber = 0;
    }

    private void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        if (currentTimeToSpawn > 0)
        {
            currentTimeToSpawn -= Time.deltaTime;
        }
        else
        {
            SpawnFruit();
            SpawnBomb();
            SpawnBomb();
            currentTimeToSpawn = timeToSpawn;
        }
    }

    private void SpawnFruit()
    {
        if (currentFruitNumber < maxFruitNumber)
        {
            currentFruitNumber++;
            Vector3 position = RandomPosition();

            //fix angle of apple so it be showned to camera, quaternion.
            GameObject spawnFruit = Instantiate(fruit, position, Quaternion.identity);
            spawnFruit.name = $"{fruit.name}_{currentFruitNumber}";
        }
    }

    private void SpawnBomb()
    {
        if (currentBombNumber < maxBombNumber)
        {
            currentBombNumber++;
            Vector3 position = RandomPosition();

            GameObject spawnBomb = Instantiate(bomb, position, Quaternion.identity);
            spawnBomb.name = $"{bomb.name}_{currentBombNumber}";
        }
    }

    private Vector3 RandomPosition()
    {
        Vector3 position = center + new Vector3(
   Random.Range(-size.x / 2, size.x / 2),
   Random.Range(-size.y / 2, size.y / 2),
   Random.Range(-size.z / 2, size.z / 2));

        return position;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}
