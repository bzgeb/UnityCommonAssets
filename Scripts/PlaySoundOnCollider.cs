using UnityEngine;
using System.Collections;

public class PlaySoundOnCollider : MonoBehaviour {
    public bool playOnlyOnce = false;
    bool played = false;
    
    public void OnCollisionEnter( Collision collision ) {
        if ( !played ) {
            audio.Play();
            played = true;
        }

    }
}
