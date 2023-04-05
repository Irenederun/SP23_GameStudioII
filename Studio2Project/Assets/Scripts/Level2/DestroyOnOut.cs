using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyOnOut : MonoBehaviour
{
    public static bool clawReturn = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Destroy"))
        {
            Destroy(gameObject);
            RatOnBeltRight.arrived = false;
            MouseOnBelt.instance = null;
            XRayFollow.allowPass = false;
            RatOnBeltRight.clawCollided = false;
            XRayFollow.clawAway = false;
            MouseOnBelt.clickEnabled = true;
            clawReturn = true;
            
            LoadNextScene.mouseNumber++;
        }
    }
}
