Shader "Unlit/ChainsawShader"
{
  Properties
  {
    _MainTex ("Texture", 2D) = "white" {}
    _Chain ("Chain", 2D) = "white" {}
    _Position ("Chain position", float) = 0
    _ChainFreq ("Movement freq", float) = 20
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
      uniform float _ChainFreq;
      uniform float _Position;
      uniform sampler2D _MainTex;
      uniform sampler2D _Chain;
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
          out_v.texcoord.xy = TRANSFORM_TEX(in_v.texcoord.xy, _MainTex);
          out_v.vertex = UnityObjectToClipPos(in_v.vertex);
          out_v.color = in_v.color;
          return out_v;
      }
      
      #define CODE_BLOCK_FRAGMENT
      float4 u_xlat0_d;
      float u_xlat1_d;
      int u_xlatb1;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlat0_d = tex2D(_MainTex, in_f.texcoord.xy);
          u_xlat1_d = (u_xlat0_d.w + (-0.5));
          u_xlatb1 = (u_xlat1_d<0);
          if(((int(u_xlatb1) * int(4294967295))!=0))
          {
              discard;
          }
          u_xlatb1 = (0<u_xlat0_d.w);
          u_xlat0_d.x = ((u_xlat0_d.x * _ChainFreq) + (-_Position));
          u_xlat0_d.x = (u_xlatb1)?(u_xlat0_d.x):(float(0));
          u_xlat0_d.y = 0;
          u_xlat0_d = tex2D(_Chain, u_xlat0_d.xy);
          out_f.color = (u_xlat0_d * in_f.color);
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
