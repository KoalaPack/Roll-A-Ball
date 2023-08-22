using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class WrongWayTrigger : MonoBehaviour
{
    public TMP_Text WrongWayText;


    private void Start()
    {
        WrongWayText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("player hitting wall");
            WrongWayText.gameObject.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        WrongWayText.gameObject.SetActive(false);
    }

}
