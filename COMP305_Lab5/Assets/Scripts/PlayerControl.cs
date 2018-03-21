using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Adding this allows us to access members of the UI namespace including Text.
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

    public float speed;             //Floating point variable to store the player's movement speed.

    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
    public int countblue, countorange, countpink;              //Integer to store the number of pickups collected so far.
    public Text countdownText, scoreText;

    public float timeLeft;
  
    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
        countblue = 0;
        countorange = 0;
        countpink = 0;
        timeLeft = 30.0f;
        countdownText.text = "Time Left: " + timeLeft;
    }
     
    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.AddForce(movement * speed);

        timeLeft -= Time.deltaTime;
        countdownText.text = "Time Left:" + Mathf.Round(timeLeft);
        if (timeLeft < 0)
        {
            scoreText.text = "Blue Candy" + countblue;
            SceneManager.LoadScene("endScene");
        }
    }

    //OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
    void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.CompareTag("PickUp1"))
        {
            other.gameObject.SetActive(false);
            countblue = countblue + 1;
        }

        if (other.gameObject.CompareTag("PickUp2"))
        {
            other.gameObject.SetActive(false);
            countorange = countorange + 1;
        }
        
        if (other.gameObject.CompareTag("PickUp3"))
        {
            other.gameObject.SetActive(false);
            countpink = countpink + 1;
        }
    }
}
