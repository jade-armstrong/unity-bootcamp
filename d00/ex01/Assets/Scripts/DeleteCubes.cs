using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteCubes : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D cube)
    {
        Object.Destroy(cube.gameObject);
    }
}
