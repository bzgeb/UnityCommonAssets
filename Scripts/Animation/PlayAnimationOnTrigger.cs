using UnityEngine;
using System.Collections;

public class PlayAnimationOnTrigger : MonoBehaviour {
    public bool playOnlyOnce = false;
    bool played;

    void OnTriggerEnter( Collider other ) {
        if ( !playOnlyOnce ) {
            animation.Play();
        } else if ( !played ) {
            animation.Play();
            played = true;
        }
    }
}
