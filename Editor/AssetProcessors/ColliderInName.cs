using UnityEngine;
using UnityEditor;
using System.Collections;

public class ColliderInName : AssetPostprocessor {
    void OnPostprocessModel( GameObject model ) {
        Apply( model.transform );
    }

    void Apply( Transform transform ) {
        if ( transform.name.ToLower().Contains( "collider" ) ) {
            transform.gameObject.AddComponent( typeof( MeshCollider ) );
        }

        foreach ( Transform child in transform ) {
            Apply( child );
        }
    }
}
