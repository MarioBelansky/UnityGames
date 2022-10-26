using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour {
 public int scoreAmount = 0; // nastavenia pre jednotlivé typy
 public float timeAmount = 0.0f;
 public GameObject explosionPrefab; // dorobíme výbuch po zásahu

 void Start() { 
 if (gameObject.tag == "TargetNegative") {
     scoreAmount = (int)PlayerPrefs.GetFloat ("score1");	
     timeAmount = PlayerPrefs.GetFloat ("time1");	
   }

   if (gameObject.tag == "TargetPositive") {
     scoreAmount = (int)PlayerPrefs.GetFloat ("score2");	
     timeAmount = PlayerPrefs.GetFloat ("time2");	
   }

   if (gameObject.tag == "TargetTime") {
     scoreAmount = (int)PlayerPrefs.GetFloat ("score3");	
     timeAmount = PlayerPrefs.GetFloat ("time3");	
   }
}

 
 void OnCollisionEnter (Collision newCollision) {// pri kolízii s inými objektami
 // ak sa zrazil s projektilom
   if (newCollision.gameObject.tag == "Projectile") {
    if (explosionPrefab) { // ak je definovany vybuch, vytvor ho
	Instantiate (explosionPrefab, transform.position, transform.rotation);
    GameManager.gm.ChangeScoreTime(scoreAmount, timeAmount);
    Destroy (newCollision.gameObject); // znic projektil
    Destroy (gameObject); // znic seba – target
  }
 }
} }
