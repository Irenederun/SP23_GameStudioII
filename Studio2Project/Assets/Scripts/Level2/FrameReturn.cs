using UnityEngine;

public class FrameReturn : MonoBehaviour
{
    public static bool frameUnderBelt;

    private void Start()
    {
        frameUnderBelt = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Frame"))
        {
            frameUnderBelt = false;
        }
    }
}
