using UnityEngine;
using System.Collections;

public class BobsRemoteControl : MonoBehaviour {

    public Transform interactionStart;
    public Transform interactionEnd;
    
    // Update is called once per frame
    protected virtual void Update () 
    {
			if (Input.GetButtonDown("Fire2")) {
				// TODO use Raycast, except they won't work for some reason.
        	foreach (var x in SpamDoor.dirtyGlobalField) {
						if ((x.transform.position - transform.position).magnitude < 1) {
							x.OnInteractedBy(this.gameObject);
						}
					}
			}
    }
}