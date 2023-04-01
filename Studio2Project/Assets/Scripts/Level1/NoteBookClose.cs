using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBookClose : MonoBehaviour
{
    private BoxCollider2D boxCol;
    public static bool turnOnCollider = false;

    private void Start()
    {
        boxCol = GetComponent<BoxCollider2D>();
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        turnOnCollider = true;
    }
}
