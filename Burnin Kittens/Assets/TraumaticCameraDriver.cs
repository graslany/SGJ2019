using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraumaticCameraDriver : MonoBehaviour {

	public Bob myLittleBob;
	public float baseCameraSize;
	public Quaternion baseCameraAngle;

	private float currentStress;
	private float stressIncreaseRate = 0.2f;
	private float stressDecreaseRate = 0.8f;
	private float stressToSizeDeltaRatio = -0.4f;
	private float stressToAngleDeltaRatio = 0.45f;

	// Use this for initialization
	void Start () {
		Camera cam = GetComponent<Camera>();
		baseCameraSize = cam.orthographicSize;
		baseCameraAngle = cam.transform.localRotation;
		currentStress = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 myPosition = transform.position;
		Vector3 targetPosition = myLittleBob.transform.position;
		myPosition.x = targetPosition.x;
		myPosition.y =targetPosition.y;
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
