using UnityEngine;
using System.Collections;

public struct SmoothingData {
    public float value;
    public float target;
    public float strength;

    public SmoothingData( float target = 0, float strength = 1, float value = 0 ) {
        this.target = target;
        this.strength = strength;
        this.value = value;
    }
}

static public class Smoothing 
{
    static public float Exponential( SmoothingData smoothingData ) {
        return smoothingData.value + ( smoothingData.target - smoothingData.value ) * 0.01f;
    }

    static public float LowPass( SmoothingData smoothingData ) {
        return smoothingData.value + ( smoothingData.target - smoothingData.value ) * smoothingData.strength;
    }
}
