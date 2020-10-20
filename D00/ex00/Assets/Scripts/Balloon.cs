using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    [SerializeField] float inflateScale = 0.01f;
    [SerializeField] float deflateScale = 0.05f;
    [SerializeField] AudioClip pop;
    [SerializeField] int breath;
    [SerializeField] int breathMax;
    bool start = false;
    bool gameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == false)
        {
            if (Input.GetKey(KeyCode.Space) && breath > 0)
            {
                start = true;
                gameObject.transform.localScale += new Vector3(inflateScale, inflateScale, inflateScale);
                breath -= 1;
                if (gameObject.transform.localScale.x > 6.5)
                {
                    gameOver = true;
                }
            }
            else if (gameObject.transform.localScale.x > 2)
            {
                gameObject.transform.localScale -= new Vector3(deflateScale, deflateScale, deflateScale);
                if (breath < breathMax && !(Input.GetKey(KeyCode.Space)))
                {
                    breath += 10;
                }
                
            }
            else if (start == true)
            {
                gameOver = true;
            }
        }
        if (gameOver == true)
        {
            Debug.Log("Balloon life time: " + Mathf.RoundToInt(Time.time) + "s");
            AudioSource.PlayClipAtPoint(pop, new Vector3(0, 0, 0));
            Destroy(gameObject);
        }
        
        
    }
}
