Shader "Unlit/GravitationalLensingShader"
{
  Properties
  {
    _MainTex ("Texture", 2D) = "white" {}
    _NormalTex ("Texture", 2D) = "white" {}
    _DistortIntensity ("Distort Intensity", float) = 1
  }
  SubShader
  {
    Tags
    { 
      "QUEUE" = "Overlay+1"
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
        "QUEUE" = "Overlay+1"
      }
      ZTest Always
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
      uniform float _DistortIntensity;
      uniform sampler2D _NormalTex;
      uniform sampler2D _BackgroundTexture;
      struct appdata_t
      {
          float4 vertex :POSITION0;
          float2 texcoord :TEXCOORD0;
      };
      
      struct OUT_Data_Vert
      {
          float2 texcoord :TEXCOORD0;
          float4 texcoord3 :TEXCOORD3;
          float4 texcoord4 :TEXCOORD4;
          float4 vertex :SV_POSITION;
      };
      
      struct v2f
      {
          float2 texcoord :TEXCOORD0;
          float4 texcoord3 :TEXCOORD3;
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
          u_xlat0 = UnityObjectToClipPos(in_v.vertex);
          u_xlat1.xyz = (u_xlat0.xyw * float3(0.5, 0.5, 0.5));
          u_xlat1.xy = (u_xlat1.zz + u_xlat1.xy);
          u_xlat1.zw = u_xlat0.zw;
          out_v.vertex = u_xlat0;
          out_v.texcoord3 = u_xlat1;
          out_v.texcoord4 = u_xlat1;
          return out_v;
      }
      
      #define CODE_BLOCK_FRAGMENT
      float4 u_xlat0_d;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlat0_d = tex2D(_NormalTex, in_f.texcoord.xy);
          u_xlat0_d.xy = (u_xlat0_d.xy + float2(-0.5, (-0.5)));
          u_xlat0_d.xy = (u_xlat0_d.ww * u_xlat0_d.xy);
          u_xlat0_d.xy = ((u_xlat0_d.xy * float2(_DistortIntensity, _DistortIntensity)) + in_f.texcoord3.xy);
          out_f.color = tex2D(_BackgroundTexture, u_xlat0_d.xy);
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
