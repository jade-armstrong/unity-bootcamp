using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpeed : MonoBehaviour
{
    public GameObject gameMngr;
    gameManager game;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        game = gameMngr.GetComponent<gameManager>();

    }

    public void ChangeGameSpeed()
    {
        game.changeSpeed(speed);           
    }
}
