using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Homework 8:
// We're upgrading our movement system (refer to Functions/MovementSystem.cs)
// Our movement system should be able to handle a fixed-size array of however many elements you want.
// You need to create an array of game objects, loop through them via for-loop, then call MoveObject()
// on each element to move all game objects as we were initially, just automated this time!
public class Homework8 : MonoBehaviour
{
    // TODO -- create an array of game objects
    float speed = 10.0f;
    public GameObject[] ObjectsToMove;
    Vector3 MoveObject(Vector3 direction, float speed)
    {
        return direction * speed * Time.deltaTime;
    }

    void Start()
    {
        
    }

    void Update()
    {
        // TODO -- loop through all game objects and call MoveObject on each element
        foreach (GameObject obj in ObjectsToMove)
        {
            Vector3 movement = MoveObject(Vector3.forward, speed);
            obj.transform.Translate(movement);
        }
    }
}
