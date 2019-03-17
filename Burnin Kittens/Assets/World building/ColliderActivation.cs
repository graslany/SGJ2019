using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderActivation : MonoBehaviour {

	public enum ActionOnCollision {
		MakeOtherPlainCollider,
		MakeOtherTrigger
	}

	public Collider2D target;
	public ActionOnCollision action;

	// Use this for initialization
	protected virtual void OnTriggerEnter2D() {
		switch(action) {
			case ActionOnCollision.MakeOtherPlainCollider:
				target.isTrigger = false;
				break;
			case ActionOnCollision.MakeOtherTrigger:
				target.isTrigger = true;
				break;
			default:
				throw new ArgumentException("Unexpected action kind");
		}
	}
}
