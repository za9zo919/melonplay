Shader "Unlit/EnergySword"
{
  Properties
  {
    _MainTex ("Texture", 2D) = "white" {}
    _OverlayTexture ("Texture", 2D) = "white" {}
    [HDR] _GlowColour ("Glow Colour", Color) = (1,0,1,1)
  }
  SubShader
  {
    Tags
    { 
      "CanUseSpriteAtlas" = "true"
      "QUEUE" = "Transparent+1"
      "RenderType" = "Opaque"
    }
    Pass // ind: 1, name: 
    {
      Tags
      { 
        "CanUseSpriteAtlas" = "true"
        "QUEUE" = "Transparent+1"
        "RenderType" = "Opaque"
      }
      ZWrite Off
      Cull Off
      Blend One One
      // m_ProgramMask = 6
      CGPROGRAM
      //#pragma target 4.0
      
      #pragma vertex vert
      #pragma fragment frag
      
      #include "UnityCG.cginc"
      
      
      #define CODE_BLOCK_VERTEX
      //uniform float4x4 unity_ObjectToWorld;
      //uniform float4x4 unity_MatrixVP;
      uniform float4 _MainTex_ST;
      //uniform float4 _Time;
      uniform float4 _GlowColour;
      uniform sampler2D _MainTex;
      uniform sampler2D _OverlayTexture;
      struct appdata_t
      {
          float4 vertex :POSITION0;
          float4 color :COLOR0;
          float2 texcoord :TEXCOORD0;
      };
      
      struct OUT_Data_Vert
      {
          float2 texcoord :TEXCOORD0;
          float2 texcoord1 :TEXCOORD1;
          float4 color :COLOR0;
          float4 vertex :SV_POSITION;
      };
      
      struct v2f
      {
          float2 texcoord :TEXCOORD0;
          float2 texcoord1 :TEXCOORD1;
          float4 color :COLOR0;
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
          out_v.texcoord1.xy = (in_v.vertex.xy * float2(0.5, 0.5));
          out_v.color = in_v.color;
          out_v.vertex = UnityObjectToClipPos(in_v.vertex);
          return out_v;
      }
      
      #define CODE_BLOCK_FRAGMENT
      float4 u_xlat0_d;
      float4 u_xlat1_d;
      float2 u_xlat2;
      int u_xlati2;
      int u_xlatb2;
      float3 u_xlat3;
      int u_xlatb3;
      float2 u_xlat4;
      float u_xlat5;
      float u_xlat7;
      int u_xlati7;
      int u_xlatb7;
      float u_xlat10;
      float2 u_xlat11;
      float u_xlat12;
      int u_xlati12;
      int u_xlatb12;
      float2 u_xlat13;
      int u_xlatb13;
      int u_xlati16;
      float u_xlat17;
      int u_xlati17;
      int u_xlatb17;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlat0_d = tex2D(_MainTex, in_f.texcoord.xy);
          u_xlat1_d = tex2D(_OverlayTexture, in_f.texcoord1.xy);
          u_xlat0_d.xy = ((u_xlat1_d.xy * float2(0.0500000007, 0.0500000007)) + in_f.texcoord1.xy);
          u_xlat1_d.xy = (u_xlat0_d.xy * float2(4, 4));
          u_xlat11.xy = floor(u_xlat1_d.xy);
          u_xlat1_d.xy = frac(u_xlat1_d.xy);
          u_xlat10 = 8;
          int u_xlati_loop_1 = int(4294967295);
          while((u_xlati_loop_1<=1))
          {
              u_xlat3.y = float(u_xlati_loop_1);
              u_xlat7 = u_xlat10;
              int u_xlati_loop_2 = int(4294967295);
              while((u_xlati_loop_2<=1))
              {
                  u_xlat3.x = float(u_xlati_loop_2);
                  u_xlat13.xy = (u_xlat11.xy + u_xlat3.xy);
                  u_xlat17 = dot(u_xlat13.xy, float2(127.099998, 311.700012));
                  u_xlat13.x = dot(u_xlat13.xy, float2(269.5, 183.300003));
                  u_xlat4.x = sin(u_xlat17);
                  u_xlat4.y = sin(u_xlat13.x);
                  u_xlat13.xy = (u_xlat4.xy * float2(18.5452995, 18.5452995));
                  u_xlat13.xy = frac(u_xlat13.xy);
                  u_xlat4.xy = ((-u_xlat1_d.xy) + u_xlat3.xy);
                  u_xlat3.xz = ((u_xlat13.xy * float2(6.28310013, 6.28310013)) + _Time.yy);
                  u_xlat3.xz = sin(u_xlat3.xz);
                  u_xlat3.xz = ((u_xlat3.xz * float2(0.5, 0.5)) + u_xlat4.xy);
                  u_xlat3.xz = (u_xlat3.xz + float2(0.5, 0.5));
                  u_xlat17 = dot(u_xlat3.xz, u_xlat3.xz);
                  u_xlatb3 = (u_xlat17<u_xlat7);
                  u_xlat7 = (u_xlatb3)?(u_xlat17):(u_xlat7);
                  u_xlati_loop_2 = (u_xlati_loop_2 + 1);
              }
              u_xlat10 = u_xlat7;
              u_xlati_loop_1 = (u_xlati_loop_1 + 1);
          }
          u_xlat10 = sqrt(u_xlat10);
          u_xlat1_d.xy = ((u_xlat0_d.xy * float2(8, 8)) + float2(1.23399997, 1.23399997));
          u_xlat11.xy = floor(u_xlat1_d.xy);
          u_xlat1_d.xy = frac(u_xlat1_d.xy);
          u_xlat2.x = float(8);
          int u_xlati_loop_3 = int(int(4294967295));
          while((u_xlati_loop_3<=1))
          {
              u_xlat3.y = float(u_xlati_loop_3);
              u_xlat12 = u_xlat2.x;
              int u_xlati_loop_4 = int(4294967295);
              while((u_xlati_loop_4<=1))
              {
                  u_xlat3.x = float(u_xlati_loop_4);
                  u_xlat13.xy = (u_xlat11.xy + u_xlat3.xy);
                  u_xlat4.x = dot(u_xlat13.xy, float2(127.099998, 311.700012));
                  u_xlat13.x = dot(u_xlat13.xy, float2(269.5, 183.300003));
                  u_xlat4.x = sin(u_xlat4.x);
                  u_xlat4.y = sin(u_xlat13.x);
                  u_xlat13.xy = (u_xlat4.xy * float2(18.5452995, 18.5452995));
                  u_xlat13.xy = frac(u_xlat13.xy);
                  u_xlat4.xy = ((-u_xlat1_d.xy) + u_xlat3.xy);
                  u_xlat3.xz = ((u_xlat13.xy * float2(6.28310013, 6.28310013)) + _Time.yy);
                  u_xlat3.xz = sin(u_xlat3.xz);
                  u_xlat3.xz = ((u_xlat3.xz * float2(0.5, 0.5)) + u_xlat4.xy);
                  u_xlat3.xz = (u_xlat3.xz + float2(0.5, 0.5));
                  u_xlat3.x = dot(u_xlat3.xz, u_xlat3.xz);
                  u_xlatb13 = (u_xlat3.x<u_xlat12);
                  u_xlat12 = (u_xlatb13)?(u_xlat3.x):(u_xlat12);
                  u_xlati_loop_4 = (u_xlati_loop_4 + 1);
              }
              u_xlat2.x = u_xlat12;
              u_xlati_loop_3 = (u_xlati_loop_3 + 1);
          }
          u_xlat1_d.x = sqrt(u_xlat2.x);
          u_xlat10 = (u_xlat10 + u_xlat1_d.x);
          u_xlat0_d.xy = ((u_xlat0_d.xy * float2(16, 16)) + float2(4.21309996, 4.21309996));
          u_xlat1_d.xy = floor(u_xlat0_d.xy);
          u_xlat0_d.xy = frac(u_xlat0_d.xy);
          u_xlat11.x = float(8);
          int u_xlati_loop_5 = int(int(4294967295));
          while((u_xlati_loop_5<=1))
          {
              u_xlat2.y = float(u_xlati_loop_5);
              u_xlat12 = u_xlat11.x;
              int u_xlati_loop_6 = int(4294967295);
              while((u_xlati_loop_6<=1))
              {
                  u_xlat2.x = float(u_xlati_loop_6);
                  u_xlat3.xy = (u_xlat1_d.xy + u_xlat2.xy);
                  u_xlat3.z = dot(u_xlat3.xy, float2(127.099998, 311.700012));
                  u_xlat3.x = dot(u_xlat3.xy, float2(269.5, 183.300003));
                  u_xlat4.xy = sin(u_xlat3.zx);
                  u_xlat3.xy = (u_xlat4.xy * float2(18.5452995, 18.5452995));
                  u_xlat3.xy = frac(u_xlat3.xy);
                  u_xlat13.xy = ((-u_xlat0_d.xy) + u_xlat2.xy);
                  u_xlat3.xy = ((u_xlat3.xy * float2(6.28310013, 6.28310013)) + _Time.yy);
                  u_xlat3.xy = sin(u_xlat3.xy);
                  u_xlat3.xy = ((u_xlat3.xy * float2(0.5, 0.5)) + u_xlat13.xy);
                  u_xlat3.xy = (u_xlat3.xy + float2(0.5, 0.5));
                  u_xlat2.x = dot(u_xlat3.xy, u_xlat3.xy);
                  u_xlatb3 = (u_xlat2.x<u_xlat12);
                  u_xlat12 = (u_xlatb3)?(u_xlat2.x):(u_xlat12);
                  u_xlati_loop_6 = (u_xlati_loop_6 + 1);
              }
              u_xlat11.x = u_xlat12;
              u_xlati_loop_5 = (u_xlati_loop_5 + 1);
          }
          u_xlat0_d.x = sqrt(u_xlat11.x);
          u_xlat0_d.x = (u_xlat0_d.x + u_xlat10);
          u_xlat5 = (u_xlat0_d.x * 0.333333343);
          u_xlat0_d.x = (((-u_xlat0_d.x) * 0.333333343) + 0.5);
          u_xlat0_d.x = ((u_xlat0_d.x * 0.5) + u_xlat5);
          u_xlat0_d.x = (u_xlat0_d.x * u_xlat0_d.x);
          u_xlat0_d.x = (u_xlat0_d.x * u_xlat0_d.x);
          u_xlat1_d = (u_xlat0_d.xxxx * _GlowColour);
          u_xlat0_d = (u_xlat0_d.wwww * u_xlat1_d);
          out_f.color = (u_xlat0_d * in_f.color);
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
