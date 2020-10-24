using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footman : MonoBehaviour
{
    public bool clicked;
    public Vector2 footPos;

    // Start is called before the first frame update
    void Start()
    {
        footPos = (Vector2)transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        clicked = true;
    }

    private void OnMouseUp()
    {
        clicked = false;
    }
}
