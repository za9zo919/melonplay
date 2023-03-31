// Upgrade NOTE: commented out 'float3 _WorldSpaceCameraPos', a built-in variable

Shader "Hidden/PostProcessing/ScreenSpaceReflections"
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
      
      precise float4 u_xlat_precise_vec4;
      
      precise int4 u_xlat_precise_ivec4;
      
      precise bool4 u_xlat_precise_bvec4;
      
      precise uint4 u_xlat_precise_uvec4;
      
      
      // uniform float3 _WorldSpaceCameraPos;
      
      uniform float4 _ProjectionParams;
      
      uniform float4 _ZBufferParams;
      
      uniform float4 _Test_TexelSize;
      
      uniform float4 _ViewMatrix[4];
      
      uniform float4 _InverseProjectionMatrix[4];
      
      uniform float4 _ScreenSpaceProjectionMatrix[4];
      
      uniform float4 _Params;
      
      uniform float4 _Params2;
      
      uniform sampler2D _CameraDepthTexture;
      
      uniform sampler2D _CameraGBufferTexture2;
      
      uniform sampler2D _Noise;
      
      
      
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
      
      
      float4 phase0_Output0_1;
      
      float4 u_xlat0;
      
      OUT_Data_Vert vert(appdata_t in_v)
      {
          
          out_v.vertex.xy = in_v.vertex.xy;
          
          out_v.vertex.zw = float2(0.0, 1.0);
          
          u_xlat0 = in_v.vertex.xyxy + float4(1.0, 1.0, 1.0, 1.0);
          
          phase0_Output0_1 = u_xlat0 * float4(0.5, 0.5, 0.5, 0.5);
          
          out_v.texcoord = phase0_Output0_1.xy;
          
          out_v.texcoord1 = phase0_Output0_1.zw;
          
          return;
      
      }
      
      
      #define CODE_BLOCK_FRAGMENT
      
      precise float4 u_xlat_precise_vec4;
      
      precise int4 u_xlat_precise_ivec4;
      
      precise bool4 u_xlat_precise_bvec4;
      
      precise uint4 u_xlat_precise_uvec4;
      
      float4 u_xlat0_d;
      
      int u_xlatb0;
      
      float4 u_xlat1;
      
      int u_xlatb1;
      
      float4 u_xlat2;
      
      float4 u_xlat3;
      
      float4 u_xlat4;
      
      float4 u_xlat5;
      
      float4 u_xlat6;
      
      float4 u_xlat7;
      
      float4 u_xlat8;
      
      int u_xlati8;
      
      int u_xlatb8;
      
      float u_xlat9;
      
      int u_xlati9;
      
      int u_xlatb10;
      
      float2 u_xlat18;
      
      float u_xlat27;
      
      int u_xlati27;
      
      int u_xlatb27;
      
      float u_xlat28;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = texture(_CameraGBufferTexture2, in_f.texcoord1.xy);
          
          u_xlat27 = dot(u_xlat0_d, float4(1.0, 1.0, 1.0, 1.0));
          
          u_xlatb27 = u_xlat27==0.0;
          
          if(u_xlatb27)
      {
              
              out_f.color = float4(0.0, 0.0, 0.0, 0.0);
              
              return;
      
      }
          
          u_xlat27 = textureLod(_CameraDepthTexture, in_f.texcoord.xy, 0.0).x;
          
          u_xlat1.xy = in_f.texcoord.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
          
          u_xlat2 = u_xlat1.yyyy * _InverseProjectionMatrix[1];
          
          u_xlat1 = _InverseProjectionMatrix[0] * u_xlat1.xxxx + u_xlat2;
          
          u_xlat1 = _InverseProjectionMatrix[2] * float4(u_xlat27) + u_xlat1;
          
          u_xlat1 = u_xlat1 + _InverseProjectionMatrix[3];
          
          u_xlat1.xyz = u_xlat1.xyz / u_xlat1.www;
          
          u_xlatb27 = u_xlat1.z<(-_Params.z);
          
          if(u_xlatb27)
      {
              
              out_f.color = float4(0.0, 0.0, 0.0, 0.0);
              
              return;
      
      }
          
          u_xlat0_d.xyz = u_xlat0_d.xyz * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
          
          u_xlat2.xyz = u_xlat0_d.yyy * _ViewMatrix[1].xyz;
          
          u_xlat0_d.xyw = _ViewMatrix[0].xyz * u_xlat0_d.xxx + u_xlat2.xyz;
          
          u_xlat0_d.xyz = _ViewMatrix[2].xyz * u_xlat0_d.zzz + u_xlat0_d.xyw;
          
          u_xlat27 = dot(u_xlat1.xyz, u_xlat1.xyz);
          
          u_xlat27 = inversesqrt(u_xlat27);
          
          u_xlat2.xyz = float3(u_xlat27) * u_xlat1.xyz;
          
          u_xlat27 = dot(u_xlat2.xyz, u_xlat0_d.xyz);
          
          u_xlat27 = u_xlat27 + u_xlat27;
          
          u_xlat0_d.xyz = u_xlat0_d.xyz * (-float3(u_xlat27)) + u_xlat2.xyz;
          
          u_xlat27 = dot(u_xlat0_d.xyz, u_xlat0_d.xyz);
          
          u_xlat27 = inversesqrt(u_xlat27);
          
          u_xlat0_d.xyz = float3(u_xlat27) * u_xlat0_d.xyz;
          
          u_xlatb27 = 0.0<u_xlat0_d.z;
          
          if(u_xlatb27)
      {
              
              out_f.color = float4(0.0, 0.0, 0.0, 0.0);
              
              return;
      
      }
          
          u_xlat27 = u_xlat0_d.z * _Params.z + u_xlat1.z;
          
          u_xlatb27 = (-_ProjectionParams.y)<u_xlat27;
          
          u_xlat28 = (-u_xlat1.z) + (-_ProjectionParams.y);
          
          u_xlat28 = u_xlat28 / u_xlat0_d.z;
          
          u_xlat27 = (u_xlatb27) ? u_xlat28 : _Params.z;
          
          u_xlat0_d.xyz = u_xlat0_d.xyz * float3(u_xlat27) + u_xlat1.xyz;
          
          u_xlat2.xyz = u_xlat1.zzz * _ScreenSpaceProjectionMatrix[2].xyw;
          
          u_xlat3.z = _ScreenSpaceProjectionMatrix[0].x * u_xlat1.x + u_xlat2.x;
          
          u_xlat3.w = _ScreenSpaceProjectionMatrix[1].y * u_xlat1.y + u_xlat2.y;
          
          u_xlat1.xyw = u_xlat0_d.zzz * _ScreenSpaceProjectionMatrix[2].xyw;
          
          u_xlat3.x = _ScreenSpaceProjectionMatrix[0].x * u_xlat0_d.x + u_xlat1.x;
          
          u_xlat3.y = _ScreenSpaceProjectionMatrix[1].y * u_xlat0_d.y + u_xlat1.y;
          
          u_xlat2.zw = float2(1.0) / float2(u_xlat2.zz);
          
          u_xlat2.xy = float2(1.0) / float2(u_xlat1.ww);
          
          u_xlat4.w = u_xlat1.z * u_xlat2.w;
          
          u_xlat5 = u_xlat2.wzxy * u_xlat3.wzxy;
          
          u_xlat0_d.xy = u_xlat3.zw * u_xlat2.zw + (-u_xlat5.zw);
          
          u_xlat0_d.x = dot(u_xlat0_d.xy, u_xlat0_d.xy);
          
          u_xlatb0 = 9.99999975e-05>=u_xlat0_d.x;
          
          u_xlat0_d.x = u_xlatb0 ? 1.0 : float(0.0);
          
          u_xlat9 = max(_Test_TexelSize.y, _Test_TexelSize.x);
          
          u_xlat0_d.xy = u_xlat0_d.xx * float2(u_xlat9) + u_xlat5.wz;
          
          u_xlat5.zw = (-u_xlat3.wz) * u_xlat2.wz + u_xlat0_d.xy;
          
          u_xlatb0 = abs(u_xlat5.w)<abs(u_xlat5.z);
          
          u_xlat3 = (int(u_xlatb0)) ? u_xlat5 : u_xlat5.yxwz;
          
          u_xlati9 = int((0.0<u_xlat3.z) ? 0xFFFFFFFFu : uint(0));
          
          u_xlati27 = int((u_xlat3.z<0.0) ? 0xFFFFFFFFu : uint(0));
          
          u_xlati9 = (-u_xlati9) + u_xlati27;
          
          u_xlat5.x = float(u_xlati9);
          
          u_xlat9 = u_xlat5.x / u_xlat3.z;
          
          u_xlat18.x = u_xlat0_d.z * u_xlat2.y + (-u_xlat4.w);
          
          u_xlat5.w = u_xlat9 * u_xlat18.x;
          
          u_xlat5.y = u_xlat9 * u_xlat3.w;
          
          u_xlat18.x = (-u_xlat2.w) + u_xlat2.y;
          
          u_xlat5.z = u_xlat9 * u_xlat18.x;
          
          u_xlat9 = u_xlat1.z * -0.00999999978;
          
          u_xlat9 = min(u_xlat9, 1.0);
          
          u_xlat9 = (-u_xlat9) + 1.0;
          
          u_xlat1.xy = in_f.texcoord.xy * _Params2.yy;
          
          u_xlat1.z = u_xlat1.y * _Params2.x;
          
          u_xlat18.xy = u_xlat1.xz + _WorldSpaceCameraPos.xz;
          
          u_xlat18.x = textureLod(_Noise, u_xlat18.xy, 0.0).w;
          
          u_xlat9 = u_xlat9 * _Params2.z;
          
          u_xlat1 = float4(u_xlat9) * u_xlat5;
          
          u_xlat4.xy = u_xlat3.xy;
          
          u_xlat4.z = u_xlat2.w;
          
          u_xlat2 = u_xlat1 * u_xlat18.xxxx + u_xlat4;
          
          u_xlat3.x = intBitsToFloat(int(0xFFFFFFFFu));
          
          u_xlat4.x = float(0.0);
          
          u_xlat4.y = float(0.0);
          
          u_xlat4.z = float(0.0);
          
          u_xlat4.w = float(0.0);
          
          u_xlat6 = u_xlat2;
          
          u_xlat7.x = float(0.0);
          
          u_xlat7.y = float(0.0);
          
          u_xlat7.z = float(0.0);
          
          u_xlat7.w = float(0.0);
          
          u_xlat18.x = float(0.0);
          
          u_xlati27 = int(0);
          
          u_xlati8 = 0;
          
          while(true)
      {
              
              u_xlat1.x = float(u_xlati27);
              
              u_xlatb1 = u_xlat1.x>=_Params2.w;
              
              u_xlat8.x = 0.0;
              
              if(u_xlatb1)
      {
                  break;
      }
              
              u_xlat6 = u_xlat5 * float4(u_xlat9) + u_xlat6;
              
              u_xlat1.xy = u_xlat1.wz * float2(0.5, 0.5) + u_xlat6.wz;
              
              u_xlat1.x = u_xlat1.x / u_xlat1.y;
              
              u_xlatb10 = u_xlat18.x<u_xlat1.x;
              
              u_xlat18.x = (u_xlatb10) ? u_xlat18.x : u_xlat1.x;
              
              u_xlat1.xy = (int(u_xlatb0)) ? u_xlat6.yx : u_xlat6.xy;
              
              u_xlat3.yz = u_xlat1.xy * _Test_TexelSize.xy;
              
              u_xlat1.x = textureLod(_CameraDepthTexture, u_xlat3.yz, 0.0).x;
              
              u_xlat1.x = _ZBufferParams.z * u_xlat1.x + _ZBufferParams.w;
              
              u_xlat1.x = float(1.0) / u_xlat1.x;
              
              u_xlatb1 = u_xlat18.x<(-u_xlat1.x);
              
              u_xlat3.w = intBitsToFloat(u_xlati27 + 1);
              
              u_xlat8 = int(u_xlatb1) ? u_xlat3 : float4(0.0, 0.0, 0.0, 0.0);
              
              u_xlat4 = u_xlat8;
              
              u_xlat7 = u_xlat8;
              
              if(u_xlatb1)
      {
                  break;
      }
              
              u_xlatb8 = u_xlatb1;
              
              u_xlati27 = u_xlati27 + 1;
              
              u_xlat4.x = float(0.0);
              
              u_xlat4.y = float(0.0);
              
              u_xlat4.z = float(0.0);
              
              u_xlat4.w = float(0.0);
              
              u_xlat7.x = float(0.0);
              
              u_xlat7.y = float(0.0);
              
              u_xlat7.z = float(0.0);
              
              u_xlat7.w = float(0.0);
      
      }
          
          u_xlat0_d = (floatBitsToInt(u_xlat8.x) != 0) ? u_xlat4 : u_xlat7;
          
          u_xlat27 = float(floatBitsToInt(u_xlat0_d.w));
          
          out_f.color.z = u_xlat27 / _Params2.w;
          
          out_f.color.w = uintBitsToFloat(floatBitsToUint(u_xlat0_d.x) & 1065353216u);
          
          out_f.color.xy = u_xlat0_d.yz;
          
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
      
      precise float4 u_xlat_precise_vec4;
      
      precise int4 u_xlat_precise_ivec4;
      
      precise bool4 u_xlat_precise_bvec4;
      
      precise uint4 u_xlat_precise_uvec4;
      
      
      uniform float4 _MainTex_TexelSize;
      
      uniform float4 _Params;
      
      uniform sampler2D _MainTex;
      
      uniform sampler2D _Test;
      
      
      
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
      
      
      float4 phase0_Output0_1;
      
      float4 u_xlat0;
      
      OUT_Data_Vert vert(appdata_t in_v)
      {
          
          out_v.vertex.xy = in_v.vertex.xy;
          
          out_v.vertex.zw = float2(0.0, 1.0);
          
          u_xlat0 = in_v.vertex.xyxy + float4(1.0, 1.0, 1.0, 1.0);
          
          phase0_Output0_1 = u_xlat0 * float4(0.5, 0.5, 0.5, 0.5);
          
          out_v.texcoord = phase0_Output0_1.xy;
          
          out_v.texcoord1 = phase0_Output0_1.zw;
          
          return;
      
      }
      
      
      #define CODE_BLOCK_FRAGMENT
      
      precise float4 u_xlat_precise_vec4;
      
      precise int4 u_xlat_precise_ivec4;
      
      precise bool4 u_xlat_precise_bvec4;
      
      precise uint4 u_xlat_precise_uvec4;
      
      float4 u_xlat0_d;
      
      uint4 u_xlatu0;
      
      float3 u_xlat1;
      
      int u_xlatb1;
      
      float3 u_xlat2;
      
      float u_xlat3;
      
      float u_xlat9;
      
      float u_xlat10;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          float4 hlslcc_FragCoord = float4(gl_FragCoord.xyz, 1.0/gl_FragCoord.w);
          
          u_xlatu0.xy = uint2(int2(hlslcc_FragCoord.xy));
          
          u_xlatu0.z = uint(0u);
          
          u_xlatu0.w = uint(0u);
          
          u_xlat0_d = texelFetch(_Test, int2(u_xlatu0.xy), int(u_xlatu0.w));
          
          u_xlatb1 = u_xlat0_d.w==0.0;
          
          if(u_xlatb1)
      {
              
              out_f.color = texture(_MainTex, in_f.texcoord1.xy);
              
              return;
      
      }
          
          u_xlat1.xyz = textureLod(_MainTex, u_xlat0_d.xy, 0.0).xyz;
          
          u_xlat10 = max(u_xlat0_d.y, u_xlat0_d.x);
          
          u_xlat10 = (-u_xlat10) + 1.0;
          
          u_xlat2.x = min(u_xlat0_d.y, u_xlat0_d.x);
          
          u_xlat10 = min(u_xlat10, u_xlat2.x);
          
          u_xlat10 = u_xlat10 * 2.19178081;
          
          u_xlat10 = clamp(u_xlat10, 0.0, 1.0);
          
          u_xlat10 = inversesqrt(u_xlat10);
          
          u_xlat10 = float(1.0) / u_xlat10;
          
          u_xlat9 = u_xlat0_d.w * u_xlat10;
          
          u_xlat0_d.xy = u_xlat0_d.xy + float2(-0.5, -0.5);
          
          u_xlat2.yz = abs(u_xlat0_d.xy) * _Params.xx;
          
          u_xlat0_d.x = _MainTex_TexelSize.z * _MainTex_TexelSize.y;
          
          u_xlat2.x = u_xlat0_d.x * u_xlat2.y;
          
          u_xlat0_d.x = dot(u_xlat2.xz, u_xlat2.xz);
          
          u_xlat0_d.x = (-u_xlat0_d.x) + 1.0;
          
          u_xlat0_d.x = max(u_xlat0_d.x, 0.0);
          
          u_xlat3 = u_xlat0_d.x * u_xlat0_d.x;
          
          u_xlat3 = u_xlat3 * u_xlat3;
          
          u_xlat0_d.x = u_xlat3 * u_xlat0_d.x;
          
          u_xlat0_d.x = u_xlat0_d.x * u_xlat9;
          
          out_f.color.xyz = u_xlat0_d.xxx * u_xlat1.xyz;
          
          out_f.color.w = u_xlat0_d.z;
          
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
      
      precise float4 u_xlat_precise_vec4;
      
      precise int4 u_xlat_precise_ivec4;
      
      precise bool4 u_xlat_precise_bvec4;
      
      precise uint4 u_xlat_precise_uvec4;
      
      
      uniform float4 _MainTex_TexelSize;
      
      uniform sampler2D _MainTex;
      
      uniform sampler2D _History;
      
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
      
      
      float4 phase0_Output0_1;
      
      float4 u_xlat0;
      
      OUT_Data_Vert vert(appdata_t in_v)
      {
          
          out_v.vertex.xy = in_v.vertex.xy;
          
          out_v.vertex.zw = float2(0.0, 1.0);
          
          u_xlat0 = in_v.vertex.xyxy + float4(1.0, 1.0, 1.0, 1.0);
          
          phase0_Output0_1 = u_xlat0 * float4(0.5, 0.5, 0.5, 0.5);
          
          out_v.texcoord = phase0_Output0_1.xy;
          
          out_v.texcoord1 = phase0_Output0_1.zw;
          
          return;
      
      }
      
      
      #define CODE_BLOCK_FRAGMENT
      
      precise float4 u_xlat_precise_vec4;
      
      precise int4 u_xlat_precise_ivec4;
      
      precise bool4 u_xlat_precise_bvec4;
      
      precise uint4 u_xlat_precise_uvec4;
      
      float4 u_xlat0_d;
      
      float4 u_xlat1;
      
      float4 u_xlat2;
      
      float4 u_xlat3;
      
      float4 u_xlat4;
      
      float u_xlat6;
      
      float2 u_xlat13;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d.z = 0.0;
          
          u_xlat0_d.xyw = (-_MainTex_TexelSize.xyy);
          
          u_xlat0_d = u_xlat0_d + in_f.texcoord.xyxy;
          
          u_xlat1 = textureLod(_MainTex, u_xlat0_d.xy, 0.0);
          
          u_xlat0_d = textureLod(_MainTex, u_xlat0_d.zw, 0.0);
          
          u_xlat2 = min(u_xlat0_d, u_xlat1);
          
          u_xlat0_d = max(u_xlat0_d, u_xlat1);
          
          u_xlat1 = _MainTex_TexelSize.xyxy * float4(1.0, -1.0, -1.0, 1.0) + in_f.texcoord.xyxy;
          
          u_xlat3 = textureLod(_MainTex, u_xlat1.xy, 0.0);
          
          u_xlat1 = textureLod(_MainTex, u_xlat1.zw, 0.0);
          
          u_xlat2 = min(u_xlat2, u_xlat3);
          
          u_xlat0_d = max(u_xlat0_d, u_xlat3);
          
          u_xlat3.x = (-_MainTex_TexelSize.x);
          
          u_xlat3.y = float(0.0);
          
          u_xlat13.y = float(0.0);
          
          u_xlat3.xy = u_xlat3.xy + in_f.texcoord.xy;
          
          u_xlat4 = textureLod(_MainTex, u_xlat3.xy, 0.0);
          
          u_xlat2 = min(u_xlat2, u_xlat4);
          
          u_xlat0_d = max(u_xlat0_d, u_xlat4);
          
          u_xlat13.x = _MainTex_TexelSize.x;
          
          u_xlat3.xy = u_xlat13.xy + in_f.texcoord.xy;
          
          u_xlat3 = textureLod(_MainTex, u_xlat3.xy, 0.0);
          
          u_xlat2 = min(u_xlat2, u_xlat3);
          
          u_xlat0_d = max(u_xlat0_d, u_xlat3);
          
          u_xlat0_d = max(u_xlat1, u_xlat0_d);
          
          u_xlat1 = min(u_xlat1, u_xlat2);
          
          u_xlat2.x = 0.0;
          
          u_xlat2.y = _MainTex_TexelSize.y;
          
          u_xlat2.xy = u_xlat2.xy + in_f.texcoord.xy;
          
          u_xlat2 = textureLod(_MainTex, u_xlat2.xy, 0.0);
          
          u_xlat1 = min(u_xlat1, u_xlat2);
          
          u_xlat0_d = max(u_xlat0_d, u_xlat2);
          
          u_xlat2.xy = in_f.texcoord.xy + _MainTex_TexelSize.xy;
          
          u_xlat2 = textureLod(_MainTex, u_xlat2.xy, 0.0);
          
          u_xlat1 = min(u_xlat1, u_xlat2);
          
          u_xlat0_d = max(u_xlat0_d, u_xlat2);
          
          u_xlat2 = textureLod(_MainTex, in_f.texcoord1.xy, 0.0);
          
          u_xlat1 = min(u_xlat1, u_xlat2);
          
          u_xlat3.xy = textureLod(_CameraMotionVectorsTexture, in_f.texcoord1.xy, 0.0).xy;
          
          u_xlat13.xy = (-u_xlat3.xy) + in_f.texcoord.xy;
          
          u_xlat3.x = dot(u_xlat3.xy, u_xlat3.xy);
          
          u_xlat3.x = sqrt(u_xlat3.x);
          
          u_xlat3.x = (-_MainTex_TexelSize.z) * 0.00200000009 + u_xlat3.x;
          
          u_xlat4 = textureLod(_History, u_xlat13.xy, 0.0);
          
          u_xlat1 = max(u_xlat1, u_xlat4);
          
          u_xlat0_d = max(u_xlat0_d, u_xlat2);
          
          u_xlat0_d = min(u_xlat0_d, u_xlat1);
          
          u_xlat1.x = _MainTex_TexelSize.z * 0.00150000001;
          
          u_xlat1.x = float(1.0) / u_xlat1.x;
          
          u_xlat1.x = u_xlat1.x * u_xlat3.x;
          
          u_xlat1.x = clamp(u_xlat1.x, 0.0, 1.0);
          
          u_xlat6 = u_xlat1.x * -2.0 + 3.0;
          
          u_xlat1.x = u_xlat1.x * u_xlat1.x;
          
          u_xlat1.x = u_xlat1.x * u_xlat6;
          
          u_xlat1.x = min(u_xlat1.x, 1.0);
          
          u_xlat2.w = u_xlat1.x * 0.850000024;
          
          u_xlat1 = u_xlat0_d + (-u_xlat2);
          
          u_xlat0_d.x = u_xlat0_d.w * -25.0 + 0.949999988;
          
          u_xlat0_d.x = max(u_xlat0_d.x, 0.699999988);
          
          u_xlat0_d.x = min(u_xlat0_d.x, 0.949999988);
          
          out_f.color = u_xlat0_d.xxxx * u_xlat1 + u_xlat2;
          
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
      
      precise float4 u_xlat_precise_vec4;
      
      precise int4 u_xlat_precise_ivec4;
      
      precise bool4 u_xlat_precise_bvec4;
      
      precise uint4 u_xlat_precise_uvec4;
      
      
      uniform float4 _ZBufferParams;
      
      uniform float4 _InverseViewMatrix[4];
      
      uniform float4 _InverseProjectionMatrix[4];
      
      uniform float4 _Params;
      
      uniform sampler2D _MainTex;
      
      uniform sampler2D _CameraDepthTexture;
      
      uniform sampler2D _CameraReflectionsTexture;
      
      uniform sampler2D _CameraGBufferTexture0;
      
      uniform sampler2D _CameraGBufferTexture1;
      
      uniform sampler2D _CameraGBufferTexture2;
      
      uniform sampler2D _Resolve;
      
      
      
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
      
      
      float4 phase0_Output0_1;
      
      float4 u_xlat0;
      
      OUT_Data_Vert vert(appdata_t in_v)
      {
          
          out_v.vertex.xy = in_v.vertex.xy;
          
          out_v.vertex.zw = float2(0.0, 1.0);
          
          u_xlat0 = in_v.vertex.xyxy + float4(1.0, 1.0, 1.0, 1.0);
          
          phase0_Output0_1 = u_xlat0 * float4(0.5, 0.5, 0.5, 0.5);
          
          out_v.texcoord = phase0_Output0_1.xy;
          
          out_v.texcoord1 = phase0_Output0_1.zw;
          
          return;
      
      }
      
      
      #define CODE_BLOCK_FRAGMENT
      
      precise float4 u_xlat_precise_vec4;
      
      precise int4 u_xlat_precise_ivec4;
      
      precise bool4 u_xlat_precise_bvec4;
      
      precise uint4 u_xlat_precise_uvec4;
      
      float3 u_xlat0_d;
      
      uint4 u_xlatu0;
      
      int u_xlatb0;
      
      float u_xlat1;
      
      float4 u_xlat2;
      
      float4 u_xlat3;
      
      float4 u_xlat4;
      
      float3 u_xlat5;
      
      float3 u_xlat6;
      
      float u_xlat8;
      
      float u_xlat9;
      
      float u_xlat10;
      
      float2 u_xlat11;
      
      float u_xlat13;
      
      float u_xlat15;
      
      float u_xlat17;
      
      float u_xlat18;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          float4 hlslcc_FragCoord = float4(gl_FragCoord.xyz, 1.0/gl_FragCoord.w);
          
          u_xlat0_d.x = textureLod(_CameraDepthTexture, in_f.texcoord1.xy, 0.0).x;
          
          u_xlat0_d.x = _ZBufferParams.x * u_xlat0_d.x + _ZBufferParams.y;
          
          u_xlat0_d.x = float(1.0) / u_xlat0_d.x;
          
          u_xlatb0 = 0.999000013<u_xlat0_d.x;
          
          if(u_xlatb0)
      {
              
              out_f.color = texture(_MainTex, in_f.texcoord1.xy);
              
              return;
      
      }
          
          u_xlatu0.xy = uint2(int2(hlslcc_FragCoord.xy));
          
          u_xlatu0.z = uint(0u);
          
          u_xlatu0.w = uint(0u);
          
          u_xlat1 = texelFetch(_CameraGBufferTexture0, int2(u_xlatu0.xy), int(u_xlatu0.w)).w;
          
          u_xlat2 = texelFetch(_CameraGBufferTexture1, int2(u_xlatu0.xy), int(u_xlatu0.w));
          
          u_xlat0_d.xyz = texelFetch(_CameraGBufferTexture2, int2(u_xlatu0.xy), int(u_xlatu0.w)).xyz;
          
          u_xlat15 = max(u_xlat2.y, u_xlat2.x);
          
          u_xlat15 = max(u_xlat2.z, u_xlat15);
          
          u_xlat15 = (-u_xlat15) + 1.0;
          
          u_xlat0_d.xyz = u_xlat0_d.xyz * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
          
          u_xlat6.x = textureLod(_CameraDepthTexture, in_f.texcoord.xy, 0.0).x;
          
          u_xlat11.xy = in_f.texcoord.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
          
          u_xlat3 = u_xlat11.yyyy * _InverseProjectionMatrix[1];
          
          u_xlat3 = _InverseProjectionMatrix[0] * u_xlat11.xxxx + u_xlat3;
          
          u_xlat3 = _InverseProjectionMatrix[2] * u_xlat6.xxxx + u_xlat3;
          
          u_xlat3 = u_xlat3 + _InverseProjectionMatrix[3];
          
          u_xlat6.xyz = u_xlat3.xyz / u_xlat3.www;
          
          u_xlat3.x = dot(u_xlat6.xyz, u_xlat6.xyz);
          
          u_xlat3.x = inversesqrt(u_xlat3.x);
          
          u_xlat6.xyz = u_xlat6.xyz * u_xlat3.xxx;
          
          u_xlat3.xyz = u_xlat6.yyy * _InverseViewMatrix[1].xyz;
          
          u_xlat3.xyz = _InverseViewMatrix[0].xyz * u_xlat6.xxx + u_xlat3.xyz;
          
          u_xlat6.xyz = _InverseViewMatrix[2].xyz * u_xlat6.zzz + u_xlat3.xyz;
          
          u_xlat3.x = (-u_xlat2.w) + 1.0;
          
          u_xlat8 = u_xlat3.x * u_xlat3.x;
          
          u_xlat13 = _Params.w + -1.0;
          
          u_xlat13 = u_xlat8 * u_xlat13 + 1.0;
          
          u_xlat4 = textureLod(_Resolve, in_f.texcoord1.xy, u_xlat13);
          
          u_xlat13 = dot((-u_xlat6.xyz), u_xlat0_d.xyz);
          
          u_xlat18 = u_xlat13 + u_xlat13;
          
          u_xlat0_d.xyz = u_xlat0_d.xyz * (-float3(u_xlat18)) + (-u_xlat6.xyz);
          
          u_xlat18 = dot(u_xlat0_d.xyz, u_xlat0_d.xyz);
          
          u_xlat18 = inversesqrt(u_xlat18);
          
          u_xlat0_d.xyz = u_xlat0_d.xyz * float3(u_xlat18);
          
          u_xlat0_d.x = dot((-u_xlat6.xyz), u_xlat0_d.xyz);
          
          u_xlat0_d.x = u_xlat0_d.x + u_xlat0_d.x;
          
          u_xlat0_d.x = clamp(u_xlat0_d.x, 0.0, 1.0);
          
          u_xlat13 = u_xlat13;
          
          u_xlat13 = clamp(u_xlat13, 0.0, 1.0);
          
          u_xlat5.x = (-u_xlat3.x) * 0.0799999982 + 0.600000024;
          
          u_xlat10 = u_xlat3.x * u_xlat8;
          
          u_xlat5.x = (-u_xlat10) * u_xlat5.x + 1.0;
          
          u_xlat10 = (-u_xlat15) + u_xlat2.w;
          
          u_xlat10 = u_xlat10 + 1.0;
          
          u_xlat10 = clamp(u_xlat10, 0.0, 1.0);
          
          u_xlat6.xyz = u_xlat4.xyz * u_xlat5.xxx;
          
          u_xlat5.x = (-u_xlat13) + 1.0;
          
          u_xlat5.x = u_xlat5.x * u_xlat5.x;
          
          u_xlat5.x = u_xlat5.x * u_xlat5.x;
          
          u_xlat3.xyz = (-u_xlat2.xyz) + float3(u_xlat10);
          
          u_xlat5.xyz = u_xlat5.xxx * u_xlat3.xyz + u_xlat2.xyz;
          
          u_xlat2.xyz = texture(_CameraReflectionsTexture, in_f.texcoord1.xy).xyz;
          
          u_xlat3 = texture(_MainTex, in_f.texcoord1.xy);
          
          u_xlat3.xyz = (-u_xlat2.xyz) + u_xlat3.xyz;
          
          u_xlat3.xyz = max(u_xlat3.xyz, float3(0.0, 0.0, 0.0));
          
          u_xlat17 = u_xlat4.w * u_xlat4.w;
          
          u_xlat4.x = u_xlat17 * 3.0;
          
          u_xlat17 = u_xlat17 * 3.0 + -0.5;
          
          u_xlat17 = u_xlat17 + u_xlat17;
          
          u_xlat17 = clamp(u_xlat17, 0.0, 1.0);
          
          u_xlat9 = u_xlat17 * -2.0 + 3.0;
          
          u_xlat17 = u_xlat17 * u_xlat17;
          
          u_xlat17 = u_xlat17 * u_xlat9;
          
          u_xlat17 = u_xlat17 * u_xlat4.x;
          
          u_xlat17 = u_xlat17 * _Params.y;
          
          u_xlat17 = clamp(u_xlat17, 0.0, 1.0);
          
          u_xlat17 = (-u_xlat17) + 1.0;
          
          u_xlat0_d.x = u_xlat0_d.x * u_xlat17;
          
          u_xlat5.xyz = u_xlat6.xyz * u_xlat5.xyz + (-u_xlat2.xyz);
          
          u_xlat0_d.xyz = u_xlat0_d.xxx * u_xlat5.xyz + u_xlat2.xyz;
          
          out_f.color.xyz = u_xlat0_d.xyz * float3(u_xlat1) + u_xlat3.xyz;
          
          out_f.color.w = u_xlat3.w;
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
