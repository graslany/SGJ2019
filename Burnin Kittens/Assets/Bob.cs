using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Bob : MonoBehaviour {

    private Dictionary<StressKind, float> stressValues;

    public ProximityChecker proximityProbe;
    
    protected virtual void Start () {
        stressValues = new Dictionary<StressKind, float>();
    }
    
    protected virtual void Update ()
    {
        if (Input.GetButtonDown("Fire2")) {
            foreach (var x in proximityProbe.GetCloseObjects()) {
                IInteractible interactible = x.GetComponent<IInteractible>();
                if (interactible != null)
                interactible.AcceptBob(this);
            }
        }
    }

    public float GetStressValueForKind(StressKind kind) {
        float res = 0;
        stressValues.TryGetValue(kind, out res);
        return res;
    }

    internal void SetStress(StressKind kind, float value)
    {
        stressValues[kind] = value;
    }
}
