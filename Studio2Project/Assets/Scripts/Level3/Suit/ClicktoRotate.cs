using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClicktoRotate : MonoBehaviour
{
    private int inPlateClickTimes = 0;
    private int outOfPlateClickTimes = 0;
    public static char direction;
    public static bool follow = false;
    private Vector2 objectPos;
    private Vector3 objectPosxyz;

    public static bool clothIsInPosition;
    private int inTargetClick = 0;
    
    private FixedJoint2D joint2d;
    private GameObject connectedBody;

    public Vector3 correctPos;

    // Update is called once per frame
    void Update()
    {
        if (follow)
        {
            objectPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            objectPosxyz = objectPos;
            transform.position = objectPosxyz;
        }
        if (!follow && ComponentPlate.instance.inPlate)
        {
            transform.rotation = Quaternion.identity;
        }

        if (!follow && clothIsInPosition)
        {
            transform.position = correctPos;
        }
    }

    private void OnMouseDown()
    {
        if (!ClickToRotateIpad.follow && !ClicktoRotateMouse.follow)
        {
            if (ComponentPlate.instance.inPlate)
                inPlateClickTimes++;
            {
                switch (inPlateClickTimes % 2)
                {
                    case 1:
                        follow = true;
                        break;
                    case 0:
                        follow = false;
                        outOfPlateClickTimes = 0;
                        break;
                }
            }

            if (!ComponentPlate.instance.inPlate)
            {
                if (gameObject.GetComponent<CheckFit>().IsFullyInTarget)
                {
                    inTargetClick++;
                    switch (inTargetClick % 2)
                    {
                        case 1:
                            UpdateConnectedBody();
                            follow = false;
                            clothIsInPosition = true;
                            //joint2d = gameObject.AddComponent<FixedJoint2D>();
                            //joint2d.connectedBody = connectedBody.GetComponent<Rigidbody2D>();
                            //transform.parent = connectedBody.transform;
                            break;
                        case 0:
                            follow = true;
                            clothIsInPosition = false;
                            Destroy(joint2d);
                            break;
                    }
                }
                else
                {
                    outOfPlateClickTimes++;
                    switch (outOfPlateClickTimes)
                    {
                        case 1:
                            transform.rotation = Quaternion.Euler(0, 0, 90);
                            direction = 'l';
                            break;
                        case 2:
                            transform.rotation = Quaternion.Euler(0, 0, 180);
                            direction = 'd';
                            break;
                        case 3:
                            transform.rotation = Quaternion.Euler(0, 0, 270);
                            direction = 'r';
                            break;
                        case 4:
                            transform.rotation = Quaternion.Euler(0, 0, 0);
                            direction = 'u';
                            outOfPlateClickTimes = 0;
                            break;
                    }
                }
            }
        }
    }
    
    private void UpdateConnectedBody()
    {
        connectedBody = GameObject.FindWithTag("Board");
    }
}
