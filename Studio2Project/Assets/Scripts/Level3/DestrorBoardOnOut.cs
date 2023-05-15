using UnityEngine;

public class DestrorBoardOnOut : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        Proceed.goDown = false;
        Destroy(col.gameObject);

        ClicktoRotate.clothIsInPosition = false;
        ClicktoRotateMouse.mouseIsInPosition = false;
        ClickToRotateIpad.ipadIsInPosition = false;
        Cursor.visible = true;
    }
}