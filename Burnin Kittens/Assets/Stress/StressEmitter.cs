using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressEmitter : MonoBehaviour, IStressSource {

	[Tooltip("Effect power depending on distance.")]
	public AnimationCurve falloffCurve;

	protected virtual void OnEnable() {
		Bob.FindInstance().AddStressSource(this, StressKind.AlternateReality);
	}

	protected virtual void OnDisable() {
		Bob myLittleBobby = Bob.FindInstance();
		if (myLittleBobby != null)
			myLittleBobby.RemoveStressSource(this, StressKind.CameraTwister);
	}

    public float GetStressValue()
    {
        Vector2 toBob = Bob.FindInstance().transform.position - transform.position;
        float distanceToBob = toBob.magnitude;
		return falloffCurve.Evaluate(distanceToBob);
    }
}
