using System.Collections;
using System.Collections.Generic;
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

        //Debug.Log(worldpoz);
        //Debug.Log(Camera.main.ScreenToWorldPosition(Input.mousePosition));

        transform.position = worldpoz;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hello");
        // Check if the other collider has the tag "slot"
        if (other.gameObject.name.Contains("Slot"))
        {
            Debug.Log("meet");
            // Destroy the coin game object
            Destroy(gameObject);
            // play an audio here;

        }
    }
}
