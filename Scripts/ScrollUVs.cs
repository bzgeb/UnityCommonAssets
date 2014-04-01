using UnityEngine;
using System.Collections;

public class ScrollUVs : MonoBehaviour
{
    public float USpeed;
    public float VSpeed;
    public Material mat;

    Vector2 offset;

    void Awake() {
        offset = new Vector2( 0, 0 );
    }

    void Update() {
        offset.x = offset.x + (USpeed * Time.deltaTime) % 1.0f;
        offset.y = offset.y + (VSpeed * Time.deltaTime) % 1.0f;
        mat.SetTextureOffset( "_MainTex", offset );
    }

    void OnDisable() {
        mat.SetTextureOffset( "_MainTex", Vector2.zero );
    }
}
