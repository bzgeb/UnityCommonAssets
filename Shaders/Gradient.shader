Shader "Custom/Gradient" {
    Properties {
        _direction("Direction",Range(0,1)) = 0
        _color1 ("Color 1", Color) = (1,.5,.5,1)
        _color2 ("Color 2", Color) = (.5,1,1,1)
    }
    SubShader {
        Pass{
        
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            float4 _color1;
            float4 _color2; 
            float4 _finalColor;
            float _direction;
            
            struct appdata {
                float4 vertex : POSITION;
                float4 tex : TEXCOORD0;
                float3 normal : NORMAL;
            };
            struct v2f {
                float4 vertex : TEXCOORD;
                float4 pos : POSITION;
                float4 color : COLOR;
            };
            v2f vert(appdata v) {
                v2f o;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                o.vertex = v.tex;
                return o;
            };
            half4 frag(v2f i) : COLOR {
                _finalColor.a = 1;
                _finalColor.r = ((_color1.r*i.vertex.y*_direction+_color1.r*i.vertex.x*(1-_direction))+(_color2.r*(1-i.vertex.y)*_direction+_color2.r*(1-i.vertex.x)*(1-_direction)));
                _finalColor.g = ((_color1.g*i.vertex.y*_direction+_color1.g*i.vertex.x*(1-_direction))+(_color2.g*(1-i.vertex.y)*_direction+_color2.g*(1-i.vertex.x)*(1-_direction)));
                _finalColor.b = ((_color1.b*i.vertex.y*_direction+_color1.b*i.vertex.x*(1-_direction))+(_color2.b*(1-i.vertex.y)*_direction+_color2.b*(1-i.vertex.x)*(1-_direction)));
                return _finalColor;
            };

            ENDCG
        }
    } 
    FallBack "Diffuse"
}