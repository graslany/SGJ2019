using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowProjector : MonoBehaviour {

	[Tooltip("Projection direction, in the projected object's space.")]
	public Vector3 localDirection = new Vector3(0, -1, 0);
	public float maxDistance = 1000;
	public int layerMask = -1;
	public Transform projectedTransform;

	// Original local position relative to the parent
	private Vector3 originalLocalPosition;

	protected virtual void Start() {
		originalLocalPosition = projectedTransform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 raycastSource = projectedTransform.parent.TransformPoint(originalLocalPosition);
		Vector3 raycastDirection = projectedTransform.TransformDirection(localDirection);
		var result = Physics2D.Raycast(raycastSource, raycastDirection, maxDistance, layerMask);
		if (result.collider != null) {
			projectedTransform.position = result.point;
		}
		else
			projectedTransform.position = raycastSource + maxDistance * raycastDirection;
	}
}
