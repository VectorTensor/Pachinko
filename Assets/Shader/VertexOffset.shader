
Shader "Examples/VertexOffset"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BaseColor("Base Color" , Color) = (1,1,1,1)
        _Second("Second Color" , Color) = (1,1,1,1)
        _ColorStart("Color Start", Range(0,1)) = 0 
        _ColorEnd("Color End", Range(0,1)) = 1 
        _Pattern("Pattern", 2D) ="white" {} 
        _rock("Rock", 2D) ="white "{}
        _WaveAmp("Wave Amplitude",Range(0,0.2)) = 0.1
    }
    SubShader
    {
        Tags { 
            "RenderType" = "Opaque"
            "Queue" = "Geometry"
 }

        Pass
        {
            //Cull Off
            //ZWrite Off
            //Blend One One
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define TAU 6.283185
            // make fog work

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal: Normal;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 normalWS : TEXCOORD1;
                float3 worldPos : TEXCOORD2;
            };

            sampler2D _MainTex;
            float4 _BaseColor;
            float4 _Second;
            float4 _MainTex_ST;
            float _ColorStart;
            float _WaveAmp;
            float _ColorEnd;
            sampler2D _Pattern;
            sampler2D _rock;



            float GetWave( float coord){
                float wave = cos((coord- _Time.y * 0.1) * TAU *5 )*0.5 +0.5; 
                wave *= 1- coord;
                return wave;
            }


            v2f vert (appdata v)
            {
                v2f o;
                //v.vertex.y = GetWave(v.uv);
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.worldPos = mul(UNITY_MATRIX_M, v.vertex);

                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.normalWS = UnityObjectToWorldNormal(v.normal);
                return o;
            }
            float InverseLerp(float a, float b, float v){
                return (v-a)/(b-a);
            }

            float4 frag (v2f i) : SV_Target
            {
                // sample the texture
                //fixed4 col = tex2D(_MainTex, i.uv);
                //return col;
               // float t = InverseLerp(_ColorStart+ cos(_Time.y),_ColorEnd+ cos(_Time.y), i.uv.x);

                //float t = InverseLerp(_ColorStart,_ColorEnd, i.uv.x);
                //float4 y = lerp(_BaseColor + cos(_Time.y),_Second + cos(_Time.y), t); 
               // float4 y = lerp(_BaseColor ,_Second , t); 
               float offset = cos(i.uv.x* TAU*8)*0.01;
                float t  = cos((i.uv.y  - _Time.y*0.1  )*TAU *5  )*0.5 +0.5;
                float4 moss = tex2D(_MainTex, float2(i.uv.x + _Time.y, i.uv.y));
               // t *= i.uv.x;
                //return t*_BaseColor;
                float topBottomRemover = (abs(i.normalWS.y) < 0.9999);
                float waves = t * topBottomRemover;
                
                float4 gradient = lerp(_BaseColor, _Second, i.uv.y); 
                float4 pattern = tex2D(_Pattern, i.uv);
                float rock = tex2D(_rock, i.uv);
               // return GetWave(i.uv);
               float4 terrain = lerp(moss,rock,pattern);
//                return GetWave(pattern);
                return moss ;
                //return t* (abs(i.normalWS.y)< 0.9998);
              //  return(y + cos(_Time.y));

            }
            ENDCG
        }
    }
}

























