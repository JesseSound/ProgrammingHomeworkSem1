using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Homework:
// When the player overlaps with either SpeedCircle or SpeedSquare, their speed doubles.
// When the player stops overlapping with either SpeedCircle or SpeedSquare, their speed resets.
// (See https://docs.unity3d.com/Manual/CollidersOverview.html for more info on collisions).
public class TriggerTest : MonoBehaviour
{

    public float playerSpeed;

    public void Awake()
    {
        playerSpeed = gameObject.GetComponent<Player>().speed;
    }

    // Runs once on-enter
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(name + " is triggered by " + collision.name);
        gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        collision.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;

        //speed buff

        gameObject.GetComponent<Player>().speed *= 2;
    }

    // Runs on repeat every frame the gameObject is moving within the collision area
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    Debug.Log(name + " is continuing to be triggered by " + collision.name);
    //}

    // Runs once on-exit
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(name + " is no longer being triggered by " + collision.name);
        gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        collision.gameObject.GetComponent<SpriteRenderer>().color = Color.green;

        //speed reversal


        gameObject.GetComponent<Player>().speed = playerSpeed;

    }
}
