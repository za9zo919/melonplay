Shader "Hidden/PostProcessing/TemporalAntialiasing"
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
      
      uniform float4 _CameraDepthTexture_TexelSize;
      
      uniform float2 _Jitter;
      
      uniform float4 _FinalBlendParameters;
      
      uniform float _Sharpness;
      
      uniform sampler2D _CameraDepthTexture;
      
      uniform sampler2D _CameraMotionVectorsTexture;
      
      uniform sampler2D _MainTex;
      
      uniform sampler2D _HistoryTex;
      
      
      
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
          
          float4 color1 : SV_Target1;
      
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
      
      float4 u_xlat6;
      
      float3 u_xlat7;
      
      float2 u_xlat14;
      
      int u_xlatb14;
      
      float u_xlat21;
      
      int u_xlatb21;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d.xy = in_f.texcoord1.xy + (-_CameraDepthTexture_TexelSize.xy);
          
          u_xlat0_d.xy = max(u_xlat0_d.xy, float2(0.0, 0.0));
          
          u_xlat0_d.xy = min(u_xlat0_d.xy, float2(_RenderViewportScaleFactor));
          
          u_xlat0_d = texture(_CameraDepthTexture, u_xlat0_d.xy).yzxw;
          
          u_xlat1 = texture(_CameraDepthTexture, in_f.texcoord1.xy).yzxw;
          
          u_xlatb21 = u_xlat0_d.z>=u_xlat1.z;
          
          u_xlat21 = u_xlatb21 ? 1.0 : float(0.0);
          
          u_xlat0_d.x = float(-1.0);
          
          u_xlat0_d.y = float(-1.0);
          
          u_xlat1.x = float(0.0);
          
          u_xlat1.y = float(0.0);
          
          u_xlat0_d.xyz = u_xlat0_d.xyz + (-u_xlat1.yyz);
          
          u_xlat0_d.xyz = float3(u_xlat21) * u_xlat0_d.xyz + u_xlat1.xyz;
          
          u_xlat1.x = float(1.0);
          
          u_xlat1.y = float(-1.0);
          
          u_xlat2 = _CameraDepthTexture_TexelSize.xyxy * float4(1.0, -1.0, -1.0, 1.0) + in_f.texcoord1.xyxy;
          
          u_xlat2 = max(u_xlat2, float4(0.0, 0.0, 0.0, 0.0));
          
          u_xlat2 = min(u_xlat2, float4(_RenderViewportScaleFactor));
          
          u_xlat3 = texture(_CameraDepthTexture, u_xlat2.xy);
          
          u_xlat2 = texture(_CameraDepthTexture, u_xlat2.zw).yzxw;
          
          u_xlat1.z = u_xlat3.x;
          
          u_xlatb21 = u_xlat3.x>=u_xlat0_d.z;
          
          u_xlat21 = u_xlatb21 ? 1.0 : float(0.0);
          
          u_xlat1.xyz = (-u_xlat0_d.yyz) + u_xlat1.xyz;
          
          u_xlat0_d.xyz = float3(u_xlat21) * u_xlat1.xyz + u_xlat0_d.xyz;
          
          u_xlat2.x = float(-1.0);
          
          u_xlat2.y = float(1.0);
          
          u_xlatb21 = u_xlat2.z>=u_xlat0_d.z;
          
          u_xlat21 = u_xlatb21 ? 1.0 : float(0.0);
          
          u_xlat1.xyz = (-u_xlat0_d.xyz) + u_xlat2.xyz;
          
          u_xlat0_d.xyz = float3(u_xlat21) * u_xlat1.xyz + u_xlat0_d.xyz;
          
          u_xlat1.xy = in_f.texcoord1.xy + _CameraDepthTexture_TexelSize.xy;
          
          u_xlat1.xy = max(u_xlat1.xy, float2(0.0, 0.0));
          
          u_xlat1.xy = min(u_xlat1.xy, float2(_RenderViewportScaleFactor));
          
          u_xlat1 = texture(_CameraDepthTexture, u_xlat1.xy);
          
          u_xlatb14 = u_xlat1.x>=u_xlat0_d.z;
          
          u_xlat14.x = u_xlatb14 ? 1.0 : float(0.0);
          
          u_xlat1.xy = (-u_xlat0_d.xy) + float2(1.0, 1.0);
          
          u_xlat0_d.xy = u_xlat14.xx * u_xlat1.xy + u_xlat0_d.xy;
          
          u_xlat0_d.xy = u_xlat0_d.xy * _CameraDepthTexture_TexelSize.xy + in_f.texcoord1.xy;
          
          u_xlat0_d = texture(_CameraMotionVectorsTexture, u_xlat0_d.xy);
          
          u_xlat14.x = dot(u_xlat0_d.xy, u_xlat0_d.xy);
          
          u_xlat0_d.xy = (-u_xlat0_d.xy) + in_f.texcoord1.xy;
          
          u_xlat0_d.xy = max(u_xlat0_d.xy, float2(0.0, 0.0));
          
          u_xlat0_d.xy = min(u_xlat0_d.xy, float2(_RenderViewportScaleFactor));
          
          u_xlat1 = texture(_HistoryTex, u_xlat0_d.xy);
          
          u_xlat0_d.x = sqrt(u_xlat14.x);
          
          u_xlat7.x = u_xlat0_d.x * 100.0;
          
          u_xlat0_d.x = u_xlat0_d.x * _FinalBlendParameters.z;
          
          u_xlat7.x = min(u_xlat7.x, 1.0);
          
          u_xlat7.x = u_xlat7.x * -3.75 + 4.0;
          
          u_xlat14.xy = in_f.texcoord1.xy + (-_Jitter.xy);
          
          u_xlat14.xy = max(u_xlat14.xy, float2(0.0, 0.0));
          
          u_xlat14.xy = min(u_xlat14.xy, float2(_RenderViewportScaleFactor));
          
          u_xlat2.xy = (-_MainTex_TexelSize.xy) * float2(0.5, 0.5) + u_xlat14.xy;
          
          u_xlat2.xy = max(u_xlat2.xy, float2(0.0, 0.0));
          
          u_xlat2.xy = min(u_xlat2.xy, float2(_RenderViewportScaleFactor));
          
          u_xlat2 = texture(_MainTex, u_xlat2.xy);
          
          u_xlat3.xy = _MainTex_TexelSize.xy * float2(0.5, 0.5) + u_xlat14.xy;
          
          u_xlat4 = texture(_MainTex, u_xlat14.xy);
          
          u_xlat14.xy = max(u_xlat3.xy, float2(0.0, 0.0));
          
          u_xlat14.xy = min(u_xlat14.xy, float2(_RenderViewportScaleFactor));
          
          u_xlat3 = texture(_MainTex, u_xlat14.xy);
          
          u_xlat5 = u_xlat2 + u_xlat3;
          
          u_xlat6 = u_xlat4 + u_xlat4;
          
          u_xlat5 = u_xlat5 * float4(4.0, 4.0, 4.0, 4.0) + (-u_xlat6);
          
          u_xlat6 = (-u_xlat5) * float4(0.166666999, 0.166666999, 0.166666999, 0.166666999) + u_xlat4;
          
          u_xlat6 = u_xlat6 * float4(_Sharpness);
          
          u_xlat4 = u_xlat6 * float4(2.71828198, 2.71828198, 2.71828198, 2.71828198) + u_xlat4;
          
          u_xlat4 = max(u_xlat4, float4(0.0, 0.0, 0.0, 0.0));
          
          u_xlat4 = min(u_xlat4, float4(65472.0, 65472.0, 65472.0, 65472.0));
          
          u_xlat5.xyz = u_xlat4.xyz + u_xlat5.xyz;
          
          u_xlat5.xyz = u_xlat5.xyz * float3(0.142857, 0.142857, 0.142857);
          
          u_xlat14.x = dot(u_xlat5.xyz, float3(0.212672904, 0.715152204, 0.0721750036));
          
          u_xlat21 = dot(u_xlat4.xyz, float3(0.212672904, 0.715152204, 0.0721750036));
          
          u_xlat14.x = (-u_xlat21) + u_xlat14.x;
          
          u_xlat5.xyz = min(u_xlat2.xyz, u_xlat3.xyz);
          
          u_xlat2.xyz = max(u_xlat2.xyz, u_xlat3.xyz);
          
          u_xlat2.xyz = u_xlat7.xxx * abs(u_xlat14.xxx) + u_xlat2.xyz;
          
          u_xlat7.xyz = (-u_xlat7.xxx) * abs(u_xlat14.xxx) + u_xlat5.xyz;
          
          u_xlat3.xyz = (-u_xlat7.xyz) + u_xlat2.xyz;
          
          u_xlat7.xyz = u_xlat7.xyz + u_xlat2.xyz;
          
          u_xlat2.xyz = u_xlat3.xyz * float3(0.5, 0.5, 0.5);
          
          u_xlat3.xyz = (-u_xlat7.xyz) * float3(0.5, 0.5, 0.5) + u_xlat1.xyz;
          
          u_xlat7.xyz = u_xlat7.xyz * float3(0.5, 0.5, 0.5);
          
          u_xlat5.xyz = u_xlat3.xyz + float3(9.99999975e-05, 9.99999975e-05, 9.99999975e-05);
          
          u_xlat2.xyz = u_xlat2.xyz / u_xlat5.xyz;
          
          u_xlat2.x = min(abs(u_xlat2.y), abs(u_xlat2.x));
          
          u_xlat2.x = min(abs(u_xlat2.z), u_xlat2.x);
          
          u_xlat2.x = min(u_xlat2.x, 1.0);
          
          u_xlat1.xyz = u_xlat3.xyz * u_xlat2.xxx + u_xlat7.xyz;
          
          u_xlat1 = (-u_xlat4) + u_xlat1;
          
          u_xlat7.x = (-_FinalBlendParameters.x) + _FinalBlendParameters.y;
          
          u_xlat0_d.x = u_xlat0_d.x * u_xlat7.x + _FinalBlendParameters.x;
          
          u_xlat0_d.x = max(u_xlat0_d.x, _FinalBlendParameters.y);
          
          u_xlat0_d.x = min(u_xlat0_d.x, _FinalBlendParameters.x);
          
          u_xlat0_d = u_xlat0_d.xxxx * u_xlat1 + u_xlat4;
          
          u_xlat0_d = max(u_xlat0_d, float4(0.0, 0.0, 0.0, 0.0));
          
          u_xlat0_d = min(u_xlat0_d, float4(65472.0, 65472.0, 65472.0, 65472.0));
          
          out_f.color = u_xlat0_d;
          
          out_f.color1 = u_xlat0_d;
          
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
      
      uniform float2 _Jitter;
      
      uniform float4 _FinalBlendParameters;
      
      uniform float _Sharpness;
      
      uniform sampler2D _CameraMotionVectorsTexture;
      
      uniform sampler2D _MainTex;
      
      uniform sampler2D _HistoryTex;
      
      
      
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
          
          float4 color1 : SV_Target1;
      
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
      
      float3 u_xlat5;
      
      float3 u_xlat7;
      
      float2 u_xlat12;
      
      float u_xlat13;
      
      float u_xlat18;
      
      float u_xlat19;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d.xy = in_f.texcoord1.xy + (-_Jitter.xy);
          
          u_xlat0_d.xy = max(u_xlat0_d.xy, float2(0.0, 0.0));
          
          u_xlat0_d.xy = min(u_xlat0_d.xy, float2(_RenderViewportScaleFactor));
          
          u_xlat12.xy = (-_MainTex_TexelSize.xy) * float2(0.5, 0.5) + u_xlat0_d.xy;
          
          u_xlat12.xy = max(u_xlat12.xy, float2(0.0, 0.0));
          
          u_xlat12.xy = min(u_xlat12.xy, float2(_RenderViewportScaleFactor));
          
          u_xlat1 = texture(_MainTex, u_xlat12.xy);
          
          u_xlat12.xy = _MainTex_TexelSize.xy * float2(0.5, 0.5) + u_xlat0_d.xy;
          
          u_xlat2 = texture(_MainTex, u_xlat0_d.xy);
          
          u_xlat0_d.xy = max(u_xlat12.xy, float2(0.0, 0.0));
          
          u_xlat0_d.xy = min(u_xlat0_d.xy, float2(_RenderViewportScaleFactor));
          
          u_xlat0_d = texture(_MainTex, u_xlat0_d.xy);
          
          u_xlat3 = u_xlat0_d + u_xlat1;
          
          u_xlat4 = u_xlat2 + u_xlat2;
          
          u_xlat3 = u_xlat3 * float4(4.0, 4.0, 4.0, 4.0) + (-u_xlat4);
          
          u_xlat4 = (-u_xlat3) * float4(0.166666999, 0.166666999, 0.166666999, 0.166666999) + u_xlat2;
          
          u_xlat4 = u_xlat4 * float4(_Sharpness);
          
          u_xlat2 = u_xlat4 * float4(2.71828198, 2.71828198, 2.71828198, 2.71828198) + u_xlat2;
          
          u_xlat2 = max(u_xlat2, float4(0.0, 0.0, 0.0, 0.0));
          
          u_xlat2 = min(u_xlat2, float4(65472.0, 65472.0, 65472.0, 65472.0));
          
          u_xlat3.xyz = u_xlat2.xyz + u_xlat3.xyz;
          
          u_xlat3.xyz = u_xlat3.xyz * float3(0.142857, 0.142857, 0.142857);
          
          u_xlat18 = dot(u_xlat3.xyz, float3(0.212672904, 0.715152204, 0.0721750036));
          
          u_xlat19 = dot(u_xlat2.xyz, float3(0.212672904, 0.715152204, 0.0721750036));
          
          u_xlat18 = u_xlat18 + (-u_xlat19);
          
          u_xlat3.xyz = min(u_xlat1.xyz, u_xlat0_d.xyz);
          
          u_xlat0_d.xyz = max(u_xlat0_d.xyz, u_xlat1.xyz);
          
          u_xlat1 = texture(_CameraMotionVectorsTexture, in_f.texcoord1.xy);
          
          u_xlat13 = dot(u_xlat1.xy, u_xlat1.xy);
          
          u_xlat1.xy = (-u_xlat1.xy) + in_f.texcoord1.xy;
          
          u_xlat1.xy = max(u_xlat1.xy, float2(0.0, 0.0));
          
          u_xlat1.xy = min(u_xlat1.xy, float2(_RenderViewportScaleFactor));
          
          u_xlat4 = texture(_HistoryTex, u_xlat1.xy);
          
          u_xlat1.x = sqrt(u_xlat13);
          
          u_xlat7.x = u_xlat1.x * 100.0;
          
          u_xlat1.x = u_xlat1.x * _FinalBlendParameters.z;
          
          u_xlat7.x = min(u_xlat7.x, 1.0);
          
          u_xlat7.x = u_xlat7.x * -3.75 + 4.0;
          
          u_xlat3.xyz = (-u_xlat7.xxx) * abs(float3(u_xlat18)) + u_xlat3.xyz;
          
          u_xlat0_d.xyz = u_xlat7.xxx * abs(float3(u_xlat18)) + u_xlat0_d.xyz;
          
          u_xlat7.xyz = (-u_xlat3.xyz) + u_xlat0_d.xyz;
          
          u_xlat0_d.xyz = u_xlat3.xyz + u_xlat0_d.xyz;
          
          u_xlat7.xyz = u_xlat7.xyz * float3(0.5, 0.5, 0.5);
          
          u_xlat3.xyz = (-u_xlat0_d.xyz) * float3(0.5, 0.5, 0.5) + u_xlat4.xyz;
          
          u_xlat0_d.xyz = u_xlat0_d.xyz * float3(0.5, 0.5, 0.5);
          
          u_xlat5.xyz = u_xlat3.xyz + float3(9.99999975e-05, 9.99999975e-05, 9.99999975e-05);
          
          u_xlat7.xyz = u_xlat7.xyz / u_xlat5.xyz;
          
          u_xlat18 = min(abs(u_xlat7.y), abs(u_xlat7.x));
          
          u_xlat18 = min(abs(u_xlat7.z), u_xlat18);
          
          u_xlat18 = min(u_xlat18, 1.0);
          
          u_xlat4.xyz = u_xlat3.xyz * float3(u_xlat18) + u_xlat0_d.xyz;
          
          u_xlat0_d = (-u_xlat2) + u_xlat4;
          
          u_xlat7.x = (-_FinalBlendParameters.x) + _FinalBlendParameters.y;
          
          u_xlat1.x = u_xlat1.x * u_xlat7.x + _FinalBlendParameters.x;
          
          u_xlat1.x = max(u_xlat1.x, _FinalBlendParameters.y);
          
          u_xlat1.x = min(u_xlat1.x, _FinalBlendParameters.x);
          
          u_xlat0_d = u_xlat1.xxxx * u_xlat0_d + u_xlat2;
          
          u_xlat0_d = max(u_xlat0_d, float4(0.0, 0.0, 0.0, 0.0));
          
          u_xlat0_d = min(u_xlat0_d, float4(65472.0, 65472.0, 65472.0, 65472.0));
          
          out_f.color = u_xlat0_d;
          
          out_f.color1 = u_xlat0_d;
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
