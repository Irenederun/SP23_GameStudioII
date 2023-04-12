using System;
using UnityEngine;

public class AwayBelt : MonoBehaviour
{
    public static bool sendAway;

    private void Start()
    {
        sendAway = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Dragged"))
        {
            sendAway = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Dragged"))
        {
            sendAway = false;
        }
    }
}
