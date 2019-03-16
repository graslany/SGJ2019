using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamDoor: SpammableObject {

	public SpriteRenderer targetRenderer;

	private bool reachedMaxSpam = false;

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
