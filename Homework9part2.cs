using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float age = 0.0f;
    public bool destroyBull = false;
    void Update()
    {
        age += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            destroyBull = true;


        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       destroyBull = false;
    }
}
