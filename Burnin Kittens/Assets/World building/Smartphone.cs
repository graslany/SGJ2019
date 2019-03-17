using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Smartphone : MonoBehaviour {

	public AudioClip confirm;
	public AudioSource confirmSource;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump"))
		{	
			confirmSource.clip = confirm;
			confirmSource.Play();
			SceneManager.LoadScene("House");
		}
	}
}
