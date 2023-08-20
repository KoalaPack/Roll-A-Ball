using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingPin : MonoBehaviour
{
    bool knockedOver = false;
    PlayerController playerController;
    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        //A pin is only considered knowkced over if its past halfway on its rotation
        if(transform.up.y < 0.5f && !knockedOver)
        {
            playerController.PinFall();
            knockedOver = true;
        }
    }
}
