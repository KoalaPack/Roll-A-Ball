using UnityEngine;
using UnityEngine.UI;

public enum CameraStyle { Fixed, Free }

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    public CameraStyle cameraStyle;
    public Transform pivot;
    public float rotationSpeed;

    public Vector3 offset;
    private Vector3 pivotOffset;

    public Toggle cameraToggle; // Reference to your UI toggle
    public Text freeModeText;   // Reference to the free mode UI text element
    public Text fixedModeText;  // Reference to the fixed mode UI text element

    private void Start()
    {
        pivotOffset = pivot.position - Player.transform.position;
        offset = transform.position - Player.transform.position;

        // Set the initial state of the text elements
        freeModeText.gameObject.SetActive(false); // Start with Free Mode text inactive
        fixedModeText.gameObject.SetActive(true); // Start with Fixed Mode text active

        // Register the OnValueChanged event of the toggle to call the ToggleCameraStyle function
        cameraToggle.onValueChanged.AddListener(ToggleCameraStyle);
    }

    private void LateUpdate()
    {
        if (cameraStyle == CameraStyle.Fixed)
        {
            transform.position = Player.transform.position + offset;
        }

        if (cameraStyle == CameraStyle.Free)
        {
            pivot.transform.position = Player.transform.position + offset;

            Quaternion turnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);

            offset = turnAngle * offset;

            transform.position = pivot.transform.position + offset;

            transform.LookAt(pivot);
        }
    }

    public void ToggleCameraStyle(bool isFreeStyle)
    {
        cameraStyle = isFreeStyle ? CameraStyle.Free : CameraStyle.Fixed;

        // Activate or deactivate the appropriate text elements based on the checkbox state
        freeModeText.gameObject.SetActive(isFreeStyle);
        fixedModeText.gameObject.SetActive(!isFreeStyle);
    }
}
