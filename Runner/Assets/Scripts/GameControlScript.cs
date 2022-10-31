using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControlScript : MonoBehaviour {
 public float timeRemaining = 100; // startovaci cas
 public float timeExtension = 30f; // pridanie powerUp
 public float timeDeduction = 20f; // odobranie Obstacle 
 private float totalTimeElapsed = 0; // uplynuty cas
 public bool isGameOver = false; // ak je hra skoncena sprava sa system inak
	
 void Start(){
  Time.timeScale = 1;  // set the time scale to 1, to start the game world. 
                       // This is needed if you restart the game from the game over menu
 }
	
 void Update () { 
   if(isGameOver)	return; // ak skoncila hra, nic sa nedeje
   totalTimeElapsed += Time.deltaTime; // uplynuly cas sa zvacsuje
   timeRemaining -= Time.deltaTime; // cas sa zmensi
   if(timeRemaining <= 0) isGameOver = true; // ak cas vyprsal nastavi sa GameOver
 }
	
 public void PowerupCollected() {
   timeRemaining += timeExtension; // zber powerupu cas prida
 }
	
 public void ObstacleCollected() {
  timeRemaining -= timeDeduction; // zber obstaclu cas uberie
}
void OnGUI() {// volá sa pre tvorbu GUI niekedy aj častejšie ako update?
 if(!isGameOver) { // ine GUI pre beh a ine po skonceni
  GUI.Label(new Rect(10, 10, Screen.width/5, Screen.height/6),"TIME LEFT: " 
+((int)timeRemaining).ToString());
  } else	{
   Time.timeScale = 0; // set the timescale to zero so as to stop the game world
   GUI.Box(new Rect(Screen.width/4, Screen.height/4, Screen.width/2, Screen.height/2), 
"GAME OVER\nYOUR SCORE: "+(int)totalTimeElapsed);
   // restart the game on click
   if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+Screen.height/10+10, 
       Screen.width/2-20, Screen.height/10), "RESTART")){
	SceneManager.LoadScene("level1"); // spusti odznova akt. scenu
       }
   // load the main menu, which as of now has not been created, ale bude
   if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+2*Screen.height/10+10, 
       Screen.width/2-20, Screen.height/10), "MAIN MENU")){
	SceneManager.LoadScene("mainmenu");
       }
   // exit the game
   if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+3*Screen.height/10+10, 
       Screen.width/2-20, Screen.height/10), "EXIT GAME")){
	Application.Quit(); // The Exit button won't do any magic either, 
			 // because we are trying this in the editor. Don't worry, 
			 // it will work fine if you build this game and test
       }   }}

}
