using UnityEngine;

public class MovePlateRight : MonoBehaviour
{
    private float initialX;
    private float destX;
    private Vector3 movingPos;
    private bool moveOut;
    private bool moveIn;
    public float outSpeed = 4;
    public float inSpeed = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        initialX = 6.733f;
        destX = 10.483f;
        movingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveOut)
        {
            if (movingPos.x < destX)
            {
                movingPos.x += outSpeed * Time.deltaTime;
                transform.position = movingPos;
            }
            else
            {
                movingPos.x = destX;
                transform.position = movingPos;
            }
        }

        if (moveIn)
        {
            if (movingPos.x > initialX)
            {
                movingPos.x -= inSpeed * Time.deltaTime;
                transform.position = movingPos;
            }
            else
            {
                movingPos.x = initialX;
                transform.position = movingPos;  
            }
        }
    }
    
    public void MoveOutward()
    {
        moveOut = true;
        moveIn = false;
    }

    public void MoveInward()
    {
        moveIn = true;
        moveOut = false;
    } 
}
