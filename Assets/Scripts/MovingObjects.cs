using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjects : MonoBehaviour
{
    public float waitTime = 8f;

    PlayerController playerController;

    private Animation beamDown;
    private Animation beamUp;

    public bool playerFreeze = false;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        beamDown = GetComponent<Animation>();
        beamUp = GetComponent<Animation>();
        playerFreeze = false;
        beamDown.Play("BeamAnimation");
        Beams();
    }

    private void Beams()
    {
        beamDown.Play("BeamAnimation");
        StartCoroutine(WaitForBeamCooldown());

    }

    IEnumerator WaitForBeamCooldown()
    {
        yield return new WaitForSeconds(waitTime);
        beamUp.Play("BeamUp");
        Beams();

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerFreeze = true;
        }
    }

}
