using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_ex01 : MonoBehaviour
{
    public float speed;
    public float jump;
    public GameObject colourCol;
    ColourCol_ex01 colourColScript;
    [HideInInspector] public bool inExit = false;

    private void Start()
    {
        colourColScript = colourCol.GetComponent<ColourCol_ex01>();
    }

    private void Update()
    {
        inExit = colourColScript.inExit;
    }
}