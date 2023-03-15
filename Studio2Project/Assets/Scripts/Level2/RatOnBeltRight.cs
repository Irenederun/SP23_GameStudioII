using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro.SpriteAssetUtilities;
using Unity.VisualScripting;
using UnityEngine;

public class RatOnBeltRight : MonoBehaviour
{
    private Vector2 ratPos;
    public static float speed = 1.5f;
    public static bool arrived = false;
    public static bool normalMouse;
    public static bool clawCollided = false;
    
    void Awake()
    {
        ratPos = transform.position;
        if (gameObject.name.Contains("No"))
        {
            normalMouse = true;
        }

        if (gameObject.name.Contains("With"))
        {
            normalMouse = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ratPos.x < 11f)
        {
            speed = 1.5f;
        }
        ratPos.x += speed * Time.deltaTime;
        transform.position = ratPos;

        if (ratPos.x > 11f && !XRayFollow.allowPass)
        {
            speed = 0;
            arrived = true;
            MouseOnBelt.instance = null;
        }

        if (clawCollided)
        {
            ratPos.y += 2f * Time.deltaTime;
            transform.position = ratPos;
        }
        
        Debug.Log(ratPos.x);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("Claw"))
        {
            clawCollided = true;
            XRayFollow.clawAway = false;
        }
    }
}
