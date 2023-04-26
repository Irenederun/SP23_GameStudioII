using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class ClicktoRotate : MonoBehaviour
{
    private int inPlateClickTimes = 0;
    private int outOfPlateClickTimes = 0;
    public static char direction;
    public static bool follow;
    private Vector2 objectPos;
    private Vector3 objectPosxyz;

    public static bool clothIsInPosition;
    private int inTargetClick = 0;
    
    private FixedJoint2D joint2d;
    
    private Rigidbody2D rb2d;
    private Vector3 clothPos;

    public Vector3 correctPos;
    
    private SpriteRenderer spCloth;
    public List<Sprite> spList = new List<Sprite>();
    private int randomNum;

    private void Start()
    {
        direction = 'u';
        follow = false;
        spCloth = GetComponent<SpriteRenderer>();
        //randomNum = (int)Random.Range(0, 5);
        //spCloth.sprite = spList[randomNum];
        spCloth.sprite = spList[Proceed.setNumber];
        clothIsInPosition = false;
        follow = false;
        //Debug.Log("Cloth: " + randomNum);
    }

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

        if (Proceed.goDown)
        {
            clothIsInPosition = false;
            transform.position -= new Vector3(0, 2, 0) * Time.deltaTime;
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
                            follow = false;
                            clothIsInPosition = true;
                            break;
                        case 0:
                            follow = true;
                            clothIsInPosition = false;
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
