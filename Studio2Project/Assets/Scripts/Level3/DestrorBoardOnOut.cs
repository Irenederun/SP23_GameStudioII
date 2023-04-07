using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestrorBoardOnOut : MonoBehaviour
{
    //public GameObject mouse;
    //public GameObject cloth;
    //public GameObject ipad;

    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);

        ClicktoRotate.clothIsInPosition = false;
        ClicktoRotateMouse.mouseIsInPosition = false;
        ClickToRotateIpad.ipadIsInPosition = false;

        //if (col.gameObject.name.Contains("Board"))
        //{
            //Instantiate(mouse);
            //Instantiate(cloth);
            //Instantiate(ipad);
        //}
    }
}