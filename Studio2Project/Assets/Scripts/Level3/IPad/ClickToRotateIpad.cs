using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ClickToRotateIpad : MonoBehaviour
{
    private int inPlateClickTimes = 0;
    private int outOfPlateClickTimes = 0;
    public static char direction;
    public static bool follow;
    private Vector2 objectPos;
    private Vector3 objectPosxyz;
    
    public static bool ipadIsInPosition;
    private int inTargetClick = 0;
    
    private FixedJoint2D joint2d;

    public Vector3 correctPos;
    
    private SpriteRenderer spIpad;
    public List<Sprite> spList = new List<Sprite>();
    private int randomNum;

    private void Start()
    {
        direction = 'u';
        follow = false;
        spIpad = GetComponent<SpriteRenderer>();
        //randomNum = (int)Random.Range(0, 5);
        //spIpad.sprite = spList[randomNum];
        spIpad.sprite = spList[Proceed.setNumber];
        ipadIsInPosition = false;
        follow = false;
        Debug.Log("Ipad: " + randomNum);
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
        if (!follow && IpadPlate.instance.inPlate)
        {
            transform.rotation = Quaternion.identity;
        }

        if (!follow && ipadIsInPosition)
        {
            transform.position = correctPos;
        }

        if (Proceed.goDown)
        {
            ipadIsInPosition = false;
            transform.position -= new Vector3(0, 2, 0) * Time.deltaTime;
        }
    }

    private void OnMouseDown()
    {
        if (!ClicktoRotateMouse.follow && !ClicktoRotate.follow)
        {
            if (IpadPlate.instance.inPlate)
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
            if (!IpadPlate.instance.inPlate)
            {
                if (gameObject.GetComponent<CheckFitIpad>().IsFullyInTarget)
                {
                    inTargetClick++;
                    switch (inTargetClick % 2)
                    {
                        case 1:
                            follow = false;
                            ipadIsInPosition = true;
                            break;
                        case 0:
                            follow = true;
                            ipadIsInPosition = false;
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
