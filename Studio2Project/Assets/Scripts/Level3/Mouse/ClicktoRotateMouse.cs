using System;
using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using Random = UnityEngine.Random;

public class ClicktoRotateMouse : MonoBehaviour
{
    private int inPlateClickTimes = 0;
    private int outOfPlateClickTimes = 0;
    public static char direction;
    public static bool follow;
    private Vector2 objectPos;
    private Vector3 objectPosxyz;
    private FixedJoint2D joint2d;
    
    public static bool mouseIsInPosition;
    private int inTargetClick = 0;

    public Vector3 correctPos;
    
    private SpriteRenderer spMouse;
    public List<Sprite> spList = new List<Sprite>();
    private int randomNum;

    private GameObject mousePlate;

    private void Start()
    {
        direction = 'u';
        follow = false;
        spMouse = GetComponent<SpriteRenderer>();
        //randomNum = (int)Random.Range(0, 5);
        //spMouse.sprite = spList[Proceed.setNumber];
        spMouse.sprite = spList[Proceed.setNumber];
        //Debug.Log("Mouse: " + randomNum);
        mouseIsInPosition = false;
        follow = false;

        if (MousePlate.instance == null)
        {
            GameObject.FindGameObjectsWithTag("MousePlate");
            MousePlate.instance = mousePlate.GetComponent<MousePlate>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("follow: " + follow);
        // Debug.Log("Direction: " + direction);
        // Debug.Log("is In plate: " + MousePlate.instance.inPlate);
        // Debug.Log("is in position: " + mouseIsInPosition);
        
        //Debug.Log("Setnumber: " + Proceed.setNumber);
        
        if (follow)
        {
            objectPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            objectPosxyz = objectPos;
            transform.position = objectPosxyz;
        }
        if (!follow && MousePlate.instance.inPlate)
        {
            transform.rotation = Quaternion.identity;
        }

        if (!follow && mouseIsInPosition)
        {
            transform.position = correctPos;
        }

        if (Proceed.goDown)
        {
            mouseIsInPosition = false;
            transform.position -= new Vector3(0, 2, 0) * Time.deltaTime;
        }
    }

    private void OnMouseDown()
    {
        if (!ClickToRotateIpad.follow && !ClicktoRotate.follow)
        {
            if (MousePlate.instance.inPlate)
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
            if (!MousePlate.instance.inPlate)
            {
                if (gameObject.GetComponent<CheckFitMouse>().CheckIfFullyInTarget())
                {
                    inTargetClick++;
                    switch (inTargetClick % 2)
                    {
                        case 1:
                            follow = false;
                            mouseIsInPosition = true;
                            break;
                        case 0:
                            follow = true;
                            mouseIsInPosition = false;
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
}
