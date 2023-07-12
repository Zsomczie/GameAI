using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTriggers : MonoBehaviour
{
    ScoreCounter scoreCounter;
    Ball ball;
    // Start is called before the first frame update
    void Start()
    {
        scoreCounter = GameObject.Find("Scorecounter").GetComponent<ScoreCounter>();
        ball= GameObject.Find("Sphere").GetComponent<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Sphere"))
        {
            if (gameObject.name.Contains("Player"))
            {
                scoreCounter.PlayerScore++;
                ball.ResetPosition();
                ball.AddStartingForce();
            }
            if (gameObject.name.Contains("AI"))
            {
                scoreCounter.ComputerScore++;
                ball.ResetPosition();
                ball.AddStartingForce();
            }
        }
    }
}
