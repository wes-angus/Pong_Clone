using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHit : MonoBehaviour
{
    public GameObject particlePrefab;
    GameObject explosion;

    // Use this for initialization
    //void Start () {

    //}

    // Update is called once per frame
    //void Update () {

    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        explosion = Instantiate(particlePrefab, transform.position, Quaternion.identity);
        Destroy(explosion, 1);
    }
}
