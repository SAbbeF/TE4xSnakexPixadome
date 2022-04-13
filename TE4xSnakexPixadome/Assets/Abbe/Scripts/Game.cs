using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public static Game gameInstance;

    private SceneMenuManagerScript sceneMenuManager;

    [SerializeField]
    private GameObject gameOver;

    private Text scoreText;

    private int scoreCount;

    public bool isOver;

    [SerializeField]
    private float maxTime;

    private float currentTime;

    private void Awake()
    {
        CreateInstance();
    }

    private void Start()
    {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        sceneMenuManager = GameObject.Find("SceneManager").GetComponent<SceneMenuManagerScript>();

        currentTime = maxTime;
        currentTime = 0;
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

            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
            }
            else
            {
                sceneMenuManager.GoToMenu();
                currentTime = maxTime;
            }
        }
    }
}
