using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHandler : MonoBehaviour
{
    Vector3 mousePos;
    Vector2 unitPos;
    float speed = 2f;
    Animator anim;
    AudioSource voice;
    public List<AudioClip> moveSounds;
    int direction = 0;
    bool left = false;
    SpriteRenderer mySprite;
    public List<GameObject> footies;
    public List<GameObject> footmen;
    GameObject footman;
    Footman footScript;
    bool clicked;
    bool noMove;

    // Start is called before the first frame update
    void Start()
    {
        unitPos = new Vector2(0,0);
        footmen.Clear();
        foreach (GameObject footman in footies)
        {
            footmen.Add(footman);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            footmen.Clear();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            foreach (GameObject footman in footies)
            {
                footScript = footman.GetComponent<Footman>();
                clicked = footScript.clicked;
                if (clicked && (Input.GetKey(KeyCode.LeftControl)))
                {
                    noMove = true;
                    footmen.Add(footman);
                }
                else if(clicked)
                {
                    noMove = true;
                    footmen.Clear();
                    footmen.Add(footman);
                }
            }
            if (!noMove)
            {
                foreach (GameObject footman in footmen)
                {
                    footScript = footman.GetComponent<Footman>();
                    voice = footman.GetComponent<AudioSource>();
                    voice.clip = moveSounds[Random.Range(0, moveSounds.Count)];
                    voice.Play();
                    mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    unitPos.x = mousePos.x;
                    unitPos.y = mousePos.y;
                    if ((footmen.IndexOf(footman)+1) % 2 == 0)
                    {
                        footScript.footPos.x = unitPos.x + ((float)(footmen.IndexOf(footman) * 0.5));
                        footScript.footPos.y = unitPos.y;
                    }
                    else
                    {
                        footScript.footPos.y = unitPos.y + ((float)(footmen.IndexOf(footman) * 0.5));
                        footScript.footPos.x = unitPos.x;
                    }
                    if (footScript.footPos.x < footman.transform.position.x)
                    {
                        left = true;
                    }
                    else
                    {
                        left = false;
                    }
                    //Up
                    if ((Mathf.Abs(footScript.footPos.x) - footman.transform.position.x) < 0.5 && (footScript.footPos.y > footman.transform.position.y))
                    {
                        direction = 1;
                    }
                    //Up-Right
                    if (((Mathf.Abs(footScript.footPos.x) - footman.transform.position.x) > 0.5) && (footScript.footPos.y > footman.transform.position.y) && ((Mathf.Abs(footScript.footPos.y) - footman.transform.position.y) > 0.5))
                    {
                        direction = 2;
                    }
                    //Right
                    if ((Mathf.Abs(footScript.footPos.x) - footman.transform.position.x) > 0.5 && (footScript.footPos.y - footman.transform.position.y > -0.5 && footScript.footPos.y - footman.transform.position.y < 0.5))
                    {
                        direction = 3;
                    }
                    //Down-Right
                    if ((Mathf.Abs(footScript.footPos.x) - footman.transform.position.x) > 0.5 && footScript.footPos.y < footman.transform.position.y && unitPos.y - footman.transform.position.y < -0.5)
                    {
                        direction = 4;
                    }
                    //Down
                    if ((Mathf.Abs(footScript.footPos.x) - footman.transform.position.x) < 0.5 && (footScript.footPos.y < footman.transform.position.y))
                    {
                        direction = 5;
                    }
                }
            }
            
        }
        foreach (GameObject footman in footies)
        {
            footScript = footman.GetComponent<Footman>();
            anim = footman.GetComponent<Animator>();
            mySprite = footman.GetComponent<SpriteRenderer>();
            if ((Vector2)footman.transform.position != footScript.footPos)
            {
                if (left)
                {
                    mySprite.flipX = true;
                }
                else
                {
                    mySprite.flipX = false;
                }
                anim.ResetTrigger("Footman_Idle");
                anim.SetInteger("Direction", direction);
                footman.transform.position = Vector2.MoveTowards(footman.transform.position, footScript.footPos, speed * Time.deltaTime);
            }
            else
            {
                anim.SetInteger("Direction", 0);
                anim.SetTrigger("Footman_Idle");
            }
        }
        noMove = false;
    }
}
