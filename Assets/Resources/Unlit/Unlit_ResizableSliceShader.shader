Shader "Unlit/ResizableSliceShader"
{
  Properties
  {
    [PerRendererData] _MainTex ("Texture", 2D) = "white" {}
    [PerRendererData] _Tint ("Tint", Color) = (1,1,1,1)
    _NoiseIntensity ("Noise Intensity", float) = 0.0025
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
      uniform float _NoiseIntensity;
      uniform float4 _ObjectScale;
      uniform float4 _Tint;
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
          out_v.texcoord1.xy = in_v.vertex.xy;
          out_v.vertex = UnityObjectToClipPos(in_v.vertex);
          return out_v;
      }
      
      #define CODE_BLOCK_FRAGMENT
      float4 phase0_Input0_0;
      float4 u_xlat0_d;
      float4 u_xlat1_d;
      int2 u_xlati1;
      float2 u_xlatb1;
      float2 u_xlat4;
      float2 u_xlat5;
      float2 u_xlatb5;
      float u_xlat6;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          phase0_Input0_0 = float4(in_f.texcoord, in_f.texcoord1);
          u_xlat0_d = (phase0_Input0_0 * _ObjectScale.xyxy);
          u_xlat4.xy = (u_xlat0_d.zw * float2(35, 35));
          u_xlat4.xy = floor(u_xlat4.xy);
          u_xlat4.xy = (u_xlat4.xy * float2(0.627885759, 0.627885759));
          u_xlat4.xy = frac(u_xlat4.xy);
          u_xlat1_d.xyz = (u_xlat4.yxx + float3(33.3300018, 33.3300018, 33.3300018));
          u_xlat1_d.x = dot(u_xlat4.xyx, u_xlat1_d.xyz);
          u_xlat4.xy = (u_xlat4.xy + u_xlat1_d.xx);
          u_xlat6 = (u_xlat4.y + u_xlat4.x);
          u_xlat4.x = (u_xlat4.x * u_xlat6);
          u_xlat4.x = frac(u_xlat4.x);
          u_xlat1_d.xy = (_ObjectScale.xy + float2(-1, (-1)));
          u_xlat1_d.xy = ((phase0_Input0_0.xy * _ObjectScale.xy) + (-u_xlat1_d.xy));
          u_xlatb5.xy = bool4(float4(0.5, 0.5, 0.5, 0.5) < phase0_Input0_0.xyxy).xy;
          float4 hlslcc_movcTemp = u_xlat0_d;
          hlslcc_movcTemp.x = (u_xlatb5.x)?(u_xlat1_d.x):(u_xlat0_d.x);
          hlslcc_movcTemp.y = (u_xlatb5.y)?(u_xlat1_d.y):(u_xlat0_d.y);
          u_xlat0_d = hlslcc_movcTemp;
          u_xlat1_d.xy = (float2(0.5, 0.5) / _ObjectScale.xy);
          u_xlat5.xy = ((-u_xlat1_d.xy) + float2(1, 1));
          u_xlatb1.xy = bool4(u_xlat1_d.xyxx < phase0_Input0_0.xyxx).xy;
          u_xlatb5.xy = bool4(phase0_Input0_0.xyxy < u_xlat5.xyxy).xy;
          int _tmp_dvx_0 = ((uint2(u_xlatb5.xy) * 4294967295) & (uint2(u_xlatb1.xy) * 4294967295));
          u_xlati1.xy = float2(int2(_tmp_dvx_0, _tmp_dvx_0));
         // float4 hlslcc_movcTemp = u_xlat0_d;
          hlslcc_movcTemp.x = ((u_xlati1.x!=0))?(float(0.5)):(u_xlat0_d.x);
          hlslcc_movcTemp.y = ((u_xlati1.y!=0))?(float(0.5)):(u_xlat0_d.y);
          u_xlat0_d = hlslcc_movcTemp;
          u_xlat1_d = tex2D(_MainTex, u_xlat0_d.xy);
          u_xlat1_d.xyz = (((-u_xlat4.xxx) * float3(_NoiseIntensity, _NoiseIntensity, _NoiseIntensity)) + u_xlat1_d.xyz);
          out_f.color = (u_xlat1_d * _Tint);
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
