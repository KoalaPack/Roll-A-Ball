using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    //An enum is a datatype that we can specify its values an and use
    public enum PowerupType {SpeedUp, SpeedDown, SizeUp, SizeDown}

    public PowerupType myPowerup;       //This objects power up type
    public float powerupDuration = 2f;  //The duration of the powerup
    PlayerController playerController;  //A refernce to our player controller

    private void Start()
    {
        //Find and assign the player controller object to this local reference
        
    }
}
