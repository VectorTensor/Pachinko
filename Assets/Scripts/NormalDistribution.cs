using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalDistribution {
  public float mean = 0f;
    public float standardDeviation = 1f;

    // Constants for the y and z components
    public float constantY = 1f;
    public float constantZ = 2f;


    public NormalDistribution(float mean, float sd){
        this.mean = mean;
        standardDeviation = sd;
    }
    
    // Function to generate the random Vector3
    public Vector3 GenerateRandomVector()
    {
        // Generate a random number for the x component using normal distribution
        float x = Random.Range(mean - 2f * standardDeviation, mean + 2f * standardDeviation);
        
        // Generate the constant y and z components
        float y = constantY;
        float z = constantZ;

        // Create and return the Vector3
        return new Vector3(x, y, z);
    }
}
