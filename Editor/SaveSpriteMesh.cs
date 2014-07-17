using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class SaveSpriteMesh : ScriptableWizard 
{
    public Sprite sprite;

    [MenuItem("GameObject/Get Sprite Mesh")]
    static void CreateWizard() {
        ScriptableWizard.DisplayWizard<SaveSpriteMesh>("Get Sprite Mesh", "Save");
    }

    void OnWizardCreate() {
        Vector2[] spriteVerts = UnityEditor.Sprites.DataUtility.GetSpriteMesh( sprite, false );
        ushort[] spriteIndices = UnityEditor.Sprites.DataUtility.GetSpriteIndices( sprite, false );

        List<Vector3> meshVerts = new List<Vector3>();
        List<int> meshIndices = new List<int>();


        foreach( Vector2 v2 in spriteVerts ) {
            meshVerts.Add( new Vector3( v2.x, v2.y, 0 ) );
        }

        foreach( ushort indice in spriteIndices ) {
            meshIndices.Add( (int)indice );
        }

        Mesh spriteMesh = new Mesh();
        spriteMesh.vertices = meshVerts.ToArray();
        spriteMesh.triangles = meshIndices.ToArray();

        AssetDatabase.CreateAsset( spriteMesh, AssetDatabase.GenerateUniqueAssetPath( "Assets/" + sprite.name + ".asset" ) );
        AssetDatabase.SaveAssets();
    }
}
