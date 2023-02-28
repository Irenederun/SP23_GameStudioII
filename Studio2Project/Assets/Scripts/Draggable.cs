using UnityEngine;

public class Draggable : MonoBehaviour
{
    private bool dragging = false;
    private Vector2 objectPos1;
    private Vector3 objectPosxyz;
    public GameObject awayMouse;

    void Update()
    {
        if (dragging)
        {
            objectPos1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            objectPosxyz = objectPos1;
            transform.position = objectPosxyz;
        }

        if (!dragging && AwayBelt.sendAway)
        {
            Destroy(this.gameObject);
            Vector3 beltPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float beltPosx = beltPos.x;
            float beltPosy = beltPos.y;
            Vector3 platePosxyz = new Vector3(beltPosx, beltPosy, 10);

            Instantiate(awayMouse, platePosxyz, Quaternion.identity);
            
            AwayBelt.sendAway = false;
            GameManager.buttonPressable = true;
        }
    }
    
    private void OnMouseDown()
    {
        dragging = true;
    }

    private void OnMouseUp()
    {
        dragging = false;
    }
}
