Shader "Hidden/PostProcessing/Debug/Overlays"
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
      
      uniform float4 unity_OrthoParams;
      
      uniform float4 _ZBufferParams;
      
      uniform float4 _Params;
      
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
      
      float u_xlat2;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = (-unity_OrthoParams.w) + 1.0;
          
          u_xlat1 = textureLod(_CameraDepthTexture, in_f.texcoord1.xy, 0.0);
          
          u_xlat2 = u_xlat1.x * _ZBufferParams.x;
          
          u_xlat0_d = u_xlat0_d * u_xlat2 + _ZBufferParams.y;
          
          u_xlat2 = (-unity_OrthoParams.w) * u_xlat2 + 1.0;
          
          u_xlat0_d = u_xlat2 / u_xlat0_d;
          
          u_xlat0_d = (-u_xlat1.x) + u_xlat0_d;
          
          out_f.color.xyz = _Params.xxx * float3(u_xlat0_d) + u_xlat1.xxx;
          
          out_f.color.w = 1.0;
          
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
      
      float3 u_xlat1;
      
      float u_xlat4;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = texture(_CameraDepthNormalsTexture, in_f.texcoord1.xy);
          
          u_xlat0_d.xyz = u_xlat0_d.xyz * float3(3.55539989, 3.55539989, 0.0) + float3(-1.77769995, -1.77769995, 1.0);
          
          u_xlat4 = dot(u_xlat0_d.xyz, u_xlat0_d.xyz);
          
          u_xlat4 = 2.0 / u_xlat4;
          
          u_xlat1.xy = u_xlat0_d.xy * float2(u_xlat4);
          
          u_xlat1.z = u_xlat4 + -1.0;
          
          out_f.color.xyz = u_xlat1.xyz * float3(1.0, 1.0, -1.0);
          
          out_f.color.w = 1.0;
          
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
      
      uniform float4 _Params;
      
      uniform sampler2D _MainTex;
      
      uniform sampler2D _CameraMotionVectorsTexture;
      
      
      
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
      
      bool3 u_xlatb0;
      
      float4 u_xlat1;
      
      bool3 u_xlatb1;
      
      float4 u_xlat2;
      
      float4 u_xlat3;
      
      float3 u_xlat4;
      
      float u_xlat6;
      
      float2 u_xlat7;
      
      float u_xlat10;
      
      int u_xlatb10;
      
      float u_xlat11;
      
      int u_xlatb11;
      
      float2 u_xlat12;
      
      float u_xlat15;
      
      int u_xlatb15;
      
      float u_xlat16;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          float4 hlslcc_FragCoord = float4(gl_FragCoord.xyz, 1.0/gl_FragCoord.w);
          
          u_xlat0_d.xy = in_f.texcoord.xy;
          
          u_xlat0_d.xy = clamp(u_xlat0_d.xy, 0.0, 1.0);
          
          u_xlat0_d.xy = u_xlat0_d.xy * float2(_RenderViewportScaleFactor);
          
          u_xlat0_d = texture(_CameraMotionVectorsTexture, u_xlat0_d.xy);
          
          u_xlat10 = abs(u_xlat0_d.y);
          
          u_xlat15 = max(u_xlat10, abs(u_xlat0_d.x));
          
          u_xlat15 = float(1.0) / u_xlat15;
          
          u_xlat1.x = min(u_xlat10, abs(u_xlat0_d.x));
          
          u_xlatb10 = u_xlat10<abs(u_xlat0_d.x);
          
          u_xlat15 = u_xlat15 * u_xlat1.x;
          
          u_xlat1.x = u_xlat15 * u_xlat15;
          
          u_xlat6 = u_xlat1.x * 0.0208350997 + -0.0851330012;
          
          u_xlat6 = u_xlat1.x * u_xlat6 + 0.180141002;
          
          u_xlat6 = u_xlat1.x * u_xlat6 + -0.330299497;
          
          u_xlat1.x = u_xlat1.x * u_xlat6 + 0.999866009;
          
          u_xlat6 = u_xlat15 * u_xlat1.x;
          
          u_xlat6 = u_xlat6 * -2.0 + 1.57079637;
          
          u_xlat10 = u_xlatb10 ? u_xlat6 : float(0.0);
          
          u_xlat10 = u_xlat15 * u_xlat1.x + u_xlat10;
          
          u_xlatb15 = (-u_xlat0_d.y)<u_xlat0_d.y;
          
          u_xlat15 = u_xlatb15 ? -3.14159274 : float(0.0);
          
          u_xlat10 = u_xlat15 + u_xlat10;
          
          u_xlat15 = min((-u_xlat0_d.y), u_xlat0_d.x);
          
          u_xlatb15 = u_xlat15<(-u_xlat15);
          
          u_xlat1.x = max((-u_xlat0_d.y), u_xlat0_d.x);
          
          u_xlat0_d.xy = u_xlat0_d.xy * float2(1.0, -1.0);
          
          u_xlat2 = u_xlat0_d.xyxy * _Params.xxyy;
          
          u_xlatb0.x = u_xlat1.x>=(-u_xlat1.x);
          
          u_xlatb0.x = u_xlatb0.x && u_xlatb15;
          
          u_xlat0_d.x = (u_xlatb0.x) ? (-u_xlat10) : u_xlat10;
          
          u_xlat0_d.x = u_xlat0_d.x * 0.318309873 + 1.0;
          
          u_xlat0_d.xyz = u_xlat0_d.xxx * float3(3.0, 3.0, 3.0) + float3(-3.0, -2.0, -4.0);
          
          u_xlat0_d.xyz = abs(u_xlat0_d.xyz) * float3(1.0, -1.0, -1.0) + float3(-1.0, 2.0, 2.0);
          
          u_xlat0_d.xyz = clamp(u_xlat0_d.xyz, 0.0, 1.0);
          
          u_xlat1 = texture(_MainTex, in_f.texcoord1.xy);
          
          u_xlat3.xyz = max(abs(u_xlat1.xyz), float3(1.1920929e-07, 1.1920929e-07, 1.1920929e-07));
          
          u_xlat3.xyz = log2(u_xlat3.xyz);
          
          u_xlat3.xyz = u_xlat3.xyz * float3(0.416666657, 0.416666657, 0.416666657);
          
          u_xlat3.xyz = exp2(u_xlat3.xyz);
          
          u_xlat3.xyz = u_xlat3.xyz * float3(1.05499995, 1.05499995, 1.05499995) + float3(-0.0549999997, -0.0549999997, -0.0549999997);
          
          u_xlat4.xyz = u_xlat1.xyz * float3(12.9200001, 12.9200001, 12.9200001);
          
          u_xlatb1.xyz = greaterThanEqual(float4(0.00313080009, 0.00313080009, 0.00313080009, 0.0), u_xlat1.xyzx).xyz;
          
          u_xlat1.x = (u_xlatb1.x) ? u_xlat4.x : u_xlat3.x;
          
          u_xlat1.y = (u_xlatb1.y) ? u_xlat4.y : u_xlat3.y;
          
          u_xlat1.z = (u_xlatb1.z) ? u_xlat4.z : u_xlat3.z;
          
          u_xlat0_d.xyz = u_xlat0_d.xyz + (-u_xlat1.xyz);
          
          u_xlat15 = dot(u_xlat2.xy, u_xlat2.xy);
          
          u_xlat2.xy = u_xlat2.zw * float2(0.25, 0.25);
          
          u_xlat16 = dot(u_xlat2.xy, u_xlat2.xy);
          
          u_xlat16 = sqrt(u_xlat16);
          
          u_xlat16 = min(u_xlat16, 1.0);
          
          u_xlat15 = sqrt(u_xlat15);
          
          u_xlat15 = clamp(u_xlat15, 0.0, 1.0);
          
          u_xlat0_d.xyz = float3(u_xlat15) * u_xlat0_d.xyz + u_xlat1.xyz;
          
          u_xlat1.xyz = u_xlat0_d.xyz + float3(0.0549999997, 0.0549999997, 0.0549999997);
          
          u_xlat1.xyz = u_xlat1.xyz * float3(0.947867334, 0.947867334, 0.947867334);
          
          u_xlat1.xyz = max(abs(u_xlat1.xyz), float3(1.1920929e-07, 1.1920929e-07, 1.1920929e-07));
          
          u_xlat1.xyz = log2(u_xlat1.xyz);
          
          u_xlat1.xyz = u_xlat1.xyz * float3(2.4000001, 2.4000001, 2.4000001);
          
          u_xlat1.xyz = exp2(u_xlat1.xyz);
          
          u_xlat2.xyz = u_xlat0_d.xyz * float3(0.0773993805, 0.0773993805, 0.0773993805);
          
          u_xlatb0.xyz = greaterThanEqual(float4(0.0404499993, 0.0404499993, 0.0404499993, 0.0), u_xlat0_d.xyzx).xyz;
          
          u_xlat0_d.x = (u_xlatb0.x) ? u_xlat2.x : u_xlat1.x;
          
          u_xlat0_d.y = (u_xlatb0.y) ? u_xlat2.y : u_xlat1.y;
          
          u_xlat0_d.z = (u_xlatb0.z) ? u_xlat2.z : u_xlat1.z;
          
          u_xlat15 = _MainTex_TexelSize.w * _Params.y;
          
          u_xlat15 = u_xlat15 / _MainTex_TexelSize.z;
          
          u_xlat1.y = floor(u_xlat15);
          
          u_xlat1.x = _Params.y;
          
          u_xlat1.xy = _MainTex_TexelSize.zw / u_xlat1.xy;
          
          u_xlat2.xy = hlslcc_FragCoord.xy / u_xlat1.xy;
          
          u_xlat2.xy = floor(u_xlat2.xy);
          
          u_xlat2.xy = u_xlat2.xy + float2(0.5, 0.5);
          
          u_xlat12.xy = u_xlat1.xy * u_xlat2.xy;
          
          u_xlat2.xy = (-u_xlat2.xy) * u_xlat1.xy + hlslcc_FragCoord.xy;
          
          u_xlat15 = min(u_xlat1.y, u_xlat1.x);
          
          u_xlat15 = u_xlat15 * 0.707106769;
          
          u_xlat1.xy = u_xlat12.xy / _MainTex_TexelSize.zw;
          
          u_xlat1.xy = clamp(u_xlat1.xy, 0.0, 1.0);
          
          u_xlat1.xy = u_xlat1.xy * float2(_RenderViewportScaleFactor);
          
          u_xlat3 = texture(_CameraMotionVectorsTexture, u_xlat1.xy);
          
          u_xlat1.xy = u_xlat3.xy * float2(1.0, -1.0);
          
          u_xlat11 = dot(u_xlat1.xy, u_xlat1.xy);
          
          u_xlat12.x = inversesqrt(u_xlat11);
          
          u_xlatb11 = u_xlat11!=0.0;
          
          u_xlat3.xy = u_xlat1.xy * u_xlat12.xx;
          
          u_xlat3.z = (-u_xlat3.y);
          
          u_xlat1.x = dot(u_xlat3.xz, u_xlat2.xy);
          
          u_xlat1.y = dot(u_xlat3.yx, u_xlat2.xy);
          
          u_xlat2.x = u_xlat16 * u_xlat15;
          
          u_xlat15 = u_xlat15 * u_xlat16 + -2.0;
          
          u_xlat7.xy = (-u_xlat2.xx) * float2(0.375, -0.0625) + u_xlat1.xy;
          
          u_xlat3.xyz = u_xlat2.xxx * float3(0.5, 0.25, -0.125);
          
          u_xlat4.x = u_xlat3.x;
          
          u_xlat4.y = 0.0;
          
          u_xlat3.xw = (-u_xlat2.xx) * float2(0.25, 0.125) + u_xlat4.xy;
          
          u_xlat3.xw = (-u_xlat3.xw) + u_xlat4.xy;
          
          u_xlat16 = dot(u_xlat3.xw, u_xlat3.xw);
          
          u_xlat16 = sqrt(u_xlat16);
          
          u_xlat4.xy = u_xlat3.xw / float2(u_xlat16);
          
          u_xlat4.z = (-u_xlat4.x);
          
          u_xlat16 = dot(u_xlat7.xy, u_xlat4.yz);
          
          u_xlat7.xy = (-u_xlat2.xx) * float2(0.375, 0.0625) + u_xlat1.xy;
          
          u_xlat3.xw = u_xlat1.xy + float2(1.0, -0.0);
          
          u_xlat1.x = u_xlat2.x * -0.25 + u_xlat1.x;
          
          u_xlat6 = dot((-u_xlat3.yz), (-u_xlat3.yz));
          
          u_xlat6 = sqrt(u_xlat6);
          
          u_xlat4.xy = (-u_xlat3.yz) / float2(u_xlat6);
          
          u_xlat4.z = (-u_xlat4.x);
          
          u_xlat6 = dot(u_xlat7.xy, u_xlat4.yz);
          
          u_xlat6 = max(u_xlat16, u_xlat6);
          
          u_xlat1.x = max((-u_xlat1.x), u_xlat6);
          
          u_xlat6 = u_xlat15 / abs(u_xlat15);
          
          u_xlat16 = u_xlat6 * u_xlat3.x;
          
          u_xlat6 = (-u_xlat6) * u_xlat3.w;
          
          u_xlat15 = -abs(u_xlat15) * 0.5 + abs(u_xlat16);
          
          u_xlat15 = max(u_xlat15, abs(u_xlat6));
          
          u_xlat15 = min(u_xlat15, u_xlat1.x);
          
          u_xlat15 = clamp(u_xlat15, 0.0, 1.0);
          
          u_xlat15 = (-u_xlat15) + 1.0;
          
          u_xlat15 = u_xlatb11 ? u_xlat15 : float(0.0);
          
          out_f.color.xyz = float3(u_xlat15) + u_xlat0_d.xyz;
          
          out_f.color.w = 1.0;
          
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
          
          u_xlat0_d.xyz = u_xlat0_d.xyz;
          
          u_xlat0_d.xyz = clamp(u_xlat0_d.xyz, 0.0, 1.0);
          
          u_xlat0_d.xyz = u_xlat0_d.xyz * float3(0.25, 0.25, 0.25);
          
          out_f.color = (u_xlatb1.x) ? float4(1.0, 0.0, 1.0, 1.0) : u_xlat0_d;
          
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
      
      uniform float4 _Params;
      
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
      
      float3 u_xlat1;
      
      float u_xlat6;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = texture(_MainTex, in_f.texcoord1.xy);
          
          u_xlat0_d.xyz = u_xlat0_d.xyz;
          
          u_xlat0_d.xyz = clamp(u_xlat0_d.xyz, 0.0, 1.0);
          
          u_xlat6 = u_xlat0_d.y * -367.857117;
          
          u_xlat6 = u_xlat0_d.x * -367.857117 + (-u_xlat6);
          
          u_xlat6 = u_xlat0_d.z * 16511.7441 + u_xlat6;
          
          u_xlat1.z = u_xlat6 * 6.0796734e-05;
          
          u_xlat1.z = clamp(u_xlat1.z, 0.0, 1.0);
          
          u_xlat6 = dot(u_xlat0_d.xy, float2(4833.03809, 11677.1963));
          
          u_xlat6 = u_xlat6 * 6.0796734e-05;
          
          u_xlat1.xy = min(float2(u_xlat6), float2(1.0, 1.0));
          
          u_xlat1.xyz = (-u_xlat0_d.xyz) + u_xlat1.xyz;
          
          out_f.color.xyz = _Params.xxx * u_xlat1.xyz + u_xlat0_d.xyz;
          
          out_f.color.w = 1.0;
          
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
      
      uniform float4 _Params;
      
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
      
      float3 u_xlat1;
      
      float u_xlat6;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = texture(_MainTex, in_f.texcoord1.xy);
          
          u_xlat0_d.xyz = u_xlat0_d.xyz;
          
          u_xlat0_d.xyz = clamp(u_xlat0_d.xyz, 0.0, 1.0);
          
          u_xlat6 = u_xlat0_d.y * 66.0126495;
          
          u_xlat6 = u_xlat0_d.x * 66.0126495 + (-u_xlat6);
          
          u_xlat6 = u_xlat0_d.z * 16511.7441 + u_xlat6;
          
          u_xlat1.z = u_xlat6 * 6.0796734e-05;
          
          u_xlat1.z = clamp(u_xlat1.z, 0.0, 1.0);
          
          u_xlat6 = dot(u_xlat0_d.xy, float2(1855.91467, 14655.8301));
          
          u_xlat6 = u_xlat6 * 6.0796734e-05;
          
          u_xlat1.xy = min(float2(u_xlat6), float2(1.0, 1.0));
          
          u_xlat1.xyz = (-u_xlat0_d.xyz) + u_xlat1.xyz;
          
          out_f.color.xyz = _Params.xxx * u_xlat1.xyz + u_xlat0_d.xyz;
          
          out_f.color.w = 1.0;
          
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
      
      uniform float4 _Params;
      
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
      
      float4 u_xlat1;
      
      int u_xlatb1;
      
      float2 u_xlat2;
      
      float3 u_xlat3;
      
      float2 u_xlat5;
      
      float u_xlat10;
      
      float u_xlat12;
      
      float u_xlat13;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = texture(_MainTex, in_f.texcoord1.xy);
          
          u_xlat0_d.xyz = u_xlat0_d.xyz;
          
          u_xlat0_d.xyz = clamp(u_xlat0_d.xyz, 0.0, 1.0);
          
          u_xlat12 = dot(u_xlat0_d.xyz, float3(2.43251014, 11.4688454, 1.76049244));
          
          u_xlat1 = float4(u_xlat12) * float4(0.00778222037, 5.98477382e-05, -0.000328985829, 0.232164323);
          
          u_xlat2.xy = float2(u_xlat12) * float2(0.137866527, 0.00933136418);
          
          u_xlat12 = dot(u_xlat0_d.xyz, float3(6.5019784, 11.0320301, 1.22384095));
          
          u_xlat10 = u_xlat12 * 0.00778222037;
          
          u_xlat1.x = u_xlat1.x / u_xlat10;
          
          u_xlatb1 = u_xlat1.x<0.834949017;
          
          u_xlat5.xy = float2(u_xlat12) * float2(-4.58941759e-06, 0.000198408336) + u_xlat1.yz;
          
          u_xlat13 = u_xlat12 * 0.239932507 + (-u_xlat1.w);
          
          u_xlat5.xy = u_xlat5.xy * float2(98.8431854, -58.8051376);
          
          u_xlat1.x = (u_xlatb1) ? u_xlat5.x : u_xlat5.y;
          
          u_xlat3.x = u_xlat1.x * 1.61047399 + u_xlat13;
          
          u_xlat3.x = clamp(u_xlat3.x, 0.0, 1.0);
          
          u_xlat5.x = u_xlat12 * -0.0504402146 + u_xlat2.x;
          
          u_xlat12 = u_xlat12 * -0.00292370259 + (-u_xlat2.y);
          
          u_xlat3.z = u_xlat1.x * 14.2738457 + u_xlat12;
          
          u_xlat3.z = clamp(u_xlat3.z, 0.0, 1.0);
          
          u_xlat3.y = (-u_xlat1.x) * 2.53264189 + u_xlat5.x;
          
          u_xlat3.y = clamp(u_xlat3.y, 0.0, 1.0);
          
          u_xlat1.xyz = (-u_xlat0_d.xyz) + u_xlat3.xyz;
          
          out_f.color.xyz = _Params.xxx * u_xlat1.xyz + u_xlat0_d.xyz;
          
          out_f.color.w = 1.0;
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
