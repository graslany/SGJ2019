using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraumaticCameraDriver : MonoBehaviour {

	public Camera targetCamera;
	public Bob myLittleBob;
	public float characterYRelPosition = 0.25f;

	private float baseCameraSize;
	private Quaternion baseCameraAngle;
	private float currentStress;
	private float stressIncreaseRate = 0.2f;
	private float stressDecreaseRate = 0.8f;
	private float stressToSizeDeltaRatio = -0.4f;
	private float stressToAngleDeltaRatio = 0.45f;

	// Use this for initialization
	void Start () {
		targetCamera = targetCamera ?? GetComponent<Camera>();
		baseCameraSize = targetCamera.orthographicSize;
		baseCameraAngle = targetCamera.transform.localRotation;
		currentStress = 0;
	}
	
	// Update is called once per frame
	void Update () {
		// Position the camera
		Vector3 myPosition = transform.position;
		Vector3 targetPosition = myLittleBob.transform.position;
		myPosition.x = targetPosition.x;
		float targetYPos = targetPosition.y;
		float camYPos = targetYPos + (1 - 2*characterYRelPosition)*targetCamera.orthographicSize;
		myPosition.y = camYPos;
		transform.position = myPosition;

		// Update the stress value
		float targetStressValue = myLittleBob.GetStressValueForKind(StressKind.CameraTwister);
		float stressDelta = targetStressValue - currentStress;
		float stressChangeRate = Mathf.Sign(stressDelta) > 0 ? stressIncreaseRate : stressDecreaseRate;
		if (stressDelta != 0 && Mathf.Abs(stressDelta) > stressChangeRate * Time.deltaTime)
			currentStress += Mathf.Sign(stressDelta) * stressChangeRate * Time.deltaTime;
		else
			currentStress = targetStressValue;

		// Update the size and rotation of the camera
		GetComponent<Camera>().orthographicSize = baseCameraSize + stressToSizeDeltaRatio * currentStress;
		GetComponent<Camera>().transform.localRotation = baseCameraAngle * Quaternion.Euler(0, 0, stressToAngleDeltaRatio * currentStress);
	}
}
