Shader "Unlit/LowFidelityLiquid"
{
  Properties
  {
    _MainTex ("Texture", 2D) = "white" {}
    _LiquidColor ("Liquid Colour", Color) = (1,0,1,1)
    _Fill ("Fill", Range(0, 1)) = 1
    _UvBounds ("UV bounds", Vector) = (0,0,1,1)
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
      uniform float4 _LiquidColor;
      uniform float4 _UvBounds;
      uniform float _Fill;
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
      float2 u_xlatb0;
      float4 u_xlat1_d;
      float2 u_xlatb4;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlatb0.xy = bool4(in_f.texcoord.xyxx < _UvBounds.xyxx).xy;
          u_xlatb4.xy = bool4(_UvBounds.zwzw < in_f.texcoord.xyxy).xy;
          u_xlatb0.x = (u_xlatb4.x || u_xlatb0.x);
          u_xlatb0.x = (u_xlatb0.y || u_xlatb0.x);
          u_xlatb0.x = (u_xlatb4.y || u_xlatb0.x);
          if(((int(u_xlatb0.x) * int(4294967295))!=0))
          {
              discard;
          }
          u_xlatb0.x = (_Fill<0.00100000005);
          u_xlat0_d = (u_xlatb0.x)?(float4(0, 0, 0, 0)):(_LiquidColor);
          u_xlat1_d = tex2D(_MainTex, in_f.texcoord.xy);
          out_f.color = (u_xlat0_d * u_xlat1_d);
          u_xlat0_d.x = ((-in_f.texcoord.y) + _Fill);
          u_xlatb0.x = (u_xlat0_d.x<0);
          if(((int(u_xlatb0.x) * int(4294967295))!=0))
          {
              discard;
          }
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
