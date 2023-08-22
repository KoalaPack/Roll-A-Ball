using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RightWayTrigger : MonoBehaviour
{
    public bool RightWay = false;
    public GameObject WrongWayChecker;
    public GameObject Blocker;

    private float objectDisableTime = 2f;

    private void Start()
    {
        Blocker.SetActive(true);
        WrongWayChecker.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Blocker.SetActive(false);
            WrongWayChecker.SetActive(false);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(DisableObjectsForTime(objectDisableTime));
    }
    private IEnumerator DisableObjectsForTime(float time)
    {
        yield return new WaitForSeconds(time);

        Blocker.SetActive(true);
        WrongWayChecker.SetActive(true);
    }
}
