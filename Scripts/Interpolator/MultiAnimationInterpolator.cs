using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animation))]
public class MultiAnimationInterpolator : MonoBehaviour 
{
    public AnimationClip[] animationClips;

    public int clipIndex;
    public bool normalize;
    public Interpolator interpolator;

    AnimationState animationState;

    void Start() {
        animation.enabled = false;

        if ( animationClips.Length != animation.GetClipCount() ) {
            Debug.LogError( "Number of clips don't match up, this is going to be a problem" );
        }
    }

    void SampleAnimation() {
        animationState = animation[animationClips[clipIndex].name];

        animationState.enabled = true;
        animationState.weight = 1;
        if ( normalize ) {
            animationState.normalizedTime = interpolator.NormalizedValue;
        } else {
            animationState.time = interpolator.Value;
        }
        animation.Sample();
        animationState.enabled = false; 
    }

    void Update() {
        SampleAnimation();
    }
}
