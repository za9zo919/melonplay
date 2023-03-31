Shader "Hidden/PostProcessing/Bloom"
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
      
      uniform float4 _MainTex_TexelSize;
      
      uniform float4 _Threshold;
      
      uniform float4 _Params;
      
      uniform sampler2D _MainTex;
      
      uniform sampler2D _AutoExposureTex;
      
      
      
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
          
          float2 texcoord : TEXCOORD0;
      
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
      
      float4 u_xlat1;
      
      float4 u_xlat2;
      
      float4 u_xlat3;
      
      float4 u_xlat4;
      
      float4 u_xlat5;
      
      float u_xlat7;
      
      float u_xlat19;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = _MainTex_TexelSize.xyxy * float4(-0.5, -0.5, 0.5, -0.5) + in_f.texcoord.xyxy;
          
          u_xlat0_d = clamp(u_xlat0_d, 0.0, 1.0);
          
          u_xlat0_d = u_xlat0_d * float4(_RenderViewportScaleFactor);
          
          u_xlat1 = texture(_MainTex, u_xlat0_d.xy);
          
          u_xlat0_d = texture(_MainTex, u_xlat0_d.zw);
          
          u_xlat0_d = u_xlat0_d + u_xlat1;
          
          u_xlat1 = _MainTex_TexelSize.xyxy * float4(-0.5, 0.5, 0.5, 0.5) + in_f.texcoord.xyxy;
          
          u_xlat1 = clamp(u_xlat1, 0.0, 1.0);
          
          u_xlat1 = u_xlat1 * float4(_RenderViewportScaleFactor);
          
          u_xlat2 = texture(_MainTex, u_xlat1.xy);
          
          u_xlat1 = texture(_MainTex, u_xlat1.zw);
          
          u_xlat0_d = u_xlat0_d + u_xlat2;
          
          u_xlat0_d = u_xlat1 + u_xlat0_d;
          
          u_xlat1.xy = in_f.texcoord.xy + (-_MainTex_TexelSize.xy);
          
          u_xlat1.xy = clamp(u_xlat1.xy, 0.0, 1.0);
          
          u_xlat1.xy = u_xlat1.xy * float2(_RenderViewportScaleFactor);
          
          u_xlat1 = texture(_MainTex, u_xlat1.xy);
          
          u_xlat2 = _MainTex_TexelSize.xyxy * float4(0.0, -1.0, 1.0, -1.0) + in_f.texcoord.xyxy;
          
          u_xlat2 = clamp(u_xlat2, 0.0, 1.0);
          
          u_xlat2 = u_xlat2 * float4(_RenderViewportScaleFactor);
          
          u_xlat3 = texture(_MainTex, u_xlat2.xy);
          
          u_xlat2 = texture(_MainTex, u_xlat2.zw);
          
          u_xlat2 = u_xlat2 + u_xlat3;
          
          u_xlat1 = u_xlat1 + u_xlat3;
          
          u_xlat3.xy = in_f.texcoord.xy;
          
          u_xlat3.xy = clamp(u_xlat3.xy, 0.0, 1.0);
          
          u_xlat3.xy = u_xlat3.xy * float2(_RenderViewportScaleFactor);
          
          u_xlat3 = texture(_MainTex, u_xlat3.xy);
          
          u_xlat1 = u_xlat1 + u_xlat3;
          
          u_xlat4 = _MainTex_TexelSize.xyxy * float4(-1.0, 0.0, 1.0, 0.0) + in_f.texcoord.xyxy;
          
          u_xlat4 = clamp(u_xlat4, 0.0, 1.0);
          
          u_xlat4 = u_xlat4 * float4(_RenderViewportScaleFactor);
          
          u_xlat5 = texture(_MainTex, u_xlat4.xy);
          
          u_xlat4 = texture(_MainTex, u_xlat4.zw);
          
          u_xlat1 = u_xlat1 + u_xlat5;
          
          u_xlat5 = u_xlat3 + u_xlat5;
          
          u_xlat1 = u_xlat1 * float4(0.03125, 0.03125, 0.03125, 0.03125);
          
          u_xlat0_d = u_xlat0_d * float4(0.125, 0.125, 0.125, 0.125) + u_xlat1;
          
          u_xlat1 = u_xlat2 + u_xlat4;
          
          u_xlat2 = u_xlat3 + u_xlat4;
          
          u_xlat1 = u_xlat3 + u_xlat1;
          
          u_xlat0_d = u_xlat1 * float4(0.03125, 0.03125, 0.03125, 0.03125) + u_xlat0_d;
          
          u_xlat1 = _MainTex_TexelSize.xyxy * float4(-1.0, 1.0, 0.0, 1.0) + in_f.texcoord.xyxy;
          
          u_xlat1 = clamp(u_xlat1, 0.0, 1.0);
          
          u_xlat1 = u_xlat1 * float4(_RenderViewportScaleFactor);
          
          u_xlat3 = texture(_MainTex, u_xlat1.zw);
          
          u_xlat1 = texture(_MainTex, u_xlat1.xy);
          
          u_xlat4 = u_xlat3 + u_xlat5;
          
          u_xlat1 = u_xlat1 + u_xlat4;
          
          u_xlat0_d = u_xlat1 * float4(0.03125, 0.03125, 0.03125, 0.03125) + u_xlat0_d;
          
          u_xlat1.xy = in_f.texcoord.xy + _MainTex_TexelSize.xy;
          
          u_xlat1.xy = clamp(u_xlat1.xy, 0.0, 1.0);
          
          u_xlat1.xy = u_xlat1.xy * float2(_RenderViewportScaleFactor);
          
          u_xlat1 = texture(_MainTex, u_xlat1.xy);
          
          u_xlat1 = u_xlat1 + u_xlat2;
          
          u_xlat1 = u_xlat3 + u_xlat1;
          
          u_xlat0_d = u_xlat1 * float4(0.03125, 0.03125, 0.03125, 0.03125) + u_xlat0_d;
          
          u_xlat0_d = min(u_xlat0_d, float4(65504.0, 65504.0, 65504.0, 65504.0));
          
          u_xlat1 = texture(_AutoExposureTex, in_f.texcoord.xy);
          
          u_xlat0_d = u_xlat0_d * u_xlat1.xxxx;
          
          u_xlat0_d = min(u_xlat0_d, _Params.xxxx);
          
          u_xlat1.x = max(u_xlat0_d.y, u_xlat0_d.x);
          
          u_xlat1.x = max(u_xlat0_d.z, u_xlat1.x);
          
          u_xlat1.yz = u_xlat1.xx + (-_Threshold.yx);
          
          u_xlat1.xy = max(u_xlat1.xy, float2(9.99999975e-05, 0.0));
          
          u_xlat7 = min(u_xlat1.y, _Threshold.z);
          
          u_xlat19 = u_xlat7 * _Threshold.w;
          
          u_xlat7 = u_xlat7 * u_xlat19;
          
          u_xlat7 = max(u_xlat1.z, u_xlat7);
          
          u_xlat1.x = u_xlat7 / u_xlat1.x;
          
          out_f.color = u_xlat0_d * u_xlat1.xxxx;
          
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
      
      uniform float4 _MainTex_TexelSize;
      
      uniform float4 _Threshold;
      
      uniform float4 _Params;
      
      uniform sampler2D _MainTex;
      
      uniform sampler2D _AutoExposureTex;
      
      
      
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
          
          float2 texcoord : TEXCOORD0;
      
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
      
      float4 u_xlat1;
      
      float4 u_xlat2;
      
      float u_xlat4;
      
      float u_xlat10;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = _MainTex_TexelSize.xyxy * float4(-1.0, -1.0, 1.0, -1.0) + in_f.texcoord.xyxy;
          
          u_xlat0_d = clamp(u_xlat0_d, 0.0, 1.0);
          
          u_xlat0_d = u_xlat0_d * float4(_RenderViewportScaleFactor);
          
          u_xlat1 = texture(_MainTex, u_xlat0_d.xy);
          
          u_xlat0_d = texture(_MainTex, u_xlat0_d.zw);
          
          u_xlat0_d = u_xlat0_d + u_xlat1;
          
          u_xlat1 = _MainTex_TexelSize.xyxy * float4(-1.0, 1.0, 1.0, 1.0) + in_f.texcoord.xyxy;
          
          u_xlat1 = clamp(u_xlat1, 0.0, 1.0);
          
          u_xlat1 = u_xlat1 * float4(_RenderViewportScaleFactor);
          
          u_xlat2 = texture(_MainTex, u_xlat1.xy);
          
          u_xlat1 = texture(_MainTex, u_xlat1.zw);
          
          u_xlat0_d = u_xlat0_d + u_xlat2;
          
          u_xlat0_d = u_xlat1 + u_xlat0_d;
          
          u_xlat0_d = u_xlat0_d * float4(0.25, 0.25, 0.25, 0.25);
          
          u_xlat0_d = min(u_xlat0_d, float4(65504.0, 65504.0, 65504.0, 65504.0));
          
          u_xlat1 = texture(_AutoExposureTex, in_f.texcoord.xy);
          
          u_xlat0_d = u_xlat0_d * u_xlat1.xxxx;
          
          u_xlat0_d = min(u_xlat0_d, _Params.xxxx);
          
          u_xlat1.x = max(u_xlat0_d.y, u_xlat0_d.x);
          
          u_xlat1.x = max(u_xlat0_d.z, u_xlat1.x);
          
          u_xlat1.yz = u_xlat1.xx + (-_Threshold.yx);
          
          u_xlat1.xy = max(u_xlat1.xy, float2(9.99999975e-05, 0.0));
          
          u_xlat4 = min(u_xlat1.y, _Threshold.z);
          
          u_xlat10 = u_xlat4 * _Threshold.w;
          
          u_xlat4 = u_xlat4 * u_xlat10;
          
          u_xlat4 = max(u_xlat1.z, u_xlat4);
          
          u_xlat1.x = u_xlat4 / u_xlat1.x;
          
          out_f.color = u_xlat0_d * u_xlat1.xxxx;
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
    Pass // ind: 3, name: 
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
      
      uniform float4 _MainTex_TexelSize;
      
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
          
          float2 texcoord : TEXCOORD0;
      
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
      
      float4 u_xlat1;
      
      float4 u_xlat2;
      
      float4 u_xlat3;
      
      float4 u_xlat4;
      
      float4 u_xlat5;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = _MainTex_TexelSize.xyxy * float4(-0.5, -0.5, 0.5, -0.5) + in_f.texcoord.xyxy;
          
          u_xlat0_d = clamp(u_xlat0_d, 0.0, 1.0);
          
          u_xlat0_d = u_xlat0_d * float4(_RenderViewportScaleFactor);
          
          u_xlat1 = texture(_MainTex, u_xlat0_d.xy);
          
          u_xlat0_d = texture(_MainTex, u_xlat0_d.zw);
          
          u_xlat0_d = u_xlat0_d + u_xlat1;
          
          u_xlat1 = _MainTex_TexelSize.xyxy * float4(-0.5, 0.5, 0.5, 0.5) + in_f.texcoord.xyxy;
          
          u_xlat1 = clamp(u_xlat1, 0.0, 1.0);
          
          u_xlat1 = u_xlat1 * float4(_RenderViewportScaleFactor);
          
          u_xlat2 = texture(_MainTex, u_xlat1.xy);
          
          u_xlat1 = texture(_MainTex, u_xlat1.zw);
          
          u_xlat0_d = u_xlat0_d + u_xlat2;
          
          u_xlat0_d = u_xlat1 + u_xlat0_d;
          
          u_xlat1.xy = in_f.texcoord.xy + (-_MainTex_TexelSize.xy);
          
          u_xlat1.xy = clamp(u_xlat1.xy, 0.0, 1.0);
          
          u_xlat1.xy = u_xlat1.xy * float2(_RenderViewportScaleFactor);
          
          u_xlat1 = texture(_MainTex, u_xlat1.xy);
          
          u_xlat2 = _MainTex_TexelSize.xyxy * float4(0.0, -1.0, 1.0, -1.0) + in_f.texcoord.xyxy;
          
          u_xlat2 = clamp(u_xlat2, 0.0, 1.0);
          
          u_xlat2 = u_xlat2 * float4(_RenderViewportScaleFactor);
          
          u_xlat3 = texture(_MainTex, u_xlat2.xy);
          
          u_xlat2 = texture(_MainTex, u_xlat2.zw);
          
          u_xlat2 = u_xlat2 + u_xlat3;
          
          u_xlat1 = u_xlat1 + u_xlat3;
          
          u_xlat3.xy = in_f.texcoord.xy;
          
          u_xlat3.xy = clamp(u_xlat3.xy, 0.0, 1.0);
          
          u_xlat3.xy = u_xlat3.xy * float2(_RenderViewportScaleFactor);
          
          u_xlat3 = texture(_MainTex, u_xlat3.xy);
          
          u_xlat1 = u_xlat1 + u_xlat3;
          
          u_xlat4 = _MainTex_TexelSize.xyxy * float4(-1.0, 0.0, 1.0, 0.0) + in_f.texcoord.xyxy;
          
          u_xlat4 = clamp(u_xlat4, 0.0, 1.0);
          
          u_xlat4 = u_xlat4 * float4(_RenderViewportScaleFactor);
          
          u_xlat5 = texture(_MainTex, u_xlat4.xy);
          
          u_xlat4 = texture(_MainTex, u_xlat4.zw);
          
          u_xlat1 = u_xlat1 + u_xlat5;
          
          u_xlat5 = u_xlat3 + u_xlat5;
          
          u_xlat1 = u_xlat1 * float4(0.03125, 0.03125, 0.03125, 0.03125);
          
          u_xlat0_d = u_xlat0_d * float4(0.125, 0.125, 0.125, 0.125) + u_xlat1;
          
          u_xlat1 = u_xlat2 + u_xlat4;
          
          u_xlat2 = u_xlat3 + u_xlat4;
          
          u_xlat1 = u_xlat3 + u_xlat1;
          
          u_xlat0_d = u_xlat1 * float4(0.03125, 0.03125, 0.03125, 0.03125) + u_xlat0_d;
          
          u_xlat1 = _MainTex_TexelSize.xyxy * float4(-1.0, 1.0, 0.0, 1.0) + in_f.texcoord.xyxy;
          
          u_xlat1 = clamp(u_xlat1, 0.0, 1.0);
          
          u_xlat1 = u_xlat1 * float4(_RenderViewportScaleFactor);
          
          u_xlat3 = texture(_MainTex, u_xlat1.zw);
          
          u_xlat1 = texture(_MainTex, u_xlat1.xy);
          
          u_xlat4 = u_xlat3 + u_xlat5;
          
          u_xlat1 = u_xlat1 + u_xlat4;
          
          u_xlat0_d = u_xlat1 * float4(0.03125, 0.03125, 0.03125, 0.03125) + u_xlat0_d;
          
          u_xlat1.xy = in_f.texcoord.xy + _MainTex_TexelSize.xy;
          
          u_xlat1.xy = clamp(u_xlat1.xy, 0.0, 1.0);
          
          u_xlat1.xy = u_xlat1.xy * float2(_RenderViewportScaleFactor);
          
          u_xlat1 = texture(_MainTex, u_xlat1.xy);
          
          u_xlat1 = u_xlat1 + u_xlat2;
          
          u_xlat1 = u_xlat3 + u_xlat1;
          
          out_f.color = u_xlat1 * float4(0.03125, 0.03125, 0.03125, 0.03125) + u_xlat0_d;
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
    Pass // ind: 4, name: 
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
      
      uniform float4 _MainTex_TexelSize;
      
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
          
          float2 texcoord : TEXCOORD0;
      
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
      
      float4 u_xlat1;
      
      float4 u_xlat2;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = _MainTex_TexelSize.xyxy * float4(-1.0, -1.0, 1.0, -1.0) + in_f.texcoord.xyxy;
          
          u_xlat0_d = clamp(u_xlat0_d, 0.0, 1.0);
          
          u_xlat0_d = u_xlat0_d * float4(_RenderViewportScaleFactor);
          
          u_xlat1 = texture(_MainTex, u_xlat0_d.xy);
          
          u_xlat0_d = texture(_MainTex, u_xlat0_d.zw);
          
          u_xlat0_d = u_xlat0_d + u_xlat1;
          
          u_xlat1 = _MainTex_TexelSize.xyxy * float4(-1.0, 1.0, 1.0, 1.0) + in_f.texcoord.xyxy;
          
          u_xlat1 = clamp(u_xlat1, 0.0, 1.0);
          
          u_xlat1 = u_xlat1 * float4(_RenderViewportScaleFactor);
          
          u_xlat2 = texture(_MainTex, u_xlat1.xy);
          
          u_xlat1 = texture(_MainTex, u_xlat1.zw);
          
          u_xlat0_d = u_xlat0_d + u_xlat2;
          
          u_xlat0_d = u_xlat1 + u_xlat0_d;
          
          out_f.color = u_xlat0_d * float4(0.25, 0.25, 0.25, 0.25);
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
    Pass // ind: 5, name: 
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
      
      uniform float4 _MainTex_TexelSize;
      
      uniform float _SampleScale;
      
      uniform sampler2D _MainTex;
      
      uniform sampler2D _BloomTex;
      
      
      
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
          
          float2 texcoord : TEXCOORD0;
          
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
      
      float4 u_xlat1;
      
      float4 u_xlat2;
      
      float4 u_xlat3;
      
      float4 u_xlat4;
      
      float4 u_xlat5;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d.xy = in_f.texcoord.xy;
          
          u_xlat0_d.xy = clamp(u_xlat0_d.xy, 0.0, 1.0);
          
          u_xlat0_d.xy = u_xlat0_d.xy * float2(_RenderViewportScaleFactor);
          
          u_xlat0_d = texture(_MainTex, u_xlat0_d.xy);
          
          u_xlat1.x = 1.0;
          
          u_xlat1.z = _SampleScale;
          
          u_xlat1 = u_xlat1.xxzz * _MainTex_TexelSize.xyxy;
          
          u_xlat2.z = float(-1.0);
          
          u_xlat2.w = float(0.0);
          
          u_xlat2.x = _SampleScale;
          
          u_xlat3 = (-u_xlat1.xywy) * u_xlat2.xxwx + in_f.texcoord.xyxy;
          
          u_xlat3 = clamp(u_xlat3, 0.0, 1.0);
          
          u_xlat3 = u_xlat3 * float4(_RenderViewportScaleFactor);
          
          u_xlat4 = texture(_MainTex, u_xlat3.xy);
          
          u_xlat3 = texture(_MainTex, u_xlat3.zw);
          
          u_xlat3 = u_xlat3 * float4(2.0, 2.0, 2.0, 2.0) + u_xlat4;
          
          u_xlat4.xy = (-u_xlat1.zy) * u_xlat2.zx + in_f.texcoord.xy;
          
          u_xlat4.xy = clamp(u_xlat4.xy, 0.0, 1.0);
          
          u_xlat4.xy = u_xlat4.xy * float2(_RenderViewportScaleFactor);
          
          u_xlat4 = texture(_MainTex, u_xlat4.xy);
          
          u_xlat3 = u_xlat3 + u_xlat4;
          
          u_xlat4 = u_xlat1.zwxw * u_xlat2.zwxw + in_f.texcoord.xyxy;
          
          u_xlat4 = clamp(u_xlat4, 0.0, 1.0);
          
          u_xlat5 = u_xlat1.zywy * u_xlat2.zxwx + in_f.texcoord.xyxy;
          
          u_xlat5 = clamp(u_xlat5, 0.0, 1.0);
          
          u_xlat1.xy = u_xlat1.xy * u_xlat2.xx + in_f.texcoord.xy;
          
          u_xlat1.xy = clamp(u_xlat1.xy, 0.0, 1.0);
          
          u_xlat1.xy = u_xlat1.xy * float2(_RenderViewportScaleFactor);
          
          u_xlat1 = texture(_MainTex, u_xlat1.xy);
          
          u_xlat2 = u_xlat5 * float4(_RenderViewportScaleFactor);
          
          u_xlat4 = u_xlat4 * float4(_RenderViewportScaleFactor);
          
          u_xlat5 = texture(_MainTex, u_xlat4.xy);
          
          u_xlat4 = texture(_MainTex, u_xlat4.zw);
          
          u_xlat3 = u_xlat5 * float4(2.0, 2.0, 2.0, 2.0) + u_xlat3;
          
          u_xlat0_d = u_xlat0_d * float4(4.0, 4.0, 4.0, 4.0) + u_xlat3;
          
          u_xlat0_d = u_xlat4 * float4(2.0, 2.0, 2.0, 2.0) + u_xlat0_d;
          
          u_xlat3 = texture(_MainTex, u_xlat2.xy);
          
          u_xlat2 = texture(_MainTex, u_xlat2.zw);
          
          u_xlat0_d = u_xlat0_d + u_xlat3;
          
          u_xlat0_d = u_xlat2 * float4(2.0, 2.0, 2.0, 2.0) + u_xlat0_d;
          
          u_xlat0_d = u_xlat1 + u_xlat0_d;
          
          u_xlat1 = texture(_BloomTex, in_f.texcoord1.xy);
          
          out_f.color = u_xlat0_d * float4(0.0625, 0.0625, 0.0625, 0.0625) + u_xlat1;
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
    Pass // ind: 6, name: 
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
      
      uniform float4 _MainTex_TexelSize;
      
      uniform float _SampleScale;
      
      uniform sampler2D _MainTex;
      
      uniform sampler2D _BloomTex;
      
      
      
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
          
          float2 texcoord : TEXCOORD0;
          
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
      
      float4 u_xlat1;
      
      float4 u_xlat2;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = _MainTex_TexelSize.xyxy * float4(-1.0, -1.0, 1.0, 1.0);
          
          u_xlat1.x = _SampleScale * 0.5;
          
          u_xlat2 = u_xlat0_d.xyzy * u_xlat1.xxxx + in_f.texcoord.xyxy;
          
          u_xlat2 = clamp(u_xlat2, 0.0, 1.0);
          
          u_xlat0_d = u_xlat0_d.xwzw * u_xlat1.xxxx + in_f.texcoord.xyxy;
          
          u_xlat0_d = clamp(u_xlat0_d, 0.0, 1.0);
          
          u_xlat0_d = u_xlat0_d * float4(_RenderViewportScaleFactor);
          
          u_xlat1 = u_xlat2 * float4(_RenderViewportScaleFactor);
          
          u_xlat2 = texture(_MainTex, u_xlat1.xy);
          
          u_xlat1 = texture(_MainTex, u_xlat1.zw);
          
          u_xlat1 = u_xlat1 + u_xlat2;
          
          u_xlat2 = texture(_MainTex, u_xlat0_d.xy);
          
          u_xlat0_d = texture(_MainTex, u_xlat0_d.zw);
          
          u_xlat1 = u_xlat1 + u_xlat2;
          
          u_xlat0_d = u_xlat0_d + u_xlat1;
          
          u_xlat1 = texture(_BloomTex, in_f.texcoord1.xy);
          
          out_f.color = u_xlat0_d * float4(0.25, 0.25, 0.25, 0.25) + u_xlat1;
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
    Pass // ind: 7, name: 
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
      
      uniform float4 _Threshold;
      
      uniform float4 _Params;
      
      uniform sampler2D _MainTex;
      
      uniform sampler2D _AutoExposureTex;
      
      
      
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
          
          float2 texcoord : TEXCOORD0;
          
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
      
      float4 u_xlat1;
      
      float u_xlat5;
      
      float u_xlat6;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = texture(_MainTex, in_f.texcoord1.xy);
          
          u_xlat0_d.xyz = min(u_xlat0_d.xyz, float3(65504.0, 65504.0, 65504.0));
          
          u_xlat1 = texture(_AutoExposureTex, in_f.texcoord.xy);
          
          u_xlat0_d.xyz = u_xlat0_d.xyz * u_xlat1.xxx;
          
          u_xlat0_d.xyz = min(u_xlat0_d.xyz, _Params.xxx);
          
          u_xlat6 = max(u_xlat0_d.y, u_xlat0_d.x);
          
          u_xlat6 = max(u_xlat0_d.z, u_xlat6);
          
          u_xlat1.xy = float2(u_xlat6) + (-_Threshold.yx);
          
          u_xlat6 = max(u_xlat6, 9.99999975e-05);
          
          u_xlat1.x = max(u_xlat1.x, 0.0);
          
          u_xlat1.x = min(u_xlat1.x, _Threshold.z);
          
          u_xlat5 = u_xlat1.x * _Threshold.w;
          
          u_xlat1.x = u_xlat1.x * u_xlat5;
          
          u_xlat1.x = max(u_xlat1.y, u_xlat1.x);
          
          u_xlat6 = u_xlat1.x / u_xlat6;
          
          out_f.color.xyz = float3(u_xlat6) * u_xlat0_d.xyz;
          
          out_f.color.w = 1.0;
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
    Pass // ind: 8, name: 
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
      
      uniform float4 _MainTex_TexelSize;
      
      uniform float _SampleScale;
      
      uniform float4 _ColorIntensity;
      
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
          
          float2 texcoord : TEXCOORD0;
      
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
      
      float4 u_xlat1;
      
      float4 u_xlat2;
      
      float4 u_xlat3;
      
      float4 u_xlat4;
      
      float4 u_xlat5;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d.xy = in_f.texcoord.xy;
          
          u_xlat0_d.xy = clamp(u_xlat0_d.xy, 0.0, 1.0);
          
          u_xlat0_d.xy = u_xlat0_d.xy * float2(_RenderViewportScaleFactor);
          
          u_xlat0_d = texture(_MainTex, u_xlat0_d.xy);
          
          u_xlat1.x = 1.0;
          
          u_xlat1.z = _SampleScale;
          
          u_xlat1 = u_xlat1.xxzz * _MainTex_TexelSize.xyxy;
          
          u_xlat2.z = float(-1.0);
          
          u_xlat2.w = float(0.0);
          
          u_xlat2.x = _SampleScale;
          
          u_xlat3 = (-u_xlat1.xywy) * u_xlat2.xxwx + in_f.texcoord.xyxy;
          
          u_xlat3 = clamp(u_xlat3, 0.0, 1.0);
          
          u_xlat3 = u_xlat3 * float4(_RenderViewportScaleFactor);
          
          u_xlat4 = texture(_MainTex, u_xlat3.xy);
          
          u_xlat3 = texture(_MainTex, u_xlat3.zw);
          
          u_xlat3.xyz = u_xlat3.xyz * float3(2.0, 2.0, 2.0) + u_xlat4.xyz;
          
          u_xlat4.xy = (-u_xlat1.zy) * u_xlat2.zx + in_f.texcoord.xy;
          
          u_xlat4.xy = clamp(u_xlat4.xy, 0.0, 1.0);
          
          u_xlat4.xy = u_xlat4.xy * float2(_RenderViewportScaleFactor);
          
          u_xlat4 = texture(_MainTex, u_xlat4.xy);
          
          u_xlat3.xyz = u_xlat3.xyz + u_xlat4.xyz;
          
          u_xlat4 = u_xlat1.zwxw * u_xlat2.zwxw + in_f.texcoord.xyxy;
          
          u_xlat4 = clamp(u_xlat4, 0.0, 1.0);
          
          u_xlat5 = u_xlat1.zywy * u_xlat2.zxwx + in_f.texcoord.xyxy;
          
          u_xlat5 = clamp(u_xlat5, 0.0, 1.0);
          
          u_xlat1.xy = u_xlat1.xy * u_xlat2.xx + in_f.texcoord.xy;
          
          u_xlat1.xy = clamp(u_xlat1.xy, 0.0, 1.0);
          
          u_xlat1.xy = u_xlat1.xy * float2(_RenderViewportScaleFactor);
          
          u_xlat1 = texture(_MainTex, u_xlat1.xy);
          
          u_xlat2 = u_xlat5 * float4(_RenderViewportScaleFactor);
          
          u_xlat4 = u_xlat4 * float4(_RenderViewportScaleFactor);
          
          u_xlat5 = texture(_MainTex, u_xlat4.xy);
          
          u_xlat4 = texture(_MainTex, u_xlat4.zw);
          
          u_xlat3.xyz = u_xlat5.xyz * float3(2.0, 2.0, 2.0) + u_xlat3.xyz;
          
          u_xlat0_d.xyz = u_xlat0_d.xyz * float3(4.0, 4.0, 4.0) + u_xlat3.xyz;
          
          u_xlat0_d.xyz = u_xlat4.xyz * float3(2.0, 2.0, 2.0) + u_xlat0_d.xyz;
          
          u_xlat3 = texture(_MainTex, u_xlat2.xy);
          
          u_xlat2 = texture(_MainTex, u_xlat2.zw);
          
          u_xlat0_d.xyz = u_xlat0_d.xyz + u_xlat3.xyz;
          
          u_xlat0_d.xyz = u_xlat2.xyz * float3(2.0, 2.0, 2.0) + u_xlat0_d.xyz;
          
          u_xlat0_d.xyz = u_xlat1.xyz + u_xlat0_d.xyz;
          
          u_xlat0_d.xyz = u_xlat0_d.xyz * float3(0.0625, 0.0625, 0.0625);
          
          u_xlat0_d.xyz = u_xlat0_d.xyz * _ColorIntensity.www;
          
          out_f.color.xyz = u_xlat0_d.xyz * _ColorIntensity.xyz;
          
          out_f.color.w = 1.0;
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
    Pass // ind: 9, name: 
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
      
      uniform float4 _MainTex_TexelSize;
      
      uniform float _SampleScale;
      
      uniform float4 _ColorIntensity;
      
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
          
          float2 texcoord : TEXCOORD0;
      
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
      
      float4 u_xlat1;
      
      float4 u_xlat2;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = _MainTex_TexelSize.xyxy * float4(-1.0, -1.0, 1.0, 1.0);
          
          u_xlat1.x = _SampleScale * 0.5;
          
          u_xlat2 = u_xlat0_d.xyzy * u_xlat1.xxxx + in_f.texcoord.xyxy;
          
          u_xlat2 = clamp(u_xlat2, 0.0, 1.0);
          
          u_xlat0_d = u_xlat0_d.xwzw * u_xlat1.xxxx + in_f.texcoord.xyxy;
          
          u_xlat0_d = clamp(u_xlat0_d, 0.0, 1.0);
          
          u_xlat0_d = u_xlat0_d * float4(_RenderViewportScaleFactor);
          
          u_xlat1 = u_xlat2 * float4(_RenderViewportScaleFactor);
          
          u_xlat2 = texture(_MainTex, u_xlat1.xy);
          
          u_xlat1 = texture(_MainTex, u_xlat1.zw);
          
          u_xlat1.xyz = u_xlat1.xyz + u_xlat2.xyz;
          
          u_xlat2 = texture(_MainTex, u_xlat0_d.xy);
          
          u_xlat0_d = texture(_MainTex, u_xlat0_d.zw);
          
          u_xlat1.xyz = u_xlat1.xyz + u_xlat2.xyz;
          
          u_xlat0_d.xyz = u_xlat0_d.xyz + u_xlat1.xyz;
          
          u_xlat0_d.xyz = u_xlat0_d.xyz * float3(0.25, 0.25, 0.25);
          
          u_xlat0_d.xyz = u_xlat0_d.xyz * _ColorIntensity.www;
          
          out_f.color.xyz = u_xlat0_d.xyz * _ColorIntensity.xyz;
          
          out_f.color.w = 1.0;
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
