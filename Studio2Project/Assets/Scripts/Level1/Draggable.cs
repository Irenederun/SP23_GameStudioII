using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private bool dragging = false;
    private Vector2 objectPos1;
    private Vector3 objectPosxyz;
    public GameObject awayMouse;
    
    public List<Sprite> dragMouseSprite;
    private SpriteRenderer mouseRenderer;
    
    private void Start()
    {
        mouseRenderer = gameObject.GetComponent<SpriteRenderer>();
        mouseRenderer.sprite = dragMouseSprite[GameManager.instance.NumberCount];
    }

    void Update()
    {
        Debug.Log(AwayBelt.sendAway);
        if (dragging)
        {
            objectPos1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            objectPosxyz = objectPos1;
            transform.position = objectPosxyz;
        }

        if (!dragging && AwayBelt.sendAway)
        {
            Destroy(gameObject);
            Vector3 beltPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float beltPosx = beltPos.x;
            float beltPosy = beltPos.y;
            Vector3 platePosxyz = new Vector3(beltPosx, beltPosy, 10);

            Instantiate(awayMouse, platePosxyz, Quaternion.identity);
            
            AwayBelt.sendAway = false;
            GameManager.buttonPressable = true;
            GameManager.instance.NumberCount++;
        }
    }
    
    private void OnMouseDown()
    {
        if (!ToolFollow.knifeFollow && !SewingFollow.sewingFollow)
        {
            dragging = true;
        }
    }

    private void OnMouseUp()
    {
        dragging = false;
    }
}
