using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScale : MonoBehaviour
{
    float shrinkTimer;
    public float shrinkDelay = 10;
    bool shrunk;

    // Update is called once per frame
    void Update()
    {
        if (shrunk)
        {
            if (Time.time >= shrinkTimer)
            {
                transform.localScale = Vector3.one * 0.375f;
                //Debug.Log("Scale: " + transform.localScale.x);
                shrunk = false;
            }
        }
    }

    public void StartShrinking()
    {
        if (!shrunk)
        {
            transform.localScale = Vector3.one * 0.25f;
            //Debug.Log("Scale: " + transform.localScale.x);
            shrunk = true;
            shrinkTimer = Time.time + shrinkDelay;
        }
    }
}
