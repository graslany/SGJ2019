using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public GameObject mainMenuUI;
	public GameObject creditsUI;
	
	public void DisplayMainMenu() {
		mainMenuUI.SetActive(true);
		creditsUI.SetActive(false);
	}
	
	public void DisplayCredits() {
		mainMenuUI.SetActive(false);
		creditsUI.SetActive(true);
	}
	
	public void LaunchGame() {
		mainMenuUI.SetActive(false);
		SceneManager.LoadScene("House");
	}
	
	public void QuitGame() {
		Application.Quit();
	}

	protected virtual void Start () {
		DisplayMainMenu();
	}
}
