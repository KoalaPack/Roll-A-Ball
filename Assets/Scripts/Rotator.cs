using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed; // The rotation speed of the object
    void Update()
    {
        // Rotate the object based on the axis (Vector3) and speed 
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime * speed);
    }
}
