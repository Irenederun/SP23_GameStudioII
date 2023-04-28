using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPosIpad : MonoBehaviour
{
    private Vector3 destPos;
    private Vector3 movingPos;
    private bool moveTo = false;
    public float speed = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        destPos = new Vector3(6.56f, -1.3f, 0);
        movingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveTo)
        {
            if (movingPos.x >= destPos.x)
            {
                movingPos.x -= speed * Time.deltaTime;
                transform.position = movingPos;
            }
            else
            {
                movingPos.x = destPos.x;
                transform.position = movingPos;
                moveTo = false;
                Destroy(gameObject.GetComponent<MoveToPosIpad>());
            }
        }
    }

    public void MoveToDestPos()
    {
        moveTo = true;
    }
}
