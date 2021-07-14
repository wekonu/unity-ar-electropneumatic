using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class geser : MonoBehaviour
{
    public float maxTime;
    public float minSwipeDist;
    public string right;
    public string left;
    float startTime;
    float endTime;
    float swipeDistance;
    float swipeTime;
    Vector3 startPos;
    Vector3 endPos;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                startTime = Time.time;
                startPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                endTime = Time.time;
                endPos = touch.position;
                swipeDistance = (endPos - startPos).magnitude;
                swipeTime = endTime - startTime;
                if (swipeTime < maxTime && swipeDistance > minSwipeDist)
                {
                    swiper();
                }
            }
        }

    }

    void swiper()
    {
        Vector2 distance = endPos - startPos;
        if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
        {
            if (distance.x > 0)
            {
                Application.LoadLevel(left);
            }
            else if (distance.x < 0)
            {
                Application.LoadLevel(right);
            }
        }
        else if (Mathf.Abs(distance.x) < Mathf.Abs(distance.y))
        {
            if (distance.y > 0)
            {
                //up swipe
            }
            else if (distance.y < 0)
            {
                //down swipe
            }
        }
    }
}
