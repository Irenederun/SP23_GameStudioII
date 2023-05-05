using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartSceneChanger : MonoBehaviour
{

    private void Update()
    {
        SceneManager.LoadScene(1);
    }

}
