using UnityEngine;
using System.Collections;
using System;

public class MonoBehaviourBase : MonoBehaviour {
    // public void Invoke(Action task, float time) {
    //    Invoke(task.Method.Name, time);
    // }

    IEnumerator Timer( Action task, float time ) {
        yield return new WaitForSeconds( time );

        task();
    }

    IEnumerator FrameTimer( Action task, int frames ) {
        int elapsedFrames = 0;
        while ( elapsedFrames < frames ) {
            yield return null;
            ++elapsedFrames;
        }

        task();
    }

    public void DelayedExecute( Action task, float time ) {
        StartCoroutine( Timer( task, time ) );
    }

    public void DelayedExecuteFrames( Action task, int frames ) {
        StartCoroutine( FrameTimer( task, frames ) );
    }

    public Action ToggleGameObject( bool enable ) {
        return () => {
            gameObject.SetActive( enable );
        };
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
