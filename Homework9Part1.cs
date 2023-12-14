using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Homework 9: Destroy all bullets and remove them from the bullets list if ANY bullets hit the target (Player).
public class Seek : MonoBehaviour
{

  


    public GameObject target;
    public GameObject bullet;
    List<GameObject> bullets = new List<GameObject>();

    float movementSpeed = 2.0f;
    float bulletSpeed = 10.0f;

    float elapsed = 0.0f;   // Current time
    float duration = 0.25f; // Total time

    bool detected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            detected = true;
           
            
        }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.tag.Equals("Bullet"))
            detected = false;
    }

    void ShootBullet()
    {
        // 1. We want our bullet to travel FROM our AI TO our Target
        // Vector from-to (AB) = B - A
        // let A = AI
        // let B = Target
        Vector3 toTarget = target.transform.position - transform.position;
        Vector3 bulletDirection = toTarget.normalized;
        Vector3 bulletPosition = transform.position + bulletDirection;
        GameObject bulletClone = Instantiate(bullet, bulletPosition, Quaternion.identity);
        bulletClone.GetComponent<Rigidbody2D>().velocity = bulletDirection * bulletSpeed;
        bullets.Add(bulletClone);
    }
    

    void Update()
    {

       



        float dt = Time.deltaTime;

        // If detected, seek towards player and shoot bullets if cooldown is expired
        if (detected)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, movementSpeed * dt);

            if (elapsed >= duration)
            {
                elapsed = 0.0f;
                ShootBullet();
            }
            elapsed += dt;
        }

        // Delete bullets if they're off-screen, and/or have been alive for more than 5 seconds.
        for (int i = 0; i < bullets.Count; i++)
        {
            Bullet bulletData = bullets[i].GetComponent<Bullet>();
            if (bulletData.age > 1.0f)
            {
                Destroy(bulletData.gameObject);
                bullets.Remove(bulletData.gameObject);
            }
            // if collision is true on the Bullet script I shall delete and remove bullets here
            if (bulletData.destroyBull)
            {
                Destroy(bulletData.gameObject);
                bullets.Remove(bulletData.gameObject);
            }
        }
        
    }
}
