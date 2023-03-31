Shader "Unlit/MinigunBarrelShader"
{
  Properties
  {
    _MainTex ("Texture", 2D) = "white" {}
    _ActualSprite ("Texture", 2D) = "white" {}
    _Mask ("Rotating Mask", 2D) = "white" {}
    _Rotation ("Rotation", float) = 0
    [HDR] _GlowColour ("Glow Colour", Color) = (1,0,1,1)
    _Progress ("Glow Intensity", Range(0, 1)) = 1
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
      uniform float4 _ActualSprite_ST;
      uniform float _Rotation;
      uniform float4 _GlowColour;
      uniform float _Progress;
      uniform sampler2D _Mask;
      uniform sampler2D _ActualSprite;
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
          out_v.texcoord.xy = TRANSFORM_TEX(in_v.texcoord.xy, _ActualSprite);
          out_v.vertex = UnityObjectToClipPos(in_v.vertex);
          return out_v;
      }
      
      #define CODE_BLOCK_FRAGMENT
      float4 u_xlat0_d;
      float4 u_xlat1_d;
      float3 u_xlat2;
      float u_xlat4;
      float u_xlat9;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlat0_d.x = 0;
          u_xlat1_d = tex2D(_Mask, in_f.texcoord.xy);
          u_xlat0_d.y = (u_xlat1_d.y * _Rotation);
          u_xlat0_d.xy = (u_xlat0_d.xy + in_f.texcoord.xy);
          u_xlat0_d = tex2D(_ActualSprite, u_xlat0_d.xy);
          u_xlat2.xyz = (u_xlat0_d.xyz * _GlowColour.xyz);
          u_xlat4 = sqrt(u_xlat1_d.z);
          out_f.color.w = min(u_xlat0_d.w, u_xlat1_d.x);
          u_xlat9 = (u_xlat4 * _Progress);
          u_xlat1_d.xyz = ((u_xlat2.xyz * float3(u_xlat9, u_xlat9, u_xlat9)) + (-u_xlat0_d.xyz));
          out_f.color.xyz = ((float3(u_xlat9, u_xlat9, u_xlat9) * u_xlat1_d.xyz) + u_xlat0_d.xyz);
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
