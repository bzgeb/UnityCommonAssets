using UnityEngine;
using System.Collections;

public class PlaySoundOnTrigger : MonoBehaviour {
    public bool playOnlyOnce = false;
    bool played = false;

    public void OnTriggerEnter( Collider other ) {
        if ( !playOnlyOnce ) {
            GetComponent<AudioSource>().Play();
        } else if ( !played ) {
            GetComponent<AudioSource>().Play();
            played = true;
        }
    }
}
