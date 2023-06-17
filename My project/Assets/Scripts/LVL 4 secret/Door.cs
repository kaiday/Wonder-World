using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int buttonCount;

    public GameObject door1;
    public GameObject door2;

    public Transform door1newpos;
    public Transform door2newpos;

    // Update is called once per frame
    void Update()
    {

        if (buttonCount == 1)
        {
            door1.transform.position = Vector2.Lerp(door1.transform.position, door1newpos.position, Time.deltaTime);
        }
        else if (buttonCount == 3)
        {
            door2.transform.position = Vector2.Lerp(door2.transform.position, door2newpos.position, Time.deltaTime);
        }
    }
}
