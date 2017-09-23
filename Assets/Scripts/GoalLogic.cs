using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalLogic : MonoBehaviour {
    private string nextLevel;

    private bool LastPlayerBall { get
        {
            var players = GameObject.FindGameObjectsWithTag("Player");
            return players.Length <= 1;
        }
    }

    private void Start()
    {
        string currentLevel = SceneManager.GetActiveScene().name;
        nextLevel = GetNextLevel(currentLevel);
    }

    private string GetNextLevel(string currentLevel)
    {
        string nextLevel = "Finish";
        switch(currentLevel)
        {
            case "Level1":
                nextLevel = "Level2";
                break;
            case "Level2":
                nextLevel = "Level3";
                break;
            case "Level3":
                nextLevel = "Level4";
                break;
        }
        return nextLevel;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        switch(collision.gameObject.tag)
        {
            case "Goal":
                if (LastPlayerBall)
                    SceneManager.LoadScene(nextLevel);
                else
                    Destroy(gameObject);
                break;
            case "Enemy":
                SceneManager.LoadScene("Level1");
                break;

        }
    }
}
