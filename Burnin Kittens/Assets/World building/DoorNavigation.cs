using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DoorNavigation: MonoBehaviour {

    public string nextLevel;

	public void OnDoorOpened(SpamDoor sender) {
		SceneManager.LoadScene(nextLevel);
	}
}
