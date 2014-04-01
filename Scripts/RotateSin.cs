using UnityEngine;
using System.Collections.Generic;

public class RotateSin : MonoBehaviour
{
    public Vector3 minRotation;
    public Vector3 maxRotation;
    public float rate;

    Transform _transform;

    void Update() {
        if ( _transform == null ) {
            _transform = GetComponent<Transform>();
        }
        float lerpValue = ( Mathf.Sin( Time.timeSinceLevelLoad * rate ) + 1 ) * 0.5f;

        Quaternion rotation = Quaternion.identity;
        rotation.eulerAngles = Vector3.Lerp( minRotation, maxRotation, lerpValue );
        _transform.rotation = rotation;
    }
}