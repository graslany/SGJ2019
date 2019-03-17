using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class UIHintPresenter : MonoBehaviour {
    
    public SpriteRenderer target;
    public UIHint lastHint;

    protected virtual void OnTriggerEnter2D(Collider2D other) {
        var h = other.GetComponent<UIHint>();
        lastHint = h ?? lastHint;
    }

    protected virtual void Update() {
        if (lastHint != null && (lastHint.transform.position - transform.position).magnitude <= lastHint.maxDistance) {
            target.sprite = lastHint.hint;
        }
        else {
            target.sprite = null;
        }
    }
}
