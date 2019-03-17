using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BobStressResponse : MonoBehaviour {

	private StressKind stressKind = StressKind.CameraTwister;

	private float currentStress;
	protected float stressIncreaseRate = 0.3f;
	protected float stressDecreaseRate = 0.8f;

	protected abstract StressKind GetStressKind();

	protected virtual void Awake () {
		stressKind = GetStressKind();
	}

	protected virtual void Start () {
		currentStress = 0;
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		Bob bob = Bob.FindInstance();

		// Update the stress value
		float targetStressValue = bob.GetStressValueForKind(stressKind);
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
