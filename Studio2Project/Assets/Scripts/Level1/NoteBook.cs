using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBook : MonoBehaviour
{
   public GameObject notebook;
   private BoxCollider2D boxCol;

   private void Start()
   {
      boxCol = GetComponent<BoxCollider2D>();
   }

   private void OnMouseDown()
   {
         Instantiate(notebook);
   }
}