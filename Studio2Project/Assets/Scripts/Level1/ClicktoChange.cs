 using System.Collections.Generic;
using UnityEngine;

public class ClicktoChange : MonoBehaviour
{
    private bool clicking = false;
    private int clickTimes;
    
    private SpriteRenderer spriteRenderer;
    public List<Sprite> sprites;
    
    public GameObject draggedAway;

    private Vector2 objectPos1;
    private Vector3 objectPosxyz;
    public GameObject heart;
    private GameObject thisHeart;
    

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (GameManager.instance.NumberCount == 1)
        {
            spriteRenderer.sprite = sprites[6];
        }
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
        if (clickTimes == 0 && ToolFollow.knifeFollow)
        {
            clickTimes++;

            switch (GameManager.instance.NumberCount)
            {
                case 0:
                    spriteRenderer.sprite = sprites[0];
                    break;
                case 1:
                    spriteRenderer.sprite = sprites[3];
                    break;
                default:
                    spriteRenderer.sprite = sprites[0];
                    break;
            }
            return;
        }

        if (clickTimes == 1 && !ToolFollow.knifeFollow && !SewingFollow.sewingFollow)
        {
            clickTimes++;
            
            UpdateMousePosition();
            thisHeart = Instantiate(heart, objectPosxyz, Quaternion.identity);
            //Cursor.visible = false;
            
            switch (GameManager.instance.NumberCount)
            {
                case 0:
                    spriteRenderer.sprite = sprites[1];
                    break;
                case 1:
                    spriteRenderer.sprite = sprites[4];
                    break;
                default:
                    spriteRenderer.sprite = sprites[1];
                    break;
            }
            SpawnChip.chipIsFollow = false;
            Destroy(SpawnChip.thisChip);
            SpawnChip.clickTimes = 0;
            return;
        }
        
        if (clickTimes == 2 && SewingFollow.sewingFollow)
        {
            clickTimes++;
            switch (GameManager.instance.NumberCount)
            {
                case 0:
                    spriteRenderer.sprite = sprites[2];
                    break;
                case 1:
                    spriteRenderer.sprite = sprites[5];
                    break;
                default:
                    spriteRenderer.sprite = sprites[2];
                    break;
            }
        }
    }
    
    private void UpdateMousePosition()
    {
        objectPos1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        objectPosxyz = objectPos1;
    }
}
