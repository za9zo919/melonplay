Shader "Unlit/UvSlideSprite"
{
  Properties
  {
    _MainTex ("Texture", 2D) = "white" {}
    _OffsetA ("Offset A", Vector) = (0,0,0,0)
    _OffsetB ("Offset B", Vector) = (1,0,0,0)
    _Transform ("Transform", Vector) = (1,1,0,0)
    _Offset ("Offset", Range(0, 1)) = 0
    [HDR] _Tint ("Tint", Color) = (1,1,1,0)
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
      uniform float4 _Transform;
      uniform float4 _OffsetA;
      uniform float4 _OffsetB;
      uniform float4 _Tint;
      uniform float _Offset;
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
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlat0_d.xy = ((-_OffsetA.xy) + _OffsetB.xy);
          u_xlat0_d.xy = ((float2(_Offset, _Offset) * u_xlat0_d.xy) + _OffsetA.xy);
          u_xlat0_d.xy = ((in_f.texcoord.xy * _Transform.xy) + u_xlat0_d.xy);
          u_xlat0_d = tex2D(_MainTex, u_xlat0_d.xy);
          out_f.color = (u_xlat0_d * _Tint);
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
