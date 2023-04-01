using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestrorBoardOnOut : MonoBehaviour
{
    public static int setNumber;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
        setNumber++;
    }
}