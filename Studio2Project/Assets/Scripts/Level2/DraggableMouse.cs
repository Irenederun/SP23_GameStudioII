using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DraggableMouse : MonoBehaviour
{
    private bool dragging = false;
    private Vector2 objectPos1;
    private Vector3 objectPosxyz;
    private Vector2 mousePos;
    private Vector3 initialPos;
    public float leftLimit;
    public float rightLimit;
    public float upperLimit;
    public float lowerLimit;

    private void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if (dragging && mousePos.x > leftLimit && mousePos.x < rightLimit && mousePos.y < upperLimit && mousePos.y > lowerLimit)
        {
            objectPos1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            objectPosxyz = objectPos1;
            transform.position = objectPosxyz;
        }

        if (dragging && mousePos.y < lowerLimit)
        {
            dragging = false;
            Respawn();
        }
    }
    
    private void OnMouseDown()
    {
        dragging = true;
    }

    private void OnMouseUp()
    {
        dragging = false;
    }

    private void Respawn()
    {
        transform.position = initialPos;
    }
}
