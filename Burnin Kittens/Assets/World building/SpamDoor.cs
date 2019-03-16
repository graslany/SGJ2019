using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

public class SpamDoor: SpammableObject {

	[Serializable]
	public class DoorOpenedEvent: UnityEvent<SpamDoor> {}

	public SpriteRenderer targetRenderer;

	public DoorOpenedEvent DoorOpened;

	private bool hasReachedMaxStressProgress = false;

	private float highestStressProgress = 0f;

	private float totalStressCost = 5f;

	protected virtual void Awake() {
		// DoorOpened = new DoorOpenedEvent();
	}

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
				// Notify observer of this object that is is open.
				var d = DoorOpened;
				if (d != null) {
					try {
						d.Invoke(this);
					}
					catch (Exception e) {Debug.LogException(e);}
				}

					
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
