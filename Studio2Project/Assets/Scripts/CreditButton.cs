using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Credit()
    {
        SceneManager.LoadScene(8);
    }

    public void REturn()
    {
        SceneManager.LoadScene(0);
    }
}
