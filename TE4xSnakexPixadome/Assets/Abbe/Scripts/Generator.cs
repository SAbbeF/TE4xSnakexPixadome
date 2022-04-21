using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField]
    private GameObject platform;

    [SerializeField]
    private Vector3 startPosition;

    [SerializeField]
    private int spaceBetweenEachPlatform;

    [SerializeField]
    private int row;

    [SerializeField]
    private int column;

    public Generator()
    {

    }

    private void Start()
    {
        CreateLevel();
    }

    public void CreateLevel()
    {
        Vector3 tempPosition = startPosition;

        for (int i = 0; i < column; i++)
        {
            for (int j = 0; j < row; j++)
            {
                GameObject spawnedPlatform = Instantiate(platform, startPosition, Quaternion.identity);
                spawnedPlatform.name = $"{platform.name}_{j}_{i}";

                startPosition.x += spaceBetweenEachPlatform;
            }

            startPosition.x = tempPosition.x;
            startPosition.z += spaceBetweenEachPlatform;
        }
    }

}
