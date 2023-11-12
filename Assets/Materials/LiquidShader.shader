// Upgrade NOTE: replaced 'UNITY_INSTANCE_ID' with 'UNITY_VERTEX_INPUT_INSTANCE_ID'

Shader "Custom/LiquidShader" {
    Properties {
           _TopColor ("Top Color", Color) = (1, 1, 1, 0.5)
        _MiddleColor ("Middle Color", Color) = (0.5, 0.3, 0, 0.5)
        _BottomColor ("Bottom Color", Color) = (0, 0, 0, 0.5)
        _BottomHeight ("Bottom Height", Range(-1,1)) = 0.33
        _MiddleHeight ("Middle Height", Range(-1,1)) = 0.66
        _TopHeight ("Top Height", Range(-1,1)) = 0.99
    }
    SubShader {
        Tags { "RenderType"="Transparent" }
        LOD 100
        Cull Back
        ZWrite On

        Pass {
            Blend SrcAlpha OneMinusSrcAlpha 
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            struct appdata {
                float4 vertex : POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID 
            };

            struct v2f {
                float4 vertex : SV_POSITION;
                float3 localPos : TEXCOORD0;                
                UNITY_VERTEX_OUTPUT_STEREO 
            };

            v2f vert (appdata v) {
                v2f o;
                UNITY_SETUP_INSTANCE_ID(v); 
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o); 
                o.vertex = UnityObjectToClipPos(v.vertex);
                //o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                o.localPos = v.vertex.xyz; // Use local position instead of world position
                return o;
            }

            float4 _TopColor;
            float4 _MiddleColor;
            float4 _BottomColor;
            float _TopHeight;
            float _MiddleHeight;
            float _BottomHeight;

            fixed4 frag (v2f i) : SV_Target {
                float height = i.localPos.y;
                if (height < _BottomHeight) {
                    return _BottomColor;
                } else if (height < _MiddleHeight) {
                    return _MiddleColor;
                } else {
                    return _TopColor;
                }
            }

            ENDCG
        }
    }
}
