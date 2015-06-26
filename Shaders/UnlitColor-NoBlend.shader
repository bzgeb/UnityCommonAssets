Shader "Custom/Unlit-Color-NoBlend" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1) 
        [Enum(UnityEngine.Rendering.CullMode)] _Cull ("Cull mode", Float) = 1
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 100
        ZWrite On
        Cull [_Cull]
        Lighting Off
    
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"

            struct appdata_t {
                float4 vertex : POSITION;
            };

            struct v2f {
                float4 vertex : SV_POSITION;
            };

            float4 _Color;
            
            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
                return o;
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
                return _Color;
            }
            ENDCG
        }

    } 
    CustomEditor "RenderQueueMaterialInspector"
}
