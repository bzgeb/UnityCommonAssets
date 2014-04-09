Shader "Custom/VertexNoise" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1) 
    }
    SubShader { // Unity chooses the subshader that fits the GPU best
        Pass { // some shaders require multiple passes
            CGPROGRAM // here begins the part in Unity's Cg
 
            #pragma vertex vert // this specifies the vert function as the vertex shader 
            #pragma fragment frag // this specifies the frag function as the fragment shader
            #include "UnityCG.cginc"

            uniform float4 _Color;
 
            float4 vert(appdata_base input) : SV_POSITION // vertex shader 
            {
                // input.vertex.xyz = input.vertex.xyz + (input.normal * sin(_Time + (input.vertex.y + input.vertex.x + input.vertex.z) * 20 ));
                input.vertex.xyz = input.vertex.xyz + (1.8f * input.normal * sin(10 * _Time[1] + (input.vertex.x + input.vertex.y + input.vertex.z) * 100));
                return mul(UNITY_MATRIX_MVP, input.vertex);
            }
 
            float4 frag(void) : COLOR // fragment shader
            {
                return _Color;
            }
 
              ENDCG // here ends the part in Cg 
        }
    }
}