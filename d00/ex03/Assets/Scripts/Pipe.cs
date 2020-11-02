using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed = 1f;
    float pipeY = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position -= new Vector3(speed,0,0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PipeRespawner")
        {
            pipeY = -1.26f + Random.Range(0, 4.86f);
            gameObject.transform.position = new Vector3(11.6f, pipeY, -1f);
        }
    }
}
