Shader "Noble Muffins/Doublesided (Two-Tex, Unlit)-SingleColorInside" {
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" { }
        _InsideColor( "Insides", Color ) = (1,1,1,1)
        _BlendTex ("Blend (RGB)", 2D) = "white" { }
        _BlendAmount ("Blend Amount", Range(0,1)) = 0
    }

    Category
    {
        BindChannels {
           Bind "Vertex", vertex
           Bind "texcoord", texcoord0
       }
        ZWrite On
        SubShader
        {
            Lighting Off
            Pass
            {
                Cull Back
                SetTexture [_MainTex]
                {
                    Combine texture
                } 

                SetTexture [_BlendTex]
                {
                    constantColor( 1, 1, 1, [_BlendAmount] )
                    Combine texture lerp(constant) previous
                }
            }
            Pass
            {
                Cull Front
                SetTexture [_]
                {
                    constantColor [_InsideColor]
                    Combine constant
                } 

                SetTexture [_BlendTex]
                {
                    constantColor( 1, 1, 1, [_BlendAmount] )
                    Combine texture lerp(constant) previous
                }
            }
        } 
    }
}
