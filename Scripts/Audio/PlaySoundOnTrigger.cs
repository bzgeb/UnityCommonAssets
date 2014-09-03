using UnityEngine;
using System.Collections;

public class PlaySoundOnTrigger : MonoBehaviour {
    public bool playOnlyOnce = false;
    bool played = false;

    public void OnTriggerEnter( Collider other ) {
        if ( !playOnlyOnce ) {
            audio.Play();
        } else if ( !played ) {
            audio.Play();
            played = true;
        }
    }
}
