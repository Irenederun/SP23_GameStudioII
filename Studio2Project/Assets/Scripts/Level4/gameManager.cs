using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public GameObject hintObject;
    public GameObject objectC;

    public GameObject objectA;
    
    public GameObject fadeOut;
    public GameObject fadeIn;
    private GameObject fadeInObj;

    public bool ObjADestroyed = false;
    public static gameManager instance;

    private void Awake()
    {
        instance = this;
        Cursor.visible = false;
    }

    void Start()
    {
        fadeInObj = Instantiate(fadeIn);
        Invoke("DestroyFadeIn", 2f);
    }

    private void DestroyFadeIn()
    {
        Destroy(fadeInObj);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Cursor.visible = true;
            SceneManager.LoadScene(0);
            return;
        }
        
        Cursor.visible = false;

    }

    public void ChangeCursor()
    {
        ObjADestroyed = true;
        Debug.Log("find!");
        objectC.SetActive(true);
    }
}
