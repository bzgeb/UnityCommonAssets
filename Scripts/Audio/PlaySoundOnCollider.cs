using UnityEngine;
using System.Collections;

public class PlaySoundOnCollider : MonoBehaviour {
    public bool playOnlyOnce = false;
    bool played = false;
    
    public void OnCollisionEnter( Collision collision ) {
        if ( !playOnlyOnce ) {
            GetComponent<AudioSource>().Play();
        } else if ( !played ) {
            GetComponent<AudioSource>().Play();
            played = true;
        }
    }
}
