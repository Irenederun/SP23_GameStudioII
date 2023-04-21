using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public GameObject hintObject;
    public GameObject objectC;

    private GameObject objectA;

    void Start()
    {
        // 找到场景中名为 "ObjectA" 的物体
        objectA = GameObject.Find("Coin");
    }

    void Update()
    {
        // 检查 objectA 是否已被销毁
        if (objectA == null)
        {
            Debug.Log("find!");
            // 激活提示动画和物体C
            hintObject.SetActive(true);
            objectC.SetActive(true);

            // 销毁 GameManager 组件
            Destroy(this);
        }
    }
}