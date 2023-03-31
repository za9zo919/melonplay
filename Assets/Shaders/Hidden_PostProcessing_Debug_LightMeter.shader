Shader "Hidden/PostProcessing/Debug/LightMeter"
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
      
      
      uniform float4 _Params;
      
      uniform float4 _ScaleOffsetRes;
      
      
      
      struct appdata_t
      {
          
          float3 vertex : POSITION0;
      
      };
      
      
      struct OUT_Data_Vert
      {
          
          float2 texcoord : TEXCOORD0;
          
          float texcoord1 : TEXCOORD1;
          
          float texcoord2 : TEXCOORD2;
          
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
      
      float u_xlat0;
      
      uint u_xlatu0;
      
      float2 u_xlat1;
      
      float3 u_xlat2;
      
      uint u_xlatu2;
      
      float4 u_xlat3;
      
      uint u_xlatu3;
      
      float3 u_xlat4;
      
      uint u_xlatu4;
      
      float3 u_xlat5;
      
      uint u_xlatu5;
      
      float3 u_xlat6;
      
      uint u_xlatu6;
      
      float3 u_xlat7;
      
      uint u_xlatu7;
      
      float3 u_xlat8;
      
      uint u_xlatu8;
      
      float3 u_xlat9;
      
      uint u_xlatu9;
      
      float3 u_xlat10;
      
      uint u_xlatu10;
      
      float3 u_xlat11;
      
      uint u_xlatu11;
      
      float3 u_xlat12;
      
      uint u_xlatu12;
      
      float3 u_xlat13;
      
      uint u_xlatu13;
      
      float3 u_xlat14;
      
      uint u_xlatu14;
      
      float3 u_xlat15;
      
      uint u_xlatu15;
      
      float3 u_xlat16;
      
      uint u_xlatu16;
      
      float3 u_xlat17;
      
      uint u_xlatu17;
      
      float3 u_xlat18;
      
      uint u_xlatu18;
      
      float3 u_xlat19;
      
      uint u_xlatu19;
      
      float3 u_xlat20;
      
      uint u_xlatu20;
      
      float3 u_xlat21;
      
      uint u_xlatu21;
      
      float3 u_xlat22;
      
      uint u_xlatu22;
      
      float3 u_xlat23;
      
      uint u_xlatu23;
      
      float3 u_xlat24;
      
      uint u_xlatu24;
      
      float3 u_xlat25;
      
      uint u_xlatu25;
      
      float3 u_xlat26;
      
      uint u_xlatu26;
      
      float3 u_xlat27;
      
      uint u_xlatu27;
      
      float3 u_xlat28;
      
      uint u_xlatu28;
      
      float3 u_xlat29;
      
      uint u_xlatu29;
      
      float3 u_xlat30;
      
      uint u_xlatu30;
      
      float3 u_xlat31;
      
      uint u_xlatu31;
      
      float3 u_xlat32;
      
      uint u_xlatu32;
      
      float3 u_xlat33;
      
      uint u_xlatu33;
      
      float3 u_xlat34;
      
      uint u_xlatu34;
      
      float3 u_xlat35;
      
      uint u_xlatu35;
      
      float3 u_xlat36;
      
      uint u_xlatu36;
      
      float3 u_xlat37;
      
      uint u_xlatu37;
      
      float3 u_xlat38;
      
      uint u_xlatu38;
      
      float3 u_xlat39;
      
      uint u_xlatu39;
      
      float3 u_xlat40;
      
      uint u_xlatu40;
      
      float3 u_xlat41;
      
      uint u_xlatu41;
      
      float3 u_xlat42;
      
      uint u_xlatu42;
      
      float3 u_xlat43;
      
      uint u_xlatu43;
      
      float3 u_xlat44;
      
      uint u_xlatu44;
      
      float3 u_xlat45;
      
      uint u_xlatu45;
      
      float3 u_xlat46;
      
      uint u_xlatu46;
      
      float3 u_xlat47;
      
      uint u_xlatu47;
      
      float3 u_xlat48;
      
      uint u_xlatu48;
      
      float3 u_xlat49;
      
      uint u_xlatu49;
      
      float3 u_xlat50;
      
      uint u_xlatu50;
      
      float3 u_xlat51;
      
      uint u_xlatu51;
      
      float3 u_xlat52;
      
      uint u_xlatu52;
      
      float3 u_xlat53;
      
      uint u_xlatu53;
      
      float3 u_xlat54;
      
      uint u_xlatu54;
      
      float3 u_xlat55;
      
      uint u_xlatu55;
      
      float3 u_xlat56;
      
      uint u_xlatu56;
      
      float3 u_xlat57;
      
      uint u_xlatu57;
      
      float3 u_xlat58;
      
      uint u_xlatu58;
      
      float3 u_xlat59;
      
      uint u_xlatu59;
      
      float3 u_xlat60;
      
      uint u_xlatu60;
      
      float3 u_xlat61;
      
      uint u_xlatu61;
      
      float3 u_xlat62;
      
      uint u_xlatu62;
      
      float3 u_xlat63;
      
      uint u_xlatu63;
      
      float u_xlat64;
      
      uint u_xlatu64;
      
      float4 u_xlat65;
      
      float2 u_xlat66;
      
      float4 u_xlat67;
      
      float2 u_xlat68;
      
      uint u_xlatu68;
      
      float2 u_xlat69;
      
      float3 u_xlat70;
      
      float3 u_xlat71;
      
      float3 u_xlat72;
      
      float3 u_xlat73;
      
      float3 u_xlat74;
      
      float3 u_xlat75;
      
      float3 u_xlat76;
      
      float3 u_xlat77;
      
      float3 u_xlat78;
      
      float3 u_xlat79;
      
      float3 u_xlat80;
      
      float3 u_xlat81;
      
      float3 u_xlat82;
      
      float3 u_xlat83;
      
      float3 u_xlat84;
      
      float3 u_xlat85;
      
      float3 u_xlat86;
      
      float3 u_xlat87;
      
      float3 u_xlat88;
      
      float3 u_xlat89;
      
      float3 u_xlat90;
      
      float3 u_xlat91;
      
      float3 u_xlat92;
      
      float3 u_xlat93;
      
      float3 u_xlat94;
      
      float3 u_xlat95;
      
      float3 u_xlat96;
      
      float3 u_xlat97;
      
      float3 u_xlat98;
      
      float3 u_xlat99;
      
      float3 u_xlat100;
      
      float3 u_xlat101;
      
      float3 u_xlat102;
      
      float3 u_xlat103;
      
      float3 u_xlat104;
      
      float3 u_xlat105;
      
      float3 u_xlat106;
      
      float3 u_xlat107;
      
      float3 u_xlat108;
      
      float3 u_xlat109;
      
      float3 u_xlat110;
      
      float3 u_xlat111;
      
      float3 u_xlat112;
      
      float3 u_xlat113;
      
      float3 u_xlat114;
      
      float3 u_xlat115;
      
      float3 u_xlat116;
      
      float3 u_xlat117;
      
      float3 u_xlat118;
      
      float3 u_xlat119;
      
      float3 u_xlat120;
      
      float3 u_xlat121;
      
      float3 u_xlat122;
      
      float3 u_xlat123;
      
      float3 u_xlat124;
      
      float3 u_xlat125;
      
      float3 u_xlat126;
      
      float3 u_xlat127;
      
      float3 u_xlat128;
      
      float3 u_xlat129;
      
      float3 u_xlat130;
      
      float3 u_xlat131;
      
      float u_xlat132;
      
      float u_xlat136;
      
      uint u_xlatu136;
      
      int u_xlatb136;
      
      float u_xlat137;
      
      uint u_xlatu137;
      
      uint u_xlatu138;
      
      uint u_xlatu139;
      
      uint u_xlatu140;
      
      uint u_xlatu141;
      
      uint u_xlatu142;
      
      uint u_xlatu143;
      
      uint u_xlatu144;
      
      uint u_xlatu145;
      
      uint u_xlatu146;
      
      uint u_xlatu147;
      
      uint u_xlatu148;
      
      uint u_xlatu149;
      
      uint u_xlatu150;
      
      uint u_xlatu151;
      
      uint u_xlatu152;
      
      uint u_xlatu153;
      
      uint u_xlatu154;
      
      uint u_xlatu155;
      
      uint u_xlatu156;
      
      uint u_xlatu157;
      
      uint u_xlatu158;
      
      uint u_xlatu159;
      
      uint u_xlatu160;
      
      uint u_xlatu161;
      
      uint u_xlatu162;
      
      uint u_xlatu163;
      
      uint u_xlatu164;
      
      uint u_xlatu165;
      
      uint u_xlatu166;
      
      uint u_xlatu167;
      
      uint u_xlatu168;
      
      uint u_xlatu169;
      
      uint u_xlatu170;
      
      uint u_xlatu171;
      
      uint u_xlatu172;
      
      uint u_xlatu173;
      
      uint u_xlatu174;
      
      uint u_xlatu175;
      
      uint u_xlatu176;
      
      uint u_xlatu177;
      
      uint u_xlatu178;
      
      uint u_xlatu179;
      
      uint u_xlatu180;
      
      uint u_xlatu181;
      
      uint u_xlatu182;
      
      uint u_xlatu183;
      
      uint u_xlatu184;
      
      uint u_xlatu185;
      
      uint u_xlatu186;
      
      uint u_xlatu187;
      
      uint u_xlatu188;
      
      uint u_xlatu189;
      
      uint u_xlatu190;
      
      uint u_xlatu191;
      
      uint u_xlatu192;
      
      uint u_xlatu193;
      
      uint u_xlatu194;
      
      uint u_xlatu195;
      
      uint u_xlatu196;
      
      uint u_xlatu197;
      
      uint u_xlatu198;
      
      uint u_xlatu199;
      
      float u_xlat200;
      
      float u_xlat204;
      
      uint u_xlatu204;
      
      float u_xlat205;
      
      OUT_Data_Vert vert(appdata_t in_v)
      {
          
          u_xlatu0 = uint(0u);
          
          u_xlatu68 = uint(0u);
          
          while(true)
      {
              
              u_xlatb136 = u_xlatu68>=128u;
              
              if(u_xlatb136)
      {
                  break;
      }
              
              u_xlatu136 = _HistogramBuffer_buf[u_xlatu68].value[(0 >> 2) + 0];
              
              u_xlatu0 = max(u_xlatu136, u_xlatu0);
              
              u_xlatu68 = u_xlatu68 + 1u;
      
      }
          
          u_xlat0 = float(u_xlatu0);
          
          u_xlat0 = float(1.0) / u_xlat0;
          
          u_xlatu68 = _HistogramBuffer_buf[0].value[(0 >> 2) + 0];
          
          u_xlat68.x = float(u_xlatu68);
          
          u_xlat136 = u_xlat0 * u_xlat68.x;
          
          u_xlatu204 = _HistogramBuffer_buf[1].value[(0 >> 2) + 0];
          
          u_xlat204 = float(u_xlatu204);
          
          u_xlat1.x = u_xlat0 * u_xlat204;
          
          u_xlat69.x = u_xlat68.x * u_xlat0 + u_xlat1.x;
          
          u_xlatu137 = _HistogramBuffer_buf[2].value[(0 >> 2) + 0];
          
          u_xlat137 = float(u_xlatu137);
          
          u_xlat205 = u_xlat0 * u_xlat137;
          
          u_xlat69.x = u_xlat137 * u_xlat0 + u_xlat69.x;
          
          u_xlatu2 = _HistogramBuffer_buf[3].value[(0 >> 2) + 0];
          
          u_xlat2.x = float(u_xlatu2);
          
          u_xlat69.x = u_xlat2.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu138 = _HistogramBuffer_buf[4].value[(0 >> 2) + 0];
          
          u_xlat2.z = float(u_xlatu138);
          
          u_xlat70.xz = float2(u_xlat0) * u_xlat2.xz;
          
          u_xlat69.x = u_xlat2.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu3 = _HistogramBuffer_buf[5].value[(0 >> 2) + 0];
          
          u_xlat3.x = float(u_xlatu3);
          
          u_xlat69.x = u_xlat3.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu139 = _HistogramBuffer_buf[6].value[(0 >> 2) + 0];
          
          u_xlat3.z = float(u_xlatu139);
          
          u_xlat71.xz = float2(u_xlat0) * u_xlat3.xz;
          
          u_xlat69.x = u_xlat3.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu4 = _HistogramBuffer_buf[7].value[(0 >> 2) + 0];
          
          u_xlat4.x = float(u_xlatu4);
          
          u_xlat69.x = u_xlat4.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu140 = _HistogramBuffer_buf[8].value[(0 >> 2) + 0];
          
          u_xlat4.z = float(u_xlatu140);
          
          u_xlat72.xz = float2(u_xlat0) * u_xlat4.xz;
          
          u_xlat69.x = u_xlat4.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu5 = _HistogramBuffer_buf[9].value[(0 >> 2) + 0];
          
          u_xlat5.x = float(u_xlatu5);
          
          u_xlat69.x = u_xlat5.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu141 = _HistogramBuffer_buf[10].value[(0 >> 2) + 0];
          
          u_xlat5.z = float(u_xlatu141);
          
          u_xlat73.xz = float2(u_xlat0) * u_xlat5.xz;
          
          u_xlat69.x = u_xlat5.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu6 = _HistogramBuffer_buf[11].value[(0 >> 2) + 0];
          
          u_xlat6.x = float(u_xlatu6);
          
          u_xlat69.x = u_xlat6.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu142 = _HistogramBuffer_buf[12].value[(0 >> 2) + 0];
          
          u_xlat6.z = float(u_xlatu142);
          
          u_xlat74.xz = float2(u_xlat0) * u_xlat6.xz;
          
          u_xlat69.x = u_xlat6.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu7 = _HistogramBuffer_buf[13].value[(0 >> 2) + 0];
          
          u_xlat7.x = float(u_xlatu7);
          
          u_xlat69.x = u_xlat7.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu143 = _HistogramBuffer_buf[14].value[(0 >> 2) + 0];
          
          u_xlat7.z = float(u_xlatu143);
          
          u_xlat75.xz = float2(u_xlat0) * u_xlat7.xz;
          
          u_xlat69.x = u_xlat7.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu8 = _HistogramBuffer_buf[15].value[(0 >> 2) + 0];
          
          u_xlat8.x = float(u_xlatu8);
          
          u_xlat69.x = u_xlat8.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu144 = _HistogramBuffer_buf[16].value[(0 >> 2) + 0];
          
          u_xlat8.z = float(u_xlatu144);
          
          u_xlat76.xz = float2(u_xlat0) * u_xlat8.xz;
          
          u_xlat69.x = u_xlat8.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu9 = _HistogramBuffer_buf[17].value[(0 >> 2) + 0];
          
          u_xlat9.x = float(u_xlatu9);
          
          u_xlat69.x = u_xlat9.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu145 = _HistogramBuffer_buf[18].value[(0 >> 2) + 0];
          
          u_xlat9.z = float(u_xlatu145);
          
          u_xlat77.xz = float2(u_xlat0) * u_xlat9.xz;
          
          u_xlat69.x = u_xlat9.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu10 = _HistogramBuffer_buf[19].value[(0 >> 2) + 0];
          
          u_xlat10.x = float(u_xlatu10);
          
          u_xlat69.x = u_xlat10.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu146 = _HistogramBuffer_buf[20].value[(0 >> 2) + 0];
          
          u_xlat10.z = float(u_xlatu146);
          
          u_xlat78.xz = float2(u_xlat0) * u_xlat10.xz;
          
          u_xlat69.x = u_xlat10.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu11 = _HistogramBuffer_buf[21].value[(0 >> 2) + 0];
          
          u_xlat11.x = float(u_xlatu11);
          
          u_xlat69.x = u_xlat11.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu147 = _HistogramBuffer_buf[22].value[(0 >> 2) + 0];
          
          u_xlat11.z = float(u_xlatu147);
          
          u_xlat79.xz = float2(u_xlat0) * u_xlat11.xz;
          
          u_xlat69.x = u_xlat11.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu12 = _HistogramBuffer_buf[23].value[(0 >> 2) + 0];
          
          u_xlat12.x = float(u_xlatu12);
          
          u_xlat69.x = u_xlat12.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu148 = _HistogramBuffer_buf[24].value[(0 >> 2) + 0];
          
          u_xlat12.z = float(u_xlatu148);
          
          u_xlat80.xz = float2(u_xlat0) * u_xlat12.xz;
          
          u_xlat69.x = u_xlat12.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu13 = _HistogramBuffer_buf[25].value[(0 >> 2) + 0];
          
          u_xlat13.x = float(u_xlatu13);
          
          u_xlat69.x = u_xlat13.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu149 = _HistogramBuffer_buf[26].value[(0 >> 2) + 0];
          
          u_xlat13.z = float(u_xlatu149);
          
          u_xlat81.xz = float2(u_xlat0) * u_xlat13.xz;
          
          u_xlat69.x = u_xlat13.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu14 = _HistogramBuffer_buf[27].value[(0 >> 2) + 0];
          
          u_xlat14.x = float(u_xlatu14);
          
          u_xlat69.x = u_xlat14.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu150 = _HistogramBuffer_buf[28].value[(0 >> 2) + 0];
          
          u_xlat14.z = float(u_xlatu150);
          
          u_xlat82.xz = float2(u_xlat0) * u_xlat14.xz;
          
          u_xlat69.x = u_xlat14.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu15 = _HistogramBuffer_buf[29].value[(0 >> 2) + 0];
          
          u_xlat15.x = float(u_xlatu15);
          
          u_xlat69.x = u_xlat15.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu151 = _HistogramBuffer_buf[30].value[(0 >> 2) + 0];
          
          u_xlat15.z = float(u_xlatu151);
          
          u_xlat83.xz = float2(u_xlat0) * u_xlat15.xz;
          
          u_xlat69.x = u_xlat15.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu16 = _HistogramBuffer_buf[31].value[(0 >> 2) + 0];
          
          u_xlat16.x = float(u_xlatu16);
          
          u_xlat69.x = u_xlat16.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu152 = _HistogramBuffer_buf[32].value[(0 >> 2) + 0];
          
          u_xlat16.z = float(u_xlatu152);
          
          u_xlat84.xz = float2(u_xlat0) * u_xlat16.xz;
          
          u_xlat69.x = u_xlat16.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu17 = _HistogramBuffer_buf[33].value[(0 >> 2) + 0];
          
          u_xlat17.x = float(u_xlatu17);
          
          u_xlat69.x = u_xlat17.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu153 = _HistogramBuffer_buf[34].value[(0 >> 2) + 0];
          
          u_xlat17.z = float(u_xlatu153);
          
          u_xlat85.xz = float2(u_xlat0) * u_xlat17.xz;
          
          u_xlat69.x = u_xlat17.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu18 = _HistogramBuffer_buf[35].value[(0 >> 2) + 0];
          
          u_xlat18.x = float(u_xlatu18);
          
          u_xlat69.x = u_xlat18.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu154 = _HistogramBuffer_buf[36].value[(0 >> 2) + 0];
          
          u_xlat18.z = float(u_xlatu154);
          
          u_xlat86.xz = float2(u_xlat0) * u_xlat18.xz;
          
          u_xlat69.x = u_xlat18.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu19 = _HistogramBuffer_buf[37].value[(0 >> 2) + 0];
          
          u_xlat19.x = float(u_xlatu19);
          
          u_xlat69.x = u_xlat19.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu155 = _HistogramBuffer_buf[38].value[(0 >> 2) + 0];
          
          u_xlat19.z = float(u_xlatu155);
          
          u_xlat87.xz = float2(u_xlat0) * u_xlat19.xz;
          
          u_xlat69.x = u_xlat19.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu20 = _HistogramBuffer_buf[39].value[(0 >> 2) + 0];
          
          u_xlat20.x = float(u_xlatu20);
          
          u_xlat69.x = u_xlat20.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu156 = _HistogramBuffer_buf[40].value[(0 >> 2) + 0];
          
          u_xlat20.z = float(u_xlatu156);
          
          u_xlat88.xz = float2(u_xlat0) * u_xlat20.xz;
          
          u_xlat69.x = u_xlat20.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu21 = _HistogramBuffer_buf[41].value[(0 >> 2) + 0];
          
          u_xlat21.x = float(u_xlatu21);
          
          u_xlat69.x = u_xlat21.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu157 = _HistogramBuffer_buf[42].value[(0 >> 2) + 0];
          
          u_xlat21.z = float(u_xlatu157);
          
          u_xlat89.xz = float2(u_xlat0) * u_xlat21.xz;
          
          u_xlat69.x = u_xlat21.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu22 = _HistogramBuffer_buf[43].value[(0 >> 2) + 0];
          
          u_xlat22.x = float(u_xlatu22);
          
          u_xlat69.x = u_xlat22.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu158 = _HistogramBuffer_buf[44].value[(0 >> 2) + 0];
          
          u_xlat22.z = float(u_xlatu158);
          
          u_xlat90.xz = float2(u_xlat0) * u_xlat22.xz;
          
          u_xlat69.x = u_xlat22.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu23 = _HistogramBuffer_buf[45].value[(0 >> 2) + 0];
          
          u_xlat23.x = float(u_xlatu23);
          
          u_xlat69.x = u_xlat23.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu159 = _HistogramBuffer_buf[46].value[(0 >> 2) + 0];
          
          u_xlat23.z = float(u_xlatu159);
          
          u_xlat91.xz = float2(u_xlat0) * u_xlat23.xz;
          
          u_xlat69.x = u_xlat23.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu24 = _HistogramBuffer_buf[47].value[(0 >> 2) + 0];
          
          u_xlat24.x = float(u_xlatu24);
          
          u_xlat69.x = u_xlat24.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu160 = _HistogramBuffer_buf[48].value[(0 >> 2) + 0];
          
          u_xlat24.z = float(u_xlatu160);
          
          u_xlat92.xz = float2(u_xlat0) * u_xlat24.xz;
          
          u_xlat69.x = u_xlat24.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu25 = _HistogramBuffer_buf[49].value[(0 >> 2) + 0];
          
          u_xlat25.x = float(u_xlatu25);
          
          u_xlat69.x = u_xlat25.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu161 = _HistogramBuffer_buf[50].value[(0 >> 2) + 0];
          
          u_xlat25.z = float(u_xlatu161);
          
          u_xlat93.xz = float2(u_xlat0) * u_xlat25.xz;
          
          u_xlat69.x = u_xlat25.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu26 = _HistogramBuffer_buf[51].value[(0 >> 2) + 0];
          
          u_xlat26.x = float(u_xlatu26);
          
          u_xlat69.x = u_xlat26.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu162 = _HistogramBuffer_buf[52].value[(0 >> 2) + 0];
          
          u_xlat26.z = float(u_xlatu162);
          
          u_xlat94.xz = float2(u_xlat0) * u_xlat26.xz;
          
          u_xlat69.x = u_xlat26.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu27 = _HistogramBuffer_buf[53].value[(0 >> 2) + 0];
          
          u_xlat27.x = float(u_xlatu27);
          
          u_xlat69.x = u_xlat27.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu163 = _HistogramBuffer_buf[54].value[(0 >> 2) + 0];
          
          u_xlat27.z = float(u_xlatu163);
          
          u_xlat95.xz = float2(u_xlat0) * u_xlat27.xz;
          
          u_xlat69.x = u_xlat27.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu28 = _HistogramBuffer_buf[55].value[(0 >> 2) + 0];
          
          u_xlat28.x = float(u_xlatu28);
          
          u_xlat69.x = u_xlat28.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu164 = _HistogramBuffer_buf[56].value[(0 >> 2) + 0];
          
          u_xlat28.z = float(u_xlatu164);
          
          u_xlat96.xz = float2(u_xlat0) * u_xlat28.xz;
          
          u_xlat69.x = u_xlat28.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu29 = _HistogramBuffer_buf[57].value[(0 >> 2) + 0];
          
          u_xlat29.x = float(u_xlatu29);
          
          u_xlat69.x = u_xlat29.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu165 = _HistogramBuffer_buf[58].value[(0 >> 2) + 0];
          
          u_xlat29.z = float(u_xlatu165);
          
          u_xlat97.xz = float2(u_xlat0) * u_xlat29.xz;
          
          u_xlat69.x = u_xlat29.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu30 = _HistogramBuffer_buf[59].value[(0 >> 2) + 0];
          
          u_xlat30.x = float(u_xlatu30);
          
          u_xlat69.x = u_xlat30.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu166 = _HistogramBuffer_buf[60].value[(0 >> 2) + 0];
          
          u_xlat30.z = float(u_xlatu166);
          
          u_xlat98.xz = float2(u_xlat0) * u_xlat30.xz;
          
          u_xlat69.x = u_xlat30.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu31 = _HistogramBuffer_buf[61].value[(0 >> 2) + 0];
          
          u_xlat31.x = float(u_xlatu31);
          
          u_xlat69.x = u_xlat31.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu167 = _HistogramBuffer_buf[62].value[(0 >> 2) + 0];
          
          u_xlat31.z = float(u_xlatu167);
          
          u_xlat99.xz = float2(u_xlat0) * u_xlat31.xz;
          
          u_xlat69.x = u_xlat31.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu32 = _HistogramBuffer_buf[63].value[(0 >> 2) + 0];
          
          u_xlat32.x = float(u_xlatu32);
          
          u_xlat69.x = u_xlat32.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu168 = _HistogramBuffer_buf[64].value[(0 >> 2) + 0];
          
          u_xlat32.z = float(u_xlatu168);
          
          u_xlat100.xz = float2(u_xlat0) * u_xlat32.xz;
          
          u_xlat69.x = u_xlat32.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu33 = _HistogramBuffer_buf[65].value[(0 >> 2) + 0];
          
          u_xlat33.x = float(u_xlatu33);
          
          u_xlat69.x = u_xlat33.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu169 = _HistogramBuffer_buf[66].value[(0 >> 2) + 0];
          
          u_xlat33.z = float(u_xlatu169);
          
          u_xlat101.xz = float2(u_xlat0) * u_xlat33.xz;
          
          u_xlat69.x = u_xlat33.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu34 = _HistogramBuffer_buf[67].value[(0 >> 2) + 0];
          
          u_xlat34.x = float(u_xlatu34);
          
          u_xlat69.x = u_xlat34.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu170 = _HistogramBuffer_buf[68].value[(0 >> 2) + 0];
          
          u_xlat34.z = float(u_xlatu170);
          
          u_xlat102.xz = float2(u_xlat0) * u_xlat34.xz;
          
          u_xlat69.x = u_xlat34.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu35 = _HistogramBuffer_buf[69].value[(0 >> 2) + 0];
          
          u_xlat35.x = float(u_xlatu35);
          
          u_xlat69.x = u_xlat35.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu171 = _HistogramBuffer_buf[70].value[(0 >> 2) + 0];
          
          u_xlat35.z = float(u_xlatu171);
          
          u_xlat103.xz = float2(u_xlat0) * u_xlat35.xz;
          
          u_xlat69.x = u_xlat35.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu36 = _HistogramBuffer_buf[71].value[(0 >> 2) + 0];
          
          u_xlat36.x = float(u_xlatu36);
          
          u_xlat69.x = u_xlat36.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu172 = _HistogramBuffer_buf[72].value[(0 >> 2) + 0];
          
          u_xlat36.z = float(u_xlatu172);
          
          u_xlat104.xz = float2(u_xlat0) * u_xlat36.xz;
          
          u_xlat69.x = u_xlat36.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu37 = _HistogramBuffer_buf[73].value[(0 >> 2) + 0];
          
          u_xlat37.x = float(u_xlatu37);
          
          u_xlat69.x = u_xlat37.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu173 = _HistogramBuffer_buf[74].value[(0 >> 2) + 0];
          
          u_xlat37.z = float(u_xlatu173);
          
          u_xlat105.xz = float2(u_xlat0) * u_xlat37.xz;
          
          u_xlat69.x = u_xlat37.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu38 = _HistogramBuffer_buf[75].value[(0 >> 2) + 0];
          
          u_xlat38.x = float(u_xlatu38);
          
          u_xlat69.x = u_xlat38.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu174 = _HistogramBuffer_buf[76].value[(0 >> 2) + 0];
          
          u_xlat38.z = float(u_xlatu174);
          
          u_xlat106.xz = float2(u_xlat0) * u_xlat38.xz;
          
          u_xlat69.x = u_xlat38.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu39 = _HistogramBuffer_buf[77].value[(0 >> 2) + 0];
          
          u_xlat39.x = float(u_xlatu39);
          
          u_xlat69.x = u_xlat39.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu175 = _HistogramBuffer_buf[78].value[(0 >> 2) + 0];
          
          u_xlat39.z = float(u_xlatu175);
          
          u_xlat107.xz = float2(u_xlat0) * u_xlat39.xz;
          
          u_xlat69.x = u_xlat39.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu40 = _HistogramBuffer_buf[79].value[(0 >> 2) + 0];
          
          u_xlat40.x = float(u_xlatu40);
          
          u_xlat69.x = u_xlat40.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu176 = _HistogramBuffer_buf[80].value[(0 >> 2) + 0];
          
          u_xlat40.z = float(u_xlatu176);
          
          u_xlat108.xz = float2(u_xlat0) * u_xlat40.xz;
          
          u_xlat69.x = u_xlat40.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu41 = _HistogramBuffer_buf[81].value[(0 >> 2) + 0];
          
          u_xlat41.x = float(u_xlatu41);
          
          u_xlat69.x = u_xlat41.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu177 = _HistogramBuffer_buf[82].value[(0 >> 2) + 0];
          
          u_xlat41.z = float(u_xlatu177);
          
          u_xlat109.xz = float2(u_xlat0) * u_xlat41.xz;
          
          u_xlat69.x = u_xlat41.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu42 = _HistogramBuffer_buf[83].value[(0 >> 2) + 0];
          
          u_xlat42.x = float(u_xlatu42);
          
          u_xlat69.x = u_xlat42.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu178 = _HistogramBuffer_buf[84].value[(0 >> 2) + 0];
          
          u_xlat42.z = float(u_xlatu178);
          
          u_xlat110.xz = float2(u_xlat0) * u_xlat42.xz;
          
          u_xlat69.x = u_xlat42.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu43 = _HistogramBuffer_buf[85].value[(0 >> 2) + 0];
          
          u_xlat43.x = float(u_xlatu43);
          
          u_xlat69.x = u_xlat43.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu179 = _HistogramBuffer_buf[86].value[(0 >> 2) + 0];
          
          u_xlat43.z = float(u_xlatu179);
          
          u_xlat111.xz = float2(u_xlat0) * u_xlat43.xz;
          
          u_xlat69.x = u_xlat43.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu44 = _HistogramBuffer_buf[87].value[(0 >> 2) + 0];
          
          u_xlat44.x = float(u_xlatu44);
          
          u_xlat69.x = u_xlat44.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu180 = _HistogramBuffer_buf[88].value[(0 >> 2) + 0];
          
          u_xlat44.z = float(u_xlatu180);
          
          u_xlat112.xz = float2(u_xlat0) * u_xlat44.xz;
          
          u_xlat69.x = u_xlat44.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu45 = _HistogramBuffer_buf[89].value[(0 >> 2) + 0];
          
          u_xlat45.x = float(u_xlatu45);
          
          u_xlat69.x = u_xlat45.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu181 = _HistogramBuffer_buf[90].value[(0 >> 2) + 0];
          
          u_xlat45.z = float(u_xlatu181);
          
          u_xlat113.xz = float2(u_xlat0) * u_xlat45.xz;
          
          u_xlat69.x = u_xlat45.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu46 = _HistogramBuffer_buf[91].value[(0 >> 2) + 0];
          
          u_xlat46.x = float(u_xlatu46);
          
          u_xlat69.x = u_xlat46.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu182 = _HistogramBuffer_buf[92].value[(0 >> 2) + 0];
          
          u_xlat46.z = float(u_xlatu182);
          
          u_xlat114.xz = float2(u_xlat0) * u_xlat46.xz;
          
          u_xlat69.x = u_xlat46.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu47 = _HistogramBuffer_buf[93].value[(0 >> 2) + 0];
          
          u_xlat47.x = float(u_xlatu47);
          
          u_xlat69.x = u_xlat47.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu183 = _HistogramBuffer_buf[94].value[(0 >> 2) + 0];
          
          u_xlat47.z = float(u_xlatu183);
          
          u_xlat115.xz = float2(u_xlat0) * u_xlat47.xz;
          
          u_xlat69.x = u_xlat47.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu48 = _HistogramBuffer_buf[95].value[(0 >> 2) + 0];
          
          u_xlat48.x = float(u_xlatu48);
          
          u_xlat69.x = u_xlat48.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu184 = _HistogramBuffer_buf[96].value[(0 >> 2) + 0];
          
          u_xlat48.z = float(u_xlatu184);
          
          u_xlat116.xz = float2(u_xlat0) * u_xlat48.xz;
          
          u_xlat69.x = u_xlat48.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu49 = _HistogramBuffer_buf[97].value[(0 >> 2) + 0];
          
          u_xlat49.x = float(u_xlatu49);
          
          u_xlat69.x = u_xlat49.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu185 = _HistogramBuffer_buf[98].value[(0 >> 2) + 0];
          
          u_xlat49.z = float(u_xlatu185);
          
          u_xlat117.xz = float2(u_xlat0) * u_xlat49.xz;
          
          u_xlat69.x = u_xlat49.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu50 = _HistogramBuffer_buf[99].value[(0 >> 2) + 0];
          
          u_xlat50.x = float(u_xlatu50);
          
          u_xlat69.x = u_xlat50.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu186 = _HistogramBuffer_buf[100].value[(0 >> 2) + 0];
          
          u_xlat50.z = float(u_xlatu186);
          
          u_xlat118.xz = float2(u_xlat0) * u_xlat50.xz;
          
          u_xlat69.x = u_xlat50.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu51 = _HistogramBuffer_buf[101].value[(0 >> 2) + 0];
          
          u_xlat51.x = float(u_xlatu51);
          
          u_xlat69.x = u_xlat51.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu187 = _HistogramBuffer_buf[102].value[(0 >> 2) + 0];
          
          u_xlat51.z = float(u_xlatu187);
          
          u_xlat119.xz = float2(u_xlat0) * u_xlat51.xz;
          
          u_xlat69.x = u_xlat51.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu52 = _HistogramBuffer_buf[103].value[(0 >> 2) + 0];
          
          u_xlat52.x = float(u_xlatu52);
          
          u_xlat69.x = u_xlat52.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu188 = _HistogramBuffer_buf[104].value[(0 >> 2) + 0];
          
          u_xlat52.z = float(u_xlatu188);
          
          u_xlat120.xz = float2(u_xlat0) * u_xlat52.xz;
          
          u_xlat69.x = u_xlat52.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu53 = _HistogramBuffer_buf[105].value[(0 >> 2) + 0];
          
          u_xlat53.x = float(u_xlatu53);
          
          u_xlat69.x = u_xlat53.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu189 = _HistogramBuffer_buf[106].value[(0 >> 2) + 0];
          
          u_xlat53.z = float(u_xlatu189);
          
          u_xlat121.xz = float2(u_xlat0) * u_xlat53.xz;
          
          u_xlat69.x = u_xlat53.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu54 = _HistogramBuffer_buf[107].value[(0 >> 2) + 0];
          
          u_xlat54.x = float(u_xlatu54);
          
          u_xlat69.x = u_xlat54.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu190 = _HistogramBuffer_buf[108].value[(0 >> 2) + 0];
          
          u_xlat54.z = float(u_xlatu190);
          
          u_xlat122.xz = float2(u_xlat0) * u_xlat54.xz;
          
          u_xlat69.x = u_xlat54.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu55 = _HistogramBuffer_buf[109].value[(0 >> 2) + 0];
          
          u_xlat55.x = float(u_xlatu55);
          
          u_xlat69.x = u_xlat55.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu191 = _HistogramBuffer_buf[110].value[(0 >> 2) + 0];
          
          u_xlat55.z = float(u_xlatu191);
          
          u_xlat123.xz = float2(u_xlat0) * u_xlat55.xz;
          
          u_xlat69.x = u_xlat55.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu56 = _HistogramBuffer_buf[111].value[(0 >> 2) + 0];
          
          u_xlat56.x = float(u_xlatu56);
          
          u_xlat69.x = u_xlat56.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu192 = _HistogramBuffer_buf[112].value[(0 >> 2) + 0];
          
          u_xlat56.z = float(u_xlatu192);
          
          u_xlat124.xz = float2(u_xlat0) * u_xlat56.xz;
          
          u_xlat69.x = u_xlat56.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu57 = _HistogramBuffer_buf[113].value[(0 >> 2) + 0];
          
          u_xlat57.x = float(u_xlatu57);
          
          u_xlat69.x = u_xlat57.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu193 = _HistogramBuffer_buf[114].value[(0 >> 2) + 0];
          
          u_xlat57.z = float(u_xlatu193);
          
          u_xlat125.xz = float2(u_xlat0) * u_xlat57.xz;
          
          u_xlat69.x = u_xlat57.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu58 = _HistogramBuffer_buf[115].value[(0 >> 2) + 0];
          
          u_xlat58.x = float(u_xlatu58);
          
          u_xlat69.x = u_xlat58.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu194 = _HistogramBuffer_buf[116].value[(0 >> 2) + 0];
          
          u_xlat58.z = float(u_xlatu194);
          
          u_xlat126.xz = float2(u_xlat0) * u_xlat58.xz;
          
          u_xlat69.x = u_xlat58.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu59 = _HistogramBuffer_buf[117].value[(0 >> 2) + 0];
          
          u_xlat59.x = float(u_xlatu59);
          
          u_xlat69.x = u_xlat59.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu195 = _HistogramBuffer_buf[118].value[(0 >> 2) + 0];
          
          u_xlat59.z = float(u_xlatu195);
          
          u_xlat127.xz = float2(u_xlat0) * u_xlat59.xz;
          
          u_xlat69.x = u_xlat59.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu60 = _HistogramBuffer_buf[119].value[(0 >> 2) + 0];
          
          u_xlat60.x = float(u_xlatu60);
          
          u_xlat69.x = u_xlat60.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu196 = _HistogramBuffer_buf[120].value[(0 >> 2) + 0];
          
          u_xlat60.z = float(u_xlatu196);
          
          u_xlat128.xz = float2(u_xlat0) * u_xlat60.xz;
          
          u_xlat69.x = u_xlat60.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu61 = _HistogramBuffer_buf[121].value[(0 >> 2) + 0];
          
          u_xlat61.x = float(u_xlatu61);
          
          u_xlat69.x = u_xlat61.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu197 = _HistogramBuffer_buf[122].value[(0 >> 2) + 0];
          
          u_xlat61.z = float(u_xlatu197);
          
          u_xlat129.xz = float2(u_xlat0) * u_xlat61.xz;
          
          u_xlat69.x = u_xlat61.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu62 = _HistogramBuffer_buf[123].value[(0 >> 2) + 0];
          
          u_xlat62.x = float(u_xlatu62);
          
          u_xlat69.x = u_xlat62.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu198 = _HistogramBuffer_buf[124].value[(0 >> 2) + 0];
          
          u_xlat62.z = float(u_xlatu198);
          
          u_xlat130.xz = float2(u_xlat0) * u_xlat62.xz;
          
          u_xlat69.x = u_xlat62.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu63 = _HistogramBuffer_buf[125].value[(0 >> 2) + 0];
          
          u_xlat63.x = float(u_xlatu63);
          
          u_xlat69.x = u_xlat63.x * u_xlat0 + u_xlat69.x;
          
          u_xlatu199 = _HistogramBuffer_buf[126].value[(0 >> 2) + 0];
          
          u_xlat63.z = float(u_xlatu199);
          
          u_xlat131.xz = float2(u_xlat0) * u_xlat63.xz;
          
          u_xlat69.x = u_xlat63.z * u_xlat0 + u_xlat69.x;
          
          u_xlatu64 = _HistogramBuffer_buf[127].value[(0 >> 2) + 0];
          
          u_xlat64 = float(u_xlatu64);
          
          u_xlat132 = u_xlat0 * u_xlat64;
          
          u_xlat69.x = u_xlat64 * u_xlat0 + u_xlat69.x;
          
          u_xlat200 = u_xlat69.x * _Params.x;
          
          u_xlat136 = min(u_xlat136, u_xlat200);
          
          u_xlat68.x = u_xlat68.x * u_xlat0 + (-u_xlat136);
          
          u_xlat65.xy = u_xlat69.xx * _Params.xy + (-float2(u_xlat136));
          
          u_xlat66.y = min(u_xlat68.x, u_xlat65.y);
          
          u_xlat65.z = u_xlat65.y + (-u_xlat66.y);
          
          u_xlat68.x = (-_ScaleOffsetRes.y) / _ScaleOffsetRes.x;
          
          u_xlat68.x = exp2(u_xlat68.x);
          
          u_xlat66.x = u_xlat66.y * u_xlat68.x;
          
          u_xlat68.x = min(u_xlat1.x, u_xlat65.x);
          
          u_xlat136 = u_xlat204 * u_xlat0 + (-u_xlat68.x);
          
          u_xlat65.xy = (-u_xlat68.xx) + u_xlat65.xz;
          
          u_xlat1.y = min(u_xlat136, u_xlat65.y);
          
          u_xlat65.z = (-u_xlat1.y) + u_xlat65.y;
          
          u_xlat67 = (-_ScaleOffsetRes.yyyy) + float4(0.0078125, 0.015625, 0.0234375, 0.03125);
          
          u_xlat67 = u_xlat67 / _ScaleOffsetRes.xxxx;
          
          u_xlat67 = exp2(u_xlat67);
          
          u_xlat1.x = u_xlat1.y * u_xlat67.x;
          
          u_xlat68.xy = u_xlat1.xy + u_xlat66.xy;
          
          u_xlat204 = min(u_xlat205, u_xlat65.x);
          
          u_xlat1.x = u_xlat137 * u_xlat0 + (-u_xlat204);
          
          u_xlat65.xy = (-float2(u_xlat204)) + u_xlat65.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat65.y);
          
          u_xlat65.z = (-u_xlat1.y) + u_xlat65.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat67.y;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat70.x, u_xlat65.x);
          
          u_xlat1.x = u_xlat2.x * u_xlat0 + (-u_xlat204);
          
          u_xlat65.xy = (-float2(u_xlat204)) + u_xlat65.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat65.y);
          
          u_xlat65.z = (-u_xlat1.y) + u_xlat65.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat67.z;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat70.z, u_xlat65.x);
          
          u_xlat1.x = u_xlat2.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat65.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat67.w;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat71.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat3.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat65 = (-_ScaleOffsetRes.yyyy) + float4(0.0390625, 0.046875, 0.0546875, 0.0625);
          
          u_xlat65 = u_xlat65 / _ScaleOffsetRes.xxxx;
          
          u_xlat65 = exp2(u_xlat65);
          
          u_xlat1.x = u_xlat1.y * u_xlat65.x;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat71.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat3.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat65.y;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat72.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat4.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat65.z;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat72.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat4.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat65.w;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat73.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat5.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat3 = (-_ScaleOffsetRes.yyyy) + float4(0.0703125, 0.078125, 0.0859375, 0.09375);
          
          u_xlat3 = u_xlat3 / _ScaleOffsetRes.xxxx;
          
          u_xlat3 = exp2(u_xlat3);
          
          u_xlat1.x = u_xlat1.y * u_xlat3.x;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat73.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat5.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.y;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat74.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat6.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.z;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat74.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat6.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.w;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat75.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat7.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat3 = (-_ScaleOffsetRes.yyyy) + float4(0.1015625, 0.109375, 0.1171875, 0.125);
          
          u_xlat3 = u_xlat3 / _ScaleOffsetRes.xxxx;
          
          u_xlat3 = exp2(u_xlat3);
          
          u_xlat1.x = u_xlat1.y * u_xlat3.x;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat75.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat7.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.y;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat76.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat8.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.z;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat76.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat8.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.w;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat77.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat9.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat3 = (-_ScaleOffsetRes.yyyy) + float4(0.1328125, 0.140625, 0.1484375, 0.15625);
          
          u_xlat3 = u_xlat3 / _ScaleOffsetRes.xxxx;
          
          u_xlat3 = exp2(u_xlat3);
          
          u_xlat1.x = u_xlat1.y * u_xlat3.x;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat77.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat9.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.y;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat78.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat10.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.z;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat78.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat10.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.w;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat79.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat11.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat3 = (-_ScaleOffsetRes.yyyy) + float4(0.1640625, 0.171875, 0.1796875, 0.1875);
          
          u_xlat3 = u_xlat3 / _ScaleOffsetRes.xxxx;
          
          u_xlat3 = exp2(u_xlat3);
          
          u_xlat1.x = u_xlat1.y * u_xlat3.x;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat79.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat11.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.y;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat80.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat12.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.z;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat80.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat12.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.w;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat81.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat13.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat3 = (-_ScaleOffsetRes.yyyy) + float4(0.1953125, 0.203125, 0.2109375, 0.21875);
          
          u_xlat3 = u_xlat3 / _ScaleOffsetRes.xxxx;
          
          u_xlat3 = exp2(u_xlat3);
          
          u_xlat1.x = u_xlat1.y * u_xlat3.x;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat81.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat13.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.y;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat82.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat14.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.z;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat82.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat14.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.w;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat83.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat15.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat3 = (-_ScaleOffsetRes.yyyy) + float4(0.2265625, 0.234375, 0.2421875, 0.25);
          
          u_xlat3 = u_xlat3 / _ScaleOffsetRes.xxxx;
          
          u_xlat3 = exp2(u_xlat3);
          
          u_xlat1.x = u_xlat1.y * u_xlat3.x;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat83.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat15.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.y;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat84.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat16.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.z;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat84.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat16.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.w;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat85.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat17.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat3 = (-_ScaleOffsetRes.yyyy) + float4(0.2578125, 0.265625, 0.2734375, 0.28125);
          
          u_xlat3 = u_xlat3 / _ScaleOffsetRes.xxxx;
          
          u_xlat3 = exp2(u_xlat3);
          
          u_xlat1.x = u_xlat1.y * u_xlat3.x;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat85.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat17.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.y;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat86.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat18.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.z;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat86.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat18.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.w;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat87.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat19.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat3 = (-_ScaleOffsetRes.yyyy) + float4(0.2890625, 0.296875, 0.3046875, 0.3125);
          
          u_xlat3 = u_xlat3 / _ScaleOffsetRes.xxxx;
          
          u_xlat3 = exp2(u_xlat3);
          
          u_xlat1.x = u_xlat1.y * u_xlat3.x;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat87.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat19.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.y;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat88.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat20.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.z;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat88.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat20.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.w;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat89.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat21.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat3 = (-_ScaleOffsetRes.yyyy) + float4(0.3203125, 0.328125, 0.3359375, 0.34375);
          
          u_xlat3 = u_xlat3 / _ScaleOffsetRes.xxxx;
          
          u_xlat3 = exp2(u_xlat3);
          
          u_xlat1.x = u_xlat1.y * u_xlat3.x;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat89.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat21.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.y;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat90.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat22.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.z;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat90.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat22.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.w;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat91.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat23.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat3 = (-_ScaleOffsetRes.yyyy) + float4(0.3515625, 0.359375, 0.3671875, 0.375);
          
          u_xlat3 = u_xlat3 / _ScaleOffsetRes.xxxx;
          
          u_xlat3 = exp2(u_xlat3);
          
          u_xlat1.x = u_xlat1.y * u_xlat3.x;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat91.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat23.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.y;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat92.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat24.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.z;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat92.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat24.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.w;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat93.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat25.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat3 = (-_ScaleOffsetRes.yyyy) + float4(0.3828125, 0.390625, 0.3984375, 0.40625);
          
          u_xlat3 = u_xlat3 / _ScaleOffsetRes.xxxx;
          
          u_xlat3 = exp2(u_xlat3);
          
          u_xlat1.x = u_xlat1.y * u_xlat3.x;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat93.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat25.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.y;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat94.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat26.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.z;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat94.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat26.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.w;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat95.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat27.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat3 = (-_ScaleOffsetRes.yyyy) + float4(0.4140625, 0.421875, 0.4296875, 0.4375);
          
          u_xlat3 = u_xlat3 / _ScaleOffsetRes.xxxx;
          
          u_xlat3 = exp2(u_xlat3);
          
          u_xlat1.x = u_xlat1.y * u_xlat3.x;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat95.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat27.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.y;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat96.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat28.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.z;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat96.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat28.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.w;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat97.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat29.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat3 = (-_ScaleOffsetRes.yyyy) + float4(0.4453125, 0.453125, 0.4609375, 0.46875);
          
          u_xlat3 = u_xlat3 / _ScaleOffsetRes.xxxx;
          
          u_xlat3 = exp2(u_xlat3);
          
          u_xlat1.x = u_xlat1.y * u_xlat3.x;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat97.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat29.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.y;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat98.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat30.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.z;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat98.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat30.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.w;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat99.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat31.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat3 = (-_ScaleOffsetRes.yyyy) + float4(0.4765625, 0.484375, 0.4921875, 0.5);
          
          u_xlat3 = u_xlat3 / _ScaleOffsetRes.xxxx;
          
          u_xlat3 = exp2(u_xlat3);
          
          u_xlat1.x = u_xlat1.y * u_xlat3.x;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat99.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat31.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.y;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat100.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat32.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.z;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat100.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat32.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.w;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat101.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat33.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat3 = (-_ScaleOffsetRes.yyyy) + float4(0.5078125, 0.515625, 0.5234375, 0.53125);
          
          u_xlat3 = u_xlat3 / _ScaleOffsetRes.xxxx;
          
          u_xlat3 = exp2(u_xlat3);
          
          u_xlat1.x = u_xlat1.y * u_xlat3.x;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat101.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat33.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.y;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat102.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat34.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.z;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat102.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat34.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.w;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat103.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat35.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat3 = (-_ScaleOffsetRes.yyyy) + float4(0.5390625, 0.546875, 0.5546875, 0.5625);
          
          u_xlat3 = u_xlat3 / _ScaleOffsetRes.xxxx;
          
          u_xlat3 = exp2(u_xlat3);
          
          u_xlat1.x = u_xlat1.y * u_xlat3.x;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat103.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat35.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.y;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat104.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat36.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.z;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat104.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat36.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.w;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat105.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat37.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat3 = (-_ScaleOffsetRes.yyyy) + float4(0.5703125, 0.578125, 0.5859375, 0.59375);
          
          u_xlat3 = u_xlat3 / _ScaleOffsetRes.xxxx;
          
          u_xlat3 = exp2(u_xlat3);
          
          u_xlat1.x = u_xlat1.y * u_xlat3.x;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat105.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat37.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.y;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat106.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat38.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.z;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat106.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat38.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.w;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat107.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat39.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat3 = (-_ScaleOffsetRes.yyyy) + float4(0.6015625, 0.609375, 0.6171875, 0.625);
          
          u_xlat3 = u_xlat3 / _ScaleOffsetRes.xxxx;
          
          u_xlat3 = exp2(u_xlat3);
          
          u_xlat1.x = u_xlat1.y * u_xlat3.x;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat107.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat39.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.y;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat108.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat40.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.z;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat108.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat40.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.w;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat109.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat41.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat3 = (-_ScaleOffsetRes.yyyy) + float4(0.6328125, 0.640625, 0.6484375, 0.65625);
          
          u_xlat3 = u_xlat3 / _ScaleOffsetRes.xxxx;
          
          u_xlat3 = exp2(u_xlat3);
          
          u_xlat1.x = u_xlat1.y * u_xlat3.x;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat109.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat41.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.y;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat110.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat42.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.z;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat110.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat42.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.w;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat111.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat43.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat3 = (-_ScaleOffsetRes.yyyy) + float4(0.6640625, 0.671875, 0.6796875, 0.6875);
          
          u_xlat3 = u_xlat3 / _ScaleOffsetRes.xxxx;
          
          u_xlat3 = exp2(u_xlat3);
          
          u_xlat1.x = u_xlat1.y * u_xlat3.x;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat111.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat43.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.y;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat112.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat44.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.z;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat112.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat44.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.w;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat113.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat45.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat3 = (-_ScaleOffsetRes.yyyy) + float4(0.6953125, 0.703125, 0.7109375, 0.71875);
          
          u_xlat3 = u_xlat3 / _ScaleOffsetRes.xxxx;
          
          u_xlat3 = exp2(u_xlat3);
          
          u_xlat1.x = u_xlat1.y * u_xlat3.x;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat113.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat45.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.y;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat114.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat46.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.z;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat114.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat46.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.w;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat115.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat47.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat3 = (-_ScaleOffsetRes.yyyy) + float4(0.7265625, 0.734375, 0.7421875, 0.75);
          
          u_xlat3 = u_xlat3 / _ScaleOffsetRes.xxxx;
          
          u_xlat3 = exp2(u_xlat3);
          
          u_xlat1.x = u_xlat1.y * u_xlat3.x;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat115.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat47.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.y;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat116.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat48.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.z;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat116.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat48.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.w;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat117.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat49.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat3 = (-_ScaleOffsetRes.yyyy) + float4(0.7578125, 0.765625, 0.7734375, 0.78125);
          
          u_xlat3 = u_xlat3 / _ScaleOffsetRes.xxxx;
          
          u_xlat3 = exp2(u_xlat3);
          
          u_xlat1.x = u_xlat1.y * u_xlat3.x;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat117.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat49.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.y;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat118.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat50.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.z;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat118.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat50.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.w;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat119.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat51.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat3 = (-_ScaleOffsetRes.yyyy) + float4(0.7890625, 0.796875, 0.8046875, 0.8125);
          
          u_xlat3 = u_xlat3 / _ScaleOffsetRes.xxxx;
          
          u_xlat3 = exp2(u_xlat3);
          
          u_xlat1.x = u_xlat1.y * u_xlat3.x;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat119.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat51.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.y;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat120.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat52.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.z;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat120.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat52.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.w;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat121.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat53.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat3 = (-_ScaleOffsetRes.yyyy) + float4(0.8203125, 0.828125, 0.8359375, 0.84375);
          
          u_xlat3 = u_xlat3 / _ScaleOffsetRes.xxxx;
          
          u_xlat3 = exp2(u_xlat3);
          
          u_xlat1.x = u_xlat1.y * u_xlat3.x;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat121.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat53.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.y;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat122.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat54.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.z;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat122.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat54.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.w;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat123.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat55.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat3 = (-_ScaleOffsetRes.yyyy) + float4(0.8515625, 0.859375, 0.8671875, 0.875);
          
          u_xlat3 = u_xlat3 / _ScaleOffsetRes.xxxx;
          
          u_xlat3 = exp2(u_xlat3);
          
          u_xlat1.x = u_xlat1.y * u_xlat3.x;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat123.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat55.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.y;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat124.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat56.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.z;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat124.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat56.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.w;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat125.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat57.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat3 = (-_ScaleOffsetRes.yyyy) + float4(0.8828125, 0.890625, 0.8984375, 0.90625);
          
          u_xlat3 = u_xlat3 / _ScaleOffsetRes.xxxx;
          
          u_xlat3 = exp2(u_xlat3);
          
          u_xlat1.x = u_xlat1.y * u_xlat3.x;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat125.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat57.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.y;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat126.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat58.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.z;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat126.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat58.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.w;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat127.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat59.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat3 = (-_ScaleOffsetRes.yyyy) + float4(0.9140625, 0.921875, 0.9296875, 0.9375);
          
          u_xlat3 = u_xlat3 / _ScaleOffsetRes.xxxx;
          
          u_xlat3 = exp2(u_xlat3);
          
          u_xlat1.x = u_xlat1.y * u_xlat3.x;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat127.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat59.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.y;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat128.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat60.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.z;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat128.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat60.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.w;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat129.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat61.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat3 = (-_ScaleOffsetRes.yyyy) + float4(0.9453125, 0.953125, 0.9609375, 0.96875);
          
          u_xlat3 = u_xlat3 / _ScaleOffsetRes.xxxx;
          
          u_xlat3 = exp2(u_xlat3);
          
          u_xlat1.x = u_xlat1.y * u_xlat3.x;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat129.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat61.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.y;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat130.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat62.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.z;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat130.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat62.z * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat1.x = u_xlat1.y * u_xlat3.w;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat131.x, u_xlat2.x);
          
          u_xlat1.x = u_xlat63.x * u_xlat0 + (-u_xlat204);
          
          u_xlat2.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat1.y = min(u_xlat1.x, u_xlat2.y);
          
          u_xlat2.z = (-u_xlat1.y) + u_xlat2.y;
          
          u_xlat3.xyz = (-_ScaleOffsetRes.yyy) + float3(0.9765625, 0.984375, 0.9921875);
          
          u_xlat3.xyz = u_xlat3.xyz / _ScaleOffsetRes.xxx;
          
          u_xlat3.xyz = exp2(u_xlat3.xyz);
          
          u_xlat1.x = u_xlat1.y * u_xlat3.x;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat204 = min(u_xlat131.z, u_xlat2.x);
          
          u_xlat1.x = u_xlat63.z * u_xlat0 + (-u_xlat204);
          
          u_xlat69.xy = (-float2(u_xlat204)) + u_xlat2.xz;
          
          u_xlat2.y = min(u_xlat1.x, u_xlat69.y);
          
          u_xlat204 = u_xlat69.y + (-u_xlat2.y);
          
          u_xlat2.x = u_xlat2.y * u_xlat3.y;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat2.xy;
          
          u_xlat1.x = min(u_xlat132, u_xlat69.x);
          
          u_xlat69.x = u_xlat64 * u_xlat0 + (-u_xlat1.x);
          
          u_xlat204 = u_xlat204 + (-u_xlat1.x);
          
          u_xlat1.y = min(u_xlat69.x, u_xlat204);
          
          u_xlat1.x = u_xlat1.y * u_xlat3.z;
          
          u_xlat68.xy = u_xlat68.xy + u_xlat1.xy;
          
          u_xlat136 = max(u_xlat68.y, 9.99999975e-05);
          
          u_xlat68.x = u_xlat68.x / u_xlat136;
          
          u_xlat68.x = max(u_xlat68.x, _Params.z);
          
          out_v.texcoord2 = min(u_xlat68.x, _Params.w);
          
          out_v.vertex.xy = in_v.vertex.xy;
          
          out_v.vertex.zw = float2(0.0, 1.0);
          
          out_v.texcoord.xy = in_v.vertex.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
          
          out_v.texcoord1 = u_xlat0;
          
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
      
      uint u_xlatu0_d;
      
      int u_xlatb0;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = in_f.texcoord.x * 128.0;
          
          u_xlat0_d = roundEven(u_xlat0_d);
          
          u_xlatu0_d = uint(u_xlat0_d);
          
          u_xlatu0_d = _HistogramBuffer_buf[u_xlatu0_d].value[(0 >> 2) + 0];
          
          u_xlat0_d = float(u_xlatu0_d);
          
          u_xlat0_d = u_xlat0_d * in_f.texcoord1;
          
          u_xlat0_d = clamp(u_xlat0_d, 0.0, 1.0);
          
          u_xlatb0 = u_xlat0_d>=in_f.texcoord.y;
          
          out_f.color.xyz = int(u_xlatb0) ? float3(0.75, 0.75, 0.75) : float3(0.0, 0.0, 0.0);
          
          out_f.color.w = 1.0;
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
