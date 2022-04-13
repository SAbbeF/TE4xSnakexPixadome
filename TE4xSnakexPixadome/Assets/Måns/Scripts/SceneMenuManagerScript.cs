using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMenuManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }


    public void LoadGame()
    {

        SceneManager.LoadScene("MainScene");

    }


    public void QuitGame()
    {

        Application.Quit();


    }


}
