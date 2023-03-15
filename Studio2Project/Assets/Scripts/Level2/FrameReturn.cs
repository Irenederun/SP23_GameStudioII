using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameReturn : MonoBehaviour
{
    public static bool frameUnderBelt = true;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Frame"))
        {
            frameUnderBelt = false;
        }
    }
}
