using UnityEngine;

public class SpawnChip : MonoBehaviour
{
    public GameObject chip;
    private Vector2 objectPos1;
    private Vector3 objectPosxyz;
    public static int clickTimes;
    public static GameObject thisChip;
    public static bool chipIsFollow;

    private void Start()
    {
        clickTimes = 0;
        chipIsFollow = false;
    }

    private void OnMouseDown()
    {
        clickTimes++;
        
        if (clickTimes % 2 == 1)
        {
            UpdateMousePosition();
            thisChip = Instantiate(chip, objectPosxyz, Quaternion.identity);
            chipIsFollow = true;
        }
        
        else
        {
            Destroy(thisChip);
            chipIsFollow = false;
        }
    }
    
    private void UpdateMousePosition()
    {
        objectPos1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        objectPosxyz = objectPos1;
    }
}
