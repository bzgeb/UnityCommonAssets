using UnityEngine;
using System.Collections;

public class PlayAnimationOnCollider : MonoBehaviour {
    public bool playOnlyOnce = false;
    bool played = false;
    
    public void OnCollisionEnter( Collision collision ) {
        if ( !playOnlyOnce ) {
            GetComponent<Animation>().Play();
        } else if ( !played ) {
            GetComponent<Animation>().Play();
            played = true;
        }
    }
}
