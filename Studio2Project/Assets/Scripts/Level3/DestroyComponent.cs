using UnityEngine;

public class DestroyComponent : MonoBehaviour
{
    public GameObject proceed;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
        if (col.gameObject.name.Contains("Ipad"))
        {
            proceed.GetComponent<Proceed>().InstantiateNewObjs();
        }
    }
}
