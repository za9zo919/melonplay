Shader "Unlit/BurnedShader"
{
  Properties
  {
    [PerRendererData] _MainTex ("Texture", 2D) = "white" {}
    _BurnProgress ("Burn Progress Map", 2D) = "white" {}
    _Progress ("Progress", Range(0, 1)) = 0
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
      //uniform float4 _Time;
      uniform float _Progress;
      uniform sampler2D _BurnProgress;
      uniform sampler2D _MainTex;
      struct appdata_t
      {
          float2 texcoord :TEXCOORD0;
          float4 vertex :POSITION0;
      };
      
      struct OUT_Data_Vert
      {
          float2 texcoord :TEXCOORD0;
          float2 texcoord1 :TEXCOORD1;
          float4 vertex :SV_POSITION;
      };
      
      struct v2f
      {
          float2 texcoord :TEXCOORD0;
          float2 texcoord1 :TEXCOORD1;
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
          out_v.texcoord.xy = in_v.texcoord.xy;
          out_v.texcoord1.xy = (in_v.vertex.xy * float2(0.5, 0.5));
          out_v.vertex = UnityObjectToClipPos(in_v.vertex);
          return out_v;
      }
      
      #define CODE_BLOCK_FRAGMENT
      float4 u_xlat0_d;
      float4 u_xlat1_d;
      float u_xlat2;
      float u_xlat4;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlat0_d = tex2D(_BurnProgress, in_f.texcoord1.xy);
          u_xlat4 = (u_xlat0_d.z * 512);
          u_xlat4 = ((_Time.z * 1.5) + u_xlat4);
          u_xlat4 = sin(u_xlat4);
          u_xlat4 = ((u_xlat4 * 0.5) + 0.5);
          u_xlat2 = (u_xlat0_d.y * u_xlat4);
          u_xlat0_d.x = (u_xlat0_d.x + (-_Progress));
          u_xlat4 = (_Progress * (-0.899999976));
          u_xlat4 = (float(1) / u_xlat4);
          u_xlat0_d.x = (u_xlat4 * u_xlat0_d.x);
          u_xlat0_d.x = clamp(u_xlat0_d.x, 0, 1);
          u_xlat4 = ((u_xlat0_d.x * (-2)) + 3);
          u_xlat0_d.x = (u_xlat0_d.x * u_xlat0_d.x);
          u_xlat0_d.x = (((-u_xlat4) * u_xlat0_d.x) + 1);
          u_xlat4 = ((-u_xlat0_d.x) + 1);
          u_xlat2 = (u_xlat4 * u_xlat2);
          u_xlat2 = (u_xlat2 * u_xlat2);
          u_xlat1_d = tex2D(_MainTex, in_f.texcoord.xy);
          u_xlat0_d.xzw = (u_xlat0_d.xxx * u_xlat1_d.xyz);
          out_f.color.w = u_xlat1_d.w;
          out_f.color.xy = ((float2(u_xlat2, u_xlat2) * float2(64, 16)) + u_xlat0_d.xz);
          out_f.color.z = u_xlat0_d.w;
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
