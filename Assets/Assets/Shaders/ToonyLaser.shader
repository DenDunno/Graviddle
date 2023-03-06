
Shader "Unlit/ToonyShader" 
{
    Properties 
    {
        _MainTex ("Texture2D display name", 2D) = "" {}
        _Color ("Main Color", Color) = (1,1,1,1)
        _Width ("Width", Range(0.001, 0.1)) = 0.01
        _Falloff ("Falloff", Range(0.001, 1.0)) = 0.5
    }

    SubShader 
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass 
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _Color;
            float _Width;
            float _Falloff;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : COLOR
            {
                return _Color;
            }
            ENDCG
        }
    }

}