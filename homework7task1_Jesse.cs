using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour
{
    // Homework: if the AI has detected the player, shoot at it!
    public GameObject target;
    float speed = 2.0f;
    bool seeking = false;
    public GameObject bullet;
    //float rotation = 0.0f; //USELESS PLZ IGNORE I COPYPASTED FOR EASE
    //float rotationSpeed = 250.0f * Mathf.Deg2Rad;//I GUESS I COULD DELETE IT BUT FORGET IT I MAY WANT IT LATER
    private float fireTimer = 0.0f;
    public float fireRate = 2.0f;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        seeking = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        seeking = false;
    }

    // Update is called once per frame
    void Update()
    {
        

        float dt = Time.deltaTime;
        if (seeking)
        {
            fireTimer -= dt;
            Vector3 direction = (target.transform.position - transform.position).normalized;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * dt);
            if (fireTimer <= 0.0f)
            {
                FIREATWILL(direction);

                // Reset the fire timer
                fireTimer = 1.0f / fireRate; 
            }

        }

        
    }
    public void FIREATWILL(Vector3 direction)
    {
        

        GameObject bulletClone = Instantiate(bullet, transform.position + direction, Quaternion.identity);
        bulletClone.GetComponent<Rigidbody2D>().velocity = direction * 5.0f;
        Destroy(bulletClone, 2.0f);
    }
}
