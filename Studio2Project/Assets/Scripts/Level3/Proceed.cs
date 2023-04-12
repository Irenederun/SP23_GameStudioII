using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Proceed : MonoBehaviour
{
    public Button finishButton;
    private Image buttonImage;
    private GameObject board;
    private Rigidbody2D rb2d;
    
    public GameObject newBoard;
    private GameObject newBoardObj = null;
    private Vector3 newBoardPos;
    
    public GameObject mouse;
    public GameObject cloth;
    public GameObject ipad;

    public GameObject fadeIn;
    private GameObject fadeInObj;
    public GameObject fadeOut;
    
    private int setNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        buttonImage = finishButton.image;
        fadeInObj = Instantiate(fadeIn);
        Invoke("DestroyFadeIn", 2f);
    }

    void DestroyFadeIn()
    {
        Destroy(fadeInObj);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(2);
        }
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(5);
        }

        if (ClicktoRotate.clothIsInPosition && ClicktoRotateMouse.mouseIsInPosition &&
            ClickToRotateIpad.ipadIsInPosition)
        {
            buttonImage.color = Color.green;
            finishButton.enabled = true;
        }
        else
        {
            finishButton.enabled = false;
            buttonImage.color = Color.white;
        }

        if (newBoardObj != null)
        {
            newBoardPos = newBoardObj.transform.position;
            
            if (newBoardPos.y > 1.01f)
            {
                newBoardPos.y -= 2f * Time.deltaTime; 
                newBoardObj.transform.position = newBoardPos;
            }
            else
            {
                newBoardObj = null;
                InstantiateNewObjs();
            }
        }

        if (setNumber == 5 || Input.GetKey(KeyCode.R))
        {
            Instantiate(fadeOut);
            Invoke("LoadScene", 2f);
        }
    }

    public void GoDown()
    {
        setNumber++;
        board = GameObject.FindWithTag("Board");
        rb2d = board.GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 1;
        Invoke("NewBoard", 1f);
    }

    public void NewBoard()
    {
        newBoardObj = Instantiate(newBoard, new Vector3(0.57f, 9.5f, 0), Quaternion.identity);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(5);
    }

    private void InstantiateNewObjs()
    {
        Instantiate(mouse);
        Instantiate(cloth);
        Instantiate(ipad);
    }
}
