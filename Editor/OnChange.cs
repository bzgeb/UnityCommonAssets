#if UNITY_EDITOR

using System;
using UnityEngine;
using UnityEditor;

public class OnChange : PropertyAttribute 
{
    public readonly string[] MethodNames;

    public OnChange(params string[] MethodNames) {
        this.MethodNames = MethodNames;
    }
}

[CustomPropertyDrawer(typeof(OnChange))]
public class OnChangeDrawer : PropertyDrawer 
{
    public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
        OnChange attr = attribute as OnChange;

        EditorGUI.BeginChangeCheck();
        EditorGUI.PropertyField(position, property, label, true);

        if (EditorGUI.EndChangeCheck()) {
            foreach (MonoBehaviour obj in property.serializedObject.targetObjects) {

                if (obj.enabled) {

                    foreach (var methodName in attr.MethodNames) {
                        obj.Invoke(methodName, 0f);
                    }
                }
            }
        }
    }
}

#else

using System;
using UnityEngine;

public class OnChange : PropertyAttribute
{
    public readonly string MethodName;
    public OnChange(string MethodName) {}
}

#endif