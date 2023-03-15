using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Proceed : MonoBehaviour
{
    public Button finishButton;
    private Image buttonImage;
        
    // Start is called before the first frame update
    void Start()
    {
        buttonImage = finishButton.image;
    }

    // Update is called once per frame
    void Update()
    {
        if (ClicktoRotate.clothIsInPosition && ClicktoRotateMouse.mouseIsInPosition &&
            ClickToRotateIpad.ipadIsInPosition)
        {
            buttonImage.color = Color.green;
        }
        else
        {
            buttonImage.color = Color.white;
        }
    }
}
