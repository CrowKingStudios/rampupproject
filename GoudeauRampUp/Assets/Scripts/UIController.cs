using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public Text startText;
    public Text winnerText;
    public Text p1ScoreText;
    public Text p2ScoreText;
    private GameController gameController;
    private float time = 3f;

	void Start()
    {
        gameController = GetComponent<GameController>();
        Destroy(startText, time);
    }
	
	void Update()
    {
        p1ScoreText.text = "P1: " + gameController.p1Points.ToString();
        p2ScoreText.text = "P2: " + gameController.p2Points.ToString();

        if(gameController.p1Points >= 12)
        {
            winnerText.text = "Player 1 Wins!";
        }

        else if (gameController.p2Points >= 12)
        {
            winnerText.text = "Player 2 Wins!";
        }
    }
}
