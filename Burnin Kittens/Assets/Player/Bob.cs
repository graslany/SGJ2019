using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Bob : MonoBehaviour {

    private Dictionary<StressKind, float> stressValues;

    public ProximityChecker proximityProbe;

    private static Bob _lastInstance;

    public static Bob FindInstance() {
        if (_lastInstance == null)
            _lastInstance = GameObject.FindObjectOfType<Bob>();
        return _lastInstance;
    }
    
    protected virtual void Start () {
        stressValues = new Dictionary<StressKind, float>();
    }
    
    protected virtual void Update ()
    {
        if (Input.GetButtonDown("Activate")) {
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
