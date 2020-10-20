using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public List<GameObject> cubeList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawn()
    {
        int randomIndex = Random.Range(0, 3);
        GameObject cube = GameObject.Instantiate(cubeList[randomIndex]);
        Rigidbody2D cubeRb2d = cube.GetComponent<Rigidbody2D>();
        cubeRb2d.gravityScale = Random.Range(0.5f, 1.2f);
    }
}
