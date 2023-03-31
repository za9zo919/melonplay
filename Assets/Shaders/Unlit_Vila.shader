Shader "Unlit/Vila"
{
  Properties
  {
    [PerRendererData] _MainTex ("1", 2D) = "white" {}
    _Layer2 ("2", 2D) = "white" {}
    _Layer3 ("3", 2D) = "white" {}
    _Layer4 ("4", 2D) = "white" {}
    _Depth ("Depth", float) = 0.2
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
      //uniform float4 _ScreenParams;
      //uniform float4x4 unity_ObjectToWorld;
      //uniform float4x4 unity_MatrixVP;
      uniform float4 _MainTex_ST;
      uniform float _Depth;
      uniform sampler2D _MainTex;
      uniform sampler2D _Layer2;
      uniform sampler2D _Layer3;
      uniform sampler2D _Layer4;
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
      float u_xlat3;
      OUT_Data_Vert vert(appdata_t in_v)
      {
          OUT_Data_Vert out_v;
          out_v.texcoord.xy = TRANSFORM_TEX(in_v.texcoord.xy, _MainTex);
          u_xlat0 = UnityObjectToClipPos(in_v.vertex);
          out_v.vertex = u_xlat0;
          u_xlat1.xyz = (u_xlat0.xyw * float3(0.5, 0.5, 0.5));
          u_xlat0.xy = (u_xlat1.zz + u_xlat1.xy);
          u_xlat1.x = (u_xlat0.x + (-0.5));
          u_xlat3 = (_ScreenParams.x / _ScreenParams.y);
          u_xlat0.x = (u_xlat3 * u_xlat1.x);
          out_v.texcoord1 = (u_xlat0 + float4(0.5, 0, 0, 0));
          return out_v;
      }
      
      #define CODE_BLOCK_FRAGMENT
      float4 u_xlat0_d;
      int u_xlatb0;
      float4 u_xlat1_d;
      float2 u_xlat2;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlat0_d.x = (_Depth * 0.25);
          u_xlat2.xy = ((-in_f.texcoord.xy) + in_f.texcoord1.xy);
          u_xlat0_d.xw = ((u_xlat0_d.xx * u_xlat2.xy) + in_f.texcoord.xy);
          u_xlat1_d = tex2D(_MainTex, u_xlat0_d.xw);
          u_xlatb0 = (0.899999976<u_xlat1_d.w);
          if(u_xlatb0)
          {
              out_f.color = u_xlat1_d;
              return out_f;
          }
          u_xlat0_d.x = (_Depth * 0.5);
          u_xlat0_d.xw = ((u_xlat0_d.xx * u_xlat2.xy) + in_f.texcoord.xy);
          u_xlat1_d = tex2D(_Layer2, u_xlat0_d.xw);
          u_xlatb0 = (0.899999976<u_xlat1_d.w);
          if(u_xlatb0)
          {
              out_f.color = u_xlat1_d;
              return out_f;
          }
          u_xlat0_d.x = (_Depth * 0.75);
          u_xlat0_d.xw = ((u_xlat0_d.xx * u_xlat2.xy) + in_f.texcoord.xy);
          u_xlat1_d = tex2D(_Layer3, u_xlat0_d.xw);
          u_xlatb0 = (0.899999976<u_xlat1_d.w);
          if(u_xlatb0)
          {
              out_f.color = u_xlat1_d;
              return out_f;
          }
          u_xlat0_d.xy = ((float2(_Depth, _Depth) * u_xlat2.xy) + in_f.texcoord.xy);
          out_f.color = tex2D(_Layer4, u_xlat0_d.xy);
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
