using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow_Yaxis : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;


    
 // Update is called once per frame
 void Update() 
 {
      Vector3 position = transform.position ;
      //this the line of code that makes the player only move up
      position.y = (player.position + offset).y;
      transform.position = position ;
 }
}
