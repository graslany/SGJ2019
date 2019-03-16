using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpammableObject : MonoBehaviour, IInteractible {

	[Tooltip("How fast the spam level decrease (per second)")]
	public float spamDecayRate = 2.0f;

	[Tooltip("Does the spam level peeks at a certain level ?")]
	public float spamMaxValue = float.MaxValue;

	[Tooltip("Current spam level")]
	public float currentSpamLevel = 0;

	public void OnInteractedBy(GameObject source) {
		currentSpamLevel++;
		if (currentSpamLevel > spamMaxValue) {
			currentSpamLevel = spamMaxValue;
		}
		OnSpamUpdate();
	}
	
	protected virtual void Update () {

		// Spam decreases continuously, does not go below zero.
		currentSpamLevel -= Time.deltaTime * spamDecayRate;
		currentSpamLevel = Mathf.Max(0, currentSpamLevel);
	}

	protected virtual void OnSpamUpdate() {}
}
