using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class CameraMover : MonoBehaviour 
{
      public Transform target;
      private Vector3 offset;

    private void Start(){
        offset = transform.position;
    }
      void Update() 
      {
          //Vector3 pos = ball.transform.position;
          //transform.position = pos;

          transform.position = new Vector3 (target.position.x + offset.x, target.position.y + offset.y, target.position.z + offset.z);
      }
  }