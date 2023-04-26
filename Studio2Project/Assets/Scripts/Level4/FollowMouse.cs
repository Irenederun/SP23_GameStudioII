using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Vector2 mousePosition1;
    private Vector3 mousePos;
    private bool meetSlot;
    //public static bool isFinished;

    void Update()
    {
        Vector3 mousepos = Input.mousePosition;
        mousepos.z = Camera.main.nearClipPlane;
        Vector3 worldpoz = Camera.main.ScreenToWorldPoint(mousepos);
        //Cursor.visible = false;
        transform.position = worldpoz;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("hello");
        if (Input.GetMouseButtonDown(0))
        {
            // Check if the other collider has the tag "slot"
            if (other.gameObject.name.Contains("Slot"))
            {
                Debug.Log("meet");
                // Destroy the coin game object
                Destroy(gameObject);
                Cursor.visible = true;
                // play an audio here;

            }
        }
    }
}
