using UnityEngine;

public class Table : MonoBehaviour
{
    public static bool onBelt = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Mouse"))
        {
            Debug.Log("mouse enter");
            onBelt = false;
        }
    }
}
