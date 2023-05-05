using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger0 : MonoBehaviour
{
    public string sceneName; // The name of the scene to change to

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) // Check if any key has been pressed
        {
            SceneManager.LoadScene(sceneName); // Load the specified scene
        }
    }
}
