using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class Bob : MonoBehaviour {

    // Careful: other scripts may access this before this one got a chance to run its awake.
    // This is why one should use the on-demand instanciation implemented by GetStressSources()
    private Dictionary<StressKind, HashSet<IStressSource>> _stressSources;

    public ProximityChecker proximityProbe;

    private static Bob _lastInstance;

    public static Bob FindInstance() {
        if (_lastInstance == null)
            _lastInstance = GameObject.FindObjectOfType<Bob>();
        return _lastInstance;
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
        return GetStressValuesForKind(kind).
            Where(s => s != null).
            Select(s => s.GetStressValue()).
            Sum();
    }

    internal void AddStressSource(IStressSource source, StressKind kind)
    {
        GetStressValuesForKind(kind).Add(source);
    }

    internal void RemoveStressSource(IStressSource source, StressKind kind)
    {
        GetStressValuesForKind(kind).Remove(source);
    }

    private HashSet<IStressSource> GetStressValuesForKind(StressKind kind) {
        HashSet<IStressSource> res = null;
        if (!GetStressSources().TryGetValue(kind, out res))
        {
            res = new HashSet<IStressSource>();
            GetStressSources()[kind] = res;
        }
        return res;
    }

    private Dictionary<StressKind, HashSet<IStressSource>> GetStressSources() {
        _stressSources = _stressSources ?? new Dictionary<StressKind, HashSet<IStressSource>>();
        return _stressSources;
    }
}
