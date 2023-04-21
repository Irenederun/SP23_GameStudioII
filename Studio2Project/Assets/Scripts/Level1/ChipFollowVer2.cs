using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ChipFollowVer2 : MonoBehaviour
{
    private Vector2 objectPos;
    private Vector3 objectPosxyz;
    private bool chipOnPlate;
    private bool followng = true;
    
    // Update is called once per frame
    void Update()
    {
        if (!followng)
        {
            transform.localScale = new Vector3(0.67f, 0.67f, 0.67f);
        }

        if (followng)
        {
            Cursor.visible = false;
            objectPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            objectPosxyz = objectPos;
            transform.position = objectPosxyz;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 13)
        {
            chipOnPlate = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.layer == 13)
        {
            chipOnPlate = false;
        }
    }

    private void OnMouseDown()
    {
        if (chipOnPlate)
        {
            followng = false;
            Cursor.visible = true;
        }
    }
}
