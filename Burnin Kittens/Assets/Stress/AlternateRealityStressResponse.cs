using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternateRealityStressResponse : BobStressResponse {

	public SpriteRenderer alternateGraphics;
	public float minStress = 0;
	public float maxStress = 100;

	protected override void Awake() {
		base.Awake();
		stressIncreaseRate = 100f;
		stressDecreaseRate = stressIncreaseRate;
	}

	protected override StressKind GetStressKind() {return StressKind.AlternateReality;}
	
	protected override void UpdateGivenStress(Bob bob, float stressValue) {
		float relativeStress = 0;
		if (maxStress > minStress)
			relativeStress = Mathf.Clamp01((stressValue - minStress) / (maxStress - minStress));
		Color c = alternateGraphics.color;
		c.a = relativeStress;
		alternateGraphics.color = c;
	}
}
