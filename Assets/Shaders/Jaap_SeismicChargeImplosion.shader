Shader "Jaap/SeismicChargeImplosion"
{
  Properties
  {
    _MainTex ("Texture", 2D) = "white" {}
    _Pattern ("Pattern", 2D) = "white" {}
    [HDR] _Tint ("Tint", Color) = (0,0,0,0)
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
      //uniform float4x4 unity_ObjectToWorld;
      //uniform float4x4 unity_MatrixVP;
      uniform float4 _MainTex_ST;
      //uniform float4 _Time;
      uniform float4 _Tint;
      uniform float _CollapseSpeed;
      uniform sampler2D _MainTex;
      uniform sampler2D _Pattern;
      uniform sampler2D _Mask;
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
          float2 texcoord :TEXCOORD0;
          float4 color :COLOR0;
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
          out_v.texcoord1.x = dot(in_v.vertex, conv_mxt4x4_0(unity_ObjectToWorld));
          out_v.texcoord1.y = dot(in_v.vertex, conv_mxt4x4_1(unity_ObjectToWorld));
          out_v.vertex = UnityObjectToClipPos(in_v.vertex);
          out_v.color = in_v.color;
          return out_v;
      }
      
      #define CODE_BLOCK_FRAGMENT
      float2 u_xlat0_d;
      int u_xlatb0;
      float4 u_xlat1_d;
      int u_xlatb1;
      float4 u_xlat2;
      float3 u_xlat3;
      int u_xlatb3;
      float u_xlat4;
      float u_xlat6;
      int u_xlatb7;
      float u_xlat9;
      int u_xlatb9;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlat0_d.xy = (in_f.texcoord.yx + float2(-0.5, (-0.5)));
          u_xlat6 = length(u_xlat0_d.xy);
          u_xlat9 = ((-u_xlat6) + 0.5);
          u_xlat6 = (((-u_xlat6) * 2) + 1);
          u_xlatb9 = (u_xlat9<0);
          if(((int(u_xlatb9) * int(4294967295))!=0))
          {
              discard;
          }
          u_xlat9 = max(abs(u_xlat0_d.y), abs(u_xlat0_d.x));
          u_xlat9 = (float(1) / u_xlat9);
          u_xlat1_d.x = min(abs(u_xlat0_d.y), abs(u_xlat0_d.x));
          u_xlat9 = (u_xlat9 * u_xlat1_d.x);
          u_xlat1_d.x = (u_xlat9 * u_xlat9);
          u_xlat4 = ((u_xlat1_d.x * 0.0208350997) + (-0.0851330012));
          u_xlat4 = ((u_xlat1_d.x * u_xlat4) + 0.180141002);
          u_xlat4 = ((u_xlat1_d.x * u_xlat4) + (-0.330299497));
          u_xlat1_d.x = ((u_xlat1_d.x * u_xlat4) + 0.999866009);
          u_xlat4 = (u_xlat9 * u_xlat1_d.x);
          u_xlat4 = ((u_xlat4 * (-2)) + 1.57079637);
          u_xlatb7 = (abs(u_xlat0_d.y)<abs(u_xlat0_d.x));
          u_xlat4 = (u_xlatb7)?(u_xlat4):(float(0));
          u_xlat9 = ((u_xlat9 * u_xlat1_d.x) + u_xlat4);
          u_xlatb1 = (u_xlat0_d.y<(-u_xlat0_d.y));
          u_xlat1_d.x = (u_xlatb1)?((-3.14159274)):(float(0));
          u_xlat9 = (u_xlat9 + u_xlat1_d.x);
          u_xlat1_d.x = min(u_xlat0_d.y, u_xlat0_d.x);
          u_xlat0_d.x = max(u_xlat0_d.y, u_xlat0_d.x);
          u_xlatb0 = (u_xlat0_d.x>=(-u_xlat0_d.x));
          u_xlatb3 = (u_xlat1_d.x<(-u_xlat1_d.x));
          u_xlatb0 = (u_xlatb0 && u_xlatb3);
          u_xlat0_d.x = (u_xlatb0)?((-u_xlat9)):(u_xlat9);
          u_xlat3.xz = (_Time.xy * float2(_CollapseSpeed, _CollapseSpeed));
          u_xlat1_d.x = ((u_xlat0_d.x * 0.159154937) + u_xlat3.z);
          u_xlat3.x = ((u_xlat6 * u_xlat6) + (-u_xlat3.x));
          u_xlat6 = (u_xlat6 * u_xlat6);
          u_xlat1_d.y = ((u_xlat0_d.x * 0.159154937) + u_xlat3.x);
          u_xlat1_d = tex2D(_Pattern, u_xlat1_d.xy);
          u_xlat2 = tex2D(_MainTex, in_f.texcoord.xy);
          u_xlat1_d = (u_xlat1_d * u_xlat2);
          u_xlat2 = tex2D(_Mask, in_f.texcoord.xy);
          u_xlat0_d.x = ((-u_xlat2.x) + 1);
          u_xlat1_d = (u_xlat0_d.xxxx * u_xlat1_d);
          u_xlat1_d = (u_xlat1_d * in_f.color);
          u_xlat1_d = (u_xlat1_d * _Tint);
          u_xlat1_d = log2(u_xlat1_d);
          u_xlat1_d = (u_xlat1_d * float4(2.5, 2.5, 2.5, 2.5));
          u_xlat1_d = exp2(u_xlat1_d);
          u_xlat1_d = (u_xlat1_d * _Tint);
          u_xlat0_d.x = (u_xlat6 * u_xlat6);
          u_xlat0_d.x = (u_xlat0_d.x * u_xlat0_d.x);
          u_xlat2 = (_Tint * _Tint);
          u_xlat2 = (u_xlat0_d.xxxx * u_xlat2);
          u_xlat2 = (u_xlat2 * in_f.color);
          out_f.color = ((u_xlat1_d * float4(u_xlat6, u_xlat6, u_xlat6, u_xlat6)) + u_xlat2);
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
