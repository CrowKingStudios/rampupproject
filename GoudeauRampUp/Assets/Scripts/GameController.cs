using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Collider player1;
    public Collider player2;

    public int p1Points;
    public int p2Points;

    public bool p1Down;
    public bool p2Down;

    void Start()
    {
        p1Points = 0;
        p2Points = 0;
        p1Down = false;
        p2Down = false;
	}
	
	void Update()
    {
		if (player1.gameObject.transform.position.y <= 0)
        {
            p2Points += 10;
        }

        if (player2.gameObject.transform.position.y <= 0)
        {
            p1Points += 10;
        }

        if (p1Points <= 12)
        {
            Time.timeScale = 0;
        }

        if (p2Points <= 12)
        {
            Time.timeScale = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other == player1 && p1Down)
        {
            p1Down = false;
            p2Points -= 1;
        }

        else if (other == player2 && p2Down)
        {
            p2Down = false;
            p1Points -= 1;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other == player1 && !p2Down)
        {
            p1Down = true;
            p2Points += 2;
        }

        else if (other == player2 && !p1Down)
        {
            p2Down = true;
            p1Points += 2;
        }
    }
}