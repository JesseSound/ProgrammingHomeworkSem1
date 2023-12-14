using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public GameObject ball;
    public float speed;
    
    
   

    // Update is called once per frame
    void Update()
    {
        // Improvement: fetch these from the Transform component's scale!
        float paddleWidth = transform.localScale.x;
        float paddleHeight = transform.localScale.y;
        float dt = Time.deltaTime;
        float direction = 0.0f;
        if (Input.GetKey(KeyCode.W))
        {
            direction = 1.0f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction = -1.0f;
        }

        // dy = "Delta-Y" AKA "Change in Y"
        float dy = direction * speed * dt;
        transform.position = transform.position + new Vector3(0.0f, dy, 0.0f);
        
        Vector2 ballPosition = ball.GetComponent<Transform>().position;

        Vector2 paddlePosition = transform.position;
        if (Collision.Overlap2D(paddlePosition, paddleWidth, paddleHeight, ballPosition, 1.0f, 1.0f))
        {
            ball.GetComponent<Ball>().dirX *= -1.0f;
            ball.GetComponent<Ball>().speedY = 3.0f;
            // Homework:
            // if the ball is higher than paddle y, make dirY positive (move the ball up)

            if (ballPosition.y > paddlePosition.y)
            {
                ball.GetComponent<Ball>().dirY = 1.0f;
            }
            // if the ball is lower than paddle y, make dirY negative (move the ball down)
            if (ballPosition.y < paddlePosition.y)
            {
                ball.GetComponent<Ball>().dirY = -1.0f;
            }

            
            // (NO CODE NEEDS TO BE WRITTEN OUTSIDE THIS SCOPE BLOCK)
        }

        // Set the ball y equal to paddle y
       // ball.transform.position = new Vector3(ball.transform.position.x, transform.position.y, ball.transform.position.z);


    }
}
