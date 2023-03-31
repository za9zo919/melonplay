Shader "Hidden/PostProcessing/Debug/Waveform"
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
// Upgrade NOTE: excluded shader from DX11, OpenGL ES 2.0 because it uses unsized arrays
#pragma exclude_renderers d3d11 gles
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
      
      uniform float3 _Params;
      
      
      
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
          
          float4 vertex : Position;
      
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
      
      struct _WaveformBuffer_type 
          {
          
          uint[4] value;
      
      };
      
      
      layout(std430, binding = 0) readonly buffer _WaveformBuffer 
          {
          
          _WaveformBuffer_type _WaveformBuffer_buf[];
      
      };
      
      float4 u_xlat0_d;
      
      uint3 u_xlatu0;
      
      float3 u_xlat1;
      
      float3 u_xlat2;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          float4 hlslcc_FragCoord = float4(gl_FragCoord.xyz, 1.0/gl_FragCoord.w);
          
          u_xlatu0.xy = uint2(hlslcc_FragCoord.xy);
          
          u_xlat0_d.xy = float2(u_xlatu0.xy);
          
          u_xlat0_d.x = u_xlat0_d.x * _Params.y + u_xlat0_d.y;
          
          u_xlatu0.x = uint(u_xlat0_d.x);
          
          u_xlatu0.xyz = uint3(_WaveformBuffer_buf[u_xlatu0.x].value[(0 >> 2) + 0], _WaveformBuffer_buf[u_xlatu0.x].value[(0 >> 2) + 1], _WaveformBuffer_buf[u_xlatu0.x].value[(0 >> 2) + 2]);
          
          u_xlat0_d.xyz = float3(u_xlatu0.xyz);
          
          u_xlat1.xyz = u_xlat0_d.yyy * float3(0.0199999996, 1.10000002, 0.0500000007);
          
          u_xlat0_d.xyw = u_xlat0_d.xxx * float3(1.39999998, 0.0299999993, 0.0199999996) + u_xlat1.xyz;
          
          u_xlat0_d.xyz = u_xlat0_d.zzz * float3(0.0, 0.25, 1.5) + u_xlat0_d.xyw;
          
          u_xlat0_d.xyz = u_xlat0_d.xyz * _Params.zzz + float3(-0.00400000019, -0.00400000019, -0.00400000019);
          
          u_xlat0_d.xyz = max(u_xlat0_d.xyz, float3(0.0, 0.0, 0.0));
          
          u_xlat1.xyz = u_xlat0_d.xyz * float3(6.19999981, 6.19999981, 6.19999981) + float3(0.5, 0.5, 0.5);
          
          u_xlat1.xyz = u_xlat0_d.xyz * u_xlat1.xyz;
          
          u_xlat2.xyz = u_xlat0_d.xyz * float3(6.19999981, 6.19999981, 6.19999981) + float3(1.70000005, 1.70000005, 1.70000005);
          
          u_xlat0_d.xyz = u_xlat0_d.xyz * u_xlat2.xyz + float3(0.0599999987, 0.0599999987, 0.0599999987);
          
          u_xlat0_d.xyz = u_xlat1.xyz / u_xlat0_d.xyz;
          
          u_xlat0_d.xyz = u_xlat0_d.xyz * u_xlat0_d.xyz;
          
          out_f.color.xyz = min(u_xlat0_d.xyz, float3(1.0, 1.0, 1.0));
          
          out_f.color.w = 1.0;
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
