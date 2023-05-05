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
    
    public static int setNumber;

    public static bool goDown;
    private GameObject oldBoard;
    private Vector3 boardPos;

    public GameObject leftPlate;
    public GameObject rightPlate;
    
    public AudioSource conveyorBelt;

    // Start is called before the first frame update
    void Start()
    {
        setNumber = 0;
        goDown = false;
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
            SceneManager.LoadScene(3);
        }
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(6);
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
            
            if (newBoardPos.y > 0.47f)
            {
                newBoardPos.y -= 2f * Time.deltaTime; 
                newBoardObj.transform.position = newBoardPos;
            }
            else
            {
                newBoardObj = null;
                if (conveyorBelt.isPlaying)
                {
                    conveyorBelt.Stop();
                }
                //InstantiateNewObjs();
            }
        }

        if (setNumber == 6 || Input.GetKey(KeyCode.R))
        {
            Instantiate(fadeOut);
            conveyorBelt.Stop();
            Invoke("LoadScene", 2f);
        }

        if (goDown)
        {
            boardPos.y -= 2 * Time.deltaTime;
            if (oldBoard == null)
            {
                oldBoard = GameObject.FindWithTag("Board");
                boardPos = oldBoard.transform.position;
            }
            oldBoard.transform.position = boardPos;
        }
    }

    public void GoDown()
    {
        setNumber++;
        board = GameObject.FindWithTag("Board");
        goDown = true;
        conveyorBelt.Play(0);
        leftPlate.GetComponent<MovePlateLeft>().MoveOutward();
        rightPlate.GetComponent<MovePlateRight>().MoveOutward();
        Invoke("NewBoard", 1f);
    }

    public void NewBoard()
    {
        newBoardObj = Instantiate(newBoard, new Vector3(0.05f, 9.16f, 1.73f), Quaternion.identity);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(6);
    }

    public void InstantiateNewObjs()
    {
        GameObject mouseNew = Instantiate(mouse, new Vector3(-10.32f, 0.22f, 0), Quaternion.identity);
        mouseNew.GetComponent<MoveToPos>().MoveToDestPos();
        leftPlate.GetComponent<MovePlateLeft>().MoveInward();
        GameObject clothNew = Instantiate(cloth, new Vector3(10.4f, 3.24f, 0), Quaternion.identity);
        clothNew.GetComponent<MoveToPosCloth>().MoveToDestPos();
        GameObject ipadNew = Instantiate(ipad, new Vector3(10.31f, 0.2f, 0), Quaternion.identity);
        ipadNew.GetComponent<MoveToPosIpad>().MoveToDestPos();
        rightPlate.GetComponent<MovePlateRight>().MoveInward();
    }
}
