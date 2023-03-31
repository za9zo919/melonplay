Shader "Unlit/BathroomMirrorShader"
{
  Properties
  {
    _MainTex ("Texture", 2D) = "white" {}
    _Reflection ("Reflection", 2D) = "white" {}
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
      // m_ProgramMask = 6
      CGPROGRAM
      //#pragma target 4.0
      
      #pragma vertex vert
      #pragma fragment frag
      
      #include "UnityCG.cginc"
      
      
      #define CODE_BLOCK_VERTEX
      //uniform float4 _ScreenParams;
      //uniform float4x4 unity_ObjectToWorld;
      //uniform float4x4 unity_MatrixVP;
      uniform float4 _MainTex_ST;
      uniform sampler2D _Reflection;
      uniform sampler2D _MainTex;
      struct appdata_t
      {
          float4 vertex :POSITION0;
          float2 texcoord :TEXCOORD0;
      };
      
      struct OUT_Data_Vert
      {
          float2 texcoord :TEXCOORD0;
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
      float u_xlat2;
      float u_xlat5;
      OUT_Data_Vert vert(appdata_t in_v)
      {
          OUT_Data_Vert out_v;
          out_v.texcoord.xy = TRANSFORM_TEX(in_v.texcoord.xy, _MainTex);
          u_xlat0 = UnityObjectToClipPos(in_v.vertex);
          u_xlat1.xyz = (u_xlat0.xyw * float3(0.5, 0.5, 0.5));
          u_xlat1.xy = (u_xlat1.zz + u_xlat1.xy);
          u_xlat2 = (u_xlat1.x + (-0.5));
          u_xlat5 = (_ScreenParams.x / _ScreenParams.y);
          u_xlat1.x = (u_xlat5 * u_xlat2);
          u_xlat1.zw = u_xlat0.zw;
          out_v.vertex = u_xlat0;
          out_v.texcoord1 = (u_xlat1 + float4(0.5, 0, 0, 0));
          return out_v;
      }
      
      #define CODE_BLOCK_FRAGMENT
      float4 u_xlat0_d;
      float4 u_xlat1_d;
      float2 u_xlat4;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlat0_d.xy = (in_f.texcoord.xy * float2(1.04999995, 1.5));
          u_xlat4.xy = ((in_f.texcoord1.xy * float2(2, 2)) + (-u_xlat0_d.xy));
          u_xlat0_d.xy = ((u_xlat4.xy * float2(0.5, 0.5)) + u_xlat0_d.xy);
          u_xlat0_d = tex2D(_Reflection, u_xlat0_d.xy);
          u_xlat1_d = tex2D(_MainTex, in_f.texcoord.xy);
          out_f.color = (u_xlat0_d * u_xlat1_d);
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
