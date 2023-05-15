using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Vector2 mousePosition1;
    private Vector3 mousePos;
    private bool meetSlot;
    //public static bool isFinished;
    //public GameObject fadeOut;
    public List<Sprite> sprites;
    private SpriteRenderer sp;

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        sp.sprite = sprites[0];
    }

    void Update()
    {
        Vector3 mousepos = Input.mousePosition;
        mousepos.z = Camera.main.nearClipPlane;
        Vector3 worldpoz = Camera.main.ScreenToWorldPoint(mousepos);
        //Cursor.visible = false;
        transform.position = worldpoz;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("in trigger");
            // Check if the other collider has the tag "slot"
            if (other.gameObject.name.Contains("Slot"))
            {
                Debug.Log("collided with slot");
                if (Input.GetMouseButton(0))
                {
                    gameManager.instance.ChangeCursor();
                    sp.sprite = sprites[1];
                    Destroy(GetComponent<CircleCollider2D>());
                    Destroy(GetComponent<Rigidbody2D>());
                    
                    // Destroy the coin game object
                    //Destroy(gameObject);
                    //Cursor.visible = true;
                    // play an audio here;

                    //Invoke("FadeOut", 6f);
                }
            }
    }
}
