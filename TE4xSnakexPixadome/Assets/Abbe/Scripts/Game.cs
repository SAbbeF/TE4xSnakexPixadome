using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public static Game gameInstance;

    [SerializeField]
    private GameObject gameOver;

    private Text scoreText;

    private int scoreCount;

    public bool isOver;

    private void Awake()
    {
        CreateInstance();
    }

    private void Start()
    {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
    }

    private void Update()
    {
        GameOver();
    }

    void CreateInstance()
    {
        if (gameInstance == null)
            gameInstance = this;
    }

    public void IncreaseScore()
    {
        scoreCount++;
        scoreText.text = "Score: " + scoreCount;
    }

    public void GameOver()
    {
        if (SnakeMovementScript.snakeInstance.bodyparts.Count < 1)
        {
            gameOver.SetActive(true);
            isOver = true;
        }
    }
}
