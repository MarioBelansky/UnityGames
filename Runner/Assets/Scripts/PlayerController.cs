using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip yes; // zvuk, ktorý v editore definujeme pre yes
    public AudioClip no;  // zvuk, ktorý v editore definujeme pre no
    private AudioSource source; // prvok, ktorý umožní prehranie
	

    public GameControlScript control;

    CharacterController controller; // potrebujeme kvôli zmene polohy playera
    public float speed = 8.0f; // rýchlosť pohybu do strán
    private Vector3 moveDirection = Vector3.zero; // veľkosť pohybu
    // Start is called before the first frame update
    void Start()
    {
    controller = GetComponent<CharacterController>(); 
    source = GetComponent<AudioSource> (); // získame audiosorce z aktuálneho GameObjectu
    controller = GetComponent<CharacterController>(); // získame controller playera
    }

    // Update is called once per frame
    void Update()
    {
    // prečítame vstup v vpravo-vľavo
    moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);  
    moveDirection = moveDirection * speed;  // zväčšíme vektor posunu speed-krát
    // fyzika = objekt sa posunie v danom smere a podľa času
    controller.Move(moveDirection * Time.deltaTime);   
    }

    void OnTriggerEnter(Collider other)	{  
    if (other.gameObject.name == "PowerUp(Clone)") {
    control.PowerupCollected ();
    source.PlayOneShot(yes,1f);
    }
    if(other.gameObject.name == "Obstacle(Clone)") {
     control.ObstacleCollected();
    source.PlayOneShot(no,1f); // prehrá zvuk s danou silou sila je 0-1
    }
    Destroy(other.gameObject);	
    }

}
