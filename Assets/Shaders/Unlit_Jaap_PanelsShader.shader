Shader "Unlit/Jaap/PanelsShader"
{
  Properties
  {
    [PerRendererData] _MainTex ("Texture", 2D) = "white" {}
    _Panels ("Panels", 2D) = "white" {}
    _PanelSize ("Single panel width and height", float) = 64
    _ColourVariation ("Colour variation", float) = 0.01
    _FadeColour ("Fade colour", Color) = (0.5,0.5,0.5,1)
    _Scale ("Scale", float) = 1
    _Offset ("Offset", Vector) = (0,0,0,0)
    _ScrollingSpeed ("Scroll speed", Vector) = (0,0,0,0)
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
      // m_ProgramMask = 6
      CGPROGRAM
      //#pragma target 4.0
      
      #pragma vertex vert
      #pragma fragment frag
      
      #include "UnityCG.cginc"
      #define conv_mxt4x4_0(mat4x4) float4(mat4x4[0].x,mat4x4[1].x,mat4x4[2].x,mat4x4[3].x)
      #define conv_mxt4x4_1(mat4x4) float4(mat4x4[0].y,mat4x4[1].y,mat4x4[2].y,mat4x4[3].y)
      #define conv_mxt4x4_2(mat4x4) float4(mat4x4[0].z,mat4x4[1].z,mat4x4[2].z,mat4x4[3].z)
      #define conv_mxt4x4_3(mat4x4) float4(mat4x4[0].w,mat4x4[1].w,mat4x4[2].w,mat4x4[3].w)
      
      
      #define CODE_BLOCK_VERTEX
      //uniform float4 _Time;
      //uniform float4x4 unity_ObjectToWorld;
      //uniform float4x4 unity_MatrixVP;
      uniform float4 _MainTex_ST;
      uniform float4 _ScrollingSpeed;
      uniform float4 _Offset;
      uniform float _Scale;
      //uniform float4 unity_OrthoParams;
      uniform float4 _Panels_TexelSize;
      uniform float4 _FadeColour;
      uniform float _PanelSize;
      uniform float _ColourVariation;
      uniform sampler2D _Panels;
      uniform sampler2D _MainTex;
      struct appdata_t
      {
          float4 vertex :POSITION0;
          float2 texcoord :TEXCOORD0;
          float4 color :COLOR0;
      };
      
      struct OUT_Data_Vert
      {
          float2 texcoord :TEXCOORD0;
          float2 texcoord1 :TEXCOORD1;
          float4 color :COLOR0;
          float4 vertex :SV_POSITION;
      };
      
      struct v2f
      {
          float2 texcoord1 :TEXCOORD1;
          float4 color :COLOR0;
      };
      
      struct OUT_Data_Frag
      {
          float4 color :SV_Target0;
      };
      
      float4 u_xlat0;
      float4 u_xlat1;
      float2 u_xlat5;
      OUT_Data_Vert vert(appdata_t in_v)
      {
          OUT_Data_Vert out_v;
          u_xlat0 = (in_v.vertex.yyyy * conv_mxt4x4_1(unity_ObjectToWorld));
          u_xlat0 = ((conv_mxt4x4_0(unity_ObjectToWorld) * in_v.vertex.xxxx) + u_xlat0);
          u_xlat0 = ((conv_mxt4x4_2(unity_ObjectToWorld) * in_v.vertex.zzzz) + u_xlat0);
          u_xlat1.xy = ((conv_mxt4x4_3(unity_ObjectToWorld).xy * in_v.vertex.ww) + u_xlat0.xy);
          u_xlat0 = (u_xlat0 + conv_mxt4x4_3(unity_ObjectToWorld));
          u_xlat1.xy = (u_xlat1.xy + (-_Offset.xy));
          u_xlat5.xy = (_Time.yy * _ScrollingSpeed.xy);
          out_v.texcoord1.xy = ((float2(float2(_Scale, _Scale)) * u_xlat1.xy) + u_xlat5.xy);
          out_v.texcoord.xy = TRANSFORM_TEX(in_v.texcoord.xy, _MainTex);
          out_v.vertex = mul(unity_MatrixVP, u_xlat0);
          out_v.color = in_v.color;
          return out_v;
      }
      
      #define CODE_BLOCK_FRAGMENT
      float u_xlat0_d;
      int u_xlatb0;
      float4 u_xlat1_d;
      float4 u_xlat2;
      float2 u_xlatb2;
      float4 u_xlat3;
      float3 u_xlat4;
      float u_xlat9;
      float2 u_xlat10;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlatb0 = (in_f.color.w<0.5);
          if(u_xlatb0)
          {
              out_f.color = _FadeColour;
              return out_f;
          }
          u_xlat0_d = (unity_OrthoParams.x * 0.0149999997);
          u_xlat0_d = clamp(u_xlat0_d, 0, 1);
          u_xlat4.xyz = ceil(in_f.texcoord1.xyx);
          u_xlat1_d.xy = (_Panels_TexelSize.zw / float2(_PanelSize, _PanelSize));
          u_xlat4.xyz = (u_xlat4.xyz * float3(3.15738511, 3.34235001, 3.34559512));
          u_xlat4.xyz = frac(u_xlat4.xyz);
          u_xlat2.xyz = (u_xlat4.yzx + float3(33.3300018, 33.3300018, 33.3300018));
          u_xlat9 = dot(u_xlat4.zyx, u_xlat2.xyz);
          u_xlat4.xyz = (u_xlat4.xyz + float3(u_xlat9, u_xlat9, u_xlat9));
          u_xlat2.xyz = (u_xlat4.yxx + u_xlat4.zzy);
          u_xlat4.xyz = (u_xlat4.xyz * u_xlat2.xyz);
          u_xlat4.xyz = frac(u_xlat4.xyz);
          u_xlat9 = (float(1) / u_xlat1_d.x);
          u_xlat4.xy = (u_xlat4.xy / float2(u_xlat9, u_xlat9));
          u_xlat4.xy = ceil(u_xlat4.xy);
          u_xlatb2.xy = bool4(in_f.texcoord1.xyxx >= (-in_f.texcoord1.xyxx)).xy;
          u_xlat2.x = (u_xlatb2.x)?(float(1)):(float(-1));
          u_xlat2.y = (u_xlatb2.y)?(float(1)):(float(-1));
          u_xlat10.xy = (u_xlat2.xy * in_f.texcoord1.xy);
          u_xlat10.xy = frac(u_xlat10.xy);
          u_xlat2.xy = (u_xlat10.xy * u_xlat2.xy);
          u_xlat1_d.xy = (u_xlat2.xy / u_xlat1_d.xy);
          u_xlat4.xy = ((u_xlat4.xy * float2(u_xlat9, u_xlat9)) + u_xlat1_d.xy);
          u_xlat2 = tex2D(_Panels, u_xlat4.xy);
          u_xlat2 = (((-u_xlat4.zzzz) * float4(float4(_ColourVariation, _ColourVariation, _ColourVariation, _ColourVariation))) + u_xlat2);
          u_xlat1_d = tex2D(_MainTex, u_xlat1_d.xy);
          u_xlat3 = (u_xlat1_d * u_xlat2);
          u_xlat1_d = (((-u_xlat2) * u_xlat1_d) + _FadeColour);
          out_f.color = ((float4(u_xlat0_d, u_xlat0_d, u_xlat0_d, u_xlat0_d) * u_xlat1_d) + u_xlat3);
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
