using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamDoor: SpammableObject {

	public SpriteRenderer targetRenderer;

	private bool reachedMaxSpam = false;

	// The frigging raycast won't work and it's 5 a.m... f*ck it!
	public static List<SpamDoor> dirtyGlobalField = new List<SpamDoor>();

	protected virtual void Awake() {
		dirtyGlobalField.Add(this);
	}

	protected virtual void OnDestroy() {
		dirtyGlobalField.Remove(this);
	}

	protected override void OnSpamUpdate () {
		if (!reachedMaxSpam) {
			if (currentSpamLevel < spamMaxValue) {
				var x = targetRenderer.material.color;
				x.a =  (spamMaxValue - currentSpamLevel) / spamMaxValue;
				targetRenderer.material.color = x;
			} else {
				Destroy(gameObject);
				reachedMaxSpam = true;
			}
		}
	}

	protected override void Update() {
		base.Update();
		
		var x = targetRenderer.material.color;
		x.a =  (spamMaxValue - currentSpamLevel) / spamMaxValue;
		targetRenderer.material.color = x;
	}
}
