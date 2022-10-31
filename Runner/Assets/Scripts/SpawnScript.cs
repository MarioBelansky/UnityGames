using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {
 // v editore definujeme objekty, ktoré sa budú vytvárať
 public GameObject obstacle;  
 public GameObject powerup;
 float timeElapsed = 0;  // čas, ktorý uplynul od vytvorenia posledného 
 float spawnCycle = 0.5f; // čas medzi vytvoreniami objektov
 bool spawnPowerup = true; // ktorý z objektov vytvárať, sú dva, vsadíme na T/F
	
 void Update () {
  timeElapsed += Time.deltaTime; // koľko času uplynulo od vytvorenia posledného
  if(timeElapsed > spawnCycle) { // už treba vytvoriť další?
    GameObject temp;
    // podľa nastavenia sa vytvorí objekt
    if(spawnPowerup) { temp = (GameObject)Instantiate(powerup);} 
                else { temp = (GameObject)Instantiate(obstacle);}
    // nastaví sa mu náhodná pozícia
    Vector3 pos = temp.transform.position;
    temp.transform.position = new Vector3(Random.Range(-3, 4), pos.y, pos.z);
    timeElapsed = 0; // čas sa vynuluje
    spawnPowerup = !spawnPowerup; // nastaví sa, že nový objekt bude iný
  }
 }
}
