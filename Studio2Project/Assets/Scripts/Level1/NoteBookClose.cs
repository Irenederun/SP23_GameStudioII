using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBookClose : MonoBehaviour
{
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
