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
		
	}
	
	private void PlayNarration(int track)
	{
		if (narrations[track] != null)
		{
			if (narrationSource.clip != null)
			{
				narrationSource.Stop();
			}
			narrationSource.clip = narrations[track];
			narrationSource.Play();
		}
	}
	
	public void TellStory(string story) // hard coded otherwise it's too clean
	{
		switch(story){
			case "Trigger_00":
				PlayNarration(0);
				break;
			case "Trigger_01":
				PlayNarration(1);
				break;
			case "Trigger_02":
				PlayNarration(2);
				break;
			// default:
			//	Debug.Log("No narration corresponding");
		}
	}
	
}
