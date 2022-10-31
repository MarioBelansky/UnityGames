using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGameObjects : MonoBehaviour
{
	
	// rozsahy pre umiestnenie
	private float secondsBetweenSpawning = 0.1f;
	public float xMinRange = -25.0f;
	public float xMaxRange = 25.0f;
	public float yMinRange = 8.0f;
	public float yMaxRange = 25.0f;
	public float zMinRange = -25.0f;
	public float zMaxRange = 25.0f;
        // zoznam objektov, ktoré sa budú vytvárať – naše prefaby
	public GameObject[] spawnObjects; 

	private float nextSpawnTime; // čas, kedy dôjde k vytvoreniu ďalšieho
	
    // Start is called before the first frame update
    void Start()
    {
		float value = PlayerPrefs.GetFloat("spawner");
		secondsBetweenSpawning = value/20;
		Debug.Log (secondsBetweenSpawning);

		nextSpawnTime = Time.time+secondsBetweenSpawning;
    }

    // Update is called once per frame
    void Update()
    {
       if (Time.time  >= nextSpawnTime) {
    MakeThingToSpawn();	// vytvor dáky objekt
    nextSpawnTime = Time.time + secondsBetweenSpawning; // vypočítaj ďalší čas
		}	 
    }
	
	void MakeThingToSpawn (){
 Vector3 spawnPosition;
 // definujú sa náhodné súradnice na všetkých osiach z definovaných rozsahov
 spawnPosition.x = Random.Range (xMinRange, xMaxRange);
 spawnPosition.y = Random.Range (yMinRange, yMaxRange);
 spawnPosition.z = Random.Range (zMinRange, zMaxRange);

 // určí sa náhodne poradové číslo objektu, ktorý sa má vytvoriť
 int objectToSpawn = Random.Range (0, spawnObjects.Length);

 // vytvorí sa objekt zo zoznamu objektov, ktoré definujeme v editore
 GameObject spawnedObject = Instantiate (spawnObjects [objectToSpawn],  
spawnPosition, transform.rotation) as GameObject;

 // make the parent the spawner so hierarchy doesn't get super messy 
 // = vkladá objekty v rámci hierarchie do spawnera
 spawnedObject.transform.parent = gameObject.transform;
	} 

}
