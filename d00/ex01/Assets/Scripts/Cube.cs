using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public KeyCode key;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            string precisionString;
            float precision = System.Math.Abs(gameObject.transform.position.y - (-4.75f));
            precisionString = string.Format("{0:0.000}", System.Math.Truncate(precision * 1000) / 1000);
            Debug.Log("Precision: " + precisionString);
            Destroy(gameObject);
        }
    }
}
