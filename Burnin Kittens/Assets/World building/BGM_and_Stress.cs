using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BGM_and_Stress : BobStressResponse {
	
	public AudioMixer Mixer;
	
	protected override void Start () {
		base.Start();
		Mixer.SetFloat("BGM_Volume", 0);
		Mixer.SetFloat("Oppression_Volume", -80);
	}
	
	protected override void UpdateGivenStress(Bob bob, float stressValue) {
				
		float sliderOppressed = Mathf.Clamp(((stressValue - 0.5f) / 10), 0, 1);
		float volumeOppressed = 20f * Mathf.Log10(sliderOppressed);
		float volumeStreet = 20f * Mathf.Log10(1 - sliderOppressed);
		
		Mixer.SetFloat("BGM_Volume", volumeStreet);
		Mixer.SetFloat("Oppression_Volume", volumeOppressed);
	}
}
