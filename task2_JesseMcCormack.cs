using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loops : MonoBehaviour
{
    // Homework task 2: use loops to spawn grenades in a border pattern (see blackboard task 2 image, 1%)
    public GameObject grenade;
    public Vector3 spawnPosition;
    void Start()
    {
        //TestWhileLoop();
        //TestForLoop();
        SpawnGrenades(420);
    }

    void TestWhileLoop()
    {
        int counter = 1;
        while (counter <= 5)
        {
            Debug.Log("Looping x" + counter);
            counter++;
        }
        Debug.Log("No longer looping");
    }

    void TestForLoop()
    {
        for (int counter = 1; counter <= 5; counter++)
        {
            Debug.Log("Looping x" + counter);
        }
        Debug.Log("No longer looping");
    }

    void SpawnGrenades(int grenadeCount)
    {
        for (int i = 0; i < grenadeCount; i++)
        {
            float xMin, xMax, zMin, zMax;
            xMin = zMin = -100.0f;
            xMax = zMax = 100.0f;



            //border position!!!
            //spawn one wall:
            Vector3 topWall = new Vector3(Random.Range(xMin, xMax), i, zMax);
            GameObject topWallGrenade = Instantiate(grenade, topWall, Quaternion.identity);
            Destroy(topWallGrenade, i/10);

            Vector3 bottomWall = new Vector3(Random.Range(xMin, xMax), i, zMin);
            GameObject bottomWallGrenade = Instantiate(grenade, bottomWall, Quaternion.identity);
            Destroy(bottomWallGrenade, i/10);


            Vector3 leftWall = new Vector3(xMin, i,Random.Range(zMin,zMax));
            GameObject leftWallGrenade = Instantiate(grenade, leftWall, Quaternion.identity);
            Destroy(leftWallGrenade, i/10);

            Vector3 rightWall = new Vector3(xMax, i, Random.Range(zMin, zMax));
            GameObject rightWallGrenade = Instantiate(grenade, rightWall, Quaternion.identity);
            Destroy(rightWallGrenade, i/10);

        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnGrenades(100);
        }
    }
}
