using UnityEngine;

public class RatOnBeltRight : MonoBehaviour
{
    private Vector2 ratPos;
    public static float speed = 2f;
    public static bool arrived;
    public static bool scanSoundEnabled;
    public static bool normalMouse;
    public static bool clawCollided;
    private GameObject childObj;
    private Animator anim;
    private Animator animScanned;
    
    void Awake()
    {
        ratPos = transform.position;
        if (gameObject.name.Contains("No"))
        {
            normalMouse = true;
        }

        if (gameObject.name.Contains("With"))
        {
            normalMouse = false;
        }
    }

    private void Start()
    {
        arrived = false;
        scanSoundEnabled = false;
        clawCollided = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ratPos.x < 11f)
        {
            speed = 2f;
            scanSoundEnabled = true;
        }
        ratPos.x += speed * Time.deltaTime;
        transform.position = ratPos;

        if (ratPos.x > 11f && !XRayFollow.allowPass)
        {
            speed = 0;
            arrived = true;
            MouseOnBelt.instance = null;
        }

        if (clawCollided)
        {
            anim = GetComponent<Animator>();
            anim.SetBool("clawedDeadMouse", true);
            Invoke("clawAwayMouse", 1f);
        }
    }

    private void clawAwayMouse()
    {
        childObj = gameObject.transform.GetChild(0).gameObject;
        animScanned = childObj.GetComponent<Animator>();
        if (MouseLeftToRight.diamondRat)
        {
            animScanned.SetBool("diamondClawed", true);
        }
        if (MouseLeftToRight.cheeseRat)
        {
            animScanned.SetBool("cheeseClawed", true);
        }
        if (MouseLeftToRight.normalRat)
        {
            animScanned.SetBool("defaultClawed", true);
        }
        ratPos.y += ClawAway.speed * Time.deltaTime;
        transform.position = ratPos;
        anim.SetBool("clawedDeadMouse", false);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("Claw"))
        {
            clawCollided = true;
            XRayFollow.clawAway = false;
        }
    }
}
