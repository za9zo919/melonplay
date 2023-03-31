Shader "Unlit/SpriteOutlineGlowOverlayShader"
{
  Properties
  {
    [PerRendererData] _MainTex ("Texture", 2D) = "white" {}
    [PerRendererData] _AtlasTransform ("Atlas Transform", Vector) = (0,0,0,0)
    [HDR] _GlowColour ("Glow outline colour", Color) = (1,0,0,1)
    _Threshold ("Threshold", float) = 0.5
  }
  SubShader
  {
    Tags
    { 
      "QUEUE" = "Transparent+1"
      "RenderType" = "Opaque"
    }
    LOD 100
    Pass // ind: 1, name: 
    {
      Tags
      { 
        "QUEUE" = "Transparent+1"
        "RenderType" = "Opaque"
      }
      LOD 100
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
      uniform float4 _AtlasTransform;
      uniform float4 _MainTex_TexelSize;
      uniform float4 _GlowColour;
      uniform float _Threshold;
      uniform float2 _ObjectScale;
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
          float4 texcoord2 :TEXCOORD2;
          float4 vertex :SV_POSITION;
      };
      
      struct v2f
      {
          float2 texcoord :TEXCOORD0;
          float2 texcoord1 :TEXCOORD1;
          float4 texcoord2 :TEXCOORD2;
      };
      
      struct OUT_Data_Frag
      {
          float4 color :SV_Target0;
      };
      
      float4 u_xlat0;
      float4 u_xlat1;
      float2 u_xlat4;
      OUT_Data_Vert vert(appdata_t in_v)
      {
          OUT_Data_Vert out_v;
          u_xlat0.xy = TRANSFORM_TEX(in_v.texcoord.xy, _MainTex);
          u_xlat4.xy = (u_xlat0.xy + (-_AtlasTransform.xy));
          out_v.texcoord.xy = u_xlat0.xy;
          out_v.texcoord1.xy = (u_xlat4.xy / _AtlasTransform.zw);
          out_v.texcoord2 = _AtlasTransform;
          out_v.vertex = UnityObjectToClipPos(in_v.vertex);
          return out_v;
      }
      
      #define CODE_BLOCK_FRAGMENT
      float4 u_xlat0_d;
      int u_xlatb0;
      float4 u_xlat1_d;
      float2 u_xlatb1;
      float4 u_xlat2;
      float2 u_xlat3;
      float2 u_xlatb3;
      float2 u_xlat6;
      float2 u_xlat7;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlat0_d.x = (-_MainTex_TexelSize.x);
          u_xlat0_d.y = float(0);
          u_xlat6.y = float(0);
          u_xlat0_d.xy = (u_xlat0_d.xy + in_f.texcoord.xy);
          u_xlat1_d = tex2D(_MainTex, u_xlat0_d.xy);
          u_xlat6.x = _MainTex_TexelSize.x;
          u_xlat0_d.xy = (u_xlat6.xy + in_f.texcoord.xy);
          u_xlat0_d = tex2D(_MainTex, u_xlat0_d.xy);
          u_xlat0_d.x = min(u_xlat0_d.w, u_xlat1_d.w);
          u_xlat1_d.y = _MainTex_TexelSize.y;
          u_xlat1_d.x = float(0);
          u_xlat7.x = float(0);
          u_xlat3.xy = (u_xlat1_d.xy + in_f.texcoord.xy);
          u_xlat2 = tex2D(_MainTex, u_xlat3.xy);
          u_xlat7.y = (-_MainTex_TexelSize.y);
          u_xlat3.xy = (u_xlat7.xy + in_f.texcoord.xy);
          u_xlat1_d = tex2D(_MainTex, u_xlat3.xy);
          u_xlat3.x = min(u_xlat1_d.w, u_xlat2.w);
          u_xlat0_d.x = min(u_xlat3.x, u_xlat0_d.x);
          u_xlat3.x = (_ObjectScale.y * _ObjectScale.x);
          u_xlatb3.x = (0.00999999978<u_xlat3.x);
          u_xlat6.xy = (_MainTex_TexelSize.xy / in_f.texcoord2.zw);
          u_xlat1_d.xy = (u_xlat6.xy / _ObjectScale.xy);
          u_xlat3.xy = (u_xlatb3.x)?(u_xlat1_d.xy):(u_xlat6.xy);
          u_xlat1_d.xy = ((-u_xlat3.xy) + float2(1, 1));
          u_xlatb3.xy = bool4(in_f.texcoord1.xyxx < u_xlat3.xyxx).xy;
          u_xlatb1.xy = bool4(u_xlat1_d.xyxx < in_f.texcoord1.xyxx).xy;
          u_xlatb3.x = (u_xlatb3.x || u_xlatb1.x);
          u_xlatb3.x = (u_xlatb3.y || u_xlatb3.x);
          u_xlatb3.x = (u_xlatb1.y || u_xlatb3.x);
          u_xlat3.x = (u_xlatb3.x)?(0):(1);
          u_xlat0_d.x = min(u_xlat3.x, u_xlat0_d.x);
          u_xlat0_d.x = ((-u_xlat0_d.x) + 1);
          u_xlat1_d = tex2D(_MainTex, in_f.texcoord.xy);
          u_xlat0_d.x = (u_xlat0_d.x * u_xlat1_d.w);
          u_xlat0_d.x = clamp(u_xlat0_d.x, 0, 1);
          u_xlat0_d.x = (u_xlat0_d.x + (-_Threshold));
          u_xlatb0 = (u_xlat0_d.x<0);
          if(((int(u_xlatb0) * int(4294967295))!=0))
          {
              discard;
          }
          out_f.color = (_GlowColour * float4(0.5, 0.5, 0.5, 0.5));
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
