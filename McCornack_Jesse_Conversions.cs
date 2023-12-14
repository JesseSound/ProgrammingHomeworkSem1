using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Degrees to radians = degrees *pi /180
        float degrees = 400.0f;
        float radians = degrees * Mathf.PI / 180;
        float testRadians = degrees * Mathf.Deg2Rad;
        Debug.Log(radians);
        Debug.Log(testRadians);

        //Radians to degrees
        float radians2 = 5.0f;
        float newDegreeFromRad2 = radians2 * Mathf.Rad2Deg;
        Debug.Log(newDegreeFromRad2);

        // two homeworksss
        //calc the average of two numbers
        // average is sum of two nos / 2


        int num1 = 87;
        int num2 = 34;
        float total;

        total = num1 + num2 / 2;
        Debug.Log(total);


        // bmi??? weight / height ^ 2????

        int weight = 184;
        float height = 1.8452f;// in meters
        float bmi = weight / height;
        Debug.Log(bmi);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
