Shader "Unlit/Obstruction"
{
  Properties
  {
    _MainTex ("Texture", 2D) = "white" {}
    _Wiggle ("Wiggle", 2D) = "white" {}
    [HDR] _Tint ("Tint", Color) = (1,1,1,1)
    _Scroll ("Scroll", Vector) = (1,0,0,0)
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
      //uniform float4 _Time;
      //uniform float4 _SinTime;
      uniform float2 _Scroll;
      uniform float4 _Tint;
      uniform sampler2D _Wiggle;
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
      float4 phase0_Input0_0;
      float4 u_xlat0_d;
      float4 u_xlat1_d;
      float4 u_xlat2;
      float2 u_xlat3;
      float2 u_xlat6;
      float u_xlat9;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          phase0_Input0_0 = float4(in_f.texcoord, in_f.texcoord1);
          u_xlat0_d.xy = (_Time.yy * _Scroll.xy);
          u_xlat6.xy = (u_xlat0_d.yx * float2(0.300000012, 0.300000012));
          u_xlat6.xy = ((phase0_Input0_0.zw * float2(0.5, 0.5)) + u_xlat6.xy);
          u_xlat1_d = tex2D(_Wiggle, u_xlat6.xy);
          u_xlat1_d.xyz = ((u_xlat1_d.xxy * float3(2, 2, 2)) + float3(-0.5, (-0.5), (-0.5)));
          u_xlat1_d.xyz = (u_xlat1_d.xyz * phase0_Input0_0.xxx);
          u_xlat6.xy = (u_xlat1_d.yz * float2(0.00999999978, 0.00999999978));
          u_xlat1_d.xyz = ((u_xlat1_d.xyz * float3(0.100000001, 0.00999999978, 0.00999999978)) + phase0_Input0_0.yzw);
          u_xlat6.xy = ((phase0_Input0_0.zw * float2(0.5, 0.5)) + u_xlat6.xy);
          u_xlat6.xy = (((-u_xlat0_d.xy) * float2(0.5, 0.5)) + u_xlat6.xy);
          u_xlat0_d.xy = ((u_xlat1_d.yz * float2(0.25, 0.25)) + u_xlat0_d.xy);
          u_xlat2 = tex2D(_MainTex, u_xlat0_d.xy);
          u_xlat0_d = tex2D(_MainTex, u_xlat6.xy);
          u_xlat3.x = ((_SinTime.w * 0.5) + 0.5);
          u_xlat0_d.x = (u_xlat3.x * u_xlat0_d.x);
          u_xlat0_d.x = (u_xlat0_d.x * 37.5100708);
          u_xlat0_d.x = exp2(u_xlat0_d.x);
          u_xlat3.xy = ((_Scroll.xy * _Time.yy) + u_xlat1_d.yz);
          u_xlat1_d.x = u_xlat1_d.x;
          u_xlat1_d.x = clamp(u_xlat1_d.x, 0, 1);
          u_xlat9 = (u_xlat1_d.x * 3.14159274);
          u_xlat9 = sin(u_xlat9);
          u_xlat9 = (u_xlat9 * u_xlat9);
          u_xlat1_d = tex2D(_MainTex, u_xlat3.xy);
          u_xlat3.x = (u_xlat2.x + u_xlat1_d.x);
          u_xlat3.x = (u_xlat3.x * 18.7550354);
          u_xlat3.x = exp2(u_xlat3.x);
          u_xlat0_d.x = (u_xlat0_d.x + u_xlat3.x);
          u_xlat0_d.x = log2(u_xlat0_d.x);
          u_xlat3.x = (u_xlat9 * u_xlat9);
          u_xlat3.x = (u_xlat3.x * u_xlat9);
          u_xlat6.x = ((-phase0_Input0_0.x) + 1);
          u_xlat6.x = (u_xlat6.x * 12);
          u_xlat6.x = clamp(u_xlat6.x, 0, 1);
          u_xlat3.x = (u_xlat6.x * u_xlat3.x);
          u_xlat6.x = (u_xlat3.x * u_xlat3.x);
          u_xlat6.x = (u_xlat6.x * u_xlat6.x);
          u_xlat3.x = (((-u_xlat6.x) * 0.800000012) + u_xlat3.x);
          u_xlat0_d.x = (u_xlat3.x * u_xlat0_d.x);
          u_xlat0_d.x = (u_xlat0_d.x * 0.0266595073);
          out_f.color = (u_xlat0_d.xxxx * _Tint);
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
