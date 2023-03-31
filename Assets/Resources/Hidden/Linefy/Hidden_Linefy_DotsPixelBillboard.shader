// Upgrade NOTE: commented out 'float3 _WorldSpaceCameraPos', a built-in variable

Shader "Hidden/Linefy/DotsPixelBillboard"
{
  Properties
  {
    _MainTex ("Texture", 2D) = "white" {}
    _ViewOffset ("_ViewOffset", float) = 0
    _DepthOffset ("_DepthOffset", float) = 0
    _WidthMultiplier ("_WidthMultiplier", float) = 2
    _Color ("_Color", Color) = (1,1,1,1)
    _FadeAlphaDistanceFrom ("FadeAlphaDistanceFrom", float) = 0
    _FadeAlphaDistanceTo ("FadeAlphaDistanceTo", float) = 1000000
    [Enum(UnityEngine.Rendering.CompareFunction)] _zTestCompare ("ZTest", float) = 4
    _PersentOfScreenHeightMode ("PersentOfScreenHeightMode", float) = 0
  }
  SubShader
  {
    Tags
    { 
      "DisableBatching" = "true"
      "FORCENOSHADOWCASTING" = "true"
      "IGNOREPROJECTOR" = "true"
      "QUEUE" = "Geometry"
      "RenderType" = "Opaque"
    }
    Pass // ind: 1, name: 
    {
      Tags
      { 
        "DisableBatching" = "true"
        "FORCENOSHADOWCASTING" = "true"
        "IGNOREPROJECTOR" = "true"
        "QUEUE" = "Geometry"
        "RenderType" = "Opaque"
      }
      Cull Off
      Fog
      { 
        Mode  Off
      } 
      // m_ProgramMask = 6
      CGPROGRAM
      //#pragma target 4.0
      
      #pragma vertex vert
      #pragma fragment frag
      
      #include "UnityCG.cginc"
      
      
      #define CODE_BLOCK_VERTEX
      
      
      // uniform float3 _WorldSpaceCameraPos;
      
      uniform float4 _ProjectionParams;
      
      uniform float4 _ScreenParams;
      
      uniform float4 unity_OrthoParams;
      
      uniform float4 unity_ObjectToWorld[4];
      
      uniform float4 unity_WorldToObject[4];
      
      uniform float4 unity_MatrixInvV[4];
      
      uniform float4 unity_MatrixVP[4];
      
      uniform float _ViewOffset;
      
      uniform float _WidthMultiplier;
      
      uniform float4 _Color;
      
      uniform float _FadeAlphaDistanceFrom;
      
      uniform float _FadeAlphaDistanceTo;
      
      uniform float _PersentOfScreenHeightMode;
      
      uniform sampler2D _MainTex;
      
      
      
      struct appdata_t
      {
          
          float3 vertex : POSITION0;
          
          float3 normal : NORMAL0;
          
          float4 color : COLOR0;
          
          float3 texcoord : TEXCOORD0;
          
          float3 texcoord1 : TEXCOORD1;
      
      };
      
      
      struct OUT_Data_Vert
      {
          
          float2 texcoord : TEXCOORD0;
          
          float4 color : COLOR0;
          
          float4 vertex : SV_POSITION;
      
      };
      
      
      struct v2f
      {
          
          float2 texcoord : TEXCOORD0;
          
          float4 color : COLOR0;
      
      };
      
      
      struct OUT_Data_Frag
      {
          
          float4 color : SV_Target0;
      
      };
      
      
      float3 u_xlat0;
      
      int u_xlatb0;
      
      float4 u_xlat1;
      
      float4 u_xlat2;
      
      int u_xlatb2;
      
      float4 u_xlat3;
      
      float3 u_xlat4;
      
      float2 u_xlat6;
      
      float3 u_xlat7;
      
      float u_xlat10;
      
      int u_xlatb10;
      
      float u_xlat15;
      
      int u_xlatb16;
      
      OUT_Data_Vert vert(appdata_t in_v)
      {
          
          u_xlatb0 = 0.0>=in_v.normal.z;
          
          if(u_xlatb0)
      {
              
              out_v.vertex = float4(0.0, 0.0, 0.0, 0.0);
              
              out_v.color = float4(0.0, 0.0, 0.0, 0.0);
              
              out_v.texcoord.xy = float2(0.0, 0.0);
              
              return;
      
      }
          
          u_xlat0.xyz = unity_WorldToObject[1].xyz * unity_MatrixInvV[2].yyy;
          
          u_xlat0.xyz = unity_WorldToObject[0].xyz * unity_MatrixInvV[2].xxx + u_xlat0.xyz;
          
          u_xlat0.xyz = unity_WorldToObject[2].xyz * unity_MatrixInvV[2].zzz + u_xlat0.xyz;
          
          u_xlat0.xyz = unity_WorldToObject[3].xyz * unity_MatrixInvV[2].www + u_xlat0.xyz;
          
          u_xlat1.xyz = _WorldSpaceCameraPos.yyy * unity_WorldToObject[1].xyz;
          
          u_xlat1.xyz = unity_WorldToObject[0].xyz * _WorldSpaceCameraPos.xxx + u_xlat1.xyz;
          
          u_xlat1.xyz = unity_WorldToObject[2].xyz * _WorldSpaceCameraPos.zzz + u_xlat1.xyz;
          
          u_xlat1.xyz = u_xlat1.xyz + unity_WorldToObject[3].xyz;
          
          u_xlat1.xyz = u_xlat1.xyz + (-in_v.vertex.xyz);
          
          u_xlat15 = dot(u_xlat1.xyz, u_xlat1.xyz);
          
          u_xlat15 = sqrt(u_xlat15);
          
          u_xlatb16 = 9.99999975e-05<abs(_ViewOffset);
          
          u_xlatb2 = u_xlat15==0.0;
          
          u_xlat7.xyz = u_xlat1.xyz / float3(u_xlat15);
          
          u_xlat1.xyz = (int(u_xlatb2)) ? u_xlat1.xyz : u_xlat7.xyz;
          
          u_xlat0.xyz = u_xlat0.xyz + (-u_xlat1.xyz);
          
          u_xlat0.xyz = unity_OrthoParams.www * u_xlat0.xyz + u_xlat1.xyz;
          
          u_xlat0.xyz = u_xlat0.xyz * float3(_ViewOffset) + in_v.vertex.xyz;
          
          u_xlat0.xyz = (int(u_xlatb16)) ? u_xlat0.xyz : in_v.vertex.xyz;
          
          u_xlat1.x = _ScreenParams.y * _WidthMultiplier;
          
          u_xlat1.x = u_xlat1.x * 0.00999999978 + (-_WidthMultiplier);
          
          u_xlat1.x = _PersentOfScreenHeightMode * u_xlat1.x + _WidthMultiplier;
          
          u_xlat2 = u_xlat0.yyyy * unity_ObjectToWorld[1];
          
          u_xlat2 = unity_ObjectToWorld[0] * u_xlat0.xxxx + u_xlat2;
          
          u_xlat2 = unity_ObjectToWorld[2] * u_xlat0.zzzz + u_xlat2;
          
          u_xlat2 = u_xlat2 + unity_ObjectToWorld[3];
          
          u_xlat3 = u_xlat2.yyyy * unity_MatrixVP[1];
          
          u_xlat3 = unity_MatrixVP[0] * u_xlat2.xxxx + u_xlat3;
          
          u_xlat3 = unity_MatrixVP[2] * u_xlat2.zzzz + u_xlat3;
          
          u_xlat2 = unity_MatrixVP[3] * u_xlat2.wwww + u_xlat3;
          
          u_xlat0.xy = u_xlat2.xy / u_xlat2.ww;
          
          u_xlat0.xy = u_xlat0.xy + float2(1.0, 1.0);
          
          u_xlat0.xy = u_xlat0.xy * _ScreenParams.xy;
          
          u_xlat6.xy = in_v.texcoord1.xy * _ScreenParams.yy;
          
          u_xlat6.xy = u_xlat6.xy * float2(0.00999999978, 0.00999999978) + (-in_v.texcoord1.xy);
          
          u_xlat3.xy = float2(float2(_PersentOfScreenHeightMode, _PersentOfScreenHeightMode)) * u_xlat6.xy + in_v.texcoord1.xy;
          
          u_xlatb10 = 0.0<_ProjectionParams.x;
          
          u_xlat2.y = (-u_xlat3.y);
          
          u_xlat2.x = (-in_v.normal.y);
          
          u_xlat3.z = in_v.normal.y;
          
          u_xlat4.xy = (int(u_xlatb10)) ? u_xlat2.xy : u_xlat3.zy;
          
          u_xlat4.z = in_v.normal.x;
          
          u_xlat6.xy = u_xlat4.zx * in_v.normal.zz;
          
          u_xlat1.xy = u_xlat1.xx * u_xlat6.xy;
          
          u_xlat0.xy = u_xlat0.xy * float2(0.5, 0.5) + u_xlat1.xy;
          
          u_xlat3.w = u_xlat4.y;
          
          u_xlat0.xy = u_xlat0.xy + u_xlat3.xw;
          
          u_xlat1 = in_v.color * _Color;
          
          u_xlat10 = u_xlat15 + (-_FadeAlphaDistanceFrom);
          
          u_xlat15 = (-_FadeAlphaDistanceFrom) + _FadeAlphaDistanceTo;
          
          u_xlat10 = u_xlat10 / u_xlat15;
          
          u_xlat10 = clamp(u_xlat10, 0.0, 1.0);
          
          u_xlat10 = (-u_xlat10) + 1.0;
          
          out_v.color.w = u_xlat10 * u_xlat1.w;
          
          u_xlat0.xy = u_xlat0.xy / _ScreenParams.xy;
          
          u_xlat0.xy = u_xlat0.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
          
          out_v.vertex.xy = u_xlat2.ww * u_xlat0.xy;
          
          out_v.vertex.zw = u_xlat2.zw;
          
          out_v.color.xyz = u_xlat1.xyz;
          
          out_v.texcoord.xy = in_v.texcoord.xy;
          
          return;
      
      }
      
      
      #define CODE_BLOCK_FRAGMENT
      
      float4 u_xlat0_d;
      
      int u_xlatb0_d;
      
      float u_xlat1_d;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = texture(_MainTex, in_f.texcoord.xy);
          
          u_xlat1_d = u_xlat0_d.w * in_f.color.w + -0.5;
          
          u_xlat0_d = u_xlat0_d * in_f.color;
          
          out_f.color = u_xlat0_d;
          
          u_xlatb0_d = u_xlat1_d<0.0;
          
          if(((int(u_xlatb0_d) * int(0xffffffffu)))!=0)
      {
              discard;
      }
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
