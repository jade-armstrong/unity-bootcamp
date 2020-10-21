using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourCol_ex01 : MonoBehaviour
{
    [HideInInspector] public bool inExit = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Exit")
        {
            inExit = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Exit")
        {
            inExit = false;
        }
    }
}
