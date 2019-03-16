using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TmpNavFromHouse : MonoBehaviour {

	protected void Awake () {
		SceneManager.LoadScene("Street");
	}
}
