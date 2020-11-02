using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour
{
    Vector3 mousePos;
    Vector3 newPos3;
    Vector2 clubPos;
    Vector2 ballPos;
    Vector2 distanceToBall;
    Vector2 clampZone;
    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        //Move the club with the mouse
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        clubPos.x = mousePos.x;
        clubPos.y = mousePos.y;
        //Restrict the club's movement to within a certain radius of the ball
        ballPos.x = ball.transform.position.x;
        ballPos.y = ball.transform.position.y;
        distanceToBall = clubPos - ballPos;
        clampZone = Vector2.ClampMagnitude(distanceToBall, 1f);
        Vector2 newPos = ballPos + clampZone;
        newPos3.x = newPos.x;
        newPos3.y = newPos.y;
        newPos3.z = -1;
        gameObject.transform.position = newPos3;
        }
}
