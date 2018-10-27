Shader "Oculus/Unlit Transparent Color" {
Properties {
    _Color ("Main Color", Color) = (1,1,1,1)
    _MainTex ("Texture", 2D) = "white" {} //  I added this property to apply Texture. Where can I use it?
}

SubShader {
    Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
    LOD 100
    Fog {Mode Off}
    Cull Off
    ZWrite Off
    Blend SrcAlpha OneMinusSrcAlpha
    Color [_Color]

    Pass {
		SetTexture [_MainTex] {
            constantColor [_Color]
            Combine texture * primary DOUBLE, texture * constant
        }
	}
}
}
