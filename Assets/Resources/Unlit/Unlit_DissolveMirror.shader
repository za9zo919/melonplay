Shader "Unlit/DissolveMirror"
{
  Properties
  {
    [PerRendererData] _MainTex ("Texture", 2D) = "white" {}
    _DissolveMap ("Texture", 2D) = "white" {}
    _MapThreshold ("Progress", Vector) = (0,0,0.5,0)
    _Progress ("Progress", float) = 0
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
      uniform float4 _MapThreshold;
      uniform float _Progress;
      uniform sampler2D _MainTex;
      uniform sampler2D _DissolveMap;
      struct appdata_t
      {
          float4 vertex :POSITION0;
          float2 texcoord :TEXCOORD0;
      };
      
      struct OUT_Data_Vert
      {
          float2 texcoord :TEXCOORD0;
          float2 texcoord1 :TEXCOORD1;
          float4 vertex :SV_POSITION;
      };
      
      struct v2f
      {
          float2 texcoord :TEXCOORD0;
          float2 texcoord1 :TEXCOORD1;
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
          out_v.texcoord.xy = in_v.texcoord.xy;
          out_v.texcoord1.xy = (in_v.vertex.xy * float2(0.5, 0.5));
          out_v.vertex = UnityObjectToClipPos(in_v.vertex);
          return out_v;
      }
      
      #define CODE_BLOCK_FRAGMENT
      float4 u_xlat0_d;
      int u_xlatb0;
      float4 u_xlat1_d;
      float3 u_xlatb1;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlat0_d = tex2D(_MainTex, in_f.texcoord.xy);
          u_xlatb1.xyz = bool4(_MapThreshold.xyzx < u_xlat0_d.xyzx).xyz;
          out_f.color = u_xlat0_d;
          u_xlatb0 = (u_xlatb1.y && u_xlatb1.x);
          u_xlatb0 = (u_xlatb1.z && u_xlatb0);
          u_xlat0_d.x = (u_xlatb0)?(_Progress):(float(0));
          u_xlat1_d = tex2D(_DissolveMap, in_f.texcoord1.xy);
          u_xlat0_d.x = ((-u_xlat0_d.x) + u_xlat1_d.x);
          u_xlatb0 = (u_xlat0_d.x<0);
          if(((int(u_xlatb0) * int(4294967295))!=0))
          {
              discard;
          }
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
