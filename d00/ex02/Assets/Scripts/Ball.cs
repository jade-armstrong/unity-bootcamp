using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject club;
    Vector3 distanceToClub;
    Vector2 ballDirection;
    Rigidbody2D rb2d;
    [SerializeField] float magnitude = 1;
    SpriteRenderer clubSprite;
    SpriteRenderer ballSprite;
    int score = -15;
    bool inHole;
    bool keyPressed = false;
    bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        clubSprite = club.GetComponent<SpriteRenderer>();
        ballSprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Only show the club when the player can hit the ball
        if (rb2d.velocity != new Vector2(0, 0))
        {
            clubSprite.enabled = false;
        }
        else
        {
            if (gameOver == false)
            {
                clubSprite.enabled = true;
            }
        }
        //End game if ball is in hole.
        if (rb2d.velocity == new Vector2(0, 0) && inHole == true)
        {
            gameOver = true;
            ballSprite.enabled = false;
            clubSprite.enabled = false;
        }
        //Hit ball harder after holding mouse button down
        if (rb2d.velocity == new Vector2(0, 0) && Input.GetKey(KeyCode.Mouse0))
        {
            keyPressed = true;
            if (magnitude < 50)
            {
                magnitude += 0.2f;
            }
        }
        //Hit ball away from club
        distanceToClub = gameObject.transform.position - club.transform.position;
        ballDirection.x = distanceToClub.x;
        ballDirection.y = distanceToClub.y;
        if (rb2d.velocity == new Vector2(0, 0) && Input.GetKeyUp(KeyCode.Mouse0))
        {
            rb2d.velocity = ballDirection * magnitude;
            magnitude = 1;
        }
        //Change score if the ball was hit but only when the ball stops.
        if (keyPressed && rb2d.velocity == new Vector2(0, 0) && !(Input.GetKey(KeyCode.Mouse0)))
        {
            keyPressed = false;
            score += 5;
            if (gameOver == false)
            {
                Debug.Log("Score: " + score);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Hole")
        {
            inHole = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Hole")
        {
            inHole = false;
        }
    }
}
