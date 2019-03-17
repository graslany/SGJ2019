using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public GameObject mainMenuUI;
	public GameObject creditsUI;
	
	public void DisplayMainMenu() {
		SafeSetActive(mainMenuUI, true);
		SafeSetActive(creditsUI, false);
	}
	
	public void DisplayCredits() {
		SafeSetActive(mainMenuUI, false);
		SafeSetActive(creditsUI, true);
	}
	
	public void LaunchGame() {
		mainMenuUI.SetActive(false);
		SceneManager.LoadScene("House");
	}
	
	public void QuitGame() {
		Application.Quit();
	}
	
	public void GoToMainMenu() {
		SceneManager.LoadScene("Start");
	}

	protected virtual void Start () {
		DisplayMainMenu();
	}
	
	private void SafeSetActive(GameObject someObject, bool value) {
		if (someObject != null)
		try {
			someObject.SetActive(value);
		}
		catch { }
	}
}
