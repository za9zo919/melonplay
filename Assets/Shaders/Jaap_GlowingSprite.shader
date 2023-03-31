Shader "Jaap/GlowingSprite"
{
  Properties
  {
    [PerRendererData] _MainTex ("Texture", 2D) = "white" {}
    _GlowMask ("Glow Mask", 2D) = "white" {}
    [HDR] _GlowColour ("Glow Colour", Color) = (1,0,1,1)
    _GlowIntensity ("Glow Intensity", float) = 1
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
      
      
      #define CODE_BLOCK_VERTEX
      //uniform float4x4 unity_ObjectToWorld;
      //uniform float4x4 unity_MatrixVP;
      uniform float4 _MainTex_ST;
      uniform float4 _GlowColour;
      uniform float _GlowIntensity;
      uniform sampler2D _MainTex;
      uniform sampler2D _GlowMask;
      struct appdata_t
      {
          float4 vertex :POSITION0;
          float2 texcoord :TEXCOORD0;
      };
      
      struct OUT_Data_Vert
      {
          float2 texcoord :TEXCOORD0;
          float4 vertex :SV_POSITION;
      };
      
      struct v2f
      {
          float2 texcoord :TEXCOORD0;
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
          out_v.vertex = UnityObjectToClipPos(in_v.vertex);
          return out_v;
      }
      
      #define CODE_BLOCK_FRAGMENT
      float4 u_xlat0_d;
      float4 u_xlat1_d;
      int u_xlatb1;
      float4 u_xlat2;
      float4 u_xlat3;
      float u_xlat5;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlat0_d = tex2D(_MainTex, in_f.texcoord.xy);
          u_xlat1_d.x = (u_xlat0_d.w + (-0.5));
          u_xlatb1 = (u_xlat1_d.x<0);
          if(((int(u_xlatb1) * int(4294967295))!=0))
          {
              discard;
          }
          u_xlat1_d = tex2D(_GlowMask, in_f.texcoord.xy);
          u_xlat2 = (u_xlat1_d * _GlowColour);
          u_xlatb1 = (0<u_xlat1_d.x);
          u_xlat5 = _GlowIntensity;
          u_xlat5 = clamp(u_xlat5, 0, 1);
          u_xlat3 = (((-u_xlat2) * float4(u_xlat5, u_xlat5, u_xlat5, u_xlat5)) + u_xlat0_d);
          u_xlat2 = (float4(u_xlat5, u_xlat5, u_xlat5, u_xlat5) * u_xlat2);
          u_xlat5 = ((-u_xlat5) + 1);
          u_xlat2 = ((float4(u_xlat5, u_xlat5, u_xlat5, u_xlat5) * u_xlat3) + u_xlat2);
          out_f.color = (int(u_xlatb1))?(u_xlat2):(u_xlat0_d);
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
