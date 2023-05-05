using UnityEngine;

public class ComponentPlate : MonoBehaviour
{
    public static ComponentPlate instance;
    public bool inPlate; 
    
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("Cloth"))
        {
            inPlate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Cloth"))
        {
            inPlate = false;
        }
    }
}
