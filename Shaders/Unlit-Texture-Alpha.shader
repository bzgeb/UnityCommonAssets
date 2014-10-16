Shader "Custom/Unlit-Texture-Alpha" {
Properties {
    _MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
    _Color ("Multiplied Alpha", Color) = (0, 0, 0, 1)
}

SubShader {
    Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
    LOD 100
    
    ZWrite Off
    Blend SrcAlpha OneMinusSrcAlpha 

    Pass {
        Lighting Off
        Color [_Color]
        SetTexture [_MainTex] { 
            combine texture, texture * primary
        } 
    }
}
}
