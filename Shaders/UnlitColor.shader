Shader "Custom/Unlit-Color" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1) 
        [Enum(UnityEngine.Rendering.BlendMode)] _Blend ("Blend mode", Float) = 1
        [Enum(UnityEngine.Rendering.BlendMode)] _Blend2 ("Blend mode 2", Float) = 1
        [Enum(UnityEngine.Rendering.CullMode)] _Cull ("Cull mode", Float) = 1
    }
    SubShader {
        LOD 100
        ZWrite On
        Blend [_Blend] [_Blend2]
        Cull [_Cull]
    
        Pass {
            Lighting Off
            Color [_Color]
        }

    } 
    CustomEditor "RenderQueueMaterialInspector"
}
