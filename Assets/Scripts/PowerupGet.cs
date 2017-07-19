using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupGet : MonoBehaviour
{
    PowerupSpawn ps;
    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        ps = GameObject.FindGameObjectWithTag("Respawn").GetComponent<PowerupSpawn>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.position.x < ps.P1_scoreX || rb.position.x > ps.P2_scoreX)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            ApplyPowerup(other.gameObject);
        }
        else if (other.gameObject.tag.Equals("Player2"))
        {
            ApplyPowerup(other.gameObject);
        }
    }

    void ApplyPowerup(GameObject paddle)
    {
        paddle.GetComponent<ProjShoot>().EnableShooting();
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        ps.Respawn();
    }
}
