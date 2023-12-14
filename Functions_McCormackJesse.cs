using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Homework:
// Part 1 -- create 4 functions (1/2 marks).
// Make a function called Add that adds two floats
// Make a function called Sub that subtracts two floats
// Make a function called Mul that multiplies two floats
// Make a function called Div that divides two floats

// Part 2 -- create a function of your choice. Marks will be allocated based on how awesome it is.
// For example, a function that logs to the console is really lame and ultimately worth 0 marks.
// A function that spawns and/or moves objects is considered "awesome" and will give full marks.
public class Functions : MonoBehaviour
{
    public GameObject prefab;
    Rigidbody rb;
    float speed = 10.0f;
    
    //homework, maybe?

    public float Add(float x, float y)
    {
        return x + y;
    }

    public float Sub(float x, float y)
    {
        return x - y;
    }

    public float Mul(float x, float y)
    {
        return x * y;
    }
    public float Div(float x, float y)
    {
        return x / y;
    }
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("This Subtracted: " +Sub(5, 5) + "This is Added: " + Add(2, 1) + "This Divided: " + Div(420, 69) + "This Multiplied " + Mul(6,9));
    }


    // Part 2 - Jesse
    //We be spawning cubes like an earth bender
    //start with a BUNCH of variables
    //While not the most organized way to do this, it's just for grading purposes for you 
    public GameObject cubePrefab;
    public int numberOfCubes = 10;
    public float spacing = 1.0f; //spacing BETWEEN spawned cubes
    public float cubeLifeTime = 0.5f; //Cubes destroy themselves after this time
    public float minHeight = 1.0f; //define minimum height of spawned cubes
    public float maxHeight = 5.0f; //define max height of cubes
    public float distanceAhead = 5.0f; //Spawn distance INFRONT of the player. Game was UNPLAYABLE before hand. They were spawning ON ME
    public float spawnDelay = 0.05f; // Make it look like a wave!!!
    
    // function to handle spawning the cubes!
    //What is an ienumerator???? not really sure but it has to do with coroutines :)
    //allows us to do things over multiple frames
    IEnumerator SpawnCubesWithDelay()
    {
        for (int i = 0; i < numberOfCubes; i++)
        {
            Vector3 spawnPosition = transform.position + transform.forward * (distanceAhead + i * spacing);
            Quaternion spawnRotation = Quaternion.identity;

            // Generate a random height between minHeight and maxHeight
            float randomHeight = Random.Range(minHeight, maxHeight);

            GameObject cube = Instantiate(cubePrefab, spawnPosition, spawnRotation);

            // Set the cube's height
            cube.transform.localScale = new Vector3(1, randomHeight, 1);

            // Destroy the cube after cubeLifeTime seconds
            Destroy(cube, cubeLifeTime);

            yield return new WaitForSeconds(spawnDelay);
        }
    }



    //refer to update() for rest of code



    void MovePlayer(float speed, float dt)
    {
        transform.position += Vector3.forward * speed * dt;
    }

    Vector3 MoveObject(Vector3 direction, float speed, float dt)
    {
        return direction * speed * dt;
    }

    void ThrowGrenade(Vector3 position, Vector3 velocity)
    {
        GameObject grenade = Instantiate(prefab, position, Quaternion.identity);
        grenade.GetComponent<Rigidbody>().velocity = velocity;
        Destroy(grenade, 10.0f);
    }

  

    void Update()
    {
        // Uncomment for custom circle physics!
        //float tt = Time.realtimeSinceStartup;
        //float dt = Time.deltaTime;
        //MovePlayer(10.0f, dt);
        //Vector3 positionDelta = MoveObject(new Vector3(Mathf.Cos(tt), 0.0f, Mathf.Sin(tt)), speed, dt);
        //transform.position += positionDelta;
        rb.velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = transform.forward * speed;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = transform.forward * -speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = transform.right * -speed;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = transform.right * speed;
        }
        if (Input.GetMouseButton(1))
        {
            transform.Rotate(new Vector3(0.0f, Input.GetAxis("Mouse X"), 0.0f) * speed);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 forward = transform.forward;
            Vector3 up = transform.up;
            Vector3 direction = (up + forward).normalized;
            // TODO -- add collision matrix to prevent us from colliding with our own grenades!
            ThrowGrenade(transform.position + direction * 5.0f, direction * 10.0f);
        }


        //Part 2 continued

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(SpawnCubesWithDelay());
        }
    }
}
