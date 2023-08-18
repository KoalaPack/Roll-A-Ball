using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float rotationSpeed = 5.0f;

    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - player.transform.position;
    }

    private void LateUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f)
        {
            float targetAngle = Mathf.Atan2(horizontalInput, verticalInput) * Mathf.Rad2Deg + player.transform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, targetAngle, 0);

            Vector3 rotatedOffset = rotation * offset;
            Vector3 desiredPosition = player.transform.position + rotatedOffset;

            transform.position = desiredPosition;
            transform.LookAt(player.transform.position);
        }
        else
        {
            transform.position = player.transform.position + offset;
            transform.LookAt(player.transform.position + player.transform.forward);
        }
    }
}
