using System.Collections.Generic;
using UnityEngine;

public class ClicktoChange : MonoBehaviour
{
    private bool clicking = false;
    private int clickTimes;
    
    private SpriteRenderer spriteRenderer;
    public List<Sprite> sprites;
    
    public GameObject draggedAway;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.objIsDestroyed && clicking)
        {
            ClickChange();
        }

        if (Input.GetMouseButtonUp(0) && clickTimes == 3)
        {
            Vector3 newPos = this.gameObject.transform.position;
            Instantiate(draggedAway, newPos, Quaternion.identity);
            Destroy(this.gameObject);
            clickTimes++;
            GameManager.objIsDestroyed = false;
        }
    }

    private void OnMouseDown()
    {
        clicking = true;
    }

    private void OnMouseUp()
    {
        clicking = false;
    }

    void ClickChange()
    {
        if (clickTimes == 0)
        {
            clickTimes++;
            spriteRenderer.sprite = sprites[0];
            return;
        }

        if (clickTimes == 1)
        {
            clickTimes++;
            spriteRenderer.sprite = sprites[1];
            return;
        }
        
        if (clickTimes == 2)
        {
            clickTimes++;
            spriteRenderer.sprite = sprites[2];
        }
    }
}
