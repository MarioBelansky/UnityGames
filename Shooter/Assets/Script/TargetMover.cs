using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMover : MonoBehaviour
{

 public enum motionDirections {Spin, Horizontal, Vertical};
	
 // definujeme ako v�chodiskov� stav horizont�lny pohyb
 public motionDirections motionState = motionDirections.Horizontal;

 // parametre pohybu 
 public float spinSpeed = 180.0f;		// rot�cia 180 stupnov za sekundu
 public float motionMagnitude = 0.1f;	// pohyb hore/dole


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update () {
  // zabezpe�uje sa pohyb pod�a vybran�ho typu
   switch(motionState) {
    case motionDirections.Vertical:
	 // pos�va sa hore/dole, pri�om polohu men� pod�a sinusoidy 	
	 gameObject.transform.Translate(Vector3.up * Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude);
	break;
    case motionDirections.Spin:
	// rotuje okolo osi y = Vector3.up gameObject-u
	gameObject.transform.Rotate (Vector3.up * spinSpeed * Time.deltaTime);
	break;
    case motionDirections.Horizontal:
	// pos�va sa doprava/do�ava, pri�om polohu men� pod�a sinusoidy
	gameObject.transform.Translate(Vector3.right * 
Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude);
	break;
    
   }
  }
}
