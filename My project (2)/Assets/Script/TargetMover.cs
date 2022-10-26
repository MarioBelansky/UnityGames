using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMover : MonoBehaviour
{

 public enum motionDirections {Spin, Horizontal, Vertical};
	
 // definujeme ako východiskový stav horizontálny pohyb
 public motionDirections motionState = motionDirections.Horizontal;

 // parametre pohybu 
 public float spinSpeed = 180.0f;		// rotácia 180 stupnov za sekundu
 public float motionMagnitude = 0.1f;	// pohyb hore/dole


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update () {
  // zabezpeèuje sa pohyb pod¾a vybraného typu
   switch(motionState) {
    case motionDirections.Spin:
	// rotuje okolo osi y = Vector3.up gameObject-u
	gameObject.transform.Rotate (Vector3.up * spinSpeed * Time.deltaTime);
	break;
    case motionDirections.Horizontal:
	// posúva sa doprava/do¾ava, prièom polohu mení pod¾a sinusoidy
	gameObject.transform.Translate(Vector3.right * 
Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude);
	break;
    case motionDirections.Vertical:
	 // posúva sa hore/dole, prièom polohu mení pod¾a sinusoidy 	
	 gameObject.transform.Translate(Vector3.up * Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude);
	break;
   }
  }
}
