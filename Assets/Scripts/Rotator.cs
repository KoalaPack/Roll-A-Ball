using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public enum PowerupType { SpeedUp, SizeUp }

    public PowerupType myPowerup;       // This object's power up type

    public float speed; // The rotation speed of the object

    private bool isScalingUp = false;
    private Vector3 originalScale;
    public float scaleSpeed = 1.0f; // The speed at which the object scales

    private void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (myPowerup == PowerupType.SpeedUp)
        {
            // Rotate the object based on the axis (Vector3) and speed 
            transform.Rotate(new Vector3(4, 30, 4) * Time.deltaTime * speed);
        }

        if (myPowerup == PowerupType.SizeUp)
        {
            // Gradually scale up and down the object
            float scaleAmount = Mathf.PingPong(Time.time * scaleSpeed, .5f); // PingPong between 0 and 1
            Vector3 newScale = originalScale + originalScale * scaleAmount;
            transform.localScale = newScale;
        }
    }
}
