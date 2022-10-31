using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
  public float moveSpeed = 3.0f; // rýchlosť pohybu
  public float gravity = 9.81f;  // gravitácia, aby dopadol ak je vo vzduchu
  private CharacterController myController; // definovaný char controller

  void Start () { // iniciujeme char. controller
   myController = gameObject.GetComponent<CharacterController>();
  }
	
  void Update () {
  // objekt sa posúva len horizontálne alebo vertikálne, prečítame z Input
  Vector3 movementZ = Input.GetAxis("Vertical") * Vector3.forward * moveSpeed * Time.deltaTime;
  Vector3 movementX = Input.GetAxis("Horizontal") * Vector3.right * moveSpeed * Time.deltaTime;
  // skombinuje získané hodnoty a vypočíta ako posunúť playera podľa nich
  Vector3 movement = transform.TransformDirection(movementZ+movementX);
 // použije gravitáciu (len na počiatočný dopad na zem)
  movement.y -= gravity * Time.deltaTime;
 // posunie hráča podľa vypočítaného posunu
  myController.Move(movement);
}
}