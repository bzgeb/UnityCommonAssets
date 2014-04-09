Shader "Unlit-No Fog" {
Properties {
    _MainTex ("Base (RGB)", 2D) = "white" {}
}

SubShader {
    Tags { "RenderType"="Opaque" }
    LOD 100
    
    Pass {
        Tags { "LightMode" = "Vertex" }
        Fog { Mode OFF }
        Lighting Off
        SetTexture [_MainTex] { combine texture } 
    }
    
}
}



