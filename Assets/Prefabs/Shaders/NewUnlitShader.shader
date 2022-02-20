Shader "Custom/Shiny"
{
    Properties
    {
        [NoScaleOffset] _MainTex ("Main texture", 2D) = "white" {}
        [NoScaleOffset] _NoiseLine ("Noise line", 2D) = "white" {}
        _LineColor ("Line color", COLOR) = (1,1,1,1)
        _Angle("Line rotation", float) = 0
        _Shiny("Line rotation", float) = 0
    }
    SubShader
    {
        Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" }
        ZTest Always
        Blend SrcAlpha OneMinusSrcAlpha

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

            sampler2D _MainTex;
            sampler2D _NoiseLine;
            float4 _MainTex_ST;
            float4 _LineColor;
            float _Angle;
            float _Shiny;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed2 rotateUV(fixed2 uv, fixed2 mid)
            {
                float angle = _Angle * UNITY_PI / 180;
                
                return fixed2(
                  cos(angle) * (uv.x - mid.x) + sin(angle) * (uv.y - mid.y) + mid.x,
                  cos(angle) * (uv.y - mid.y) - sin(angle) * (uv.x - mid.x) + mid.y
                );
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed2 noise_line_uv = rotateUV(i.uv, fixed2(0.5, 0.5)) - _Shiny;
                fixed4 noise_line = tex2D(_NoiseLine, noise_line_uv) * _LineColor;
                fixed4 textureColor = tex2D(_MainTex, i.uv);
                fixed4 sum = noise_line + textureColor;
                sum.a = textureColor.a;
                
                return sum;
            }
            ENDCG
        }
    }
}
