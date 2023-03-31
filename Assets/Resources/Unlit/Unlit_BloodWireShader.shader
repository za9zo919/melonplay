Shader "Unlit/BloodWireShader"
{
  Properties
  {
    _MainTex ("Texture", 2D) = "white" {}
    _BulgeIntensity ("Bulge Intensity", float) = 1
    _Flow ("Flow", float) = 1
    _BloodColor ("Blood color", Color) = (1,0,0,1)
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
      uniform float4 _MainTex_ST;
      //uniform float4 _Time;
      uniform float _BulgeIntensity;
      uniform float _Flow;
      uniform float4 _BloodColor;
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
      int u_xlatb6;
      float u_xlat9;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlatb0 = (0<_Flow);
          u_xlat0_d.x = (u_xlatb0)?(1):((-1));
          u_xlat0_d.x = (u_xlat0_d.x * _Time.w);
          u_xlat3 = (in_f.texcoord.x * 0.100000001);
          u_xlat0_d.x = ((u_xlat0_d.x * 8) + (-u_xlat3));
          u_xlat0_d.x = sin(u_xlat0_d.x);
          u_xlat0_d.x = ((u_xlat0_d.x * 0.5) + 0.5);
          u_xlat0_d.x = (u_xlat0_d.x * u_xlat0_d.x);
          u_xlat0_d.x = (u_xlat0_d.x * u_xlat0_d.x);
          u_xlat0_d.x = (u_xlat0_d.x * u_xlat0_d.x);
          u_xlat0_d.y = min(abs(_Flow), 1);
          u_xlat0_d.x = (u_xlat0_d.y * u_xlat0_d.x);
          u_xlat6 = ((-_BulgeIntensity) + 1);
          u_xlat6 = ((u_xlat0_d.x * u_xlat6) + _BulgeIntensity);
          u_xlat9 = (in_f.texcoord.y + (-0.5));
          u_xlat1_d.x = (u_xlat6 * u_xlat9);
          u_xlat2.y = ((u_xlat9 * u_xlat6) + 0.5);
          u_xlat6 = ((-abs(u_xlat1_d.x)) + 0.5);
          u_xlatb6 = (u_xlat6<0);
          if(((int(u_xlatb6) * int(4294967295))!=0))
          {
              discard;
          }
          u_xlat6 = (u_xlat0_d.y * u_xlat0_d.y);
          u_xlat6 = (u_xlat6 * u_xlat6);
          u_xlat6 = (u_xlat6 * u_xlat0_d.y);
          u_xlat0_d.x = (u_xlat6 * u_xlat0_d.x);
          u_xlat0_d.x = log2(u_xlat0_d.x);
          u_xlat0_d.xy = (u_xlat0_d.xy * float2(0.100000001, 0.800000012));
          u_xlat0_d.x = exp2(u_xlat0_d.x);
          u_xlat0_d.x = max(u_xlat0_d.x, u_xlat0_d.y);
          u_xlat2.x = in_f.texcoord.x;
          u_xlat1_d = tex2D(_MainTex, u_xlat2.xy);
          u_xlat2.xyz = (u_xlat1_d.xyz * _BloodColor.xyz);
          u_xlat2.w = u_xlat1_d.w;
          u_xlat2 = ((-u_xlat1_d) + u_xlat2);
          u_xlat0_d = ((u_xlat0_d.xxxx * u_xlat2) + u_xlat1_d);
          out_f.color = (u_xlat0_d * in_f.color);
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
