using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public GameObject button;
    public GameObject conveyorbeltMouse;
    public GameObject operationObject;
    public GameObject fakeButton;

    public static bool objIsDestroyed;
    public static bool buttonPressable;
    private int numberCount = 0;

    public Image mouseCount;
    public GameObject fadeOut;
    public GameObject fadeIn;
    private GameObject fadeInObj;

    public AudioSource conveyorBelt;
    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        fadeInObj = Instantiate(fadeIn);
        Invoke("DestroyFadeIn", 2f);

        objIsDestroyed = false;
        buttonPressable = true;
    }

    private void DestroyFadeIn()
    {
        Destroy(fadeInObj);
    }

    public int NumberCount
    {
        get
        {
            return numberCount;
        }
        set
        {
            numberCount = value;
            Debug.Log(numberCount);
            mouseCount.fillAmount = numberCount/10f;

            if (numberCount == 10)
            {
                Instantiate(fadeOut);
                conveyorBelt.Stop();
                Invoke("LoadScene", 2f);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }
        
        if (Input.GetKey(KeyCode.R))
        {
            LoadScene();
        }
        
        if (Input.GetMouseButtonUp(0) && !objIsDestroyed)
        {
            if (!Table.instance.onBelt)
            {
                Destroy(ConveyorBelt.Instance.gameObject);
                Table.instance.onBelt = true;

                Vector2 platePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 platePosxyz = platePos;

                Instantiate(operationObject, platePosxyz, Quaternion.identity);
                if (conveyorBelt.isPlaying)
                {
                    conveyorBelt.Stop();
                }
                objIsDestroyed = true;
            }
        }

        if (buttonPressable)
        {
            button.SetActive(true);
            fakeButton.SetActive(false);
        }

        if (!buttonPressable)
        {
            button.SetActive(false);
            fakeButton.SetActive(true);
        }
        
        if (ToolFollow.knifeFollow || SewingFollow.sewingFollow || SpawnChip.chipIsFollow)
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }
    }

    public void Spawn()
    {
        Instantiate(conveyorbeltMouse, new Vector3(-7.42f, 7f, 10), Quaternion.identity);
        buttonPressable = false;
        // if (conveyorBelt.isPlaying)
        // {
        //     conveyorBelt.Stop();
        // }
        // conveyorBelt.Play(0);
        //Invoke("EnsableButton", 0.7f);
    }

    public void EnsableButton()
    {
        buttonPressable = true;
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(4);
    }

}
