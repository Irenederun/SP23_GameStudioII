using System;
using System.Collections;
using System.Collections.Generic;
using Fungus.EditorUtils;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionGameManager : MonoBehaviour
{
    public static TransitionGameManager instance;
    public int levelChanger = 1;
    public GameObject mouse;
    public GameObject fadeIn;
    public GameObject fadeOut;
    private GameObject fadeInObj;

    // Start is called before the first frame update
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
