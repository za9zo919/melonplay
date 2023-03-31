Shader "Jaap/ForcefieldShader"
{
  Properties
  {
    _MainTex ("Mask", 2D) = "white" {}
    _NormalTexture ("Normal", 2D) = "white" {}
    _Gradient ("Colour gradient", 2D) = "white" {}
    [HDR] _Left ("Left colour", Color) = (1,1,1,1)
    [HDR] _Right ("Right colour", Color) = (1,1,1,1)
  }
  SubShader
  {
    Tags
    { 
      "QUEUE" = "Transparent+1"
      "RenderType" = "Fade"
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
        "RenderType" = "Fade"
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
      uniform float4 _NormalTexture_ST;
      //uniform float4 _Time;
      //uniform float4 _ScreenParams;
      uniform float4 _Left;
      uniform float4 _Right;
      uniform sampler2D _MainTex;
      uniform sampler2D _NormalTexture;
      uniform sampler2D _BackgroundTexture;
      uniform sampler2D _Gradient;
      struct appdata_t
      {
          float4 vertex :POSITION0;
          float2 texcoord :TEXCOORD0;
      };
      
      struct OUT_Data_Vert
      {
          float2 texcoord :TEXCOORD0;
          float2 texcoord2 :TEXCOORD2;
          float4 texcoord1 :TEXCOORD1;
          float4 vertex :SV_POSITION;
      };
      
      struct v2f
      {
          float2 texcoord :TEXCOORD0;
          float4 texcoord1 :TEXCOORD1;
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
          out_v.texcoord.xy = TRANSFORM_TEX(in_v.texcoord.xy, _NormalTexture);
          out_v.texcoord2.xy = in_v.vertex.xy;
          u_xlat0 = UnityObjectToClipPos(in_v.vertex);
          u_xlat1.xyz = (u_xlat0.xyw * float3(0.5, 0.5, 0.5));
          out_v.texcoord1.xy = (u_xlat1.zz + u_xlat1.xy);
          out_v.texcoord1.zw = u_xlat0.zw;
          out_v.vertex = u_xlat0;
          return out_v;
      }
      
      #define CODE_BLOCK_FRAGMENT
      float4 u_xlat0_d;
      int u_xlatb0;
      float4 u_xlat1_d;
      float2 u_xlat2;
      float2 u_xlat4;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlat0_d = tex2D(_MainTex, in_f.texcoord.xy);
          u_xlat0_d.x = (u_xlat0_d.w + (-0.5));
          u_xlatb0 = (u_xlat0_d.x<0);
          if(((int(u_xlatb0) * int(4294967295))!=0))
          {
              discard;
          }
          u_xlat0_d.x = (_Time.x + _Time.x);
          u_xlat2.xy = (in_f.texcoord1.xy * _ScreenParams.xy);
          u_xlat2.xy = (u_xlat2.xy * float2(0.00200000009, 0.00200000009));
          u_xlat1_d = tex2D(_NormalTexture, u_xlat2.xy);
          u_xlat0_d.xy = ((u_xlat1_d.xy * float2(0.5, 0.5)) + u_xlat0_d.xx);
          u_xlat0_d.xy = ((u_xlat1_d.ww * float2(3.5, 3.5)) + u_xlat0_d.xy);
          u_xlat1_d.xyz = ((u_xlat1_d.xyw * float3(0.00999999978, 0.00999999978, 0.00999999978)) + in_f.texcoord1.xyw);
          u_xlat4.xy = (u_xlat1_d.xy / u_xlat1_d.zz);
          u_xlat1_d = tex2D(_BackgroundTexture, u_xlat4.xy);
          u_xlat0_d = tex2D(_Gradient, u_xlat0_d.xy);
          u_xlat0_d = (u_xlat1_d / u_xlat0_d);
          u_xlat1_d = ((-_Left) + _Right);
          u_xlat1_d = ((in_f.texcoord1.xxxx * u_xlat1_d) + _Left);
          u_xlat0_d = (u_xlat0_d * u_xlat1_d);
          out_f.color = (u_xlat0_d * float4(0.199999809, 0.199999809, 0.199999809, 0.199999809));
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
