Shader "Hidden/PostProcessing/DeferredFog"
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
      
      uniform float4 _ProjectionParams;
      
      uniform float4 unity_OrthoParams;
      
      uniform float4 _ZBufferParams;
      
      uniform float4 _FogColor;
      
      uniform float3 _FogParams;
      
      uniform sampler2D _MainTex;
      
      uniform sampler2D _CameraDepthTexture;
      
      
      
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
      
      float u_xlat0_d;
      
      float4 u_xlat1;
      
      float4 u_xlat2;
      
      float u_xlat3;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = (-unity_OrthoParams.w) + 1.0;
          
          u_xlat1 = texture(_CameraDepthTexture, in_f.texcoord1.xy);
          
          u_xlat3 = u_xlat1.x * _ZBufferParams.x;
          
          u_xlat0_d = u_xlat0_d * u_xlat3 + _ZBufferParams.y;
          
          u_xlat3 = (-unity_OrthoParams.w) * u_xlat3 + 1.0;
          
          u_xlat0_d = u_xlat3 / u_xlat0_d;
          
          u_xlat0_d = u_xlat0_d * _ProjectionParams.z + (-_ProjectionParams.y);
          
          u_xlat0_d = u_xlat0_d * _FogParams.x;
          
          u_xlat0_d = u_xlat0_d * (-u_xlat0_d);
          
          u_xlat0_d = exp2(u_xlat0_d);
          
          u_xlat0_d = (-u_xlat0_d) + 1.0;
          
          u_xlat1 = texture(_MainTex, in_f.texcoord1.xy);
          
          u_xlat2 = (-u_xlat1) + _FogColor;
          
          out_f.color = float4(u_xlat0_d) * u_xlat2 + u_xlat1;
          
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
      
      uniform float4 _ProjectionParams;
      
      uniform float4 unity_OrthoParams;
      
      uniform float4 _ZBufferParams;
      
      uniform float4 _FogColor;
      
      uniform float3 _FogParams;
      
      uniform sampler2D _MainTex;
      
      uniform sampler2D _CameraDepthTexture;
      
      
      
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
      
      float u_xlat0_d;
      
      int u_xlatb0;
      
      float4 u_xlat1;
      
      float4 u_xlat2;
      
      float u_xlat3;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = (-unity_OrthoParams.w) + 1.0;
          
          u_xlat1 = texture(_CameraDepthTexture, in_f.texcoord1.xy);
          
          u_xlat3 = u_xlat1.x * _ZBufferParams.x;
          
          u_xlat0_d = u_xlat0_d * u_xlat3 + _ZBufferParams.y;
          
          u_xlat3 = (-unity_OrthoParams.w) * u_xlat3 + 1.0;
          
          u_xlat0_d = u_xlat3 / u_xlat0_d;
          
          u_xlat3 = u_xlat0_d * _ProjectionParams.z + (-_ProjectionParams.y);
          
          u_xlatb0 = u_xlat0_d<0.999899983;
          
          u_xlat0_d = u_xlatb0 ? 1.0 : float(0.0);
          
          u_xlat3 = u_xlat3 * _FogParams.x;
          
          u_xlat3 = u_xlat3 * (-u_xlat3);
          
          u_xlat3 = exp2(u_xlat3);
          
          u_xlat3 = (-u_xlat3) + 1.0;
          
          u_xlat0_d = u_xlat0_d * u_xlat3;
          
          u_xlat1 = texture(_MainTex, in_f.texcoord1.xy);
          
          u_xlat2 = (-u_xlat1) + _FogColor;
          
          out_f.color = float4(u_xlat0_d) * u_xlat2 + u_xlat1;
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
