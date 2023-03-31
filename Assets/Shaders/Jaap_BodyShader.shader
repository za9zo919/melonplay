Shader "Jaap/BodyShader"
{
  Properties
  {
    _MainTex ("Skin", 2D) = "white" {}
    _FleshTex ("Flesh", 2D) = "white" {}
    _BoneTex ("Skeleton", 2D) = "white" {}
    _DamageTex ("Damage", 2D) = "white" {}
    _DamageMultiplier ("Damage Multiplier", float) = 1
    _BurnProgressInfluence ("Burn Progress Influence", float) = 1
    _BurnProgress ("Burn Progress", Range(0, 1)) = 0
    _AcidProgress ("Acid Progress", Range(0, 1)) = 0
    _RottenProgress ("Rotten Progress", Range(0, 1)) = 0
    _ElectrocutionIntensity ("Electrocution Intensity", Range(0, 1)) = 0
    _BruiseColor ("Bruise Color", Color) = (1,0,1,1)
    _SecondBruiseColor ("Second bruise Color", Color) = (1,0,1,1)
    _ThirdBruiseColor ("Third bruise Color", Color) = (1,0,1,1)
    _BloodColor ("Blood Color", Color) = (1,0,0,1)
    _Zombie ("Zombie Color", Color) = (1,0,0,1)
    [HDR] _ElectroBoneColour ("Electrified Bone Colour", Color) = (1,1,1,1)
    _FreezeColour ("Freeze Colour", Color) = (1,1,1,1)
    [HDR] _GlowColour ("Heat Colour", Color) = (1,0,1,1)
    _Temperature ("Temperature", Range(-1, 1)) = 1
    _DamagePointCount ("debug damage point count", float) = 1
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
      #pragma multi_compile DUMMY
      //#pragma target 4.0
      
      #pragma vertex vert
      #pragma fragment frag
      
      #include "UnityCG.cginc"
      
      
      #define CODE_BLOCK_VERTEX
      //uniform float4x4 unity_ObjectToWorld;
      //uniform float4x4 unity_MatrixVP;
      //uniform float4 _Time;
      uniform float4 _BruiseColor;
      uniform float4 _SecondBruiseColor;
      uniform float4 _ThirdBruiseColor;
      uniform float4 _Zombie;
      uniform float4 _GlowColour;
      uniform float4 _FreezeColour;
      uniform float4 _ElectroBoneColour;
      uniform float4 _BloodColor;
      uniform float4 _DamagePoints[128];
      uniform float _DamagePointTimeStamp[128];
      uniform int _DamagePointCount;
      uniform float _BurnProgress;
      uniform float _AcidProgress;
      uniform float _Temperature;
      uniform float _BurnProgressInfluence;
      uniform float _ElectrocutionIntensity;
      uniform float _RottenProgress;
      uniform sampler2D _MainTex;
      uniform sampler2D _FleshTex;
      uniform sampler2D _BoneTex;
      uniform sampler2D _DamageTex;
      struct appdata_t
      {
          float4 vertex :POSITION0;
          float4 color :COLOR0;
          float2 texcoord :TEXCOORD0;
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
          out_v.texcoord.xy = in_v.texcoord.xy;
          out_v.texcoord1.xy = in_v.vertex.xy;
          out_v.vertex = UnityObjectToClipPos(in_v.vertex);
          out_v.color = in_v.color;
          return out_v;
      }
      
      #define CODE_BLOCK_FRAGMENT
      float4 u_xlat0_d;
      int u_xlatb0;
      float4 u_xlat1_d;
      int u_xlatb1;
      float4 u_xlat2;
      float4 u_xlat3;
      float4 u_xlat4;
      float4 u_xlat5;
      int u_xlatb5;
      float4 u_xlat6;
      float4 u_xlat7;
      float4 u_xlat8;
      float4 u_xlat9;
      float2 u_xlat10;
      float4 u_xlat11;
      float4 u_xlat12;
      int u_xlatb12;
      float4 u_xlat13;
      int u_xlati14;
      float4 u_xlat15;
      float4 u_xlatb15;
      float4 u_xlat16;
      int u_xlatb16;
      float4 u_xlat17;
      float4 u_xlat18;
      float4 u_xlat19;
      float4 u_xlat20;
      float3 u_xlat21;
      int u_xlatb21;
      float3 u_xlat22;
      float u_xlat25;
      float3 u_xlat26;
      float2 u_xlat33;
      int u_xlatb33;
      float3 u_xlat35;
      int u_xlati35;
      int u_xlatb35;
      float3 u_xlat36;
      int u_xlatb36;
      float u_xlat42;
      int u_xlatb42;
      float u_xlat43;
      float u_xlat48;
      float u_xlat52;
      float u_xlat54;
      int u_xlatb54;
      float u_xlat56;
      int u_xlati56;
      float2 u_xlat58;
      float u_xlat63;
      int u_xlatb63;
      float u_xlat64;
      float u_xlat69;
      float u_xlat70;
      float u_xlat73;
      float u_xlat77;
      float u_xlat79;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlat0_d.xy = (in_f.texcoord1.xy * float2(35, 35));
          u_xlat0_d.xy = round(u_xlat0_d.xy);
          u_xlat1_d = tex2D(_MainTex, in_f.texcoord.xy);
          u_xlat42 = (u_xlat1_d.w + (-0.00999999978));
          u_xlatb42 = (u_xlat42<0);
          if(((int(u_xlatb42) * int(4294967295))!=0))
          {
              discard;
          }
          u_xlat2 = tex2D(_FleshTex, in_f.texcoord.xy);
          u_xlat3 = tex2D(_BoneTex, in_f.texcoord.xy);
          u_xlat4 = tex2D(_DamageTex, in_f.texcoord.xy);
          u_xlat42 = (u_xlat4.z * 0.899999976);
          u_xlat5 = ((u_xlat4.zwww * float4(0.200000003, 0.100000001, 0.100000001, 0.100000001)) + float4(1, 0.433999985, 0.0839999989, 0.0909999982));
          u_xlat63 = (u_xlat5.x * 0.5);
          u_xlat25 = (((-u_xlat5.x) * 0.5) + 1);
          u_xlat25 = (u_xlat25 + u_xlat25);
          u_xlatb5 = (u_xlat5.x<1);
          u_xlat5.x = (u_xlatb5)?(1):(float(0));
          u_xlat6.xyz = ((-u_xlat5.yzw) + _SecondBruiseColor.xyz);
          u_xlat26.xyz = ((u_xlat6.xyz * float3(0.200000003, 0.200000003, 0.200000003)) + u_xlat5.yzw);
          u_xlat6.xy = (u_xlat4.xz * u_xlat4.zz);
          u_xlat48 = ((u_xlat4.w * u_xlat4.w) + 0.300000012);
          u_xlat7.xyz = ((-_BruiseColor.xyz) + _SecondBruiseColor.xyz);
          u_xlat69 = (u_xlat6.x * 0.400000006);
          u_xlat8 = ((-_BloodColor) + float4(1, 1, 1, 1));
          u_xlat9 = ((-_BruiseColor) + _SecondBruiseColor);
          u_xlat9 = ((u_xlat4.wwww * u_xlat9) + _BruiseColor);
          u_xlat10.xy = (u_xlat4.xw + float2(0.100000001, 0.5));
          u_xlat70 = min(u_xlat10.x, 0.899999976);
          u_xlat10.x = ((-u_xlat70) + 1);
          u_xlat10.x = (float(1) / u_xlat10.x);
          u_xlat42 = min(u_xlat42, 1);
          u_xlat52 = ((-u_xlat42) + 1);
          u_xlat52 = (float(1) / u_xlat52);
          u_xlat73 = ((u_xlat4.w * 2.5999999) + 0.5);
          u_xlat11 = ((-_SecondBruiseColor) + float4(1, 1, 1, 1));
          u_xlat11 = ((u_xlat11 * float4(0.200000003, 0.200000003, 0.200000003, 0.200000003)) + _SecondBruiseColor);
          u_xlat11 = (u_xlat3 * u_xlat11);
          u_xlat12.w = 1;
          u_xlat13 = u_xlat1_d;
          int u_xlati_loop_1 = 0;
          while((u_xlati_loop_1<_DamagePointCount))
          {
             // u_xlati35 = int((2139095040 & floatBitsToUint(_DamagePoints[u_xlati_loop_1].z)));
              u_xlatb35 = (u_xlati35==int(2139095040));
              u_xlat56 = max(0, _DamagePoints[u_xlati_loop_1].z);
              u_xlat56 = min(u_xlat56, 100);
              u_xlat35.x = (u_xlatb35)?(0):(u_xlat56);
              u_xlat56 = floor(_DamagePoints[u_xlati_loop_1].w);
              u_xlati56 = int(u_xlat56);
              u_xlat77 = (_Time.y + (-_DamagePointTimeStamp[u_xlati_loop_1]));
              u_xlatb15 = bool4(int4(u_xlati56, u_xlati56, u_xlati56, u_xlati56) == int4(5, 4, 2, 3));
              u_xlatb16 = (0>=u_xlat35.x);
              u_xlatb15.x = (u_xlatb15.x || u_xlatb16);
              u_xlat16.xy = ((u_xlat0_d.xy * float2(0.0285714287, 0.0285714287)) + (-_DamagePoints[u_xlati_loop_1]));
              u_xlat16.x = length(u_xlat16.xy);
              u_xlat15.x = (u_xlatb15.x)?(100000):(u_xlat16.x);
              u_xlat16.xy = (u_xlat35.xx * float2(100, 0.0399999991));
              u_xlat16.x = min(u_xlat16.x, 8);
              u_xlat58.x = ((-u_xlat15.x) + 1);
              u_xlat58.x = (((-u_xlat25) * u_xlat58.x) + 1);
              u_xlat79 = ((u_xlat63 * u_xlat15.x) + (-u_xlat58.x));
              u_xlat58.x = ((u_xlat5.x * u_xlat79) + u_xlat58.x);
              u_xlat16.x = (u_xlat16.x / u_xlat58.x);
              u_xlat16.xzw = (u_xlat16.xxx + float3(-20, (-40), (-48)));
              u_xlat16.xzw = (u_xlat16.xzw * float3(0.03125, 0.0833333358, 0.055555556));
              u_xlat16.xzw = clamp(u_xlat16.xzw, 0, 1);
              u_xlat17.xyz = ((u_xlat16.xzw * float3(-2, (-2), (-2))) + float3(3, 3, 3));
              u_xlat16.xzw = (u_xlat16.xzw * u_xlat16.xzw);
              u_xlat16.xzw = (u_xlat16.xzw * u_xlat17.xyz);
              u_xlat16.x = (u_xlat4.w * u_xlat16.x);
              u_xlat17.xyz = ((-u_xlat13.xyz) + _BloodColor.xyz);
              u_xlat17.xyz = ((u_xlat16.xxx * u_xlat17.xyz) + u_xlat13.xyz);
              u_xlat18.xyz = ((_SecondBruiseColor.xyz * float3(0.5, 0.5, 0.5)) + (-u_xlat17.xyz));
              u_xlat17.xyz = ((u_xlat16.zzz * u_xlat18.xyz) + u_xlat17.xyz);
              u_xlat18.xyz = (u_xlat26.xyz + (-u_xlat17.xyz));
              u_xlat12.xyz = ((u_xlat16.www * u_xlat18.xyz) + u_xlat17.xyz);
              u_xlat17 = min(u_xlat12, u_xlat13);
              u_xlat17 = (u_xlatb15.y)?(u_xlat17):(u_xlat13);
              u_xlat12.x = (u_xlat16.y / u_xlat15.x);
              u_xlat33.x = min(u_xlat12.x, 1);
              u_xlat54 = ((u_xlat33.x * (-2)) + 3);
              u_xlat33.x = (u_xlat33.x * u_xlat33.x);
              u_xlat33.x = (u_xlat33.x * u_xlat54);
              u_xlat33.x = (u_xlat48 * u_xlat33.x);
              u_xlat16.xy = ((u_xlat33.xx * u_xlat4.zx) + float2(-0.300000012, (-0.100000001)));
              u_xlat16.xy = (u_xlat16.xy * float2(1.66666675, (-10)));
              u_xlat16.xy = clamp(u_xlat16.xy, 0, 1);
              u_xlat58.xy = ((u_xlat16.xy * float2(-2, (-2))) + float2(3, 3));
              u_xlat16.xy = (u_xlat16.xy * u_xlat16.xy);
              u_xlat16.xy = (u_xlat16.xy * u_xlat58.xy);
              u_xlat16.xzw = ((u_xlat16.xxx * u_xlat7.xyz) + _BruiseColor.xyz);
              u_xlat18.xyz = ((_ThirdBruiseColor.xyz * u_xlat33.xxx) + (-u_xlat16.xzw));
              u_xlat16.xyz = ((u_xlat16.yyy * u_xlat18.xyz) + u_xlat16.xzw);
              u_xlat18.xyz = ((-u_xlat17.xyz) + u_xlat16.xyz);
              u_xlat18.xyz = ((u_xlat33.xxx * u_xlat18.xyz) + u_xlat17.xyz);
              u_xlat12.x = sqrt(u_xlat12.x);
              u_xlat12.x = (u_xlat69 * u_xlat12.x);
              u_xlat12.x = (u_xlat12.x * 4);
              u_xlat12.x = min(u_xlat12.x, 0.5);
              u_xlat18.w = u_xlat17.w;
              u_xlat19 = ((-u_xlat18) + float4(1, 1, 1, 1));
              u_xlat19 = (u_xlat8 * u_xlat19);
              u_xlat19 = (((-u_xlat19) * float4(2, 2, 2, 2)) + float4(1, 1, 1, 1));
              u_xlat54 = (u_xlat18.y + u_xlat18.x);
              u_xlat54 = (u_xlat18.z + u_xlat54);
              u_xlatb54 = (u_xlat54<0.5);
              u_xlat54 = (u_xlatb54)?(1):(float(0));
              u_xlat20 = ((u_xlat18 * _BloodColor) + (-u_xlat19));
              u_xlat19 = ((float4(u_xlat54, u_xlat54, u_xlat54, u_xlat54) * u_xlat20) + u_xlat19);
              u_xlat12.xz = (u_xlat12.xx + float2(-0.150000006, (-0.25)));
              u_xlat12.xz = (u_xlat12.zx * float2(19.9999962, 2.85714293));
              u_xlat54 = max(u_xlat12.z, 0);
              u_xlat36.x = ((u_xlat54 * (-2)) + 3);
              u_xlat54 = (u_xlat54 * u_xlat54);
              u_xlat54 = (u_xlat54 * u_xlat36.x);
              u_xlat19 = ((-u_xlat18) + u_xlat19);
              u_xlat18 = ((float4(u_xlat54, u_xlat54, u_xlat54, u_xlat54) * u_xlat19) + u_xlat18);
              u_xlat12.x = u_xlat12.x;
              u_xlat12.x = clamp(u_xlat12.x, 0, 1);
              u_xlat36.x = ((u_xlat12.x * (-2)) + 3);
              u_xlat12.x = (u_xlat12.x * u_xlat12.x);
              u_xlat12.x = (u_xlat12.x * u_xlat36.x);
              u_xlat19 = (u_xlat2 + (-u_xlat18));
              u_xlat18 = ((u_xlat12.xxxx * u_xlat19) + u_xlat18);
              u_xlat17 = ((int(u_xlati56)!=0))?(u_xlat17):(u_xlat18);
              u_xlat36.x = (u_xlat17.w + (-0.5));
              u_xlatb36 = (u_xlat36.x<0);
              if(((int(u_xlatb36) * int(4294967295))!=0))
              {
                  discard;
              }
              u_xlat18.xyz = min(u_xlat35.xxx, float3(2.5, 15, 10));
              u_xlat18.xyw = (u_xlat18.xyz * float3(0.0399999991, 0.0299999993, 0.00639999984));
              u_xlat35.x = max(u_xlat15.x, 0.00999999978);
              u_xlat35.x = (u_xlat18.x / u_xlat35.x);
              u_xlat35.x = min(u_xlat35.x, 1);
              u_xlat36.x = (u_xlat35.x * u_xlat35.x);
              u_xlat19 = (u_xlat9 + (-u_xlat17));
              u_xlat19 = ((u_xlat36.xxxx * u_xlat19) + u_xlat17);
              u_xlat35.x = (u_xlat35.x + (-0.949999988));
              u_xlat35.x = (u_xlat35.x * 19.9999962);
              u_xlat35.x = max(u_xlat35.x, 0);
              u_xlat36.x = ((u_xlat35.x * (-2)) + 3);
              u_xlat35.x = (u_xlat35.x * u_xlat35.x);
              u_xlat35.x = (u_xlat35.x * u_xlat36.x);
              u_xlat20 = (u_xlat2 + (-u_xlat19));
              u_xlat19 = ((u_xlat35.xxxx * u_xlat20) + u_xlat19);
              u_xlat17 = (u_xlatb15.z)?(u_xlat19):(u_xlat17);
              u_xlat35.x = (u_xlat17.w + (-0.5));
              u_xlatb35 = (u_xlat35.x<0);
              if(((int(u_xlatb35) * int(4294967295))!=0))
              {
                  discard;
              }
              u_xlat16.xyz = (u_xlat16.xyz + (-u_xlat17.xyz));
              u_xlat16.xyz = ((u_xlat33.xxx * u_xlat16.xyz) + u_xlat17.xyz);
              u_xlat16.w = u_xlat17.w;
              u_xlat19 = ((-u_xlat16) + float4(1, 1, 1, 1));
              u_xlat19 = (u_xlat8 * u_xlat19);
              u_xlat19 = (((-u_xlat19) * float4(2, 2, 2, 2)) + float4(1, 1, 1, 1));
              u_xlat33.x = (u_xlat16.y + u_xlat16.x);
              u_xlat33.x = (u_xlat16.z + u_xlat33.x);
              u_xlatb33 = (u_xlat33.x<0.5);
              u_xlat33.x = (u_xlatb33)?(1):(float(0));
              u_xlat20 = ((u_xlat16 * _BloodColor) + (-u_xlat19));
              u_xlat19 = ((u_xlat33.xxxx * u_xlat20) + u_xlat19);
              u_xlat19 = ((-u_xlat16) + u_xlat19);
              u_xlat16 = ((float4(u_xlat54, u_xlat54, u_xlat54, u_xlat54) * u_xlat19) + u_xlat16);
              u_xlat19 = (u_xlat2 + (-u_xlat16));
              u_xlat16 = ((u_xlat12.xxxx * u_xlat19) + u_xlat16);
              u_xlat12.xy = (u_xlat18.yw / u_xlat15.xx);
              u_xlat54 = (((-u_xlat12.x) * u_xlat4.z) + 1);
              u_xlatb54 = (u_xlat54<0);
              u_xlat35.x = ((-u_xlat70) + u_xlat12.x);
              u_xlat35.x = (u_xlat10.x * u_xlat35.x);
              u_xlat35.x = clamp(u_xlat35.x, 0, 1);
              u_xlat36.x = ((u_xlat35.x * (-2)) + 3);
              u_xlat35.x = (u_xlat35.x * u_xlat35.x);
              u_xlat35.x = (u_xlat35.x * u_xlat36.x);
              u_xlat18.xyw = ((_BloodColor.xyz * float3(0.800000012, 0.800000012, 0.800000012)) + (-u_xlat16.xyz));
              u_xlat16.xyz = ((u_xlat35.xxx * u_xlat18.xyw) + u_xlat16.xyz);
              u_xlat12.x = (u_xlat12.x + (-0.850000024));
              u_xlat12.x = (u_xlat12.x * 6.66666794);
              u_xlat12.x = clamp(u_xlat12.x, 0, 1);
              u_xlat35.x = ((u_xlat12.x * (-2)) + 3);
              u_xlat12.x = (u_xlat12.x * u_xlat12.x);
              u_xlat12.x = (u_xlat12.x * u_xlat35.x);
              u_xlat19 = (u_xlat2 + (-u_xlat16));
              u_xlat16 = ((u_xlat12.xxxx * u_xlat19) + u_xlat16);
              u_xlat16 = (int(u_xlatb54))?(u_xlat3):(u_xlat16);
              u_xlat16 = (u_xlatb15.w)?(u_xlat16):(u_xlat17);
              u_xlat12.x = (u_xlat16.w + (-0.5));
              u_xlatb12 = (u_xlat12.x<0);
              if(((int(u_xlatb12) * int(4294967295))!=0))
              {
                  discard;
              }
              u_xlatb12 = (u_xlati56==1);
              u_xlat54 = min(u_xlat12.y, 1);
              u_xlat35.x = ((u_xlat54 * (-2)) + 3);
              u_xlat54 = (u_xlat54 * u_xlat54);
              u_xlat54 = (u_xlat54 * u_xlat35.x);
              u_xlat54 = (u_xlat48 * u_xlat54);
              u_xlat35.xy = ((float2(u_xlat54, u_xlat54) * u_xlat4.zx) + float2(-0.300000012, (-0.100000001)));
              u_xlat35.xy = (u_xlat35.xy * float2(1.66666675, (-10)));
              u_xlat35.xy = clamp(u_xlat35.xy, 0, 1);
              u_xlat36.xy = ((u_xlat35.xy * float2(-2, (-2))) + float2(3, 3));
              u_xlat35.xy = (u_xlat35.xy * u_xlat35.xy);
              u_xlat35.xy = (u_xlat35.xy * u_xlat36.xy);
              u_xlat36.xyz = ((u_xlat35.xxx * u_xlat7.xyz) + _BruiseColor.xyz);
              u_xlat17.xyz = ((_ThirdBruiseColor.xyz * float3(u_xlat54, u_xlat54, u_xlat54)) + (-u_xlat36.xyz));
              u_xlat36.xyz = ((u_xlat35.yyy * u_xlat17.xyz) + u_xlat36.xyz);
              u_xlat36.xyz = ((-u_xlat16.xyz) + u_xlat36.xyz);
              u_xlat36.xyz = ((float3(u_xlat54, u_xlat54, u_xlat54) * u_xlat36.xyz) + u_xlat16.xyz);
              u_xlat33.x = sqrt(u_xlat12.y);
              u_xlat33.x = (u_xlat69 * u_xlat33.x);
              u_xlat33.x = (u_xlat33.x * 4);
              u_xlat33.x = min(u_xlat33.x, 0.5);
              u_xlat17.xyz = ((-u_xlat36.xyz) + float3(1, 1, 1));
              u_xlat17.xyz = (u_xlat8.xyz * u_xlat17.xyz);
              u_xlat17.xyz = (((-u_xlat17.xyz) * float3(2, 2, 2)) + float3(1, 1, 1));
              u_xlat54 = (u_xlat36.y + u_xlat36.x);
              u_xlat54 = (u_xlat36.z + u_xlat54);
              u_xlatb54 = (u_xlat54<0.5);
              u_xlat54 = (u_xlatb54)?(1):(float(0));
              u_xlat18.xyw = ((u_xlat36.xyz * _BloodColor.xyz) + (-u_xlat17.xyz));
              u_xlat17.xyz = ((float3(u_xlat54, u_xlat54, u_xlat54) * u_xlat18.xyw) + u_xlat17.xyz);
              u_xlat33.xy = (u_xlat33.xx + float2(-0.150000006, (-0.25)));
              u_xlat33.xy = (u_xlat33.yx * float2(19.9999962, 2.85714293));
              u_xlat54 = max(u_xlat33.y, 0);
              u_xlat35.x = ((u_xlat54 * (-2)) + 3);
              u_xlat54 = (u_xlat54 * u_xlat54);
              u_xlat54 = (u_xlat54 * u_xlat35.x);
              u_xlat17.xyz = ((-u_xlat36.xyz) + u_xlat17.xyz);
              u_xlat36.xyz = ((float3(u_xlat54, u_xlat54, u_xlat54) * u_xlat17.xyz) + u_xlat36.xyz);
              u_xlat33.x = u_xlat33.x;
              u_xlat33.x = clamp(u_xlat33.x, 0, 1);
              u_xlat54 = ((u_xlat33.x * (-2)) + 3);
              u_xlat33.x = (u_xlat33.x * u_xlat33.x);
              u_xlat33.x = (u_xlat33.x * u_xlat54);
              u_xlat17.xyz = (u_xlat2.xyz + (-u_xlat36.xyz));
              u_xlat36.xyz = ((u_xlat33.xxx * u_xlat17.xyz) + u_xlat36.xyz);
              u_xlat33.x = (u_xlat77 + (-1));
              u_xlat33.x = ((u_xlat33.x * 0.100000001) + 0.200000003);
              u_xlat33.x = clamp(u_xlat33.x, 0, 1);
              u_xlat35.xyz = ((-u_xlat16.xyz) + u_xlat36.xyz);
              u_xlat35.xyz = ((u_xlat33.xxx * u_xlat35.xyz) + u_xlat16.xyz);
              u_xlat33.x = log2(u_xlat18.z);
              u_xlat33.x = (u_xlat33.x * 1.39999998);
              u_xlat33.x = exp2(u_xlat33.x);
              u_xlat33.x = (u_xlat33.x * 0.00350000011);
              u_xlat33.x = (u_xlat33.x / u_xlat15.x);
              u_xlat54 = ((-u_xlat42) + u_xlat33.x);
              u_xlat54 = (u_xlat52 * u_xlat54);
              u_xlat54 = clamp(u_xlat54, 0, 1);
              u_xlat15.x = ((u_xlat54 * (-2)) + 3);
              u_xlat54 = (u_xlat54 * u_xlat54);
              u_xlat54 = (u_xlat54 * u_xlat15.x);
              u_xlat15.xyz = ((-u_xlat35.xyz) + _BloodColor.xyz);
              u_xlat15.xyz = ((float3(u_xlat54, u_xlat54, u_xlat54) * u_xlat15.xyz) + u_xlat35.xyz);
              u_xlat54 = (u_xlat33.x + (-0.5));
              u_xlat54 = (u_xlat54 + u_xlat54);
              u_xlat54 = clamp(u_xlat54, 0, 1);
              u_xlat35.x = ((u_xlat54 * (-2)) + 3);
              u_xlat54 = (u_xlat54 * u_xlat54);
              u_xlat54 = (u_xlat54 * u_xlat35.x);
              u_xlat15.w = u_xlat16.w;
              u_xlat17 = (u_xlat2 + (-u_xlat15));
              u_xlat15 = ((float4(u_xlat54, u_xlat54, u_xlat54, u_xlat54) * u_xlat17) + u_xlat15);
              u_xlat33.x = (u_xlat73 + (-u_xlat33.x));
              u_xlatb33 = (u_xlat33.x<0);
              u_xlat15 = (int(u_xlatb33))?(u_xlat11):(u_xlat15);
              u_xlat13 = (int(u_xlatb12))?(u_xlat15):(u_xlat16);
              u_xlat12.x = (u_xlat13.w + (-0.5));
              u_xlatb12 = (u_xlat12.x<0);
              if(((int(u_xlatb12) * int(4294967295))!=0))
              {
                  discard;
              }
              u_xlati_loop_1 = (u_xlati_loop_1 + 1);
          }
          u_xlat0_d.x = (u_xlat13.w + (-0.5));
          u_xlatb0 = (u_xlat0_d.x<0);
          if(((int(u_xlatb0) * int(4294967295))!=0))
          {
              discard;
          }
          u_xlat0_d.x = (_BurnProgress * _BurnProgressInfluence);
          u_xlat21.x = (u_xlat0_d.x * u_xlat6.y);
          u_xlat21.x = (u_xlat21.x * 7);
          u_xlat21.x = clamp(u_xlat21.x, 0, 1);
          u_xlat42 = ((u_xlat21.x * (-2)) + 3);
          u_xlat21.x = (u_xlat21.x * u_xlat21.x);
          u_xlat63 = (u_xlat4.x * 0.0500000007);
          u_xlat21.x = ((u_xlat42 * u_xlat21.x) + (-u_xlat63));
          u_xlat21.x = clamp(u_xlat21.x, 0, 1);
          u_xlat1_d.x = (u_xlat0_d.x * 3.33333325);
          u_xlat42 = (((-u_xlat0_d.x) * 1.20000005) + 1);
          u_xlat42 = (((-u_xlat4.z) * 0.5) + u_xlat42);
          u_xlat5.xyz = ((u_xlat2.xyz * float3(u_xlat42, u_xlat42, u_xlat42)) + (-u_xlat2.xyz));
          u_xlat5.w = 0;
          u_xlat2 = ((u_xlat21.xxxx * u_xlat5) + u_xlat2);
          u_xlatb0 = (u_xlat0_d.x>=0.99000001);
          u_xlat42 = ((_BurnProgress * _BurnProgressInfluence) + (-0.400000006));
          u_xlat42 = (u_xlat42 * 1.24999988);
          u_xlat42 = clamp(u_xlat42, 0, 1);
          u_xlat63 = ((u_xlat42 * (-2)) + 3);
          u_xlat42 = (u_xlat42 * u_xlat42);
          u_xlat42 = (u_xlat42 * u_xlat63);
          u_xlat22.xy = ((-u_xlat4.zw) + float2(1, 1));
          u_xlatb42 = (u_xlat22.x<u_xlat42);
          u_xlatb0 = (u_xlatb42 || u_xlatb0);
          u_xlat5.xyz = ((u_xlat4.xxx * u_xlat8.xyz) + _BloodColor.xyz);
          u_xlat5.xyz = (u_xlat3.xyz * u_xlat5.xyz);
          u_xlat5.xyz = (u_xlat5.xyz * float3(0.100000001, 0.100000001, 0.100000001));
          u_xlat42 = ((-u_xlat21.x) + 1);
          u_xlat13.xyz = (float3(u_xlat42, u_xlat42, u_xlat42) * u_xlat13.xyz);
          u_xlat1_d.x = u_xlat1_d.x;
          u_xlat1_d.x = clamp(u_xlat1_d.x, 0, 1);
          u_xlat42 = ((u_xlat1_d.x * (-2)) + 3);
          u_xlat63 = (u_xlat1_d.x * u_xlat1_d.x);
          u_xlat42 = (u_xlat63 * u_xlat42);
          u_xlat42 = (u_xlat42 * 0.800000012);
          u_xlat7 = ((u_xlat13 * _BloodColor) + (-u_xlat13));
          u_xlat7 = ((float4(u_xlat42, u_xlat42, u_xlat42, u_xlat42) * u_xlat7) + u_xlat13);
          u_xlatb21 = (0.800000012<u_xlat21.x);
          u_xlat21.x = (u_xlatb21)?(1):(float(0));
          u_xlat8 = (u_xlat2 + (-u_xlat7));
          u_xlat7 = ((u_xlat21.xxxx * u_xlat8.wxyz) + u_xlat7.wxyz);
          u_xlat8.xyz = (int(u_xlatb0))?(u_xlat5.xyz):(u_xlat7.yzw);
          u_xlat5.w = u_xlat3.w;
          u_xlat7.yzw = u_xlat3.xyz;
          u_xlat0_d = (int(u_xlatb0))?(u_xlat5.wxyz):(u_xlat7);
          u_xlat0_d.x = (u_xlat0_d.x + (-0.5));
          u_xlatb0 = (u_xlat0_d.x<0);
          if(((int(u_xlatb0) * int(4294967295))!=0))
          {
              discard;
          }
          u_xlat1_d.xy = float2((float2(_AcidProgress, _Temperature) * float2(_AcidProgress, _Temperature)));
          u_xlat0_d.x = (u_xlat1_d.x * u_xlat1_d.x);
          u_xlat1_d.x = (_AcidProgress * 0.200000003);
          u_xlat0_d.x = max(u_xlat0_d.x, u_xlat1_d.x);
          u_xlat0_d.x = clamp(u_xlat0_d.x, 0, 1);
          u_xlat3.xyz = (u_xlat4.www * _BloodColor.xyz);
          u_xlat3.xyz = (u_xlat3.xyz * float3(0.5, 0.5, 0.5));
          u_xlat3.xyz = min(u_xlat0_d.yzw, u_xlat3.xyz);
          u_xlat1_d.x = (u_xlat0_d.x * u_xlat6.x);
          u_xlat1_d.x = (u_xlat1_d.x * 12);
          u_xlat1_d.x = clamp(u_xlat1_d.x, 0, 1);
          u_xlat1_d.x = (u_xlat1_d.x * 0.899999976);
          u_xlat3.xyz = ((-u_xlat0_d.yzw) + u_xlat3.xyz);
          u_xlat21.xyz = ((u_xlat1_d.xxx * u_xlat3.xyz) + u_xlat0_d.yzw);
          u_xlat1_d.x = (((-_BurnProgress) * _BurnProgressInfluence) + 1);
          u_xlat5.xyz = (u_xlat21.xyz * u_xlat1_d.xxx);
          u_xlat21.xy = (float2(1, 1) / u_xlat4.wx);
          u_xlat0_d.x = (u_xlat21.x * u_xlat0_d.x);
          u_xlat0_d.x = clamp(u_xlat0_d.x, 0, 1);
          u_xlat21.x = ((u_xlat0_d.x * (-2)) + 3);
          u_xlat0_d.x = (u_xlat0_d.x * u_xlat0_d.x);
          u_xlat0_d.x = (u_xlat0_d.x * u_xlat21.x);
          u_xlat0_d.x = min(u_xlat0_d.x, 1);
          u_xlat8.w = 1;
          u_xlat21.x = (u_xlat21.y * u_xlat0_d.x);
          u_xlat21.x = clamp(u_xlat21.x, 0, 1);
          u_xlat42 = ((u_xlat21.x * (-2)) + 3);
          u_xlat21.x = (u_xlat21.x * u_xlat21.x);
          u_xlat21.x = (u_xlat21.x * u_xlat42);
          u_xlat21.x = dot(u_xlat21.xx, u_xlat4.zz);
          u_xlat21.x = clamp(u_xlat21.x, 0, 1);
          u_xlat6 = ((u_xlat8 * _SecondBruiseColor) + (-u_xlat8));
          u_xlat6 = ((u_xlat21.xxxx * u_xlat6) + u_xlat8);
          u_xlat21.x = ((u_xlat0_d.x * u_xlat0_d.x) + (-0.899999976));
          u_xlat21.x = (u_xlat21.x * 9.99999809);
          u_xlat21.x = max(u_xlat21.x, 0);
          u_xlat42 = ((u_xlat21.x * (-2)) + 3);
          u_xlat21.x = (u_xlat21.x * u_xlat21.x);
          u_xlat21.x = (u_xlat21.x * u_xlat42);
          u_xlat5 = ((-u_xlat2) + u_xlat5);
          u_xlat2 = ((u_xlat21.xxxx * u_xlat5) + u_xlat2);
          u_xlat0_d.x = (u_xlat0_d.x + (-0.300000012));
          u_xlat0_d.x = (u_xlat0_d.x * 3.33333325);
          u_xlat0_d.x = clamp(u_xlat0_d.x, 0, 1);
          u_xlat21.x = ((u_xlat0_d.x * (-2)) + 3);
          u_xlat0_d.x = (u_xlat0_d.x * u_xlat0_d.x);
          u_xlat0_d.x = (u_xlat0_d.x * u_xlat21.x);
          u_xlat2 = ((-u_xlat6) + u_xlat2);
          u_xlat0_d = ((u_xlat0_d.xxxx * u_xlat2) + u_xlat6);
          u_xlat63 = (u_xlat0_d.w + (-0.5));
          u_xlatb63 = (u_xlat63<0);
          if(((int(u_xlatb63) * int(4294967295))!=0))
          {
              discard;
          }
          u_xlat63 = (((-_RottenProgress) * 0.25) + u_xlat22.y);
          u_xlat63 = (u_xlat63 + (-_RottenProgress));
          u_xlat1_d.x = (float(1) / (-_RottenProgress));
          u_xlat63 = (u_xlat63 * u_xlat1_d.x);
          u_xlat63 = clamp(u_xlat63, 0, 1);
          u_xlat1_d.x = ((u_xlat63 * (-2)) + 3);
          u_xlat63 = (u_xlat63 * u_xlat63);
          u_xlat63 = ((u_xlat1_d.x * u_xlat63) + _RottenProgress);
          u_xlat63 = clamp(u_xlat63, 0, 1);
          u_xlat1_d.xzw = (u_xlat10.yyy * _Zombie.xyz);
          u_xlat1_d.xzw = ((u_xlat1_d.xzw * float3(0.5, 0.5, 0.5)) + float3(-1, (-1), (-1)));
          u_xlat1_d.xzw = ((float3(u_xlat63, u_xlat63, u_xlat63) * u_xlat1_d.xzw) + float3(1, 1, 1));
          u_xlat2.xyz = (u_xlat0_d.xyz * u_xlat1_d.xzw);
          u_xlat0_d.x = (u_xlat2.y + u_xlat2.x);
          u_xlat0_d.x = ((u_xlat0_d.z * u_xlat1_d.w) + u_xlat0_d.x);
          u_xlat21.x = (u_xlat4.z * u_xlat63);
          u_xlat21.x = ((u_xlat21.x * 0.800000012) + (-0.400000006));
          u_xlat21.x = (u_xlat21.x * 20.0000076);
          u_xlat21.x = clamp(u_xlat21.x, 0, 1);
          u_xlat42 = ((u_xlat21.x * (-2)) + 3);
          u_xlat21.x = (u_xlat21.x * u_xlat21.x);
          u_xlat21.x = (u_xlat21.x * u_xlat42);
          u_xlat21.x = (u_xlat21.x * 0.5);
          u_xlat0_d.xzw = ((u_xlat0_d.xxx * float3(0.333333343, 0.333333343, 0.333333343)) + (-u_xlat2.xyz));
          u_xlat0_d.xyz = ((u_xlat21.xxx * u_xlat0_d.xzw) + u_xlat2.xyz);
          u_xlat0_d.xyz = clamp(u_xlat0_d.xyz, 0, 1);
          u_xlat63 = (_Time.z + _Time.z);
          u_xlatb63 = (u_xlat63>=(-u_xlat63));
          u_xlat1_d.xz = (int(u_xlatb63))?(float2(2, 0.5)):(float2(-2, (-0.5)));
          u_xlat63 = (u_xlat1_d.z * _Time.z);
          u_xlat63 = frac(u_xlat63);
          u_xlat63 = (u_xlat63 * u_xlat1_d.x);
          u_xlat63 = (u_xlat63 * 0.103100002);
          u_xlat63 = frac(u_xlat63);
          u_xlat1_d.x = (u_xlat63 + 33.3300018);
          u_xlat63 = (u_xlat63 * u_xlat1_d.x);
          u_xlat1_d.x = (u_xlat63 + u_xlat63);
          u_xlat63 = (u_xlat63 * u_xlat1_d.x);
          u_xlat63 = frac(u_xlat63);
          u_xlat63 = (u_xlat63 * _ElectrocutionIntensity);
          u_xlat1_d.x = (_Time.x * 5);
          u_xlatb1 = (u_xlat1_d.x>=(-u_xlat1_d.x));
          u_xlat1_d.xz = (int(u_xlatb1))?(float2(5, 0.200000003)):(float2(-5, (-0.200000003)));
          u_xlat43 = (u_xlat1_d.z * _Time.x);
          u_xlat43 = frac(u_xlat43);
          u_xlat1_d.x = (u_xlat43 * u_xlat1_d.x);
          u_xlat1_d.x = (u_xlat1_d.x * 0.103100002);
          u_xlat1_d.x = frac(u_xlat1_d.x);
          u_xlat43 = (u_xlat1_d.x + 33.3300018);
          u_xlat1_d.x = (u_xlat43 * u_xlat1_d.x);
          u_xlat43 = (u_xlat1_d.x + u_xlat1_d.x);
          u_xlat1_d.x = (u_xlat43 * u_xlat1_d.x);
          u_xlat1_d.x = frac(u_xlat1_d.x);
          u_xlatb63 = (u_xlat1_d.x<u_xlat63);
          u_xlat63 = (u_xlatb63)?(1):(float(0));
          u_xlat63 = (u_xlat3.w * u_xlat63);
          u_xlat0_d.xyz = ((float3(u_xlat63, u_xlat63, u_xlat63) * _ElectroBoneColour.xyz) + u_xlat0_d.xyz);
          u_xlat0_d.xyz = clamp(u_xlat0_d.xyz, 0, 1);
          u_xlatb63 = (0<_Temperature);
          u_xlat1_d.x = min(u_xlat1_d.y, 1);
          u_xlat22.xyz = ((u_xlat0_d.xyz * _GlowColour.xyz) + (-u_xlat0_d.xyz));
          u_xlat1_d.xyz = ((u_xlat1_d.xxx * u_xlat22.xyz) + u_xlat0_d.xyz);
          u_xlat1_d.xyz = max(u_xlat1_d.xyz, float3(0, 0, 0));
          u_xlat64 = (-_Temperature);
          u_xlat64 = clamp(u_xlat64, 0, 1);
          u_xlat2.xyz = ((u_xlat0_d.xyz * _FreezeColour.xyz) + (-u_xlat0_d.xyz));
          u_xlat0_d.xyz = ((float3(u_xlat64, u_xlat64, u_xlat64) * u_xlat2.xyz) + u_xlat0_d.xyz);
          u_xlat0_d.xyz = max(u_xlat0_d.xyz, float3(0, 0, 0));
          u_xlat0_d.xyz = (int(u_xlatb63))?(u_xlat1_d.xyz):(u_xlat0_d.xyz);
          u_xlat0_d.w = 1;
          out_f.color = (u_xlat0_d * in_f.color);
          //return xy;
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
