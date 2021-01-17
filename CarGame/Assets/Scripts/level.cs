using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level : MonoBehaviour
{
    public void LoadStartMenu()
    {
        //loads the first scene in the Project
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {

        SceneManager.LoadScene("CarGame");
        FindObjectOfType<GameSession>().ResetGame();

    }

    public static void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }


    public void Exit()
    {
        Application.Quit();
    }

    public static void LoadWinner()
    {
        SceneManager.LoadScene("Winner");
    }
}
