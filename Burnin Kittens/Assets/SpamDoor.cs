using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamDoor: SpammableObject {

	public SpriteRenderer targetRenderer;

	private bool hasReachedMaxStressProgress = false;

	private float highestStressProgress = 0f;

	private float totalStressCost = 5f;

	protected override void OnAcceptedBob (Bob bob) {

		// Change the door state
		if (!hasReachedMaxStressProgress) {
			float stressProgress;
			if (currentSpamLevel < spamMaxValue) {
				var doorColor = targetRenderer.material.color;
				stressProgress = currentSpamLevel / spamMaxValue;
				highestStressProgress = Mathf.Max(highestStressProgress, stressProgress);
				doorColor.a =  1 - stressProgress;
				targetRenderer.material.color = doorColor;
			} else {
				Destroy(gameObject);
				hasReachedMaxStressProgress = true;
				stressProgress = 0;
				highestStressProgress = 0;
			}

			// Notify Bob
			bob.SetStress(StressKind.CameraTwister, totalStressCost * highestStressProgress);
		}
	}

	protected override void Update() {
		base.Update();
		
		var x = targetRenderer.material.color;
		x.a =  (spamMaxValue - currentSpamLevel) / spamMaxValue;
		targetRenderer.material.color = x;
	}
}
