using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform tf;
    public Transform ballTransform;
    public Rigidbody rgBall;

    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        rgBall = ballTransform.GetComponent<Rigidbody>();
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Dot product of two normalized vector is equals to cos of theire angle.
        float yRotation = -Mathf.Acos(Vector3.Dot(rgBall.velocity.normalized, Vector3.right)) * Mathf.Rad2Deg;
        tf.eulerAngles = new Vector3(0, yRotation, 0);
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
