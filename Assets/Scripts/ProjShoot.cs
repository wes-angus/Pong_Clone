using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjShoot : MonoBehaviour
{
    public GameObject projPrefab;
    public float projSpeed;
    //bool shootActive = false;
    float shotTimer;
    public float shotDelay = 0.5f;
    GameObject bullet;
    bool p1;
    bool shootingActive = false;
    float powerupTimer;
    public float powerupLength = 10;
    GameObject score;

    // Use this for initialization
    void Start()
    {
        p1 = GetComponent<PaddleMove>().p1;
        shotTimer = Time.time + shotDelay;
        if(p1)
        {
            score = GameObject.FindGameObjectWithTag("HUD_P1");
        }
        else
        {
            score = GameObject.FindGameObjectWithTag("HUD_P2");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (shootingActive)
        {
            if (Time.time >= shotTimer)
            {
                if (p1)
                {
                    if (Input.GetButton("Fire1"))
                    {
                        Shoot();
                        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * projSpeed;
                    }
                }
                else
                {
                    if (Input.GetButton("Fire2"))
                    {
                        Shoot();
                        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.left * projSpeed;
                    }
                }
            }
            if (Time.time >= powerupTimer)
            {
                shootingActive = false;
                score.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }

    void Shoot()
    {
        bullet = Instantiate(projPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<ShotHit>().enemy_p1 = !p1;
        shotTimer = Time.time + shotDelay;
    }

    public void EnableShooting()
    {
        shootingActive = true;
        powerupTimer = Time.time + powerupLength;
        score.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
    }
}
