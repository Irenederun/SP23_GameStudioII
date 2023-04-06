using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class XRayFollow : MonoBehaviour
{
    private Vector2 objectPos;
    private Vector3 objectPosxyz;
    private Vector2 mousePos;
    private float tapTime = 0;
    private bool taping = false;
    public float leftLimit;
    public float rightLimit;
    public float upperLimit;
    public float lowerLimit;
    public GameObject rightCamera;
    public GameObject XRay;
    private Camera cam;
    private Vector3 initialPos;
    private Quaternion initialRot;
    private bool xRayActive = false;
    public static bool allowPass = false;
    public static bool clawAway = false;
    private SpriteRenderer sp;

    public GameObject allowToPass;
    public GameObject NotPass;
    public AudioSource scan;
    
    private void Start()
    {
        cam = rightCamera.GetComponent<Camera>();
        initialPos = transform.position;
        initialRot = transform.rotation;
        sp = GetComponent<SpriteRenderer>();
        sp.color = new Color32(36,36,36, 114);
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (taping)
        {
            if (mousePos.x > leftLimit && mousePos.x < rightLimit && mousePos.y < upperLimit && mousePos.y > lowerLimit)
            {
                MouseFollow();
            }
            
            if (Input.GetKey(KeyCode.Mouse0))
            {
                tapTime++;
            }

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                tapTime = 0;
            }

            if (!FrameReturn.frameUnderBelt && mousePos.y < -1.8f && Input.GetKeyDown(KeyCode.Mouse0))
            {
                transform.position = initialPos;
                transform.rotation = initialRot;
                taping = false;
                FrameReturn.frameUnderBelt = true;
                Cursor.visible = true;
                if (xRayActive)
                {
                    XRay.SetActive(false);
                    xRayActive = false;
                    sp.color = new Color32(36,36,36, 114);
                }
                return;
            }
        }

        if (tapTime*Time.deltaTime > 3f && RatOnBeltRight.arrived)
        {
            XRay.SetActive(true);
            xRayActive = true;
            tapTime = 0;

            if (RatOnBeltRight.normalMouse)
            {
                allowPass = true;
                sp.color = Color.green;
                allowToPass.SetActive(true);
                Invoke("AllowPass", 1f);
            }
            
            if (!RatOnBeltRight.normalMouse)
            {
                allowPass = false;
                sp.color = Color.red;
                NotPass.SetActive(true);
                Invoke("NoPass", 1f);
            }
        }
    }

    void MouseFollow()
    {
        objectPosxyz = mousePos;
        transform.position = objectPosxyz;
        transform.rotation = Quaternion.identity;
        Cursor.visible = false;
    }

    private void OnMouseDown()
    {
        taping = true;
        scan.Play(0);
    }

    private void AllowPass()
    {
        RatOnBeltRight.speed = 1.5f;
        allowToPass.SetActive(false);
    }

    private void NoPass()
    {
        clawAway = true;
        NotPass.SetActive(false);
    }
}
