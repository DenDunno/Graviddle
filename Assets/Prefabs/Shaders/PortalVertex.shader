// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Unlit/PortalVertex"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
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
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            uint id : SV_VertexID;
            
            float4 vertexOffset(float4 vertex)
            {
                return normalize(vertex) * (sin(_Time.y * 2)) / 5;
            }
            
            v2f vert (appdata v)
            {
                v2f o;
                const float4 vertex = v.vertex + vertexOffset(v.vertex);
                o.vertex = UnityObjectToClipPos(vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = float4(1,0.6,0,1);
                return col;
            }
            ENDCG
        }
    }
}
