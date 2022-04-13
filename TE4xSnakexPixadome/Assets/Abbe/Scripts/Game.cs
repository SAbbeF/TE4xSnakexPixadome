using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public static Game gameInstance;

    private Text scoreText;

    private int scoreCount;


    private void Awake()
    {
        CreateInstance();
    }

    private void Start()
    {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
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
}
