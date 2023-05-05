using UnityEngine;

public class DestroyOnOutLeft : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("Mouse"))
        {
            Destroy(col.gameObject);
        }
    }
}
