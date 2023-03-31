Shader "Hidden/PostProcessing/DepthOfField"
{
  Properties
  {
  }
  SubShader
  {
    Tags
    { 
    }
    Pass // ind: 1, name: CoC Calculation
    {
      Name "CoC Calculation"
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
      
      uniform float4 _ZBufferParams;
      
      uniform float _Distance;
      
      uniform float _LensCoeff;
      
      uniform float _RcpMaxCoC;
      
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
      
      float4 u_xlat0_d;
      
      float u_xlat1;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = texture(_CameraDepthTexture, in_f.texcoord1.xy);
          
          u_xlat0_d.x = _ZBufferParams.z * u_xlat0_d.x + _ZBufferParams.w;
          
          u_xlat0_d.x = float(1.0) / u_xlat0_d.x;
          
          u_xlat1 = u_xlat0_d.x + (-_Distance);
          
          u_xlat0_d.x = max(u_xlat0_d.x, 9.99999975e-05);
          
          u_xlat1 = u_xlat1 * _LensCoeff;
          
          u_xlat0_d.x = u_xlat1 / u_xlat0_d.x;
          
          u_xlat0_d.x = u_xlat0_d.x * 0.5;
          
          u_xlat0_d.x = u_xlat0_d.x * _RcpMaxCoC + 0.5;
          
          out_f.color = u_xlat0_d.xxxx;
          
          out_f.color = clamp(out_f.color, 0.0, 1.0);
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
    Pass // ind: 2, name: CoC Temporal Filter
    {
      Name "CoC Temporal Filter"
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
      
      precise float4 u_xlat_precise_vec4;
      
      precise int4 u_xlat_precise_ivec4;
      
      precise bool4 u_xlat_precise_bvec4;
      
      precise uint4 u_xlat_precise_uvec4;
      
      
      uniform float _RenderViewportScaleFactor;
      
      uniform float4 _MainTex_TexelSize;
      
      uniform float3 _TaaParams;
      
      uniform sampler2D _CoCTex;
      
      uniform sampler2D _CameraMotionVectorsTexture;
      
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
      
      precise float4 u_xlat_precise_vec4;
      
      precise int4 u_xlat_precise_ivec4;
      
      precise bool4 u_xlat_precise_bvec4;
      
      precise uint4 u_xlat_precise_uvec4;
      
      float3 u_xlat0_d;
      
      float4 u_xlat1;
      
      float4 u_xlat2;
      
      float2 u_xlat3;
      
      float3 u_xlat5;
      
      int u_xlatb5;
      
      int u_xlatb6;
      
      float u_xlat8;
      
      int u_xlatb9;
      
      float2 u_xlat11;
      
      float u_xlat12;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d.xy = _MainTex_TexelSize.yy * float2(-0.0, -1.0);
          
          u_xlat1 = (-_MainTex_TexelSize.xyyy) * float4(1.0, 0.0, 0.0, 1.0) + in_f.texcoord.xyxy;
          
          u_xlat1 = clamp(u_xlat1, 0.0, 1.0);
          
          u_xlat1 = u_xlat1 * float4(_RenderViewportScaleFactor);
          
          u_xlat12 = texture(_CoCTex, u_xlat1.xy).x;
          
          u_xlat0_d.z = texture(_CoCTex, u_xlat1.zw).x;
          
          u_xlat1.xy = in_f.texcoord.xy + (-_TaaParams.xxyz.yz);
          
          u_xlat1.xy = clamp(u_xlat1.xy, 0.0, 1.0);
          
          u_xlat1.xy = u_xlat1.xy * float2(_RenderViewportScaleFactor);
          
          u_xlat1.x = texture(_CoCTex, u_xlat1.xy).x;
          
          u_xlatb5 = u_xlat12<u_xlat1.x;
          
          u_xlat2.z = (u_xlatb5) ? u_xlat12 : u_xlat1.x;
          
          u_xlat12 = max(u_xlat12, u_xlat1.x);
          
          u_xlat12 = max(u_xlat0_d.z, u_xlat12);
          
          u_xlatb9 = u_xlat0_d.z<u_xlat2.z;
          
          u_xlat3.xy = _MainTex_TexelSize.xy * float2(1.0, 0.0);
          
          u_xlat11.xy = (-u_xlat3.xy);
          
          u_xlat2.xy = int(u_xlatb5) ? u_xlat11.xy : float2(0.0, 0.0);
          
          u_xlat0_d.xyz = (int(u_xlatb9)) ? u_xlat0_d.xyz : u_xlat2.xyz;
          
          u_xlat2 = _MainTex_TexelSize.yyxy * float4(0.0, 1.0, 1.0, 0.0) + in_f.texcoord.xyxy;
          
          u_xlat2 = clamp(u_xlat2, 0.0, 1.0);
          
          u_xlat2 = u_xlat2 * float4(_RenderViewportScaleFactor);
          
          u_xlat5.z = texture(_CoCTex, u_xlat2.xy).x;
          
          u_xlat2.x = texture(_CoCTex, u_xlat2.zw).x;
          
          u_xlatb6 = u_xlat5.z<u_xlat0_d.z;
          
          u_xlat5.xy = _MainTex_TexelSize.yy * float2(0.0, 1.0);
          
          u_xlat12 = max(u_xlat12, u_xlat5.z);
          
          u_xlat12 = max(u_xlat2.x, u_xlat12);
          
          u_xlat0_d.xyz = (int(u_xlatb6)) ? u_xlat5.xyz : u_xlat0_d.xyz;
          
          u_xlatb5 = u_xlat2.x<u_xlat0_d.z;
          
          u_xlat8 = min(u_xlat2.x, u_xlat0_d.z);
          
          u_xlat0_d.xy = (int(u_xlatb5)) ? u_xlat3.xy : u_xlat0_d.xy;
          
          u_xlat0_d.xy = u_xlat0_d.xy + in_f.texcoord.xy;
          
          u_xlat0_d.xy = clamp(u_xlat0_d.xy, 0.0, 1.0);
          
          u_xlat0_d.xy = u_xlat0_d.xy * float2(_RenderViewportScaleFactor);
          
          u_xlat0_d.xy = texture(_CameraMotionVectorsTexture, u_xlat0_d.xy).xy;
          
          u_xlat0_d.xy = (-u_xlat0_d.xy) + in_f.texcoord.xy;
          
          u_xlat0_d.xy = clamp(u_xlat0_d.xy, 0.0, 1.0);
          
          u_xlat0_d.xy = u_xlat0_d.xy * float2(_RenderViewportScaleFactor);
          
          u_xlat0_d.x = texture(_MainTex, u_xlat0_d.xy).x;
          
          u_xlat0_d.x = max(u_xlat8, u_xlat0_d.x);
          
          u_xlat0_d.x = min(u_xlat12, u_xlat0_d.x);
          
          u_xlat0_d.x = (-u_xlat1.x) + u_xlat0_d.x;
          
          out_f.color = float4(_TaaParams.z, _TaaParams.z, _TaaParams.z, _TaaParams.z) * u_xlat0_d.xxxx + u_xlat1.xxxx;
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
    Pass // ind: 3, name: Downsample and Prefilter
    {
      Name "Downsample and Prefilter"
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
      
      precise float4 u_xlat_precise_vec4;
      
      precise int4 u_xlat_precise_ivec4;
      
      precise bool4 u_xlat_precise_bvec4;
      
      precise uint4 u_xlat_precise_uvec4;
      
      
      uniform float _RenderViewportScaleFactor;
      
      uniform float4 _MainTex_TexelSize;
      
      uniform float _MaxCoC;
      
      uniform sampler2D _MainTex;
      
      uniform sampler2D _CoCTex;
      
      
      
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
      
      precise float4 u_xlat_precise_vec4;
      
      precise int4 u_xlat_precise_ivec4;
      
      precise bool4 u_xlat_precise_bvec4;
      
      precise uint4 u_xlat_precise_uvec4;
      
      float4 u_xlat0_d;
      
      float3 u_xlat1;
      
      float4 u_xlat2;
      
      float3 u_xlat3;
      
      float u_xlat4;
      
      float u_xlat8;
      
      int u_xlatb8;
      
      float u_xlat12;
      
      float u_xlat13;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = (-_MainTex_TexelSize.xyxy) * float4(0.5, 0.5, -0.5, 0.5) + in_f.texcoord.xyxy;
          
          u_xlat0_d = clamp(u_xlat0_d, 0.0, 1.0);
          
          u_xlat0_d = u_xlat0_d * float4(_RenderViewportScaleFactor);
          
          u_xlat1.xyz = texture(_MainTex, u_xlat0_d.zw).xyz;
          
          u_xlat13 = max(u_xlat1.y, u_xlat1.x);
          
          u_xlat13 = max(u_xlat1.z, u_xlat13);
          
          u_xlat13 = u_xlat13 + 1.0;
          
          u_xlat8 = texture(_CoCTex, u_xlat0_d.zw).x;
          
          u_xlat8 = u_xlat8 * 2.0 + -1.0;
          
          u_xlat12 = abs(u_xlat8) / u_xlat13;
          
          u_xlat1.xyz = float3(u_xlat12) * u_xlat1.xyz;
          
          u_xlat2.xyz = texture(_MainTex, u_xlat0_d.xy).xyz;
          
          u_xlat0_d.x = texture(_CoCTex, u_xlat0_d.xy).x;
          
          u_xlat0_d.x = u_xlat0_d.x * 2.0 + -1.0;
          
          u_xlat4 = max(u_xlat2.y, u_xlat2.x);
          
          u_xlat4 = max(u_xlat2.z, u_xlat4);
          
          u_xlat4 = u_xlat4 + 1.0;
          
          u_xlat4 = abs(u_xlat0_d.x) / u_xlat4;
          
          u_xlat1.xyz = u_xlat2.xyz * float3(u_xlat4) + u_xlat1.xyz;
          
          u_xlat4 = u_xlat12 + u_xlat4;
          
          u_xlat2 = _MainTex_TexelSize.xyxy * float4(-0.5, 0.5, 0.5, 0.5) + in_f.texcoord.xyxy;
          
          u_xlat2 = clamp(u_xlat2, 0.0, 1.0);
          
          u_xlat2 = u_xlat2 * float4(_RenderViewportScaleFactor);
          
          u_xlat3.xyz = texture(_MainTex, u_xlat2.xy).xyz;
          
          u_xlat12 = max(u_xlat3.y, u_xlat3.x);
          
          u_xlat12 = max(u_xlat3.z, u_xlat12);
          
          u_xlat12 = u_xlat12 + 1.0;
          
          u_xlat13 = texture(_CoCTex, u_xlat2.xy).x;
          
          u_xlat13 = u_xlat13 * 2.0 + -1.0;
          
          u_xlat12 = abs(u_xlat13) / u_xlat12;
          
          u_xlat1.xyz = u_xlat3.xyz * float3(u_xlat12) + u_xlat1.xyz;
          
          u_xlat4 = u_xlat12 + u_xlat4;
          
          u_xlat3.xyz = texture(_MainTex, u_xlat2.zw).xyz;
          
          u_xlat12 = texture(_CoCTex, u_xlat2.zw).x;
          
          u_xlat12 = u_xlat12 * 2.0 + -1.0;
          
          u_xlat2.x = max(u_xlat3.y, u_xlat3.x);
          
          u_xlat2.x = max(u_xlat3.z, u_xlat2.x);
          
          u_xlat2.x = u_xlat2.x + 1.0;
          
          u_xlat2.x = abs(u_xlat12) / u_xlat2.x;
          
          u_xlat1.xyz = u_xlat3.xyz * u_xlat2.xxx + u_xlat1.xyz;
          
          u_xlat4 = u_xlat4 + u_xlat2.x;
          
          u_xlat4 = max(u_xlat4, 9.99999975e-05);
          
          u_xlat1.xyz = u_xlat1.xyz / float3(u_xlat4);
          
          u_xlat4 = min(u_xlat8, u_xlat13);
          
          u_xlat8 = max(u_xlat8, u_xlat13);
          
          u_xlat8 = max(u_xlat12, u_xlat8);
          
          u_xlat4 = min(u_xlat12, u_xlat4);
          
          u_xlat4 = min(u_xlat4, u_xlat0_d.x);
          
          u_xlat0_d.x = max(u_xlat8, u_xlat0_d.x);
          
          u_xlatb8 = u_xlat0_d.x<(-u_xlat4);
          
          u_xlat0_d.x = (u_xlatb8) ? u_xlat4 : u_xlat0_d.x;
          
          u_xlat0_d.x = u_xlat0_d.x * _MaxCoC;
          
          u_xlat4 = _MainTex_TexelSize.y + _MainTex_TexelSize.y;
          
          u_xlat4 = float(1.0) / u_xlat4;
          
          u_xlat4 = u_xlat4 * abs(u_xlat0_d.x);
          
          u_xlat4 = clamp(u_xlat4, 0.0, 1.0);
          
          out_f.color.w = u_xlat0_d.x;
          
          u_xlat0_d.x = u_xlat4 * -2.0 + 3.0;
          
          u_xlat4 = u_xlat4 * u_xlat4;
          
          u_xlat0_d.x = u_xlat4 * u_xlat0_d.x;
          
          out_f.color.xyz = u_xlat0_d.xxx * u_xlat1.xyz;
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
    Pass // ind: 4, name: Bokeh Filter (small)
    {
      Name "Bokeh Filter (small)"
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
      
      uniform float _MaxCoC;
      
      uniform float _RcpAspect;
      
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
      
      float4 ImmCB_0[16];
      
      float4 u_xlat0_d;
      
      int u_xlatb0;
      
      float4 u_xlat1;
      
      float4 u_xlat2;
      
      float4 u_xlat3;
      
      float4 u_xlat4;
      
      float u_xlat5;
      
      int u_xlati6;
      
      float u_xlat12;
      
      int u_xlatb12;
      
      float u_xlat18;
      
      int u_xlatb18;
      
      float u_xlat22;
      
      int u_xlatb22;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          ImmCB_0[0] = float4(0.0,0.0,0.0,0.0);
          
          ImmCB_0[1] = float4(0.545454562,0.0,0.0,0.0);
          
          ImmCB_0[2] = float4(0.168554723,0.518758118,0.0,0.0);
          
          ImmCB_0[3] = float4(-0.441282034,0.320610106,0.0,0.0);
          
          ImmCB_0[4] = float4(-0.441281974,-0.320610195,0.0,0.0);
          
          ImmCB_0[5] = float4(0.168554798,-0.518758118,0.0,0.0);
          
          ImmCB_0[6] = float4(1.0,0.0,0.0,0.0);
          
          ImmCB_0[7] = float4(0.809017003,0.587785244,0.0,0.0);
          
          ImmCB_0[8] = float4(0.309016973,0.95105654,0.0,0.0);
          
          ImmCB_0[9] = float4(-0.309017032,0.95105648,0.0,0.0);
          
          ImmCB_0[10] = float4(-0.809017062,0.587785184,0.0,0.0);
          
          ImmCB_0[11] = float4(-1.0,0.0,0.0,0.0);
          
          ImmCB_0[12] = float4(-0.809016943,-0.587785363,0.0,0.0);
          
          ImmCB_0[13] = float4(-0.309016645,-0.9510566,0.0,0.0);
          
          ImmCB_0[14] = float4(0.309017122,-0.95105648,0.0,0.0);
          
          ImmCB_0[15] = float4(0.809016943,-0.587785304,0.0,0.0);
          
          u_xlat0_d = texture(_MainTex, in_f.texcoord1.xy);
          
          u_xlat0_d.x = _MainTex_TexelSize.y + _MainTex_TexelSize.y;
          
          u_xlat1.w = 1.0;
          
          u_xlat2.x = float(0.0);
          
          u_xlat2.y = float(0.0);
          
          u_xlat2.z = float(0.0);
          
          u_xlat2.w = float(0.0);
          
          u_xlat3.x = float(0.0);
          
          u_xlat3.y = float(0.0);
          
          u_xlat3.z = float(0.0);
          
          u_xlat3.w = float(0.0);
          
          for(int u_xlati_loop_1 = 0 ; u_xlati_loop_1<16 ; u_xlati_loop_1++)
      
          
              {
              
              u_xlat4.yz = float2(float2(_MaxCoC, _MaxCoC)) * ImmCB_0[u_xlati_loop_1].xy;
              
              u_xlat12 = dot(u_xlat4.yz, u_xlat4.yz);
              
              u_xlat12 = sqrt(u_xlat12);
              
              u_xlat4.x = u_xlat4.y * _RcpAspect;
              
              u_xlat4.xy = u_xlat4.xz + in_f.texcoord.xy;
              
              u_xlat4.xy = clamp(u_xlat4.xy, 0.0, 1.0);
              
              u_xlat4.xy = u_xlat4.xy * float2(_RenderViewportScaleFactor);
              
              u_xlat4 = texture(_MainTex, u_xlat4.xy);
              
              u_xlat5 = min(u_xlat0_d.w, u_xlat4.w);
              
              u_xlat5 = max(u_xlat5, 0.0);
              
              u_xlat5 = (-u_xlat12) + u_xlat5;
              
              u_xlat5 = _MainTex_TexelSize.y * 2.0 + u_xlat5;
              
              u_xlat5 = u_xlat5 / u_xlat0_d.x;
              
              u_xlat5 = clamp(u_xlat5, 0.0, 1.0);
              
              u_xlat12 = (-u_xlat12) + (-u_xlat4.w);
              
              u_xlat12 = _MainTex_TexelSize.y * 2.0 + u_xlat12;
              
              u_xlat12 = u_xlat12 / u_xlat0_d.x;
              
              u_xlat12 = clamp(u_xlat12, 0.0, 1.0);
              
              u_xlatb22 = (-u_xlat4.w)>=_MainTex_TexelSize.y;
              
              u_xlat22 = u_xlatb22 ? 1.0 : float(0.0);
              
              u_xlat12 = u_xlat12 * u_xlat22;
              
              u_xlat1.xyz = u_xlat4.xyz;
              
              u_xlat2 = u_xlat1 * float4(u_xlat5) + u_xlat2;
              
              u_xlat3 = u_xlat1 * float4(u_xlat12) + u_xlat3;
      
      }
          
          u_xlatb0 = u_xlat2.w==0.0;
          
          u_xlat0_d.x = u_xlatb0 ? 1.0 : float(0.0);
          
          u_xlat0_d.x = u_xlat0_d.x + u_xlat2.w;
          
          u_xlat0_d.xyz = u_xlat2.xyz / u_xlat0_d.xxx;
          
          u_xlatb18 = u_xlat3.w==0.0;
          
          u_xlat18 = u_xlatb18 ? 1.0 : float(0.0);
          
          u_xlat18 = u_xlat18 + u_xlat3.w;
          
          u_xlat1.xyz = u_xlat3.xyz / float3(u_xlat18);
          
          u_xlat18 = u_xlat3.w * 0.196349546;
          
          u_xlat18 = min(u_xlat18, 1.0);
          
          u_xlat1.xyz = (-u_xlat0_d.xyz) + u_xlat1.xyz;
          
          out_f.color.xyz = float3(u_xlat18) * u_xlat1.xyz + u_xlat0_d.xyz;
          
          out_f.color.w = u_xlat18;
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
    Pass // ind: 5, name: Bokeh Filter (medium)
    {
      Name "Bokeh Filter (medium)"
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
      
      uniform float _MaxCoC;
      
      uniform float _RcpAspect;
      
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
      
      float4 ImmCB_0[22];
      
      float4 u_xlat0_d;
      
      int u_xlatb0;
      
      float4 u_xlat1;
      
      float4 u_xlat2;
      
      float4 u_xlat3;
      
      float4 u_xlat4;
      
      float u_xlat5;
      
      int u_xlati6;
      
      float u_xlat12;
      
      int u_xlatb12;
      
      float u_xlat18;
      
      int u_xlatb18;
      
      float u_xlat22;
      
      int u_xlatb22;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          ImmCB_0[0] = float4(0.0,0.0,0.0,0.0);
          
          ImmCB_0[1] = float4(0.533333361,0.0,0.0,0.0);
          
          ImmCB_0[2] = float4(0.332527906,0.41697681,0.0,0.0);
          
          ImmCB_0[3] = float4(-0.118677847,0.519961596,0.0,0.0);
          
          ImmCB_0[4] = float4(-0.480516732,0.231404707,0.0,0.0);
          
          ImmCB_0[5] = float4(-0.480516732,-0.231404677,0.0,0.0);
          
          ImmCB_0[6] = float4(-0.118677631,-0.519961655,0.0,0.0);
          
          ImmCB_0[7] = float4(0.332527846,-0.416976899,0.0,0.0);
          
          ImmCB_0[8] = float4(1.0,0.0,0.0,0.0);
          
          ImmCB_0[9] = float4(0.90096885,0.433883756,0.0,0.0);
          
          ImmCB_0[10] = float4(0.623489797,0.781831503,0.0,0.0);
          
          ImmCB_0[11] = float4(0.222520977,0.974927902,0.0,0.0);
          
          ImmCB_0[12] = float4(-0.222520947,0.974927902,0.0,0.0);
          
          ImmCB_0[13] = float4(-0.623489976,0.781831384,0.0,0.0);
          
          ImmCB_0[14] = float4(-0.90096885,0.433883816,0.0,0.0);
          
          ImmCB_0[15] = float4(-1.0,0.0,0.0,0.0);
          
          ImmCB_0[16] = float4(-0.90096885,-0.433883756,0.0,0.0);
          
          ImmCB_0[17] = float4(-0.623489618,-0.781831622,0.0,0.0);
          
          ImmCB_0[18] = float4(-0.222520545,-0.974928021,0.0,0.0);
          
          ImmCB_0[19] = float4(0.222521499,-0.974927783,0.0,0.0);
          
          ImmCB_0[20] = float4(0.623489678,-0.781831622,0.0,0.0);
          
          ImmCB_0[21] = float4(0.90096885,-0.433883756,0.0,0.0);
          
          u_xlat0_d = texture(_MainTex, in_f.texcoord1.xy);
          
          u_xlat0_d.x = _MainTex_TexelSize.y + _MainTex_TexelSize.y;
          
          u_xlat1.w = 1.0;
          
          u_xlat2.x = float(0.0);
          
          u_xlat2.y = float(0.0);
          
          u_xlat2.z = float(0.0);
          
          u_xlat2.w = float(0.0);
          
          u_xlat3.x = float(0.0);
          
          u_xlat3.y = float(0.0);
          
          u_xlat3.z = float(0.0);
          
          u_xlat3.w = float(0.0);
          
          for(int u_xlati_loop_1 = 0 ; u_xlati_loop_1<22 ; u_xlati_loop_1++)
      
          
              {
              
              u_xlat4.yz = float2(float2(_MaxCoC, _MaxCoC)) * ImmCB_0[u_xlati_loop_1].xy;
              
              u_xlat12 = dot(u_xlat4.yz, u_xlat4.yz);
              
              u_xlat12 = sqrt(u_xlat12);
              
              u_xlat4.x = u_xlat4.y * _RcpAspect;
              
              u_xlat4.xy = u_xlat4.xz + in_f.texcoord.xy;
              
              u_xlat4.xy = clamp(u_xlat4.xy, 0.0, 1.0);
              
              u_xlat4.xy = u_xlat4.xy * float2(_RenderViewportScaleFactor);
              
              u_xlat4 = texture(_MainTex, u_xlat4.xy);
              
              u_xlat5 = min(u_xlat0_d.w, u_xlat4.w);
              
              u_xlat5 = max(u_xlat5, 0.0);
              
              u_xlat5 = (-u_xlat12) + u_xlat5;
              
              u_xlat5 = _MainTex_TexelSize.y * 2.0 + u_xlat5;
              
              u_xlat5 = u_xlat5 / u_xlat0_d.x;
              
              u_xlat5 = clamp(u_xlat5, 0.0, 1.0);
              
              u_xlat12 = (-u_xlat12) + (-u_xlat4.w);
              
              u_xlat12 = _MainTex_TexelSize.y * 2.0 + u_xlat12;
              
              u_xlat12 = u_xlat12 / u_xlat0_d.x;
              
              u_xlat12 = clamp(u_xlat12, 0.0, 1.0);
              
              u_xlatb22 = (-u_xlat4.w)>=_MainTex_TexelSize.y;
              
              u_xlat22 = u_xlatb22 ? 1.0 : float(0.0);
              
              u_xlat12 = u_xlat12 * u_xlat22;
              
              u_xlat1.xyz = u_xlat4.xyz;
              
              u_xlat2 = u_xlat1 * float4(u_xlat5) + u_xlat2;
              
              u_xlat3 = u_xlat1 * float4(u_xlat12) + u_xlat3;
      
      }
          
          u_xlatb0 = u_xlat2.w==0.0;
          
          u_xlat0_d.x = u_xlatb0 ? 1.0 : float(0.0);
          
          u_xlat0_d.x = u_xlat0_d.x + u_xlat2.w;
          
          u_xlat0_d.xyz = u_xlat2.xyz / u_xlat0_d.xxx;
          
          u_xlatb18 = u_xlat3.w==0.0;
          
          u_xlat18 = u_xlatb18 ? 1.0 : float(0.0);
          
          u_xlat18 = u_xlat18 + u_xlat3.w;
          
          u_xlat1.xyz = u_xlat3.xyz / float3(u_xlat18);
          
          u_xlat18 = u_xlat3.w * 0.142799661;
          
          u_xlat18 = min(u_xlat18, 1.0);
          
          u_xlat1.xyz = (-u_xlat0_d.xyz) + u_xlat1.xyz;
          
          out_f.color.xyz = float3(u_xlat18) * u_xlat1.xyz + u_xlat0_d.xyz;
          
          out_f.color.w = u_xlat18;
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
    Pass // ind: 6, name: Bokeh Filter (large)
    {
      Name "Bokeh Filter (large)"
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
      
      uniform float _MaxCoC;
      
      uniform float _RcpAspect;
      
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
      
      float4 ImmCB_0[43];
      
      float4 u_xlat0_d;
      
      int u_xlatb0;
      
      float4 u_xlat1;
      
      float4 u_xlat2;
      
      float4 u_xlat3;
      
      float4 u_xlat4;
      
      float u_xlat5;
      
      int u_xlati6;
      
      float u_xlat12;
      
      int u_xlatb12;
      
      float u_xlat18;
      
      int u_xlatb18;
      
      float u_xlat22;
      
      int u_xlatb22;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          ImmCB_0[0] = float4(0.0,0.0,0.0,0.0);
          
          ImmCB_0[1] = float4(0.363636374,0.0,0.0,0.0);
          
          ImmCB_0[2] = float4(0.226723567,0.284302384,0.0,0.0);
          
          ImmCB_0[3] = float4(-0.0809167102,0.354519248,0.0,0.0);
          
          ImmCB_0[4] = float4(-0.327625036,0.157775939,0.0,0.0);
          
          ImmCB_0[5] = float4(-0.327625036,-0.157775909,0.0,0.0);
          
          ImmCB_0[6] = float4(-0.0809165612,-0.354519278,0.0,0.0);
          
          ImmCB_0[7] = float4(0.226723522,-0.284302413,0.0,0.0);
          
          ImmCB_0[8] = float4(0.681818187,0.0,0.0,0.0);
          
          ImmCB_0[9] = float4(0.614296973,0.295829833,0.0,0.0);
          
          ImmCB_0[10] = float4(0.425106674,0.533066928,0.0,0.0);
          
          ImmCB_0[11] = float4(0.151718855,0.664723575,0.0,0.0);
          
          ImmCB_0[12] = float4(-0.151718825,0.664723575,0.0,0.0);
          
          ImmCB_0[13] = float4(-0.425106794,0.533066869,0.0,0.0);
          
          ImmCB_0[14] = float4(-0.614296973,0.295829862,0.0,0.0);
          
          ImmCB_0[15] = float4(-0.681818187,0.0,0.0,0.0);
          
          ImmCB_0[16] = float4(-0.614296973,-0.295829833,0.0,0.0);
          
          ImmCB_0[17] = float4(-0.425106555,-0.533067048,0.0,0.0);
          
          ImmCB_0[18] = float4(-0.151718557,-0.664723635,0.0,0.0);
          
          ImmCB_0[19] = float4(0.151719198,-0.664723516,0.0,0.0);
          
          ImmCB_0[20] = float4(0.425106615,-0.533067048,0.0,0.0);
          
          ImmCB_0[21] = float4(0.614296973,-0.295829833,0.0,0.0);
          
          ImmCB_0[22] = float4(1.0,0.0,0.0,0.0);
          
          ImmCB_0[23] = float4(0.955572784,0.294755191,0.0,0.0);
          
          ImmCB_0[24] = float4(0.826238751,0.5633201,0.0,0.0);
          
          ImmCB_0[25] = float4(0.623489797,0.781831503,0.0,0.0);
          
          ImmCB_0[26] = float4(0.365340978,0.930873752,0.0,0.0);
          
          ImmCB_0[27] = float4(0.0747300014,0.997203827,0.0,0.0);
          
          ImmCB_0[28] = float4(-0.222520947,0.974927902,0.0,0.0);
          
          ImmCB_0[29] = float4(-0.50000006,0.866025388,0.0,0.0);
          
          ImmCB_0[30] = float4(-0.733051956,0.680172682,0.0,0.0);
          
          ImmCB_0[31] = float4(-0.90096885,0.433883816,0.0,0.0);
          
          ImmCB_0[32] = float4(-0.988830864,0.149042085,0.0,0.0);
          
          ImmCB_0[33] = float4(-0.988830805,-0.149042487,0.0,0.0);
          
          ImmCB_0[34] = float4(-0.90096885,-0.433883756,0.0,0.0);
          
          ImmCB_0[35] = float4(-0.733051836,-0.680172801,0.0,0.0);
          
          ImmCB_0[36] = float4(-0.499999911,-0.866025448,0.0,0.0);
          
          ImmCB_0[37] = float4(-0.222521007,-0.974927902,0.0,0.0);
          
          ImmCB_0[38] = float4(0.074730292,-0.997203767,0.0,0.0);
          
          ImmCB_0[39] = float4(0.365341485,-0.930873573,0.0,0.0);
          
          ImmCB_0[40] = float4(0.623489678,-0.781831622,0.0,0.0);
          
          ImmCB_0[41] = float4(0.826238811,-0.563319981,0.0,0.0);
          
          ImmCB_0[42] = float4(0.955572903,-0.294754833,0.0,0.0);
          
          u_xlat0_d = texture(_MainTex, in_f.texcoord1.xy);
          
          u_xlat0_d.x = _MainTex_TexelSize.y + _MainTex_TexelSize.y;
          
          u_xlat1.w = 1.0;
          
          u_xlat2.x = float(0.0);
          
          u_xlat2.y = float(0.0);
          
          u_xlat2.z = float(0.0);
          
          u_xlat2.w = float(0.0);
          
          u_xlat3.x = float(0.0);
          
          u_xlat3.y = float(0.0);
          
          u_xlat3.z = float(0.0);
          
          u_xlat3.w = float(0.0);
          
          for(int u_xlati_loop_1 = 0 ; u_xlati_loop_1<43 ; u_xlati_loop_1++)
      
          
              {
              
              u_xlat4.yz = float2(float2(_MaxCoC, _MaxCoC)) * ImmCB_0[u_xlati_loop_1].xy;
              
              u_xlat12 = dot(u_xlat4.yz, u_xlat4.yz);
              
              u_xlat12 = sqrt(u_xlat12);
              
              u_xlat4.x = u_xlat4.y * _RcpAspect;
              
              u_xlat4.xy = u_xlat4.xz + in_f.texcoord.xy;
              
              u_xlat4.xy = clamp(u_xlat4.xy, 0.0, 1.0);
              
              u_xlat4.xy = u_xlat4.xy * float2(_RenderViewportScaleFactor);
              
              u_xlat4 = texture(_MainTex, u_xlat4.xy);
              
              u_xlat5 = min(u_xlat0_d.w, u_xlat4.w);
              
              u_xlat5 = max(u_xlat5, 0.0);
              
              u_xlat5 = (-u_xlat12) + u_xlat5;
              
              u_xlat5 = _MainTex_TexelSize.y * 2.0 + u_xlat5;
              
              u_xlat5 = u_xlat5 / u_xlat0_d.x;
              
              u_xlat5 = clamp(u_xlat5, 0.0, 1.0);
              
              u_xlat12 = (-u_xlat12) + (-u_xlat4.w);
              
              u_xlat12 = _MainTex_TexelSize.y * 2.0 + u_xlat12;
              
              u_xlat12 = u_xlat12 / u_xlat0_d.x;
              
              u_xlat12 = clamp(u_xlat12, 0.0, 1.0);
              
              u_xlatb22 = (-u_xlat4.w)>=_MainTex_TexelSize.y;
              
              u_xlat22 = u_xlatb22 ? 1.0 : float(0.0);
              
              u_xlat12 = u_xlat12 * u_xlat22;
              
              u_xlat1.xyz = u_xlat4.xyz;
              
              u_xlat2 = u_xlat1 * float4(u_xlat5) + u_xlat2;
              
              u_xlat3 = u_xlat1 * float4(u_xlat12) + u_xlat3;
      
      }
          
          u_xlatb0 = u_xlat2.w==0.0;
          
          u_xlat0_d.x = u_xlatb0 ? 1.0 : float(0.0);
          
          u_xlat0_d.x = u_xlat0_d.x + u_xlat2.w;
          
          u_xlat0_d.xyz = u_xlat2.xyz / u_xlat0_d.xxx;
          
          u_xlatb18 = u_xlat3.w==0.0;
          
          u_xlat18 = u_xlatb18 ? 1.0 : float(0.0);
          
          u_xlat18 = u_xlat18 + u_xlat3.w;
          
          u_xlat1.xyz = u_xlat3.xyz / float3(u_xlat18);
          
          u_xlat18 = u_xlat3.w * 0.0730602965;
          
          u_xlat18 = min(u_xlat18, 1.0);
          
          u_xlat1.xyz = (-u_xlat0_d.xyz) + u_xlat1.xyz;
          
          out_f.color.xyz = float3(u_xlat18) * u_xlat1.xyz + u_xlat0_d.xyz;
          
          out_f.color.w = u_xlat18;
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
    Pass // ind: 7, name: Bokeh Filter (very large)
    {
      Name "Bokeh Filter (very large)"
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
      
      uniform float _MaxCoC;
      
      uniform float _RcpAspect;
      
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
      
      float4 ImmCB_0[71];
      
      float4 u_xlat0_d;
      
      int u_xlatb0;
      
      float4 u_xlat1;
      
      float4 u_xlat2;
      
      float4 u_xlat3;
      
      float4 u_xlat4;
      
      float u_xlat5;
      
      int u_xlati6;
      
      float u_xlat12;
      
      int u_xlatb12;
      
      float u_xlat18;
      
      int u_xlatb18;
      
      float u_xlat22;
      
      int u_xlatb22;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          ImmCB_0[0] = float4(0.0,0.0,0.0,0.0);
          
          ImmCB_0[1] = float4(0.275862098,0.0,0.0,0.0);
          
          ImmCB_0[2] = float4(0.171997204,0.215677679,0.0,0.0);
          
          ImmCB_0[3] = float4(-0.0613850951,0.268945664,0.0,0.0);
          
          ImmCB_0[4] = float4(-0.248543158,0.119692102,0.0,0.0);
          
          ImmCB_0[5] = float4(-0.248543158,-0.11969208,0.0,0.0);
          
          ImmCB_0[6] = float4(-0.0613849834,-0.268945694,0.0,0.0);
          
          ImmCB_0[7] = float4(0.171997175,-0.215677708,0.0,0.0);
          
          ImmCB_0[8] = float4(0.517241359,0.0,0.0,0.0);
          
          ImmCB_0[9] = float4(0.466018349,0.224422619,0.0,0.0);
          
          ImmCB_0[10] = float4(0.322494715,0.40439558,0.0,0.0);
          
          ImmCB_0[11] = float4(0.115097053,0.504273057,0.0,0.0);
          
          ImmCB_0[12] = float4(-0.115097038,0.504273057,0.0,0.0);
          
          ImmCB_0[13] = float4(-0.322494805,0.404395521,0.0,0.0);
          
          ImmCB_0[14] = float4(-0.466018349,0.224422649,0.0,0.0);
          
          ImmCB_0[15] = float4(-0.517241359,0.0,0.0,0.0);
          
          ImmCB_0[16] = float4(-0.466018349,-0.224422619,0.0,0.0);
          
          ImmCB_0[17] = float4(-0.322494626,-0.40439564,0.0,0.0);
          
          ImmCB_0[18] = float4(-0.11509683,-0.504273117,0.0,0.0);
          
          ImmCB_0[19] = float4(0.115097322,-0.504272997,0.0,0.0);
          
          ImmCB_0[20] = float4(0.322494656,-0.40439564,0.0,0.0);
          
          ImmCB_0[21] = float4(0.466018349,-0.224422619,0.0,0.0);
          
          ImmCB_0[22] = float4(0.758620679,0.0,0.0,0.0);
          
          ImmCB_0[23] = float4(0.724917293,0.223607376,0.0,0.0);
          
          ImmCB_0[24] = float4(0.626801789,0.427346289,0.0,0.0);
          
          ImmCB_0[25] = float4(0.472992241,0.593113542,0.0,0.0);
          
          ImmCB_0[26] = float4(0.277155221,0.706180096,0.0,0.0);
          
          ImmCB_0[27] = float4(0.0566917248,0.756499469,0.0,0.0);
          
          ImmCB_0[28] = float4(-0.168808997,0.73960048,0.0,0.0);
          
          ImmCB_0[29] = float4(-0.379310399,0.656984746,0.0,0.0);
          
          ImmCB_0[30] = float4(-0.556108356,0.515993059,0.0,0.0);
          
          ImmCB_0[31] = float4(-0.683493614,0.32915324,0.0,0.0);
          
          ImmCB_0[32] = float4(-0.750147521,0.113066405,0.0,0.0);
          
          ImmCB_0[33] = float4(-0.750147521,-0.113066711,0.0,0.0);
          
          ImmCB_0[34] = float4(-0.683493614,-0.32915318,0.0,0.0);
          
          ImmCB_0[35] = float4(-0.556108296,-0.515993178,0.0,0.0);
          
          ImmCB_0[36] = float4(-0.37931028,-0.656984806,0.0,0.0);
          
          ImmCB_0[37] = float4(-0.168809041,-0.73960048,0.0,0.0);
          
          ImmCB_0[38] = float4(0.0566919446,-0.75649941,0.0,0.0);
          
          ImmCB_0[39] = float4(0.277155608,-0.706179917,0.0,0.0);
          
          ImmCB_0[40] = float4(0.472992152,-0.593113661,0.0,0.0);
          
          ImmCB_0[41] = float4(0.626801848,-0.4273462,0.0,0.0);
          
          ImmCB_0[42] = float4(0.724917352,-0.223607108,0.0,0.0);
          
          ImmCB_0[43] = float4(1.0,0.0,0.0,0.0);
          
          ImmCB_0[44] = float4(0.974927902,0.222520933,0.0,0.0);
          
          ImmCB_0[45] = float4(0.90096885,0.433883756,0.0,0.0);
          
          ImmCB_0[46] = float4(0.781831503,0.623489797,0.0,0.0);
          
          ImmCB_0[47] = float4(0.623489797,0.781831503,0.0,0.0);
          
          ImmCB_0[48] = float4(0.433883637,0.900968909,0.0,0.0);
          
          ImmCB_0[49] = float4(0.222520977,0.974927902,0.0,0.0);
          
          ImmCB_0[50] = float4(0.0,1.0,0.0,0.0);
          
          ImmCB_0[51] = float4(-0.222520947,0.974927902,0.0,0.0);
          
          ImmCB_0[52] = float4(-0.433883846,0.90096885,0.0,0.0);
          
          ImmCB_0[53] = float4(-0.623489976,0.781831384,0.0,0.0);
          
          ImmCB_0[54] = float4(-0.781831682,0.623489559,0.0,0.0);
          
          ImmCB_0[55] = float4(-0.90096885,0.433883816,0.0,0.0);
          
          ImmCB_0[56] = float4(-0.974927902,0.222520933,0.0,0.0);
          
          ImmCB_0[57] = float4(-1.0,0.0,0.0,0.0);
          
          ImmCB_0[58] = float4(-0.974927902,-0.222520873,0.0,0.0);
          
          ImmCB_0[59] = float4(-0.90096885,-0.433883756,0.0,0.0);
          
          ImmCB_0[60] = float4(-0.781831384,-0.623489916,0.0,0.0);
          
          ImmCB_0[61] = float4(-0.623489618,-0.781831622,0.0,0.0);
          
          ImmCB_0[62] = float4(-0.433883458,-0.900969028,0.0,0.0);
          
          ImmCB_0[63] = float4(-0.222520545,-0.974928021,0.0,0.0);
          
          ImmCB_0[64] = float4(0.0,-1.0,0.0,0.0);
          
          ImmCB_0[65] = float4(0.222521499,-0.974927783,0.0,0.0);
          
          ImmCB_0[66] = float4(0.433883488,-0.900968969,0.0,0.0);
          
          ImmCB_0[67] = float4(0.623489678,-0.781831622,0.0,0.0);
          
          ImmCB_0[68] = float4(0.781831443,-0.623489857,0.0,0.0);
          
          ImmCB_0[69] = float4(0.90096885,-0.433883756,0.0,0.0);
          
          ImmCB_0[70] = float4(0.974927902,-0.222520858,0.0,0.0);
          
          u_xlat0_d = texture(_MainTex, in_f.texcoord1.xy);
          
          u_xlat0_d.x = _MainTex_TexelSize.y + _MainTex_TexelSize.y;
          
          u_xlat1.w = 1.0;
          
          u_xlat2.x = float(0.0);
          
          u_xlat2.y = float(0.0);
          
          u_xlat2.z = float(0.0);
          
          u_xlat2.w = float(0.0);
          
          u_xlat3.x = float(0.0);
          
          u_xlat3.y = float(0.0);
          
          u_xlat3.z = float(0.0);
          
          u_xlat3.w = float(0.0);
          
          for(int u_xlati_loop_1 = 0 ; u_xlati_loop_1<71 ; u_xlati_loop_1++)
      
          
              {
              
              u_xlat4.yz = float2(float2(_MaxCoC, _MaxCoC)) * ImmCB_0[u_xlati_loop_1].xy;
              
              u_xlat12 = dot(u_xlat4.yz, u_xlat4.yz);
              
              u_xlat12 = sqrt(u_xlat12);
              
              u_xlat4.x = u_xlat4.y * _RcpAspect;
              
              u_xlat4.xy = u_xlat4.xz + in_f.texcoord.xy;
              
              u_xlat4.xy = clamp(u_xlat4.xy, 0.0, 1.0);
              
              u_xlat4.xy = u_xlat4.xy * float2(_RenderViewportScaleFactor);
              
              u_xlat4 = texture(_MainTex, u_xlat4.xy);
              
              u_xlat5 = min(u_xlat0_d.w, u_xlat4.w);
              
              u_xlat5 = max(u_xlat5, 0.0);
              
              u_xlat5 = (-u_xlat12) + u_xlat5;
              
              u_xlat5 = _MainTex_TexelSize.y * 2.0 + u_xlat5;
              
              u_xlat5 = u_xlat5 / u_xlat0_d.x;
              
              u_xlat5 = clamp(u_xlat5, 0.0, 1.0);
              
              u_xlat12 = (-u_xlat12) + (-u_xlat4.w);
              
              u_xlat12 = _MainTex_TexelSize.y * 2.0 + u_xlat12;
              
              u_xlat12 = u_xlat12 / u_xlat0_d.x;
              
              u_xlat12 = clamp(u_xlat12, 0.0, 1.0);
              
              u_xlatb22 = (-u_xlat4.w)>=_MainTex_TexelSize.y;
              
              u_xlat22 = u_xlatb22 ? 1.0 : float(0.0);
              
              u_xlat12 = u_xlat12 * u_xlat22;
              
              u_xlat1.xyz = u_xlat4.xyz;
              
              u_xlat2 = u_xlat1 * float4(u_xlat5) + u_xlat2;
              
              u_xlat3 = u_xlat1 * float4(u_xlat12) + u_xlat3;
      
      }
          
          u_xlatb0 = u_xlat2.w==0.0;
          
          u_xlat0_d.x = u_xlatb0 ? 1.0 : float(0.0);
          
          u_xlat0_d.x = u_xlat0_d.x + u_xlat2.w;
          
          u_xlat0_d.xyz = u_xlat2.xyz / u_xlat0_d.xxx;
          
          u_xlatb18 = u_xlat3.w==0.0;
          
          u_xlat18 = u_xlatb18 ? 1.0 : float(0.0);
          
          u_xlat18 = u_xlat18 + u_xlat3.w;
          
          u_xlat1.xyz = u_xlat3.xyz / float3(u_xlat18);
          
          u_xlat18 = u_xlat3.w * 0.0442477837;
          
          u_xlat18 = min(u_xlat18, 1.0);
          
          u_xlat1.xyz = (-u_xlat0_d.xyz) + u_xlat1.xyz;
          
          out_f.color.xyz = float3(u_xlat18) * u_xlat1.xyz + u_xlat0_d.xyz;
          
          out_f.color.w = u_xlat18;
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
    Pass // ind: 8, name: Postfilter
    {
      Name "Postfilter"
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
          
          u_xlat0_d = (-_MainTex_TexelSize.xyxy) * float4(0.5, 0.5, -0.5, 0.5) + in_f.texcoord.xyxy;
          
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
          
          out_f.color = u_xlat0_d * float4(0.25, 0.25, 0.25, 0.25);
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
    Pass // ind: 9, name: Combine
    {
      Name "Combine"
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
      
      uniform float _MaxCoC;
      
      uniform sampler2D _DepthOfFieldTex;
      
      uniform sampler2D _CoCTex;
      
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
      
      float4 u_xlat2;
      
      float u_xlat3;
      
      float u_xlat6;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = texture(_CoCTex, in_f.texcoord1.xy);
          
          u_xlat0_d.x = u_xlat0_d.x + -0.5;
          
          u_xlat0_d.x = u_xlat0_d.x + u_xlat0_d.x;
          
          u_xlat3 = _MainTex_TexelSize.y + _MainTex_TexelSize.y;
          
          u_xlat0_d.x = u_xlat0_d.x * _MaxCoC + (-u_xlat3);
          
          u_xlat3 = float(1.0) / u_xlat3;
          
          u_xlat0_d.x = u_xlat3 * u_xlat0_d.x;
          
          u_xlat0_d.x = clamp(u_xlat0_d.x, 0.0, 1.0);
          
          u_xlat3 = u_xlat0_d.x * -2.0 + 3.0;
          
          u_xlat0_d.x = u_xlat0_d.x * u_xlat0_d.x;
          
          u_xlat6 = u_xlat0_d.x * u_xlat3;
          
          u_xlat1 = texture(_DepthOfFieldTex, in_f.texcoord1.xy);
          
          u_xlat0_d.x = u_xlat3 * u_xlat0_d.x + u_xlat1.w;
          
          u_xlat0_d.x = (-u_xlat6) * u_xlat1.w + u_xlat0_d.x;
          
          u_xlat3 = max(u_xlat1.y, u_xlat1.x);
          
          u_xlat1.w = max(u_xlat1.z, u_xlat3);
          
          u_xlat2 = texture(_MainTex, in_f.texcoord1.xy);
          
          u_xlat1 = u_xlat1 + (-u_xlat2);
          
          out_f.color = u_xlat0_d.xxxx * u_xlat1 + u_xlat2;
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
    Pass // ind: 10, name: Debug Overlay
    {
      Name "Debug Overlay"
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
      
      uniform float4 _ZBufferParams;
      
      uniform float _Distance;
      
      uniform float _LensCoeff;
      
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
      
      float4 u_xlat0_d;
      
      bool3 u_xlatb0;
      
      float4 u_xlat1;
      
      float3 u_xlat2;
      
      float u_xlat3;
      
      float u_xlat9;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = texture(_CameraDepthTexture, in_f.texcoord1.xy);
          
          u_xlat0_d.x = _ZBufferParams.z * u_xlat0_d.x + _ZBufferParams.w;
          
          u_xlat0_d.x = float(1.0) / u_xlat0_d.x;
          
          u_xlat3 = u_xlat0_d.x + (-_Distance);
          
          u_xlat3 = u_xlat3 * _LensCoeff;
          
          u_xlat0_d.x = u_xlat3 / u_xlat0_d.x;
          
          u_xlat0_d.x = u_xlat0_d.x * 80.0;
          
          u_xlat3 = u_xlat0_d.x;
          
          u_xlat3 = clamp(u_xlat3, 0.0, 1.0);
          
          u_xlat0_d.x = (-u_xlat0_d.x);
          
          u_xlat0_d.x = clamp(u_xlat0_d.x, 0.0, 1.0);
          
          u_xlat0_d.xzw = u_xlat0_d.xxx * float3(0.0, 1.0, 1.0) + float3(1.0, 0.0, 0.0);
          
          u_xlat1.xyz = (-u_xlat0_d.xww) + float3(0.400000006, 0.400000006, 0.400000006);
          
          u_xlat0_d.xyz = float3(u_xlat3) * u_xlat1.xyz + u_xlat0_d.xzw;
          
          u_xlat1 = texture(_MainTex, in_f.texcoord1.xy);
          
          u_xlat9 = dot(u_xlat1.xyz, float3(0.212672904, 0.715152204, 0.0721750036));
          
          u_xlat9 = u_xlat9 + 0.5;
          
          u_xlat1.xyz = u_xlat0_d.xzz * float3(u_xlat9) + float3(0.0549999997, 0.0549999997, 0.0549999997);
          
          u_xlat0_d.xyz = float3(u_xlat9) * u_xlat0_d.xyz;
          
          u_xlat1.xyz = u_xlat1.xyz * float3(0.947867334, 0.947867334, 0.947867334);
          
          u_xlat1.xyz = max(abs(u_xlat1.xyz), float3(1.1920929e-07, 1.1920929e-07, 1.1920929e-07));
          
          u_xlat1.xyz = log2(u_xlat1.xyz);
          
          u_xlat1.xyz = u_xlat1.xyz * float3(2.4000001, 2.4000001, 2.4000001);
          
          u_xlat1.xyz = exp2(u_xlat1.xyz);
          
          u_xlat2.xyz = u_xlat0_d.xzz * float3(0.0773993805, 0.0773993805, 0.0773993805);
          
          u_xlatb0.xyz = greaterThanEqual(float4(0.0404499993, 0.0404499993, 0.0404499993, 0.0), u_xlat0_d.xyzx).xyz;
          
          out_f.color.x = (u_xlatb0.x) ? u_xlat2.x : u_xlat1.x;
          
          out_f.color.y = (u_xlatb0.y) ? u_xlat2.y : u_xlat1.y;
          
          out_f.color.z = (u_xlatb0.z) ? u_xlat2.z : u_xlat1.z;
          
          out_f.color.w = 1.0;
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
  }
  SubShader
  {
    Tags
    { 
    }
    Pass // ind: 1, name: CoC Calculation
    {
      Name "CoC Calculation"
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
      
      uniform float4 _ZBufferParams;
      
      uniform float _Distance;
      
      uniform float _LensCoeff;
      
      uniform float _RcpMaxCoC;
      
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
      
      float4 u_xlat0_d;
      
      float u_xlat1;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = texture(_CameraDepthTexture, in_f.texcoord1.xy);
          
          u_xlat0_d.x = _ZBufferParams.z * u_xlat0_d.x + _ZBufferParams.w;
          
          u_xlat0_d.x = float(1.0) / u_xlat0_d.x;
          
          u_xlat1 = u_xlat0_d.x + (-_Distance);
          
          u_xlat0_d.x = max(u_xlat0_d.x, 9.99999975e-05);
          
          u_xlat1 = u_xlat1 * _LensCoeff;
          
          u_xlat0_d.x = u_xlat1 / u_xlat0_d.x;
          
          u_xlat0_d.x = u_xlat0_d.x * 0.5;
          
          u_xlat0_d.x = u_xlat0_d.x * _RcpMaxCoC + 0.5;
          
          out_f.color = u_xlat0_d.xxxx;
          
          out_f.color = clamp(out_f.color, 0.0, 1.0);
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
    Pass // ind: 2, name: CoC Temporal Filter
    {
      Name "CoC Temporal Filter"
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
      
      uniform float3 _TaaParams;
      
      uniform sampler2D _CoCTex;
      
      uniform sampler2D _CameraMotionVectorsTexture;
      
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
      
      float3 u_xlat0_d;
      
      float4 u_xlat1;
      
      float4 u_xlat2;
      
      float4 u_xlat3;
      
      float4 u_xlat4;
      
      float2 u_xlat6;
      
      float u_xlat10;
      
      int u_xlatb11;
      
      int u_xlatb15;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d.xy = _MainTex_TexelSize.yy * float2(-0.0, -1.0);
          
          u_xlat1 = (-_MainTex_TexelSize.xyyy) * float4(1.0, 0.0, 0.0, 1.0) + in_f.texcoord.xyxy;
          
          u_xlat1 = clamp(u_xlat1, 0.0, 1.0);
          
          u_xlat1 = u_xlat1 * float4(_RenderViewportScaleFactor);
          
          u_xlat2 = texture(_CoCTex, u_xlat1.xy);
          
          u_xlat1 = texture(_CoCTex, u_xlat1.zw);
          
          u_xlat6.xy = in_f.texcoord.xy + (-_TaaParams.xxyz.yz);
          
          u_xlat6.xy = clamp(u_xlat6.xy, 0.0, 1.0);
          
          u_xlat6.xy = u_xlat6.xy * float2(_RenderViewportScaleFactor);
          
          u_xlat3 = texture(_CoCTex, u_xlat6.xy);
          
          u_xlatb15 = u_xlat2.x<u_xlat3.x;
          
          u_xlat4.z = (u_xlatb15) ? u_xlat2.x : u_xlat3.x;
          
          u_xlat6.x = max(u_xlat2.x, u_xlat3.x);
          
          u_xlat6.x = max(u_xlat1.x, u_xlat6.x);
          
          u_xlatb11 = u_xlat1.x<u_xlat4.z;
          
          u_xlat0_d.z = u_xlat1.x;
          
          u_xlat1.xw = _MainTex_TexelSize.xy * float2(1.0, 0.0);
          
          u_xlat2.xy = (-u_xlat1.xw);
          
          u_xlat4.xy = int(u_xlatb15) ? u_xlat2.xy : float2(0.0, 0.0);
          
          u_xlat0_d.xyz = (int(u_xlatb11)) ? u_xlat0_d.xyz : u_xlat4.xyz;
          
          u_xlat2 = _MainTex_TexelSize.yyxy * float4(0.0, 1.0, 1.0, 0.0) + in_f.texcoord.xyxy;
          
          u_xlat2 = clamp(u_xlat2, 0.0, 1.0);
          
          u_xlat2 = u_xlat2 * float4(_RenderViewportScaleFactor);
          
          u_xlat4 = texture(_CoCTex, u_xlat2.xy).yzxw;
          
          u_xlat2 = texture(_CoCTex, u_xlat2.zw);
          
          u_xlatb15 = u_xlat4.z<u_xlat0_d.z;
          
          u_xlat4.xy = _MainTex_TexelSize.yy * float2(0.0, 1.0);
          
          u_xlat6.x = max(u_xlat6.x, u_xlat4.z);
          
          u_xlat6.x = max(u_xlat2.x, u_xlat6.x);
          
          u_xlat0_d.xyz = (int(u_xlatb15)) ? u_xlat4.xyz : u_xlat0_d.xyz;
          
          u_xlatb15 = u_xlat2.x<u_xlat0_d.z;
          
          u_xlat10 = min(u_xlat2.x, u_xlat0_d.z);
          
          u_xlat0_d.xy = (int(u_xlatb15)) ? u_xlat1.xw : u_xlat0_d.xy;
          
          u_xlat0_d.xy = u_xlat0_d.xy + in_f.texcoord.xy;
          
          u_xlat0_d.xy = clamp(u_xlat0_d.xy, 0.0, 1.0);
          
          u_xlat0_d.xy = u_xlat0_d.xy * float2(_RenderViewportScaleFactor);
          
          u_xlat2 = texture(_CameraMotionVectorsTexture, u_xlat0_d.xy);
          
          u_xlat0_d.xy = (-u_xlat2.xy) + in_f.texcoord.xy;
          
          u_xlat0_d.xy = clamp(u_xlat0_d.xy, 0.0, 1.0);
          
          u_xlat0_d.xy = u_xlat0_d.xy * float2(_RenderViewportScaleFactor);
          
          u_xlat2 = texture(_MainTex, u_xlat0_d.xy);
          
          u_xlat0_d.x = max(u_xlat10, u_xlat2.x);
          
          u_xlat0_d.x = min(u_xlat6.x, u_xlat0_d.x);
          
          u_xlat0_d.x = (-u_xlat3.x) + u_xlat0_d.x;
          
          out_f.color = float4(_TaaParams.z, _TaaParams.z, _TaaParams.z, _TaaParams.z) * u_xlat0_d.xxxx + u_xlat3.xxxx;
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
    Pass // ind: 3, name: Downsample and Prefilter
    {
      Name "Downsample and Prefilter"
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
      
      uniform float _MaxCoC;
      
      uniform sampler2D _MainTex;
      
      uniform sampler2D _CoCTex;
      
      
      
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
      
      float u_xlat5;
      
      float u_xlat10;
      
      int u_xlatb10;
      
      float u_xlat15;
      
      float u_xlat16;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = (-_MainTex_TexelSize.xyxy) * float4(0.5, 0.5, -0.5, 0.5) + in_f.texcoord.xyxy;
          
          u_xlat0_d = clamp(u_xlat0_d, 0.0, 1.0);
          
          u_xlat0_d = u_xlat0_d * float4(_RenderViewportScaleFactor);
          
          u_xlat1 = texture(_MainTex, u_xlat0_d.zw);
          
          u_xlat16 = max(u_xlat1.y, u_xlat1.x);
          
          u_xlat16 = max(u_xlat1.z, u_xlat16);
          
          u_xlat16 = u_xlat16 + 1.0;
          
          u_xlat2 = texture(_CoCTex, u_xlat0_d.zw);
          
          u_xlat10 = u_xlat2.x * 2.0 + -1.0;
          
          u_xlat15 = abs(u_xlat10) / u_xlat16;
          
          u_xlat1.xyz = float3(u_xlat15) * u_xlat1.xyz;
          
          u_xlat2 = texture(_MainTex, u_xlat0_d.xy);
          
          u_xlat3 = texture(_CoCTex, u_xlat0_d.xy);
          
          u_xlat0_d.x = u_xlat3.x * 2.0 + -1.0;
          
          u_xlat5 = max(u_xlat2.y, u_xlat2.x);
          
          u_xlat5 = max(u_xlat2.z, u_xlat5);
          
          u_xlat5 = u_xlat5 + 1.0;
          
          u_xlat5 = abs(u_xlat0_d.x) / u_xlat5;
          
          u_xlat1.xyz = u_xlat2.xyz * float3(u_xlat5) + u_xlat1.xyz;
          
          u_xlat5 = u_xlat15 + u_xlat5;
          
          u_xlat2 = _MainTex_TexelSize.xyxy * float4(-0.5, 0.5, 0.5, 0.5) + in_f.texcoord.xyxy;
          
          u_xlat2 = clamp(u_xlat2, 0.0, 1.0);
          
          u_xlat2 = u_xlat2 * float4(_RenderViewportScaleFactor);
          
          u_xlat3 = texture(_MainTex, u_xlat2.xy);
          
          u_xlat15 = max(u_xlat3.y, u_xlat3.x);
          
          u_xlat15 = max(u_xlat3.z, u_xlat15);
          
          u_xlat15 = u_xlat15 + 1.0;
          
          u_xlat4 = texture(_CoCTex, u_xlat2.xy);
          
          u_xlat16 = u_xlat4.x * 2.0 + -1.0;
          
          u_xlat15 = abs(u_xlat16) / u_xlat15;
          
          u_xlat1.xyz = u_xlat3.xyz * float3(u_xlat15) + u_xlat1.xyz;
          
          u_xlat5 = u_xlat15 + u_xlat5;
          
          u_xlat3 = texture(_MainTex, u_xlat2.zw);
          
          u_xlat2 = texture(_CoCTex, u_xlat2.zw);
          
          u_xlat15 = u_xlat2.x * 2.0 + -1.0;
          
          u_xlat2.x = max(u_xlat3.y, u_xlat3.x);
          
          u_xlat2.x = max(u_xlat3.z, u_xlat2.x);
          
          u_xlat2.x = u_xlat2.x + 1.0;
          
          u_xlat2.x = abs(u_xlat15) / u_xlat2.x;
          
          u_xlat1.xyz = u_xlat3.xyz * u_xlat2.xxx + u_xlat1.xyz;
          
          u_xlat5 = u_xlat5 + u_xlat2.x;
          
          u_xlat5 = max(u_xlat5, 9.99999975e-05);
          
          u_xlat1.xyz = u_xlat1.xyz / float3(u_xlat5);
          
          u_xlat5 = min(u_xlat10, u_xlat16);
          
          u_xlat10 = max(u_xlat10, u_xlat16);
          
          u_xlat10 = max(u_xlat15, u_xlat10);
          
          u_xlat5 = min(u_xlat15, u_xlat5);
          
          u_xlat5 = min(u_xlat5, u_xlat0_d.x);
          
          u_xlat0_d.x = max(u_xlat10, u_xlat0_d.x);
          
          u_xlatb10 = u_xlat0_d.x<(-u_xlat5);
          
          u_xlat0_d.x = (u_xlatb10) ? u_xlat5 : u_xlat0_d.x;
          
          u_xlat0_d.x = u_xlat0_d.x * _MaxCoC;
          
          u_xlat5 = _MainTex_TexelSize.y + _MainTex_TexelSize.y;
          
          u_xlat5 = float(1.0) / u_xlat5;
          
          u_xlat5 = u_xlat5 * abs(u_xlat0_d.x);
          
          u_xlat5 = clamp(u_xlat5, 0.0, 1.0);
          
          out_f.color.w = u_xlat0_d.x;
          
          u_xlat0_d.x = u_xlat5 * -2.0 + 3.0;
          
          u_xlat5 = u_xlat5 * u_xlat5;
          
          u_xlat0_d.x = u_xlat5 * u_xlat0_d.x;
          
          out_f.color.xyz = u_xlat0_d.xxx * u_xlat1.xyz;
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
    Pass // ind: 4, name: Bokeh Filter (small)
    {
      Name "Bokeh Filter (small)"
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
      
      uniform float _MaxCoC;
      
      uniform float _RcpAspect;
      
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
      
      float4 ImmCB_0[16];
      
      float4 u_xlat0_d;
      
      int u_xlatb0;
      
      float4 u_xlat1;
      
      float4 u_xlat2;
      
      float4 u_xlat3;
      
      float4 u_xlat4;
      
      float u_xlat5;
      
      int u_xlati6;
      
      float u_xlat12;
      
      int u_xlatb12;
      
      float u_xlat18;
      
      int u_xlatb18;
      
      float u_xlat22;
      
      int u_xlatb22;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          ImmCB_0[0] = float4(0.0,0.0,0.0,0.0);
          
          ImmCB_0[1] = float4(0.545454562,0.0,0.0,0.0);
          
          ImmCB_0[2] = float4(0.168554723,0.518758118,0.0,0.0);
          
          ImmCB_0[3] = float4(-0.441282034,0.320610106,0.0,0.0);
          
          ImmCB_0[4] = float4(-0.441281974,-0.320610195,0.0,0.0);
          
          ImmCB_0[5] = float4(0.168554798,-0.518758118,0.0,0.0);
          
          ImmCB_0[6] = float4(1.0,0.0,0.0,0.0);
          
          ImmCB_0[7] = float4(0.809017003,0.587785244,0.0,0.0);
          
          ImmCB_0[8] = float4(0.309016973,0.95105654,0.0,0.0);
          
          ImmCB_0[9] = float4(-0.309017032,0.95105648,0.0,0.0);
          
          ImmCB_0[10] = float4(-0.809017062,0.587785184,0.0,0.0);
          
          ImmCB_0[11] = float4(-1.0,0.0,0.0,0.0);
          
          ImmCB_0[12] = float4(-0.809016943,-0.587785363,0.0,0.0);
          
          ImmCB_0[13] = float4(-0.309016645,-0.9510566,0.0,0.0);
          
          ImmCB_0[14] = float4(0.309017122,-0.95105648,0.0,0.0);
          
          ImmCB_0[15] = float4(0.809016943,-0.587785304,0.0,0.0);
          
          u_xlat0_d = texture(_MainTex, in_f.texcoord1.xy);
          
          u_xlat0_d.x = _MainTex_TexelSize.y + _MainTex_TexelSize.y;
          
          u_xlat1.w = 1.0;
          
          u_xlat2.x = float(0.0);
          
          u_xlat2.y = float(0.0);
          
          u_xlat2.z = float(0.0);
          
          u_xlat2.w = float(0.0);
          
          u_xlat3.x = float(0.0);
          
          u_xlat3.y = float(0.0);
          
          u_xlat3.z = float(0.0);
          
          u_xlat3.w = float(0.0);
          
          for(int u_xlati_loop_1 = 0 ; u_xlati_loop_1<16 ; u_xlati_loop_1++)
      
          
              {
              
              u_xlat4.yz = float2(float2(_MaxCoC, _MaxCoC)) * ImmCB_0[u_xlati_loop_1].xy;
              
              u_xlat12 = dot(u_xlat4.yz, u_xlat4.yz);
              
              u_xlat12 = sqrt(u_xlat12);
              
              u_xlat4.x = u_xlat4.y * _RcpAspect;
              
              u_xlat4.xy = u_xlat4.xz + in_f.texcoord.xy;
              
              u_xlat4.xy = clamp(u_xlat4.xy, 0.0, 1.0);
              
              u_xlat4.xy = u_xlat4.xy * float2(_RenderViewportScaleFactor);
              
              u_xlat4 = texture(_MainTex, u_xlat4.xy);
              
              u_xlat5 = min(u_xlat0_d.w, u_xlat4.w);
              
              u_xlat5 = max(u_xlat5, 0.0);
              
              u_xlat5 = (-u_xlat12) + u_xlat5;
              
              u_xlat5 = _MainTex_TexelSize.y * 2.0 + u_xlat5;
              
              u_xlat5 = u_xlat5 / u_xlat0_d.x;
              
              u_xlat5 = clamp(u_xlat5, 0.0, 1.0);
              
              u_xlat12 = (-u_xlat12) + (-u_xlat4.w);
              
              u_xlat12 = _MainTex_TexelSize.y * 2.0 + u_xlat12;
              
              u_xlat12 = u_xlat12 / u_xlat0_d.x;
              
              u_xlat12 = clamp(u_xlat12, 0.0, 1.0);
              
              u_xlatb22 = (-u_xlat4.w)>=_MainTex_TexelSize.y;
              
              u_xlat22 = u_xlatb22 ? 1.0 : float(0.0);
              
              u_xlat12 = u_xlat12 * u_xlat22;
              
              u_xlat1.xyz = u_xlat4.xyz;
              
              u_xlat2 = u_xlat1 * float4(u_xlat5) + u_xlat2;
              
              u_xlat3 = u_xlat1 * float4(u_xlat12) + u_xlat3;
      
      }
          
          u_xlatb0 = u_xlat2.w==0.0;
          
          u_xlat0_d.x = u_xlatb0 ? 1.0 : float(0.0);
          
          u_xlat0_d.x = u_xlat0_d.x + u_xlat2.w;
          
          u_xlat0_d.xyz = u_xlat2.xyz / u_xlat0_d.xxx;
          
          u_xlatb18 = u_xlat3.w==0.0;
          
          u_xlat18 = u_xlatb18 ? 1.0 : float(0.0);
          
          u_xlat18 = u_xlat18 + u_xlat3.w;
          
          u_xlat1.xyz = u_xlat3.xyz / float3(u_xlat18);
          
          u_xlat18 = u_xlat3.w * 0.196349546;
          
          u_xlat18 = min(u_xlat18, 1.0);
          
          u_xlat1.xyz = (-u_xlat0_d.xyz) + u_xlat1.xyz;
          
          out_f.color.xyz = float3(u_xlat18) * u_xlat1.xyz + u_xlat0_d.xyz;
          
          out_f.color.w = u_xlat18;
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
    Pass // ind: 5, name: Bokeh Filter (medium)
    {
      Name "Bokeh Filter (medium)"
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
      
      uniform float _MaxCoC;
      
      uniform float _RcpAspect;
      
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
      
      float4 ImmCB_0[22];
      
      float4 u_xlat0_d;
      
      int u_xlatb0;
      
      float4 u_xlat1;
      
      float4 u_xlat2;
      
      float4 u_xlat3;
      
      float4 u_xlat4;
      
      float u_xlat5;
      
      int u_xlati6;
      
      float u_xlat12;
      
      int u_xlatb12;
      
      float u_xlat18;
      
      int u_xlatb18;
      
      float u_xlat22;
      
      int u_xlatb22;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          ImmCB_0[0] = float4(0.0,0.0,0.0,0.0);
          
          ImmCB_0[1] = float4(0.533333361,0.0,0.0,0.0);
          
          ImmCB_0[2] = float4(0.332527906,0.41697681,0.0,0.0);
          
          ImmCB_0[3] = float4(-0.118677847,0.519961596,0.0,0.0);
          
          ImmCB_0[4] = float4(-0.480516732,0.231404707,0.0,0.0);
          
          ImmCB_0[5] = float4(-0.480516732,-0.231404677,0.0,0.0);
          
          ImmCB_0[6] = float4(-0.118677631,-0.519961655,0.0,0.0);
          
          ImmCB_0[7] = float4(0.332527846,-0.416976899,0.0,0.0);
          
          ImmCB_0[8] = float4(1.0,0.0,0.0,0.0);
          
          ImmCB_0[9] = float4(0.90096885,0.433883756,0.0,0.0);
          
          ImmCB_0[10] = float4(0.623489797,0.781831503,0.0,0.0);
          
          ImmCB_0[11] = float4(0.222520977,0.974927902,0.0,0.0);
          
          ImmCB_0[12] = float4(-0.222520947,0.974927902,0.0,0.0);
          
          ImmCB_0[13] = float4(-0.623489976,0.781831384,0.0,0.0);
          
          ImmCB_0[14] = float4(-0.90096885,0.433883816,0.0,0.0);
          
          ImmCB_0[15] = float4(-1.0,0.0,0.0,0.0);
          
          ImmCB_0[16] = float4(-0.90096885,-0.433883756,0.0,0.0);
          
          ImmCB_0[17] = float4(-0.623489618,-0.781831622,0.0,0.0);
          
          ImmCB_0[18] = float4(-0.222520545,-0.974928021,0.0,0.0);
          
          ImmCB_0[19] = float4(0.222521499,-0.974927783,0.0,0.0);
          
          ImmCB_0[20] = float4(0.623489678,-0.781831622,0.0,0.0);
          
          ImmCB_0[21] = float4(0.90096885,-0.433883756,0.0,0.0);
          
          u_xlat0_d = texture(_MainTex, in_f.texcoord1.xy);
          
          u_xlat0_d.x = _MainTex_TexelSize.y + _MainTex_TexelSize.y;
          
          u_xlat1.w = 1.0;
          
          u_xlat2.x = float(0.0);
          
          u_xlat2.y = float(0.0);
          
          u_xlat2.z = float(0.0);
          
          u_xlat2.w = float(0.0);
          
          u_xlat3.x = float(0.0);
          
          u_xlat3.y = float(0.0);
          
          u_xlat3.z = float(0.0);
          
          u_xlat3.w = float(0.0);
          
          for(int u_xlati_loop_1 = 0 ; u_xlati_loop_1<22 ; u_xlati_loop_1++)
      
          
              {
              
              u_xlat4.yz = float2(float2(_MaxCoC, _MaxCoC)) * ImmCB_0[u_xlati_loop_1].xy;
              
              u_xlat12 = dot(u_xlat4.yz, u_xlat4.yz);
              
              u_xlat12 = sqrt(u_xlat12);
              
              u_xlat4.x = u_xlat4.y * _RcpAspect;
              
              u_xlat4.xy = u_xlat4.xz + in_f.texcoord.xy;
              
              u_xlat4.xy = clamp(u_xlat4.xy, 0.0, 1.0);
              
              u_xlat4.xy = u_xlat4.xy * float2(_RenderViewportScaleFactor);
              
              u_xlat4 = texture(_MainTex, u_xlat4.xy);
              
              u_xlat5 = min(u_xlat0_d.w, u_xlat4.w);
              
              u_xlat5 = max(u_xlat5, 0.0);
              
              u_xlat5 = (-u_xlat12) + u_xlat5;
              
              u_xlat5 = _MainTex_TexelSize.y * 2.0 + u_xlat5;
              
              u_xlat5 = u_xlat5 / u_xlat0_d.x;
              
              u_xlat5 = clamp(u_xlat5, 0.0, 1.0);
              
              u_xlat12 = (-u_xlat12) + (-u_xlat4.w);
              
              u_xlat12 = _MainTex_TexelSize.y * 2.0 + u_xlat12;
              
              u_xlat12 = u_xlat12 / u_xlat0_d.x;
              
              u_xlat12 = clamp(u_xlat12, 0.0, 1.0);
              
              u_xlatb22 = (-u_xlat4.w)>=_MainTex_TexelSize.y;
              
              u_xlat22 = u_xlatb22 ? 1.0 : float(0.0);
              
              u_xlat12 = u_xlat12 * u_xlat22;
              
              u_xlat1.xyz = u_xlat4.xyz;
              
              u_xlat2 = u_xlat1 * float4(u_xlat5) + u_xlat2;
              
              u_xlat3 = u_xlat1 * float4(u_xlat12) + u_xlat3;
      
      }
          
          u_xlatb0 = u_xlat2.w==0.0;
          
          u_xlat0_d.x = u_xlatb0 ? 1.0 : float(0.0);
          
          u_xlat0_d.x = u_xlat0_d.x + u_xlat2.w;
          
          u_xlat0_d.xyz = u_xlat2.xyz / u_xlat0_d.xxx;
          
          u_xlatb18 = u_xlat3.w==0.0;
          
          u_xlat18 = u_xlatb18 ? 1.0 : float(0.0);
          
          u_xlat18 = u_xlat18 + u_xlat3.w;
          
          u_xlat1.xyz = u_xlat3.xyz / float3(u_xlat18);
          
          u_xlat18 = u_xlat3.w * 0.142799661;
          
          u_xlat18 = min(u_xlat18, 1.0);
          
          u_xlat1.xyz = (-u_xlat0_d.xyz) + u_xlat1.xyz;
          
          out_f.color.xyz = float3(u_xlat18) * u_xlat1.xyz + u_xlat0_d.xyz;
          
          out_f.color.w = u_xlat18;
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
    Pass // ind: 6, name: Bokeh Filter (large)
    {
      Name "Bokeh Filter (large)"
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
      
      uniform float _MaxCoC;
      
      uniform float _RcpAspect;
      
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
      
      float4 ImmCB_0[43];
      
      float4 u_xlat0_d;
      
      int u_xlatb0;
      
      float4 u_xlat1;
      
      float4 u_xlat2;
      
      float4 u_xlat3;
      
      float4 u_xlat4;
      
      float u_xlat5;
      
      int u_xlati6;
      
      float u_xlat12;
      
      int u_xlatb12;
      
      float u_xlat18;
      
      int u_xlatb18;
      
      float u_xlat22;
      
      int u_xlatb22;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          ImmCB_0[0] = float4(0.0,0.0,0.0,0.0);
          
          ImmCB_0[1] = float4(0.363636374,0.0,0.0,0.0);
          
          ImmCB_0[2] = float4(0.226723567,0.284302384,0.0,0.0);
          
          ImmCB_0[3] = float4(-0.0809167102,0.354519248,0.0,0.0);
          
          ImmCB_0[4] = float4(-0.327625036,0.157775939,0.0,0.0);
          
          ImmCB_0[5] = float4(-0.327625036,-0.157775909,0.0,0.0);
          
          ImmCB_0[6] = float4(-0.0809165612,-0.354519278,0.0,0.0);
          
          ImmCB_0[7] = float4(0.226723522,-0.284302413,0.0,0.0);
          
          ImmCB_0[8] = float4(0.681818187,0.0,0.0,0.0);
          
          ImmCB_0[9] = float4(0.614296973,0.295829833,0.0,0.0);
          
          ImmCB_0[10] = float4(0.425106674,0.533066928,0.0,0.0);
          
          ImmCB_0[11] = float4(0.151718855,0.664723575,0.0,0.0);
          
          ImmCB_0[12] = float4(-0.151718825,0.664723575,0.0,0.0);
          
          ImmCB_0[13] = float4(-0.425106794,0.533066869,0.0,0.0);
          
          ImmCB_0[14] = float4(-0.614296973,0.295829862,0.0,0.0);
          
          ImmCB_0[15] = float4(-0.681818187,0.0,0.0,0.0);
          
          ImmCB_0[16] = float4(-0.614296973,-0.295829833,0.0,0.0);
          
          ImmCB_0[17] = float4(-0.425106555,-0.533067048,0.0,0.0);
          
          ImmCB_0[18] = float4(-0.151718557,-0.664723635,0.0,0.0);
          
          ImmCB_0[19] = float4(0.151719198,-0.664723516,0.0,0.0);
          
          ImmCB_0[20] = float4(0.425106615,-0.533067048,0.0,0.0);
          
          ImmCB_0[21] = float4(0.614296973,-0.295829833,0.0,0.0);
          
          ImmCB_0[22] = float4(1.0,0.0,0.0,0.0);
          
          ImmCB_0[23] = float4(0.955572784,0.294755191,0.0,0.0);
          
          ImmCB_0[24] = float4(0.826238751,0.5633201,0.0,0.0);
          
          ImmCB_0[25] = float4(0.623489797,0.781831503,0.0,0.0);
          
          ImmCB_0[26] = float4(0.365340978,0.930873752,0.0,0.0);
          
          ImmCB_0[27] = float4(0.0747300014,0.997203827,0.0,0.0);
          
          ImmCB_0[28] = float4(-0.222520947,0.974927902,0.0,0.0);
          
          ImmCB_0[29] = float4(-0.50000006,0.866025388,0.0,0.0);
          
          ImmCB_0[30] = float4(-0.733051956,0.680172682,0.0,0.0);
          
          ImmCB_0[31] = float4(-0.90096885,0.433883816,0.0,0.0);
          
          ImmCB_0[32] = float4(-0.988830864,0.149042085,0.0,0.0);
          
          ImmCB_0[33] = float4(-0.988830805,-0.149042487,0.0,0.0);
          
          ImmCB_0[34] = float4(-0.90096885,-0.433883756,0.0,0.0);
          
          ImmCB_0[35] = float4(-0.733051836,-0.680172801,0.0,0.0);
          
          ImmCB_0[36] = float4(-0.499999911,-0.866025448,0.0,0.0);
          
          ImmCB_0[37] = float4(-0.222521007,-0.974927902,0.0,0.0);
          
          ImmCB_0[38] = float4(0.074730292,-0.997203767,0.0,0.0);
          
          ImmCB_0[39] = float4(0.365341485,-0.930873573,0.0,0.0);
          
          ImmCB_0[40] = float4(0.623489678,-0.781831622,0.0,0.0);
          
          ImmCB_0[41] = float4(0.826238811,-0.563319981,0.0,0.0);
          
          ImmCB_0[42] = float4(0.955572903,-0.294754833,0.0,0.0);
          
          u_xlat0_d = texture(_MainTex, in_f.texcoord1.xy);
          
          u_xlat0_d.x = _MainTex_TexelSize.y + _MainTex_TexelSize.y;
          
          u_xlat1.w = 1.0;
          
          u_xlat2.x = float(0.0);
          
          u_xlat2.y = float(0.0);
          
          u_xlat2.z = float(0.0);
          
          u_xlat2.w = float(0.0);
          
          u_xlat3.x = float(0.0);
          
          u_xlat3.y = float(0.0);
          
          u_xlat3.z = float(0.0);
          
          u_xlat3.w = float(0.0);
          
          for(int u_xlati_loop_1 = 0 ; u_xlati_loop_1<43 ; u_xlati_loop_1++)
      
          
              {
              
              u_xlat4.yz = float2(float2(_MaxCoC, _MaxCoC)) * ImmCB_0[u_xlati_loop_1].xy;
              
              u_xlat12 = dot(u_xlat4.yz, u_xlat4.yz);
              
              u_xlat12 = sqrt(u_xlat12);
              
              u_xlat4.x = u_xlat4.y * _RcpAspect;
              
              u_xlat4.xy = u_xlat4.xz + in_f.texcoord.xy;
              
              u_xlat4.xy = clamp(u_xlat4.xy, 0.0, 1.0);
              
              u_xlat4.xy = u_xlat4.xy * float2(_RenderViewportScaleFactor);
              
              u_xlat4 = texture(_MainTex, u_xlat4.xy);
              
              u_xlat5 = min(u_xlat0_d.w, u_xlat4.w);
              
              u_xlat5 = max(u_xlat5, 0.0);
              
              u_xlat5 = (-u_xlat12) + u_xlat5;
              
              u_xlat5 = _MainTex_TexelSize.y * 2.0 + u_xlat5;
              
              u_xlat5 = u_xlat5 / u_xlat0_d.x;
              
              u_xlat5 = clamp(u_xlat5, 0.0, 1.0);
              
              u_xlat12 = (-u_xlat12) + (-u_xlat4.w);
              
              u_xlat12 = _MainTex_TexelSize.y * 2.0 + u_xlat12;
              
              u_xlat12 = u_xlat12 / u_xlat0_d.x;
              
              u_xlat12 = clamp(u_xlat12, 0.0, 1.0);
              
              u_xlatb22 = (-u_xlat4.w)>=_MainTex_TexelSize.y;
              
              u_xlat22 = u_xlatb22 ? 1.0 : float(0.0);
              
              u_xlat12 = u_xlat12 * u_xlat22;
              
              u_xlat1.xyz = u_xlat4.xyz;
              
              u_xlat2 = u_xlat1 * float4(u_xlat5) + u_xlat2;
              
              u_xlat3 = u_xlat1 * float4(u_xlat12) + u_xlat3;
      
      }
          
          u_xlatb0 = u_xlat2.w==0.0;
          
          u_xlat0_d.x = u_xlatb0 ? 1.0 : float(0.0);
          
          u_xlat0_d.x = u_xlat0_d.x + u_xlat2.w;
          
          u_xlat0_d.xyz = u_xlat2.xyz / u_xlat0_d.xxx;
          
          u_xlatb18 = u_xlat3.w==0.0;
          
          u_xlat18 = u_xlatb18 ? 1.0 : float(0.0);
          
          u_xlat18 = u_xlat18 + u_xlat3.w;
          
          u_xlat1.xyz = u_xlat3.xyz / float3(u_xlat18);
          
          u_xlat18 = u_xlat3.w * 0.0730602965;
          
          u_xlat18 = min(u_xlat18, 1.0);
          
          u_xlat1.xyz = (-u_xlat0_d.xyz) + u_xlat1.xyz;
          
          out_f.color.xyz = float3(u_xlat18) * u_xlat1.xyz + u_xlat0_d.xyz;
          
          out_f.color.w = u_xlat18;
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
    Pass // ind: 7, name: Bokeh Filter (very large)
    {
      Name "Bokeh Filter (very large)"
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
      
      uniform float _MaxCoC;
      
      uniform float _RcpAspect;
      
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
      
      float4 ImmCB_0[71];
      
      float4 u_xlat0_d;
      
      int u_xlatb0;
      
      float4 u_xlat1;
      
      float4 u_xlat2;
      
      float4 u_xlat3;
      
      float4 u_xlat4;
      
      float u_xlat5;
      
      int u_xlati6;
      
      float u_xlat12;
      
      int u_xlatb12;
      
      float u_xlat18;
      
      int u_xlatb18;
      
      float u_xlat22;
      
      int u_xlatb22;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          ImmCB_0[0] = float4(0.0,0.0,0.0,0.0);
          
          ImmCB_0[1] = float4(0.275862098,0.0,0.0,0.0);
          
          ImmCB_0[2] = float4(0.171997204,0.215677679,0.0,0.0);
          
          ImmCB_0[3] = float4(-0.0613850951,0.268945664,0.0,0.0);
          
          ImmCB_0[4] = float4(-0.248543158,0.119692102,0.0,0.0);
          
          ImmCB_0[5] = float4(-0.248543158,-0.11969208,0.0,0.0);
          
          ImmCB_0[6] = float4(-0.0613849834,-0.268945694,0.0,0.0);
          
          ImmCB_0[7] = float4(0.171997175,-0.215677708,0.0,0.0);
          
          ImmCB_0[8] = float4(0.517241359,0.0,0.0,0.0);
          
          ImmCB_0[9] = float4(0.466018349,0.224422619,0.0,0.0);
          
          ImmCB_0[10] = float4(0.322494715,0.40439558,0.0,0.0);
          
          ImmCB_0[11] = float4(0.115097053,0.504273057,0.0,0.0);
          
          ImmCB_0[12] = float4(-0.115097038,0.504273057,0.0,0.0);
          
          ImmCB_0[13] = float4(-0.322494805,0.404395521,0.0,0.0);
          
          ImmCB_0[14] = float4(-0.466018349,0.224422649,0.0,0.0);
          
          ImmCB_0[15] = float4(-0.517241359,0.0,0.0,0.0);
          
          ImmCB_0[16] = float4(-0.466018349,-0.224422619,0.0,0.0);
          
          ImmCB_0[17] = float4(-0.322494626,-0.40439564,0.0,0.0);
          
          ImmCB_0[18] = float4(-0.11509683,-0.504273117,0.0,0.0);
          
          ImmCB_0[19] = float4(0.115097322,-0.504272997,0.0,0.0);
          
          ImmCB_0[20] = float4(0.322494656,-0.40439564,0.0,0.0);
          
          ImmCB_0[21] = float4(0.466018349,-0.224422619,0.0,0.0);
          
          ImmCB_0[22] = float4(0.758620679,0.0,0.0,0.0);
          
          ImmCB_0[23] = float4(0.724917293,0.223607376,0.0,0.0);
          
          ImmCB_0[24] = float4(0.626801789,0.427346289,0.0,0.0);
          
          ImmCB_0[25] = float4(0.472992241,0.593113542,0.0,0.0);
          
          ImmCB_0[26] = float4(0.277155221,0.706180096,0.0,0.0);
          
          ImmCB_0[27] = float4(0.0566917248,0.756499469,0.0,0.0);
          
          ImmCB_0[28] = float4(-0.168808997,0.73960048,0.0,0.0);
          
          ImmCB_0[29] = float4(-0.379310399,0.656984746,0.0,0.0);
          
          ImmCB_0[30] = float4(-0.556108356,0.515993059,0.0,0.0);
          
          ImmCB_0[31] = float4(-0.683493614,0.32915324,0.0,0.0);
          
          ImmCB_0[32] = float4(-0.750147521,0.113066405,0.0,0.0);
          
          ImmCB_0[33] = float4(-0.750147521,-0.113066711,0.0,0.0);
          
          ImmCB_0[34] = float4(-0.683493614,-0.32915318,0.0,0.0);
          
          ImmCB_0[35] = float4(-0.556108296,-0.515993178,0.0,0.0);
          
          ImmCB_0[36] = float4(-0.37931028,-0.656984806,0.0,0.0);
          
          ImmCB_0[37] = float4(-0.168809041,-0.73960048,0.0,0.0);
          
          ImmCB_0[38] = float4(0.0566919446,-0.75649941,0.0,0.0);
          
          ImmCB_0[39] = float4(0.277155608,-0.706179917,0.0,0.0);
          
          ImmCB_0[40] = float4(0.472992152,-0.593113661,0.0,0.0);
          
          ImmCB_0[41] = float4(0.626801848,-0.4273462,0.0,0.0);
          
          ImmCB_0[42] = float4(0.724917352,-0.223607108,0.0,0.0);
          
          ImmCB_0[43] = float4(1.0,0.0,0.0,0.0);
          
          ImmCB_0[44] = float4(0.974927902,0.222520933,0.0,0.0);
          
          ImmCB_0[45] = float4(0.90096885,0.433883756,0.0,0.0);
          
          ImmCB_0[46] = float4(0.781831503,0.623489797,0.0,0.0);
          
          ImmCB_0[47] = float4(0.623489797,0.781831503,0.0,0.0);
          
          ImmCB_0[48] = float4(0.433883637,0.900968909,0.0,0.0);
          
          ImmCB_0[49] = float4(0.222520977,0.974927902,0.0,0.0);
          
          ImmCB_0[50] = float4(0.0,1.0,0.0,0.0);
          
          ImmCB_0[51] = float4(-0.222520947,0.974927902,0.0,0.0);
          
          ImmCB_0[52] = float4(-0.433883846,0.90096885,0.0,0.0);
          
          ImmCB_0[53] = float4(-0.623489976,0.781831384,0.0,0.0);
          
          ImmCB_0[54] = float4(-0.781831682,0.623489559,0.0,0.0);
          
          ImmCB_0[55] = float4(-0.90096885,0.433883816,0.0,0.0);
          
          ImmCB_0[56] = float4(-0.974927902,0.222520933,0.0,0.0);
          
          ImmCB_0[57] = float4(-1.0,0.0,0.0,0.0);
          
          ImmCB_0[58] = float4(-0.974927902,-0.222520873,0.0,0.0);
          
          ImmCB_0[59] = float4(-0.90096885,-0.433883756,0.0,0.0);
          
          ImmCB_0[60] = float4(-0.781831384,-0.623489916,0.0,0.0);
          
          ImmCB_0[61] = float4(-0.623489618,-0.781831622,0.0,0.0);
          
          ImmCB_0[62] = float4(-0.433883458,-0.900969028,0.0,0.0);
          
          ImmCB_0[63] = float4(-0.222520545,-0.974928021,0.0,0.0);
          
          ImmCB_0[64] = float4(0.0,-1.0,0.0,0.0);
          
          ImmCB_0[65] = float4(0.222521499,-0.974927783,0.0,0.0);
          
          ImmCB_0[66] = float4(0.433883488,-0.900968969,0.0,0.0);
          
          ImmCB_0[67] = float4(0.623489678,-0.781831622,0.0,0.0);
          
          ImmCB_0[68] = float4(0.781831443,-0.623489857,0.0,0.0);
          
          ImmCB_0[69] = float4(0.90096885,-0.433883756,0.0,0.0);
          
          ImmCB_0[70] = float4(0.974927902,-0.222520858,0.0,0.0);
          
          u_xlat0_d = texture(_MainTex, in_f.texcoord1.xy);
          
          u_xlat0_d.x = _MainTex_TexelSize.y + _MainTex_TexelSize.y;
          
          u_xlat1.w = 1.0;
          
          u_xlat2.x = float(0.0);
          
          u_xlat2.y = float(0.0);
          
          u_xlat2.z = float(0.0);
          
          u_xlat2.w = float(0.0);
          
          u_xlat3.x = float(0.0);
          
          u_xlat3.y = float(0.0);
          
          u_xlat3.z = float(0.0);
          
          u_xlat3.w = float(0.0);
          
          for(int u_xlati_loop_1 = 0 ; u_xlati_loop_1<71 ; u_xlati_loop_1++)
      
          
              {
              
              u_xlat4.yz = float2(float2(_MaxCoC, _MaxCoC)) * ImmCB_0[u_xlati_loop_1].xy;
              
              u_xlat12 = dot(u_xlat4.yz, u_xlat4.yz);
              
              u_xlat12 = sqrt(u_xlat12);
              
              u_xlat4.x = u_xlat4.y * _RcpAspect;
              
              u_xlat4.xy = u_xlat4.xz + in_f.texcoord.xy;
              
              u_xlat4.xy = clamp(u_xlat4.xy, 0.0, 1.0);
              
              u_xlat4.xy = u_xlat4.xy * float2(_RenderViewportScaleFactor);
              
              u_xlat4 = texture(_MainTex, u_xlat4.xy);
              
              u_xlat5 = min(u_xlat0_d.w, u_xlat4.w);
              
              u_xlat5 = max(u_xlat5, 0.0);
              
              u_xlat5 = (-u_xlat12) + u_xlat5;
              
              u_xlat5 = _MainTex_TexelSize.y * 2.0 + u_xlat5;
              
              u_xlat5 = u_xlat5 / u_xlat0_d.x;
              
              u_xlat5 = clamp(u_xlat5, 0.0, 1.0);
              
              u_xlat12 = (-u_xlat12) + (-u_xlat4.w);
              
              u_xlat12 = _MainTex_TexelSize.y * 2.0 + u_xlat12;
              
              u_xlat12 = u_xlat12 / u_xlat0_d.x;
              
              u_xlat12 = clamp(u_xlat12, 0.0, 1.0);
              
              u_xlatb22 = (-u_xlat4.w)>=_MainTex_TexelSize.y;
              
              u_xlat22 = u_xlatb22 ? 1.0 : float(0.0);
              
              u_xlat12 = u_xlat12 * u_xlat22;
              
              u_xlat1.xyz = u_xlat4.xyz;
              
              u_xlat2 = u_xlat1 * float4(u_xlat5) + u_xlat2;
              
              u_xlat3 = u_xlat1 * float4(u_xlat12) + u_xlat3;
      
      }
          
          u_xlatb0 = u_xlat2.w==0.0;
          
          u_xlat0_d.x = u_xlatb0 ? 1.0 : float(0.0);
          
          u_xlat0_d.x = u_xlat0_d.x + u_xlat2.w;
          
          u_xlat0_d.xyz = u_xlat2.xyz / u_xlat0_d.xxx;
          
          u_xlatb18 = u_xlat3.w==0.0;
          
          u_xlat18 = u_xlatb18 ? 1.0 : float(0.0);
          
          u_xlat18 = u_xlat18 + u_xlat3.w;
          
          u_xlat1.xyz = u_xlat3.xyz / float3(u_xlat18);
          
          u_xlat18 = u_xlat3.w * 0.0442477837;
          
          u_xlat18 = min(u_xlat18, 1.0);
          
          u_xlat1.xyz = (-u_xlat0_d.xyz) + u_xlat1.xyz;
          
          out_f.color.xyz = float3(u_xlat18) * u_xlat1.xyz + u_xlat0_d.xyz;
          
          out_f.color.w = u_xlat18;
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
    Pass // ind: 8, name: Postfilter
    {
      Name "Postfilter"
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
          
          u_xlat0_d = (-_MainTex_TexelSize.xyxy) * float4(0.5, 0.5, -0.5, 0.5) + in_f.texcoord.xyxy;
          
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
          
          out_f.color = u_xlat0_d * float4(0.25, 0.25, 0.25, 0.25);
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
    Pass // ind: 9, name: Combine
    {
      Name "Combine"
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
      
      uniform float _MaxCoC;
      
      uniform sampler2D _DepthOfFieldTex;
      
      uniform sampler2D _CoCTex;
      
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
      
      float4 u_xlat2;
      
      float u_xlat3;
      
      float u_xlat6;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = texture(_CoCTex, in_f.texcoord1.xy);
          
          u_xlat0_d.x = u_xlat0_d.x + -0.5;
          
          u_xlat0_d.x = u_xlat0_d.x + u_xlat0_d.x;
          
          u_xlat3 = _MainTex_TexelSize.y + _MainTex_TexelSize.y;
          
          u_xlat0_d.x = u_xlat0_d.x * _MaxCoC + (-u_xlat3);
          
          u_xlat3 = float(1.0) / u_xlat3;
          
          u_xlat0_d.x = u_xlat3 * u_xlat0_d.x;
          
          u_xlat0_d.x = clamp(u_xlat0_d.x, 0.0, 1.0);
          
          u_xlat3 = u_xlat0_d.x * -2.0 + 3.0;
          
          u_xlat0_d.x = u_xlat0_d.x * u_xlat0_d.x;
          
          u_xlat6 = u_xlat0_d.x * u_xlat3;
          
          u_xlat1 = texture(_DepthOfFieldTex, in_f.texcoord1.xy);
          
          u_xlat0_d.x = u_xlat3 * u_xlat0_d.x + u_xlat1.w;
          
          u_xlat0_d.x = (-u_xlat6) * u_xlat1.w + u_xlat0_d.x;
          
          u_xlat3 = max(u_xlat1.y, u_xlat1.x);
          
          u_xlat1.w = max(u_xlat1.z, u_xlat3);
          
          u_xlat2 = texture(_MainTex, in_f.texcoord1.xy);
          
          u_xlat1 = u_xlat1 + (-u_xlat2);
          
          out_f.color = u_xlat0_d.xxxx * u_xlat1 + u_xlat2;
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
    Pass // ind: 10, name: Debug Overlay
    {
      Name "Debug Overlay"
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
      
      uniform float4 _ZBufferParams;
      
      uniform float _Distance;
      
      uniform float _LensCoeff;
      
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
      
      float4 u_xlat0_d;
      
      bool3 u_xlatb0;
      
      float4 u_xlat1;
      
      float3 u_xlat2;
      
      float u_xlat3;
      
      float u_xlat9;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = texture(_CameraDepthTexture, in_f.texcoord1.xy);
          
          u_xlat0_d.x = _ZBufferParams.z * u_xlat0_d.x + _ZBufferParams.w;
          
          u_xlat0_d.x = float(1.0) / u_xlat0_d.x;
          
          u_xlat3 = u_xlat0_d.x + (-_Distance);
          
          u_xlat3 = u_xlat3 * _LensCoeff;
          
          u_xlat0_d.x = u_xlat3 / u_xlat0_d.x;
          
          u_xlat0_d.x = u_xlat0_d.x * 80.0;
          
          u_xlat3 = u_xlat0_d.x;
          
          u_xlat3 = clamp(u_xlat3, 0.0, 1.0);
          
          u_xlat0_d.x = (-u_xlat0_d.x);
          
          u_xlat0_d.x = clamp(u_xlat0_d.x, 0.0, 1.0);
          
          u_xlat0_d.xzw = u_xlat0_d.xxx * float3(0.0, 1.0, 1.0) + float3(1.0, 0.0, 0.0);
          
          u_xlat1.xyz = (-u_xlat0_d.xww) + float3(0.400000006, 0.400000006, 0.400000006);
          
          u_xlat0_d.xyz = float3(u_xlat3) * u_xlat1.xyz + u_xlat0_d.xzw;
          
          u_xlat1 = texture(_MainTex, in_f.texcoord1.xy);
          
          u_xlat9 = dot(u_xlat1.xyz, float3(0.212672904, 0.715152204, 0.0721750036));
          
          u_xlat9 = u_xlat9 + 0.5;
          
          u_xlat1.xyz = u_xlat0_d.xzz * float3(u_xlat9) + float3(0.0549999997, 0.0549999997, 0.0549999997);
          
          u_xlat0_d.xyz = float3(u_xlat9) * u_xlat0_d.xyz;
          
          u_xlat1.xyz = u_xlat1.xyz * float3(0.947867334, 0.947867334, 0.947867334);
          
          u_xlat1.xyz = max(abs(u_xlat1.xyz), float3(1.1920929e-07, 1.1920929e-07, 1.1920929e-07));
          
          u_xlat1.xyz = log2(u_xlat1.xyz);
          
          u_xlat1.xyz = u_xlat1.xyz * float3(2.4000001, 2.4000001, 2.4000001);
          
          u_xlat1.xyz = exp2(u_xlat1.xyz);
          
          u_xlat2.xyz = u_xlat0_d.xzz * float3(0.0773993805, 0.0773993805, 0.0773993805);
          
          u_xlatb0.xyz = greaterThanEqual(float4(0.0404499993, 0.0404499993, 0.0404499993, 0.0), u_xlat0_d.xyzx).xyz;
          
          out_f.color.x = (u_xlatb0.x) ? u_xlat2.x : u_xlat1.x;
          
          out_f.color.y = (u_xlatb0.y) ? u_xlat2.y : u_xlat1.y;
          
          out_f.color.z = (u_xlatb0.z) ? u_xlat2.z : u_xlat1.z;
          
          out_f.color.w = 1.0;
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
