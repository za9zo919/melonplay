Shader "Unlit/LavaShader"
{
  Properties
  {
    _MainTex ("Main Texture", 2D) = "white" {}
    _SwirlNoise ("Swirl Noise", 2D) = "white" {}
    _TintGradient ("Tint Gradient", 2D) = "white" {}
    _RockTexture ("Rock Texture", 2D) = "white" {}
    _LavaNoise ("Lava Noise", 2D) = "white" {}
    _RockTint ("Rock Tint", Color) = (1,1,1,1)
    [HDR] _LavaTint ("Lava Tint", Color) = (1,1,1,1)
    _CutoffEdge ("Cutoff Edge", float) = 1
    _Scale ("Scale", float) = 1
    _Pixelisation ("Pixelisation", float) = 1
    _Speed ("Speed", float) = 1
  }
  SubShader
  {
    Tags
    { 
      "QUEUE" = "Transparent+1"
      "RenderType" = "Opaque"
    }
    Pass // ind: 1, name: 
    {
      Tags
      { 
        "QUEUE" = "Transparent+1"
        "RenderType" = "Opaque"
      }
      ZWrite Off
      Cull Off
      Blend SrcAlpha OneMinusSrcAlpha
      // m_ProgramMask = 6
      CGPROGRAM
      //#pragma target 4.0
      
      #pragma vertex vert
      #pragma fragment frag
      
      #include "UnityCG.cginc"
      #define conv_mxt4x4_0(mat4x4) float4(mat4x4[0].x,mat4x4[1].x,mat4x4[2].x,mat4x4[3].x)
      #define conv_mxt4x4_1(mat4x4) float4(mat4x4[0].y,mat4x4[1].y,mat4x4[2].y,mat4x4[3].y)
      #define conv_mxt4x4_2(mat4x4) float4(mat4x4[0].z,mat4x4[1].z,mat4x4[2].z,mat4x4[3].z)
      #define conv_mxt4x4_3(mat4x4) float4(mat4x4[0].w,mat4x4[1].w,mat4x4[2].w,mat4x4[3].w)
      
      
      #define CODE_BLOCK_VERTEX
      //uniform float4x4 unity_ObjectToWorld;
      //uniform float4x4 unity_MatrixVP;
      uniform float4 _MainTex_ST;
      //uniform float4 _Time;
      uniform float _CutoffEdge;
      uniform float4 _RockTint;
      uniform float4 _LavaTint;
      uniform float _Scale;
      uniform float _Pixelisation;
      uniform float _Speed;
      uniform sampler2D _LavaNoise;
      uniform sampler2D _TintGradient;
      uniform sampler2D _RockTexture;
      struct appdata_t
      {
          float4 vertex :POSITION0;
          float2 texcoord :TEXCOORD0;
          float4 color :COLOR0;
      };
      
      struct OUT_Data_Vert
      {
          float2 texcoord :TEXCOORD0;
          float2 texcoord1 :TEXCOORD1;
          float4 color :COLOR0;
          float4 vertex :SV_POSITION;
      };
      
      struct v2f
      {
          float2 texcoord :TEXCOORD0;
          float2 texcoord1 :TEXCOORD1;
          float4 color :COLOR0;
      };
      
      struct OUT_Data_Frag
      {
          float4 color :SV_Target0;
      };
      
      float4 u_xlat0;
      float4 u_xlat1;
      OUT_Data_Vert vert(appdata_t in_v)
      {
          OUT_Data_Vert out_v;
          u_xlat0 = (in_v.vertex.yyyy * conv_mxt4x4_1(unity_ObjectToWorld));
          u_xlat0 = ((conv_mxt4x4_0(unity_ObjectToWorld) * in_v.vertex.xxxx) + u_xlat0);
          u_xlat0 = ((conv_mxt4x4_2(unity_ObjectToWorld) * in_v.vertex.zzzz) + u_xlat0);
          u_xlat1 = (u_xlat0 + conv_mxt4x4_3(unity_ObjectToWorld));
          out_v.texcoord1.xy = ((conv_mxt4x4_3(unity_ObjectToWorld).xy * in_v.vertex.ww) + u_xlat0.xy);
          out_v.vertex = mul(unity_MatrixVP, u_xlat1);
          out_v.texcoord.xy = TRANSFORM_TEX(in_v.texcoord.xy, _MainTex);
          out_v.color = in_v.color;
          return out_v;
      }
      
      #define CODE_BLOCK_FRAGMENT
      float4 u_xlat0_d;
      int u_xlatb0;
      float4 u_xlat1_d;
      float4 u_xlat2;
      float3 u_xlatb2;
      float4 u_xlat3;
      float4 u_xlat4;
      float4 u_xlat5;
      float3 u_xlatb5;
      float4 u_xlat6;
      float3 u_xlatb6;
      float4 u_xlat7;
      float4 u_xlat8;
      float4 u_xlatb8;
      float4 u_xlat9;
      float4 u_xlat10;
      float4 u_xlat11;
      float4 u_xlatb11;
      float4 u_xlat12;
      float u_xlat13;
      float3 u_xlat14;
      float2 u_xlat26;
      float u_xlat28;
      float2 u_xlat29;
      float u_xlat39;
      float u_xlat40;
      int u_xlatb40;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlat0_d.x = float(0);
          u_xlat0_d.w = float(1);
          u_xlat1_d.xy = in_f.texcoord1.xy;
          u_xlat1_d.z = _Time.x;
          u_xlat40 = dot(u_xlat1_d.xyz, float3(0.333333343, 0.333333343, 0.333333343));
          u_xlat2.xyz = (float3(u_xlat40, u_xlat40, u_xlat40) + u_xlat1_d.xyz);
          u_xlat2.xyz = floor(u_xlat2.xyz);
          u_xlat3.xyz = (u_xlat2.xyz * float3(0.00346020772, 0.00346020772, 0.00346020772));
          u_xlat3.xyz = floor(u_xlat3.xyz);
          u_xlat3.xyz = (((-u_xlat3.xyz) * float3(289, 289, 289)) + u_xlat2.xyz);
          u_xlat1_d.xyz = (u_xlat1_d.xyz + (-u_xlat2.xyz));
          u_xlat40 = dot(u_xlat2.xyz, float3(0.166666672, 0.166666672, 0.166666672));
          u_xlat1_d.xyz = (float3(u_xlat40, u_xlat40, u_xlat40) + u_xlat1_d.xyz);
          u_xlatb2.xyz = bool4(u_xlat1_d.zxyz >= u_xlat1_d.xyzx).xyz;
          u_xlat4.x = (u_xlatb2.y)?(float(1)):(0);
          u_xlat4.y = (u_xlatb2.z)?(float(1)):(0);
          u_xlat4.z = (u_xlatb2.x)?(float(1)):(0);
          u_xlat2.x = (u_xlatb2.x)?(float(0)):(float(1));
          u_xlat2.y = (u_xlatb2.y)?(float(0)):(float(1));
          u_xlat2.z = (u_xlatb2.z)?(float(0)):(float(1));
          u_xlat5.xyz = min(u_xlat2.xyz, u_xlat4.xyz);
          u_xlat2.xyz = max(u_xlat2.xyz, u_xlat4.xyz);
          u_xlat0_d.y = u_xlat5.z;
          u_xlat0_d.z = u_xlat2.z;
          u_xlat0_d = (u_xlat0_d + u_xlat3.zzzz);
          u_xlat4 = (u_xlat0_d * u_xlat0_d);
          u_xlat0_d = ((u_xlat4 * float4(34, 34, 34, 34)) + u_xlat0_d);
          u_xlat4 = (u_xlat0_d * float4(0.00346020772, 0.00346020772, 0.00346020772, 0.00346020772));
          u_xlat4 = floor(u_xlat4);
          u_xlat0_d = (((-u_xlat4) * float4(289, 289, 289, 289)) + u_xlat0_d);
          u_xlat0_d = (u_xlat3.yyyy + u_xlat0_d);
          u_xlat4.x = float(0);
          u_xlat4.w = float(1);
          u_xlat4.y = u_xlat5.y;
          u_xlat4.z = u_xlat2.y;
          u_xlat0_d = (u_xlat0_d + u_xlat4);
          u_xlat4 = (u_xlat0_d * u_xlat0_d);
          u_xlat0_d = ((u_xlat4 * float4(34, 34, 34, 34)) + u_xlat0_d);
          u_xlat4 = (u_xlat0_d * float4(0.00346020772, 0.00346020772, 0.00346020772, 0.00346020772));
          u_xlat4 = floor(u_xlat4);
          u_xlat0_d = (((-u_xlat4) * float4(289, 289, 289, 289)) + u_xlat0_d);
          u_xlat0_d = (u_xlat3.xxxx + u_xlat0_d);
          u_xlat3.x = float(0);
          u_xlat3.w = float(1);
          u_xlat3.y = u_xlat5.x;
          u_xlat4.xyz = (u_xlat1_d.xyz + (-u_xlat5.xyz));
          u_xlat4.xyz = (u_xlat4.xyz + float3(0.166666672, 0.166666672, 0.166666672));
          u_xlat3.z = u_xlat2.x;
          u_xlat2.xyz = (u_xlat1_d.xyz + (-u_xlat2.xyz));
          u_xlat2.xyz = (u_xlat2.xyz + float3(0.333333343, 0.333333343, 0.333333343));
          u_xlat0_d = (u_xlat0_d + u_xlat3);
          u_xlat3 = (u_xlat0_d * u_xlat0_d);
          u_xlat0_d = ((u_xlat3 * float4(34, 34, 34, 34)) + u_xlat0_d);
          u_xlat3 = (u_xlat0_d * float4(0.00346020772, 0.00346020772, 0.00346020772, 0.00346020772));
          u_xlat3 = floor(u_xlat3);
          u_xlat0_d = (((-u_xlat3) * float4(289, 289, 289, 289)) + u_xlat0_d);
          u_xlat3 = (u_xlat0_d * float4(0.0204081647, 0.0204081647, 0.0204081647, 0.0204081647));
          u_xlat3 = floor(u_xlat3);
          u_xlat0_d = (((-u_xlat3) * float4(49, 49, 49, 49)) + u_xlat0_d);
          u_xlat3 = (u_xlat0_d * float4(0.142857149, 0.142857149, 0.142857149, 0.142857149));
          u_xlat3 = floor(u_xlat3);
          u_xlat0_d = (((-u_xlat3) * float4(7, 7, 7, 7)) + u_xlat0_d);
          u_xlat3 = ((u_xlat3.zxwy * float4(0.285714298, 0.285714298, 0.285714298, 0.285714298)) + float4(-0.928571403, (-0.928571403), (-0.928571403), (-0.928571403)));
          u_xlat0_d = ((u_xlat0_d * float4(0.285714298, 0.285714298, 0.285714298, 0.285714298)) + float4(-0.928571403, (-0.928571403), (-0.928571403), (-0.928571403)));
          u_xlat5.yw = u_xlat0_d.xy;
          u_xlat5.xz = u_xlat3.yw;
          u_xlat6.yw = floor(u_xlat0_d.xy);
          u_xlat6.xz = floor(u_xlat3.yw);
          u_xlat6 = ((u_xlat6 * float4(2, 2, 2, 2)) + float4(1, 1, 1, 1));
          u_xlat7 = ((-abs(u_xlat3.ywxz)) + float4(1, 1, 1, 1));
          u_xlat7 = ((-abs(u_xlat0_d)) + u_xlat7);
          u_xlatb8 = bool4(float4(0, 0, 0, 0) >= u_xlat7);
          u_xlat8.x = (u_xlatb8.x)?(float(-1)):(float(0));
          u_xlat8.y = (u_xlatb8.y)?(float(-1)):(float(0));
          u_xlat8.z = (u_xlatb8.z)?(float(-1)):(float(0));
          u_xlat8.w = (u_xlatb8.w)?(float(-1)):(float(0));
          u_xlat5 = ((u_xlat6 * u_xlat8.xxyy) + u_xlat5);
          u_xlat6.xy = u_xlat5.zw;
          u_xlat6.z = u_xlat7.y;
          u_xlat0_d.x = dot(u_xlat6.xyz, u_xlat6.xyz);
          u_xlat0_d.x = rsqrt(u_xlat0_d.x);
          u_xlat6.xyz = (u_xlat0_d.xxx * u_xlat6.xyz);
          u_xlat6.y = dot(u_xlat6.xyz, u_xlat4.xyz);
          u_xlat4.y = dot(u_xlat4.xyz, u_xlat4.xyz);
          u_xlat9.yw = floor(u_xlat0_d.zw);
          u_xlat3.yw = u_xlat0_d.zw;
          u_xlat9.xz = floor(u_xlat3.xz);
          u_xlat0_d = ((u_xlat9 * float4(2, 2, 2, 2)) + float4(1, 1, 1, 1));
          u_xlat0_d = ((u_xlat0_d.zwxy * u_xlat8.wwzz) + u_xlat3.zwxy);
          u_xlat3.xy = u_xlat0_d.zw;
          u_xlat3.z = u_xlat7.z;
          u_xlat3.xyz = normalize(u_xlat3.xyz);
          u_xlat6.z = dot(u_xlat3.xyz, u_xlat2.xyz);
          u_xlat4.z = dot(u_xlat2.xyz, u_xlat2.xyz);
          u_xlat5.z = u_xlat7.x;
          u_xlat0_d.z = u_xlat7.w;
          u_xlat2.xyz = normalize(u_xlat5.xyz);
          u_xlat6.x = dot(u_xlat2.xyz, u_xlat1_d.xyz);
          u_xlat0_d.xyz = normalize(u_xlat0_d.xyz);
          u_xlat2.xyz = (u_xlat1_d.xyz + float3(-0.5, (-0.5), (-0.5)));
          u_xlat4.x = dot(u_xlat1_d.xyz, u_xlat1_d.xyz);
          u_xlat6.w = dot(u_xlat0_d.xyz, u_xlat2.xyz);
          u_xlat4.w = dot(u_xlat2.xyz, u_xlat2.xyz);
          u_xlat0_d = ((-u_xlat4) + float4(0.600000024, 0.600000024, 0.600000024, 0.600000024));
          u_xlat0_d = max(u_xlat0_d, float4(0, 0, 0, 0));
          u_xlat0_d = (u_xlat0_d * u_xlat0_d);
          u_xlat0_d = (u_xlat0_d * u_xlat0_d);
          u_xlat0_d.x = dot(u_xlat0_d, u_xlat6);
          u_xlat13 = (in_f.texcoord.y * in_f.color.x);
          u_xlat13 = ((u_xlat13 * _CutoffEdge) + (-1));
          u_xlat0_d.x = (((-u_xlat0_d.x) * 42) + u_xlat13);
          u_xlatb0 = (u_xlat0_d.x<0);
          if(((int(u_xlatb0) * int(4294967295))!=0))
          {
              discard;
          }
          u_xlat0_d.x = float(0);
          u_xlat0_d.w = float(1);
          u_xlat1_d.x = float(0);
          u_xlat1_d.w = float(1);
          u_xlat2.xy = (in_f.texcoord1.xy / float2(float2(_Pixelisation, _Pixelisation)));
          u_xlat2.xy = round(u_xlat2.xy);
          u_xlat2.xy = (u_xlat2.xy * float2(float2(_Pixelisation, _Pixelisation)));
          u_xlat2.z = (_Time.x * _Speed);
          u_xlat3 = (u_xlat2.zxyz * float4(0.0300000012, 0.0599999987, 0.0599999987, 0.150000006));
          u_xlat28 = dot(u_xlat3.yzw, float3(0.333333343, 0.333333343, 0.333333343));
          u_xlat4.xyz = (float3(u_xlat28, u_xlat28, u_xlat28) + u_xlat3.yzw);
          u_xlat4.xyz = floor(u_xlat4.xyz);
          u_xlat5.xyz = (u_xlat4.xyz * float3(0.00346020772, 0.00346020772, 0.00346020772));
          u_xlat5.xyz = floor(u_xlat5.xyz);
          u_xlat5.xyz = (((-u_xlat5.xyz) * float3(289, 289, 289)) + u_xlat4.xyz);
          u_xlat6.xyz = (u_xlat3.yzw + (-u_xlat4.xyz));
          u_xlat7.xyz = (u_xlat3.yzw + float3(3941, 3941, 0));
          u_xlat28 = dot(u_xlat4.xyz, float3(0.166666672, 0.166666672, 0.166666672));
          u_xlat4.xyz = (float3(u_xlat28, u_xlat28, u_xlat28) + u_xlat6.xyz);
          u_xlatb6.xyz = bool4(u_xlat4.zxyz >= u_xlat4.xyzx).xyz;
          u_xlat8.x = (u_xlatb6.y)?(float(1)):(0);
          u_xlat8.y = (u_xlatb6.z)?(float(1)):(0);
          u_xlat8.z = (u_xlatb6.x)?(float(1)):(0);
          u_xlat6.x = (u_xlatb6.x)?(float(0)):(float(1));
          u_xlat6.y = (u_xlatb6.y)?(float(0)):(float(1));
          u_xlat6.z = (u_xlatb6.z)?(float(0)):(float(1));
          u_xlat9.xyz = min(u_xlat6.xyz, u_xlat8.xyz);
          u_xlat6.xyz = max(u_xlat6.xyz, u_xlat8.xyz);
          u_xlat1_d.y = u_xlat9.z;
          u_xlat1_d.z = u_xlat6.z;
          u_xlat1_d = (u_xlat1_d + u_xlat5.zzzz);
          u_xlat8 = (u_xlat1_d * u_xlat1_d);
          u_xlat1_d = ((u_xlat8 * float4(34, 34, 34, 34)) + u_xlat1_d);
          u_xlat8 = (u_xlat1_d * float4(0.00346020772, 0.00346020772, 0.00346020772, 0.00346020772));
          u_xlat8 = floor(u_xlat8);
          u_xlat1_d = (((-u_xlat8) * float4(289, 289, 289, 289)) + u_xlat1_d);
          u_xlat1_d = (u_xlat5.yyyy + u_xlat1_d);
          u_xlat0_d.y = u_xlat9.y;
          u_xlat0_d.z = u_xlat6.y;
          u_xlat0_d = (u_xlat0_d + u_xlat1_d);
          u_xlat1_d = (u_xlat0_d * u_xlat0_d);
          u_xlat0_d = ((u_xlat1_d * float4(34, 34, 34, 34)) + u_xlat0_d);
          u_xlat1_d = (u_xlat0_d * float4(0.00346020772, 0.00346020772, 0.00346020772, 0.00346020772));
          u_xlat1_d = floor(u_xlat1_d);
          u_xlat0_d = (((-u_xlat1_d) * float4(289, 289, 289, 289)) + u_xlat0_d);
          u_xlat0_d = (u_xlat5.xxxx + u_xlat0_d);
          u_xlat1_d.x = float(0);
          u_xlat1_d.w = float(1);
          u_xlat1_d.y = u_xlat9.x;
          u_xlat5.xyz = (u_xlat4.xyz + (-u_xlat9.xyz));
          u_xlat5.xyz = (u_xlat5.xyz + float3(0.166666672, 0.166666672, 0.166666672));
          u_xlat1_d.z = u_xlat6.x;
          u_xlat6.xyz = (u_xlat4.xyz + (-u_xlat6.xyz));
          u_xlat6.xyz = (u_xlat6.xyz + float3(0.333333343, 0.333333343, 0.333333343));
          u_xlat0_d = (u_xlat0_d + u_xlat1_d);
          u_xlat1_d = (u_xlat0_d * u_xlat0_d);
          u_xlat0_d = ((u_xlat1_d * float4(34, 34, 34, 34)) + u_xlat0_d);
          u_xlat1_d = (u_xlat0_d * float4(0.00346020772, 0.00346020772, 0.00346020772, 0.00346020772));
          u_xlat1_d = floor(u_xlat1_d);
          u_xlat0_d = (((-u_xlat1_d) * float4(289, 289, 289, 289)) + u_xlat0_d);
          u_xlat1_d = (u_xlat0_d * float4(0.0204081647, 0.0204081647, 0.0204081647, 0.0204081647));
          u_xlat1_d = floor(u_xlat1_d);
          u_xlat0_d = (((-u_xlat1_d) * float4(49, 49, 49, 49)) + u_xlat0_d);
          u_xlat1_d = (u_xlat0_d * float4(0.142857149, 0.142857149, 0.142857149, 0.142857149));
          u_xlat1_d = floor(u_xlat1_d);
          u_xlat0_d = (((-u_xlat1_d) * float4(7, 7, 7, 7)) + u_xlat0_d);
          u_xlat1_d = ((u_xlat1_d.zxwy * float4(0.285714298, 0.285714298, 0.285714298, 0.285714298)) + float4(-0.928571403, (-0.928571403), (-0.928571403), (-0.928571403)));
          u_xlat0_d = ((u_xlat0_d * float4(0.285714298, 0.285714298, 0.285714298, 0.285714298)) + float4(-0.928571403, (-0.928571403), (-0.928571403), (-0.928571403)));
          u_xlat8.yw = u_xlat0_d.xy;
          u_xlat8.xz = u_xlat1_d.yw;
          u_xlat9.yw = floor(u_xlat0_d.xy);
          u_xlat9.xz = floor(u_xlat1_d.yw);
          u_xlat9 = ((u_xlat9 * float4(2, 2, 2, 2)) + float4(1, 1, 1, 1));
          u_xlat10 = ((-abs(u_xlat1_d.ywxz)) + float4(1, 1, 1, 1));
          u_xlat10 = ((-abs(u_xlat0_d)) + u_xlat10);
          u_xlatb11 = bool4(float4(0, 0, 0, 0) >= u_xlat10);
          u_xlat11.x = (u_xlatb11.x)?(float(-1)):(float(0));
          u_xlat11.y = (u_xlatb11.y)?(float(-1)):(float(0));
          u_xlat11.z = (u_xlatb11.z)?(float(-1)):(float(0));
          u_xlat11.w = (u_xlatb11.w)?(float(-1)):(float(0));
          u_xlat8 = ((u_xlat9 * u_xlat11.xxyy) + u_xlat8);
          u_xlat9.xy = u_xlat8.zw;
          u_xlat9.z = u_xlat10.y;
          u_xlat0_d.x = dot(u_xlat9.xyz, u_xlat9.xyz);
          u_xlat0_d.x = rsqrt(u_xlat0_d.x);
          u_xlat9.xyz = (u_xlat0_d.xxx * u_xlat9.xyz);
          u_xlat9.y = dot(u_xlat9.xyz, u_xlat5.xyz);
          u_xlat5.y = dot(u_xlat5.xyz, u_xlat5.xyz);
          u_xlat12.yw = floor(u_xlat0_d.zw);
          u_xlat1_d.yw = u_xlat0_d.zw;
          u_xlat12.xz = floor(u_xlat1_d.xz);
          u_xlat0_d = ((u_xlat12 * float4(2, 2, 2, 2)) + float4(1, 1, 1, 1));
          u_xlat0_d = ((u_xlat0_d.zwxy * u_xlat11.wwzz) + u_xlat1_d.zwxy);
          u_xlat1_d.xy = u_xlat0_d.zw;
          u_xlat1_d.z = u_xlat10.z;
          u_xlat1_d.xyz = normalize(u_xlat1_d.xyz);
          u_xlat9.z = dot(u_xlat1_d.xyz, u_xlat6.xyz);
          u_xlat5.z = dot(u_xlat6.xyz, u_xlat6.xyz);
          u_xlat8.z = u_xlat10.x;
          u_xlat0_d.z = u_xlat10.w;
          u_xlat1_d.xyz = normalize(u_xlat8.xyz);
          u_xlat9.x = dot(u_xlat1_d.xyz, u_xlat4.xyz);
          u_xlat0_d.xyz = normalize(u_xlat0_d.xyz);
          u_xlat1_d.xyz = (u_xlat4.xyz + float3(-0.5, (-0.5), (-0.5)));
          u_xlat5.x = dot(u_xlat4.xyz, u_xlat4.xyz);
          u_xlat9.w = dot(u_xlat0_d.xyz, u_xlat1_d.xyz);
          u_xlat5.w = dot(u_xlat1_d.xyz, u_xlat1_d.xyz);
          u_xlat0_d = ((-u_xlat5) + float4(0.600000024, 0.600000024, 0.600000024, 0.600000024));
          u_xlat0_d = max(u_xlat0_d, float4(0, 0, 0, 0));
          u_xlat0_d = (u_xlat0_d * u_xlat0_d);
          u_xlat0_d = (u_xlat0_d * u_xlat0_d);
          u_xlat0_d.x = dot(u_xlat0_d, u_xlat9);
          u_xlat26.x = dot(u_xlat7.xyz, float3(0.333333343, 0.333333343, 0.333333343));
          u_xlat1_d.xyz = (u_xlat26.xxx + u_xlat7.xyz);
          u_xlat1_d.xyz = floor(u_xlat1_d.xyz);
          u_xlat4.xyz = (u_xlat1_d.xyz * float3(0.00346020772, 0.00346020772, 0.00346020772));
          u_xlat4.xyz = floor(u_xlat4.xyz);
          u_xlat4.xyz = (((-u_xlat4.xyz) * float3(289, 289, 289)) + u_xlat1_d.xyz);
          u_xlat5.xyz = ((-u_xlat1_d.xyz) + u_xlat7.xyz);
          u_xlat26.x = dot(u_xlat1_d.xyz, float3(0.166666672, 0.166666672, 0.166666672));
          u_xlat1_d.xyz = (u_xlat26.xxx + u_xlat5.xyz);
          u_xlatb5.xyz = bool4(u_xlat1_d.zxyz >= u_xlat1_d.xyzx).xyz;
          u_xlat6.x = (u_xlatb5.y)?(float(1)):(0);
          u_xlat6.y = (u_xlatb5.z)?(float(1)):(0);
          u_xlat6.z = (u_xlatb5.x)?(float(1)):(0);
          u_xlat5.x = (u_xlatb5.x)?(float(0)):(float(1));
          u_xlat5.y = (u_xlatb5.y)?(float(0)):(float(1));
          u_xlat5.z = (u_xlatb5.z)?(float(0)):(float(1));
          u_xlat7.xyz = min(u_xlat5.xyz, u_xlat6.xyz);
          u_xlat5.xyz = max(u_xlat5.xyz, u_xlat6.xyz);
          u_xlat6.y = u_xlat7.z;
          u_xlat6.z = u_xlat5.z;
          u_xlat6.x = float(0);
          u_xlat6.w = float(1);
          u_xlat6 = (u_xlat4.zzzz + u_xlat6);
          u_xlat8 = (u_xlat6 * u_xlat6);
          u_xlat6 = ((u_xlat8 * float4(34, 34, 34, 34)) + u_xlat6);
          u_xlat8 = (u_xlat6 * float4(0.00346020772, 0.00346020772, 0.00346020772, 0.00346020772));
          u_xlat8 = floor(u_xlat8);
          u_xlat6 = (((-u_xlat8) * float4(289, 289, 289, 289)) + u_xlat6);
          u_xlat6 = (u_xlat4.yyyy + u_xlat6);
          u_xlat8.x = float(0);
          u_xlat8.w = float(1);
          u_xlat8.y = u_xlat7.y;
          u_xlat8.z = u_xlat5.y;
          u_xlat6 = (u_xlat6 + u_xlat8);
          u_xlat8 = (u_xlat6 * u_xlat6);
          u_xlat6 = ((u_xlat8 * float4(34, 34, 34, 34)) + u_xlat6);
          u_xlat8 = (u_xlat6 * float4(0.00346020772, 0.00346020772, 0.00346020772, 0.00346020772));
          u_xlat8 = floor(u_xlat8);
          u_xlat6 = (((-u_xlat8) * float4(289, 289, 289, 289)) + u_xlat6);
          u_xlat4 = (u_xlat4.xxxx + u_xlat6);
          u_xlat6.x = float(0);
          u_xlat6.w = float(1);
          u_xlat6.y = u_xlat7.x;
          u_xlat7.xyz = (u_xlat1_d.xyz + (-u_xlat7.xyz));
          u_xlat7.xyz = (u_xlat7.xyz + float3(0.166666672, 0.166666672, 0.166666672));
          u_xlat6.z = u_xlat5.x;
          u_xlat5.xyz = (u_xlat1_d.xyz + (-u_xlat5.xyz));
          u_xlat5.xyz = (u_xlat5.xyz + float3(0.333333343, 0.333333343, 0.333333343));
          u_xlat4 = (u_xlat4 + u_xlat6);
          u_xlat6 = (u_xlat4 * u_xlat4);
          u_xlat4 = ((u_xlat6 * float4(34, 34, 34, 34)) + u_xlat4);
          u_xlat6 = (u_xlat4 * float4(0.00346020772, 0.00346020772, 0.00346020772, 0.00346020772));
          u_xlat6 = floor(u_xlat6);
          u_xlat4 = (((-u_xlat6) * float4(289, 289, 289, 289)) + u_xlat4);
          u_xlat6 = (u_xlat4 * float4(0.0204081647, 0.0204081647, 0.0204081647, 0.0204081647));
          u_xlat6 = floor(u_xlat6);
          u_xlat4 = (((-u_xlat6) * float4(49, 49, 49, 49)) + u_xlat4);
          u_xlat6 = (u_xlat4 * float4(0.142857149, 0.142857149, 0.142857149, 0.142857149));
          u_xlat6 = floor(u_xlat6);
          u_xlat4 = (((-u_xlat6) * float4(7, 7, 7, 7)) + u_xlat4);
          u_xlat6 = ((u_xlat6.zxwy * float4(0.285714298, 0.285714298, 0.285714298, 0.285714298)) + float4(-0.928571403, (-0.928571403), (-0.928571403), (-0.928571403)));
          u_xlat4 = ((u_xlat4 * float4(0.285714298, 0.285714298, 0.285714298, 0.285714298)) + float4(-0.928571403, (-0.928571403), (-0.928571403), (-0.928571403)));
          u_xlat8.yw = u_xlat4.xy;
          u_xlat8.xz = u_xlat6.yw;
          u_xlat9.yw = floor(u_xlat4.xy);
          u_xlat9.xz = floor(u_xlat6.yw);
          u_xlat9 = ((u_xlat9 * float4(2, 2, 2, 2)) + float4(1, 1, 1, 1));
          u_xlat10 = ((-abs(u_xlat6.ywxz)) + float4(1, 1, 1, 1));
          u_xlat10 = ((-abs(u_xlat4)) + u_xlat10);
          u_xlatb11 = bool4(float4(0, 0, 0, 0) >= u_xlat10);
          u_xlat11.x = (u_xlatb11.x)?(float(-1)):(float(0));
          u_xlat11.y = (u_xlatb11.y)?(float(-1)):(float(0));
          u_xlat11.z = (u_xlatb11.z)?(float(-1)):(float(0));
          u_xlat11.w = (u_xlatb11.w)?(float(-1)):(float(0));
          u_xlat8 = ((u_xlat9 * u_xlat11.xxyy) + u_xlat8);
          u_xlat9.xy = u_xlat8.zw;
          u_xlat9.z = u_xlat10.y;
          u_xlat26.x = dot(u_xlat9.xyz, u_xlat9.xyz);
          u_xlat26.x = rsqrt(u_xlat26.x);
          u_xlat9.xyz = (u_xlat26.xxx * u_xlat9.xyz);
          u_xlat9.y = dot(u_xlat9.xyz, u_xlat7.xyz);
          u_xlat7.y = dot(u_xlat7.xyz, u_xlat7.xyz);
          u_xlat12.yw = floor(u_xlat4.zw);
          u_xlat6.yw = u_xlat4.zw;
          u_xlat12.xz = floor(u_xlat6.xz);
          u_xlat4 = ((u_xlat12 * float4(2, 2, 2, 2)) + float4(1, 1, 1, 1));
          u_xlat4 = ((u_xlat4.zwxy * u_xlat11.wwzz) + u_xlat6.zwxy);
          u_xlat6.xy = u_xlat4.zw;
          u_xlat6.z = u_xlat10.z;
          u_xlat26.x = dot(u_xlat6.xyz, u_xlat6.xyz);
          u_xlat26.x = rsqrt(u_xlat26.x);
          u_xlat6.xyz = (u_xlat26.xxx * u_xlat6.xyz);
          u_xlat9.z = dot(u_xlat6.xyz, u_xlat5.xyz);
          u_xlat7.z = dot(u_xlat5.xyz, u_xlat5.xyz);
          u_xlat8.z = u_xlat10.x;
          u_xlat4.z = u_xlat10.w;
          u_xlat26.x = dot(u_xlat8.xyz, u_xlat8.xyz);
          u_xlat26.x = rsqrt(u_xlat26.x);
          u_xlat5.xyz = (u_xlat26.xxx * u_xlat8.xyz);
          u_xlat9.x = dot(u_xlat5.xyz, u_xlat1_d.xyz);
          u_xlat26.x = dot(u_xlat4.xyz, u_xlat4.xyz);
          u_xlat26.x = rsqrt(u_xlat26.x);
          u_xlat4.xyz = (u_xlat26.xxx * u_xlat4.xyz);
          u_xlat5.xyz = (u_xlat1_d.xyz + float3(-0.5, (-0.5), (-0.5)));
          u_xlat7.x = dot(u_xlat1_d.xyz, u_xlat1_d.xyz);
          u_xlat9.w = dot(u_xlat4.xyz, u_xlat5.xyz);
          u_xlat7.w = dot(u_xlat5.xyz, u_xlat5.xyz);
          u_xlat1_d = ((-u_xlat7) + float4(0.600000024, 0.600000024, 0.600000024, 0.600000024));
          u_xlat1_d = max(u_xlat1_d, float4(0, 0, 0, 0));
          u_xlat1_d = (u_xlat1_d * u_xlat1_d);
          u_xlat1_d = (u_xlat1_d * u_xlat1_d);
          u_xlat0_d.y = dot(u_xlat1_d, u_xlat9);
          u_xlat0_d.xy = (u_xlat0_d.xy * float2(_Scale, _Scale));
          u_xlat0_d.xy = (u_xlat0_d.xy * float2(84, 84));
          u_xlat0_d.xy = ((u_xlat2.xy * float2(_Scale, _Scale)) + u_xlat0_d.xy);
          u_xlat1_d = (u_xlat0_d.xyxy * float4(0.5, 0.5, 0.0199999996, 0.0199999996));
          u_xlat26.x = dot(u_xlat1_d.zw, float2(0.366025418, 0.366025418));
          u_xlat1_d = tex2D(_LavaNoise, u_xlat1_d.xy);
          u_xlat26.xy = ((u_xlat0_d.xy * float2(0.0199999996, 0.0199999996)) + u_xlat26.xx);
          u_xlat26.xy = floor(u_xlat26.xy);
          u_xlat14.xy = ((u_xlat0_d.xy * float2(0.0199999996, 0.0199999996)) + (-u_xlat26.xy));
          u_xlat40 = dot(u_xlat26.xy, float2(0.211324871, 0.211324871));
          u_xlat14.xy = (float2(u_xlat40, u_xlat40) + u_xlat14.xy);
          u_xlat2.xy = (u_xlat26.xy * float2(0.00346020772, 0.00346020772));
          u_xlat2.xy = floor(u_xlat2.xy);
          u_xlat26.xy = (((-u_xlat2.xy) * float2(289, 289)) + u_xlat26.xy);
          u_xlatb40 = (u_xlat14.y<u_xlat14.x);
          u_xlat2 = (int(u_xlatb40))?(float4(1, 0, (-1), (-0))):(float4(0, 1, (-0), (-1)));
          u_xlat4.y = u_xlat2.y;
          u_xlat4.x = float(0);
          u_xlat4.z = float(1);
          u_xlat4.xyz = (u_xlat26.yyy + u_xlat4.xyz);
          u_xlat5.xyz = (u_xlat4.xyz * u_xlat4.xyz);
          u_xlat4.xyz = ((u_xlat5.xyz * float3(34, 34, 34)) + u_xlat4.xyz);
          u_xlat5.xyz = (u_xlat4.xyz * float3(0.00346020772, 0.00346020772, 0.00346020772));
          u_xlat5.xyz = floor(u_xlat5.xyz);
          u_xlat4.xyz = (((-u_xlat5.xyz) * float3(289, 289, 289)) + u_xlat4.xyz);
          u_xlat4.xyz = (u_xlat26.xxx + u_xlat4.xyz);
          u_xlat5.y = u_xlat2.x;
          u_xlat5.x = float(0);
          u_xlat5.z = float(1);
          u_xlat4.xyz = (u_xlat4.xyz + u_xlat5.xyz);
          u_xlat5.xyz = (u_xlat4.xyz * u_xlat4.xyz);
          u_xlat4.xyz = ((u_xlat5.xyz * float3(34, 34, 34)) + u_xlat4.xyz);
          u_xlat5.xyz = (u_xlat4.xyz * float3(0.00346020772, 0.00346020772, 0.00346020772));
          u_xlat5.xyz = floor(u_xlat5.xyz);
          u_xlat4.xyz = (((-u_xlat5.xyz) * float3(289, 289, 289)) + u_xlat4.xyz);
          u_xlat4.xyz = (u_xlat4.xyz * float3(0.024390243, 0.024390243, 0.024390243));
          u_xlat4.xyz = frac(u_xlat4.xyz);
          u_xlat5.xyz = ((u_xlat4.xyz * float3(2, 2, 2)) + float3(-0.5, (-0.5), (-0.5)));
          u_xlat4.xyz = ((u_xlat4.xyz * float3(2, 2, 2)) + float3(-1, (-1), (-1)));
          u_xlat5.xyz = floor(u_xlat5.xyz);
          u_xlat5.xyz = (u_xlat4.xyz + (-u_xlat5.xyz));
          u_xlat4.xyz = (abs(u_xlat4.xyz) + float3(-0.5, (-0.5), (-0.5)));
          u_xlat26.x = (u_xlat14.y * u_xlat4.x);
          u_xlat6.x = ((u_xlat5.x * u_xlat14.x) + u_xlat26.x);
          u_xlat7.x = dot(u_xlat14.xy, u_xlat14.xy);
          u_xlat8 = (u_xlat14.xyxy + float4(0.211324871, 0.211324871, (-0.577350259), (-0.577350259)));
          u_xlat7.z = dot(u_xlat8.zw, u_xlat8.zw);
          u_xlat8.xy = (u_xlat2.zw + u_xlat8.xy);
          u_xlat7.y = dot(u_xlat8.xy, u_xlat8.xy);
          u_xlat14.xyz = ((-u_xlat7.xyz) + float3(0.5, 0.5, 0.5));
          u_xlat14.xyz = max(u_xlat14.xyz, float3(0, 0, 0));
          u_xlat14.xyz = (u_xlat14.xyz * u_xlat14.xyz);
          u_xlat14.xyz = (u_xlat14.xyz * u_xlat14.xyz);
          u_xlat2.xyz = (u_xlat4.xyz * u_xlat4.xyz);
          u_xlat26.xy = (u_xlat4.yz * u_xlat8.yw);
          u_xlat6.yz = ((u_xlat5.yz * u_xlat8.xz) + u_xlat26.xy);
          u_xlat2.xyz = ((u_xlat5.xyz * u_xlat5.xyz) + u_xlat2.xyz);
          u_xlat2.xyz = (((-u_xlat2.xyz) * float3(0.853734732, 0.853734732, 0.853734732)) + float3(1.79284286, 1.79284286, 1.79284286));
          u_xlat14.xyz = (u_xlat14.xyz * u_xlat2.xyz);
          u_xlat0_d.z = dot(u_xlat14.xyz, u_xlat6.xyz);
          u_xlat3.y = float(0);
          u_xlat29.y = float(0);
          u_xlat14.xy = ((u_xlat0_d.xy * float2(0.00499999989, 0.00499999989)) + u_xlat3.xy);
          u_xlat2 = tex2D(_LavaNoise, u_xlat14.xy);
          u_xlat14.xy = (u_xlat0_d.xy * float2(0.0500000007, 0.0500000007));
          u_xlat0_d.xyz = (u_xlat0_d.xyz * float3(0.340000004, 0.340000004, 26));
          u_xlat4 = tex2D(_RockTexture, u_xlat0_d.xy);
          u_xlat0_d.xyw = (u_xlat4.xyz * _RockTint.xyz);
          u_xlat4 = tex2D(_LavaNoise, u_xlat14.xy);
          u_xlat14.x = ((u_xlat4.x * 0.5) + u_xlat2.x);
          u_xlat1_d.x = ((u_xlat1_d.x * 0.25) + u_xlat14.x);
          u_xlat26.x = ((u_xlat1_d.x * 0.555555582) + u_xlat0_d.z);
          u_xlat26.x = (((-in_f.texcoord.y) * 0.200000003) + u_xlat26.x);
          u_xlat26.x = clamp(u_xlat26.x, 0, 1);
          u_xlat26.x = ((-u_xlat26.x) + 1.10000002);
          u_xlat29.x = (((-u_xlat26.x) * u_xlat26.x) + 1);
          u_xlat1_d = tex2D(_TintGradient, u_xlat29.xy);
          u_xlat1_d.xyz = (u_xlat1_d.xyz * _LavaTint.xyz);
          u_xlat40 = ((-u_xlat26.x) + 1.20000005);
          u_xlat2.x = (u_xlat40 * u_xlat40);
          u_xlat40 = (u_xlat40 * u_xlat2.x);
          u_xlat2.xyz = (u_xlat0_d.xyw * float3(u_xlat40, u_xlat40, u_xlat40));
          u_xlat0_d.x = (((-u_xlat0_d.w) * u_xlat40) + u_xlat26.x);
          u_xlat0_d.x = (u_xlat0_d.x + (-0.400000006));
          u_xlat0_d.x = (u_xlat0_d.x * 2.00000024);
          u_xlat0_d.x = clamp(u_xlat0_d.x, 0, 1);
          u_xlat13 = ((-u_xlat4.x) + 1);
          u_xlat13 = ((u_xlat13 * 0.5) + u_xlat4.x);
          u_xlat1_d.xyz = ((u_xlat1_d.xyz * float3(u_xlat13, u_xlat13, u_xlat13)) + (-u_xlat2.xyz));
          u_xlat13 = ((u_xlat0_d.x * (-2)) + 3);
          u_xlat0_d.x = (u_xlat0_d.x * u_xlat0_d.x);
          u_xlat0_d.x = (u_xlat0_d.x * u_xlat13);
          u_xlat0_d.x = min(u_xlat0_d.x, 1);
          u_xlat2.w = _RockTint.w;
          u_xlat1_d.w = ((-u_xlat2.w) + _LavaTint.w);
          out_f.color = ((u_xlat0_d.xxxx * u_xlat1_d) + u_xlat2);
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
