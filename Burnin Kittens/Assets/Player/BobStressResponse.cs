using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BobStressResponse : MonoBehaviour {

	private float currentStress;
	private float stressIncreaseRate = 0.3f;
	private float stressDecreaseRate = 0.8f;

	// Use this for initialization
	protected virtual void Start () {
		currentStress = 0;
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		Bob bob = Bob.FindInstance();

		// Update the stress value
		float targetStressValue = bob.GetStressValueForKind(StressKind.CameraTwister);
		float stressDelta = targetStressValue - currentStress;
		float stressChangeRate = Mathf.Sign(stressDelta) > 0 ? stressIncreaseRate : stressDecreaseRate;
		if (stressDelta != 0 && Mathf.Abs(stressDelta) > stressChangeRate * Time.deltaTime)
			currentStress += Mathf.Sign(stressDelta) * stressChangeRate * Time.deltaTime;
		else
			currentStress = targetStressValue;

		UpdateGivenStress(bob, currentStress);
	}

	protected abstract void UpdateGivenStress(Bob bob, float stressValue);
}
