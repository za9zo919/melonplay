Shader "Jaap/LegacyBodyShader"
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
      uniform int _DamagePointCount;
      uniform float _BurnProgress;
      uniform float _AcidProgress;
      uniform float _Temperature;
      uniform float _BurnProgressInfluence;
      uniform float _ElectrocutionIntensity;
      uniform float _RottenProgress;
      uniform float _DamageMultiplier;
      uniform sampler2D _MainTex;
      uniform sampler2D _DamageTex;
      uniform sampler2D _FleshTex;
      uniform sampler2D _BoneTex;
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
      float4 ImmCB_0[6];
      float4 u_xlat0_d;
      float4 u_xlat1_d;
      int u_xlatb1;
      float4 u_xlat2;
      float4 u_xlatb2;
      float4 u_xlat3;
      float4 u_xlat4;
      float4 u_xlat5;
      float4 u_xlat6;
      float4 u_xlat7;
      int u_xlatb7;
      float4 u_xlat8;
      float3 u_xlat10;
      int u_xlatb10;
      float3 u_xlat11;
      int u_xlatb11;
      float3 u_xlat12;
      float u_xlat19;
      int u_xlati19;
      int u_xlatb19;
      float u_xlat28;
      int u_xlatb28;
      float u_xlat29;
      int u_xlati29;
      int u_xlatb29;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          ImmCB_0[0] = float4(0.699999988, 1, 0, 0);
          ImmCB_0[1] = float4(0.150000006, 0.449999988, 0, 0);
          ImmCB_0[2] = float4(0.00999999978, 0.300000012, 0, 0);
          ImmCB_0[3] = float4(0.0500000007, 0.449999988, 0, 0);
          ImmCB_0[4] = float4(1, 1, 0, 0);
          ImmCB_0[5] = float4(1, 1, 0, 0);
          u_xlat0_d = tex2D(_MainTex, in_f.texcoord.xy);
          u_xlat1_d.x = (u_xlat0_d.w + (-0.00999999978));
          u_xlatb1 = (u_xlat1_d.x<0);
          if(((int(u_xlatb1) * int(4294967295))!=0))
          {
              discard;
          }
          u_xlat1_d.x = log2(_BurnProgress);
          u_xlat1_d.x = (u_xlat1_d.x * 0.300000012);
          u_xlat1_d.x = exp2(u_xlat1_d.x);
          u_xlat1_d.x = (u_xlat1_d.x * _BurnProgressInfluence);
          u_xlat1_d.x = (u_xlat1_d.x * 0.879999995);
          u_xlat1_d.x = clamp(u_xlat1_d.x, 0, 1);
          u_xlat10.x = (u_xlat1_d.x + _AcidProgress);
          u_xlatb10 = (u_xlat10.x<0.00999999978);
          u_xlat2.xy = in_f.texcoord1.xy;
          u_xlat2.z = 0;
          u_xlat2.xyz = (u_xlat2.xyz * float3(35, 35, 35));
          u_xlat2.xyz = round(u_xlat2.xyz);
          u_xlat2.xyz = (u_xlat2.xyz / float3(35, 35, 35));
          u_xlat28 = float(10000);
          int u_xlati_loop_1 = int(0);
          while((u_xlati_loop_1<_DamagePointCount))
          {
              u_xlati29 = int(_DamagePoints[u_xlati_loop_1].w);
              u_xlat3.x = (ImmCB_0[u_xlati29].x / _DamagePoints[u_xlati_loop_1].z);
              float _tmp_dvx_1 = (-_DamagePoints[u_xlati_loop_1]);
              u_xlat4.xy = float2(_tmp_dvx_1, _tmp_dvx_1);
              u_xlat4.z = (-u_xlat3.x);
              u_xlat3.xyz = (u_xlat2.xyz + u_xlat4.xyz);
              u_xlat3.x = length(u_xlat3.xyz);
              u_xlat3.x = log2(u_xlat3.x);
              u_xlat29 = (u_xlat3.x * ImmCB_0[u_xlati29].y);
              u_xlat29 = exp2(u_xlat29);
              u_xlat28 = min(u_xlat28, u_xlat29);
              u_xlati_loop_1 = (u_xlati_loop_1 + 1);
          }
          u_xlat19 = max(_DamageMultiplier, 0.100000001);
          u_xlat19 = (u_xlat28 / u_xlat19);
          u_xlatb28 = (0.699999988<u_xlat19);
          u_xlatb10 = (u_xlatb10 && u_xlatb28);
          u_xlatb28 = (0.00999999978>=_RottenProgress);
          u_xlatb10 = (u_xlatb28 && u_xlatb10);
          if(u_xlatb10)
          {
              u_xlat2 = (u_xlat0_d * in_f.color);
              u_xlat2.xyz = u_xlat2.xyz;
              u_xlat2.xyz = clamp(u_xlat2.xyz, 0, 1);
              u_xlatb10 = (0<_Temperature);
              u_xlat28 = (_Temperature * _Temperature);
              u_xlat28 = min(u_xlat28, 1);
              u_xlat3.xyz = ((u_xlat2.xyz * _GlowColour.xyz) + (-u_xlat2.xyz));
              u_xlat3.xyz = ((float3(u_xlat28, u_xlat28, u_xlat28) * u_xlat3.xyz) + u_xlat2.xyz);
              u_xlat3.xyz = max(u_xlat3.xyz, float3(0, 0, 0));
              u_xlat28 = (-_Temperature);
              u_xlat28 = clamp(u_xlat28, 0, 1);
              u_xlat4.xyz = ((u_xlat2.xyz * _FreezeColour.xyz) + (-u_xlat2.xyz));
              u_xlat2.xyz = ((float3(u_xlat28, u_xlat28, u_xlat28) * u_xlat4.xyz) + u_xlat2.xyz);
              u_xlat2.xyz = max(u_xlat2.xyz, float3(0, 0, 0));
              out_f.color.xyz = (int(u_xlatb10))?(u_xlat3.xyz):(u_xlat2.xyz);
              out_f.color.w = u_xlat2.w;
              //return xy;
              return out_f;
          }
          u_xlat2 = tex2D(_DamageTex, in_f.texcoord.xy);
          u_xlat10.x = (u_xlat2.x * _DamageMultiplier);
          u_xlat3 = tex2D(_FleshTex, in_f.texcoord.xy);
          u_xlat4 = tex2D(_BoneTex, in_f.texcoord.xy);
          u_xlat28 = (u_xlat2.x + u_xlat2.x);
          u_xlat29 = ((u_xlat2.x * 2) + (-1));
          u_xlat19 = ((u_xlat29 * 0.100000001) + u_xlat19);
          u_xlat29 = ((-u_xlat1_d.x) + 1);
          u_xlat19 = min(u_xlat19, u_xlat29);
          u_xlat29 = log2(_AcidProgress);
          u_xlat29 = (u_xlat29 * 0.699999988);
          u_xlat29 = exp2(u_xlat29);
          u_xlat29 = ((-u_xlat29) + 1);
          u_xlat19 = min(u_xlat19, u_xlat29);
          u_xlat5.xyz = float3(((-float3(u_xlat19, u_xlat19, u_xlat19)) + float3(0.25, 0.400000006, 1)));
          u_xlat29 = (float(1) / u_xlat5.x);
          u_xlat29 = (u_xlat29 * u_xlat5.y);
          u_xlat29 = clamp(u_xlat29, 0, 1);
          u_xlat5.x = ((u_xlat29 * (-2)) + 3);
          u_xlat29 = (u_xlat29 * u_xlat29);
          u_xlat29 = (u_xlat29 * u_xlat5.x);
          u_xlat5.x = ((-u_xlat2.y) + u_xlat2.x);
          u_xlat11.x = ((u_xlat5.x * 0.699999988) + u_xlat2.y);
          u_xlat6.xyz = _BruiseColor.xyz;
          u_xlat6.w = u_xlat0_d.w;
          u_xlat7.xyz = ((-u_xlat6.xyz) + _SecondBruiseColor.xyz);
          u_xlat7.w = 0;
          u_xlat7 = ((u_xlat11.xxxx * u_xlat7) + u_xlat6);
          u_xlat8.xyz = ((-u_xlat7.xyz) + _ThirdBruiseColor.xyz);
          u_xlat8.w = (u_xlat0_d.w + (-u_xlat7.w));
          u_xlat7 = ((float4(u_xlat29, u_xlat29, u_xlat29, u_xlat29) * u_xlat8) + u_xlat7);
          u_xlat6.xyz = _BloodColor.xyz;
          u_xlat5.x = float(0.100000001);
          u_xlat5.y = float(0);
          u_xlat5.w = u_xlat6.w;
          u_xlat8 = ((-u_xlat6) + u_xlat5.xyyw);
          u_xlat6 = ((float4(float4(_RottenProgress, _RottenProgress, _RottenProgress, _RottenProgress)) * u_xlat8) + u_xlat6);
          u_xlat8 = ((float4(float4(_RottenProgress, _RottenProgress, _RottenProgress, _RottenProgress)) * float4(-0.899999976, (-1), (-1), 0)) + float4(1, 1, 1, 1));
          u_xlat3 = (u_xlat3 * u_xlat8);
          u_xlat5.x = float(0.0500000007);
          u_xlat5.y = float(0);
          u_xlat5.w = u_xlat7.w;
          u_xlat8 = ((-u_xlat7) + u_xlat5.xyyw);
          u_xlat7 = ((float4(float4(_RottenProgress, _RottenProgress, _RottenProgress, _RottenProgress)) * u_xlat8) + u_xlat7);
          u_xlat11.x = (float(1) / (-u_xlat19));
          u_xlat11.x = (u_xlat11.x * u_xlat5.z);
          u_xlat11.x = clamp(u_xlat11.x, 0, 1);
          u_xlat29 = ((u_xlat11.x * (-2)) + 3);
          u_xlat11.x = (u_xlat11.x * u_xlat11.x);
          u_xlat11.x = (u_xlat11.x * u_xlat29);
          u_xlat5 = (u_xlat6 + (-u_xlat7));
          u_xlat5 = ((u_xlat11.xxxx * u_xlat5) + u_xlat7);
          u_xlat11.xz = (float2(u_xlat19, u_xlat19) * float2(0.899999976, 1.5));
          u_xlat7.x = ((u_xlat10.x * 0.400000006) + 0.400000006);
          u_xlatb11 = (u_xlat11.x<u_xlat7.x);
          u_xlatb7 = (0.460000008<u_xlat19);
          u_xlat28 = (u_xlatb7)?(u_xlat28):(u_xlat10.x);
          u_xlat7.x = (u_xlat19 + 0.550000012);
          u_xlat28 = ((u_xlat28 * u_xlat7.x) + (-_BruiseColor.w));
          u_xlat28 = (u_xlat28 + 1);
          u_xlat28 = clamp(u_xlat28, 0, 1);
          u_xlat7 = (u_xlat0_d + (-u_xlat5));
          u_xlat5 = ((float4(u_xlat28, u_xlat28, u_xlat28, u_xlat28) * u_xlat7) + u_xlat5);
          u_xlat0_d = (int(u_xlatb11))?(u_xlat5):(u_xlat0_d);
          u_xlatb19 = (u_xlat19<u_xlat10.x);
          u_xlatb10 = (u_xlat11.z<u_xlat10.x);
          u_xlat5 = ((-u_xlat6) + float4(1, 1, 1, 1));
          u_xlat5 = ((u_xlat2.xxxx * u_xlat5) + u_xlat6);
          u_xlat5 = (u_xlat4 * u_xlat5);
          u_xlat3 = (int(u_xlatb10))?(u_xlat5):(u_xlat3);
          u_xlat0_d = (int(u_xlatb19))?(u_xlat3):(u_xlat0_d);
          u_xlatb10 = (u_xlat2.z<u_xlat1_d.x);
          u_xlatb19 = (0<u_xlat0_d.w);
          u_xlatb10 = (u_xlatb19 && u_xlatb10);
          u_xlat1_d.x = (u_xlat1_d.x * 0.100000001);
          u_xlat1_d.xzw = ((u_xlat2.zzz * float3(0.419999987, 0.400000006, 0.400000006)) + (-u_xlat1_d.xxx));
          u_xlat1_d.xzw = (u_xlat0_d.xyz * u_xlat1_d.xzw);
          u_xlat0_d.xyz = (int(u_xlatb10))?(u_xlat1_d.xzw):(u_xlat0_d.xyz);
          u_xlat1_d.x = (u_xlat2.z * _RottenProgress);
          u_xlat2 = ((u_xlat0_d * _Zombie) + (-u_xlat0_d));
          u_xlat0_d = ((u_xlat1_d.xxxx * u_xlat2) + u_xlat0_d);
          u_xlat1_d.x = (((-_RottenProgress) * 0.5) + 1);
          u_xlat0_d.xyz = (u_xlat0_d.xyz * u_xlat1_d.xxx);
          u_xlat1_d.x = (u_xlat4.w * u_xlat0_d.w);
          u_xlat1_d.x = (u_xlat1_d.x * _ElectrocutionIntensity);
          u_xlat2 = (_Time.zzxx * float4(5, 5, 5, 5));
          u_xlatb2 = bool4(u_xlat2 >= (-u_xlat2.yyww));
          u_xlat2.x = (u_xlatb2.x)?(float(5)):(float(-5));
          u_xlat2.y = (u_xlatb2.y)?(float(0.200000003)):(float(-0.200000003));
          u_xlat2.z = (u_xlatb2.z)?(float(5)):(float(-5));
          u_xlat2.w = (u_xlatb2.w)?(float(0.200000003)):(float(-0.200000003));
          u_xlat10.xy = (u_xlat2.yw * _Time.zx);
          u_xlat10.xy = frac(u_xlat10.xy);
          u_xlat10.xy = (u_xlat10.xy * u_xlat2.xz);
          u_xlat10.xy = (u_xlat10.xy * float2(0.103100002, 0.103100002));
          u_xlat10.xy = frac(u_xlat10.xy);
          u_xlat2.xy = (u_xlat10.xy + float2(33.3300018, 33.3300018));
          u_xlat10.xy = (u_xlat10.xy * u_xlat2.xy);
          u_xlat2.xy = (u_xlat10.xy + u_xlat10.xy);
          u_xlat10.xy = (u_xlat10.xy * u_xlat2.xy);
          u_xlat10.xy = frac(u_xlat10.xy);
          u_xlat1_d.x = (u_xlat10.x * u_xlat1_d.x);
          u_xlatb1 = (u_xlat10.y<u_xlat1_d.x);
          u_xlat1_d.x = (u_xlatb1)?(1):(float(0));
          u_xlat2 = ((-u_xlat0_d) + _ElectroBoneColour);
          u_xlat0_d = ((u_xlat1_d.xxxx * u_xlat2) + u_xlat0_d);
          u_xlatb1 = (0.00999999978<abs(_Temperature));
          u_xlat10.xyz = u_xlat0_d.xyz;
          u_xlat10.xyz = clamp(u_xlat10.xyz, 0, 1);
          u_xlatb2.x = (0<_Temperature);
          u_xlat11.x = (_Temperature * _Temperature);
          u_xlat11.x = min(u_xlat11.x, 1);
          u_xlat3.xyz = ((u_xlat10.xyz * _GlowColour.xyz) + (-u_xlat10.xyz));
          u_xlat11.xyz = ((u_xlat11.xxx * u_xlat3.xyz) + u_xlat10.xyz);
          u_xlat11.xyz = max(u_xlat11.xyz, float3(0, 0, 0));
          u_xlat3.x = (-_Temperature);
          u_xlat3.x = clamp(u_xlat3.x, 0, 1);
          u_xlat12.xyz = ((u_xlat10.xyz * _FreezeColour.xyz) + (-u_xlat10.xyz));
          u_xlat10.xyz = ((u_xlat3.xxx * u_xlat12.xyz) + u_xlat10.xyz);
          u_xlat10.xyz = max(u_xlat10.xyz, float3(0, 0, 0));
          u_xlat10.xyz = (u_xlatb2.x)?(u_xlat11.xyz):(u_xlat10.xyz);
          u_xlat0_d.xyz = (int(u_xlatb1))?(u_xlat10.xyz):(u_xlat0_d.xyz);
          out_f.color = (u_xlat0_d * in_f.color);
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
