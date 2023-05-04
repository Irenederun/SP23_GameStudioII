using System;
using System.Collections.Generic;
using UnityEngine;

public class AwayMouse : MonoBehaviour
{
    Vector3 awayPos;
    public List<Sprite> awayMouseSprite;
    private SpriteRenderer mouseRenderer;

    private GameObject audioHolder;
    public AudioSource conveyorBelt;

    private void Start()
    {
         mouseRenderer = gameObject.GetComponent<SpriteRenderer>();
         mouseRenderer.sprite = awayMouseSprite[GameManager.instance.NumberCount - 1];
         audioHolder = GameObject.FindWithTag("audio");
         conveyorBelt = audioHolder.GetComponent<AudioSource>();
         conveyorBelt.Play(0);
    }

    void Update()
    {
        awayPos = transform.position;
        awayPos.y += 2 * Time.deltaTime;
        transform.position = awayPos;
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == 10)
        {
            Debug.Log("Destroyed Out!");
            if (GameManager.buttonPressable)
            {
                conveyorBelt.Stop();
            }
            Destroy(this.gameObject);
        }
    }
}
