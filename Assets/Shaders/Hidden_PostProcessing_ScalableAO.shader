Shader "Hidden/PostProcessing/ScalableAO"
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
      
      uniform float4 unity_CameraProjection[4];
      
      uniform float4 _ProjectionParams;
      
      uniform float4 unity_OrthoParams;
      
      uniform float4 _ZBufferParams;
      
      uniform float4 _ScreenParams;
      
      uniform float4 _AOParams;
      
      uniform sampler2D _CameraDepthNormalsTexture;
      
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
      
      int u_xlati0;
      
      float4 u_xlat1;
      
      int u_xlati1;
      
      float3 u_xlat2;
      
      float3 u_xlat3;
      
      bool2 u_xlatb3;
      
      float2 u_xlat4;
      
      float2 u_xlat5;
      
      float4 u_xlat6;
      
      float u_xlat7;
      
      float2 u_xlat8;
      
      float u_xlat9;
      
      float3 u_xlat10;
      
      float3 u_xlat14;
      
      int u_xlati14;
      
      bool2 u_xlatb14;
      
      float2 u_xlat18;
      
      int2 u_xlati18;
      
      bool2 u_xlatb18;
      
      float2 u_xlat22;
      
      float u_xlat27;
      
      int u_xlatb27;
      
      float u_xlat29;
      
      int u_xlatb29;
      
      float u_xlat30;
      
      int u_xlati30;
      
      int u_xlatb30;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d.xy = in_f.texcoord.xy;
          
          u_xlat0_d.xy = clamp(u_xlat0_d.xy, 0.0, 1.0);
          
          u_xlat0_d.xy = u_xlat0_d.xy * float2(_RenderViewportScaleFactor);
          
          u_xlat1 = texture(_CameraDepthNormalsTexture, u_xlat0_d.xy);
          
          u_xlat1.xyz = u_xlat1.xyz * float3(3.55539989, 3.55539989, 0.0) + float3(-1.77769995, -1.77769995, 1.0);
          
          u_xlat18.x = dot(u_xlat1.xyz, u_xlat1.xyz);
          
          u_xlat18.x = 2.0 / u_xlat18.x;
          
          u_xlat10.xy = u_xlat1.xy * u_xlat18.xx;
          
          u_xlat10.z = u_xlat18.x + -1.0;
          
          u_xlat2.xyz = u_xlat10.xyz * float3(1.0, 1.0, -1.0);
          
          u_xlat0_d = textureLod(_CameraDepthTexture, u_xlat0_d.xy, 0.0);
          
          u_xlat9 = (-unity_OrthoParams.w) + 1.0;
          
          u_xlat0_d.x = u_xlat0_d.x * _ZBufferParams.x;
          
          u_xlat18.x = (-unity_OrthoParams.w) * u_xlat0_d.x + 1.0;
          
          u_xlat0_d.x = u_xlat9 * u_xlat0_d.x + _ZBufferParams.y;
          
          u_xlat0_d.x = u_xlat18.x / u_xlat0_d.x;
          
          u_xlatb18.xy = lessThan(in_f.texcoord.xyxy, float4(0.0, 0.0, 0.0, 0.0)).xy;
          
          u_xlati18.x = int((uint(u_xlatb18.y) * 0xffffffffu) | (uint(u_xlatb18.x) * 0xffffffffu));
          
          u_xlatb3.xy = lessThan(float4(1.0, 1.0, 0.0, 0.0), in_f.texcoord.xyxx).xy;
          
          u_xlati18.y = int((uint(u_xlatb3.y) * 0xffffffffu) | (uint(u_xlatb3.x) * 0xffffffffu));
          
          u_xlati18.xy = int2(uint2(u_xlati18.xy) & uint2(1u, 1u));
          
          u_xlati18.x = u_xlati18.y + u_xlati18.x;
          
          u_xlat18.x = float(u_xlati18.x);
          
          u_xlatb27 = 9.99999975e-06>=u_xlat0_d.x;
          
          u_xlat27 = u_xlatb27 ? 1.0 : float(0.0);
          
          u_xlat18.x = u_xlat27 + u_xlat18.x;
          
          u_xlat18.x = u_xlat18.x * 100000000.0;
          
          u_xlat3.z = u_xlat0_d.x * _ProjectionParams.z + u_xlat18.x;
          
          u_xlat0_d.xz = in_f.texcoord.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
          
          u_xlat0_d.xz = u_xlat0_d.xz + (-unity_CameraProjection[2].xy);
          
          u_xlat4.x = unity_CameraProjection[0].x;
          
          u_xlat4.y = unity_CameraProjection[1].y;
          
          u_xlat0_d.xz = u_xlat0_d.xz / u_xlat4.xy;
          
          u_xlat27 = (-u_xlat3.z) + 1.0;
          
          u_xlat27 = unity_OrthoParams.w * u_xlat27 + u_xlat3.z;
          
          u_xlat3.xy = float2(u_xlat27) * u_xlat0_d.xz;
          
          u_xlati0 = int(_AOParams.w);
          
          u_xlat18.xy = in_f.texcoord.xy * _AOParams.zz;
          
          u_xlat18.xy = u_xlat18.xy * _ScreenParams.xy;
          
          u_xlat18.xy = floor(u_xlat18.xy);
          
          u_xlat18.x = dot(float2(0.0671105608, 0.00583714992), u_xlat18.xy);
          
          u_xlat18.x = fract(u_xlat18.x);
          
          u_xlat18.x = u_xlat18.x * 52.9829178;
          
          u_xlat18.x = fract(u_xlat18.x);
          
          u_xlat5.x = 12.9898005;
          
          u_xlat27 = 0.0;
          
          for(int u_xlati_loop_1 = 0 ; u_xlati_loop_1<u_xlati0 ; u_xlati_loop_1++)
      
          
              {
              
              u_xlat29 = float(u_xlati_loop_1);
              
              u_xlat5.y = in_f.texcoord.x * 1.00000001e-10 + u_xlat29;
              
              u_xlat30 = u_xlat5.y * 78.2330017;
              
              u_xlat30 = sin(u_xlat30);
              
              u_xlat30 = u_xlat30 * 43758.5469;
              
              u_xlat30 = fract(u_xlat30);
              
              u_xlat30 = u_xlat18.x + u_xlat30;
              
              u_xlat30 = fract(u_xlat30);
              
              u_xlat6.z = u_xlat30 * 2.0 + -1.0;
              
              u_xlat30 = dot(u_xlat5.xy, float2(1.0, 78.2330017));
              
              u_xlat30 = sin(u_xlat30);
              
              u_xlat30 = u_xlat30 * 43758.5469;
              
              u_xlat30 = fract(u_xlat30);
              
              u_xlat30 = u_xlat18.x + u_xlat30;
              
              u_xlat30 = u_xlat30 * 6.28318548;
              
              u_xlat7 = sin(u_xlat30);
              
              u_xlat8.x = cos(u_xlat30);
              
              u_xlat30 = (-u_xlat6.z) * u_xlat6.z + 1.0;
              
              u_xlat30 = sqrt(u_xlat30);
              
              u_xlat8.y = u_xlat7;
              
              u_xlat6.xy = float2(u_xlat30) * u_xlat8.xy;
              
              u_xlat29 = u_xlat29 + 1.0;
              
              u_xlat29 = u_xlat29 / _AOParams.w;
              
              u_xlat29 = sqrt(u_xlat29);
              
              u_xlat29 = u_xlat29 * _AOParams.y;
              
              u_xlat14.xyz = float3(u_xlat29) * u_xlat6.xyz;
              
              u_xlat29 = dot((-u_xlat2.xyz), u_xlat14.xyz);
              
              u_xlatb29 = u_xlat29>=0.0;
              
              u_xlat14.xyz = (int(u_xlatb29)) ? (-u_xlat14.xyz) : u_xlat14.xyz;
              
              u_xlat14.xyz = u_xlat3.xyz + u_xlat14.xyz;
              
              u_xlat22.xy = u_xlat14.yy * unity_CameraProjection[1].xy;
              
              u_xlat22.xy = unity_CameraProjection[0].xy * u_xlat14.xx + u_xlat22.xy;
              
              u_xlat22.xy = unity_CameraProjection[2].xy * u_xlat14.zz + u_xlat22.xy;
              
              u_xlat29 = (-u_xlat14.z) + 1.0;
              
              u_xlat29 = unity_OrthoParams.w * u_xlat29 + u_xlat14.z;
              
              u_xlat22.xy = u_xlat22.xy / float2(u_xlat29);
              
              u_xlat22.xy = u_xlat22.xy + float2(1.0, 1.0);
              
              u_xlat14.xy = u_xlat22.xy * float2(0.5, 0.5);
              
              u_xlat14.xy = clamp(u_xlat14.xy, 0.0, 1.0);
              
              u_xlat14.xy = u_xlat14.xy * float2(_RenderViewportScaleFactor);
              
              u_xlat6 = textureLod(_CameraDepthTexture, u_xlat14.xy, 0.0);
              
              u_xlat29 = u_xlat6.x * _ZBufferParams.x;
              
              u_xlat30 = (-unity_OrthoParams.w) * u_xlat29 + 1.0;
              
              u_xlat29 = u_xlat9 * u_xlat29 + _ZBufferParams.y;
              
              u_xlat29 = u_xlat30 / u_xlat29;
              
              u_xlatb14.xy = lessThan(u_xlat22.xyxx, float4(0.0, 0.0, 0.0, 0.0)).xy;
              
              u_xlatb30 = u_xlatb14.y || u_xlatb14.x;
              
              u_xlati30 = u_xlatb30 ? 1 : int(0);
              
              u_xlatb14.xy = lessThan(float4(2.0, 2.0, 0.0, 0.0), u_xlat22.xyxx).xy;
              
              u_xlatb14.x = u_xlatb14.y || u_xlatb14.x;
              
              u_xlati14 = u_xlatb14.x ? 1 : int(0);
              
              u_xlati30 = u_xlati30 + u_xlati14;
              
              u_xlat30 = float(u_xlati30);
              
              u_xlatb14.x = 9.99999975e-06>=u_xlat29;
              
              u_xlat14.x = u_xlatb14.x ? 1.0 : float(0.0);
              
              u_xlat30 = u_xlat30 + u_xlat14.x;
              
              u_xlat30 = u_xlat30 * 100000000.0;
              
              u_xlat6.z = u_xlat29 * _ProjectionParams.z + u_xlat30;
              
              u_xlat22.xy = u_xlat22.xy + (-unity_CameraProjection[2].xy);
              
              u_xlat22.xy = u_xlat22.xy + float2(-1.0, -1.0);
              
              u_xlat22.xy = u_xlat22.xy / u_xlat4.xy;
              
              u_xlat29 = (-u_xlat6.z) + 1.0;
              
              u_xlat29 = unity_OrthoParams.w * u_xlat29 + u_xlat6.z;
              
              u_xlat6.xy = float2(u_xlat29) * u_xlat22.xy;
              
              u_xlat14.xyz = (-u_xlat3.xyz) + u_xlat6.xyz;
              
              u_xlat29 = dot(u_xlat14.xyz, u_xlat2.xyz);
              
              u_xlat29 = (-u_xlat3.z) * 0.00200000009 + u_xlat29;
              
              u_xlat29 = max(u_xlat29, 0.0);
              
              u_xlat30 = dot(u_xlat14.xyz, u_xlat14.xyz);
              
              u_xlat30 = u_xlat30 + 9.99999975e-05;
              
              u_xlat29 = u_xlat29 / u_xlat30;
              
              u_xlat27 = u_xlat27 + u_xlat29;
      
      }
          
          u_xlat0_d.x = u_xlat27 * _AOParams.y;
          
          u_xlat0_d.x = u_xlat0_d.x * _AOParams.x;
          
          u_xlat0_d.x = u_xlat0_d.x / _AOParams.w;
          
          u_xlat0_d.x = max(abs(u_xlat0_d.x), 1.1920929e-07);
          
          u_xlat0_d.x = log2(u_xlat0_d.x);
          
          u_xlat0_d.x = u_xlat0_d.x * 0.600000024;
          
          out_f.color.x = exp2(u_xlat0_d.x);
          
          out_f.color.yzw = u_xlat10.xyz * float3(0.5, 0.5, -0.5) + float3(0.5, 0.5, 0.5);
          
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
      
      uniform float4 unity_CameraProjection[4];
      
      uniform float4 unity_WorldToCamera[4];
      
      uniform float4 _ProjectionParams;
      
      uniform float4 unity_OrthoParams;
      
      uniform float4 _ZBufferParams;
      
      uniform float4 _ScreenParams;
      
      uniform float4 _AOParams;
      
      uniform sampler2D _CameraGBufferTexture2;
      
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
      
      int u_xlati0;
      
      float4 u_xlat1;
      
      float3 u_xlat2;
      
      bool2 u_xlatb2;
      
      float2 u_xlat3;
      
      float2 u_xlat4;
      
      float4 u_xlat5;
      
      float u_xlat6;
      
      float2 u_xlat7;
      
      float u_xlat8;
      
      float3 u_xlat12;
      
      int2 u_xlati12;
      
      bool2 u_xlatb12;
      
      float2 u_xlat16;
      
      int2 u_xlati16;
      
      bool2 u_xlatb16;
      
      float2 u_xlat19;
      
      float u_xlat20;
      
      bool2 u_xlatb20;
      
      float u_xlat24;
      
      int u_xlatb24;
      
      int u_xlati25;
      
      float u_xlat26;
      
      int u_xlatb26;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d.xy = in_f.texcoord.xy;
          
          u_xlat0_d.xy = clamp(u_xlat0_d.xy, 0.0, 1.0);
          
          u_xlat0_d.xy = u_xlat0_d.xy * float2(_RenderViewportScaleFactor);
          
          u_xlat1 = texture(_CameraGBufferTexture2, u_xlat0_d.xy);
          
          u_xlat16.x = dot(u_xlat1.xyz, u_xlat1.xyz);
          
          u_xlatb16.x = u_xlat16.x!=0.0;
          
          u_xlat16.x = (u_xlatb16.x) ? -1.0 : -0.0;
          
          u_xlat1.xyz = u_xlat1.xyz * float3(2.0, 2.0, 2.0) + u_xlat16.xxx;
          
          u_xlat2.xyz = u_xlat1.yyy * unity_WorldToCamera[1].xyz;
          
          u_xlat1.xyw = unity_WorldToCamera[0].xyz * u_xlat1.xxx + u_xlat2.xyz;
          
          u_xlat1.xyz = unity_WorldToCamera[2].xyz * u_xlat1.zzz + u_xlat1.xyw;
          
          u_xlat0_d = textureLod(_CameraDepthTexture, u_xlat0_d.xy, 0.0);
          
          u_xlat8 = (-unity_OrthoParams.w) + 1.0;
          
          u_xlat0_d.x = u_xlat0_d.x * _ZBufferParams.x;
          
          u_xlat16.x = (-unity_OrthoParams.w) * u_xlat0_d.x + 1.0;
          
          u_xlat0_d.x = u_xlat8 * u_xlat0_d.x + _ZBufferParams.y;
          
          u_xlat0_d.x = u_xlat16.x / u_xlat0_d.x;
          
          u_xlatb16.xy = lessThan(in_f.texcoord.xyxy, float4(0.0, 0.0, 0.0, 0.0)).xy;
          
          u_xlati16.x = int((uint(u_xlatb16.y) * 0xffffffffu) | (uint(u_xlatb16.x) * 0xffffffffu));
          
          u_xlatb2.xy = lessThan(float4(1.0, 1.0, 0.0, 0.0), in_f.texcoord.xyxx).xy;
          
          u_xlati16.y = int((uint(u_xlatb2.y) * 0xffffffffu) | (uint(u_xlatb2.x) * 0xffffffffu));
          
          u_xlati16.xy = int2(uint2(u_xlati16.xy) & uint2(1u, 1u));
          
          u_xlati16.x = u_xlati16.y + u_xlati16.x;
          
          u_xlat16.x = float(u_xlati16.x);
          
          u_xlatb24 = 9.99999975e-06>=u_xlat0_d.x;
          
          u_xlat24 = u_xlatb24 ? 1.0 : float(0.0);
          
          u_xlat16.x = u_xlat24 + u_xlat16.x;
          
          u_xlat16.x = u_xlat16.x * 100000000.0;
          
          u_xlat2.z = u_xlat0_d.x * _ProjectionParams.z + u_xlat16.x;
          
          u_xlat0_d.xz = in_f.texcoord.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
          
          u_xlat0_d.xz = u_xlat0_d.xz + (-unity_CameraProjection[2].xy);
          
          u_xlat3.x = unity_CameraProjection[0].x;
          
          u_xlat3.y = unity_CameraProjection[1].y;
          
          u_xlat0_d.xz = u_xlat0_d.xz / u_xlat3.xy;
          
          u_xlat24 = (-u_xlat2.z) + 1.0;
          
          u_xlat24 = unity_OrthoParams.w * u_xlat24 + u_xlat2.z;
          
          u_xlat2.xy = float2(u_xlat24) * u_xlat0_d.xz;
          
          u_xlati0 = int(_AOParams.w);
          
          u_xlat16.xy = in_f.texcoord.xy * _AOParams.zz;
          
          u_xlat16.xy = u_xlat16.xy * _ScreenParams.xy;
          
          u_xlat16.xy = floor(u_xlat16.xy);
          
          u_xlat16.x = dot(float2(0.0671105608, 0.00583714992), u_xlat16.xy);
          
          u_xlat16.x = fract(u_xlat16.x);
          
          u_xlat16.x = u_xlat16.x * 52.9829178;
          
          u_xlat16.x = fract(u_xlat16.x);
          
          u_xlat4.x = 12.9898005;
          
          u_xlat24 = 0.0;
          
          for(int u_xlati_loop_1 = 0 ; u_xlati_loop_1<u_xlati0 ; u_xlati_loop_1++)
      
          
              {
              
              u_xlat26 = float(u_xlati_loop_1);
              
              u_xlat4.y = in_f.texcoord.x * 1.00000001e-10 + u_xlat26;
              
              u_xlat19.x = u_xlat4.y * 78.2330017;
              
              u_xlat19.x = sin(u_xlat19.x);
              
              u_xlat19.x = u_xlat19.x * 43758.5469;
              
              u_xlat19.x = fract(u_xlat19.x);
              
              u_xlat19.x = u_xlat16.x + u_xlat19.x;
              
              u_xlat19.x = fract(u_xlat19.x);
              
              u_xlat5.z = u_xlat19.x * 2.0 + -1.0;
              
              u_xlat19.x = dot(u_xlat4.xy, float2(1.0, 78.2330017));
              
              u_xlat19.x = sin(u_xlat19.x);
              
              u_xlat19.x = u_xlat19.x * 43758.5469;
              
              u_xlat19.x = fract(u_xlat19.x);
              
              u_xlat19.x = u_xlat16.x + u_xlat19.x;
              
              u_xlat19.x = u_xlat19.x * 6.28318548;
              
              u_xlat6 = sin(u_xlat19.x);
              
              u_xlat7.x = cos(u_xlat19.x);
              
              u_xlat19.x = (-u_xlat5.z) * u_xlat5.z + 1.0;
              
              u_xlat19.x = sqrt(u_xlat19.x);
              
              u_xlat7.y = u_xlat6;
              
              u_xlat5.xy = u_xlat19.xx * u_xlat7.xy;
              
              u_xlat26 = u_xlat26 + 1.0;
              
              u_xlat26 = u_xlat26 / _AOParams.w;
              
              u_xlat26 = sqrt(u_xlat26);
              
              u_xlat26 = u_xlat26 * _AOParams.y;
              
              u_xlat12.xyz = float3(u_xlat26) * u_xlat5.xyz;
              
              u_xlat26 = dot((-u_xlat1.xyz), u_xlat12.xyz);
              
              u_xlatb26 = u_xlat26>=0.0;
              
              u_xlat12.xyz = (int(u_xlatb26)) ? (-u_xlat12.xyz) : u_xlat12.xyz;
              
              u_xlat12.xyz = u_xlat2.xyz + u_xlat12.xyz;
              
              u_xlat19.xy = u_xlat12.yy * unity_CameraProjection[1].xy;
              
              u_xlat19.xy = unity_CameraProjection[0].xy * u_xlat12.xx + u_xlat19.xy;
              
              u_xlat19.xy = unity_CameraProjection[2].xy * u_xlat12.zz + u_xlat19.xy;
              
              u_xlat26 = (-u_xlat12.z) + 1.0;
              
              u_xlat26 = unity_OrthoParams.w * u_xlat26 + u_xlat12.z;
              
              u_xlat19.xy = u_xlat19.xy / float2(u_xlat26);
              
              u_xlat19.xy = u_xlat19.xy + float2(1.0, 1.0);
              
              u_xlat12.xy = u_xlat19.xy * float2(0.5, 0.5);
              
              u_xlat12.xy = clamp(u_xlat12.xy, 0.0, 1.0);
              
              u_xlat12.xy = u_xlat12.xy * float2(_RenderViewportScaleFactor);
              
              u_xlat5 = textureLod(_CameraDepthTexture, u_xlat12.xy, 0.0);
              
              u_xlat26 = u_xlat5.x * _ZBufferParams.x;
              
              u_xlat12.x = (-unity_OrthoParams.w) * u_xlat26 + 1.0;
              
              u_xlat26 = u_xlat8 * u_xlat26 + _ZBufferParams.y;
              
              u_xlat26 = u_xlat12.x / u_xlat26;
              
              u_xlatb12.xy = lessThan(u_xlat19.xyxx, float4(0.0, 0.0, 0.0, 0.0)).xy;
              
              u_xlati12.x = int((uint(u_xlatb12.y) * 0xffffffffu) | (uint(u_xlatb12.x) * 0xffffffffu));
              
              u_xlatb20.xy = lessThan(float4(2.0, 2.0, 2.0, 2.0), u_xlat19.xyxy).xy;
              
              u_xlati12.y = int((uint(u_xlatb20.y) * 0xffffffffu) | (uint(u_xlatb20.x) * 0xffffffffu));
              
              u_xlati12.xy = int2(uint2(u_xlati12.xy) & uint2(1u, 1u));
              
              u_xlati12.x = u_xlati12.y + u_xlati12.x;
              
              u_xlat12.x = float(u_xlati12.x);
              
              u_xlatb20.x = 9.99999975e-06>=u_xlat26;
              
              u_xlat20 = u_xlatb20.x ? 1.0 : float(0.0);
              
              u_xlat12.x = u_xlat20 + u_xlat12.x;
              
              u_xlat12.x = u_xlat12.x * 100000000.0;
              
              u_xlat5.z = u_xlat26 * _ProjectionParams.z + u_xlat12.x;
              
              u_xlat19.xy = u_xlat19.xy + (-unity_CameraProjection[2].xy);
              
              u_xlat19.xy = u_xlat19.xy + float2(-1.0, -1.0);
              
              u_xlat19.xy = u_xlat19.xy / u_xlat3.xy;
              
              u_xlat26 = (-u_xlat5.z) + 1.0;
              
              u_xlat26 = unity_OrthoParams.w * u_xlat26 + u_xlat5.z;
              
              u_xlat5.xy = float2(u_xlat26) * u_xlat19.xy;
              
              u_xlat12.xyz = (-u_xlat2.xyz) + u_xlat5.xyz;
              
              u_xlat26 = dot(u_xlat12.xyz, u_xlat1.xyz);
              
              u_xlat26 = (-u_xlat2.z) * 0.00200000009 + u_xlat26;
              
              u_xlat26 = max(u_xlat26, 0.0);
              
              u_xlat19.x = dot(u_xlat12.xyz, u_xlat12.xyz);
              
              u_xlat19.x = u_xlat19.x + 9.99999975e-05;
              
              u_xlat26 = u_xlat26 / u_xlat19.x;
              
              u_xlat24 = u_xlat24 + u_xlat26;
      
      }
          
          u_xlat0_d.x = u_xlat24 * _AOParams.y;
          
          u_xlat0_d.x = u_xlat0_d.x * _AOParams.x;
          
          u_xlat0_d.x = u_xlat0_d.x / _AOParams.w;
          
          u_xlat0_d.x = max(abs(u_xlat0_d.x), 1.1920929e-07);
          
          u_xlat0_d.x = log2(u_xlat0_d.x);
          
          u_xlat0_d.x = u_xlat0_d.x * 0.600000024;
          
          out_f.color.x = exp2(u_xlat0_d.x);
          
          out_f.color.yzw = u_xlat1.xyz * float3(0.5, 0.5, 0.5) + float3(0.5, 0.5, 0.5);
          
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
      
      uniform sampler2D _CameraDepthNormalsTexture;
      
      
      
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
      
      float3 u_xlat5;
      
      float3 u_xlat6;
      
      float3 u_xlat7;
      
      float3 u_xlat9;
      
      float u_xlat10;
      
      float u_xlat11;
      
      float u_xlat12;
      
      float u_xlat13;
      
      float u_xlat17;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d.x = _MainTex_TexelSize.x;
          
          u_xlat0_d.y = 0.0;
          
          u_xlat1 = (-u_xlat0_d.xyxy) * float4(2.76923084, 1.38461542, 6.46153831, 3.23076916) + in_f.texcoord.xyxy;
          
          u_xlat1 = clamp(u_xlat1, 0.0, 1.0);
          
          u_xlat0_d = u_xlat0_d.xyxy * float4(2.76923084, 1.38461542, 6.46153831, 3.23076916) + in_f.texcoord.xyxy;
          
          u_xlat0_d = clamp(u_xlat0_d, 0.0, 1.0);
          
          u_xlat0_d = u_xlat0_d * float4(_RenderViewportScaleFactor);
          
          u_xlat1 = u_xlat1 * float4(_RenderViewportScaleFactor);
          
          u_xlat2 = texture(_MainTex, u_xlat1.xy);
          
          u_xlat1 = texture(_MainTex, u_xlat1.zw);
          
          u_xlat7.xyz = u_xlat2.yzw * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
          
          u_xlat3 = texture(_CameraDepthNormalsTexture, in_f.texcoord1.xy);
          
          u_xlat3.xyz = u_xlat3.xyz * float3(3.55539989, 3.55539989, 0.0) + float3(-1.77769995, -1.77769995, 1.0);
          
          u_xlat13 = dot(u_xlat3.xyz, u_xlat3.xyz);
          
          u_xlat13 = 2.0 / u_xlat13;
          
          u_xlat9.xy = u_xlat3.xy * float2(u_xlat13);
          
          u_xlat9.z = u_xlat13 + -1.0;
          
          u_xlat3.xyz = u_xlat9.xyz * float3(1.0, 1.0, -1.0);
          
          out_f.color.yzw = u_xlat9.xyz * float3(0.5, 0.5, -0.5) + float3(0.5, 0.5, 0.5);
          
          u_xlat7.x = dot(u_xlat3.xyz, u_xlat7.xyz);
          
          u_xlat7.x = u_xlat7.x + -0.800000012;
          
          u_xlat7.x = u_xlat7.x * 5.00000048;
          
          u_xlat7.x = clamp(u_xlat7.x, 0.0, 1.0);
          
          u_xlat12 = u_xlat7.x * -2.0 + 3.0;
          
          u_xlat7.x = u_xlat7.x * u_xlat7.x;
          
          u_xlat7.x = u_xlat7.x * u_xlat12;
          
          u_xlat7.x = u_xlat7.x * 0.31621623;
          
          u_xlat2.x = u_xlat7.x * u_xlat2.x;
          
          u_xlat4 = texture(_MainTex, in_f.texcoord1.xy);
          
          u_xlat2.x = u_xlat4.x * 0.227027029 + u_xlat2.x;
          
          u_xlat4 = texture(_MainTex, u_xlat0_d.xy);
          
          u_xlat0_d = texture(_MainTex, u_xlat0_d.zw);
          
          u_xlat9.xyz = u_xlat4.yzw * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
          
          u_xlat12 = dot(u_xlat3.xyz, u_xlat9.xyz);
          
          u_xlat12 = u_xlat12 + -0.800000012;
          
          u_xlat12 = u_xlat12 * 5.00000048;
          
          u_xlat12 = clamp(u_xlat12, 0.0, 1.0);
          
          u_xlat17 = u_xlat12 * -2.0 + 3.0;
          
          u_xlat12 = u_xlat12 * u_xlat12;
          
          u_xlat12 = u_xlat12 * u_xlat17;
          
          u_xlat17 = u_xlat12 * 0.31621623;
          
          u_xlat7.x = u_xlat12 * 0.31621623 + u_xlat7.x;
          
          u_xlat2.x = u_xlat4.x * u_xlat17 + u_xlat2.x;
          
          u_xlat6.xyz = u_xlat1.yzw * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
          
          u_xlat6.x = dot(u_xlat3.xyz, u_xlat6.xyz);
          
          u_xlat6.x = u_xlat6.x + -0.800000012;
          
          u_xlat6.x = u_xlat6.x * 5.00000048;
          
          u_xlat6.x = clamp(u_xlat6.x, 0.0, 1.0);
          
          u_xlat11 = u_xlat6.x * -2.0 + 3.0;
          
          u_xlat6.x = u_xlat6.x * u_xlat6.x;
          
          u_xlat6.x = u_xlat6.x * u_xlat11;
          
          u_xlat11 = u_xlat6.x * 0.0702702701;
          
          u_xlat6.x = u_xlat6.x * 0.0702702701 + u_xlat7.x;
          
          u_xlat1.x = u_xlat1.x * u_xlat11 + u_xlat2.x;
          
          u_xlat5.xyz = u_xlat0_d.yzw * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
          
          u_xlat5.x = dot(u_xlat3.xyz, u_xlat5.xyz);
          
          u_xlat5.x = u_xlat5.x + -0.800000012;
          
          u_xlat5.x = u_xlat5.x * 5.00000048;
          
          u_xlat5.x = clamp(u_xlat5.x, 0.0, 1.0);
          
          u_xlat10 = u_xlat5.x * -2.0 + 3.0;
          
          u_xlat5.x = u_xlat5.x * u_xlat5.x;
          
          u_xlat5.x = u_xlat5.x * u_xlat10;
          
          u_xlat10 = u_xlat5.x * 0.0702702701;
          
          u_xlat5.x = u_xlat5.x * 0.0702702701 + u_xlat6.x;
          
          u_xlat5.x = u_xlat5.x + 0.227027029;
          
          u_xlat0_d.x = u_xlat0_d.x * u_xlat10 + u_xlat1.x;
          
          out_f.color.x = u_xlat0_d.x / u_xlat5.x;
          
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
      
      uniform float4 unity_WorldToCamera[4];
      
      uniform float4 _MainTex_TexelSize;
      
      uniform sampler2D _MainTex;
      
      uniform sampler2D _CameraGBufferTexture2;
      
      
      
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
      
      float u_xlat5;
      
      float3 u_xlat6;
      
      float3 u_xlat7;
      
      float3 u_xlat8;
      
      float u_xlat12;
      
      float u_xlat13;
      
      float u_xlat15;
      
      int u_xlatb15;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = texture(_CameraGBufferTexture2, in_f.texcoord1.xy);
          
          u_xlat15 = dot(u_xlat0_d.xyz, u_xlat0_d.xyz);
          
          u_xlatb15 = u_xlat15!=0.0;
          
          u_xlat15 = (u_xlatb15) ? -1.0 : -0.0;
          
          u_xlat0_d.xyz = u_xlat0_d.xyz * float3(2.0, 2.0, 2.0) + float3(u_xlat15);
          
          u_xlat1.xyz = u_xlat0_d.yyy * unity_WorldToCamera[1].xyz;
          
          u_xlat0_d.xyw = unity_WorldToCamera[0].xyz * u_xlat0_d.xxx + u_xlat1.xyz;
          
          u_xlat0_d.xyz = unity_WorldToCamera[2].xyz * u_xlat0_d.zzz + u_xlat0_d.xyw;
          
          u_xlat1.x = _MainTex_TexelSize.x;
          
          u_xlat1.y = 0.0;
          
          u_xlat2 = (-u_xlat1.xyxy) * float4(2.76923084, 1.38461542, 6.46153831, 3.23076916) + in_f.texcoord.xyxy;
          
          u_xlat2 = clamp(u_xlat2, 0.0, 1.0);
          
          u_xlat1 = u_xlat1.xyxy * float4(2.76923084, 1.38461542, 6.46153831, 3.23076916) + in_f.texcoord.xyxy;
          
          u_xlat1 = clamp(u_xlat1, 0.0, 1.0);
          
          u_xlat1 = u_xlat1 * float4(_RenderViewportScaleFactor);
          
          u_xlat2 = u_xlat2 * float4(_RenderViewportScaleFactor);
          
          u_xlat3 = texture(_MainTex, u_xlat2.xy);
          
          u_xlat2 = texture(_MainTex, u_xlat2.zw);
          
          u_xlat8.xyz = u_xlat3.yzw * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
          
          u_xlat15 = dot(u_xlat0_d.xyz, u_xlat8.xyz);
          
          u_xlat15 = u_xlat15 + -0.800000012;
          
          u_xlat15 = u_xlat15 * 5.00000048;
          
          u_xlat15 = clamp(u_xlat15, 0.0, 1.0);
          
          u_xlat8.x = u_xlat15 * -2.0 + 3.0;
          
          u_xlat15 = u_xlat15 * u_xlat15;
          
          u_xlat15 = u_xlat15 * u_xlat8.x;
          
          u_xlat15 = u_xlat15 * 0.31621623;
          
          u_xlat3.x = u_xlat15 * u_xlat3.x;
          
          u_xlat4 = texture(_MainTex, in_f.texcoord1.xy);
          
          u_xlat3.x = u_xlat4.x * 0.227027029 + u_xlat3.x;
          
          u_xlat4 = texture(_MainTex, u_xlat1.xy);
          
          u_xlat1 = texture(_MainTex, u_xlat1.zw);
          
          u_xlat8.xyz = u_xlat4.yzw * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
          
          u_xlat8.x = dot(u_xlat0_d.xyz, u_xlat8.xyz);
          
          u_xlat8.x = u_xlat8.x + -0.800000012;
          
          u_xlat8.x = u_xlat8.x * 5.00000048;
          
          u_xlat8.x = clamp(u_xlat8.x, 0.0, 1.0);
          
          u_xlat13 = u_xlat8.x * -2.0 + 3.0;
          
          u_xlat8.x = u_xlat8.x * u_xlat8.x;
          
          u_xlat8.x = u_xlat8.x * u_xlat13;
          
          u_xlat13 = u_xlat8.x * 0.31621623;
          
          u_xlat15 = u_xlat8.x * 0.31621623 + u_xlat15;
          
          u_xlat3.x = u_xlat4.x * u_xlat13 + u_xlat3.x;
          
          u_xlat7.xyz = u_xlat2.yzw * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
          
          u_xlat7.x = dot(u_xlat0_d.xyz, u_xlat7.xyz);
          
          u_xlat7.x = u_xlat7.x + -0.800000012;
          
          u_xlat7.x = u_xlat7.x * 5.00000048;
          
          u_xlat7.x = clamp(u_xlat7.x, 0.0, 1.0);
          
          u_xlat12 = u_xlat7.x * -2.0 + 3.0;
          
          u_xlat7.x = u_xlat7.x * u_xlat7.x;
          
          u_xlat7.x = u_xlat7.x * u_xlat12;
          
          u_xlat12 = u_xlat7.x * 0.0702702701;
          
          u_xlat15 = u_xlat7.x * 0.0702702701 + u_xlat15;
          
          u_xlat2.x = u_xlat2.x * u_xlat12 + u_xlat3.x;
          
          u_xlat6.xyz = u_xlat1.yzw * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
          
          u_xlat6.x = dot(u_xlat0_d.xyz, u_xlat6.xyz);
          
          out_f.color.yzw = u_xlat0_d.xyz * float3(0.5, 0.5, 0.5) + float3(0.5, 0.5, 0.5);
          
          u_xlat0_d.x = u_xlat6.x + -0.800000012;
          
          u_xlat0_d.x = u_xlat0_d.x * 5.00000048;
          
          u_xlat0_d.x = clamp(u_xlat0_d.x, 0.0, 1.0);
          
          u_xlat5 = u_xlat0_d.x * -2.0 + 3.0;
          
          u_xlat0_d.x = u_xlat0_d.x * u_xlat0_d.x;
          
          u_xlat0_d.x = u_xlat0_d.x * u_xlat5;
          
          u_xlat5 = u_xlat0_d.x * 0.0702702701;
          
          u_xlat0_d.x = u_xlat0_d.x * 0.0702702701 + u_xlat15;
          
          u_xlat0_d.x = u_xlat0_d.x + 0.227027029;
          
          u_xlat5 = u_xlat1.x * u_xlat5 + u_xlat2.x;
          
          out_f.color.x = u_xlat5 / u_xlat0_d.x;
          
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
      
      uniform float4 _AOParams;
      
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
      
      float3 u_xlat5;
      
      float3 u_xlat6;
      
      float3 u_xlat7;
      
      float3 u_xlat8;
      
      float3 u_xlat9;
      
      float u_xlat10;
      
      float u_xlat11;
      
      float u_xlat12;
      
      float u_xlat17;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d.x = _MainTex_TexelSize.y / _AOParams.z;
          
          u_xlat0_d.y = float(1.38461542);
          
          u_xlat0_d.z = float(3.23076916);
          
          u_xlat1 = float4(-0.0, -2.76923084, -0.0, -6.46153831) * u_xlat0_d.yxzx + in_f.texcoord.xyxy;
          
          u_xlat1 = clamp(u_xlat1, 0.0, 1.0);
          
          u_xlat0_d = float4(0.0, 2.76923084, 0.0, 6.46153831) * u_xlat0_d.yxzx + in_f.texcoord.xyxy;
          
          u_xlat0_d = clamp(u_xlat0_d, 0.0, 1.0);
          
          u_xlat0_d = u_xlat0_d * float4(_RenderViewportScaleFactor);
          
          u_xlat1 = u_xlat1 * float4(_RenderViewportScaleFactor);
          
          u_xlat2 = texture(_MainTex, u_xlat1.xy);
          
          u_xlat1 = texture(_MainTex, u_xlat1.zw);
          
          u_xlat7.xyz = u_xlat2.yzw * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
          
          u_xlat3 = texture(_MainTex, in_f.texcoord1.xy);
          
          u_xlat8.xyz = u_xlat3.yzw * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
          
          u_xlat7.x = dot(u_xlat8.xyz, u_xlat7.xyz);
          
          u_xlat7.x = u_xlat7.x + -0.800000012;
          
          u_xlat7.x = u_xlat7.x * 5.00000048;
          
          u_xlat7.x = clamp(u_xlat7.x, 0.0, 1.0);
          
          u_xlat12 = u_xlat7.x * -2.0 + 3.0;
          
          u_xlat7.x = u_xlat7.x * u_xlat7.x;
          
          u_xlat7.x = u_xlat7.x * u_xlat12;
          
          u_xlat7.x = u_xlat7.x * 0.31621623;
          
          u_xlat2.x = u_xlat7.x * u_xlat2.x;
          
          u_xlat2.x = u_xlat3.x * 0.227027029 + u_xlat2.x;
          
          u_xlat4 = texture(_MainTex, u_xlat0_d.xy);
          
          u_xlat0_d = texture(_MainTex, u_xlat0_d.zw);
          
          u_xlat9.xyz = u_xlat4.yzw * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
          
          u_xlat12 = dot(u_xlat8.xyz, u_xlat9.xyz);
          
          u_xlat12 = u_xlat12 + -0.800000012;
          
          u_xlat12 = u_xlat12 * 5.00000048;
          
          u_xlat12 = clamp(u_xlat12, 0.0, 1.0);
          
          u_xlat17 = u_xlat12 * -2.0 + 3.0;
          
          u_xlat12 = u_xlat12 * u_xlat12;
          
          u_xlat12 = u_xlat12 * u_xlat17;
          
          u_xlat17 = u_xlat12 * 0.31621623;
          
          u_xlat7.x = u_xlat12 * 0.31621623 + u_xlat7.x;
          
          u_xlat2.x = u_xlat4.x * u_xlat17 + u_xlat2.x;
          
          u_xlat6.xyz = u_xlat1.yzw * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
          
          u_xlat6.x = dot(u_xlat8.xyz, u_xlat6.xyz);
          
          u_xlat6.x = u_xlat6.x + -0.800000012;
          
          u_xlat6.x = u_xlat6.x * 5.00000048;
          
          u_xlat6.x = clamp(u_xlat6.x, 0.0, 1.0);
          
          u_xlat11 = u_xlat6.x * -2.0 + 3.0;
          
          u_xlat6.x = u_xlat6.x * u_xlat6.x;
          
          u_xlat6.x = u_xlat6.x * u_xlat11;
          
          u_xlat11 = u_xlat6.x * 0.0702702701;
          
          u_xlat6.x = u_xlat6.x * 0.0702702701 + u_xlat7.x;
          
          u_xlat1.x = u_xlat1.x * u_xlat11 + u_xlat2.x;
          
          u_xlat5.xyz = u_xlat0_d.yzw * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
          
          u_xlat5.x = dot(u_xlat8.xyz, u_xlat5.xyz);
          
          out_f.color.yzw = u_xlat8.xyz * float3(0.5, 0.5, 0.5) + float3(0.5, 0.5, 0.5);
          
          u_xlat5.x = u_xlat5.x + -0.800000012;
          
          u_xlat5.x = u_xlat5.x * 5.00000048;
          
          u_xlat5.x = clamp(u_xlat5.x, 0.0, 1.0);
          
          u_xlat10 = u_xlat5.x * -2.0 + 3.0;
          
          u_xlat5.x = u_xlat5.x * u_xlat5.x;
          
          u_xlat5.x = u_xlat5.x * u_xlat10;
          
          u_xlat10 = u_xlat5.x * 0.0702702701;
          
          u_xlat5.x = u_xlat5.x * 0.0702702701 + u_xlat6.x;
          
          u_xlat5.x = u_xlat5.x + 0.227027029;
          
          u_xlat0_d.x = u_xlat0_d.x * u_xlat10 + u_xlat1.x;
          
          out_f.color.x = u_xlat0_d.x / u_xlat5.x;
          
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
      Blend Zero OneMinusSrcColor, Zero OneMinusSrcAlpha
      // m_ProgramMask = 6
      CGPROGRAM
      //#pragma target 4.0
      
      #pragma vertex vert
      #pragma fragment frag
      
      #include "UnityCG.cginc"
      
      
      #define CODE_BLOCK_VERTEX
      
      
      uniform float _RenderViewportScaleFactor;
      
      uniform float4 _AOParams;
      
      uniform float3 _AOColor;
      
      uniform float4 _SAOcclusionTexture_TexelSize;
      
      uniform sampler2D _SAOcclusionTexture;
      
      
      
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
      
      float3 u_xlat5;
      
      float3 u_xlat6;
      
      float3 u_xlat7;
      
      float u_xlat10;
      
      float u_xlat12;
      
      float u_xlat15;
      
      float u_xlat17;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d.xy = in_f.texcoord.xy;
          
          u_xlat0_d.xy = clamp(u_xlat0_d.xy, 0.0, 1.0);
          
          u_xlat0_d.xy = u_xlat0_d.xy * float2(_RenderViewportScaleFactor);
          
          u_xlat0_d = texture(_SAOcclusionTexture, u_xlat0_d.xy);
          
          u_xlat5.xyz = u_xlat0_d.yzw * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
          
          u_xlat1.xy = _SAOcclusionTexture_TexelSize.xy / _AOParams.zz;
          
          u_xlat2.xy = (-u_xlat1.xy) + in_f.texcoord.xy;
          
          u_xlat2.xy = clamp(u_xlat2.xy, 0.0, 1.0);
          
          u_xlat2.xy = u_xlat2.xy * float2(_RenderViewportScaleFactor);
          
          u_xlat2 = texture(_SAOcclusionTexture, u_xlat2.xy);
          
          u_xlat7.xyz = u_xlat2.yzw * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
          
          u_xlat7.x = dot(u_xlat5.xyz, u_xlat7.xyz);
          
          u_xlat7.x = u_xlat7.x + -0.800000012;
          
          u_xlat7.x = u_xlat7.x * 5.00000048;
          
          u_xlat7.x = clamp(u_xlat7.x, 0.0, 1.0);
          
          u_xlat12 = u_xlat7.x * -2.0 + 3.0;
          
          u_xlat7.x = u_xlat7.x * u_xlat7.x;
          
          u_xlat7.x = u_xlat7.x * u_xlat12;
          
          u_xlat0_d.x = u_xlat2.x * u_xlat7.x + u_xlat0_d.x;
          
          u_xlat1.zw = (-u_xlat1.yx);
          
          u_xlat3 = u_xlat1.xzwy + in_f.texcoord.xyxy;
          
          u_xlat3 = clamp(u_xlat3, 0.0, 1.0);
          
          u_xlat1.xy = u_xlat1.xy + in_f.texcoord.xy;
          
          u_xlat1.xy = clamp(u_xlat1.xy, 0.0, 1.0);
          
          u_xlat1.xy = u_xlat1.xy * float2(_RenderViewportScaleFactor);
          
          u_xlat1 = texture(_SAOcclusionTexture, u_xlat1.xy);
          
          u_xlat3 = u_xlat3 * float4(_RenderViewportScaleFactor);
          
          u_xlat4 = texture(_SAOcclusionTexture, u_xlat3.xy);
          
          u_xlat3 = texture(_SAOcclusionTexture, u_xlat3.zw);
          
          u_xlat2.xzw = u_xlat4.yzw * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
          
          u_xlat2.x = dot(u_xlat5.xyz, u_xlat2.xzw);
          
          u_xlat2.x = u_xlat2.x + -0.800000012;
          
          u_xlat2.x = u_xlat2.x * 5.00000048;
          
          u_xlat2.x = clamp(u_xlat2.x, 0.0, 1.0);
          
          u_xlat12 = u_xlat2.x * -2.0 + 3.0;
          
          u_xlat2.x = u_xlat2.x * u_xlat2.x;
          
          u_xlat17 = u_xlat2.x * u_xlat12;
          
          u_xlat2.x = u_xlat12 * u_xlat2.x + u_xlat7.x;
          
          u_xlat0_d.x = u_xlat4.x * u_xlat17 + u_xlat0_d.x;
          
          u_xlat7.xyz = u_xlat3.yzw * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
          
          u_xlat7.x = dot(u_xlat5.xyz, u_xlat7.xyz);
          
          u_xlat7.x = u_xlat7.x + -0.800000012;
          
          u_xlat7.x = u_xlat7.x * 5.00000048;
          
          u_xlat7.x = clamp(u_xlat7.x, 0.0, 1.0);
          
          u_xlat12 = u_xlat7.x * -2.0 + 3.0;
          
          u_xlat7.x = u_xlat7.x * u_xlat7.x;
          
          u_xlat17 = u_xlat7.x * u_xlat12;
          
          u_xlat2.x = u_xlat12 * u_xlat7.x + u_xlat2.x;
          
          u_xlat0_d.x = u_xlat3.x * u_xlat17 + u_xlat0_d.x;
          
          u_xlat6.xyz = u_xlat1.yzw * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
          
          u_xlat5.x = dot(u_xlat5.xyz, u_xlat6.xyz);
          
          u_xlat5.x = u_xlat5.x + -0.800000012;
          
          u_xlat5.x = u_xlat5.x * 5.00000048;
          
          u_xlat5.x = clamp(u_xlat5.x, 0.0, 1.0);
          
          u_xlat10 = u_xlat5.x * -2.0 + 3.0;
          
          u_xlat5.x = u_xlat5.x * u_xlat5.x;
          
          u_xlat15 = u_xlat5.x * u_xlat10;
          
          u_xlat5.x = u_xlat10 * u_xlat5.x + u_xlat2.x;
          
          u_xlat5.x = u_xlat5.x + 1.0;
          
          u_xlat0_d.x = u_xlat1.x * u_xlat15 + u_xlat0_d.x;
          
          u_xlat0_d.x = u_xlat0_d.x / u_xlat5.x;
          
          out_f.color.xyz = u_xlat0_d.xxx * _AOColor.xyz;
          
          out_f.color.w = u_xlat0_d.x;
          
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
      Blend Zero OneMinusSrcColor, Zero OneMinusSrcAlpha
      // m_ProgramMask = 6
      CGPROGRAM
      //#pragma target 4.0
      
      #pragma vertex vert
      #pragma fragment frag
      
      #include "UnityCG.cginc"
      
      
      #define CODE_BLOCK_VERTEX
      
      
      uniform float _RenderViewportScaleFactor;
      
      uniform float4 _ScreenParams;
      
      uniform float4 _AOParams;
      
      uniform float3 _AOColor;
      
      uniform sampler2D _SAOcclusionTexture;
      
      
      
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
      
      float3 u_xlat6;
      
      float3 u_xlat7;
      
      float u_xlat10;
      
      float u_xlat12;
      
      float u_xlat15;
      
      float u_xlat17;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d.xy = in_f.texcoord.xy;
          
          u_xlat0_d.xy = clamp(u_xlat0_d.xy, 0.0, 1.0);
          
          u_xlat0_d.xy = u_xlat0_d.xy * float2(_RenderViewportScaleFactor);
          
          u_xlat0_d = texture(_SAOcclusionTexture, u_xlat0_d.xy);
          
          u_xlat1.xy = _ScreenParams.zw + float2(-1.0, -1.0);
          
          u_xlat1.xy = u_xlat1.xy / _AOParams.zz;
          
          u_xlat2.xy = (-u_xlat1.xy) + in_f.texcoord.xy;
          
          u_xlat2.xy = clamp(u_xlat2.xy, 0.0, 1.0);
          
          u_xlat2.xy = u_xlat2.xy * float2(_RenderViewportScaleFactor);
          
          u_xlat2 = texture(_SAOcclusionTexture, u_xlat2.xy);
          
          u_xlat7.xyz = u_xlat2.yzw * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
          
          u_xlat5.xyz = u_xlat0_d.yzw * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
          
          u_xlat7.x = dot(u_xlat5.xyz, u_xlat7.xyz);
          
          u_xlat7.x = u_xlat7.x + -0.800000012;
          
          u_xlat7.x = u_xlat7.x * 5.00000048;
          
          u_xlat7.x = clamp(u_xlat7.x, 0.0, 1.0);
          
          u_xlat12 = u_xlat7.x * -2.0 + 3.0;
          
          u_xlat7.x = u_xlat7.x * u_xlat7.x;
          
          u_xlat7.x = u_xlat7.x * u_xlat12;
          
          u_xlat0_d.x = u_xlat2.x * u_xlat7.x + u_xlat0_d.x;
          
          u_xlat1.zw = (-u_xlat1.yx);
          
          u_xlat3 = u_xlat1.xzwy + in_f.texcoord.xyxy;
          
          u_xlat3 = clamp(u_xlat3, 0.0, 1.0);
          
          u_xlat1.xy = u_xlat1.xy + in_f.texcoord.xy;
          
          u_xlat1.xy = clamp(u_xlat1.xy, 0.0, 1.0);
          
          u_xlat1.xy = u_xlat1.xy * float2(_RenderViewportScaleFactor);
          
          u_xlat1 = texture(_SAOcclusionTexture, u_xlat1.xy);
          
          u_xlat3 = u_xlat3 * float4(_RenderViewportScaleFactor);
          
          u_xlat4 = texture(_SAOcclusionTexture, u_xlat3.xy);
          
          u_xlat3 = texture(_SAOcclusionTexture, u_xlat3.zw);
          
          u_xlat2.xzw = u_xlat4.yzw * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
          
          u_xlat2.x = dot(u_xlat5.xyz, u_xlat2.xzw);
          
          u_xlat2.x = u_xlat2.x + -0.800000012;
          
          u_xlat2.x = u_xlat2.x * 5.00000048;
          
          u_xlat2.x = clamp(u_xlat2.x, 0.0, 1.0);
          
          u_xlat12 = u_xlat2.x * -2.0 + 3.0;
          
          u_xlat2.x = u_xlat2.x * u_xlat2.x;
          
          u_xlat17 = u_xlat2.x * u_xlat12;
          
          u_xlat2.x = u_xlat12 * u_xlat2.x + u_xlat7.x;
          
          u_xlat0_d.x = u_xlat4.x * u_xlat17 + u_xlat0_d.x;
          
          u_xlat7.xyz = u_xlat3.yzw * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
          
          u_xlat7.x = dot(u_xlat5.xyz, u_xlat7.xyz);
          
          u_xlat7.x = u_xlat7.x + -0.800000012;
          
          u_xlat7.x = u_xlat7.x * 5.00000048;
          
          u_xlat7.x = clamp(u_xlat7.x, 0.0, 1.0);
          
          u_xlat12 = u_xlat7.x * -2.0 + 3.0;
          
          u_xlat7.x = u_xlat7.x * u_xlat7.x;
          
          u_xlat17 = u_xlat7.x * u_xlat12;
          
          u_xlat2.x = u_xlat12 * u_xlat7.x + u_xlat2.x;
          
          u_xlat0_d.x = u_xlat3.x * u_xlat17 + u_xlat0_d.x;
          
          u_xlat6.xyz = u_xlat1.yzw * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
          
          u_xlat5.x = dot(u_xlat5.xyz, u_xlat6.xyz);
          
          u_xlat5.x = u_xlat5.x + -0.800000012;
          
          u_xlat5.x = u_xlat5.x * 5.00000048;
          
          u_xlat5.x = clamp(u_xlat5.x, 0.0, 1.0);
          
          u_xlat10 = u_xlat5.x * -2.0 + 3.0;
          
          u_xlat5.x = u_xlat5.x * u_xlat5.x;
          
          u_xlat15 = u_xlat5.x * u_xlat10;
          
          u_xlat5.x = u_xlat10 * u_xlat5.x + u_xlat2.x;
          
          u_xlat5.x = u_xlat5.x + 1.0;
          
          u_xlat0_d.x = u_xlat1.x * u_xlat15 + u_xlat0_d.x;
          
          u_xlat0_d.x = u_xlat0_d.x / u_xlat5.x;
          
          out_f.color.w = u_xlat0_d.x;
          
          out_f.color1.xyz = u_xlat0_d.xxx * _AOColor.xyz;
          
          out_f.color.xyz = float3(0.0, 0.0, 0.0);
          
          out_f.color1.w = 0.0;
          
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
      
      uniform float4 _AOParams;
      
      uniform float4 _SAOcclusionTexture_TexelSize;
      
      uniform sampler2D _SAOcclusionTexture;
      
      
      
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
      
      float3 u_xlat5;
      
      float3 u_xlat6;
      
      float3 u_xlat7;
      
      float u_xlat10;
      
      float u_xlat12;
      
      float u_xlat15;
      
      float u_xlat17;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d.xy = in_f.texcoord.xy;
          
          u_xlat0_d.xy = clamp(u_xlat0_d.xy, 0.0, 1.0);
          
          u_xlat0_d.xy = u_xlat0_d.xy * float2(_RenderViewportScaleFactor);
          
          u_xlat0_d = texture(_SAOcclusionTexture, u_xlat0_d.xy);
          
          u_xlat5.xyz = u_xlat0_d.yzw * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
          
          u_xlat1.xy = _SAOcclusionTexture_TexelSize.xy / _AOParams.zz;
          
          u_xlat2.xy = (-u_xlat1.xy) + in_f.texcoord.xy;
          
          u_xlat2.xy = clamp(u_xlat2.xy, 0.0, 1.0);
          
          u_xlat2.xy = u_xlat2.xy * float2(_RenderViewportScaleFactor);
          
          u_xlat2 = texture(_SAOcclusionTexture, u_xlat2.xy);
          
          u_xlat7.xyz = u_xlat2.yzw * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
          
          u_xlat7.x = dot(u_xlat5.xyz, u_xlat7.xyz);
          
          u_xlat7.x = u_xlat7.x + -0.800000012;
          
          u_xlat7.x = u_xlat7.x * 5.00000048;
          
          u_xlat7.x = clamp(u_xlat7.x, 0.0, 1.0);
          
          u_xlat12 = u_xlat7.x * -2.0 + 3.0;
          
          u_xlat7.x = u_xlat7.x * u_xlat7.x;
          
          u_xlat17 = u_xlat7.x * u_xlat12;
          
          u_xlat7.x = u_xlat12 * u_xlat7.x + 1.0;
          
          u_xlat0_d.x = u_xlat2.x * u_xlat17 + u_xlat0_d.x;
          
          u_xlat1.zw = (-u_xlat1.yx);
          
          u_xlat3 = u_xlat1.xzwy + in_f.texcoord.xyxy;
          
          u_xlat3 = clamp(u_xlat3, 0.0, 1.0);
          
          u_xlat1.xy = u_xlat1.xy + in_f.texcoord.xy;
          
          u_xlat1.xy = clamp(u_xlat1.xy, 0.0, 1.0);
          
          u_xlat1.xy = u_xlat1.xy * float2(_RenderViewportScaleFactor);
          
          u_xlat1 = texture(_SAOcclusionTexture, u_xlat1.xy);
          
          u_xlat3 = u_xlat3 * float4(_RenderViewportScaleFactor);
          
          u_xlat4 = texture(_SAOcclusionTexture, u_xlat3.xy);
          
          u_xlat3 = texture(_SAOcclusionTexture, u_xlat3.zw);
          
          u_xlat2.xzw = u_xlat4.yzw * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
          
          u_xlat2.x = dot(u_xlat5.xyz, u_xlat2.xzw);
          
          u_xlat2.x = u_xlat2.x + -0.800000012;
          
          u_xlat2.x = u_xlat2.x * 5.00000048;
          
          u_xlat2.x = clamp(u_xlat2.x, 0.0, 1.0);
          
          u_xlat12 = u_xlat2.x * -2.0 + 3.0;
          
          u_xlat2.x = u_xlat2.x * u_xlat2.x;
          
          u_xlat17 = u_xlat2.x * u_xlat12;
          
          u_xlat2.x = u_xlat12 * u_xlat2.x + u_xlat7.x;
          
          u_xlat0_d.x = u_xlat4.x * u_xlat17 + u_xlat0_d.x;
          
          u_xlat7.xyz = u_xlat3.yzw * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
          
          u_xlat7.x = dot(u_xlat5.xyz, u_xlat7.xyz);
          
          u_xlat7.x = u_xlat7.x + -0.800000012;
          
          u_xlat7.x = u_xlat7.x * 5.00000048;
          
          u_xlat7.x = clamp(u_xlat7.x, 0.0, 1.0);
          
          u_xlat12 = u_xlat7.x * -2.0 + 3.0;
          
          u_xlat7.x = u_xlat7.x * u_xlat7.x;
          
          u_xlat17 = u_xlat7.x * u_xlat12;
          
          u_xlat2.x = u_xlat12 * u_xlat7.x + u_xlat2.x;
          
          u_xlat0_d.x = u_xlat3.x * u_xlat17 + u_xlat0_d.x;
          
          u_xlat6.xyz = u_xlat1.yzw * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
          
          u_xlat5.x = dot(u_xlat5.xyz, u_xlat6.xyz);
          
          u_xlat5.x = u_xlat5.x + -0.800000012;
          
          u_xlat5.x = u_xlat5.x * 5.00000048;
          
          u_xlat5.x = clamp(u_xlat5.x, 0.0, 1.0);
          
          u_xlat10 = u_xlat5.x * -2.0 + 3.0;
          
          u_xlat5.x = u_xlat5.x * u_xlat5.x;
          
          u_xlat15 = u_xlat5.x * u_xlat10;
          
          u_xlat5.x = u_xlat10 * u_xlat5.x + u_xlat2.x;
          
          u_xlat0_d.x = u_xlat1.x * u_xlat15 + u_xlat0_d.x;
          
          u_xlat0_d.x = u_xlat0_d.x / u_xlat5.x;
          
          out_f.color.xyz = (-u_xlat0_d.xxx) + float3(1.0, 1.0, 1.0);
          
          out_f.color.w = 1.0;
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
