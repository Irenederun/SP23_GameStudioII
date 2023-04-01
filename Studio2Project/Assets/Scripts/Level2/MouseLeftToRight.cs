using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouseLeftToRight : MonoBehaviour
{
    public GameObject ratNoHeart;
    public GameObject ratWithHeart;
    private Vector3 ratPos = new Vector3 (5.95f, -1.21f, 10f);
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("Mouse"))
        {
            Destroy(col.gameObject);
            Invoke("RatNoHeart", 1f);
        }
        
        if (col.gameObject.name.Contains("WrongRat"))
        {
            Destroy(col.gameObject);
            Invoke("RatWithHeart", 1f);
        }
    }

    void RatNoHeart()
    {
        Instantiate(ratNoHeart,ratPos,Quaternion.identity);
    }

    void RatWithHeart()
    {
        Instantiate(ratWithHeart,ratPos,Quaternion.identity);
    }
}
