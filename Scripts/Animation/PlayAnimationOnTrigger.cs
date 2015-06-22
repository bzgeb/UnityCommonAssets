using UnityEngine;
using System.Collections;

public class PlayAnimationOnTrigger : MonoBehaviour {
    public bool playOnlyOnce = false;
    bool played;

    void OnTriggerEnter( Collider other ) {
        if ( !playOnlyOnce ) {
            GetComponent<Animation>().Play();
        } else if ( !played ) {
            GetComponent<Animation>().Play();
            played = true;
        }
    }
}
