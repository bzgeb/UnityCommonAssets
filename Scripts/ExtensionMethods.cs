using UnityEngine;
using System;
using System.Reflection;

public static class ExtensionMethods {
    public static float Remap (this float value, float from1, float to1, float from2, float to2) {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

    public static string GetPath(this Transform current) {
         if (current.parent == null) {
             return "/" + current.name;
         }

         return current.parent.GetPath() + "/" + current.name;
    }

    public static string GetRelativePath(this Transform current, Transform parent ) {
        if ( current.parent == null ) {
            return "/" + current.name;
        }

        if ( current.parent == parent ) {
            return current.name;
        }

        return current.parent.GetRelativePath( parent ) + "/" + current.name;
    }

    public static int ParentCount( this Transform current ) {
        if ( current.parent == null ) {
            return 0;
        }

        return current.parent.ParentCount() + 1;
    }

    public static T GetCopyOf<T>(this Component comp, T other) where T : Component
    {
        Type type = comp.GetType();
        if (type != other.GetType()) return null; // type mis-match
        BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Default | BindingFlags.DeclaredOnly;
        PropertyInfo[] pinfos = type.GetProperties(flags);
        foreach (var pinfo in pinfos) {
            if (pinfo.CanWrite) {
                try {
                    pinfo.SetValue(comp, pinfo.GetValue(other, null), null);
                }
                catch { } // In case of NotImplementedException being thrown. For some reason specifying that exception didn't seem to catch it, so I didn't catch anything specific.
            }
        }
        FieldInfo[] finfos = type.GetFields(flags);
        foreach (var finfo in finfos) {
            finfo.SetValue(comp, finfo.GetValue(other));
        }
        return comp as T;
    }

    public static T AddComponent<T>(this GameObject go, T toAdd) where T : Component
    {
        return go.AddComponent<T>().GetCopyOf(toAdd) as T;
    }
}