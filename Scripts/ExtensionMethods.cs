using UnityEngine;

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
}