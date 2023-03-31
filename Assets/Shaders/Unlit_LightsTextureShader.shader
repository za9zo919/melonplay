Shader "Unlit/LightsTextureShader"
{
  Properties
  {
    _LightsRenderTexture ("Lights RT", 2D) = "white" {}
    _MainTex ("Texture", 2D) = "white" {}
    _Intensity ("Intensity", float) = 1
    _MinimumBrightness ("Min Brightness", float) = 0
    _MaximumBrightness ("Max Brightness", float) = 1
  }
  SubShader
  {
    Tags
    { 
      "RenderType" = "Opaque"
    }
    LOD 100
    Pass // ind: 1, name: 
    {
      Tags
      { 
        "RenderType" = "Opaque"
      }
      LOD 100
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
      uniform float _Intensity;
      uniform float _MinimumBrightness;
      uniform float _MaximumBrightness;
      uniform sampler2D _MainTex;
      uniform sampler2D _LightsRenderTexture;
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
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlat0_d = tex2D(_LightsRenderTexture, in_f.texcoord.xy);
          u_xlat0_d = (u_xlat0_d * float4(_Intensity, _Intensity, _Intensity, _Intensity));
          u_xlat0_d = max(u_xlat0_d, float4(float4(_MinimumBrightness, _MinimumBrightness, _MinimumBrightness, _MinimumBrightness)));
          u_xlat0_d = min(u_xlat0_d, float4(float4(_MaximumBrightness, _MaximumBrightness, _MaximumBrightness, _MaximumBrightness)));
          u_xlat1_d = tex2D(_MainTex, in_f.texcoord.xy);
          out_f.color = (u_xlat0_d * u_xlat1_d);
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
