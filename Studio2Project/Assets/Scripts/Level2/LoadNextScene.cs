using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    public static int mouseNumber = 0;
    public GameObject fadeOut;


    // Update is called once per frame
    void Update()
    {
        if (mouseNumber == 10)
        {
            Instantiate(fadeOut);
            Invoke("LoadScene", 2f);
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(2);
    }
}
