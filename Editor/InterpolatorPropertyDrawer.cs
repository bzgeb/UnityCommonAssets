using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer(typeof(Interpolator))]
public class InterpolatorPropertyDrawer : PropertyDrawer {
    public override void OnGUI( Rect position, SerializedProperty prop, GUIContent label ) {
        string description = "None";
        if ( prop.objectReferenceValue != null ) {
            description = (prop.objectReferenceValue as Interpolator).description;
        }

        EditorGUI.BeginProperty( position, label, prop );
        GUIStyle headerStyle = new GUIStyle( EditorStyles.label );
        headerStyle.fontStyle = FontStyle.Bold;
        EditorGUI.LabelField( new Rect( position.x, position.y + 4, position.width, 16 ), prop.displayName, headerStyle );

        GUIStyle labelStyle = new GUIStyle( EditorStyles.label );
        labelStyle.fontStyle = FontStyle.Italic;
        EditorGUI.LabelField( new Rect( position.x, position.y + 20, 110, 16 ), description, labelStyle );
        prop.objectReferenceValue = EditorGUI.ObjectField( new Rect( position.x + 120, position.y + 20, 120, 16 ), prop.objectReferenceValue, typeof( Interpolator ), true );

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight( SerializedProperty property, GUIContent label ) {
        return 36;
    }
}
