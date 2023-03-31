Shader "Jaap/GlowingMetal"
{
  Properties
  {
    _MainTex ("Texture", 2D) = "white" {}
    [HDR] _GlowColour ("Glow Colour", Color) = (1,0,1,1)
    _Progress ("Glow Intensity", Range(0, 1)) = 1
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
      uniform float4 _GlowColour;
      uniform float _Progress;
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
          out_v.vertex = UnityObjectToClipPos(in_v.vertex);
          out_v.texcoord.xy = in_v.texcoord.xy;
          return out_v;
      }
      
      #define CODE_BLOCK_FRAGMENT
      float4 u_xlat0_d;
      float u_xlat1_d;
      int u_xlatb1;
      float3 u_xlat3;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlat0_d = tex2D(_MainTex, in_f.texcoord.xy);
          u_xlat1_d = (u_xlat0_d.w + (-0.5));
          u_xlatb1 = (u_xlat1_d<0);
          if(((int(u_xlatb1) * int(4294967295))!=0))
          {
              discard;
          }
          u_xlat1_d = _Progress;
          u_xlat1_d = clamp(u_xlat1_d, 0, 1);
          u_xlat3.xyz = (u_xlat0_d.xyz * _GlowColour.xyz);
          u_xlat3.xyz = ((u_xlat3.xyz * float3(u_xlat1_d, u_xlat1_d, u_xlat1_d)) + (-u_xlat0_d.xyz));
          out_f.color.xyz = ((float3(u_xlat1_d, u_xlat1_d, u_xlat1_d) * u_xlat3.xyz) + u_xlat0_d.xyz);
          out_f.color.w = u_xlat0_d.w;
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
