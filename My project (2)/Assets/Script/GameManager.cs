using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	
	public float time;
	public TMP_Text timeText;
	public TMP_Text scoreText;
	int score = 0;
    
	public static GameManager gm = null; // singleton
	
	 public void ChangeScoreTime(int sc, float t) {
  score += sc;
  time += t;
  scoreText.text = "Score: " + score.ToString ();
}
	
	
	void Awake() {
  if (gm == null) {
	gm = this;
	} // tu by mohla nasledovať kontrola či neexistuje inštancia, 
    // ktorá nie je tento objekt a ak áno deštrukcia...
				}
 
 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    time = time - Time.deltaTime;
 if (time <= 0)
 	GameOver ();
 timeText.text = time.ToString();
}

void GameOver() {
 Scene scene = SceneManager.GetActiveScene();
 SceneManager.LoadScene(scene.name);
}
}
