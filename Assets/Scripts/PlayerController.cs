using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f; //Movement of player
    private Rigidbody rb; //Reference to rigidbody of player
    private int pickupCount; //Number of pickups in game
    private Timer timer; //Reference to timer script
    private bool gameOver = false; //Indication to see if the game is over

    [Header("UI")]
    public GameObject inGamePanel; //Panel for in-game screen
    public GameObject winPanel; //Panel for win screen
    public TMP_Text scoreText; //Text for pickup score
    public TMP_Text timerText; //Text for timer
    public TMP_Text winTimeText; //Text for win timer


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Get the number of pickups in our scene
        pickupCount = GameObject.FindGameObjectsWithTag("Pick Up").Length;
        //Run the check pickups function
        CheckPickups();
        //Get the timer object and start the timer
        timer = FindObjectOfType<Timer>();
        timer.StartTimer();

        //Turn on our ingame panel
        inGamePanel.SetActive(true);
        //Turn off our win panel
        winPanel.SetActive(false);

    }

    void FixedUpdate()
    {

        if (gameOver == true)
        {
            return;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    private void Update()
    {
        timerText.text = "Time: " + timer.GetTime().ToString("F2");
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag =="Pick Up")
        {
            Destroy (other.gameObject);
            //Decrement the pickup count
            pickupCount -= 1;
            //Run the check pickups function
            CheckPickups();
        }
    }

    void CheckPickups()
    {
        //Display the amount of pickups left in our scene
        scoreText.text = "pickup Left: " + pickupCount;
        if (pickupCount == 0)
        {
            WinGame();
        }
    }
    void WinGame()
    {
        //Set the game over to true
        gameOver = true;
        //Stop the timer
        timer.StopTimer();
        //Turn off our ingame panel
        inGamePanel.SetActive(false);
        //Turn on our win panel
        winPanel.SetActive(true);
        //Display time on win screen
        winTimeText.text = "Your time is: " + timer.GetTime().ToString("F2");

        //Set the velocity of the rigidbody to zero
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    //Temporary - Remove when doing modules in A2
    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    //Quit the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
