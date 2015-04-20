using UnityEngine;
using System.Collections;

public class AnimatorInterpolator : MonoBehaviour {
    public Animator animator;
    public Interpolator interpolator;
    public string stateName;
    public int layer;

    void Start() {
        if ( animator == null ) {
            Debug.LogError( "No animator found" );
            enabled = false;
        }
    }

    void SampleAnimation() {
        animator.Play( stateName, layer, interpolator.Value );
    }

    void Update() {
        SampleAnimation();
    }
}
