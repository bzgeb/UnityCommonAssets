using UnityEngine;
using System.Collections;

public class PlayAnimationOnCollider : MonoBehaviour {
    public bool playOnlyOnce = false;
    bool played = false;
    
    public void OnCollisionEnter( Collision collision ) {
        if ( !playOnlyOnce ) {
            animation.Play();
        } else if ( !played ) {
            animation.Play();
            played = true;
        }
    }
}
