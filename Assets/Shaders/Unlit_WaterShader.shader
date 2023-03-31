Shader "Unlit/WaterShader"
{
  Properties
  {
    _MainTex ("Texture", 2D) = "white" {}
    _CausticsTex ("Caustics", 2D) = "white" {}
    _Shimmering ("Distortion Texture", 2D) = "white" {}
    _IceTexture ("Ice texture", 2D) = "white" {}
    _Tint ("Tint", Color) = (0,0,0,0)
    _DepthColour ("Depth Colour", Color) = (0,0,0,0)
    _CausticsSpeed ("Caustics speed", float) = 1
    _Skew ("Skew", float) = 1
    _DistortIntensity ("Distort Intensity", float) = 1
    _Brightness ("Brightness", float) = 1
    _DepthFade ("Depth Fade Factor", Range(0, 1)) = 1
    _DepthMultiplier ("Depth", float) = 1
    _Temperature ("Temperature", float) = 18
  }
  SubShader
  {
    Tags
    { 
      "QUEUE" = "Transparent+1"
      "RenderType" = "Opaque"
    }
    Pass // ind: 1, name: 
    {
      Tags
      { 
      }
      ZClip Off
      ZWrite Off
      Cull Off
      Stencil
      { 
        Ref 0
        ReadMask 0
        WriteMask 0
        Pass Keep
        Fail Keep
        ZFail Keep
        PassFront Keep
        FailFront Keep
        ZFailFront Keep
        PassBack Keep
        FailBack Keep
        ZFailBack Keep
      } 
      // m_ProgramMask = 0
      
    } // end phase
    Pass // ind: 2, name: 
    {
      Tags
      { 
        "QUEUE" = "Transparent+1"
        "RenderType" = "Opaque"
      }
      ZWrite Off
      Cull Off
      Blend SrcAlpha OneMinusSrcAlpha
      // m_ProgramMask = 6
      CGPROGRAM
      //#pragma target 4.0
      
      #pragma vertex vert
      #pragma fragment frag
      
      #include "UnityCG.cginc"
      #define conv_mxt4x4_0(mat4x4) float4(mat4x4[0].x,mat4x4[1].x,mat4x4[2].x,mat4x4[3].x)
      #define conv_mxt4x4_1(mat4x4) float4(mat4x4[0].y,mat4x4[1].y,mat4x4[2].y,mat4x4[3].y)
      #define conv_mxt4x4_2(mat4x4) float4(mat4x4[0].z,mat4x4[1].z,mat4x4[2].z,mat4x4[3].z)
      #define conv_mxt4x4_3(mat4x4) float4(mat4x4[0].w,mat4x4[1].w,mat4x4[2].w,mat4x4[3].w)
      
      
      #define CODE_BLOCK_VERTEX
      //uniform float4x4 unity_ObjectToWorld;
      //uniform float4x4 unity_MatrixVP;
      uniform float4 _MainTex_ST;
      uniform float4 _CausticsTex_ST;
      uniform float4 _Shimmering_ST;
      //uniform float4 _Time;
      //uniform float4 unity_OrthoParams;
      uniform float _CausticsSpeed;
      uniform float _DepthMultiplier;
      uniform float4 _Tint;
      uniform float4 _DepthColour;
      uniform float _Skew;
      uniform float _DepthFade;
      uniform float _DistortIntensity;
      uniform float _Brightness;
      uniform float _Temperature;
      uniform sampler2D _MainTex;
      uniform sampler2D _IceTexture;
      uniform sampler2D _Shimmering;
      uniform sampler2D _BackgroundTexture;
      uniform sampler2D _CausticsTex;
      struct appdata_t
      {
          float4 vertex :POSITION0;
          float2 texcoord :TEXCOORD0;
      };
      
      struct OUT_Data_Vert
      {
          float2 texcoord :TEXCOORD0;
          float2 texcoord1 :TEXCOORD1;
          float4 texcoord3 :TEXCOORD3;
          float4 texcoord4 :TEXCOORD4;
          float2 texcoord5 :TEXCOORD5;
          float2 texcoord6 :TEXCOORD6;
          float4 vertex :SV_POSITION;
      };
      
      struct v2f
      {
          float2 texcoord :TEXCOORD0;
          float2 texcoord1 :TEXCOORD1;
          float4 texcoord3 :TEXCOORD3;
          float2 texcoord5 :TEXCOORD5;
          float2 texcoord6 :TEXCOORD6;
      };
      
      struct OUT_Data_Frag
      {
          float4 color :SV_Target0;
      };
      
      float4 u_xlat0;
      float4 u_xlat1;
      OUT_Data_Vert vert(appdata_t in_v)
      {
          OUT_Data_Vert out_v;
          out_v.texcoord.xy = TRANSFORM_TEX(in_v.texcoord.xy, _MainTex);
          out_v.texcoord1.xy = TRANSFORM_TEX(in_v.texcoord.xy, _CausticsTex);
          u_xlat0 = (in_v.vertex.yyyy * conv_mxt4x4_1(unity_ObjectToWorld));
          u_xlat0 = ((conv_mxt4x4_0(unity_ObjectToWorld) * in_v.vertex.xxxx) + u_xlat0);
          u_xlat0 = ((conv_mxt4x4_2(unity_ObjectToWorld) * in_v.vertex.zzzz) + u_xlat0);
          u_xlat1 = (u_xlat0 + conv_mxt4x4_3(unity_ObjectToWorld));
          out_v.texcoord6.xy = ((conv_mxt4x4_3(unity_ObjectToWorld).xy * in_v.vertex.ww) + u_xlat0.xy);
          u_xlat0 = mul(unity_MatrixVP, u_xlat1);
          u_xlat1.xyz = (u_xlat0.xyw * float3(0.5, 0.5, 0.5));
          u_xlat1.xy = (u_xlat1.zz + u_xlat1.xy);
          u_xlat1.zw = u_xlat0.zw;
          out_v.vertex = u_xlat0;
          out_v.texcoord3 = u_xlat1;
          out_v.texcoord4 = u_xlat1;
          out_v.texcoord5.xy = TRANSFORM_TEX(in_v.texcoord.xy, _Shimmering);
          return out_v;
      }
      
      #define CODE_BLOCK_FRAGMENT
      float4 u_xlat0_d;
      float4 u_xlat1_d;
      float4 u_xlat2;
      float4 u_xlat3;
      int u_xlati3;
      int u_xlatb3;
      float4 u_xlat4;
      int u_xlatb4;
      float4 u_xlat5;
      float3 u_xlat6;
      float3 u_xlat7;
      int u_xlatb7;
      float3 u_xlat8;
      float u_xlat14;
      float2 u_xlat16;
      float2 u_xlat17;
      int u_xlatb17;
      float2 u_xlat18;
      int u_xlatb18;
      float u_xlat21;
      int u_xlati23;
      int u_xlati24;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlat0_d.x = ((-in_f.texcoord.y) + 1);
          u_xlat0_d.x = log2(u_xlat0_d.x);
          u_xlat0_d.x = (u_xlat0_d.x * _DepthMultiplier);
          u_xlat0_d.x = exp2(u_xlat0_d.x);
          u_xlat0_d.x = min(u_xlat0_d.x, 1);
          u_xlat1_d = tex2D(_MainTex, in_f.texcoord.xy);
          u_xlatb7 = (_Temperature<0);
          if(u_xlatb7)
          {
              u_xlat7.xy = ((-u_xlat0_d.xx) + float2(1, 0.899999976));
              u_xlat2.xyz = ((-_Tint.xyz) + _DepthColour.xyz);
              u_xlat2.xyz = ((u_xlat7.xxx * u_xlat2.xyz) + _Tint.xyz);
              u_xlat3.xyz = (u_xlat1_d.xyz * u_xlat2.xyz);
              u_xlat4 = (in_f.texcoord6.xyxy * float4(0.00200000009, 0.00200000009, 0.0666666701, 0.0666666701));
              u_xlat5 = tex2D(_IceTexture, u_xlat4.xy);
              u_xlat6.xyz = ((-u_xlat5.xyz) + float3(0.717647076, 0.909803927, 0.890196085));
              u_xlat5.xyz = ((u_xlat6.xyz * float3(0.699999988, 0.699999988, 0.699999988)) + u_xlat5.xyz);
              u_xlat4 = tex2D(_IceTexture, u_xlat4.zw);
              u_xlat7.x = max(u_xlat7.y, 0);
              u_xlat14 = (unity_OrthoParams.x * 0.00400000019);
              u_xlat14 = clamp(u_xlat14, 0, 1);
              u_xlat14 = log2(u_xlat14);
              u_xlat14 = (u_xlat14 * 0.100000001);
              u_xlat14 = exp2(u_xlat14);
              u_xlat2.xyz = (((-u_xlat1_d.xyz) * u_xlat2.xyz) + float3(1, 1, 1));
              u_xlat2.xyz = ((u_xlat2.xyz * float3(0.5, 0.5, 0.5)) + u_xlat3.xyz);
              u_xlat3.xyz = ((-u_xlat4.xyz) + u_xlat5.xyz);
              u_xlat3.xyz = ((float3(u_xlat14, u_xlat14, u_xlat14) * u_xlat3.xyz) + u_xlat4.xyz);
              u_xlat21 = (u_xlat7.x * u_xlat7.x);
              u_xlat7.x = (u_xlat7.x * u_xlat21);
              u_xlat4.xyz = ((-u_xlat3.xyz) + float3(0.100000001, 0.100000001, 0.100000001));
              u_xlat3.xyz = ((u_xlat7.xxx * u_xlat4.xyz) + u_xlat3.xyz);
              out_f.color.xyz = (u_xlat2.xyz * u_xlat3.xyz);
              u_xlat7.x = (u_xlat14 * 0.800000012);
              out_f.color.w = max(u_xlat7.x, 0.200000003);
              return out_f;
          }
          u_xlat7.x = ((-u_xlat0_d.x) + 1);
          u_xlat2 = ((-_Tint.wxyz) + _DepthColour.wxyz);
          u_xlat2 = ((u_xlat7.xxxx * u_xlat2) + _Tint.wxyz);
          u_xlat7.x = max(u_xlat7.x, 0.100000001);
          u_xlat14 = (0.100000001 / unity_OrthoParams.y);
          u_xlat3.x = (_Time.y * 0.00999999978);
          u_xlat3.y = float(0);
          u_xlat17.y = float(0);
          u_xlat3.xy = (u_xlat3.xy + in_f.texcoord5.xy);
          u_xlat4 = tex2D(_Shimmering, u_xlat3.xy);
          u_xlat4.xyz = (float3(u_xlat14, u_xlat14, u_xlat14) * u_xlat4.xyw);
          u_xlat7.xyz = (u_xlat7.xxx * u_xlat4.xyz);
          u_xlat7.xyz = ((u_xlat7.xyz * float3(float3(_DistortIntensity, _DistortIntensity, _DistortIntensity))) + in_f.texcoord3.xyw);
          u_xlat7.xy = (u_xlat7.xy / u_xlat7.zz);
          u_xlat4 = tex2D(_BackgroundTexture, u_xlat7.xy);
          u_xlat7.x = (in_f.texcoord.y * _Skew);
          u_xlat3.x = (u_xlat7.x * 0.0500000007);
          u_xlat3.y = (_Time.y * _CausticsSpeed);
          u_xlat17.x = in_f.texcoord1.x;
          u_xlat7.xy = (u_xlat3.xy + u_xlat17.xy);
          u_xlat3 = tex2D(_CausticsTex, u_xlat7.xy);
          u_xlat7.x = (u_xlat3.x * u_xlat3.x);
          u_xlat7.x = (u_xlat7.x * _Brightness);
          u_xlat14 = (u_xlat0_d.x + (-1));
          u_xlat14 = ((_DepthFade * u_xlat14) + 1);
          u_xlat1_d = ((u_xlat7.xxxx * float4(u_xlat14, u_xlat14, u_xlat14, u_xlat14)) + u_xlat1_d.wxyz);
          u_xlat7.xyz = ((-u_xlat2.yzw) + float3(1, 1, 1));
          u_xlat7.xyz = ((u_xlat0_d.xxx * u_xlat7.xyz) + u_xlat2.yzw);
          u_xlat7.xyz = (u_xlat7.xyz * u_xlat4.xyz);
          u_xlat1_d.x = (u_xlat2.x * u_xlat1_d.x);
          u_xlat8.xyz = ((u_xlat1_d.yzw * u_xlat2.yzw) + (-u_xlat7.xyz));
          u_xlat1_d.xyz = ((u_xlat1_d.xxx * u_xlat8.xyz) + u_xlat7.xyz);
          u_xlatb7 = (_Temperature>=100);
          if(u_xlatb7)
          {
              u_xlat7.xy = (in_f.texcoord6.xy * float2(1.5, 1.5));
              u_xlat16.x = 0;
              u_xlat16.y = (_Time.x * 0.600000024);
              u_xlat2.xy = ((in_f.texcoord6.xy * float2(0.00999999978, 0.00999999978)) + u_xlat16.xy);
              u_xlat2 = tex2D(_Shimmering, u_xlat2.xy);
              u_xlat2.xy = ((u_xlat2.xy * float2(2, 2)) + in_f.texcoord6.xy);
              u_xlat21 = (u_xlat0_d.x + 0.5);
              u_xlat21 = min(u_xlat21, 1);
              u_xlat3.xy = ((_Time.zz * float2(3.60000014, 6)) + float2(u_xlat21, u_xlat21));
              u_xlat2.z = (u_xlat2.y + (-u_xlat3.x));
              u_xlat2.xy = (u_xlat2.xz + u_xlat2.xz);
              u_xlat16.xy = floor(u_xlat2.xy);
              u_xlat2.xy = frac(u_xlat2.xy);
              u_xlat21 = 8;
              int u_xlati_loop_1 = int(4294967295);
              while((u_xlati_loop_1<=1))
              {
                  u_xlat4.y = float(u_xlati_loop_1);
                  u_xlat17.x = u_xlat21;
                  int u_xlati_loop_2 = int(4294967295);
                  while((u_xlati_loop_2<=1))
                  {
                      u_xlat4.x = float(u_xlati_loop_2);
                      u_xlat18.xy = (u_xlat16.xy + u_xlat4.xy);
                      u_xlat5.x = dot(u_xlat18.xy, float2(127.099998, 311.700012));
                      u_xlat18.x = dot(u_xlat18.xy, float2(269.5, 183.300003));
                      u_xlat5.x = sin(u_xlat5.x);
                      u_xlat5.y = sin(u_xlat18.x);
                      u_xlat18.xy = (u_xlat5.xy * float2(18.5452995, 18.5452995));
                      u_xlat18.xy = frac(u_xlat18.xy);
                      u_xlat5.xy = ((-u_xlat2.xy) + u_xlat4.xy);
                      u_xlat4.xz = ((u_xlat18.xy * float2(6.28310013, 6.28310013)) + float2(0.5, 0.5));
                      u_xlat4.xz = sin(u_xlat4.xz);
                      u_xlat4.xz = ((u_xlat4.xz * float2(0.5, 0.5)) + u_xlat5.xy);
                      u_xlat4.xz = (u_xlat4.xz + float2(0.5, 0.5));
                      u_xlat4.x = dot(u_xlat4.xz, u_xlat4.xz);
                      u_xlatb18 = (u_xlat4.x<u_xlat17.x);
                      u_xlat17.x = (u_xlatb18)?(u_xlat4.x):(u_xlat17.x);
                      u_xlati_loop_2 = (u_xlati_loop_2 + 1);
                  }
                  u_xlat21 = u_xlat17.x;
                  u_xlati_loop_1 = (u_xlati_loop_1 + 1);
              }
              u_xlat21 = sqrt(u_xlat21);
              u_xlat21 = ((-u_xlat21) + 1);
              u_xlat21 = (u_xlat0_d.x * u_xlat21);
              u_xlat21 = (((-u_xlat21) * u_xlat21) + 0.5);
              u_xlat0_d.w = ((-abs(u_xlat21)) + 1);
              u_xlat2.x = 0;
              u_xlat2.y = _Time.x;
              u_xlat2.xy = ((in_f.texcoord6.xy * float2(0.0149999997, 0.0149999997)) + u_xlat2.xy);
              u_xlat2 = tex2D(_Shimmering, u_xlat2.xy);
              u_xlat2.xy = ((u_xlat2.xy * float2(2, 2)) + u_xlat7.xy);
              u_xlat2.z = ((-u_xlat3.y) + u_xlat2.y);
              u_xlat7.xy = (u_xlat2.xz + u_xlat2.xz);
              u_xlat2.xy = floor(u_xlat7.xy);
              u_xlat7.xy = frac(u_xlat7.xy);
              u_xlat16.x = float(8);
              int u_xlati_loop_3 = int(int(4294967295));
              while((u_xlati_loop_3<=1))
              {
                  u_xlat3.y = float(u_xlati_loop_3);
                  u_xlat17.x = u_xlat16.x;
                  int u_xlati_loop_4 = int(4294967295);
                  while((u_xlati_loop_4<=1))
                  {
                      u_xlat3.x = float(u_xlati_loop_4);
                      u_xlat4.xy = (u_xlat2.xy + u_xlat3.xy);
                      u_xlat4.z = dot(u_xlat4.xy, float2(127.099998, 311.700012));
                      u_xlat4.x = dot(u_xlat4.xy, float2(269.5, 183.300003));
                      u_xlat5.xy = sin(u_xlat4.zx);
                      u_xlat4.xy = (u_xlat5.xy * float2(18.5452995, 18.5452995));
                      u_xlat4.xy = frac(u_xlat4.xy);
                      u_xlat18.xy = ((-u_xlat7.xy) + u_xlat3.xy);
                      u_xlat4.xy = ((u_xlat4.xy * float2(6.28310013, 6.28310013)) + float2(0.5, 0.5));
                      u_xlat4.xy = sin(u_xlat4.xy);
                      u_xlat4.xy = ((u_xlat4.xy * float2(0.5, 0.5)) + u_xlat18.xy);
                      u_xlat4.xy = (u_xlat4.xy + float2(0.5, 0.5));
                      u_xlat3.x = dot(u_xlat4.xy, u_xlat4.xy);
                      u_xlatb4 = (u_xlat3.x<u_xlat17.x);
                      u_xlat17.x = (u_xlatb4)?(u_xlat3.x):(u_xlat17.x);
                      u_xlati_loop_4 = (u_xlati_loop_4 + 1);
                  }
                  u_xlat16.x = u_xlat17.x;
                  u_xlati_loop_3 = (u_xlati_loop_3 + 1);
              }
              u_xlat7.x = sqrt(u_xlat16.x);
              u_xlat7.x = ((-u_xlat7.x) + 1);
              u_xlat0_d.x = (u_xlat0_d.x * u_xlat7.x);
              u_xlat0_d.x = (((-u_xlat0_d.x) * u_xlat0_d.x) + 0.5);
              u_xlat0_d.x = ((-abs(u_xlat0_d.x)) + 1);
              u_xlat0_d.xw = (u_xlat0_d.xw * u_xlat0_d.xw);
              u_xlat0_d.x = (u_xlat0_d.x * u_xlat0_d.x);
              u_xlat0_d.x = ((u_xlat0_d.w * u_xlat0_d.w) + u_xlat0_d.x);
              u_xlat1_d.w = 1;
              out_f.color = ((u_xlat0_d.xxxx * float4(0.00500000035, 0.00500000035, 0.00500000035, 0.00500000035)) + u_xlat1_d);
          }
          else
          {
              out_f.color.xyz = u_xlat1_d.xyz;
              out_f.color.w = 1;
          }
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
