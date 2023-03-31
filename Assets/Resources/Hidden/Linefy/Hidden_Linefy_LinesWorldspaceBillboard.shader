// Upgrade NOTE: commented out 'float3 _WorldSpaceCameraPos', a built-in variable

Shader "Hidden/Linefy/LinesWorldspaceBillboard"
{
  Properties
  {
    _MainTex ("Texture", 2D) = "white" {}
    _TextureScale ("Texture Scale", float) = 1
    _ViewOffset ("_ViewOffset", float) = 0
    _DepthOffset ("_DepthOffset", float) = 0
    _WidthMultiplier ("_WidthMultiplier", float) = 2
    _Color ("_Color", Color) = (1,1,1,1)
    _FadeAlphaDistanceFrom ("FadeAlphaDistanceFrom", float) = 100000
    _FadeAlphaDistanceTo ("FadeAlphaDistanceTo", float) = 100000
    [Enum(UnityEngine.Rendering.CompareFunction)] _zTestCompare ("ZTest", float) = 4
    _AutoTextureOffset ("AutoTextureOffset", float) = 0
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
      
      uniform float4 unity_MatrixV[4];
      
      uniform float4 unity_MatrixInvV[4];
      
      uniform float4 unity_MatrixVP[4];
      
      uniform float _ViewOffset;
      
      uniform float _WidthMultiplier;
      
      uniform float4 _Color;
      
      uniform float _TextureScale;
      
      uniform float _TextureOffset;
      
      uniform float _FadeAlphaDistanceFrom;
      
      uniform float _FadeAlphaDistanceTo;
      
      uniform float _AutoTextureOffset;
      
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
          
          float3 texcoord : TEXCOORD0;
          
          float2 texcoord1 : TEXCOORD1;
          
          float4 color : COLOR0;
          
          float4 vertex : SV_POSITION;
      
      };
      
      
      struct v2f
      {
          
          float3 texcoord : TEXCOORD0;
          
          float4 color : COLOR0;
      
      };
      
      
      struct OUT_Data_Frag
      {
          
          float4 color : SV_Target0;
      
      };
      
      
      float3 u_xlat0;
      
      int u_xlati0;
      
      int u_xlatb0;
      
      float3 u_xlat1;
      
      float4 u_xlat2;
      
      float3 u_xlat3;
      
      int u_xlatb3;
      
      float4 u_xlat4;
      
      int u_xlatb4;
      
      float4 u_xlat5;
      
      float4 u_xlat6;
      
      float4 u_xlat7;
      
      float4 u_xlat8;
      
      float u_xlat9;
      
      int u_xlatb9;
      
      float3 u_xlat11;
      
      float u_xlat12;
      
      float3 u_xlat13;
      
      float u_xlat18;
      
      int u_xlatb22;
      
      float u_xlat27;
      
      int u_xlati27;
      
      int u_xlatb27;
      
      float u_xlat28;
      
      int u_xlatb28;
      
      float u_xlat30;
      
      OUT_Data_Vert vert(appdata_t in_v)
      {
          
          u_xlati0 = int(in_v.texcoord1.y);
          
          u_xlatb0 = u_xlati0==1;
          
          if(u_xlatb0)
      {
              
              out_v.vertex = float4(0.0, 0.0, 0.0, 0.0);
              
              out_v.color = float4(0.0, 0.0, 0.0, 0.0);
              
              out_v.texcoord.xyz = float3(0.0, 0.0, 0.0);
              
              out_v.texcoord1.xy = float2(0.0, 0.0);
              
              return;
      
      }
          
          u_xlat0.xyz = unity_WorldToObject[1].xyz * unity_MatrixInvV[1].yyy;
          
          u_xlat0.xyz = unity_WorldToObject[0].xyz * unity_MatrixInvV[1].xxx + u_xlat0.xyz;
          
          u_xlat0.xyz = unity_WorldToObject[2].xyz * unity_MatrixInvV[1].zzz + u_xlat0.xyz;
          
          u_xlat0.xyz = unity_WorldToObject[3].xyz * unity_MatrixInvV[1].www + u_xlat0.xyz;
          
          u_xlat1.xyz = unity_WorldToObject[1].xyz * unity_MatrixInvV[2].yyy;
          
          u_xlat1.xyz = unity_WorldToObject[0].xyz * unity_MatrixInvV[2].xxx + u_xlat1.xyz;
          
          u_xlat1.xyz = unity_WorldToObject[2].xyz * unity_MatrixInvV[2].zzz + u_xlat1.xyz;
          
          u_xlat1.xyz = unity_WorldToObject[3].xyz * unity_MatrixInvV[2].www + u_xlat1.xyz;
          
          u_xlati27 = int(in_v.texcoord1.x);
          
          u_xlat2 = in_v.vertex.yyyy * unity_ObjectToWorld[1];
          
          u_xlat2 = unity_ObjectToWorld[0] * in_v.vertex.xxxx + u_xlat2;
          
          u_xlat2 = unity_ObjectToWorld[2] * in_v.vertex.zzzz + u_xlat2;
          
          u_xlat2 = u_xlat2 + unity_ObjectToWorld[3];
          
          u_xlat28 = u_xlat2.y * unity_MatrixV[1].z;
          
          u_xlat28 = unity_MatrixV[0].z * u_xlat2.x + u_xlat28;
          
          u_xlat28 = unity_MatrixV[2].z * u_xlat2.z + u_xlat28;
          
          u_xlat28 = unity_MatrixV[3].z * u_xlat2.w + u_xlat28;
          
          u_xlat2 = in_v.normal.yyyy * unity_ObjectToWorld[1];
          
          u_xlat2 = unity_ObjectToWorld[0] * in_v.normal.xxxx + u_xlat2;
          
          u_xlat2 = unity_ObjectToWorld[2] * in_v.normal.zzzz + u_xlat2;
          
          u_xlat2 = u_xlat2 + unity_ObjectToWorld[3];
          
          u_xlat11.x = u_xlat2.y * unity_MatrixV[1].z;
          
          u_xlat2.x = unity_MatrixV[0].z * u_xlat2.x + u_xlat11.x;
          
          u_xlat2.x = unity_MatrixV[2].z * u_xlat2.z + u_xlat2.x;
          
          u_xlat2.x = unity_MatrixV[3].z * u_xlat2.w + u_xlat2.x;
          
          u_xlat11.xyz = _WorldSpaceCameraPos.yyy * unity_WorldToObject[1].xyz;
          
          u_xlat11.xyz = unity_WorldToObject[0].xyz * _WorldSpaceCameraPos.xxx + u_xlat11.xyz;
          
          u_xlat11.xyz = unity_WorldToObject[2].xyz * _WorldSpaceCameraPos.zzz + u_xlat11.xyz;
          
          u_xlat11.xyz = u_xlat11.xyz + unity_WorldToObject[3].xyz;
          
          u_xlat3.xyz = u_xlat11.xyz + (-in_v.vertex.xyz);
          
          u_xlat30 = dot(u_xlat3.xyz, u_xlat3.xyz);
          
          u_xlat30 = sqrt(u_xlat30);
          
          u_xlatb4 = 9.99999975e-05<abs(_ViewOffset);
          
          u_xlat11.xyz = u_xlat11.xyz + (-in_v.normal.xyz);
          
          u_xlat13.x = dot(u_xlat11.xyz, u_xlat11.xyz);
          
          u_xlat13.x = sqrt(u_xlat13.x);
          
          u_xlatb22 = u_xlat30==0.0;
          
          u_xlat5.xyz = u_xlat3.xyz / float3(u_xlat30);
          
          u_xlat3.xyz = (int(u_xlatb22)) ? u_xlat3.xyz : u_xlat5.xyz;
          
          u_xlatb22 = u_xlat13.x==0.0;
          
          u_xlat5.xyz = u_xlat11.xyz / u_xlat13.xxx;
          
          u_xlat11.xyz = (int(u_xlatb22)) ? u_xlat11.xyz : u_xlat5.xyz;
          
          u_xlat13.xyz = u_xlat1.xyz + (-u_xlat3.xyz);
          
          u_xlat3.xyz = unity_OrthoParams.www * u_xlat13.xyz + u_xlat3.xyz;
          
          u_xlat1.xyz = u_xlat1.xyz + (-u_xlat11.xyz);
          
          u_xlat1.xyz = unity_OrthoParams.www * u_xlat1.xyz + u_xlat11.xyz;
          
          u_xlat11.xyz = u_xlat3.xyz * float3(_ViewOffset) + in_v.vertex.xyz;
          
          u_xlat1.xyz = u_xlat1.xyz * float3(_ViewOffset) + in_v.normal.xyz;
          
          u_xlat11.xyz = (int(u_xlatb4)) ? u_xlat11.xyz : in_v.vertex.xyz;
          
          u_xlat1.xyz = (int(u_xlatb4)) ? u_xlat1.xyz : in_v.normal.xyz;
          
          u_xlatb3 = 0.0<u_xlat28;
          
          u_xlat12 = (-u_xlat28) + u_xlat2.x;
          
          u_xlat12 = (-u_xlat28) / u_xlat12;
          
          u_xlat12 = u_xlat12 + 0.00100000005;
          
          u_xlat4.xyz = (-u_xlat11.xyz) + u_xlat1.xyz;
          
          u_xlat4.xyz = float3(u_xlat12) * u_xlat4.xyz + u_xlat11.xyz;
          
          u_xlat11.xyz = (int(u_xlatb3)) ? u_xlat4.xyz : u_xlat11.xyz;
          
          u_xlatb3 = 0.0<u_xlat2.x;
          
          u_xlat28 = u_xlat28 + (-u_xlat2.x);
          
          u_xlat28 = (-u_xlat2.x) / u_xlat28;
          
          u_xlat28 = u_xlat28 + 0.00100000005;
          
          u_xlat4.xyz = (-u_xlat1.xyz) + u_xlat11.xyz;
          
          u_xlat4.xyz = float3(u_xlat28) * u_xlat4.xyz + u_xlat1.xyz;
          
          u_xlat1.xyz = (int(u_xlatb3)) ? u_xlat4.xyz : u_xlat1.xyz;
          
          u_xlat4 = u_xlat11.yyyy * unity_ObjectToWorld[1];
          
          u_xlat4 = unity_ObjectToWorld[0] * u_xlat11.xxxx + u_xlat4;
          
          u_xlat4 = unity_ObjectToWorld[2] * u_xlat11.zzzz + u_xlat4;
          
          u_xlat4 = u_xlat4 + unity_ObjectToWorld[3];
          
          u_xlat5 = u_xlat4.yyyy * unity_MatrixVP[1];
          
          u_xlat5 = unity_MatrixVP[0] * u_xlat4.xxxx + u_xlat5;
          
          u_xlat5 = unity_MatrixVP[2] * u_xlat4.zzzz + u_xlat5;
          
          u_xlat4 = unity_MatrixVP[3] * u_xlat4.wwww + u_xlat5;
          
          u_xlat5 = u_xlat1.yyyy * unity_ObjectToWorld[1];
          
          u_xlat5 = unity_ObjectToWorld[0] * u_xlat1.xxxx + u_xlat5;
          
          u_xlat5 = unity_ObjectToWorld[2] * u_xlat1.zzzz + u_xlat5;
          
          u_xlat5 = u_xlat5 + unity_ObjectToWorld[3];
          
          u_xlat3.xyz = u_xlat5.yyy * unity_MatrixVP[1].xyw;
          
          u_xlat3.xyz = unity_MatrixVP[0].xyw * u_xlat5.xxx + u_xlat3.xyz;
          
          u_xlat3.xyz = unity_MatrixVP[2].xyw * u_xlat5.zzz + u_xlat3.xyz;
          
          u_xlat3.xyz = unity_MatrixVP[3].xyw * u_xlat5.www + u_xlat3.xyz;
          
          u_xlat4.xy = u_xlat4.xy / u_xlat4.ww;
          
          u_xlat4.xy = u_xlat4.xy + float2(1.0, 1.0);
          
          u_xlat4.xy = u_xlat4.xy * _ScreenParams.xy;
          
          u_xlat4.xy = u_xlat4.xy * float2(0.5, 0.5);
          
          u_xlat3.xy = u_xlat3.xy / u_xlat3.zz;
          
          u_xlat3.xy = u_xlat3.xy + float2(1.0, 1.0);
          
          u_xlat3.xy = u_xlat3.xy * _ScreenParams.xy;
          
          u_xlat3.xy = u_xlat3.xy * float2(0.5, 0.5) + (-u_xlat4.xy);
          
          u_xlat28 = dot(u_xlat3.xy, u_xlat3.xy);
          
          u_xlat5.x = sqrt(u_xlat28);
          
          u_xlat6.xy = u_xlat3.xy / u_xlat5.xx;
          
          u_xlat7 = in_v.color * _Color;
          
          u_xlat28 = in_v.texcoord.y * _WidthMultiplier;
          
          u_xlat28 = u_xlat28 * 0.5;
          
          u_xlat0.xyz = u_xlat0.xyz * float3(u_xlat28) + u_xlat11.xyz;
          
          u_xlat8 = u_xlat0.yyyy * unity_ObjectToWorld[1];
          
          u_xlat8 = unity_ObjectToWorld[0] * u_xlat0.xxxx + u_xlat8;
          
          u_xlat8 = unity_ObjectToWorld[2] * u_xlat0.zzzz + u_xlat8;
          
          u_xlat8 = u_xlat8 + unity_ObjectToWorld[3];
          
          u_xlat0.xy = u_xlat8.yy * unity_MatrixVP[1].yw;
          
          u_xlat0.xy = unity_MatrixVP[0].yw * u_xlat8.xx + u_xlat0.xy;
          
          u_xlat0.xy = unity_MatrixVP[2].yw * u_xlat8.zz + u_xlat0.xy;
          
          u_xlat0.xy = unity_MatrixVP[3].yw * u_xlat8.ww + u_xlat0.xy;
          
          u_xlat0.x = u_xlat0.x / u_xlat0.y;
          
          u_xlat0.x = u_xlat0.x + 1.0;
          
          u_xlat0.x = u_xlat0.x * _ScreenParams.y;
          
          u_xlat0.x = (-u_xlat0.x) * 0.5 + u_xlat4.y;
          
          u_xlatb9 = 0.0<_ProjectionParams.x;
          
          u_xlat9 = (u_xlatb9) ? -2.0 : 2.0;
          
          u_xlat8.z = u_xlat4.w * u_xlat0.x;
          
          u_xlat18 = u_xlat30 + (-_FadeAlphaDistanceFrom);
          
          u_xlat28 = (-_FadeAlphaDistanceFrom) + _FadeAlphaDistanceTo;
          
          u_xlat18 = u_xlat18 / u_xlat28;
          
          u_xlat18 = clamp(u_xlat18, 0.0, 1.0);
          
          u_xlat18 = (-u_xlat18) + 1.0;
          
          u_xlat18 = u_xlat18 * u_xlat7.w;
          
          if(u_xlati27 == 0)
      {
              
              u_xlat8.y = in_v.texcoord.x * _TextureScale + _TextureOffset;
              
              u_xlat6.z = (-u_xlat6.x);
              
              u_xlat3.xy = (-u_xlat6.yz) * u_xlat0.xx + u_xlat4.xy;
              
              out_v.texcoord1.y = u_xlat9 * u_xlat0.x;
              
              u_xlat3.xy = u_xlat3.xy / _ScreenParams.xy;
              
              u_xlat3.xy = u_xlat3.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
              
              out_v.vertex.xy = u_xlat4.ww * u_xlat3.xy;
              
              out_v.vertex.zw = u_xlat4.zw;
              
              out_v.color.xyz = u_xlat7.xyz;
              
              out_v.color.w = u_xlat18;
              
              u_xlat8.w = 0.0;
              
              out_v.texcoord.xyz = u_xlat8.ywz;
              
              out_v.texcoord1.x = 0.0;
              
              return;
      
      }
          
          u_xlatb28 = u_xlati27==1;
          
          if(u_xlatb28)
      {
              
              u_xlat8.x = in_v.texcoord.x * _TextureScale + _TextureOffset;
              
              u_xlat6.w = (-u_xlat6.x);
              
              u_xlat3.xy = u_xlat6.yw * u_xlat0.xx + u_xlat4.xy;
              
              out_v.texcoord1.y = u_xlat9 * u_xlat0.x;
              
              u_xlat3.xy = u_xlat3.xy / _ScreenParams.xy;
              
              u_xlat3.xy = u_xlat3.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
              
              out_v.vertex.xy = u_xlat4.ww * u_xlat3.xy;
              
              out_v.vertex.zw = u_xlat4.zw;
              
              out_v.color.xyz = u_xlat7.xyz;
              
              out_v.color.w = u_xlat18;
              
              out_v.texcoord.xyz = u_xlat8.xzz;
              
              out_v.texcoord1.x = 0.0;
              
              return;
      
      }
          
          u_xlatb27 = u_xlati27==2;
          
          if(u_xlatb27)
      {
              
              u_xlat3.xyz = (-u_xlat1.xyz) + u_xlat11.xyz;
              
              u_xlat27 = dot(u_xlat3.xyz, u_xlat3.xyz);
              
              u_xlat27 = sqrt(u_xlat27);
              
              u_xlat27 = u_xlat27 * _AutoTextureOffset + in_v.texcoord.x;
              
              out_v.texcoord.x = u_xlat27 * _TextureScale + _TextureOffset;
              
              u_xlat3.xy = u_xlat6.yx * float2(1.0, -1.0);
              
              u_xlat3.xy = (-u_xlat3.xy) * u_xlat0.xx + u_xlat4.xy;
              
              u_xlat5.y = u_xlat9 * u_xlat0.x;
              
              u_xlat3.xy = u_xlat3.xy / _ScreenParams.xy;
              
              u_xlat3.xy = u_xlat3.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
              
              out_v.vertex.xy = u_xlat4.ww * u_xlat3.xy;
              
              out_v.vertex.zw = u_xlat4.zw;
              
              out_v.color.xyz = u_xlat7.xyz;
              
              out_v.color.w = u_xlat18;
              
              out_v.texcoord.yz = u_xlat8.zz;
              
              out_v.texcoord1.xy = u_xlat5.xy;
              
              return;
      
      }
          
          u_xlat1.xyz = (-u_xlat1.xyz) + u_xlat11.xyz;
          
          u_xlat27 = dot(u_xlat1.xyz, u_xlat1.xyz);
          
          u_xlat27 = sqrt(u_xlat27);
          
          u_xlat27 = u_xlat27 * _AutoTextureOffset + in_v.texcoord.x;
          
          out_v.texcoord.x = u_xlat27 * _TextureScale + _TextureOffset;
          
          u_xlat1.xy = u_xlat6.yx * float2(1.0, -1.0);
          
          u_xlat1.xy = u_xlat1.xy * u_xlat0.xx + u_xlat4.xy;
          
          u_xlat5.z = u_xlat9 * u_xlat0.x;
          
          u_xlat0.xy = u_xlat1.xy / _ScreenParams.xy;
          
          u_xlat0.xy = u_xlat0.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
          
          out_v.vertex.xy = u_xlat4.ww * u_xlat0.xy;
          
          out_v.vertex.zw = u_xlat4.zw;
          
          out_v.color.xyz = u_xlat7.xyz;
          
          out_v.color.w = u_xlat18;
          
          out_v.texcoord.y = 0.0;
          
          out_v.texcoord.z = u_xlat8.z;
          
          out_v.texcoord1.xy = u_xlat5.xz;
          
          return;
      
      }
      
      
      #define CODE_BLOCK_FRAGMENT
      
      float4 u_xlat0_d;
      
      int u_xlatb0_d;
      
      float u_xlat1_d;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d.y = in_f.texcoord.y / in_f.texcoord.z;
          
          u_xlat0_d.x = in_f.texcoord.x;
          
          u_xlat0_d = texture(_MainTex, u_xlat0_d.xy);
          
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
