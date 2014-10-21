#if UNITY_EDITOR

using System;
using UnityEngine;
using UnityEditor;

public class MinMaxSlider : PropertyAttribute {

    public readonly float max;
    public readonly float min;

    public MinMaxSlider (float min, float max) {
        this.min = min;
        this.max = max;
    }
}

[CustomPropertyDrawer(typeof (MinMaxSlider))]
public class MinMaxSliderDrawer : PropertyDrawer {
    
    public override void OnGUI( Rect position, SerializedProperty property, GUIContent label ) {

        if ( property.propertyType == SerializedPropertyType.Vector2 ) {

            Vector2 range = property.vector2Value;
            float min = range.x;
            float max = range.y;
            MinMaxSlider attr = attribute as MinMaxSlider;
            label.tooltip = string.Format ("{0}, {1}", min, max);
            EditorGUI.BeginChangeCheck ();
            EditorGUI.MinMaxSlider( label, position, ref min, ref max, attr.min, attr.max );

            position.xMin += EditorGUIUtility.labelWidth;
            position.yMin += EditorGUIUtility.singleLineHeight - EditorGUIUtility.standardVerticalSpacing;

            var fullWidth = position.width;
            var span = attr.max - attr.min;
            var minPos = fullWidth * (min - attr.min) / span;
            var maxPos = fullWidth * (max - attr.min) / span;

            position.xMin += minPos;
            position.width = maxPos - minPos;

            var style = new GUIStyle(EditorStyles.miniLabel);
            style.alignment = TextAnchor.UpperLeft;
            EditorGUI.LabelField(position, min.ToString("0.00"), style);
            style.alignment = TextAnchor.UpperRight;
            EditorGUI.LabelField(position, max.ToString("0.00"), style);

            if (EditorGUI.EndChangeCheck ()) {
                range.x = min;
                range.y = max;
                property.vector2Value = range;
            }

        } else {
            EditorGUI.HelpBox(position, "Use MinMaxSlider only with type Vector2.", MessageType.Warning);
        }
    }

    public override float GetPropertyHeight( SerializedProperty property, GUIContent label ) {
        return base.GetPropertyHeight (property, label) + EditorGUIUtility.singleLineHeight;
    }
}

#else

using System;
using UnityEngine;

public class Divider : PropertyAttribute 
{
    public readonly float max;
    public readonly float min;
    
    public MinMaxSlider (float min, float max) {}
}

#endif
