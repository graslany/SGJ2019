using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Narration : MonoBehaviour {

	public AudioMixer Mixer;	
	public AudioClip[] narrations;
	public AudioSource narrationSource;

	// Use this for initialization
	void Start () {
		PlayNarration(0);
	}
	
	private void PlayNarration(int track)
	{
		if (narrationSource.clip != null)
		{
			narrationSource.Stop();
		}
		narrationSource.clip = narrations[track];
		narrationSource.Play();
		
	}
	
	public void TellStory(string story) // hard coded otherwise it's too clean
	{
		switch(story){
			case "clef":
				// PlayNarration(1);
				break;
			case "porte":
				PlayNarration(2);
				break;
			// default:
			//	Debug.Log("No narration corresponding");
		}
	}
	
}
