using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    public string sceneName;
    public string scene;
    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        scene = currentScene.name;
    }

    // Update is called once per frame
    void Update()
    {
        if(scene == sceneName)
        {
            LoadGame();
        }

        if(Time.timeScale <= 0) 
        {
            LoadGame();
        }
    }


    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void LoadGame()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadGameScene();
        }
    }
}
