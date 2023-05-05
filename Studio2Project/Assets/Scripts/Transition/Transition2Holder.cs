using UnityEngine;

public class Transition2Holder : MonoBehaviour
{
    public static Transition2Holder instance;
    public int levelChanger = 2;
    public GameObject mouse;
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
