using UnityEngine;
using System.Collections;

public class BobsRemoteControl : MonoBehaviour {

    public ProximityChecker proximityProbe;
    
    // Update is called once per frame
    protected virtual void Update () 
    {
		if (Input.GetButtonDown("Fire2")) {
        	foreach (var x in proximityProbe.GetCloseObjects()) {
				IInteractible interactible = x.GetComponent<IInteractible>();
				if (interactible != null)
					interactible.OnInteractedBy(gameObject);
			}
		}
	}
}
