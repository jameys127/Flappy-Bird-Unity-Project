using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject pipeSpawner;


    [ContextMenu("Increasing Score")]
    public void addScore(int scoreToAdd)
    {
        score = score + scoreToAdd;
        scoreText.text = score.ToString();
        if (score % 5 == 0)
        {
            pipeSpawner.GetComponent<PipeSpawnScript>().spawnAtIncreasedSpeedCheck();
            var pipes = GameObject.FindGameObjectsWithTag("Pipe");
            foreach (var pipe in pipes)
            {
                pipe.GetComponent<PipeScript>().increaseSpeed(1);
            } 
        }
    }

    public void playAgainButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        pipeSpawner.GetComponent<PipeSpawnScript>().birdIsDead();
        stoppingPipesAtGameOver();
        gameOverScreen.SetActive(true);
    }

    public void stoppingPipesAtGameOver()
    {
        var pipes = GameObject.FindGameObjectsWithTag("Pipe");
        foreach (var pipe in pipes)
        {
            pipe.GetComponent<PipeScript>().stopSpeed();
        }
    }

}
