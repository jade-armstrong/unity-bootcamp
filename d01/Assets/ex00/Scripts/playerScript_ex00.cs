using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerScript_ex00 : MonoBehaviour
{
    public GameObject playerCam;
    public GameObject claire;
    public GameObject john;
    public GameObject thomas;
    public float speed = 3;
    public float jump = 5;
    GameObject character;
    Rigidbody2D rb2d;
    Vector3 camPos;
    float yVel;


    // Start is called before the first frame update
    void Start()
    {
        character = thomas;
    }


    // Update is called once per frame
    void Update()
    {
        //Handle Scene Reload
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene("ex00");
        }        
        //Handle Character Changes
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            character = claire;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            character = john;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            character = thomas;
        }
        //Center the camera on the character
        camPos = character.transform.position;
        camPos.z = -10;
        playerCam.transform.position = camPos;
        //Handle Character Movement
        rb2d = character.GetComponent<Rigidbody2D>();
        if (Input.GetKeyDown(KeyCode.UpArrow) && rb2d.velocity.y == 0)
        {
            rb2d.velocity += new Vector2(0, jump);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            yVel = rb2d.velocity.y;
            rb2d.velocity = new Vector2(speed, yVel);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            yVel = rb2d.velocity.y;
            rb2d.velocity = new Vector2(speed * -1, yVel);
        }
    }
}
