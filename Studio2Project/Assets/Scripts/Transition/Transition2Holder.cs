using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition2Holder : MonoBehaviour
{
    public static Transition2Holder instance;
    public int levelChanger = 1;
    public GameObject mouse;
    public GameObject fadeIn;
    public GameObject fadeOut;
    private GameObject fadeInObj;
    void Start()
    {
        instance = this; 
        
        fadeInObj = Instantiate(fadeIn);
        Invoke("DestroyFadeIn", 2f);
        
        switch (levelChanger)
        {
            case 0:
                Instantiate(mouse, new Vector3(-6.37f, -1.8f, 0), Quaternion.identity);
                break;
            case 1:
                Instantiate(mouse, new Vector3(0.47f, -0.18f, 0), Quaternion.identity);
                break;
            case 2:
                Instantiate(mouse, new Vector3(5.28f, 3.6f, 0), Quaternion.identity);
                break;
        }
    }

    void DestroyFadeIn()
    {
        Destroy(fadeInObj);
    }
}
