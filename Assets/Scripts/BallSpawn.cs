using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallSpawn : MonoBehaviour
{
    public GameObject ballPrefab;
    GameObject ball;
    Rigidbody2D ballRB;
    Vector2 startPos, startVel;
    public float ballSpeed = 1;
    public float minY, maxY;
    public float p1_scoreX, p2_scoreX;
    public float spawnDelay = 1;
    float spawnTimer;
    bool spawned = false;
    bool p1Side = true;
    ScoreUpdate scoreP1, scoreP2;
    bool ended = false;

    // Use this for initialization
    void Start()
    {
        spawnTimer = Time.time + spawnDelay;
        scoreP1 = GameObject.FindGameObjectWithTag("HUD_P1").GetComponent<ScoreUpdate>();
        scoreP2 = GameObject.FindGameObjectWithTag("HUD_P2").GetComponent<ScoreUpdate>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawned)
        {
            if (Time.time >= spawnTimer)
            {
                spawned = true;
                startPos = new Vector2(0, Random.Range(minY, maxY));
                ball = Instantiate(ballPrefab, startPos, Quaternion.identity);
                ballRB = ball.GetComponent<Rigidbody2D>();
                startVel = new Vector2(Random.Range(0.33f, 1), Random.Range(0.33f, 1)).normalized;
                if (p1Side)
                {
                    startVel *= -(ballSpeed + scoreP1.Score / 20f);
                    p1Side = false;
                }
                else
                {
                    startVel *= (ballSpeed + scoreP2.Score / 20f);
                    p1Side = true;
                }
                ballRB.velocity = startVel;
            }
        }
        else
        {
            // TODO: Check for p1_scoreX, p2_scoreX to score
            if (ballRB.position.x > p2_scoreX)
            {
                BallReset();
                if (!ended)
                {
                    scoreP1.ChangeScore();
                    if (scoreP1.Score >= 11)
                    {
                        EndGame();
                    }
                }
            }
            else if (ballRB.position.x < p1_scoreX)
            {
                BallReset();
                if (!ended)
                {
                    scoreP2.ChangeScore();
                    if (scoreP2.Score >= 11)
                    {
                        EndGame();
                    }
                }
            }
        }

        if (ended)
        {
            if (Input.GetButtonDown("Jump"))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    void BallReset()
    {
        Destroy(ball);
        spawned = false;
        spawnTimer = Time.time + spawnDelay;
    }

    void EndGame()
    {
        //scoreP1.ResetScore();
        //scoreP2.ResetScore();
        Destroy(GameObject.Find("paddle_P1"));
        Destroy(GameObject.Find("paddle_P2"));
        ended = true;
    }
}
