using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    //config para
    [Range(0,10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 3;
    [SerializeField] TextMeshProUGUI scoreText;

    //state variable
    [SerializeField] int currentScore = 0;
    // Start is called before the first frame update

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
            if  (gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start() 
    {
        scoreText.text = currentScore.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;

    }

    public void AddToSore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void RestGameScore()
    {
        Destroy(gameObject);
    }
}
