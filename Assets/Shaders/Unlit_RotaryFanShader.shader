Shader "Unlit/RotaryFanShader"
{
  Properties
  {
    _MainTex ("Texture", 2D) = "white" {}
    _FanFrequency ("Blade count", float) = 4
    _Speed ("Rotation speed", float) = 1
    _Pixelation ("Pixelation", float) = 35
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
      uniform float _Speed;
      uniform float _FanFrequency;
      uniform float _Pixelation;
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
      float2 u_xlat0_d;
      int u_xlatb0;
      float4 u_xlat1_d;
      float3 u_xlat2;
      int u_xlatb2;
      int u_xlatb3;
      float u_xlat4;
      float u_xlat6;
      int u_xlatb6;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlat0_d.xy = (in_f.texcoord.yx * float2(float2(_Pixelation, _Pixelation)));
          u_xlat0_d.xy = ceil(u_xlat0_d.xy);
          u_xlat0_d.xy = (u_xlat0_d.xy / float2(float2(_Pixelation, _Pixelation)));
          u_xlat0_d.xy = (u_xlat0_d.xy + float2(-0.5, (-0.5)));
          u_xlat4 = max(abs(u_xlat0_d.y), abs(u_xlat0_d.x));
          u_xlat4 = (float(1) / u_xlat4);
          u_xlat6 = min(abs(u_xlat0_d.y), abs(u_xlat0_d.x));
          u_xlat4 = (u_xlat4 * u_xlat6);
          u_xlat6 = (u_xlat4 * u_xlat4);
          u_xlat1_d.x = ((u_xlat6 * 0.0208350997) + (-0.0851330012));
          u_xlat1_d.x = ((u_xlat6 * u_xlat1_d.x) + 0.180141002);
          u_xlat1_d.x = ((u_xlat6 * u_xlat1_d.x) + (-0.330299497));
          u_xlat6 = ((u_xlat6 * u_xlat1_d.x) + 0.999866009);
          u_xlat1_d.x = (u_xlat6 * u_xlat4);
          u_xlat1_d.x = ((u_xlat1_d.x * (-2)) + 1.57079637);
          u_xlatb3 = (abs(u_xlat0_d.y)<abs(u_xlat0_d.x));
          u_xlat1_d.x = (u_xlatb3)?(u_xlat1_d.x):(float(0));
          u_xlat4 = ((u_xlat4 * u_xlat6) + u_xlat1_d.x);
          u_xlatb6 = (u_xlat0_d.y<(-u_xlat0_d.y));
          u_xlat6 = (u_xlatb6)?((-3.14159274)):(float(0));
          u_xlat4 = (u_xlat6 + u_xlat4);
          u_xlat6 = min(u_xlat0_d.y, u_xlat0_d.x);
          u_xlat0_d.x = max(u_xlat0_d.y, u_xlat0_d.x);
          u_xlatb0 = (u_xlat0_d.x>=(-u_xlat0_d.x));
          u_xlatb2 = (u_xlat6<(-u_xlat6));
          u_xlatb0 = (u_xlatb0 && u_xlatb2);
          u_xlat0_d.x = (u_xlatb0)?((-u_xlat4)):(u_xlat4);
          u_xlat2.x = (_Time.y * _Speed);
          u_xlat0_d.x = ((u_xlat0_d.x * _FanFrequency) + u_xlat2.x);
          u_xlat0_d.x = sin(u_xlat0_d.x);
          u_xlatb0 = (0<u_xlat0_d.x);
          u_xlat0_d.xy = float2((int(u_xlatb0))?(float2(0.0450000018, (-0.0450000018))):(float2(0.0399999991, (-0.0399999991))));
          u_xlat1_d = tex2D(_MainTex, in_f.texcoord.xy);
          u_xlat2.xyz = (u_xlat0_d.yyy + u_xlat1_d.xyz);
          out_f.color.xyz = ((u_xlat1_d.www * u_xlat2.xyz) + u_xlat0_d.xxx);
          out_f.color.w = 1;
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
