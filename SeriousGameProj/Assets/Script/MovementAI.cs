using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAI : MonoBehaviour
{

    //used to tweak how fast AI will move around scene
    public float speed;
    private float waitTime;
    public float startWaitTime;


    //array for all positions the AI will move to
    public Transform[] moveSpots;

    //used to pick random position from moveSpots array 
    private int randomSpot;

    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }

        }

        var difference = moveSpots[randomSpot].position - transform.position;
        var isFacingRight = difference.x > 0;

        if (isFacingRight && transform.localScale.x < 0
            || !isFacingRight && transform.localScale.x > 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        // invert the local X-axis scale
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }



}