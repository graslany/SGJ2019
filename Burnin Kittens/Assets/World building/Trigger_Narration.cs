﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Narration : MonoBehaviour {

	public Narration Narrateur;
	public 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D collision)
	{
		Narrateur.TellStory(gameObject.name);
		Destroy(gameObject);
	}
}
