using UnityEngine;
using System.Collections;

public class PlaySoundOnTrigger : MonoBehaviour {
    public bool playOnlyOnce = false;
    bool played = false;

    public void OnTriggerEnter( Collider other ) {
        if ( !played ) {
            audio.Play();
            played = true;
        }
    }
}
