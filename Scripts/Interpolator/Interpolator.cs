using UnityEngine;
using System.Collections;
using System;

public class Interpolator : MonoBehaviour 
{
    public float val;
    public float Value {
        get {
            return val;
        }
        set {
            val = value;
        }
    }

    public float NormalizedValue {
        get {
            return val / maxValue;
        }
        set {
            val = value;
        }
    }
    public string description;

    bool interpolating;
    SmoothingData smoothingData;
    Func<SmoothingData, float> smoothing;

    public float maxValue;

    public void GoTo( SmoothingData data, Func<SmoothingData, float> smoothingFunc ) {
        interpolating = true;
        smoothingData = data;
        smoothing = smoothingFunc;
    }

    void FixedUpdate() {
        if ( Mathf.Approximately( Value, smoothingData.target ) ) {
            interpolating = false;
        }

        if ( interpolating ) {
            smoothingData.value = Value;
            Value = smoothing( smoothingData );
        }
    }
}
