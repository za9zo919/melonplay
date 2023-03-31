Shader "Unlit/SnowOverlay"
{
  Properties
  {
    _MainTex ("Texture", 2D) = "white" {}
    _Noise ("Noise", 2D) = "white" {}
    _SnowDirection ("Snow Direction", Vector) = (0,1,0,0)
    _NoiseDirection ("Noise Direction", Vector) = (1,0,0,0)
    _Intensity ("Intensity", float) = 1
    _Tiling ("Snow Tiling", float) = 1
    _TilingN ("Noise Tiling", float) = 1
    _BlackIsAlpha ("Black is Alpha", Range(0, 1)) = 0
    _Visibility ("Visibility", Range(0, 4)) = 1
    _Density ("Density", Range(0, 1)) = 1
    [HDR] _Tint ("Tint", Color) = (1,0,1,1)
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
      //uniform float4 _Time;
      uniform float4 _Tint;
      uniform float _Tiling;
      uniform float _TilingN;
      uniform float2 _SnowDirection;
      uniform float2 _NoiseDirection;
      uniform float _Intensity;
      uniform float _BlackIsAlpha;
      uniform float _Visibility;
      uniform float _Density;
      uniform sampler2D _Noise;
      uniform sampler2D _MainTex;
      struct appdata_t
      {
          float4 vertex :POSITION0;
          float2 texcoord :TEXCOORD0;
      };
      
      struct OUT_Data_Vert
      {
          float2 texcoord :TEXCOORD0;
          float2 texcoord2 :TEXCOORD2;
          float3 texcoord1 :TEXCOORD1;
          float4 vertex :SV_POSITION;
      };
      
      struct v2f
      {
          float2 texcoord :TEXCOORD0;
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
          u_xlat1.xyz = ((conv_mxt4x4_3(unity_ObjectToWorld).xyz * in_v.vertex.www) + u_xlat0.xyz);
          u_xlat0 = (u_xlat0 + conv_mxt4x4_3(unity_ObjectToWorld));
          out_v.texcoord.xy = u_xlat1.xy;
          out_v.texcoord1.xyz = u_xlat1.xyz;
          out_v.texcoord2.xy = in_v.texcoord.xy;
          out_v.vertex = mul(unity_MatrixVP, u_xlat0);
          return out_v;
      }
      
      #define CODE_BLOCK_FRAGMENT
      float4 u_xlat0_d;
      int u_xlatb0;
      float4 u_xlat1_d;
      float4 u_xlat2;
      int u_xlatb4;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlat0_d = (in_f.texcoord.xyxy * float4(_TilingN, _TilingN, _Tiling, _Tiling));
          u_xlat0_d.xy = ((_Time.xx * _NoiseDirection.xy) + u_xlat0_d.xy);
          u_xlat1_d = tex2D(_Noise, u_xlat0_d.xy);
          u_xlat0_d.xy = ((_Time.xx * float2(_SnowDirection.x, _SnowDirection.y)) + u_xlat0_d.zw);
          u_xlat0_d.xy = (((-u_xlat1_d.xz) * float2(float2(_Intensity, _Intensity))) + u_xlat0_d.xy);
          u_xlat2 = tex2D(_MainTex, u_xlat0_d.xy);
          u_xlatb0 = (0.5<_Density);
          u_xlat2 = (int(u_xlatb0))?(u_xlat2):(float4(0, 0, 0, 0));
          u_xlat0_d.x = ((_Density * 2) + (-1));
          u_xlat2.w = (u_xlat0_d.x * u_xlat2.w);
          u_xlat0_d.x = ((_Time.x * 0.5) + 5);
          u_xlat0_d.xy = ((u_xlat0_d.xx * float2(_SnowDirection.x, _SnowDirection.y)) + u_xlat0_d.zw);
          u_xlat0_d.xy = (((-u_xlat1_d.zx) * float2(float2(_Intensity, _Intensity))) + u_xlat0_d.xy);
          u_xlat0_d = tex2D(_MainTex, u_xlat0_d.xy);
          u_xlat0_d.w = (u_xlat0_d.w * _Density);
          u_xlat0_d = (u_xlat2 + u_xlat0_d);
          u_xlat0_d = (u_xlat0_d * float4(_Visibility, _Visibility, _Visibility, _Visibility));
          u_xlat0_d = clamp(u_xlat0_d, 0, 1);
          u_xlat0_d = (u_xlat0_d * _Tint);
          u_xlat1_d.x = length(u_xlat0_d.xyz);
          u_xlat1_d.x = (u_xlat1_d.x * 0.100000001);
          u_xlatb4 = (0.5<_BlackIsAlpha);
          u_xlat1_d.x = (u_xlatb4)?(u_xlat1_d.x):(1);
          u_xlat1_d.x = (u_xlat1_d.x * u_xlat1_d.x);
          u_xlat1_d.x = min(u_xlat1_d.x, 1);
          out_f.color.w = (u_xlat0_d.w * u_xlat1_d.x);
          out_f.color.xyz = u_xlat0_d.xyz;
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
