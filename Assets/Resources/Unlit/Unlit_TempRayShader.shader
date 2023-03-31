Shader "Unlit/TempRayShader"
{
  Properties
  {
    _MainTex ("Texture", 2D) = "white" {}
    [HDR] _Tint ("Tint", Color) = (1,0,0,1)
    _Frequency ("Frequency", float) = 0.1
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
      Blend One One
      // m_ProgramMask = 6
      CGPROGRAM
      //#pragma target 4.0
      
      #pragma vertex vert
      #pragma fragment frag
      
      #include "UnityCG.cginc"
      
      
      #define CODE_BLOCK_VERTEX
      //uniform float4x4 unity_ObjectToWorld;
      //uniform float4x4 unity_MatrixVP;
      uniform float4 _MainTex_ST;
      //uniform float4 _Time;
      uniform float4 _Tint;
      uniform float _Frequency;
      uniform float _Speed;
      uniform sampler2D _MainTex;
      struct appdata_t
      {
          float4 vertex :POSITION0;
          float2 texcoord :TEXCOORD0;
          float4 color :COLOR0;
      };
      
      struct OUT_Data_Vert
      {
          float2 texcoord :TEXCOORD0;
          float4 color :COLOR0;
          float4 vertex :SV_POSITION;
      };
      
      struct v2f
      {
          float2 texcoord :TEXCOORD0;
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
          out_v.texcoord.xy = TRANSFORM_TEX(in_v.texcoord.xy, _MainTex);
          out_v.vertex = UnityObjectToClipPos(in_v.vertex);
          out_v.color = in_v.color;
          return out_v;
      }
      
      #define CODE_BLOCK_FRAGMENT
      float4 u_xlat0_d;
      int u_xlatb0;
      float4 u_xlat1_d;
      float4 u_xlat2;
      float u_xlat3;
      float u_xlat6;
      float u_xlat9;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlatb0 = (_Time.z>=(-_Time.z));
          u_xlat0_d.x = (u_xlatb0)?(1):((-1));
          u_xlat3 = (u_xlat0_d.x * _Time.z);
          u_xlat3 = frac(u_xlat3);
          u_xlat0_d.x = (u_xlat3 * u_xlat0_d.x);
          u_xlat6 = (in_f.texcoord.x * _Frequency);
          u_xlat6 = ((_Time.z * _Speed) + (-u_xlat6));
          u_xlat6 = sin(u_xlat6);
          u_xlat6 = (u_xlat6 * in_f.texcoord.x);
          u_xlat1_d.y = ((u_xlat6 * 0.25) + in_f.texcoord.y);
          u_xlat0_d.y = 0;
          u_xlat1_d.x = in_f.texcoord.x;
          u_xlat0_d.xy = ((u_xlat1_d.xy * float2(249.339996, 249.339996)) + u_xlat0_d.xy);
          u_xlat2 = tex2D(_MainTex, u_xlat1_d.xy);
          u_xlat0_d.z = (u_xlat1_d.y + (-0.5));
          u_xlat0_d.xyz = (u_xlat0_d.xyz * float3(0.103100002, 0.103100002, 3.14159274));
          u_xlat6 = cos(u_xlat0_d.z);
          u_xlat6 = max(u_xlat6, 0);
          u_xlat6 = log2(u_xlat6);
          u_xlat6 = (u_xlat6 * 50);
          u_xlat6 = exp2(u_xlat6);
          u_xlat1_d = (u_xlat2 * _Tint);
          u_xlat0_d.xy = frac(u_xlat0_d.xy);
          u_xlat2.xyz = (u_xlat0_d.yxx + float3(33.3300018, 33.3300018, 33.3300018));
          u_xlat9 = dot(u_xlat0_d.xyx, u_xlat2.xyz);
          u_xlat0_d.xy = (float2(u_xlat9, u_xlat9) + u_xlat0_d.xy);
          u_xlat3 = (u_xlat0_d.y + u_xlat0_d.x);
          u_xlat0_d.x = (u_xlat0_d.x * u_xlat3);
          u_xlat0_d.x = frac(u_xlat0_d.x);
          u_xlat1_d = (u_xlat0_d.xxxx * u_xlat1_d);
          u_xlat0_d = (float4(u_xlat6, u_xlat6, u_xlat6, u_xlat6) * u_xlat1_d);
          out_f.color = (u_xlat0_d * in_f.color);
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
