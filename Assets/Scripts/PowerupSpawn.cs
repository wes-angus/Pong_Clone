using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawn : MonoBehaviour
{
    public GameObject powerPrefab;
    GameObject powerup;
    Vector2 startPos, startVel;
    public float powerSpeed = 0.5f;
    float minY, maxY;
    float p1_scoreX, p2_scoreX;
    public float spawnDelay = 20;
    float spawnTimer;
    bool spawned;
    bool p1Side;
    int randInt;
    BallSpawn bs;

    public float P1_scoreX
    {
        get
        {
            return p1_scoreX;
        }
    }

    public float P2_scoreX
    {
        get
        {
            return p2_scoreX;
        }
    }

    // Use this for initialization
    void Start()
    {
        bs = GetComponent<BallSpawn>();
        minY = bs.minY;
        maxY = bs.maxY;
        p1_scoreX = bs.p1_scoreX;
        p2_scoreX = bs.p2_scoreX;
        Respawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawned)
        {
            if (Time.time >= spawnTimer)
            {
                randInt = Random.Range(0, 7);
                Debug.Log("Powerup = " + randInt);
                if (randInt == 0)
                {
                    spawned = true;
                    startPos = new Vector2(0, Random.Range(minY, maxY));
                    powerup = Instantiate(powerPrefab, startPos, Quaternion.identity);
                    startVel = Vector2.right;
                    if (p1Side)
                    {
                        startVel *= -powerSpeed;
                    }
                    else
                    {
                        startVel *= powerSpeed;
                    }
                    powerup.GetComponent<Rigidbody2D>().velocity = startVel;
                }
                else
                {
                    spawnTimer += 1;
                }
            }
        }
    }

    public void Respawn()
    {
        spawned = false;
        p1Side = false;
        spawnTimer = Time.time + spawnDelay;
    }
}
