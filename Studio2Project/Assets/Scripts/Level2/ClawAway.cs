using UnityEngine;

public class ClawAway : MonoBehaviour
{
    private Vector3 clawPos;
    private Vector3 clawPosInitial;
    public static float speed = 3f;
    private Animator anim;
    public GameObject collidedRat;
    private bool goUp;
    
    // Start is called before the first frame update
    void Start()
    {
        clawPos = transform.position;
        clawPosInitial = transform.position;
        anim = GetComponent<Animator>();
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
            anim.SetBool("catchMouse", true);
            //Invoke("clawReturn", 1f);
        }

        if (goUp)
        {
            clawPos.y += speed * Time.deltaTime;
            transform.position = clawPos;
        }

        if (transform.position.y < 0.15f)
        {
            transform.position = clawPosInitial;   
        }

        if (DestroyOnOut.clawReturn)
        {
            RatOnBeltRight.clawCollided = false;
            goUp = false;
            anim.SetBool("catchMouse", false);
            if (clawPos.y > clawPosInitial.y)
            {
                clawPos.y -= 2f * speed * Time.deltaTime;
                transform.position = clawPos;
            }
            
            if (clawPos.y < clawPosInitial.y)
            {
                transform.position = clawPosInitial;
                DestroyOnOut.clawReturn = false;
            }
        }
    }

    public void RatDead()
    {
        Debug.Log("NOW");
        if (collidedRat != null)
        {
            collidedRat.GetComponent<RatOnBeltRight>().clawAwayMouse();
            goUp = true;
        }
    }
}
