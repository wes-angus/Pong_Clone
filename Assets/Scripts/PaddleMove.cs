using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMove : MonoBehaviour
{
    public bool p1 = true;
    Rigidbody2D rb;
    public float speed = 1;
    public float yLim;
    float v;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
		if (p1)
        {
            v = Input.GetAxis("Vertical");
            Move();
        }
        else
        {
            v = Input.GetAxis("Vertical2");
            Move();
        }
    }

    private void Move()
    {
        if (v != 0)
        {
            rb.position += new Vector2(0, speed * v);
            rb.position = new Vector2(rb.position.x, Mathf.Clamp(rb.position.y, -yLim, yLim));
        }
    }
}
