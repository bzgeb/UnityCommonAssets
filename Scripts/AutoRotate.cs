using UnityEngine;
using System.Collections;

public class AutoRotate : MonoBehaviour {
    public Vector3 rotation;
    
    void Update () {
        transform.localRotation = transform.localRotation * Quaternion.Euler( rotation * Time.deltaTime );
    }
}
