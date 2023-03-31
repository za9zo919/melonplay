// Upgrade NOTE: commented out 'float3 _WorldSpaceCameraPos', a built-in variable

Shader "Hidden/Linefy/PolylineTransparentPixelBillboard"
{
  Properties
  {
    _MainTex ("Texture", 2D) = "white" {}
    _TextureOffset ("Texture Offset", float) = 0
    _TextureScale ("Texture Scale", float) = 1
    _ViewOffset ("_ViewOffset", float) = 0
    _Feather ("_Feather", float) = 1
    _DepthOffset ("_DepthOffset", float) = 0
    _WidthMultiplier ("_WidthMultiplier", float) = 2
    _Color ("_Color", Color) = (1,1,1,1)
    [Enum(UnityEngine.Rendering.CompareFunction)] _zTestCompare ("ZTest", float) = 4
    _FadeAlphaDistanceFrom ("FadeAlphaDistanceFrom", float) = 100000
    _FadeAlphaDistanceTo ("FadeAlphaDistanceTo", float) = 100000
    _PersentOfScreenHeightMode ("PersentOfScreenHeightMode", float) = 0
  }
  SubShader
  {
    Tags
    { 
      "DisableBatching" = "true"
      "FORCENOSHADOWCASTING" = "true"
      "IGNOREPROJECTOR" = "true"
      "QUEUE" = "Transparent"
      "RenderType" = "Transparent"
    }
    Pass // ind: 1, name: 
    {
      Tags
      { 
        "DisableBatching" = "true"
        "FORCENOSHADOWCASTING" = "true"
        "IGNOREPROJECTOR" = "true"
        "QUEUE" = "Transparent"
        "RenderType" = "Transparent"
      }
      ZWrite Off
      Cull Off
      Fog
      { 
        Mode  Off
      } 
      Blend SrcAlpha OneMinusSrcAlpha
      // m_ProgramMask = 6
      CGPROGRAM
      //#pragma target 4.0
      
      #pragma vertex vert
      #pragma fragment frag
      
      #include "UnityCG.cginc"
      
      
      #define CODE_BLOCK_VERTEX
      
      
      // uniform float3 _WorldSpaceCameraPos;
      
      uniform float4 _ScreenParams;
      
      uniform float4 unity_OrthoParams;
      
      uniform float4 unity_ObjectToWorld[4];
      
      uniform float4 unity_WorldToObject[4];
      
      uniform float4 unity_MatrixInvV[4];
      
      uniform float4 unity_MatrixVP[4];
      
      uniform float _ViewOffset;
      
      uniform float _WidthMultiplier;
      
      uniform float4 _Color;
      
      uniform float _TextureScale;
      
      uniform float _TextureOffset;
      
      uniform float _FadeAlphaDistanceFrom;
      
      uniform float _FadeAlphaDistanceTo;
      
      uniform float _PersentOfScreenHeightMode;
      
      uniform float4 _ProjectionParams;
      
      uniform float _Feather;
      
      uniform sampler2D _MainTex;
      
      
      
      struct appdata_t
      {
          
          float3 vertex : POSITION0;
          
          float3 normal : NORMAL0;
          
          float4 tangent : TANGENT0;
          
          float4 color : COLOR0;
          
          float3 texcoord : TEXCOORD0;
          
          float3 texcoord1 : TEXCOORD1;
          
          float3 texcoord2 : TEXCOORD2;
          
          float4 texcoord3 : TEXCOORD3;
      
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
          
          float2 texcoord1 : TEXCOORD1;
          
          float4 color : COLOR0;
      
      };
      
      
      struct OUT_Data_Frag
      {
          
          float4 color : SV_Target0;
      
      };
      
      
      float3 u_xlat0;
      
      int u_xlati0;
      
      int u_xlatb0;
      
      float4 u_xlat1;
      
      int u_xlatb1;
      
      float4 u_xlat2;
      
      float4 u_xlat3;
      
      float4 u_xlat4;
      
      float4 u_xlat5;
      
      float4 u_xlat6;
      
      int u_xlatb6;
      
      float4 u_xlat7;
      
      float4 u_xlat8;
      
      float4 u_xlat9;
      
      float u_xlat10;
      
      float3 u_xlat11;
      
      float4 u_xlat12;
      
      int u_xlati12;
      
      int u_xlatb12;
      
      float4 u_xlat13;
      
      float3 u_xlat14;
      
      int u_xlati14;
      
      int u_xlatb14;
      
      float2 u_xlat15;
      
      float2 u_xlat20;
      
      int u_xlatb20;
      
      float u_xlat24;
      
      int u_xlatb24;
      
      float2 u_xlat26;
      
      float2 u_xlat28;
      
      int u_xlati28;
      
      int u_xlatb28;
      
      float u_xlat29;
      
      float2 u_xlat31;
      
      float2 u_xlat32;
      
      int u_xlatb32;
      
      float u_xlat34;
      
      float2 u_xlat38;
      
      float u_xlat42;
      
      int u_xlatb42;
      
      float u_xlat43;
      
      int u_xlatb44;
      
      float u_xlat46;
      
      int u_xlatb46;
      
      float u_xlat47;
      
      float u_xlat51;
      
      float u_xlat53;
      
      int u_xlati53;
      
      float u_xlat54;
      
      OUT_Data_Vert vert(appdata_t in_v)
      {
          
          u_xlatb0 = in_v.texcoord1.y==2.0;
          
          if(u_xlatb0)
      {
              
              out_v.vertex = float4(0.0, 0.0, 0.0, 0.0);
              
              out_v.color = float4(0.0, 0.0, 0.0, 0.0);
              
              out_v.texcoord.xyz = float3(0.0, 0.0, 0.0);
              
              out_v.texcoord1.xy = float2(0.0, 0.0);
              
              return;
      
      }
          
          u_xlati0 = int(in_v.texcoord1.x);
          
          u_xlati14 = int((0<u_xlati0) ? 0xFFFFFFFFu : uint(0));
          
          u_xlati28 = int((u_xlati0<0) ? 0xFFFFFFFFu : uint(0));
          
          u_xlati14 = (-u_xlati14) + u_xlati28;
          
          u_xlat14.x = float(u_xlati14);
          
          u_xlat1.xyz = _WorldSpaceCameraPos.yyy * unity_WorldToObject[1].xyz;
          
          u_xlat1.xyz = unity_WorldToObject[0].xyz * _WorldSpaceCameraPos.xxx + u_xlat1.xyz;
          
          u_xlat1.xyz = unity_WorldToObject[2].xyz * _WorldSpaceCameraPos.zzz + u_xlat1.xyz;
          
          u_xlat1.xyz = u_xlat1.xyz + unity_WorldToObject[3].xyz;
          
          u_xlat2.xyz = u_xlat1.xyz + (-in_v.vertex.xyz);
          
          u_xlat28.x = dot(u_xlat2.xyz, u_xlat2.xyz);
          
          u_xlat28.x = sqrt(u_xlat28.x);
          
          u_xlatb42 = 9.99999975e-05<abs(_ViewOffset);
          
          if(u_xlatb42)
      {
              
              u_xlat3.xyz = unity_WorldToObject[1].xyz * unity_MatrixInvV[2].yyy;
              
              u_xlat3.xyz = unity_WorldToObject[0].xyz * unity_MatrixInvV[2].xxx + u_xlat3.xyz;
              
              u_xlat3.xyz = unity_WorldToObject[2].xyz * unity_MatrixInvV[2].zzz + u_xlat3.xyz;
              
              u_xlat3.xyz = unity_WorldToObject[3].xyz * unity_MatrixInvV[2].www + u_xlat3.xyz;
              
              u_xlat4.xyz = u_xlat1.xyz + (-in_v.tangent.xyz);
              
              u_xlat1.xyz = u_xlat1.xyz + (-in_v.normal.xyz);
              
              u_xlat42 = dot(u_xlat4.xyz, u_xlat4.xyz);
              
              u_xlat42 = sqrt(u_xlat42);
              
              u_xlat43 = dot(u_xlat1.xyz, u_xlat1.xyz);
              
              u_xlat43 = sqrt(u_xlat43);
              
              u_xlatb44 = u_xlat42==0.0;
              
              u_xlat5.xyz = u_xlat4.xyz / float3(u_xlat42);
              
              u_xlat4.xyz = (int(u_xlatb44)) ? u_xlat4.xyz : u_xlat5.xyz;
              
              u_xlatb42 = u_xlat43==0.0;
              
              u_xlat5.xyz = u_xlat1.xyz / float3(u_xlat43);
              
              u_xlat1.xyz = (int(u_xlatb42)) ? u_xlat1.xyz : u_xlat5.xyz;
              
              u_xlat5.xyz = u_xlat3.xyz + (-u_xlat4.xyz);
              
              u_xlat4.xyz = unity_OrthoParams.www * u_xlat5.xyz + u_xlat4.xyz;
              
              u_xlatb42 = u_xlat28.x==0.0;
              
              u_xlat5.xyz = u_xlat2.xyz / u_xlat28.xxx;
              
              u_xlat2.xyz = (int(u_xlatb42)) ? u_xlat2.xyz : u_xlat5.xyz;
              
              u_xlat5.xyz = (-u_xlat2.xyz) + u_xlat3.xyz;
              
              u_xlat2.xyz = unity_OrthoParams.www * u_xlat5.xyz + u_xlat2.xyz;
              
              u_xlat2.xyz = u_xlat2.xyz * float3(_ViewOffset) + in_v.vertex.xyz;
              
              u_xlat3.xyz = (-u_xlat1.xyz) + u_xlat3.xyz;
              
              u_xlat1.xyz = unity_OrthoParams.www * u_xlat3.xyz + u_xlat1.xyz;
              
              u_xlat3.xyz = u_xlat4.xyz * float3(_ViewOffset) + in_v.tangent.xyz;
              
              u_xlat1.xyz = u_xlat1.xyz * float3(_ViewOffset) + in_v.normal.xyz;
      
      }
          else
          
              {
              
              u_xlat3.xyz = in_v.tangent.xyz;
              
              u_xlat2.xyz = in_v.vertex.xyz;
              
              u_xlat1.xyz = in_v.normal.xyz;
      
      }
          
          u_xlat4 = u_xlat2.yyyy * unity_ObjectToWorld[1];
          
          u_xlat4 = unity_ObjectToWorld[0] * u_xlat2.xxxx + u_xlat4;
          
          u_xlat2 = unity_ObjectToWorld[2] * u_xlat2.zzzz + u_xlat4;
          
          u_xlat2 = u_xlat2 + unity_ObjectToWorld[3];
          
          u_xlat4 = u_xlat2.yyyy * unity_MatrixVP[1];
          
          u_xlat4 = unity_MatrixVP[0] * u_xlat2.xxxx + u_xlat4;
          
          u_xlat4 = unity_MatrixVP[2] * u_xlat2.zzzz + u_xlat4;
          
          u_xlat2 = unity_MatrixVP[3] * u_xlat2.wwww + u_xlat4;
          
          u_xlat4.xy = in_v.texcoord2.xy * float2(float2(_WidthMultiplier, _WidthMultiplier));
          
          u_xlat4.xy = u_xlat4.xy * float2(0.5, 0.5);
          
          u_xlat42 = _ScreenParams.y * _WidthMultiplier;
          
          u_xlat32.xy = float2(u_xlat42) * in_v.texcoord2.xy;
          
          u_xlat32.xy = u_xlat32.xy * float2(0.00499999989, 0.00499999989) + (-u_xlat4.xy);
          
          u_xlat4.yz = float2(_PersentOfScreenHeightMode) * u_xlat32.xy + u_xlat4.xy;
          
          u_xlat14.x = u_xlat14.x + 1.0;
          
          u_xlat4.x = u_xlat14.x * 0.5;
          
          u_xlat14.xz = (-u_xlat4.yz) + u_xlat4.zy;
          
          u_xlat14.xz = u_xlat4.xx * u_xlat14.xz + u_xlat4.yz;
          
          u_xlat5.x = in_v.texcoord.x * _TextureScale + _TextureOffset;
          
          u_xlat6.w = u_xlat2.w * u_xlat14.x;
          
          u_xlat7 = in_v.color * _Color;
          
          u_xlat14.x = u_xlat28.x + (-_FadeAlphaDistanceFrom);
          
          u_xlat28.x = (-_FadeAlphaDistanceFrom) + _FadeAlphaDistanceTo;
          
          u_xlat14.x = u_xlat14.x / u_xlat28.x;
          
          u_xlat14.x = clamp(u_xlat14.x, 0.0, 1.0);
          
          u_xlat14.x = (-u_xlat14.x) + 1.0;
          
          u_xlat7.w = u_xlat14.x * u_xlat7.w;
          
          u_xlatb14 = u_xlati0==int(0xFFFFFFFFu);
          
          if(u_xlatb14)
      {
              
              out_v.vertex = u_xlat2;
              
              out_v.color = u_xlat7;
              
              u_xlat5.yz = u_xlat6.ww * float2(0.5, 1.0);
              
              out_v.texcoord.xyz = u_xlat5.xyz;
              
              out_v.texcoord1.xy = u_xlat4.xy;
              
              return;
      
      }
          
          u_xlat8.w = u_xlat2.w * u_xlat14.z;
          
          u_xlatb14 = u_xlati0==1;
          
          if(u_xlatb14)
      {
              
              out_v.vertex = u_xlat2;
              
              out_v.color = u_xlat7;
              
              u_xlat8.x = u_xlat5.x;
              
              u_xlat8.y = u_xlat8.w * 0.5;
              
              out_v.texcoord.xyz = u_xlat8.xyw;
              
              out_v.texcoord1.xy = u_xlat4.xy;
              
              return;
      
      }
          
          u_xlatb14 = in_v.texcoord1.y==1.0;
          
          u_xlat9 = u_xlat3.yyyy * unity_ObjectToWorld[1];
          
          u_xlat9 = unity_ObjectToWorld[0] * u_xlat3.xxxx + u_xlat9;
          
          u_xlat3 = unity_ObjectToWorld[2] * u_xlat3.zzzz + u_xlat9;
          
          u_xlat3 = u_xlat3 + unity_ObjectToWorld[3];
          
          u_xlat9.xyz = u_xlat3.yyy * unity_MatrixVP[1].xyw;
          
          u_xlat9.xyz = unity_MatrixVP[0].xyw * u_xlat3.xxx + u_xlat9.xyz;
          
          u_xlat3.xyz = unity_MatrixVP[2].xyw * u_xlat3.zzz + u_xlat9.xyz;
          
          u_xlat3.xyz = unity_MatrixVP[3].xyw * u_xlat3.www + u_xlat3.xyz;
          
          u_xlat9 = u_xlat1.yyyy * unity_ObjectToWorld[1];
          
          u_xlat9 = unity_ObjectToWorld[0] * u_xlat1.xxxx + u_xlat9;
          
          u_xlat1 = unity_ObjectToWorld[2] * u_xlat1.zzzz + u_xlat9;
          
          u_xlat1 = u_xlat1 + unity_ObjectToWorld[3];
          
          u_xlat9.xyz = u_xlat1.yyy * unity_MatrixVP[1].xyw;
          
          u_xlat9.xyz = unity_MatrixVP[0].xyw * u_xlat1.xxx + u_xlat9.xyz;
          
          u_xlat1.xyz = unity_MatrixVP[2].xyw * u_xlat1.zzz + u_xlat9.xyz;
          
          u_xlat1.xyz = unity_MatrixVP[3].xyw * u_xlat1.www + u_xlat1.xyz;
          
          u_xlat28.xy = u_xlat3.xy / u_xlat3.zz;
          
          u_xlat28.xy = u_xlat28.xy + float2(1.0, 1.0);
          
          u_xlat28.xy = u_xlat28.xy * _ScreenParams.xy;
          
          u_xlat28.xy = u_xlat28.xy * float2(0.5, 0.5);
          
          u_xlat2.xy = u_xlat2.xy / u_xlat2.ww;
          
          u_xlat2.xy = u_xlat2.xy + float2(1.0, 1.0);
          
          u_xlat2.xy = u_xlat2.xy * _ScreenParams.xy;
          
          u_xlat3.xy = u_xlat2.xy * float2(0.5, 0.5);
          
          u_xlat1.xy = u_xlat1.xy / u_xlat1.zz;
          
          u_xlat1.xy = u_xlat1.xy + float2(1.0, 1.0);
          
          u_xlat1.xy = u_xlat1.xy * _ScreenParams.xy;
          
          u_xlat29 = in_v.texcoord.y * _TextureScale + _TextureOffset;
          
          u_xlat31.xy = u_xlat2.xy * float2(0.5, 0.5) + (-u_xlat28.xy);
          
          u_xlat43 = dot(u_xlat31.xy, u_xlat31.xy);
          
          u_xlat32.x = sqrt(u_xlat43);
          
          u_xlatb46 = u_xlat32.x<0.00100000005;
          
          u_xlat9.xy = u_xlat31.xy / u_xlat32.xx;
          
          u_xlat9.xy = (int(u_xlatb46)) ? u_xlat31.xy : u_xlat9.xy;
          
          u_xlat1.xy = u_xlat1.xy * float2(0.5, 0.5) + (-u_xlat3.xy);
          
          u_xlat51 = dot(u_xlat1.xy, u_xlat1.xy);
          
          u_xlat10 = sqrt(u_xlat51);
          
          u_xlatb24 = u_xlat10<0.00100000005;
          
          u_xlat38.xy = u_xlat1.xy / float2(u_xlat10);
          
          u_xlat11.xy = (int(u_xlatb24)) ? u_xlat1.xy : u_xlat38.xy;
          
          u_xlat9.z = (-u_xlat9.x);
          
          u_xlat11.z = (-u_xlat11.x);
          
          u_xlat38.xy = u_xlat9.yz + u_xlat11.yz;
          
          u_xlat53 = dot(u_xlat38.xy, u_xlat38.xy);
          
          u_xlat53 = inversesqrt(u_xlat53);
          
          u_xlat38.xy = u_xlat38.xy * float2(u_xlat53);
          
          u_xlat53 = dot(u_xlat9.xy, u_xlat38.xy);
          
          u_xlati12 = int((0.0<u_xlat53) ? 0xFFFFFFFFu : uint(0));
          
          u_xlati53 = int((u_xlat53<0.0) ? 0xFFFFFFFFu : uint(0));
          
          u_xlati53 = (-u_xlati12) + u_xlati53;
          
          u_xlat12.x = dot(u_xlat9.yz, u_xlat11.yz);
          
          u_xlatb12 = u_xlat12.x<-0.999000013;
          
          u_xlatb24 = u_xlatb24 || u_xlatb12;
          
          u_xlatb46 = u_xlatb46 || u_xlatb24;
          
          u_xlatb14 = u_xlatb14 || u_xlatb46;
          
          u_xlatb46 = u_xlati0==int(0xFFFFFFFEu);
          
          if(u_xlatb46)
      {
              
              u_xlat12.xy = u_xlat4.yy * u_xlat11.yz;
              
              u_xlat5.yz = u_xlat2.xy * float2(0.5, 0.5) + u_xlat12.xy;
              
              u_xlatb46 = u_xlati53<0;
              
              u_xlat24 = dot(u_xlat38.xy, u_xlat9.yz);
              
              u_xlat24 = float(1.0) / u_xlat24;
              
              u_xlat24 = u_xlat4.y * u_xlat24;
              
              u_xlat12.x = u_xlat10 * 0.5;
              
              u_xlat26.x = u_xlat4.y * u_xlat4.y;
              
              u_xlat12.x = u_xlat12.x * u_xlat12.x + u_xlat26.x;
              
              u_xlat12.x = sqrt(u_xlat12.x);
              
              u_xlatb12 = u_xlat12.x<u_xlat24;
              
              u_xlat26.xy = u_xlat1.xy * float2(0.5, 0.5) + u_xlat3.xy;
              
              u_xlat26.xy = u_xlat11.yz * u_xlat4.yy + u_xlat26.xy;
              
              u_xlat13.xy = u_xlat38.xy * float2(u_xlat24) + u_xlat3.xy;
              
              u_xlat12.yz = (int(u_xlatb12)) ? u_xlat26.xy : u_xlat13.xy;
              
              u_xlat13.xy = u_xlat2.xy * float2(0.5, 0.5) + (-u_xlat12.yz);
              
              u_xlat24 = dot((-u_xlat1.xy), u_xlat13.xy);
              
              u_xlat24 = u_xlat24 / u_xlat51;
              
              u_xlat13.xyz = in_v.texcoord3.xyz * _Color.xyz + (-u_xlat7.xyz);
              
              u_xlat13.w = 0.0;
              
              u_xlat13 = float4(u_xlat24) * u_xlat13 + u_xlat7;
              
              u_xlat54 = (-u_xlat5.x) + u_xlat29;
              
              u_xlat12.x = u_xlat24 * u_xlat54 + u_xlat5.x;
              
              u_xlat13 = (int(u_xlatb46)) ? u_xlat13 : u_xlat7;
              
              u_xlat12.xyz = (int(u_xlatb46)) ? u_xlat12.xyz : u_xlat5.xyz;
              
              out_v.color = (int(u_xlatb14)) ? u_xlat7 : u_xlat13;
              
              u_xlat6.xyz = (int(u_xlatb14)) ? u_xlat5.xyz : u_xlat12.xyz;
              
              u_xlat20.xy = u_xlat6.yz / _ScreenParams.xy;
              
              u_xlat20.xy = u_xlat20.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
              
              out_v.vertex.xy = u_xlat2.ww * u_xlat20.xy;
              
              out_v.vertex.zw = u_xlat2.zw;
              
              out_v.texcoord.xyz = u_xlat6.xww;
              
              out_v.texcoord1.xy = u_xlat4.xy;
              
              return;
      
      }
          
          u_xlatb46 = u_xlati0==2;
          
          if(u_xlatb46)
      {
              
              u_xlat6.xy = u_xlat4.yy * u_xlat9.yz;
              
              u_xlat5.yz = u_xlat2.xy * float2(0.5, 0.5) + u_xlat6.xy;
              
              u_xlatb46 = u_xlati53<0;
              
              u_xlat6.x = dot(u_xlat38.xy, u_xlat9.yz);
              
              u_xlat6.x = float(1.0) / u_xlat6.x;
              
              u_xlat6.x = u_xlat4.y * u_xlat6.x;
              
              u_xlat20.x = u_xlat32.x * 0.5;
              
              u_xlat34 = u_xlat4.y * u_xlat4.y;
              
              u_xlat20.x = u_xlat20.x * u_xlat20.x + u_xlat34;
              
              u_xlat20.x = sqrt(u_xlat20.x);
              
              u_xlatb20 = u_xlat20.x<u_xlat6.x;
              
              u_xlat12.xy = u_xlat31.xy * float2(0.5, 0.5) + u_xlat28.xy;
              
              u_xlat12.xy = u_xlat9.yz * u_xlat4.yy + u_xlat12.xy;
              
              u_xlat6.xz = u_xlat38.xy * u_xlat6.xx + u_xlat3.xy;
              
              u_xlat6.yz = (int(u_xlatb20)) ? u_xlat12.xy : u_xlat6.xz;
              
              u_xlat12.xy = u_xlat2.xy * float2(0.5, 0.5) + (-u_xlat6.yz);
              
              u_xlat24 = dot(u_xlat31.xy, u_xlat12.xy);
              
              u_xlat24 = u_xlat24 / u_xlat43;
              
              u_xlat12.x = (-u_xlat5.x) + u_xlat29;
              
              u_xlat6.x = u_xlat24 * u_xlat12.x + u_xlat5.x;
              
              u_xlat12.xyz = in_v.texcoord3.xyz * _Color.xyz + (-u_xlat7.xyz);
              
              u_xlat12.w = 0.0;
              
              u_xlat12 = float4(u_xlat24) * u_xlat12 + u_xlat7;
              
              u_xlat12 = (int(u_xlatb46)) ? u_xlat12 : u_xlat7;
              
              u_xlat6.xyz = (int(u_xlatb46)) ? u_xlat6.xyz : u_xlat5.xyz;
              
              out_v.color = (int(u_xlatb14)) ? u_xlat7 : u_xlat12;
              
              u_xlat8.xyz = (int(u_xlatb14)) ? u_xlat5.xyz : u_xlat6.xyz;
              
              u_xlat6.xy = u_xlat8.yz / _ScreenParams.xy;
              
              u_xlat6.xy = u_xlat6.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
              
              out_v.vertex.xy = u_xlat2.ww * u_xlat6.xy;
              
              out_v.vertex.zw = u_xlat2.zw;
              
              out_v.texcoord.xyz = u_xlat8.xww;
              
              out_v.texcoord1.xy = u_xlat4.xy;
              
              return;
      
      }
          
          u_xlatb46 = u_xlati0==int(0xFFFFFFFDu);
          
          if(u_xlatb46)
      {
              
              u_xlat6.xy = (-u_xlat11.xy) * u_xlat4.yy + u_xlat3.xy;
              
              u_xlatb46 = 0<u_xlati53;
              
              u_xlat8.xy = u_xlat38.xy * u_xlat4.yy + u_xlat3.xy;
              
              u_xlat8.xy = (int(u_xlatb46)) ? u_xlat8.xy : u_xlat3.xy;
              
              u_xlat6.xy = (int(u_xlatb14)) ? u_xlat6.xy : u_xlat8.xy;
              
              u_xlat6.xy = u_xlat6.xy / _ScreenParams.xy;
              
              u_xlat6.xy = u_xlat6.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
              
              out_v.vertex.xy = u_xlat2.ww * u_xlat6.xy;
              
              out_v.vertex.zw = u_xlat2.zw;
              
              out_v.color = u_xlat7;
              
              u_xlat5.w = u_xlat6.w;
              
              out_v.texcoord.xyz = u_xlat5.xww;
              
              out_v.texcoord1.xy = u_xlat4.xy;
              
              return;
      
      }
          
          u_xlatb46 = u_xlati0==3;
          
          if(u_xlatb46)
      {
              
              u_xlat6.xy = u_xlat9.xy * u_xlat4.yy + u_xlat3.xy;
              
              u_xlatb46 = 0<u_xlati53;
              
              u_xlat8.xy = u_xlat38.xy * u_xlat4.yy + u_xlat3.xy;
              
              u_xlat8.xy = (int(u_xlatb46)) ? u_xlat8.xy : u_xlat3.xy;
              
              u_xlat6.xy = (int(u_xlatb14)) ? u_xlat6.xy : u_xlat8.xy;
              
              u_xlat6.xy = u_xlat6.xy / _ScreenParams.xy;
              
              u_xlat6.xy = u_xlat6.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
              
              out_v.vertex.xy = u_xlat2.ww * u_xlat6.xy;
              
              out_v.vertex.zw = u_xlat2.zw;
              
              out_v.color = u_xlat7;
              
              u_xlat8.z = u_xlat5.x;
              
              out_v.texcoord.xyz = u_xlat8.zww;
              
              out_v.texcoord1.xy = u_xlat4.xy;
              
              return;
      
      }
          
          u_xlatb46 = u_xlati0==int(0xFFFFFFFCu);
          
          if(u_xlatb46)
      {
              
              u_xlat6.xy = u_xlat4.yy * u_xlat11.yz;
              
              u_xlat5.yz = u_xlat2.xy * float2(0.5, 0.5) + (-u_xlat6.xy);
              
              u_xlatb46 = u_xlati53<0;
              
              u_xlat47 = dot(u_xlat38.xy, u_xlat9.yz);
              
              u_xlat47 = float(1.0) / u_xlat47;
              
              u_xlat47 = u_xlat4.y * u_xlat47;
              
              u_xlat6.x = u_xlat10 * 0.5;
              
              u_xlat20.x = u_xlat4.y * u_xlat4.y;
              
              u_xlat6.x = u_xlat6.x * u_xlat6.x + u_xlat20.x;
              
              u_xlat6.x = sqrt(u_xlat6.x);
              
              u_xlatb6 = u_xlat6.x<u_xlat47;
              
              u_xlat20.xy = u_xlat1.xy * float2(0.5, 0.5) + u_xlat3.xy;
              
              u_xlat20.xy = (-u_xlat11.yz) * u_xlat4.yy + u_xlat20.xy;
              
              u_xlat8.xy = (-u_xlat38.xy) * float2(u_xlat47) + u_xlat3.xy;
              
              u_xlat6.yz = (int(u_xlatb6)) ? u_xlat20.xy : u_xlat8.xy;
              
              u_xlat8.xy = u_xlat2.xy * float2(0.5, 0.5) + (-u_xlat6.yz);
              
              u_xlat1.x = dot((-u_xlat1.xy), u_xlat8.xy);
              
              u_xlat1.x = u_xlat1.x / u_xlat51;
              
              u_xlat15.x = (-u_xlat5.x) + u_xlat29;
              
              u_xlat6.x = u_xlat1.x * u_xlat15.x + u_xlat5.x;
              
              u_xlat12.xyz = in_v.texcoord3.xyz * _Color.xyz + (-u_xlat7.xyz);
              
              u_xlat12.w = 0.0;
              
              u_xlat12 = u_xlat1.xxxx * u_xlat12 + u_xlat7;
              
              u_xlatb1 = u_xlatb14 || u_xlatb46;
              
              out_v.color = (int(u_xlatb1)) ? u_xlat7 : u_xlat12;
              
              u_xlat6.xyz = (int(u_xlatb1)) ? u_xlat5.xyz : u_xlat6.xyz;
              
              u_xlat1.xy = u_xlat6.yz / _ScreenParams.xy;
              
              u_xlat1.xy = u_xlat1.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
              
              out_v.vertex.xy = u_xlat2.ww * u_xlat1.xy;
              
              out_v.vertex.zw = u_xlat2.zw;
              
              out_v.texcoord.x = u_xlat6.x;
              
              out_v.texcoord.y = 0.0;
              
              out_v.texcoord.z = u_xlat6.w;
              
              out_v.texcoord1.xy = u_xlat4.xy;
              
              return;
      
      }
          
          u_xlatb1 = u_xlati0==4;
          
          if(u_xlatb1)
      {
              
              u_xlat1.xy = u_xlat4.yy * u_xlat9.yz;
              
              u_xlat5.yz = u_xlat2.xy * float2(0.5, 0.5) + (-u_xlat1.xy);
              
              u_xlatb1 = u_xlati53<0;
              
              u_xlat15.x = dot(u_xlat38.xy, u_xlat9.yz);
              
              u_xlat15.x = float(1.0) / u_xlat15.x;
              
              u_xlat15.x = u_xlat4.y * u_xlat15.x;
              
              u_xlat32.x = u_xlat32.x * 0.5;
              
              u_xlat46 = u_xlat4.y * u_xlat4.y;
              
              u_xlat32.x = u_xlat32.x * u_xlat32.x + u_xlat46;
              
              u_xlat32.x = sqrt(u_xlat32.x);
              
              u_xlatb32 = u_xlat32.x<u_xlat15.x;
              
              u_xlat28.xy = u_xlat31.xy * float2(0.5, 0.5) + u_xlat28.xy;
              
              u_xlat28.xy = (-u_xlat9.yz) * u_xlat4.yy + u_xlat28.xy;
              
              u_xlat6.xy = (-u_xlat38.xy) * u_xlat15.xx + u_xlat3.xy;
              
              u_xlat6.yz = (int(u_xlatb32)) ? u_xlat28.xy : u_xlat6.xy;
              
              u_xlat28.xy = u_xlat2.xy * float2(0.5, 0.5) + (-u_xlat6.yz);
              
              u_xlat28.x = dot(u_xlat31.xy, u_xlat28.xy);
              
              u_xlat28.x = u_xlat28.x / u_xlat43;
              
              u_xlat42 = (-u_xlat5.x) + u_xlat29;
              
              u_xlat6.x = u_xlat28.x * u_xlat42 + u_xlat5.x;
              
              u_xlat12.xyz = in_v.texcoord3.xyz * _Color.xyz + (-u_xlat7.xyz);
              
              u_xlat12.w = 0.0;
              
              u_xlat12 = u_xlat28.xxxx * u_xlat12 + u_xlat7;
              
              u_xlatb28 = u_xlatb14 || u_xlatb1;
              
              out_v.color = (int(u_xlatb28)) ? u_xlat7 : u_xlat12;
              
              u_xlat1.xyz = (int(u_xlatb28)) ? u_xlat5.xyz : u_xlat6.xyz;
              
              u_xlat28.xy = u_xlat1.yz / _ScreenParams.xy;
              
              u_xlat28.xy = u_xlat28.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
              
              out_v.vertex.xy = u_xlat2.ww * u_xlat28.xy;
              
              out_v.vertex.zw = u_xlat2.zw;
              
              out_v.texcoord.x = u_xlat1.x;
              
              out_v.texcoord.y = 0.0;
              
              out_v.texcoord.z = u_xlat8.w;
              
              out_v.texcoord1.xy = u_xlat4.xy;
              
              return;
      
      }
          
          u_xlatb28 = u_xlati0==int(0xFFFFFFFBu);
          
          if(u_xlatb28)
      {
              
              u_xlat28.xy = (-u_xlat11.xy) * u_xlat4.yy + u_xlat3.xy;
              
              u_xlatb1 = u_xlati53<0;
              
              u_xlat15.xy = (-u_xlat38.xy) * u_xlat4.yy + u_xlat3.xy;
              
              u_xlat1.xy = (int(u_xlatb1)) ? u_xlat15.xy : u_xlat3.xy;
              
              u_xlat28.xy = (int(u_xlatb14)) ? u_xlat28.xy : u_xlat1.xy;
              
              u_xlat28.xy = u_xlat28.xy / _ScreenParams.xy;
              
              u_xlat28.xy = u_xlat28.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
              
              out_v.vertex.xy = u_xlat2.ww * u_xlat28.xy;
              
              out_v.vertex.zw = u_xlat2.zw;
              
              out_v.color = u_xlat7;
              
              out_v.texcoord.x = u_xlat5.x;
              
              out_v.texcoord.y = 0.0;
              
              out_v.texcoord.z = u_xlat6.w;
              
              out_v.texcoord1.xy = u_xlat4.xy;
              
              return;
      
      }
          
          u_xlatb0 = u_xlati0==5;
          
          if(u_xlatb0)
      {
              
              u_xlat0.xz = u_xlat9.xy * u_xlat4.yy + u_xlat3.xy;
              
              u_xlatb42 = u_xlati53<0;
              
              u_xlat1.xy = (-u_xlat38.xy) * u_xlat4.yy + u_xlat3.xy;
              
              u_xlat1.xy = (int(u_xlatb42)) ? u_xlat1.xy : u_xlat3.xy;
              
              u_xlat0.xy = (int(u_xlatb14)) ? u_xlat0.xz : u_xlat1.xy;
              
              u_xlat0.xy = u_xlat0.xy / _ScreenParams.xy;
              
              u_xlat0.xy = u_xlat0.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
              
              out_v.vertex.xy = u_xlat2.ww * u_xlat0.xy;
              
              out_v.vertex.zw = u_xlat2.zw;
              
              out_v.color = u_xlat7;
              
              out_v.texcoord.x = u_xlat5.x;
              
              out_v.texcoord.y = 0.0;
              
              out_v.texcoord.z = u_xlat8.w;
              
              out_v.texcoord1.xy = u_xlat4.xy;
              
              return;
      
      }
          
          u_xlat0.xy = u_xlat3.xy / _ScreenParams.xy;
          
          u_xlat0.xy = u_xlat0.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
          
          out_v.vertex.xy = u_xlat2.ww * u_xlat0.xy;
          
          out_v.vertex.zw = u_xlat2.zw;
          
          out_v.color = u_xlat7;
          
          out_v.texcoord.xyz = float3(0.0, 0.0, 0.0);
          
          out_v.texcoord1.xy = u_xlat4.xy;
          
          return;
      
      }
      
      
      #define CODE_BLOCK_FRAGMENT
      
      float2 u_xlat0_d;
      
      int u_xlatb0_d;
      
      float4 u_xlat1_d;
      
      float u_xlat2_d;
      
      int u_xlatb2;
      
      float u_xlat4_d;
      
      float u_xlat6_d;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlatb0_d = 0.0<_ProjectionParams.x;
          
          u_xlat2_d = in_f.texcoord.y / in_f.texcoord.z;
          
          u_xlat4_d = (-u_xlat2_d) + 1.0;
          
          u_xlat0_d.y = (u_xlatb0_d) ? u_xlat4_d : u_xlat2_d;
          
          u_xlat4_d = (-u_xlat0_d.y) + 1.0;
          
          u_xlat4_d = min(u_xlat4_d, u_xlat0_d.y);
          
          u_xlat6_d = in_f.texcoord1.y / _Feather;
          
          u_xlat6_d = u_xlat6_d + u_xlat6_d;
          
          u_xlat4_d = u_xlat6_d * u_xlat4_d;
          
          u_xlat4_d = min(u_xlat4_d, 1.0);
          
          u_xlat0_d.x = in_f.texcoord.x;
          
          u_xlat1_d = texture(_MainTex, u_xlat0_d.xy);
          
          u_xlat1_d = u_xlat1_d * in_f.color;
          
          u_xlat0_d.x = u_xlat4_d * u_xlat1_d.w;
          
          u_xlatb2 = 0.00100000005<_Feather;
          
          out_f.color.w = (u_xlatb2) ? u_xlat0_d.x : u_xlat1_d.w;
          
          out_f.color.xyz = u_xlat1_d.xyz;
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
