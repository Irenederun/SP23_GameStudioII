using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    public static int mouseNumber;
    public GameObject fadeOut;
    public GameObject fadeIn;
    private GameObject fadeInObj;

    private void Start()
    {
        fadeInObj = Instantiate(fadeIn);
        Invoke("DestroyFadeIn", 2f);
        mouseNumber = 0;
    }

    void DestroyFadeIn()
    {
        Destroy(fadeInObj);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Number of mouse " + mouseNumber);
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(2);
        }
        
        if (Input.GetKey(KeyCode.R))
        {
            LoadScene();
        }
        
        if (mouseNumber == 10)
        {
            Instantiate(fadeOut);
            Invoke("LoadScene", 2f);
            mouseNumber = 11;
        }
    }

    private void LoadScene()
    {
        Cursor.visible = true;
        SceneManager.LoadScene(5);
    }
}
