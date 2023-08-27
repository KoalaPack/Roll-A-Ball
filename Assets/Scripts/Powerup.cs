using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public enum PowerupType { SpeedUp, SpeedDown, Grow, Shrink }

    public PowerupType myPowerup;
    public float powerupDuration = 2f;
    PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    public void UsePowerup()
    {
        if (myPowerup == PowerupType.SpeedUp)
            playerController.speed = playerController.baseSpeed * 1.5f;

        if (myPowerup == PowerupType.SpeedDown)
            playerController.speed = playerController.baseSpeed / 3;

        if (myPowerup == PowerupType.Grow)
        {
            Vector3 temp = playerController.gameObject.transform.position;
            temp.y = 11;
            playerController.gameObject.transform.position = temp;
            playerController.gameObject.transform.localScale = Vector3.one * 2;
        }

        if (myPowerup == PowerupType.Shrink)
            playerController.gameObject.transform.localScale = Vector3.one / 2;

        StartCoroutine(ResetPowerup());
    }

    IEnumerator ResetPowerup()
    {
        yield return new WaitForSeconds(powerupDuration);

        if (myPowerup == PowerupType.SpeedUp || myPowerup == PowerupType.SpeedDown)
            playerController.speed = playerController.baseSpeed;

        if (myPowerup == PowerupType.Grow || myPowerup == PowerupType.Shrink)
        {
            playerController.gameObject.transform.localScale = Vector3.one;
        }
    }
}
