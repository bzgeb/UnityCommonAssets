using UnityEngine;
using System.Collections.Generic;

public class ScaleSin : MonoBehaviour
{
    public Vector3 minScale;
    public Vector3 maxScale;
    public float rate;

    Transform _transform;

    void Update() {
        if ( _transform == null ) {
            _transform = GetComponent<Transform>();
        }
        float lerpValue = ( Mathf.Sin( Time.timeSinceLevelLoad * rate ) + 1 ) * 0.5f;

        _transform.localScale = Vector3.Lerp( minScale, maxScale, lerpValue );
    }
}