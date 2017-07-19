using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotHit : MonoBehaviour
{
    public bool enemy_p1;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.position.x > 3 || rb.position.x < -3)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player" + (enemy_p1 ? "" : "2")))
        {
            other.GetComponent<ResetScale>().StartShrinking();
            Destroy(gameObject);
        }
    }
}
