using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamDoor: SpammableObject {

	public SpriteRenderer targetRenderer;

	private bool reachedMaxSpam = false;

	private float totalStressCost = 5f;

	protected override void OnAcceptedBob (Bob bob) {

		// Change the door state
		if (!reachedMaxSpam) {
			float stressProgress;
			if (currentSpamLevel < spamMaxValue) {
				var doorColor = targetRenderer.material.color;
				stressProgress = currentSpamLevel / spamMaxValue;
				doorColor.a =  1 - stressProgress;
				targetRenderer.material.color = doorColor;
			} else {
				Destroy(gameObject);
				reachedMaxSpam = true;
				stressProgress = 0;
			}

			// Notify Bob
			bob.SetStress(StressKind.CameraTwister, totalStressCost * stressProgress);
		}
	}

	protected override void Update() {
		base.Update();
		
		var x = targetRenderer.material.color;
		x.a =  (spamMaxValue - currentSpamLevel) / spamMaxValue;
		targetRenderer.material.color = x;
	}
}
