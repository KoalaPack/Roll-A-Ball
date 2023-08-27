using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f; // Movement speed of the player

    [HideInInspector]
    public float baseSpeed;

    private Rigidbody rb; // Reference to the player's rigidbody
    private int pickupCount; // Number of pickups in the game
    private Timer timer; // Reference to the timer script
    private bool gameOver = false; // Indicates if the game is over

    [Header("UI")]
    public GameObject inGamePanel; // In-game UI panel
    public GameObject winPanel; // Win screen UI panel
    public TMP_Text scoreText; // Text for pickup score
    public TMP_Text timerText; // Text for timer
    public TMP_Text winTimeText; // Text for win timer

    bool grounded = true;

    //Controllers
    //SoundController soundController;
    CameraController cameraController;


    void Start()
    {
        baseSpeed = speed;

        rb = GetComponent<Rigidbody>();
        pickupCount = GameObject.FindGameObjectsWithTag("Pick Up").Length +
                      GameObject.FindGameObjectsWithTag("BowlingPin").Length;

        CheckPickups();

        timer = FindObjectOfType<Timer>();
        timer.StartTimer();

        inGamePanel.SetActive(true);
        winPanel.SetActive(false);

        cameraController = FindObjectOfType<CameraController>();
    }

    void FixedUpdate()
    {
        if (gameOver)
        {
            return;
        }

        if (grounded)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.AddForce(movement * speed);

            if (cameraController.cameraStyle == CameraStyle.Free)
            {
                transform.eulerAngles = Camera.main.transform.eulerAngles;

                movement = transform.TransformDirection(movement);
            }

            rb.AddForce(movement * speed);
        }
    }

    private void Update()
    {
        timerText.text = "Time: " + timer.GetTime().ToString("F2");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pick Up")
        {
            Destroy(other.gameObject);
            pickupCount--;
            CheckPickups();
        }

        if (other.gameObject.CompareTag("Powerup"))
        {
            Powerup powerup = other.GetComponent<Powerup>();
            powerup.UsePowerup();
            StartCoroutine(DisablePowerupChildrenForDuration(powerup, 6f));
        }
    }

    private IEnumerator DisablePowerupChildrenForDuration(Powerup powerup, float duration)
    {
        // Disable the power-up's children
        foreach (Transform child in powerup.gameObject.transform)
        {
            child.gameObject.SetActive(false);
        }

        // Wait for the specified duration
        yield return new WaitForSeconds(duration);

        // Enable the power-up's children again
        foreach (Transform child in powerup.gameObject.transform)
        {
            child.gameObject.SetActive(true);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
            grounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
            grounded = false;
    }

    public void PinFall()
    {
        pickupCount--;
        CheckPickups();
    }

    void CheckPickups()
    {
        scoreText.text = "Pickups Left: " + pickupCount;
        if (pickupCount <= 0)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        gameOver = true;
        timer.StopTimer();
        inGamePanel.SetActive(false);
        winPanel.SetActive(true);
        winTimeText.text = "Your time is: " + timer.GetTime().ToString("F2");

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
