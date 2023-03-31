Shader "Unlit/LED Display Shader"
{
  Properties
  {
    [PerRendererData] _MainTex ("Texture", 2D) = "white" {}
    _LEDMultiply ("Texture", 2D) = "white" {}
    _Pixelation ("Pixelation", float) = 8
    _FPS ("Frames per second", float) = 12
    [HDR] _Tint ("Tint", Color) = (1,1,1,1)
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
      uniform float4 _MainTex_ST;
      //uniform float4 _Time;
      uniform float _FPS;
      uniform float4 _LEDMultiply_TexelSize;
      uniform float4 _Tint;
      uniform float _Pixelation;
      uniform sampler2D _MainTex;
      uniform sampler2D _LEDMultiply;
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
      float u_xlat2;
      float2 u_xlat4;
      int u_xlatb4;
      float u_xlat6;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlat0_d.x = (_Time.y * _FPS);
          u_xlat0_d.y = (_LEDMultiply_TexelSize.z / _LEDMultiply_TexelSize.w);
          u_xlat0_d.xy = round(u_xlat0_d.xy);
          u_xlat4.x = (u_xlat0_d.y * u_xlat0_d.x);
          u_xlatb4 = (u_xlat4.x>=(-u_xlat4.x));
          u_xlat4.x = (u_xlatb4)?(u_xlat0_d.y):((-u_xlat0_d.y));
          u_xlat6 = (float(1) / u_xlat4.x);
          u_xlat0_d.x = (u_xlat6 * u_xlat0_d.x);
          u_xlat0_d.x = frac(u_xlat0_d.x);
          u_xlat0_d.x = (u_xlat0_d.x * u_xlat4.x);
          u_xlat4.xy = (in_f.texcoord.xy * float2(_Pixelation, _Pixelation));
          u_xlat4.xy = round(u_xlat4.xy);
          u_xlat1_d.yz = (u_xlat4.xy / float2(_Pixelation, _Pixelation));
          u_xlat4.x = (u_xlat1_d.y / u_xlat0_d.y);
          u_xlat2 = (float(1) / u_xlat0_d.y);
          u_xlat1_d.x = ((u_xlat0_d.x * u_xlat2) + u_xlat4.x);
          u_xlat0_d = tex2D(_LEDMultiply, u_xlat1_d.xz);
          u_xlat1_d = tex2D(_MainTex, in_f.texcoord.xy);
          u_xlat1_d = (u_xlat1_d * _Tint);
          out_f.color = (u_xlat0_d * u_xlat1_d);
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
