Shader "Jaap/UseWire"
{
  Properties
  {
    _MainTex ("Texture", 2D) = "white" {}
    _GlowTime ("Glow time", float) = 1
    [HDR] _GlowColour ("Glow Colour", Color) = (1,0,1,1)
    [PerRendererData] _Timestamp ("Timestamp", float) = 0
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
      //uniform float4 _Time;
      uniform float _GlowTime;
      uniform float _Timestamp;
      uniform float4 _GlowColour;
      uniform sampler2D _MainTex;
      struct appdata_t
      {
          float4 vertex :POSITION0;
          float2 texcoord :TEXCOORD0;
          float4 color :COLOR0;
      };
      
      struct OUT_Data_Vert
      {
          float2 texcoord :TEXCOORD0;
          float4 color :COLOR0;
          float4 vertex :SV_POSITION;
      };
      
      struct v2f
      {
          float2 texcoord :TEXCOORD0;
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
          out_v.vertex = UnityObjectToClipPos(in_v.vertex);
          out_v.texcoord.xy = TRANSFORM_TEX(in_v.texcoord.xy, _MainTex);
          out_v.color = in_v.color;
          return out_v;
      }
      
      #define CODE_BLOCK_FRAGMENT
      float4 u_xlat0_d;
      float4 u_xlat1_d;
      float4 u_xlat2;
      float u_xlat3;
      int u_xlatb3;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlat0_d.x = (_Time.y + (-_Timestamp));
          u_xlat0_d.x = (u_xlat0_d.x / _GlowTime);
          u_xlat0_d.x = clamp(u_xlat0_d.x, 0, 1);
          u_xlat0_d.x = min(u_xlat0_d.x, 0.980000019);
          u_xlat0_d.x = ((-u_xlat0_d.x) + 1);
          u_xlat1_d = tex2D(_MainTex, in_f.texcoord.xy);
          u_xlatb3 = (0.899999976<u_xlat1_d.w);
          u_xlat3 = (u_xlatb3)?(1):(float(0));
          u_xlat0_d.x = (u_xlat3 * u_xlat0_d.x);
          u_xlat1_d.w = 1;
          u_xlat2 = ((_GlowColour * u_xlat1_d) + (-u_xlat1_d));
          u_xlat0_d = ((u_xlat0_d.xxxx * u_xlat2) + u_xlat1_d);
          out_f.color = (u_xlat0_d * in_f.color);
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
