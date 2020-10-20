using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    int score = 0;
    int count = 0;
    Pipe pipeScript;
    CircleCollider2D flappyCol;
    Rigidbody2D flappyRB;
    bool gameOver = false;
    [SerializeField] List<GameObject> Pipes;
    [SerializeField] AudioClip death;

    // Start is called before the first frame update
    void Start()
    {
        flappyCol = gameObject.GetComponent<CircleCollider2D>();
        flappyRB = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            flappyRB.velocity += new Vector2(0, 5f);
        }
        if (gameOver == true)
        {
            //Stop the pipes
            foreach (GameObject obj in Pipes)
            {
                pipeScript = obj.GetComponent<Pipe>();
                pipeScript.speed = 0f;
            }
            //Make flappy rise a little and then fall
            flappyCol.enabled = false;
            Destroy(flappyRB);
            if (count < 12)
            {
                gameObject.transform.position += new Vector3(0, 0.15f, 0);
                count += 1;
            }
            if (count == 12)
            {
                count += 1;
            }
            if (count > 12 && count < 100)
            {
                gameObject.transform.position -= new Vector3(0, 0.2f, 0);
                count += 1;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Pipe" || collision.gameObject.name == "Ground")
        {
            AudioSource.PlayClipAtPoint(death, new Vector3(0, 0, 0));
            gameOver = true;
            Debug.Log("Time: " + Mathf.RoundToInt(Time.time) + "s");
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Points")
        {
            score += 5;
            Debug.Log("Score: " + score);
            foreach (GameObject obj in Pipes)
            {
                pipeScript = obj.GetComponent<Pipe>();
                pipeScript.speed += 0.01f;
            }
        }
    }
}
