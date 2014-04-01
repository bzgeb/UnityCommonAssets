using UnityEngine;
using UnityEditor;
using System.Collections;

public class RenderQueueMaterialInspector : MaterialEditor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        Material targetMat = target as Material;
        int renderQueue = targetMat.renderQueue;
        renderQueue = EditorGUILayout.IntField( "Render Queue", renderQueue );
        targetMat.renderQueue = renderQueue;
    }
}
