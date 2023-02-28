using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject button;
    public GameObject parts;
    public GameObject operationObject;
    
    public static bool objIsDestroyed = false;
    public static bool buttonPressable = true;
    
    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && !objIsDestroyed)
        {
            if (!Table.onBelt)
            {
                Destroy(ConveyorBelt.Instance.gameObject);
                Table.onBelt = true;

                Vector2 platePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 platePosxyz = platePos;

                Instantiate(operationObject, platePosxyz, Quaternion.identity);
                objIsDestroyed = true;
            }
        }

        if (buttonPressable)
        {
            button.SetActive(true);
        }

        if (!buttonPressable)
        {
            button.SetActive(false);
        }
    }

    public void Spawn()
    {
        Instantiate(parts, new Vector3(-7f, 7.5f, 10), Quaternion.identity);
    }
    
}
