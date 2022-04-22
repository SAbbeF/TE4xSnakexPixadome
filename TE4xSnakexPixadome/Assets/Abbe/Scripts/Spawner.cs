using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Generator generator;

    CheckTrigger checkTrigger;

    [SerializeField]
    private GameObject fruit;

    [SerializeField]
    private GameObject bomb;

    [SerializeField]
    private GameObject trigger;

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

    private List<Transform> usedLocations;

    private int spawnLocationIndex;

    int locationCounter;

    Spawner()
    {
        usedLocations = new List<Transform>();
    }

    private void Start()
    {
        currentTimeToSpawn = timeToSpawn;
        currentFruitNumber = 0;
        locationCounter = 0;
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
            currentTimeToSpawn = timeToSpawn;
        }
    }

    private void SpawnFruit()
    {
        if (currentFruitNumber < maxFruitNumber)
        {
            if (Game.gameInstance.isOver == true)
                return;

            Transform spawnpPosition = GetSpawnLocation();

            GameObject triggerTest = Instantiate(trigger, (spawnpPosition.position + new Vector3(0, 6, 0)), Quaternion.identity);

            if (triggerTest.GetComponent<CheckTrigger>().Triggered == false)
            {
                //Destroy(triggerTest);
                GameObject spawnFruit = Instantiate(fruit, (spawnpPosition.position + new Vector3(0, 3, 0)), Quaternion.identity);
                spawnFruit.name = $"{fruit.name}_{currentFruitNumber}";
                currentFruitNumber++;
            }
        }
    }

    private void SpawnBomb()
    {
        if (currentBombNumber < maxBombNumber)
        {
            if (Game.gameInstance.isOver == true)
                return;

            currentBombNumber++;
            Transform spawnpPosition = GetSpawnLocation();
            
            GameObject spawnBomb = Instantiate(bomb, (spawnpPosition.position + new Vector3(0, 5, 0)), Quaternion.Euler(-90, 0, 0));
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



    public Transform GetSpawnLocation()
    {
        Transform spawnLocation = generator.spawnableLocations[Random.Range(1, (generator.column * generator.row))];
        //spawnLocationIndex = (spawnLocationIndex + 1) % generator.spawnableLocations.Count;

        if (usedLocations.Contains(spawnLocation) && locationCounter < (generator.column * generator.row))
        {
            GetSpawnLocation();
        }
        else if (usedLocations.Count >= (generator.column * generator.row))
        {
            currentBombNumber = maxBombNumber;
            currentFruitNumber = maxFruitNumber;
        }

        locationCounter++;
        usedLocations.Add(spawnLocation);
        return spawnLocation;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}
