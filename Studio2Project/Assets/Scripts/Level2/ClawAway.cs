
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawAway : MonoBehaviour
{
    private Vector3 clawPos;
    private Vector3 clawPosInitial;
    public static float speed = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        clawPos = transform.position;
        clawPosInitial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (XRayFollow.clawAway)    
        {
            clawPos.y -= speed * Time.deltaTime;
            transform.position = clawPos;
        }

        if (RatOnBeltRight.clawCollided)
        {
            Debug.Log("up");
            clawPos.y += 2f * Time.deltaTime;
            transform.position = clawPos;
        }

        if (DestroyOnOut.clawReturn)
        {
            transform.position = clawPosInitial;
            DestroyOnOut.clawReturn = false;
        }
    }
}