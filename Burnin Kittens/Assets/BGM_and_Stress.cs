using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BGM_and_Stress : MonoBehaviour {

	public Bob myLittleBob;
	
	public AudioMixer Mixer_Street;
	public AudioMixerSnapshot Street;

	private float m_TransitionToStreet; // duration of transition (in ms)
	
	private float currentStress; // gestion du stress (cf TraumaticCameraDriver)
	private float stressIncreaseRate = 0.2f;
	private float stressDecreaseRate = 0.8f;
	
	// Use this for initialization
	void Start () {
		m_TransitionToStreet = 1000;
		currentStress = 0;
		Street.TransitionTo(2000);
	}
	
	// Update is called once per frame
	void Update () {
		float targetStressValue = myLittleBob.GetStressValueForKind(StressKind.CameraTwister);
		float stressDelta = targetStressValue - currentStress;
		float stressChangeRate = Mathf.Sign(stressDelta) > 0 ? stressIncreaseRate : stressDecreaseRate;
		if (stressDelta != 0 && Mathf.Abs(stressDelta) > stressChangeRate * Time.deltaTime)
			currentStress += Mathf.Sign(stressDelta) * stressChangeRate * Time.deltaTime;
		else
			currentStress = targetStressValue;
				
		float sliderOppressed = Mathf.Clamp(((currentStress - 0.5f) / 10), 0, 1);
		// Debug.Log("sliderOppressed = " + sliderOppressed + "    currentStress = " + currentStress);
		float volumeOppressed = 20f * Mathf.Log10(sliderOppressed);
		float volumeStreet = 20f * Mathf.Log10(1 - sliderOppressed);
		//Debug.Log("volumeOppressed = " + volumeOppressed + "   volumeStreet = " + volumeStreet);
		
		Mixer_Street.SetFloat("BGM_Street_Volume", volumeStreet);
		Mixer_Street.SetFloat("Oppression_Volume", volumeOppressed);
	}
}
