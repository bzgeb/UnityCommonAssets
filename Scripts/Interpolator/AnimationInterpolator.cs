using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animation))]
public class AnimationInterpolator : MonoBehaviour 
{
    AnimationState animationState;

    public bool normalize;
    public Interpolator interpolator;

    void Start() {
        GetComponent<Animation>().enabled = false;
        animationState = GetComponent<Animation>()[GetComponent<Animation>().clip.name];
    }

    void SampleAnimation() {
        animationState.enabled = true;
        animationState.weight = 1;
        if ( normalize ) {
            animationState.normalizedTime = interpolator.NormalizedValue;
        } else {
            animationState.time = interpolator.Value;
        }
        GetComponent<Animation>().Sample();
        animationState.enabled = false; 
    }

    void Update() {
        SampleAnimation();
    }
}
