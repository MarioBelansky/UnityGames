using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour {
 public GameObject cnvMain;     // pre pristup k canvasu s hlavnym menu
 public GameObject cnvSettings; // pre pristup k canvasu s nastaveniami

  public TMP_InputField timer1;
  public TMP_InputField score1;

  public TMP_InputField timer2;
  public TMP_InputField score2;

  public TMP_InputField timer3;
  public TMP_InputField score3;

  

 public void StartGame() {
  SceneManager.LoadScene("level1");
 }

 public void GameOver() {
  // funguje len vo vybuildovanej aplik�cii
  Application.Quit (); 
  Debug.Log("Hra skon�ila");
}

 public void ShowSettings() { // nastav�me pre udalos� kliknutia v main menu
	cnvMain.gameObject.SetActive(false);
	cnvSettings.gameObject.SetActive(true);
 }
 
 public void ShowMain() {// nastav�me pre kliknutie na zru�i� v menu Nastaven�
	cnvMain.gameObject.SetActive(true);
	cnvSettings.gameObject.SetActive(false);
 }

 public void SaveAndCloseSettings() {
 float music = GameObject.Find("MusicSlider").GetComponent<Slider>().value;
 PlayerPrefs.SetFloat("music", music);
 float effects = GameObject.Find("EffectsSlider").GetComponent<Slider>().value;
 PlayerPrefs.SetFloat("effect", effects);
 float spawner = GameObject.Find("GenSpeedSlider").GetComponent<Slider>().value;
 PlayerPrefs.SetFloat("spawner", spawner);

  string t1 = timer1.text;
  string s1 = score1.text;
 PlayerPrefs.SetFloat("time1", float.Parse(t1));
 PlayerPrefs.SetFloat("score1", float.Parse(s1)); 
  string t2 = timer2.text;
  string s2 = score2.text;
 PlayerPrefs.SetFloat("time2", float.Parse(t2));
 PlayerPrefs.SetFloat("score2", float.Parse(s2));
  string t3 = timer3.text;
  string s3 = score3.text;
 PlayerPrefs.SetFloat("time3", float.Parse(t3));
 PlayerPrefs.SetFloat("score3", float.Parse(s3));
 ShowMain ();
}

}