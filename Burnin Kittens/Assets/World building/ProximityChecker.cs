using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProximityChecker : MonoBehaviour {

	[Tooltip("The layer(s) on which objects are looked up")]
	public List<int> layers;

	// The child transforms are looked up at startup and considered direction to which
	// rays should be cast.
	private List<Transform> checkPoints;
	
	// Get any object that is close to this object on the proper layer(s).
	public bool HasAnyCloseObject () {
		return GetCloseObjects().Any();
	}

	public List<Transform> GetCloseObjects () {
		int layerMask = layers.
			Select(layerIndex => 1 << layerIndex).
			Aggregate((mask, bit) => mask & bit);
		return checkPoints.
			SelectMany(t => Physics2D.LinecastAll(transform.position, t.position, layerMask)).
			Select(h => h.transform).
			Distinct().
			ToList();
	}

	protected virtual void Start () {
		checkPoints = GetComponentsInChildren<Transform>().Where(t => t != transform).ToList();
	}
}
