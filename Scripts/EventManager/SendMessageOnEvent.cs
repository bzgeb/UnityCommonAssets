using UnityEngine;
using System.Collections;

public class SendMessageOnEvent : MonoBehaviour 
{
    public Events eventName;
    public GameObject target;
    public string message;

    void OnEnable() {
        EventManager.Register( eventName.ToString(), OnEvent );
    }

    void OnDisable() {
        EventManager.Deregister( eventName.ToString(), OnEvent );
    }

    void OnEvent( params object[] args ) {
        if ( target != null ) {
            target.SendMessage( message );
        } else {
            SendMessage( message );
        }
    }
}
