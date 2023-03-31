// Upgrade NOTE: commented out 'float3 _WorldSpaceCameraPos', a built-in variable

Shader "Hidden/Linefy/PolylineWorldspaceBillboard"
{
  Properties
  {
    _MainTex ("Texture", 2D) = "white" {}
    _ViewOffset ("_ViewOffset", float) = 0
    _DepthOffset ("_DepthOffset", float) = 0
    _TextureScale ("Texture Scale", float) = 1
    _WidthMultiplier ("_WidthMultiplier", float) = 2
    _Color ("_Color", Color) = (1,1,1,1)
    [Enum(UnityEngine.Rendering.CompareFunction)] _zTestCompare ("ZTest", float) = 4
    _FadeAlphaDistanceFrom ("FadeAlphaDistanceFrom", float) = 100000
    _FadeAlphaDistanceTo ("FadeAlphaDistanceTo", float) = 100000
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
      
      uniform float _TextureScale;
      
      uniform float _TextureOffset;
      
      uniform float _FadeAlphaDistanceFrom;
      
      uniform float _FadeAlphaDistanceTo;
      
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
          
          float4 color : COLOR0;
      
      };
      
      
      struct OUT_Data_Frag
      {
          
          float4 color : SV_Target0;
      
      };
      
      
      float3 u_xlat0;
      
      int u_xlatb0;
      
      float4 u_xlat1;
      
      int u_xlati1;
      
      int u_xlatb1;
      
      float4 u_xlat2;
      
      float4 u_xlat3;
      
      int u_xlatb3;
      
      float4 u_xlat4;
      
      int u_xlatb4;
      
      float4 u_xlat5;
      
      int u_xlatb5;
      
      float2 u_xlat6;
      
      float4 u_xlat7;
      
      float4 u_xlat8;
      
      float4 u_xlat9;
      
      float4 u_xlat10;
      
      float4 u_xlat11;
      
      float4 u_xlat12;
      
      float2 u_xlat13;
      
      int u_xlatb13;
      
      float3 u_xlat14;
      
      int u_xlati14;
      
      float u_xlat17;
      
      int u_xlatb17;
      
      float3 u_xlat18;
      
      float3 u_xlat22;
      
      float u_xlat26;
      
      float u_xlat27;
      
      float u_xlat28;
      
      int u_xlatb28;
      
      float2 u_xlat29;
      
      float2 u_xlat32;
      
      float2 u_xlat33;
      
      int u_xlati33;
      
      int u_xlatb33;
      
      int u_xlati39;
      
      int u_xlatb39;
      
      float u_xlat40;
      
      float u_xlat41;
      
      int u_xlatb41;
      
      float u_xlat42;
      
      int u_xlatb42;
      
      float u_xlat43;
      
      float u_xlat44;
      
      int u_xlati44;
      
      float u_xlat46;
      
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
          
          u_xlat0.xyz = unity_WorldToObject[1].xyz * unity_MatrixInvV[1].yyy;
          
          u_xlat0.xyz = unity_WorldToObject[0].xyz * unity_MatrixInvV[1].xxx + u_xlat0.xyz;
          
          u_xlat0.xyz = unity_WorldToObject[2].xyz * unity_MatrixInvV[1].zzz + u_xlat0.xyz;
          
          u_xlat0.xyz = unity_WorldToObject[3].xyz * unity_MatrixInvV[1].www + u_xlat0.xyz;
          
          u_xlati39 = int(in_v.texcoord1.x);
          
          u_xlati1 = int((0<u_xlati39) ? 0xFFFFFFFFu : uint(0));
          
          u_xlati14 = int((u_xlati39<0) ? 0xFFFFFFFFu : uint(0));
          
          u_xlati1 = (-u_xlati1) + u_xlati14;
          
          u_xlat1.x = float(u_xlati1);
          
          u_xlat14.xyz = _WorldSpaceCameraPos.yyy * unity_WorldToObject[1].xyz;
          
          u_xlat14.xyz = unity_WorldToObject[0].xyz * _WorldSpaceCameraPos.xxx + u_xlat14.xyz;
          
          u_xlat14.xyz = unity_WorldToObject[2].xyz * _WorldSpaceCameraPos.zzz + u_xlat14.xyz;
          
          u_xlat14.xyz = u_xlat14.xyz + unity_WorldToObject[3].xyz;
          
          u_xlat2.xyz = u_xlat14.xyz + (-in_v.vertex.xyz);
          
          u_xlat41 = dot(u_xlat2.xyz, u_xlat2.xyz);
          
          u_xlat41 = sqrt(u_xlat41);
          
          u_xlatb3 = 9.99999975e-05<abs(_ViewOffset);
          
          if(u_xlatb3)
      {
              
              u_xlat3.xyz = unity_WorldToObject[1].xyz * unity_MatrixInvV[2].yyy;
              
              u_xlat3.xyz = unity_WorldToObject[0].xyz * unity_MatrixInvV[2].xxx + u_xlat3.xyz;
              
              u_xlat3.xyz = unity_WorldToObject[2].xyz * unity_MatrixInvV[2].zzz + u_xlat3.xyz;
              
              u_xlat3.xyz = unity_WorldToObject[3].xyz * unity_MatrixInvV[2].www + u_xlat3.xyz;
              
              u_xlat4.xyz = u_xlat14.xyz + (-in_v.tangent.xyz);
              
              u_xlat14.xyz = u_xlat14.xyz + (-in_v.normal.xyz);
              
              u_xlat42 = dot(u_xlat4.xyz, u_xlat4.xyz);
              
              u_xlat42 = sqrt(u_xlat42);
              
              u_xlat43 = dot(u_xlat14.xyz, u_xlat14.xyz);
              
              u_xlat43 = sqrt(u_xlat43);
              
              u_xlatb5 = u_xlat42==0.0;
              
              u_xlat18.xyz = u_xlat4.xyz / float3(u_xlat42);
              
              u_xlat4.xyz = (int(u_xlatb5)) ? u_xlat4.xyz : u_xlat18.xyz;
              
              u_xlatb42 = u_xlat41==0.0;
              
              u_xlat5.xyz = u_xlat2.xyz / float3(u_xlat41);
              
              u_xlat2.xyz = (int(u_xlatb42)) ? u_xlat2.xyz : u_xlat5.xyz;
              
              u_xlatb42 = u_xlat43==0.0;
              
              u_xlat5.xyz = u_xlat14.xyz / float3(u_xlat43);
              
              u_xlat14.xyz = (int(u_xlatb42)) ? u_xlat14.xyz : u_xlat5.xyz;
              
              u_xlat5.xyz = u_xlat3.xyz + (-u_xlat4.xyz);
              
              u_xlat4.xyz = unity_OrthoParams.www * u_xlat5.xyz + u_xlat4.xyz;
              
              u_xlat5.xyz = (-u_xlat2.xyz) + u_xlat3.xyz;
              
              u_xlat2.xyz = unity_OrthoParams.www * u_xlat5.xyz + u_xlat2.xyz;
              
              u_xlat3.xyz = (-u_xlat14.xyz) + u_xlat3.xyz;
              
              u_xlat14.xyz = unity_OrthoParams.www * u_xlat3.xyz + u_xlat14.xyz;
              
              u_xlat3.xyz = u_xlat4.xyz * float3(_ViewOffset) + in_v.tangent.xyz;
              
              u_xlat2.xyz = u_xlat2.xyz * float3(_ViewOffset) + in_v.vertex.xyz;
              
              u_xlat14.xyz = u_xlat14.xyz * float3(_ViewOffset) + in_v.normal.xyz;
      
      }
          else
          
              {
              
              u_xlat3.xyz = in_v.tangent.xyz;
              
              u_xlat2.xyz = in_v.vertex.xyz;
              
              u_xlat14.xyz = in_v.normal.xyz;
      
      }
          
          u_xlat4 = u_xlat2.yyyy * unity_ObjectToWorld[1];
          
          u_xlat4 = unity_ObjectToWorld[0] * u_xlat2.xxxx + u_xlat4;
          
          u_xlat4 = unity_ObjectToWorld[2] * u_xlat2.zzzz + u_xlat4;
          
          u_xlat4 = u_xlat4 + unity_ObjectToWorld[3];
          
          u_xlat5 = u_xlat4.yyyy * unity_MatrixVP[1];
          
          u_xlat5 = unity_MatrixVP[0] * u_xlat4.xxxx + u_xlat5;
          
          u_xlat5 = unity_MatrixVP[2] * u_xlat4.zzzz + u_xlat5;
          
          u_xlat4 = unity_MatrixVP[3] * u_xlat4.wwww + u_xlat5;
          
          u_xlat5.xy = u_xlat4.xy / u_xlat4.ww;
          
          u_xlat42 = u_xlat5.y + 1.0;
          
          u_xlat42 = u_xlat42 * _ScreenParams.y;
          
          u_xlat6.y = u_xlat42 * 0.5;
          
          u_xlat18.xy = in_v.texcoord2.xy * float2(float2(_WidthMultiplier, _WidthMultiplier));
          
          u_xlat32.xy = u_xlat18.xy * float2(0.5, 0.5);
          
          u_xlat1.x = u_xlat1.x + 1.0;
          
          u_xlat1.x = u_xlat1.x * 0.5;
          
          u_xlat18.xy = u_xlat18.yx * float2(0.5, 0.5) + (-u_xlat32.xy);
          
          u_xlat7.xy = u_xlat1.xx * u_xlat18.xy + u_xlat32.xy;
          
          u_xlat8.x = in_v.texcoord.x * _TextureScale + _TextureOffset;
          
          u_xlat0.xyz = u_xlat0.xyz * u_xlat32.xxx + u_xlat2.xyz;
          
          u_xlat9 = u_xlat0.yyyy * unity_ObjectToWorld[1];
          
          u_xlat9 = unity_ObjectToWorld[0] * u_xlat0.xxxx + u_xlat9;
          
          u_xlat9 = unity_ObjectToWorld[2] * u_xlat0.zzzz + u_xlat9;
          
          u_xlat9 = u_xlat9 + unity_ObjectToWorld[3];
          
          u_xlat0.xy = u_xlat9.yy * unity_MatrixVP[1].yw;
          
          u_xlat0.xy = unity_MatrixVP[0].yw * u_xlat9.xx + u_xlat0.xy;
          
          u_xlat0.xy = unity_MatrixVP[2].yw * u_xlat9.zz + u_xlat0.xy;
          
          u_xlat0.xy = unity_MatrixVP[3].yw * u_xlat9.ww + u_xlat0.xy;
          
          u_xlat0.x = u_xlat0.x / u_xlat0.y;
          
          u_xlat0.x = u_xlat0.x + 1.0;
          
          u_xlat0.x = u_xlat0.x * _ScreenParams.y;
          
          u_xlat0.x = (-u_xlat0.x) * 0.5 + u_xlat6.y;
          
          u_xlatb13 = 0.0<_ProjectionParams.x;
          
          u_xlat9.x = (u_xlatb13) ? (-u_xlat0.x) : u_xlat0.x;
          
          u_xlat10 = in_v.color * _Color;
          
          u_xlat0.x = u_xlat41 + (-_FadeAlphaDistanceFrom);
          
          u_xlat13.x = (-_FadeAlphaDistanceFrom) + _FadeAlphaDistanceTo;
          
          u_xlat0.x = u_xlat0.x / u_xlat13.x;
          
          u_xlat0.x = clamp(u_xlat0.x, 0.0, 1.0);
          
          u_xlat0.x = (-u_xlat0.x) + 1.0;
          
          u_xlat10.w = u_xlat0.x * u_xlat10.w;
          
          u_xlatb0 = u_xlati39==int(0xFFFFFFFFu);
          
          if(u_xlatb0)
      {
              
              out_v.vertex = u_xlat4;
              
              out_v.color = u_xlat10;
              
              u_xlat8.yz = u_xlat7.xx * float2(0.5, 1.0);
              
              out_v.texcoord.xyz = u_xlat8.xyz;
              
              u_xlat9.y = 0.0;
              
              out_v.texcoord1.xy = u_xlat9.yx;
              
              return;
      
      }
          
          u_xlatb0 = u_xlati39==1;
          
          if(u_xlatb0)
      {
              
              out_v.vertex = u_xlat4;
              
              out_v.color = u_xlat10;
              
              u_xlat7.z = u_xlat8.x;
              
              u_xlat7.w = u_xlat7.y * 0.5;
              
              out_v.texcoord.xyz = u_xlat7.zwy;
              
              u_xlat9.z = 0.0;
              
              out_v.texcoord1.xy = u_xlat9.zx;
              
              return;
      
      }
          
          u_xlatb0 = in_v.texcoord1.y==1.0;
          
          u_xlat2 = u_xlat3.yyyy * unity_ObjectToWorld[1];
          
          u_xlat2 = unity_ObjectToWorld[0] * u_xlat3.xxxx + u_xlat2;
          
          u_xlat2 = unity_ObjectToWorld[2] * u_xlat3.zzzz + u_xlat2;
          
          u_xlat2 = u_xlat2 + unity_ObjectToWorld[3];
          
          u_xlat3.xyz = u_xlat2.yyy * unity_MatrixVP[1].xyw;
          
          u_xlat3.xyz = unity_MatrixVP[0].xyw * u_xlat2.xxx + u_xlat3.xyz;
          
          u_xlat2.xyz = unity_MatrixVP[2].xyw * u_xlat2.zzz + u_xlat3.xyz;
          
          u_xlat2.xyz = unity_MatrixVP[3].xyw * u_xlat2.www + u_xlat2.xyz;
          
          u_xlat3 = u_xlat14.yyyy * unity_ObjectToWorld[1];
          
          u_xlat3 = unity_ObjectToWorld[0] * u_xlat14.xxxx + u_xlat3;
          
          u_xlat1 = unity_ObjectToWorld[2] * u_xlat14.zzzz + u_xlat3;
          
          u_xlat1 = u_xlat1 + unity_ObjectToWorld[3];
          
          u_xlat3.xyz = u_xlat1.yyy * unity_MatrixVP[1].xyw;
          
          u_xlat3.xyz = unity_MatrixVP[0].xyw * u_xlat1.xxx + u_xlat3.xyz;
          
          u_xlat1.xyz = unity_MatrixVP[2].xyw * u_xlat1.zzz + u_xlat3.xyz;
          
          u_xlat1.xyz = unity_MatrixVP[3].xyw * u_xlat1.www + u_xlat1.xyz;
          
          u_xlat13.xy = u_xlat2.xy / u_xlat2.zz;
          
          u_xlat13.xy = u_xlat13.xy + float2(1.0, 1.0);
          
          u_xlat13.xy = u_xlat13.xy * _ScreenParams.xy;
          
          u_xlat2.xy = u_xlat13.xy * float2(0.5, 0.5);
          
          u_xlat40 = u_xlat5.x + 1.0;
          
          u_xlat40 = u_xlat40 * _ScreenParams.x;
          
          u_xlat6.x = u_xlat40 * 0.5;
          
          u_xlat1.xy = u_xlat1.xy / u_xlat1.zz;
          
          u_xlat1.xy = u_xlat1.xy + float2(1.0, 1.0);
          
          u_xlat1.xy = u_xlat1.xy * _ScreenParams.xy;
          
          u_xlat27 = in_v.texcoord.y * _TextureScale + _TextureOffset;
          
          u_xlat13.xy = (-u_xlat13.xy) * float2(0.5, 0.5) + u_xlat6.xy;
          
          u_xlat40 = dot(u_xlat13.xy, u_xlat13.xy);
          
          u_xlat28 = sqrt(u_xlat40);
          
          u_xlatb41 = u_xlat28<0.00100000005;
          
          u_xlat3.xy = u_xlat13.xy / float2(u_xlat28);
          
          u_xlat3.xy = (int(u_xlatb41)) ? u_xlat13.xy : u_xlat3.xy;
          
          u_xlat1.xy = u_xlat1.xy * float2(0.5, 0.5) + (-u_xlat6.xy);
          
          u_xlat42 = dot(u_xlat1.xy, u_xlat1.xy);
          
          u_xlat4.x = sqrt(u_xlat42);
          
          u_xlatb17 = u_xlat4.x<0.00100000005;
          
          u_xlat5.xy = u_xlat1.xy / u_xlat4.xx;
          
          u_xlat5.xy = (int(u_xlatb17)) ? u_xlat1.xy : u_xlat5.xy;
          
          u_xlat3.z = (-u_xlat3.x);
          
          u_xlat5.z = (-u_xlat5.x);
          
          u_xlat32.xy = u_xlat3.yz + u_xlat5.yz;
          
          u_xlat44 = dot(u_xlat32.xy, u_xlat32.xy);
          
          u_xlat44 = inversesqrt(u_xlat44);
          
          u_xlat32.xy = float2(u_xlat44) * u_xlat32.xy;
          
          u_xlat44 = dot(u_xlat3.xy, u_xlat32.xy);
          
          u_xlati33 = int((0.0<u_xlat44) ? 0xFFFFFFFFu : uint(0));
          
          u_xlati44 = int((u_xlat44<0.0) ? 0xFFFFFFFFu : uint(0));
          
          u_xlati44 = (-u_xlati33) + u_xlati44;
          
          u_xlat33.x = dot(u_xlat3.yz, u_xlat5.yz);
          
          u_xlatb33 = u_xlat33.x<-0.999000013;
          
          u_xlatb17 = u_xlatb17 || u_xlatb33;
          
          u_xlatb41 = u_xlatb41 || u_xlatb17;
          
          u_xlatb0 = u_xlatb0 || u_xlatb41;
          
          u_xlatb41 = u_xlati39==int(0xFFFFFFFEu);
          
          if(u_xlatb41)
      {
              
              u_xlat8.yz = u_xlat5.yz * u_xlat9.xx + u_xlat6.xy;
              
              u_xlatb41 = u_xlati44<0;
              
              u_xlat17 = dot(u_xlat32.xy, u_xlat3.yz);
              
              u_xlat17 = float(1.0) / u_xlat17;
              
              u_xlat17 = u_xlat9.x * u_xlat17;
              
              u_xlat33.x = u_xlat4.x * 0.5;
              
              u_xlat46 = u_xlat9.x * u_xlat9.x;
              
              u_xlat33.x = u_xlat33.x * u_xlat33.x + u_xlat46;
              
              u_xlat33.x = sqrt(u_xlat33.x);
              
              u_xlatb33 = u_xlat33.x<u_xlat17;
              
              u_xlat22.xy = u_xlat1.xy * float2(0.5, 0.5) + u_xlat6.xy;
              
              u_xlat22.xy = u_xlat5.yz * u_xlat9.xx + u_xlat22.xy;
              
              u_xlat11.xy = u_xlat32.xy * float2(u_xlat17) + u_xlat6.xy;
              
              u_xlat11.yz = (int(u_xlatb33)) ? u_xlat22.xy : u_xlat11.xy;
              
              u_xlat33.xy = u_xlat6.xy + (-u_xlat11.yz);
              
              u_xlat17 = dot((-u_xlat1.xy), u_xlat33.xy);
              
              u_xlat17 = u_xlat17 / u_xlat42;
              
              u_xlat12.xyz = in_v.texcoord3.xyz * _Color.xyz + (-u_xlat10.xyz);
              
              u_xlat12.w = 0.0;
              
              u_xlat12 = float4(u_xlat17) * u_xlat12 + u_xlat10;
              
              u_xlat33.x = (-u_xlat8.x) + u_xlat27;
              
              u_xlat11.x = u_xlat17 * u_xlat33.x + u_xlat8.x;
              
              u_xlat12 = (int(u_xlatb41)) ? u_xlat12 : u_xlat10;
              
              u_xlat11.xyz = (int(u_xlatb41)) ? u_xlat11.xyz : u_xlat8.xyz;
              
              out_v.color = (int(u_xlatb0)) ? u_xlat10 : u_xlat12;
              
              u_xlat11.xyz = (int(u_xlatb0)) ? u_xlat8.xyz : u_xlat11.xyz;
              
              u_xlat33.xy = u_xlat11.yz / _ScreenParams.xy;
              
              u_xlat33.xy = u_xlat33.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
              
              out_v.vertex.xy = u_xlat4.ww * u_xlat33.xy;
              
              out_v.vertex.zw = u_xlat4.zw;
              
              u_xlat11.w = u_xlat7.x;
              
              out_v.texcoord.xyz = u_xlat11.xww;
              
              u_xlat9.w = 0.0;
              
              out_v.texcoord1.xy = u_xlat9.wx;
              
              return;
      
      }
          
          u_xlatb41 = u_xlati39==2;
          
          if(u_xlatb41)
      {
              
              u_xlat8.yz = u_xlat3.yz * u_xlat9.xx + u_xlat6.xy;
              
              u_xlatb41 = u_xlati44<0;
              
              u_xlat17 = dot(u_xlat32.xy, u_xlat3.yz);
              
              u_xlat17 = float(1.0) / u_xlat17;
              
              u_xlat17 = u_xlat9.x * u_xlat17;
              
              u_xlat33.x = u_xlat28 * 0.5;
              
              u_xlat46 = u_xlat9.x * u_xlat9.x;
              
              u_xlat33.x = u_xlat33.x * u_xlat33.x + u_xlat46;
              
              u_xlat33.x = sqrt(u_xlat33.x);
              
              u_xlatb33 = u_xlat33.x<u_xlat17;
              
              u_xlat22.xy = u_xlat13.xy * float2(0.5, 0.5) + u_xlat2.xy;
              
              u_xlat22.xy = u_xlat3.yz * u_xlat9.xx + u_xlat22.xy;
              
              u_xlat11.xy = u_xlat32.xy * float2(u_xlat17) + u_xlat6.xy;
              
              u_xlat11.yz = (int(u_xlatb33)) ? u_xlat22.xy : u_xlat11.xy;
              
              u_xlat33.xy = u_xlat6.xy + (-u_xlat11.yz);
              
              u_xlat17 = dot(u_xlat13.xy, u_xlat33.xy);
              
              u_xlat17 = u_xlat17 / u_xlat40;
              
              u_xlat33.x = (-u_xlat8.x) + u_xlat27;
              
              u_xlat11.x = u_xlat17 * u_xlat33.x + u_xlat8.x;
              
              u_xlat12.xyz = in_v.texcoord3.xyz * _Color.xyz + (-u_xlat10.xyz);
              
              u_xlat12.w = 0.0;
              
              u_xlat12 = float4(u_xlat17) * u_xlat12 + u_xlat10;
              
              u_xlat12 = (int(u_xlatb41)) ? u_xlat12 : u_xlat10;
              
              u_xlat22.xyz = (int(u_xlatb41)) ? u_xlat11.xyz : u_xlat8.xyz;
              
              out_v.color = (int(u_xlatb0)) ? u_xlat10 : u_xlat12;
              
              u_xlat11.xyz = (int(u_xlatb0)) ? u_xlat8.xyz : u_xlat22.xyz;
              
              u_xlat33.xy = u_xlat11.yz / _ScreenParams.xy;
              
              u_xlat33.xy = u_xlat33.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
              
              out_v.vertex.xy = u_xlat4.ww * u_xlat33.xy;
              
              out_v.vertex.zw = u_xlat4.zw;
              
              u_xlat11.w = u_xlat7.y;
              
              out_v.texcoord.xyz = u_xlat11.xww;
              
              out_v.texcoord1.x = 0.0;
              
              out_v.texcoord1.y = u_xlat9.x;
              
              return;
      
      }
          
          u_xlatb41 = u_xlati39==int(0xFFFFFFFDu);
          
          if(u_xlatb41)
      {
              
              u_xlat33.xy = (-u_xlat5.xy) * u_xlat9.xx + u_xlat6.xy;
              
              u_xlatb41 = 0<u_xlati44;
              
              u_xlat22.xy = u_xlat32.xy * u_xlat9.xx + u_xlat6.xy;
              
              u_xlat22.xy = (int(u_xlatb41)) ? u_xlat22.xy : u_xlat6.xy;
              
              u_xlat33.xy = (int(u_xlatb0)) ? u_xlat33.xy : u_xlat22.xy;
              
              u_xlat33.xy = u_xlat33.xy / _ScreenParams.xy;
              
              u_xlat33.xy = u_xlat33.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
              
              out_v.vertex.xy = u_xlat4.ww * u_xlat33.xy;
              
              out_v.vertex.zw = u_xlat4.zw;
              
              out_v.color = u_xlat10;
              
              u_xlat8.w = u_xlat7.x;
              
              out_v.texcoord.xyz = u_xlat8.xww;
              
              out_v.texcoord1.x = 0.0;
              
              out_v.texcoord1.y = u_xlat9.x;
              
              return;
      
      }
          
          u_xlatb41 = u_xlati39==3;
          
          if(u_xlatb41)
      {
              
              u_xlat33.xy = u_xlat3.xy * u_xlat9.xx + u_xlat6.xy;
              
              u_xlatb41 = 0<u_xlati44;
              
              u_xlat22.xy = u_xlat32.xy * u_xlat9.xx + u_xlat6.xy;
              
              u_xlat22.xy = (int(u_xlatb41)) ? u_xlat22.xy : u_xlat6.xy;
              
              u_xlat33.xy = (int(u_xlatb0)) ? u_xlat33.xy : u_xlat22.xy;
              
              u_xlat33.xy = u_xlat33.xy / _ScreenParams.xy;
              
              u_xlat33.xy = u_xlat33.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
              
              out_v.vertex.xy = u_xlat4.ww * u_xlat33.xy;
              
              out_v.vertex.zw = u_xlat4.zw;
              
              out_v.color = u_xlat10;
              
              out_v.texcoord.x = u_xlat8.x;
              
              out_v.texcoord.yz = u_xlat7.yy;
              
              out_v.texcoord1.x = 0.0;
              
              out_v.texcoord1.y = u_xlat9.x;
              
              return;
      
      }
          
          u_xlatb41 = u_xlati39==int(0xFFFFFFFCu);
          
          if(u_xlatb41)
      {
              
              u_xlat8.yz = (-u_xlat5.yz) * u_xlat9.xx + u_xlat6.xy;
              
              u_xlatb41 = u_xlati44<0;
              
              u_xlat17 = dot(u_xlat32.xy, u_xlat3.yz);
              
              u_xlat17 = float(1.0) / u_xlat17;
              
              u_xlat17 = u_xlat9.x * u_xlat17;
              
              u_xlat4.x = u_xlat4.x * 0.5;
              
              u_xlat33.x = u_xlat9.x * u_xlat9.x;
              
              u_xlat4.x = u_xlat4.x * u_xlat4.x + u_xlat33.x;
              
              u_xlat4.x = sqrt(u_xlat4.x);
              
              u_xlatb4 = u_xlat4.x<u_xlat17;
              
              u_xlat33.xy = u_xlat1.xy * float2(0.5, 0.5) + u_xlat6.xy;
              
              u_xlat33.xy = (-u_xlat5.yz) * u_xlat9.xx + u_xlat33.xy;
              
              u_xlat22.xy = (-u_xlat32.xy) * float2(u_xlat17) + u_xlat6.xy;
              
              u_xlat11.yz = (int(u_xlatb4)) ? u_xlat33.xy : u_xlat22.xy;
              
              u_xlat4.xy = u_xlat6.xy + (-u_xlat11.yz);
              
              u_xlat1.x = dot((-u_xlat1.xy), u_xlat4.xy);
              
              u_xlat1.x = u_xlat1.x / u_xlat42;
              
              u_xlat14.x = (-u_xlat8.x) + u_xlat27;
              
              u_xlat11.x = u_xlat1.x * u_xlat14.x + u_xlat8.x;
              
              u_xlat12.xyz = in_v.texcoord3.xyz * _Color.xyz + (-u_xlat10.xyz);
              
              u_xlat12.w = 0.0;
              
              u_xlat12 = u_xlat1.xxxx * u_xlat12 + u_xlat10;
              
              u_xlatb1 = u_xlatb0 || u_xlatb41;
              
              out_v.color = (int(u_xlatb1)) ? u_xlat10 : u_xlat12;
              
              u_xlat22.xyz = (int(u_xlatb1)) ? u_xlat8.xyz : u_xlat11.xyz;
              
              u_xlat1.xy = u_xlat22.yz / _ScreenParams.xy;
              
              u_xlat1.xy = u_xlat1.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
              
              out_v.vertex.xy = u_xlat4.ww * u_xlat1.xy;
              
              out_v.vertex.zw = u_xlat4.zw;
              
              out_v.texcoord.x = u_xlat22.x;
              
              out_v.texcoord.y = 0.0;
              
              out_v.texcoord.z = u_xlat7.x;
              
              out_v.texcoord1.x = 0.0;
              
              out_v.texcoord1.y = u_xlat9.x;
              
              return;
      
      }
          
          u_xlatb1 = u_xlati39==4;
          
          if(u_xlatb1)
      {
              
              u_xlat8.yz = (-u_xlat3.yz) * u_xlat9.xx + u_xlat6.xy;
              
              u_xlatb1 = u_xlati44<0;
              
              u_xlat14.x = dot(u_xlat32.xy, u_xlat3.yz);
              
              u_xlat14.x = float(1.0) / u_xlat14.x;
              
              u_xlat14.x = u_xlat9.x * u_xlat14.x;
              
              u_xlat28 = u_xlat28 * 0.5;
              
              u_xlat41 = u_xlat9.x * u_xlat9.x;
              
              u_xlat28 = u_xlat28 * u_xlat28 + u_xlat41;
              
              u_xlat28 = sqrt(u_xlat28);
              
              u_xlatb28 = u_xlat28<u_xlat14.x;
              
              u_xlat2.xy = u_xlat13.xy * float2(0.5, 0.5) + u_xlat2.xy;
              
              u_xlat2.xy = (-u_xlat3.yz) * u_xlat9.xx + u_xlat2.xy;
              
              u_xlat29.xy = (-u_xlat32.xy) * u_xlat14.xx + u_xlat6.xy;
              
              u_xlat2.yz = (int(u_xlatb28)) ? u_xlat2.xy : u_xlat29.xy;
              
              u_xlat29.xy = (-u_xlat2.yz) + u_xlat6.xy;
              
              u_xlat13.x = dot(u_xlat13.xy, u_xlat29.xy);
              
              u_xlat13.x = u_xlat13.x / u_xlat40;
              
              u_xlat26 = (-u_xlat8.x) + u_xlat27;
              
              u_xlat2.x = u_xlat13.x * u_xlat26 + u_xlat8.x;
              
              u_xlat11.xyz = in_v.texcoord3.xyz * _Color.xyz + (-u_xlat10.xyz);
              
              u_xlat11.w = 0.0;
              
              u_xlat11 = u_xlat13.xxxx * u_xlat11 + u_xlat10;
              
              u_xlatb13 = u_xlatb0 || u_xlatb1;
              
              out_v.color = (int(u_xlatb13)) ? u_xlat10 : u_xlat11;
              
              u_xlat1.xyz = (int(u_xlatb13)) ? u_xlat8.xyz : u_xlat2.xyz;
              
              u_xlat13.xy = u_xlat1.yz / _ScreenParams.xy;
              
              u_xlat13.xy = u_xlat13.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
              
              out_v.vertex.xy = u_xlat4.ww * u_xlat13.xy;
              
              out_v.vertex.zw = u_xlat4.zw;
              
              out_v.texcoord.x = u_xlat1.x;
              
              out_v.texcoord.y = 0.0;
              
              out_v.texcoord.z = u_xlat7.y;
              
              out_v.texcoord1.x = 0.0;
              
              out_v.texcoord1.y = u_xlat9.x;
              
              return;
      
      }
          
          u_xlatb13 = u_xlati39==int(0xFFFFFFFBu);
          
          if(u_xlatb13)
      {
              
              u_xlat13.xy = (-u_xlat5.xy) * u_xlat9.xx + u_xlat6.xy;
              
              u_xlatb1 = u_xlati44<0;
              
              u_xlat14.xy = (-u_xlat32.xy) * u_xlat9.xx + u_xlat6.xy;
              
              u_xlat1.xy = (int(u_xlatb1)) ? u_xlat14.xy : u_xlat6.xy;
              
              u_xlat13.xy = (int(u_xlatb0)) ? u_xlat13.xy : u_xlat1.xy;
              
              u_xlat13.xy = u_xlat13.xy / _ScreenParams.xy;
              
              u_xlat13.xy = u_xlat13.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
              
              out_v.vertex.xy = u_xlat4.ww * u_xlat13.xy;
              
              out_v.vertex.zw = u_xlat4.zw;
              
              out_v.color = u_xlat10;
              
              out_v.texcoord.x = u_xlat8.x;
              
              out_v.texcoord.y = 0.0;
              
              out_v.texcoord.z = u_xlat7.x;
              
              out_v.texcoord1.x = 0.0;
              
              out_v.texcoord1.y = u_xlat9.x;
              
              return;
      
      }
          
          u_xlatb13 = u_xlati39==5;
          
          if(u_xlatb13)
      {
              
              u_xlat13.xy = u_xlat3.xy * u_xlat9.xx + u_xlat6.xy;
              
              u_xlatb39 = u_xlati44<0;
              
              u_xlat1.xy = (-u_xlat32.xy) * u_xlat9.xx + u_xlat6.xy;
              
              u_xlat1.xy = (int(u_xlatb39)) ? u_xlat1.xy : u_xlat6.xy;
              
              u_xlat0.xy = (int(u_xlatb0)) ? u_xlat13.xy : u_xlat1.xy;
              
              u_xlat0.xy = u_xlat0.xy / _ScreenParams.xy;
              
              u_xlat0.xy = u_xlat0.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
              
              out_v.vertex.xy = u_xlat4.ww * u_xlat0.xy;
              
              out_v.vertex.zw = u_xlat4.zw;
              
              out_v.color = u_xlat10;
              
              out_v.texcoord.x = u_xlat8.x;
              
              out_v.texcoord.y = 0.0;
              
              out_v.texcoord.z = u_xlat7.y;
              
              out_v.texcoord1.x = 0.0;
              
              out_v.texcoord1.y = u_xlat9.x;
              
              return;
      
      }
          
          u_xlat0.xy = u_xlat6.xy / _ScreenParams.xy;
          
          u_xlat0.xy = u_xlat0.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
          
          out_v.vertex.xy = u_xlat4.ww * u_xlat0.xy;
          
          out_v.vertex.zw = u_xlat4.zw;
          
          out_v.color = u_xlat10;
          
          out_v.texcoord.xyz = float3(0.0, 0.0, 0.0);
          
          out_v.texcoord1.x = 0.0;
          
          out_v.texcoord1.y = u_xlat9.x;
          
          return;
      
      }
      
      
      #define CODE_BLOCK_FRAGMENT
      
      float4 u_xlat0_d;
      
      int u_xlatb0_d;
      
      float u_xlat1_d;
      
      float u_xlat2_d;
      
      float u_xlat4_d;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlatb0_d = 0.0<_ProjectionParams.x;
          
          u_xlat2_d = in_f.texcoord.y / in_f.texcoord.z;
          
          u_xlat4_d = (-u_xlat2_d) + 1.0;
          
          u_xlat0_d.y = (u_xlatb0_d) ? u_xlat4_d : u_xlat2_d;
          
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
