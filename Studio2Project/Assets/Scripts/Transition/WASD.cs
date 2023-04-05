using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WASD : MonoBehaviour
{
    private Rigidbody2D rb;
    public float forceAmount = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * forceAmount);
        }
       
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * forceAmount);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.up * forceAmount);
        }
       
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.down * forceAmount);
        }
        rb.velocity *= 0.85f;
        
        transform.rotation = Quaternion.identity;
    }
    
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("enter");
        if (col.gameObject.name.Contains("2"))
        {
            TransitionGameManager.instance.levelChanger++;
            Instantiate(TransitionGameManager.instance.fadeOut);
            Invoke("LoadScene1", 2f);
        }

        if (col.gameObject.name.Contains("3"))
        {
            TransitionGameManager.instance.levelChanger++;
            Instantiate(TransitionGameManager.instance.fadeOut);
            Invoke("LoadScene2", 2f);
        }
    }

    private void LoadScene1()
    {
        SceneManager.LoadScene(1);
    }

    private void LoadScene2()
    {
        SceneManager.LoadScene(2);
    }
}
