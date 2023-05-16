using System.Collections;
using Fungus;
using UnityEngine;

public class KnobRotate : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 dragStartPos;
    private float startAngle;
    public AudioSource sound;
    public GameObject fadeout;
    private bool operationDone = false;
    private float dragCount = 0;

    private void Update()
    {
        if (isDragging && !operationDone)
        {
            if (dragCount * Time.deltaTime > 1.2f)
            {
                sound.Play(0);   
                Invoke("MoveCam", 1.5f);
                Invoke("fadeOut", 7f);
                operationDone = true;
                //return;
            }
            
            Vector3 mousePos = Input.mousePosition;
            Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
            mousePos -= objectPos;
            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - startAngle;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            dragCount++;
            
            //if (angle >= 225f)
        }
    }

    void MoveCam()
    {
        StartCoroutine(MoveCamera());
    }

    private void fadeOut()
    {
        Instantiate(fadeout);
    }

    private IEnumerator MoveCamera()
    {
        Vector3 startPosition = Camera.main.transform.position;
        Vector3 endPosition = new Vector3(startPosition.x, startPosition.y - 10f, startPosition.z);
        float elapsedTime = 0f;
        float duration = 4f;
        while (elapsedTime < duration)
        {
            Camera.main.transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Camera.main.transform.position = endPosition;
    }


    private void OnMouseDown()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos -= objectPos;
        startAngle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - Mathf.Atan2(transform.right.y, transform.right.x) * Mathf.Rad2Deg;
        isDragging = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }
}
