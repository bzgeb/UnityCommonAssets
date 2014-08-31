using UnityEngine;
using System.Collections;

public class MonoBehaviourBase : MonoBehaviour {
    public delegate void Task();

    public void Invoke(Task task, float time) {
       Invoke(task.Method.Name, time);
    }

    static public Transform FindInChildren( Transform t, string name ) {
        Transform r = null;

        foreach ( Transform child in t ) {
            if ( child.name.ToLower() == name.ToLower() ) {
                r = child;
                break;
            }
        }

        if ( r == null ) {
            foreach ( Transform child in t ) {
                r = FindInChildren( child, name );
                if ( r != null ) {
                    break;
                }
            }
        }

        return r;
    }

    static public void SetLayerRecursively( GameObject go, int layer ) {
        go.layer = layer;
        foreach ( Transform t in go.transform ) {
            SetLayerRecursively( t.gameObject, layer );
        }
    }
}
