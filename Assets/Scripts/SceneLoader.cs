using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    [SerializeField] private GameObject _startingSceneTransition;
    [SerializeField] private GameObject _endingSceneTransition;

    private void Start()
    {
        _startingSceneTransition.SetActive(true);
    }
    public void LoadMainScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}

