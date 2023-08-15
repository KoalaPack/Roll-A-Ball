using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    //An enum is a datatype that we can specify its values an and use
    public enum PowerupType {SpeedUp, SpeedDown, Grow, Shrink}

    public PowerupType myPowerup;       //This objects power up type
    public float powerupDuration = 2f;  //The duration of the powerup
    PlayerController playerController;  //A refernce to our player controller

    private void Start()
    {
        //Find and assign the player controller object to this local reference
        playerController = FindObjectOfType<PlayerController>();       

    }

    public void UsePowerup()
    {
        //If this powerup is the speedup powerup, increase the player controller speed by double
        if (myPowerup == PowerupType.SpeedUp)
            playerController.speed = playerController.baseSpeed * 2;

        if (myPowerup == PowerupType.SpeedDown)
            playerController.speed = playerController.baseSpeed / 3;

        //If this powerup is the grow powerup, increase the player controller size by double
        //We also need to move it up on the y axis otherwise it will go through the ground collider
        if (myPowerup == PowerupType.Grow)
        {
            Vector3 temp = playerController.gameObject.transform.position;
            temp.y = 1;
            playerController.gameObject.transform.position = temp;
            playerController.gameObject.transform.localScale = Vector3.one * 2;
        }

        //If this powerup is the shrink powerup, decrease the player size by half
        if (myPowerup == PowerupType.Shrink)
            playerController.gameObject.transform.localScale = Vector3.one / 2;

        //Start a coroutine to reset the powerups effects
        StartCoroutine(ResetPowerup());
    }

    IEnumerator ResetPowerup()
    {
        yield return new WaitForSeconds(powerupDuration);

        //If this powerup relates to speed, reset our player controller speed to its base speed
        if(myPowerup == PowerupType.SpeedUp || myPowerup == PowerupType.SpeedDown)
            playerController.speed = playerController.baseSpeed;

        //If this powerup relates to size, reset our player controller size to 1
        if (myPowerup == PowerupType.Grow || myPowerup == PowerupType.Shrink)
        {
            playerController.gameObject.transform.localScale = Vector3.one;
        }
    }
}
