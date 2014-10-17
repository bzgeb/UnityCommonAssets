using UnityEngine;
using System.Collections;

public class OffsetUVs : MonoBehaviour
{
    public Material mat;
    public Vector2 offset;

    void Awake() {
        offset = new Vector2( 0, 0 );
    }

    void Update() {
        mat.SetTextureOffset( "_MainTex", offset );
    }

    void OnDisable() {
        mat.SetTextureOffset( "_MainTex", Vector2.zero );
    }
}
