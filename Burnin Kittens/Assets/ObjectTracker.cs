using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTracker : MonoBehaviour {

	[System.Serializable]
	public class AxisConfig {
		public bool enable;
		public float minValue = float.MinValue;
		public float maxValue = float.MaxValue;
	}

	public Transform target;
	public AxisConfig xTracking;
	public AxisConfig yTracking;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null && (xTracking.enable || yTracking.enable)) {
			Vector3 myPosition = transform.position;
			Vector3 targetPosition = target.position;
			if (xTracking.enable)
				myPosition.x = Mathf.Clamp(targetPosition.x, xTracking.minValue, xTracking.maxValue);
			if (yTracking.enable)
				myPosition.y = Mathf.Clamp(targetPosition.y, yTracking.minValue, yTracking.maxValue);
			transform.position = myPosition;
		}
	}
}
