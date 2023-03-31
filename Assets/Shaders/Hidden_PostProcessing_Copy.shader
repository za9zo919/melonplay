Shader "Hidden/PostProcessing/Copy"
{
  Properties
  {
  }
  SubShader
  {
    Tags
    { 
    }
    Pass // ind: 1, name: 
    {
      Tags
      { 
      }
      ZTest Always
      ZWrite Off
      Cull Off
      // m_ProgramMask = 6
      CGPROGRAM
      //#pragma target 4.0
      
      #pragma vertex vert
      #pragma fragment frag
      
      #include "UnityCG.cginc"
      
      
      #define CODE_BLOCK_VERTEX
      
      
      uniform float _RenderViewportScaleFactor;
      
      uniform sampler2D _MainTex;
      
      
      
      struct appdata_t
      {
          
          float3 vertex : POSITION0;
      
      };
      
      
      struct OUT_Data_Vert
      {
          
          float2 texcoord : TEXCOORD0;
          
          float2 texcoord1 : TEXCOORD1;
          
          float4 vertex : SV_POSITION;
      
      };
      
      
      struct v2f
      {
          
          float2 texcoord1 : TEXCOORD1;
      
      };
      
      
      struct OUT_Data_Frag
      {
          
          float4 color : SV_Target0;
      
      };
      
      
      float2 u_xlat0;
      
      OUT_Data_Vert vert(appdata_t in_v)
      {
          
          out_v.vertex.xy = in_v.vertex.xy;
          
          out_v.vertex.zw = float2(0.0, 1.0);
          
          u_xlat0.xy = in_v.vertex.xy + float2(1.0, 1.0);
          
          u_xlat0.xy = u_xlat0.xy * float2(0.5, 0.5);
          
          out_v.texcoord1.xy = u_xlat0.xy * float2(_RenderViewportScaleFactor);
          
          out_v.texcoord.xy = in_v.vertex.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
          
          return;
      
      }
      
      
      #define CODE_BLOCK_FRAGMENT
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          out_f.color = texture(_MainTex, in_f.texcoord1.xy);
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
    Pass // ind: 2, name: 
    {
      Tags
      { 
      }
      ZTest Always
      ZWrite Off
      Cull Off
      // m_ProgramMask = 6
      CGPROGRAM
      //#pragma target 4.0
      
      #pragma vertex vert
      #pragma fragment frag
      
      #include "UnityCG.cginc"
      
      
      #define CODE_BLOCK_VERTEX
      
      
      uniform float _RenderViewportScaleFactor;
      
      uniform sampler2D _MainTex;
      
      
      
      struct appdata_t
      {
          
          float3 vertex : POSITION0;
      
      };
      
      
      struct OUT_Data_Vert
      {
          
          float2 texcoord : TEXCOORD0;
          
          float2 texcoord1 : TEXCOORD1;
          
          float4 vertex : SV_POSITION;
      
      };
      
      
      struct v2f
      {
          
          float2 texcoord1 : TEXCOORD1;
      
      };
      
      
      struct OUT_Data_Frag
      {
          
          float4 color : SV_Target0;
      
      };
      
      
      float2 u_xlat0;
      
      OUT_Data_Vert vert(appdata_t in_v)
      {
          
          out_v.vertex.xy = in_v.vertex.xy;
          
          out_v.vertex.zw = float2(0.0, 1.0);
          
          u_xlat0.xy = in_v.vertex.xy + float2(1.0, 1.0);
          
          u_xlat0.xy = u_xlat0.xy * float2(0.5, 0.5);
          
          out_v.texcoord1.xy = u_xlat0.xy * float2(_RenderViewportScaleFactor);
          
          out_v.texcoord.xy = in_v.vertex.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
          
          return;
      
      }
      
      
      #define CODE_BLOCK_FRAGMENT
      
      float4 u_xlat0_d;
      
      int4 u_xlati1;
      
      bool4 u_xlatb1;
      
      bool4 u_xlatb2;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = texture(_MainTex, in_f.texcoord1.xy);
          
          u_xlatb1 = lessThan(u_xlat0_d, float4(0.0, 0.0, 0.0, 0.0));
          
          u_xlatb2 = lessThan(float4(0.0, 0.0, 0.0, 0.0), u_xlat0_d);
          
          u_xlati1 = int4((uint4(u_xlatb1) * 0xffffffffu) | (uint4(u_xlatb2) * 0xffffffffu));
          
          u_xlatb2 = equal(u_xlat0_d, float4(0.0, 0.0, 0.0, 0.0));
          
          u_xlati1 = int4(uint4(u_xlati1) | (uint4(u_xlatb2) * 0xffffffffu));
          
          u_xlatb1 = equal(u_xlati1, int4(0, 0, 0, 0));
          
          u_xlatb1.x = u_xlatb1.y || u_xlatb1.x;
          
          u_xlatb1.x = u_xlatb1.z || u_xlatb1.x;
          
          u_xlatb1.x = u_xlatb1.w || u_xlatb1.x;
          
          out_f.color = (u_xlatb1.x) ? float4(0.0, 0.0, 0.0, 0.0) : u_xlat0_d;
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
