using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro.SpriteAssetUtilities;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class RatOnBeltRight : MonoBehaviour
{
    private Vector2 ratPos;
    public static float speed = 2f;
    public static bool arrived = false;
    public static bool scanSoundEnabled = false;
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
            speed = 2f;
            scanSoundEnabled = true;
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
            ratPos.y += ClawAway.speed * Time.deltaTime;
            transform.position = ratPos;
        }
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
