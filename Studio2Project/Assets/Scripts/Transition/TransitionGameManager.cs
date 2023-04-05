using System;
using System.Collections;
using System.Collections.Generic;
using Fungus.EditorUtils;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionGameManager : MonoBehaviour
{
    public static TransitionGameManager instance;
    public int levelChanger = 0;
    public GameObject mouse;
    public GameObject fadeIn;
    public GameObject fadeOut;
    private GameObject fadeInObj;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
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
