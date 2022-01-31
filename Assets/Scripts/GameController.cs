using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static bool GameIsOver;

    public GameObject gameOverUI;

    private void Start()
    {
        GameIsOver = false;
    }
    private void Update()
    {
        if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }

        if (Input.GetKeyDown("e")) EndGame();

    }

    private void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }
}
