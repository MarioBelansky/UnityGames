using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb; // komponent/súčasť riadiaci fyziku
    public int speed = 5;

void Start () {
    rb = GetComponent<Rigidbody> (); // získa komponent/odkaz na fyziku
}

void FixedUpdate() {
    // prečíta zmeny na vstupe
    float moveHorizontal = Input.GetAxis ("Horizontal"); 
    float moveVertical = Input.GetAxis ("Vertical");

    // vytvorí posuvný vektor
    Vector3 movement = new Vector3 (moveHorizontal * speed, 0.0f, moveVertical * speed);

    // vektor aplikuje na fyzikálny model - posunie sa
    rb.AddForce (movement);
 }
}
