﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleRelay: MonoBehaviour, IInteractible {

	public GameObject target;

	public void AcceptBob(Bob source) {
		if (enabled) {
			IInteractible realTarget = target != null ? target.GetComponent<IInteractible>() : null;
			if (realTarget != null)
				realTarget.AcceptBob(source);
			else
				Debug.LogWarning("No target available to relay the call.");
		}
	}
}
