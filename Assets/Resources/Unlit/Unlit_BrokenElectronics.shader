Shader "Unlit/BrokenElectronics"
{
  Properties
  {
    [PerRendererData] _MainTex ("Texture", 2D) = "white" {}
    _DamageMap ("DamageMap", 2D) = "white" {}
    _BrokenElectronics ("Texture Behind Damage", 2D) = "white" {}
    _Progress ("Heat", Range(0, 1)) = 0
    [HDR] _GlowColour ("Glow Colour", Color) = (1,0,1,1)
    [PerRendererData] _Offset ("Offset", Vector) = (0,0,0,0)
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
      
      
      #define CODE_BLOCK_VERTEX
      //uniform float4x4 unity_ObjectToWorld;
      //uniform float4x4 unity_MatrixVP;
      uniform float4 _GlowColour;
      uniform float2 _Offset;
      uniform float _Progress;
      uniform sampler2D _BrokenElectronics;
      uniform sampler2D _DamageMap;
      uniform sampler2D _MainTex;
      struct appdata_t
      {
          float4 vertex :POSITION0;
          float2 texcoord :TEXCOORD0;
      };
      
      struct OUT_Data_Vert
      {
          float2 texcoord :TEXCOORD0;
          float2 texcoord1 :TEXCOORD1;
          float4 vertex :SV_POSITION;
      };
      
      struct v2f
      {
          float2 texcoord :TEXCOORD0;
          float2 texcoord1 :TEXCOORD1;
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
          out_v.texcoord1.xy = (in_v.vertex.xy * float2(0.5, 0.5));
          out_v.vertex = UnityObjectToClipPos(in_v.vertex);
          return out_v;
      }
      
      #define CODE_BLOCK_FRAGMENT
      float4 u_xlat0_d;
      float4 u_xlat1_d;
      float2 u_xlatb1;
      float4 u_xlat2;
      float4 u_xlat3;
      float4 u_xlat4;
      float3 u_xlat6;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlat0_d.xy = (in_f.texcoord1.xy + _Offset.xy);
          u_xlat1_d = tex2D(_DamageMap, u_xlat0_d.xy);
          u_xlat0_d = tex2D(_BrokenElectronics, u_xlat0_d.xy);
          u_xlat6.xz = ((u_xlat1_d.xz * float2(0.00999999978, 0.00999999978)) + in_f.texcoord.xy);
          u_xlat2 = tex2D(_MainTex, u_xlat6.xz);
          u_xlat3.xyz = (u_xlat2.xyz * _GlowColour.xyz);
          u_xlat3.xyz = ((u_xlat3.xyz * float3(float3(_Progress, _Progress, _Progress))) + (-u_xlat2.xyz));
          u_xlat2.xyz = ((float3(float3(_Progress, _Progress, _Progress)) * u_xlat3.xyz) + u_xlat2.xyz);
          u_xlat6.x = (u_xlat2.y + u_xlat2.x);
          u_xlat6.x = (u_xlat2.z + u_xlat6.x);
          u_xlat3.xyz = ((u_xlat6.xxx * float3(0.200000003, 0.200000003, 0.200000003)) + (-u_xlat2.xyz));
          u_xlatb1.xy = bool4(float4(0.100000001, 0.200000003, 0, 0) < u_xlat1_d.xxxx).xy;
          u_xlat1_d.x = (u_xlatb1.x)?(1):(float(0));
          u_xlat3.xyz = ((u_xlat1_d.xxx * u_xlat3.xyz) + u_xlat2.xyz);
          u_xlat4 = max(u_xlat2, float4(0.300000012, 0.300000012, 0.300000012, 0.300000012));
          u_xlat0_d.w = u_xlat2.w;
          u_xlat2 = min(u_xlat4, float4(1, 1, 1, 1));
          u_xlat2 = (u_xlat0_d * u_xlat2);
          u_xlat3.w = u_xlat0_d.w;
          u_xlat0_d.x = 0;
          u_xlat0_d.w = u_xlat3.w;
          u_xlat0_d = ((-u_xlat3) + u_xlat0_d.xxxw);
          u_xlat0_d = ((u_xlat1_d.zzzz * u_xlat0_d) + u_xlat3);
          out_f.color = (u_xlatb1.y)?(u_xlat2):(u_xlat0_d);
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
