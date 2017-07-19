using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUpdate : MonoBehaviour
{
    private int score = 0;
    SpriteRenderer sr;
    public Sprite[] numberSprites;

    public int Score
    {
        get
        {
            return score;
        }
    }

    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (score > 9)
        {
            transform.GetChild(0).GetComponent<Renderer>().enabled = true;
        }
    }

    public void ChangeScore()
    {
        score++;
        sr.sprite = numberSprites[score % 10];
    }

    public void ResetScore()
    {
        score = 0;
        sr.sprite = numberSprites[0];
        transform.GetChild(0).GetComponent<Renderer>().enabled = true;
    }
}
