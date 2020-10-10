using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneLoader : MonoBehaviour
{
    GameSession gameStatus;
    private void Start()
    {
        gameStatus = FindObjectOfType<GameSession>();
    }
    public void LoadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        gameStatus.RestGameScore();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
