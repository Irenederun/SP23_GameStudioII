using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Proceed : MonoBehaviour
{
    public Button finishButton;
    private Image buttonImage;
    public GameObject board;
    private Rigidbody2D rb2d;

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
            finishButton.enabled = true;
        }
        else
        {
            finishButton.enabled = false;
            buttonImage.color = Color.white;
        }
    }

    public void GoDown()
    {
        rb2d = board.GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 1;
    }
}
