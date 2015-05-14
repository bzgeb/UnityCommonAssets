Shader "Custom/Henk glow" {
Properties {
	_Color ("Main Color", Color) = (0.5,0.5,0.5,0.5)
	_MainTex ("Texture", 2D) = "white" {}
	_Softness ("See-through Softness", Float) = 1
	_MinDistance ("Closeest Distance (hidden)", Float) = 2
	_MaxDistance ("Medium Distance (fully visible)", Float) = 10
	_FadeDistance ("Farthest Distance (hidden)", Float) = 10000
    _RimHardness ("Rim Hardness", Float) = 1
}

Category {
	Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
	//Blend One One
	Blend One OneMinusSrcAlpha
	AlphaTest Greater .01
	ColorMask RGB
	Cull Off
    Lighting Off
    ZWrite Off
    Fog { Color (0,0,0,0) }
	BindChannels {
		Bind "Color", color
		Bind "Vertex", vertex
		Bind "TexCoord", texcoord
	}
	
	SubShader {
		Pass {
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_particles

			#include "UnityCG.cginc"

			sampler2D _MainTex;
			fixed4 _Color;
            float _Softness;
            float _MinDistance;
            float _MaxDistance;
            float _FadeDistance;
            float _RimHardness;
			
			struct appdata_t {
				float4 vertex : POSITION;
				fixed4 color : COLOR;
                fixed3 normal : NORMAL;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f {
				float4 vertex : POSITION;
				fixed4 color : COLOR;
                fixed3 normal : TEXCOORD0;
				float2 texcoord : TEXCOORD1;
                float3 eyeToPoint : TEXCOORD2;
                #ifdef SOFTPARTICLES_ON
				float4 projPos : TEXCOORD3;
                #endif
			};
			
			float4 _MainTex_ST;

			v2f vert (appdata_t v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.color = v.color;
                o.normal = mul(UNITY_MATRIX_IT_MV, float4(v.normal, 0)).xyz;
				o.texcoord = TRANSFORM_TEX(v.texcoord,_MainTex);
                o.eyeToPoint = mul(UNITY_MATRIX_MV, v.vertex).xyz;

                #ifdef SOFTPARTICLES_ON
				o.projPos = ComputeScreenPos (o.vertex);
				COMPUTE_EYEDEPTH(o.projPos.z);
                #endif

				return o;
			}

			sampler2D _CameraDepthTexture;

			fixed4 frag (v2f i) : COLOR
			{
                float angleFactor = saturate(_RimHardness * abs(dot(
                    normalize(i.eyeToPoint),
                    -normalize(i.normal))));

                float distance = length(i.eyeToPoint);
				float fade =
                    smoothstep(_MinDistance, _MaxDistance, distance) *
                    smoothstep(_FadeDistance, _MaxDistance, distance) *
                    angleFactor * angleFactor;

                #ifdef SOFTPARTICLES_ON
				float sceneZ = LinearEyeDepth (UNITY_SAMPLE_DEPTH(
                    tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos))));
				float partZ = i.projPos.z;
                fade *= smoothstep(0, _Softness, sceneZ-partZ);
                #endif

                float4 color = _Color * tex2D(_MainTex, i.texcoord);
                return float4(
                  i.color.rgb * color.rgb * 2 * fade * i.color.a,
                  color.a * 2 * fade);
			}
			ENDCG 
		}
	} 	

}
}
