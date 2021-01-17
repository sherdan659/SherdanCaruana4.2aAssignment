using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text scoreText;
    public GameSession gameSession;
    public void Start()
    {
        scoreText = GetComponent<Text>();
        gameSession = FindObjectOfType<GameSession>();
    }

    public void Update()
    {
        scoreText.text = gameSession.GetScore().ToString();
    }
}
