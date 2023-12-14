using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// *Programming* homework 10:
// Change the CheckCollisionCircles function to take in two Circle objects.
// Each circle should store a position and a radius.
public class homeworkCircle
{
    public Vector3 position;
    public float radius;
    public GameObject circleObject;
    
    public homeworkCircle( Vector3 p)
    {
        position = p;
        
        circleObject = new GameObject("Circle");
        circleObject.transform.position = position;
        circleObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        radius = circleObject.transform.localScale.x * 0.5f;
        // Optionally, add a sprite renderer to visualize the circle
        SpriteRenderer spriteRenderer = circleObject.AddComponent<SpriteRenderer>();
        spriteRenderer.color = Color.blue;

        // Load your sprite from the Resources folder (replace "CircleSprite" with your actual sprite name)
        Sprite circleSprite = Resources.Load<Sprite>("CircleSprite");

        if (circleSprite != null)
        {
            spriteRenderer.sprite = circleSprite;
        }
        else
        {
            Debug.LogError("Sprite not found. Make sure you have a sprite named 'CircleSprite' in the Resources folder.");
        }
    } 
}
public class CircleCircleDetection : MonoBehaviour
{
    public GameObject circle1;
    public GameObject circle2;

    homeworkCircle circleOne;
    homeworkCircle circleTwo;

    private void Start()
    {
        circleOne = new homeworkCircle(new Vector3(5.0f, 3.0f,0f));
        circleTwo = new homeworkCircle(new Vector3(10.0f, 15.0f, 0f));
    }




    void Update()
    {
        Vector3 position1 = circle1.transform.position;
        Vector3 position2 = circle2.transform.position;
        float radius1 = circle1.transform.localScale.x * 0.5f;
        float radius2 = circle2.transform.localScale.x * 0.5f;

        Color color = CheckCollisionCircles(circleOne, circleTwo) ?
            Color.green : Color.red;
        
        // The above is a shortcut for the following:
        //if (CheckCollisionCircles(position1, radius1, position2, radius2))
        //    color = Color.green;
        //else
        //    color = Color.red;

        circle1.GetComponent<SpriteRenderer>().color = color;
        circle2.GetComponent<SpriteRenderer>().color = color;
    }

    bool CheckCollisionCircles(homeworkCircle circle1, homeworkCircle circle2)
    {
        // 1. Calculate distance between 
       Vector3 position1 = circle1.circleObject.transform.position;
       Vector3 position2 = circle2.circleObject.transform.position;

        float distance = Vector2.Distance(position1,position2);
        float radius1 = circle1.circleObject.transform.localScale.x * 0.5f;
        float radius2 = circle2.circleObject.transform.localScale.x * 0.5f;
        Debug.Log(radius1);
        Debug.Log(radius2);
        Debug.Log(distance);
        // 2. Calculate sum of radius1 + radius2
        float radiiSum = radius1 + radius2;
      
        // 3. Compare whether the distance is less than the radii sum (if so, there's a collision)!
        return distance < radiiSum;
    }
}
