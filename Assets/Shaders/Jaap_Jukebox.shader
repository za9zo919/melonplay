Shader "Jaap/Jukebox"
{
  Properties
  {
    _MainTex ("Texture", 2D) = "white" {}
    _GlowMask ("Mask", 2D) = "white" {}
    _Gradient ("Gradient", 2D) = "white" {}
    [HDR] _BaseColour ("Base Colour", Color) = (1,0,1,1)
    [PerRendererData] _MusicVolume ("Music Volume", float) = 0
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
      //uniform float4 _SinTime;
      uniform float4 _BaseColour;
      uniform float _MusicVolume;
      uniform sampler2D _MainTex;
      uniform sampler2D _GlowMask;
      uniform sampler2D _Gradient;
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
      float4 u_xlat2;
      float3 u_xlat5;
      float u_xlat9;
      int u_xlatb9;
      int u_xlatb10;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlat0_d = tex2D(_MainTex, in_f.texcoord.xy);
          u_xlat9 = (u_xlat0_d.w + (-0.5));
          u_xlatb9 = (u_xlat9<0);
          if(((int(u_xlatb9) * int(4294967295))!=0))
          {
              discard;
          }
          u_xlat9 = ((_SinTime.w * 0.5) + 0.5);
          u_xlat9 = (u_xlat9 * 0.00999999978);
          u_xlat9 = max(u_xlat9, _MusicVolume);
          u_xlat1_d.x = ((_Time.x * 2) + in_f.texcoord.y);
          u_xlat1_d.y = 0;
          u_xlat1_d = tex2D(_Gradient, u_xlat1_d.xy);
          u_xlat2 = tex2D(_GlowMask, in_f.texcoord.xy);
          u_xlat5.xyz = (u_xlat2.xyz * _BaseColour.xyz);
          u_xlatb10 = (0<u_xlat2.x);
          u_xlat1_d.xyz = (u_xlat1_d.xyz * u_xlat5.xyz);
          u_xlat1_d.xyz = (float3(u_xlat9, u_xlat9, u_xlat9) * u_xlat1_d.xyz);
          out_f.color.xyz = (int(u_xlatb10))?(u_xlat1_d.xyz):(u_xlat0_d.xyz);
          out_f.color.w = 1;
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
