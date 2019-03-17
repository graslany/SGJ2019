using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraumaticCameraDriver : BobStressResponse {

	public Camera targetCamera;
	public float characterYRelPosition = 0.25f;

	private float baseCameraSize;
	private Quaternion baseCameraAngle;
	private float stressToSizeDeltaRatio = -0.55f;
	private float stressToAngleDeltaRatio = 0.45f;

	// Use this for initialization
	protected override void Start () {
		base.Start();
		targetCamera = targetCamera ?? GetComponent<Camera>();
		baseCameraSize = targetCamera.orthographicSize;
		baseCameraAngle = targetCamera.transform.localRotation;
	}
	
	protected override void UpdateGivenStress(Bob bob, float stressValue) {

		// Position the camera
		Vector3 camPosition = targetCamera.transform.position;
		Vector3 targetPosition = bob.transform.position;
		camPosition.x = targetPosition.x;
		float targetYPos = targetPosition.y;
		float camYPos = targetYPos + (1 - 2*characterYRelPosition)*targetCamera.orthographicSize;
		camPosition.y = camYPos;
		targetCamera.transform.position = camPosition;

		// Update the size and rotation of the camera
		targetCamera.orthographicSize = baseCameraSize + stressToSizeDeltaRatio * stressValue;
		targetCamera.transform.localRotation = baseCameraAngle * Quaternion.Euler(0, 0, stressToAngleDeltaRatio * stressValue);
	}
}
