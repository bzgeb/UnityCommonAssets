Shader "Custom/Unlit-VertexColor" {
    SubShader {
        Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
        LOD 100
        ZWrite On
        Blend SrcAlpha OneMinusSrcAlpha
    
        Pass {
            Lighting Off
            CGPROGRAM
            #include "UnityCG.cginc"
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 3.0

            float4 _Color;

            struct vertexInput {
                float4 vertex : POSITION;
                float4 color : COLOR;
            };

            struct vertexOutput {
                float4 pos : SV_POSITION;
                float4 color : COLOR0;
            };

            vertexOutput vert( vertexInput input ) {
                vertexOutput output;

                output.pos = mul( UNITY_MATRIX_MVP, input.vertex );
                output.color = input.color;

                return output;
            }

            float4 frag( vertexOutput input ) : COLOR {
                float4 result = input.color;

                return result;
            }
            ENDCG
        }
    }
}
