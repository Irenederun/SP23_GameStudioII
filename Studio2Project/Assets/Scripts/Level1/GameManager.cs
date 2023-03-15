using System;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject button;
    public GameObject parts;
    public GameObject operationObject;
    public GameObject fakeButton;

    public static bool objIsDestroyed = false;
    public static bool buttonPressable = true;
    public static int numberCount = 0;

    public static int NumberCount
    {
        get
        {
            return numberCount;
        }
        set
        {
            numberCount = value;
            Debug.Log(numberCount);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && !objIsDestroyed)
        {
            if (!Table.instance.onBelt)
            {
                Destroy(ConveyorBelt.Instance.gameObject);
                Table.instance.onBelt = true;

                Vector2 platePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 platePosxyz = platePos;

                Instantiate(operationObject, platePosxyz, Quaternion.identity);
                objIsDestroyed = true;
            }
        }

        if (buttonPressable)
        {
            button.SetActive(true);
            fakeButton.SetActive(false);
        }

        if (!buttonPressable)
        {
            button.SetActive(false);
            fakeButton.SetActive(true);
        }

        if (NumberCount > 5)
        {
            NumberCount = 0;
        }

        if (ToolFollow.knifeFollow || SewingFollow.sewingFollow || SpawnChip.chipIsFollow)
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }
    }

    public void Spawn()
    {
        Instantiate(parts, new Vector3(-7f, 7.5f, 10), Quaternion.identity);
    }

}
