Shader "Jaap/Wh"
{
  Properties
  {
    _MainTex ("Texture", 2D) = "white" {}
    _Pattern ("Pattern", 2D) = "white" {}
    _Inside ("Other side", 2D) = "white" {}
    _Tint ("Tint", Color) = (0,0,0,0)
    _GlowMultiplier ("Glow Multiplier", float) = 1
    _CollapseSpeed ("Collapse Speed", float) = 1
  }
  SubShader
  {
    Tags
    { 
      "CanUseSpriteAtlas" = "true"
      "IGNOREPROJECTOR" = "true"
      "PreviewType" = "Plane"
      "QUEUE" = "Transparent"
      "RenderType" = "Transparent"
    }
    Pass // ind: 1, name: 
    {
      Tags
      { 
        "CanUseSpriteAtlas" = "true"
        "IGNOREPROJECTOR" = "true"
        "PreviewType" = "Plane"
        "QUEUE" = "Transparent"
        "RenderType" = "Transparent"
      }
      ZWrite Off
      Cull Off
      Blend One One
      // m_ProgramMask = 6
      CGPROGRAM
      //#pragma target 4.0
      
      #pragma vertex vert
      #pragma fragment frag
      
      #include "UnityCG.cginc"
      #define conv_mxt4x4_0(mat4x4) float4(mat4x4[0].x,mat4x4[1].x,mat4x4[2].x,mat4x4[3].x)
      #define conv_mxt4x4_1(mat4x4) float4(mat4x4[0].y,mat4x4[1].y,mat4x4[2].y,mat4x4[3].y)
      
      
      #define CODE_BLOCK_VERTEX
      //uniform float4 _ScreenParams;
      //uniform float4x4 unity_ObjectToWorld;
      //uniform float4x4 unity_MatrixVP;
      uniform float4 _MainTex_ST;
      //uniform float4 _Time;
      uniform float4 _Tint;
      uniform float _GlowMultiplier;
      uniform float _CollapseSpeed;
      uniform sampler2D _MainTex;
      uniform sampler2D _Pattern;
      uniform sampler2D _Inside;
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
          float4 texcoord2 :TEXCOORD2;
      };
      
      struct OUT_Data_Frag
      {
          float4 color :SV_Target0;
      };
      
      float4 u_xlat0;
      float4 u_xlat1;
      float u_xlat3;
      OUT_Data_Vert vert(appdata_t in_v)
      {
          OUT_Data_Vert out_v;
          out_v.texcoord.xy = TRANSFORM_TEX(in_v.texcoord.xy, _MainTex);
          out_v.texcoord1.x = dot(in_v.vertex, conv_mxt4x4_0(unity_ObjectToWorld));
          out_v.texcoord1.y = dot(in_v.vertex, conv_mxt4x4_1(unity_ObjectToWorld));
          u_xlat0 = UnityObjectToClipPos(in_v.vertex);
          out_v.vertex = u_xlat0;
          u_xlat1.xyz = (u_xlat0.xyw * float3(0.5, 0.5, 0.5));
          u_xlat0.xy = (u_xlat1.zz + u_xlat1.xy);
          u_xlat1.x = (u_xlat0.x + (-0.5));
          u_xlat3 = (_ScreenParams.x / _ScreenParams.y);
          u_xlat0.x = (u_xlat3 * u_xlat1.x);
          out_v.texcoord2 = (u_xlat0 + float4(0.5, 0, 0, 0));
          return out_v;
      }
      
      #define CODE_BLOCK_FRAGMENT
      float4 u_xlat0_d;
      float4 u_xlat1_d;
      float4 u_xlat2;
      float u_xlat3_d;
      int u_xlatb3;
      float3 u_xlat4;
      int u_xlatb4;
      float2 u_xlat6;
      float u_xlat9;
      int u_xlatb9;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlat0_d.xy = (in_f.texcoord.yx + float2(-0.5, (-0.5)));
          u_xlat6.x = max(abs(u_xlat0_d.y), abs(u_xlat0_d.x));
          u_xlat6.x = (float(1) / u_xlat6.x);
          u_xlat9 = min(abs(u_xlat0_d.y), abs(u_xlat0_d.x));
          u_xlat6.x = (u_xlat6.x * u_xlat9);
          u_xlat9 = (u_xlat6.x * u_xlat6.x);
          u_xlat1_d.x = ((u_xlat9 * 0.0208350997) + (-0.0851330012));
          u_xlat1_d.x = ((u_xlat9 * u_xlat1_d.x) + 0.180141002);
          u_xlat1_d.x = ((u_xlat9 * u_xlat1_d.x) + (-0.330299497));
          u_xlat9 = ((u_xlat9 * u_xlat1_d.x) + 0.999866009);
          u_xlat1_d.x = (u_xlat9 * u_xlat6.x);
          u_xlat1_d.x = ((u_xlat1_d.x * (-2)) + 1.57079637);
          u_xlatb4 = (abs(u_xlat0_d.y)<abs(u_xlat0_d.x));
          u_xlat1_d.x = (u_xlatb4)?(u_xlat1_d.x):(float(0));
          u_xlat6.x = ((u_xlat6.x * u_xlat9) + u_xlat1_d.x);
          u_xlatb9 = (u_xlat0_d.y<(-u_xlat0_d.y));
          u_xlat9 = (u_xlatb9)?((-3.14159274)):(float(0));
          u_xlat6.x = (u_xlat9 + u_xlat6.x);
          u_xlat9 = min(u_xlat0_d.y, u_xlat0_d.x);
          u_xlatb9 = (u_xlat9<(-u_xlat9));
          u_xlat1_d.x = max(u_xlat0_d.y, u_xlat0_d.x);
          u_xlat0_d.x = length(u_xlat0_d.xy);
          u_xlat0_d.x = (((-u_xlat0_d.x) * 4) + 1);
          u_xlatb3 = (u_xlat1_d.x>=(-u_xlat1_d.x));
          u_xlatb3 = (u_xlatb3 && u_xlatb9);
          u_xlat3_d = (u_xlatb3)?((-u_xlat6.x)):(u_xlat6.x);
          u_xlat6.xy = (_Time.xy * float2(float2(_CollapseSpeed, _CollapseSpeed)));
          u_xlat1_d.x = ((u_xlat3_d * 0.159154937) + u_xlat6.y);
          u_xlat9 = (u_xlat0_d.x * u_xlat0_d.x);
          u_xlat6.x = ((u_xlat0_d.x * u_xlat9) + (-u_xlat6.x));
          u_xlat0_d.x = (u_xlat9 * u_xlat0_d.x);
          u_xlat1_d.y = ((u_xlat3_d * 0.159154937) + u_xlat6.x);
          u_xlat1_d = tex2D(_Pattern, u_xlat1_d.xy);
          u_xlat2 = tex2D(_MainTex, in_f.texcoord.xy);
          u_xlat1_d = (u_xlat1_d * u_xlat2);
          u_xlat2 = (u_xlat1_d * _Tint);
          u_xlat2 = log2(u_xlat2);
          u_xlat2 = (u_xlat2 * float4(2.5, 2.5, 2.5, 2.5));
          u_xlat2 = exp2(u_xlat2);
          u_xlat2 = (u_xlat2 * float4(_GlowMultiplier, _GlowMultiplier, _GlowMultiplier, _GlowMultiplier));
          u_xlat2 = (u_xlat0_d.xxxx * u_xlat2);
          u_xlat0_d.x = (u_xlat0_d.x * u_xlat0_d.x);
          u_xlat0_d.x = (u_xlat0_d.x * u_xlat0_d.x);
          u_xlat0_d.x = (u_xlat0_d.x * _GlowMultiplier);
          u_xlat0_d = (u_xlat0_d.xxxx * _Tint);
          u_xlat0_d = ((u_xlat2 * float4(4, 4, 4, 4)) + u_xlat0_d);
          u_xlat1_d.x = (((-u_xlat1_d.x) * 0.5) + 0.800000012);
          u_xlat4.xz = ((-in_f.texcoord.xy) + in_f.texcoord2.xy);
          u_xlat1_d.xy = ((u_xlat1_d.xx * u_xlat4.xz) + in_f.texcoord.xy);
          u_xlat2 = tex2D(_Inside, u_xlat1_d.xy);
          u_xlat2 = ((-u_xlat0_d) + u_xlat2);
          out_f.color = ((u_xlat1_d.zzzz * u_xlat2) + u_xlat0_d);
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
