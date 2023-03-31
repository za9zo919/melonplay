Shader "Unlit/LaserPointerBeam"
{
  Properties
  {
    [HDR] _Color ("Color", Color) = (0,1,0,1)
    _NoiseTexture ("Noise Texture", 2D) = "white" {}
  }
  SubShader
  {
    Tags
    { 
      "RenderType" = "Fade"
    }
    Pass // ind: 1, name: 
    {
      Tags
      { 
        "RenderType" = "Fade"
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
      //uniform float4 _Time;
      uniform float4 _Color;
      uniform sampler2D _NoiseTexture;
      struct appdata_t
      {
          float4 vertex :POSITION0;
          float4 color :COLOR0;
          float2 texcoord :TEXCOORD0;
      };
      
      struct OUT_Data_Vert
      {
          float2 texcoord :TEXCOORD0;
          float4 color :COLOR0;
          float4 texcoord1 :TEXCOORD1;
          float4 vertex :SV_POSITION;
      };
      
      struct v2f
      {
          float2 texcoord :TEXCOORD0;
          float4 color :COLOR0;
          float4 texcoord1 :TEXCOORD1;
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
          out_v.color = in_v.color;
          u_xlat0 = UnityObjectToClipPos(in_v.vertex);
          u_xlat1.xyz = (u_xlat0.xyw * float3(0.5, 0.5, 0.5));
          out_v.texcoord1.xy = (u_xlat1.zz + u_xlat1.xy);
          out_v.texcoord1.zw = u_xlat0.zw;
          out_v.vertex = u_xlat0;
          return out_v;
      }
      
      #define CODE_BLOCK_FRAGMENT
      float3 u_xlat0_d;
      float4 u_xlat1_d;
      float4 u_xlat2;
      float u_xlat3;
      float2 u_xlat6;
      int u_xlatb6;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlat0_d.xy = ((-in_f.texcoord.yx) + float2(0.5, 1));
          u_xlatb6 = (u_xlat0_d.y>=(-u_xlat0_d.y));
          u_xlat0_d.z = (u_xlatb6)?(1):((-1));
          u_xlat0_d.x = (((-abs(u_xlat0_d.x)) * 2) + 1);
          u_xlat0_d.xy = (u_xlat0_d.xz * u_xlat0_d.xy);
          u_xlat3 = frac(u_xlat0_d.y);
          u_xlat3 = (u_xlat3 * u_xlat0_d.z);
          u_xlat6.xy = ((_Time.zz * float2(2, 2)) + in_f.texcoord1.xy);
          u_xlat1_d = tex2D(_NoiseTexture, u_xlat6.xy);
          u_xlat2 = (in_f.color * _Color);
          u_xlat1_d = (u_xlat1_d.xxxx * u_xlat2);
          u_xlat1_d = (u_xlat0_d.xxxx * u_xlat1_d);
          out_f.color = (float4(u_xlat3, u_xlat3, u_xlat3, u_xlat3) * u_xlat1_d);
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
