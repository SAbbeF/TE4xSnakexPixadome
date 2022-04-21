using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject landPiece;

    [SerializeField]
    private int startPosition;

    [SerializeField]
    private int levelSizeX;

    [SerializeField]
    private int levelSizeY;

    private Vector3 spawnPoint;

    private Vector2[] board;

    private LevelCreator()
    {
        startPosition = 0;
    }


}
