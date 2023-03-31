Shader "Unlit/SyringeShader"
{
  Properties
  {
    _MainTex ("Texture", 2D) = "white" {}
    _CutoffA ("Cutoff A", Range(0, 1)) = 0.1
    _CutoffB ("Cutoff B", Range(0, 1)) = 0.1
    _LiquidColour ("Liquid colour", Color) = (1,0,1,1)
    _Direction ("Flow direction", Range(-1, 1)) = 0
  }
  SubShader
  {
    Tags
    { 
      "CanUseSpriteAtlas" = "true"
      "QUEUE" = "Transparent+1"
      "RenderType" = "Opaque"
    }
    Pass // ind: 1, name: 
    {
      Tags
      { 
        "CanUseSpriteAtlas" = "true"
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
      uniform float4 _MainTex_ST;
      //uniform float4 _Time;
      uniform float _CutoffA;
      uniform float _CutoffB;
      uniform float _Direction;
      uniform float4 _LiquidColour;
      uniform sampler2D _MainTex;
      struct appdata_t
      {
          float4 vertex :POSITION0;
          float2 texcoord :TEXCOORD0;
      };
      
      struct OUT_Data_Vert
      {
          float2 texcoord :TEXCOORD0;
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
          out_v.texcoord.xy = TRANSFORM_TEX(in_v.texcoord.xy, _MainTex);
          out_v.vertex = UnityObjectToClipPos(in_v.vertex);
          return out_v;
      }
      
      #define CODE_BLOCK_FRAGMENT
      float4 u_xlat0_d;
      float4 u_xlat1_d;
      int u_xlatb1;
      float4 u_xlat2;
      float u_xlat3;
      int u_xlatb3;
      float3 u_xlat4;
      int u_xlatb4;
      float u_xlat7;
      int u_xlatb7;
      float u_xlat8;
      int u_xlatb8;
      int u_xlatb11;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlat0_d.x = (in_f.texcoord.x + in_f.texcoord.x);
          u_xlat4.x = ((_Time.y * (-2)) + u_xlat0_d.x);
          u_xlat0_d.x = ((_Time.y * 2) + u_xlat0_d.x);
          u_xlatb8 = (u_xlat4.x>=(-u_xlat4.x));
          u_xlat4.x = frac(abs(u_xlat4.x));
          u_xlat4.x = (u_xlatb8)?(u_xlat4.x):((-u_xlat4.x));
          u_xlat4.x = (abs(u_xlat4.x) + (-0.850000024));
          u_xlat4.x = (u_xlat4.x * 20.0000191);
          u_xlat4.x = clamp(u_xlat4.x, 0, 1);
          u_xlat8 = ((u_xlat4.x * (-2)) + 3);
          u_xlat4.x = (u_xlat4.x * u_xlat4.x);
          u_xlat4.x = (u_xlat4.x * u_xlat8);
          u_xlatb8 = (u_xlat0_d.x>=(-u_xlat0_d.x));
          u_xlat0_d.x = frac(abs(u_xlat0_d.x));
          u_xlat0_d.x = (u_xlatb8)?(u_xlat0_d.x):((-u_xlat0_d.x));
          u_xlat0_d.x = (abs(u_xlat0_d.x) + (-0.850000024));
          u_xlat0_d.x = (u_xlat0_d.x * 20.0000191);
          u_xlat0_d.x = clamp(u_xlat0_d.x, 0, 1);
          u_xlat8 = ((u_xlat0_d.x * (-2)) + 3);
          u_xlat0_d.x = (u_xlat0_d.x * u_xlat0_d.x);
          u_xlat0_d.x = (u_xlat0_d.x * u_xlat8);
          u_xlatb8 = (0<_Direction);
          u_xlat0_d.x = (u_xlatb8)?(u_xlat4.x):(u_xlat0_d.x);
          u_xlat0_d.x = (u_xlat0_d.x * abs(_Direction));
          u_xlat1_d = tex2D(_MainTex, in_f.texcoord.xy);
          u_xlat0_d.x = (u_xlat0_d.x * u_xlat1_d.w);
          u_xlat0_d.x = (u_xlat0_d.x * 0.25);
          u_xlat4.x = dot(_LiquidColour.xyz, float3(0.298999995, 0.587000012, 0.114));
          u_xlatb4 = (0.5<u_xlat4.x);
          u_xlat4.x = (u_xlatb4)?(0):(1);
          u_xlat4.xyz = (u_xlat4.xxx + (-_LiquidColour.xyz));
          u_xlat0_d.xyz = ((u_xlat0_d.xxx * u_xlat4.xyz) + _LiquidColour.xyz);
          u_xlat0_d.w = 1;
          u_xlat2 = ((-u_xlat0_d) + float4(1, 1, 1, 1));
          u_xlatb3 = (_CutoffA<in_f.texcoord.x);
          u_xlat7 = ((-_CutoffA) + _CutoffB);
          u_xlat7 = ((_LiquidColour.w * u_xlat7) + _CutoffA);
          u_xlatb11 = (in_f.texcoord.x<u_xlat7);
          u_xlatb7 = (u_xlat7<in_f.texcoord.x);
          u_xlatb3 = (u_xlatb11 || u_xlatb3);
          u_xlat3 = (u_xlatb3)?(1):(float(0));
          u_xlat0_d = ((float4(u_xlat3, u_xlat3, u_xlat3, u_xlat3) * u_xlat2) + u_xlat0_d);
          u_xlat0_d = (u_xlat0_d * u_xlat1_d);
          u_xlatb1 = (in_f.texcoord.x<_CutoffB);
          u_xlatb1 = (u_xlatb1 || u_xlatb7);
          u_xlat1_d.x = (u_xlatb1)?(1):(0.25);
          out_f.color.w = (u_xlat0_d.w * u_xlat1_d.x);
          out_f.color.xyz = u_xlat0_d.xyz;
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
