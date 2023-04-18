using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MouseLeftToRight : MonoBehaviour
{
    public GameObject ratNoHeart;
    public GameObject ratWithHeart;
    private GameObject heartMouse;
    public Animator anim;
    private Vector3 ratPos = new Vector3 (5.95f, -1.21f, 10f);
    private bool cheeseRat = false;
    private bool diamondRat = false;
    
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
            if (col.gameObject.name.Contains("Cheese"))
            {
                cheeseRat = true;
            }
            if (col.gameObject.name.Contains("Diamond"))
            {
                diamondRat = true;
            }
            Invoke("RatWithHeart", 1f);
        }
    }

    void RatNoHeart()
    {
        Instantiate(ratNoHeart,ratPos,Quaternion.identity);
    }

    void RatWithHeart()
    {
        heartMouse = Instantiate(ratWithHeart,ratPos,Quaternion.identity);
        anim = heartMouse.GetComponentInChildren<Animator>();
        if (diamondRat)
        {
            anim.SetBool("diamondHeart", true);
            diamondRat = false;
        }

        if (cheeseRat)
        {
            anim.SetBool("cheeseHeart", true);
            cheeseRat = false;
        }
    }
}
