Shader "Unlit/ToonyLaser"
{
    Properties
    {
        _Color("Main color", Color) = (.25, .5, .5, 1)
        _LineSize ("Line size", Range(0.0, 0.5)) = 0.25 
        _NoiseTexture ("Noise", 2d) = "" {}
    }
    SubShader
    {
        Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha
        LOD 100
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            fixed4 _Color;
            float _LineSize;
            sampler2D _NoiseTexture;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                const fixed transparency = (i.uv.x > 0.5 - _LineSize) * (i.uv.x < 0.5 + _LineSize);
                
                const float noise = tex2D(_NoiseTexture, i.uv).r;
                i.uv.x = i.uv.x + noise;


                return _Color * transparency;
            }
            ENDCG
        }
    }
}
