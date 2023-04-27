using UnityEngine;

public class Transition3 : MonoBehaviour
{
    public static Transition3 instance;
    public GameObject fadeIn;
    public GameObject fadeOut;
    private GameObject fadeInObj;
    void Start()
    {
        instance = this; 
        
        fadeInObj = Instantiate(fadeIn);
        Invoke("DestroyFadeIn", 2f);
    }

    void DestroyFadeIn()
    {
        Destroy(fadeInObj);
    }
}
