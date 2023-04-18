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
    public static bool cheeseRat = false;
    public static bool diamondRat = false;
    public static bool normalRat = false;
    private GameObject heartRatChild;
    
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

            if (col.gameObject.name.Contains("Default"))
            {
                normalRat = true;
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
        heartRatChild = heartMouse.transform.GetChild(0).gameObject;
        anim = heartRatChild.GetComponent<Animator>();
        if (diamondRat)
        {
            Debug.Log("Diamond");
            anim.SetBool("diamondHeart", true);
        }

        if (cheeseRat)
        {
            Debug.Log("cheese");
            anim.SetBool("cheeseHeart", true);
        }
    }
}
