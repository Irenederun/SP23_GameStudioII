
using System;
using System.Collections;
using System.Collections.Generic;
using Fungus;
using MoonSharp.Interpreter;
using TreeEditor;
using UnityEngine;
using Collision2D = UnityEngine.Collision2D;

public class MouseOnBelt : MonoBehaviour
{
    public static MouseOnBelt instance;
    private bool onBelt = false;
    private Vector2 mousePos;
    public static bool clickEnabled = true;

    private void Awake()
    {
        instance = null;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = transform.position;

        if (onBelt == true)
        {
            mousePos.x += 1f * Time.deltaTime;
            transform.position = mousePos;
        }
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.name.Contains("Belt"))
        {
            onBelt = true;
        }
    }
    
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.name.Contains("Belt"))
        {
            onBelt = false;
        }
    }

    private void OnMouseDown()
    {
        if (clickEnabled)
        {
            if (instance == null)
            {
                clickEnabled = false;
                instance = this;
                instance.gameObject.GetComponent<DraggableMouse>().enabled = true;
            }
        }
    }
}
