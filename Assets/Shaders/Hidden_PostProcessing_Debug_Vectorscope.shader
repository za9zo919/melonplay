Shader "Hidden/PostProcessing/Debug/Vectorscope"
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
      
      struct _VectorscopeBuffer_type 
          {
          
          uint[1] value;
      
      };
      
      
      layout(std430, binding = 0) readonly buffer _VectorscopeBuffer 
          {
          
          _VectorscopeBuffer_type _VectorscopeBuffer_buf[];
      
      };
      
      float4 u_xlat0_d;
      
      float3 u_xlat1;
      
      float2 u_xlat4;
      
      uint2 u_xlatu4;
      
      float u_xlat6;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = in_f.texcoord.xyxy * float4(-1.0, 1.0, -1.0, 1.0) + float4(0.5, -0.5, 1.0, 0.0);
          
          u_xlat4.xy = u_xlat0_d.zw * _Params.xy;
          
          u_xlatu4.xy = uint2(u_xlat4.xy);
          
          u_xlat4.xy = float2(u_xlatu4.xy);
          
          u_xlat4.x = u_xlat4.y * _Params.x + u_xlat4.x;
          
          u_xlatu4.x = uint(u_xlat4.x);
          
          u_xlatu4.x = _VectorscopeBuffer_buf[u_xlatu4.x].value[(0 >> 2) + 0];
          
          u_xlat4.x = float(u_xlatu4.x);
          
          u_xlat4.x = u_xlat4.x * _Params.z + -0.00400000019;
          
          u_xlat4.x = max(u_xlat4.x, 0.0);
          
          u_xlat1.xy = u_xlat4.xx * float2(6.19999981, 6.19999981) + float2(0.5, 1.70000005);
          
          u_xlat6 = u_xlat4.x * u_xlat1.x;
          
          u_xlat4.x = u_xlat4.x * u_xlat1.y + 0.0599999987;
          
          u_xlat4.x = u_xlat6 / u_xlat4.x;
          
          u_xlat4.x = u_xlat4.x * u_xlat4.x;
          
          u_xlat4.x = min(u_xlat4.x, 1.0);
          
          u_xlat0_d.x = (-u_xlat0_d.x) * 0.344000012 + 0.5;
          
          u_xlat1.y = (-u_xlat0_d.y) * 0.713999987 + u_xlat0_d.x;
          
          u_xlat1.xz = in_f.texcoord.yx * float2(1.403, 1.773) + float2(-0.201499999, -0.386500001);
          
          out_f.color.xyz = u_xlat4.xxx * (-u_xlat1.xyz) + u_xlat1.xyz;
          
          out_f.color.w = 1.0;
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
