using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnobRotate : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 dragStartPos;
    private float startAngle;

    private void Update()
    {
        if (isDragging)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
            mousePos -= objectPos;
            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - startAngle;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            if (angle >= 180f)
            {
                StartCoroutine(MoveCamera());
            }
        }
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
