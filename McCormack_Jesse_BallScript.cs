using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update

    public float speedX = 0.01f;
    public float direction = 1.0f;
    public float vertical = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            direction = direction * -1.0f;
        }
        
        if(transform.position.x > 19.0f)
        {
            direction = direction * -1.0f;
            vertical = Random.Range(-0.01f, 0.01f);
        }
        if (transform.position.x < -19.0f)
        {
            direction = direction * -1.0f;
            vertical = Random.Range(-0.01f, 0.01f);
        }

        if (transform.position.y < 10.0f)
        {
            vertical = vertical * -1.0f;
        }
        if (transform.position.y > -10.0f)
        {
            vertical = vertical * -1.0f;
        }


        transform.position = transform.position + new Vector3(speedX * direction, vertical, 0.0f);
    }
}
