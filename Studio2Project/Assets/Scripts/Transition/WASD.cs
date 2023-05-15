using UnityEngine;
using UnityEngine.SceneManagement;

public class WASD : MonoBehaviour
{
    private Rigidbody2D rb;
    public float forceAmount = 5;
    private bool cursorShow = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cursorShow = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.identity;
        if (cursorShow)
        {
            Cursor.visible = true;
            return;
        }
        
        if (!cursorShow)
        {
            Cursor.visible = false;
        }
        
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
    }
    
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("2"))
        {
            cursorShow = true;
            Instantiate(TransitionGameManager.instance.fadeOut);
            Invoke("LoadScene1", 2f);
        }

        if (col.gameObject.name.Contains("3"))
        {
            cursorShow = true;
            Instantiate(Transition2Holder.instance.fadeOut);
            Invoke("LoadScene2", 2f);
        }
        
        if (col.gameObject.name.Contains("4"))
        {
            cursorShow = true;
            Instantiate(Transition2Holder.instance.fadeOut);
            Invoke("LoadScene3", 2f);
        }
    }

    private void LoadScene1()
    {
        SceneManager.LoadScene(2);
    }

    private void LoadScene2()
    {
        SceneManager.LoadScene(3);
    }
    
    private void LoadScene3()
    {
        SceneManager.LoadScene(7);
    }
}
