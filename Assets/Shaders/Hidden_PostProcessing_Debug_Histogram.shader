Shader "Hidden/PostProcessing/Debug/Histogram"
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
      
      
      uniform float2 _Params;
      
      
      
      struct appdata_t
      {
          
          float3 vertex : POSITION0;
      
      };
      
      
      struct OUT_Data_Vert
      {
          
          float2 texcoord : TEXCOORD0;
          
          float texcoord1 : TEXCOORD1;
          
          float4 vertex : SV_POSITION;
      
      };
      
      
      struct v2f
      {
          
          float2 texcoord : TEXCOORD0;
          
          float texcoord1 : TEXCOORD1;
      
      };
      
      
      struct OUT_Data_Frag
      {
          
          float4 color : SV_Target0;
      
      };
      
      
      struct _HistogramBuffer_type 
          {
          
          uint[1] value;
      
      };
      
      
      layout(std430, binding = 0) readonly buffer _HistogramBuffer 
          {
          
          _HistogramBuffer_type _HistogramBuffer_buf[];
      
      };
      
      float2 u_xlat0;
      
      uint u_xlatu0;
      
      uint u_xlatu1;
      
      OUT_Data_Vert vert(appdata_t in_v)
      {
          
          u_xlatu0 = _HistogramBuffer_buf[0].value[(0 >> 2) + 0];
          
          u_xlatu1 = _HistogramBuffer_buf[1].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[2].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[3].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[4].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[5].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[6].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[7].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[8].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[9].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[10].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[11].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[12].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[13].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[14].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[15].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[16].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[17].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[18].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[19].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[20].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[21].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[22].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[23].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[24].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[25].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[26].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[27].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[28].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[29].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[30].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[31].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[32].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[33].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[34].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[35].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[36].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[37].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[38].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[39].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[40].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[41].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[42].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[43].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[44].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[45].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[46].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[47].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[48].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[49].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[50].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[51].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[52].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[53].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[54].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[55].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[56].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[57].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[58].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[59].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[60].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[61].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[62].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[63].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[64].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[65].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[66].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[67].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[68].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[69].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[70].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[71].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[72].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[73].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[74].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[75].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[76].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[77].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[78].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[79].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[80].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[81].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[82].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[83].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[84].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[85].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[86].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[87].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[88].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[89].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[90].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[91].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[92].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[93].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[94].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[95].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[96].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[97].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[98].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[99].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[100].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[101].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[102].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[103].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[104].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[105].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[106].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[107].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[108].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[109].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[110].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[111].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[112].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[113].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[114].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[115].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[116].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[117].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[118].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[119].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[120].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[121].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[122].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[123].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[124].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[125].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[126].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[127].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[128].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[129].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          out_v.vertex.xy = in_v.vertex.xy;
          
          out_v.vertex.zw = float2(0.0, 1.0);
          
          u_xlatu1 = _HistogramBuffer_buf[130].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[131].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[132].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[133].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[134].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[135].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[136].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[137].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[138].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[139].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[140].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[141].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[142].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[143].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[144].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[145].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[146].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[147].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[148].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[149].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[150].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[151].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[152].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[153].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[154].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[155].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[156].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[157].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[158].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[159].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[160].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[161].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[162].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[163].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[164].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[165].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[166].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[167].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[168].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[169].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[170].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[171].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[172].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[173].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[174].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[175].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[176].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[177].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[178].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[179].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[180].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[181].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[182].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[183].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[184].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[185].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[186].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[187].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[188].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[189].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[190].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[191].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[192].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[193].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[194].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[195].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[196].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[197].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[198].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[199].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[200].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[201].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[202].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[203].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[204].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[205].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[206].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[207].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[208].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[209].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[210].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[211].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[212].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[213].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[214].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[215].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[216].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[217].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[218].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[219].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[220].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[221].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[222].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[223].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[224].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[225].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[226].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[227].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[228].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[229].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[230].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[231].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[232].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[233].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[234].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[235].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[236].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[237].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[238].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[239].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[240].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[241].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[242].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[243].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[244].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[245].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[246].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[247].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[248].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[249].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[250].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[251].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[252].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[253].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[254].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlatu1 = _HistogramBuffer_buf[255].value[(0 >> 2) + 0];
          
          u_xlatu0 = max(u_xlatu1, u_xlatu0);
          
          u_xlat0.x = float(u_xlatu0);
          
          out_v.texcoord1 = _Params.y / u_xlat0.x;
          
          u_xlat0.xy = in_v.vertex.xy + float2(1.0, 1.0);
          
          out_v.texcoord.xy = u_xlat0.xy * float2(0.5, 0.5);
          
          return;
      
      }
      
      
      #define CODE_BLOCK_FRAGMENT
      
      precise float4 u_xlat_precise_vec4;
      
      precise int4 u_xlat_precise_ivec4;
      
      precise bool4 u_xlat_precise_bvec4;
      
      precise uint4 u_xlat_precise_uvec4;
      
      struct _HistogramBuffer_type 
          {
          
          uint[1] value;
      
      };
      
      
      layout(std430, binding = 0) readonly buffer _HistogramBuffer 
          {
          
          _HistogramBuffer_type _HistogramBuffer_buf[];
      
      };
      
      float u_xlat0_d;
      
      int u_xlatb0;
      
      float2 u_xlat1;
      
      uint2 u_xlatu1_d;
      
      float u_xlat2;
      
      uint u_xlatu2;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = in_f.texcoord.x * 255.0;
          
          u_xlat1.x = floor(u_xlat0_d);
          
          u_xlat0_d = fract(u_xlat0_d);
          
          u_xlatu1_d.x = uint(u_xlat1.x);
          
          u_xlatu1_d.y = u_xlatu1_d.x + 1u;
          
          u_xlatu1_d.x = _HistogramBuffer_buf[u_xlatu1_d.x].value[(0 >> 2) + 0];
          
          u_xlat1.xy = float2(u_xlatu1_d.xy);
          
          u_xlat2 = min(u_xlat1.y, 255.0);
          
          u_xlatu2 = uint(u_xlat2);
          
          u_xlatu2 = _HistogramBuffer_buf[u_xlatu2].value[(0 >> 2) + 0];
          
          u_xlat1.y = float(u_xlatu2);
          
          u_xlat1.xy = u_xlat1.xy * float2(in_f.texcoord1);
          
          u_xlat2 = u_xlat0_d * u_xlat1.y;
          
          u_xlat0_d = (-u_xlat0_d) + 1.0;
          
          u_xlat0_d = u_xlat1.x * u_xlat0_d + u_xlat2;
          
          u_xlat1.x = in_f.texcoord.y * _Params.y;
          
          u_xlat1.x = roundEven(u_xlat1.x);
          
          u_xlatu1_d.x = uint(u_xlat1.x);
          
          u_xlat1.x = float(u_xlatu1_d.x);
          
          u_xlatb0 = u_xlat0_d>=u_xlat1.x;
          
          out_f.color.xyz = int(u_xlatb0) ? float3(1.0, 1.0, 1.0) : float3(0.0, 0.0, 0.0);
          
          out_f.color.w = 1.0;
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
