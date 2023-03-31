// Upgrade NOTE: commented out 'float3 _WorldSpaceCameraPos', a built-in variable

Shader "Hidden/Linefy/PolylineWorldspaceXY"
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
      
      uniform float4 _ProjectionParams;
      
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
      
      
      float4 u_xlat0;
      
      int u_xlati0;
      
      int u_xlatb0;
      
      float4 u_xlat1;
      
      int u_xlatb1;
      
      float3 u_xlat2;
      
      float4 u_xlat3;
      
      float4 u_xlat4;
      
      float4 u_xlat5;
      
      float4 u_xlat6;
      
      float4 u_xlat7;
      
      float4 u_xlat8;
      
      float2 u_xlat9;
      
      float4 u_xlat10;
      
      float4 u_xlat11;
      
      float4 u_xlat12;
      
      float u_xlat13;
      
      int u_xlati13;
      
      int u_xlatb13;
      
      float2 u_xlat14;
      
      float3 u_xlat17;
      
      int u_xlatb17;
      
      float2 u_xlat26;
      
      int u_xlati26;
      
      int u_xlatb26;
      
      float2 u_xlat27;
      
      float2 u_xlat29;
      
      float2 u_xlat30;
      
      float2 u_xlat35;
      
      int u_xlati35;
      
      int u_xlatb35;
      
      float2 u_xlat36;
      
      float u_xlat39;
      
      int u_xlatb39;
      
      int u_xlatb40;
      
      float u_xlat41;
      
      int u_xlatb41;
      
      float u_xlat43;
      
      int u_xlatb43;
      
      float u_xlat44;
      
      float u_xlat46;
      
      int u_xlatb46;
      
      float u_xlat47;
      
      int u_xlati47;
      
      float u_xlat48;
      
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
          
          u_xlati13 = int((0<u_xlati0) ? 0xFFFFFFFFu : uint(0));
          
          u_xlati26 = int((u_xlati0<0) ? 0xFFFFFFFFu : uint(0));
          
          u_xlati13 = (-u_xlati13) + u_xlati26;
          
          u_xlat13 = float(u_xlati13);
          
          u_xlat1.xyz = _WorldSpaceCameraPos.yyy * unity_WorldToObject[1].xyz;
          
          u_xlat1.xyz = unity_WorldToObject[0].xyz * _WorldSpaceCameraPos.xxx + u_xlat1.xyz;
          
          u_xlat1.xyz = unity_WorldToObject[2].xyz * _WorldSpaceCameraPos.zzz + u_xlat1.xyz;
          
          u_xlat1.xyz = u_xlat1.xyz + unity_WorldToObject[3].xyz;
          
          u_xlat2.xyz = u_xlat1.xyz + (-in_v.vertex.xyz);
          
          u_xlat26.x = dot(u_xlat2.xyz, u_xlat2.xyz);
          
          u_xlat26.x = sqrt(u_xlat26.x);
          
          u_xlatb39 = 9.99999975e-05<abs(_ViewOffset);
          
          if(u_xlatb39)
      {
              
              u_xlat3.xyz = unity_WorldToObject[1].xyz * unity_MatrixInvV[2].yyy;
              
              u_xlat3.xyz = unity_WorldToObject[0].xyz * unity_MatrixInvV[2].xxx + u_xlat3.xyz;
              
              u_xlat3.xyz = unity_WorldToObject[2].xyz * unity_MatrixInvV[2].zzz + u_xlat3.xyz;
              
              u_xlat3.xyz = unity_WorldToObject[3].xyz * unity_MatrixInvV[2].www + u_xlat3.xyz;
              
              u_xlat4.xyz = u_xlat1.xyz + (-in_v.tangent.xyz);
              
              u_xlat1.xyz = u_xlat1.xyz + (-in_v.normal.xyz);
              
              u_xlat39 = dot(u_xlat4.xyz, u_xlat4.xyz);
              
              u_xlat39 = sqrt(u_xlat39);
              
              u_xlat27.x = dot(u_xlat1.xyz, u_xlat1.xyz);
              
              u_xlat27.x = sqrt(u_xlat27.x);
              
              u_xlatb40 = u_xlat39==0.0;
              
              u_xlat30.xy = u_xlat4.xy / float2(u_xlat39);
              
              u_xlat4.xy = (int(u_xlatb40)) ? u_xlat4.xy : u_xlat30.xy;
              
              u_xlatb39 = u_xlat26.x==0.0;
              
              u_xlat5.xyz = u_xlat2.xyz / u_xlat26.xxx;
              
              u_xlat2.xyz = (int(u_xlatb39)) ? u_xlat2.xyz : u_xlat5.xyz;
              
              u_xlatb39 = u_xlat27.x==0.0;
              
              u_xlat27.xy = u_xlat1.xy / u_xlat27.xx;
              
              u_xlat1.xy = (int(u_xlatb39)) ? u_xlat1.xy : u_xlat27.xy;
              
              u_xlat27.xy = u_xlat3.xy + (-u_xlat4.xy);
              
              u_xlat27.xy = unity_OrthoParams.ww * u_xlat27.xy + u_xlat4.xy;
              
              u_xlat4.xyz = (-u_xlat2.xyz) + u_xlat3.xyz;
              
              u_xlat2.xyz = unity_OrthoParams.www * u_xlat4.xyz + u_xlat2.xyz;
              
              u_xlat3.xy = (-u_xlat1.xy) + u_xlat3.xy;
              
              u_xlat1.xy = unity_OrthoParams.ww * u_xlat3.xy + u_xlat1.xy;
              
              u_xlat27.xy = u_xlat27.xy * float2(_ViewOffset) + in_v.tangent.xy;
              
              u_xlat2.xyz = u_xlat2.xyz * float3(_ViewOffset) + in_v.vertex.xyz;
              
              u_xlat1.xy = u_xlat1.xy * float2(_ViewOffset) + in_v.normal.xy;
      
      }
          else
          
              {
              
              u_xlat27.xy = in_v.tangent.xy;
              
              u_xlat1.xy = in_v.normal.xy;
              
              u_xlat2.xyz = in_v.vertex.xyz;
      
      }
          
          u_xlat3.xy = in_v.texcoord2.xy * float2(float2(_WidthMultiplier, _WidthMultiplier));
          
          u_xlat4.xy = u_xlat3.xy * float2(0.5, 0.5);
          
          u_xlat13 = u_xlat13 + 1.0;
          
          u_xlat13 = u_xlat13 * 0.5;
          
          u_xlat3.xy = u_xlat3.yx * float2(0.5, 0.5) + (-u_xlat4.xy);
          
          u_xlat3.xy = float2(u_xlat13) * u_xlat3.xy + u_xlat4.xy;
          
          u_xlat5.x = in_v.texcoord.x * _TextureScale + _TextureOffset;
          
          u_xlat6 = in_v.color * _Color;
          
          u_xlat13 = u_xlat26.x + (-_FadeAlphaDistanceFrom);
          
          u_xlat26.x = (-_FadeAlphaDistanceFrom) + _FadeAlphaDistanceTo;
          
          u_xlat13 = u_xlat13 / u_xlat26.x;
          
          u_xlat13 = clamp(u_xlat13, 0.0, 1.0);
          
          u_xlat13 = (-u_xlat13) + 1.0;
          
          u_xlat6.w = u_xlat13 * u_xlat6.w;
          
          u_xlatb13 = u_xlati0==int(0xFFFFFFFFu);
          
          if(u_xlatb13)
      {
              
              u_xlat7 = u_xlat2.yyyy * unity_ObjectToWorld[1];
              
              u_xlat7 = unity_ObjectToWorld[0] * u_xlat2.xxxx + u_xlat7;
              
              u_xlat7 = unity_ObjectToWorld[2] * u_xlat2.zzzz + u_xlat7;
              
              u_xlat7 = u_xlat7 + unity_ObjectToWorld[3];
              
              u_xlat8 = u_xlat7.yyyy * unity_MatrixVP[1];
              
              u_xlat8 = unity_MatrixVP[0] * u_xlat7.xxxx + u_xlat8;
              
              u_xlat8 = unity_MatrixVP[2] * u_xlat7.zzzz + u_xlat8;
              
              out_v.vertex = unity_MatrixVP[3] * u_xlat7.wwww + u_xlat8;
              
              out_v.color = u_xlat6;
              
              u_xlat5.yz = u_xlat3.xx * float2(0.5, 1.0);
              
              out_v.texcoord.xyz = u_xlat5.xyz;
              
              u_xlat4.z = 0.0;
              
              out_v.texcoord1.xy = u_xlat4.zx;
              
              return;
      
      }
          
          u_xlatb13 = u_xlati0==1;
          
          if(u_xlatb13)
      {
              
              u_xlat7 = u_xlat2.yyyy * unity_ObjectToWorld[1];
              
              u_xlat7 = unity_ObjectToWorld[0] * u_xlat2.xxxx + u_xlat7;
              
              u_xlat7 = unity_ObjectToWorld[2] * u_xlat2.zzzz + u_xlat7;
              
              u_xlat7 = u_xlat7 + unity_ObjectToWorld[3];
              
              u_xlat8 = u_xlat7.yyyy * unity_MatrixVP[1];
              
              u_xlat8 = unity_MatrixVP[0] * u_xlat7.xxxx + u_xlat8;
              
              u_xlat8 = unity_MatrixVP[2] * u_xlat7.zzzz + u_xlat8;
              
              out_v.vertex = unity_MatrixVP[3] * u_xlat7.wwww + u_xlat8;
              
              out_v.color = u_xlat6;
              
              u_xlat3.z = u_xlat5.x;
              
              u_xlat3.w = u_xlat3.y * 0.5;
              
              out_v.texcoord.xyz = u_xlat3.zwy;
              
              u_xlat4.w = 0.0;
              
              out_v.texcoord1.xy = u_xlat4.wx;
              
              return;
      
      }
          
          u_xlatb13 = in_v.texcoord1.y==1.0;
          
          u_xlat26.x = in_v.texcoord.y * _TextureScale + _TextureOffset;
          
          u_xlat29.xy = (-u_xlat27.xy) + u_xlat2.xy;
          
          u_xlat39 = dot(u_xlat29.xy, u_xlat29.xy);
          
          u_xlat41 = sqrt(u_xlat39);
          
          u_xlatb17 = u_xlat41<0.00100000005;
          
          u_xlat30.xy = u_xlat29.xy / float2(u_xlat41);
          
          u_xlat7.xy = (int(u_xlatb17)) ? u_xlat29.xy : u_xlat30.xy;
          
          u_xlat1.xy = u_xlat1.xy + (-u_xlat2.xy);
          
          u_xlat30.x = dot(u_xlat1.xy, u_xlat1.xy);
          
          u_xlat43 = sqrt(u_xlat30.x);
          
          u_xlatb46 = u_xlat43<0.00100000005;
          
          u_xlat8.xy = u_xlat1.xy / float2(u_xlat43);
          
          u_xlat8.xy = (int(u_xlatb46)) ? u_xlat1.xy : u_xlat8.xy;
          
          u_xlat7.z = (-u_xlat7.x);
          
          u_xlat8.z = (-u_xlat8.x);
          
          u_xlat9.xy = u_xlat7.yz + u_xlat8.yz;
          
          u_xlat47 = dot(u_xlat9.xy, u_xlat9.xy);
          
          u_xlat47 = inversesqrt(u_xlat47);
          
          u_xlat9.xy = float2(u_xlat47) * u_xlat9.xy;
          
          u_xlat47 = dot(u_xlat7.xy, u_xlat9.xy);
          
          u_xlati35 = int((0.0<u_xlat47) ? 0xFFFFFFFFu : uint(0));
          
          u_xlati47 = int((u_xlat47<0.0) ? 0xFFFFFFFFu : uint(0));
          
          u_xlati47 = (-u_xlati35) + u_xlati47;
          
          u_xlat35.x = dot(u_xlat7.yz, u_xlat8.yz);
          
          u_xlatb35 = u_xlat35.x<-0.999000013;
          
          u_xlatb46 = u_xlatb46 || u_xlatb35;
          
          u_xlatb17 = u_xlatb17 || u_xlatb46;
          
          u_xlatb13 = u_xlatb13 || u_xlatb17;
          
          u_xlatb17 = u_xlati0==int(0xFFFFFFFEu);
          
          if(u_xlatb17)
      {
              
              u_xlat5.yz = u_xlat8.yz * u_xlat4.xx + u_xlat2.xy;
              
              u_xlatb17 = u_xlati47<0;
              
              u_xlat46 = dot(u_xlat9.xy, u_xlat7.yz);
              
              u_xlat46 = float(1.0) / u_xlat46;
              
              u_xlat46 = u_xlat4.x * u_xlat46;
              
              u_xlat35.x = u_xlat43 * 0.5;
              
              u_xlat48 = u_xlat4.x * u_xlat4.x;
              
              u_xlat35.x = u_xlat35.x * u_xlat35.x + u_xlat48;
              
              u_xlat35.x = sqrt(u_xlat35.x);
              
              u_xlatb35 = u_xlat35.x<u_xlat46;
              
              u_xlat10.xy = u_xlat1.xy * float2(0.5, 0.5) + u_xlat2.xy;
              
              u_xlat10.xy = u_xlat8.yz * u_xlat4.xx + u_xlat10.xy;
              
              u_xlat36.xy = u_xlat9.xy * float2(u_xlat46) + u_xlat2.xy;
              
              u_xlat10.yz = (int(u_xlatb35)) ? u_xlat10.xy : u_xlat36.xy;
              
              u_xlat35.xy = u_xlat2.xy + (-u_xlat10.yz);
              
              u_xlat46 = dot((-u_xlat1.xy), u_xlat35.xy);
              
              u_xlat46 = u_xlat46 / u_xlat30.x;
              
              u_xlat11.xyz = in_v.texcoord3.xyz * _Color.xyz + (-u_xlat6.xyz);
              
              u_xlat11.w = 0.0;
              
              u_xlat11 = float4(u_xlat46) * u_xlat11 + u_xlat6;
              
              u_xlat35.x = (-u_xlat5.x) + u_xlat26.x;
              
              u_xlat10.x = u_xlat46 * u_xlat35.x + u_xlat5.x;
              
              u_xlat11 = (int(u_xlatb17)) ? u_xlat11 : u_xlat6;
              
              u_xlat10.xyz = (int(u_xlatb17)) ? u_xlat10.xyz : u_xlat5.xyz;
              
              out_v.color = (int(u_xlatb13)) ? u_xlat6 : u_xlat11;
              
              u_xlat10.xyz = (int(u_xlatb13)) ? u_xlat5.xyz : u_xlat10.xyz;
              
              u_xlat11 = u_xlat10.zzzz * unity_ObjectToWorld[1];
              
              u_xlat11 = unity_ObjectToWorld[0] * u_xlat10.yyyy + u_xlat11;
              
              u_xlat11 = unity_ObjectToWorld[2] * u_xlat2.zzzz + u_xlat11;
              
              u_xlat11 = u_xlat11 + unity_ObjectToWorld[3];
              
              u_xlat12 = u_xlat11.yyyy * unity_MatrixVP[1];
              
              u_xlat12 = unity_MatrixVP[0] * u_xlat11.xxxx + u_xlat12;
              
              u_xlat12 = unity_MatrixVP[2] * u_xlat11.zzzz + u_xlat12;
              
              out_v.vertex = unity_MatrixVP[3] * u_xlat11.wwww + u_xlat12;
              
              u_xlat10.w = u_xlat3.x;
              
              out_v.texcoord.xyz = u_xlat10.xww;
              
              out_v.texcoord1.x = 0.0;
              
              out_v.texcoord1.y = u_xlat4.x;
              
              return;
      
      }
          
          u_xlatb17 = u_xlati0==2;
          
          if(u_xlatb17)
      {
              
              u_xlat5.yz = u_xlat7.yz * u_xlat4.xx + u_xlat2.xy;
              
              u_xlatb17 = u_xlati47<0;
              
              u_xlat46 = dot(u_xlat9.xy, u_xlat7.yz);
              
              u_xlat46 = float(1.0) / u_xlat46;
              
              u_xlat46 = u_xlat4.x * u_xlat46;
              
              u_xlat35.x = u_xlat41 * 0.5;
              
              u_xlat48 = u_xlat4.x * u_xlat4.x;
              
              u_xlat35.x = u_xlat35.x * u_xlat35.x + u_xlat48;
              
              u_xlat35.x = sqrt(u_xlat35.x);
              
              u_xlatb35 = u_xlat35.x<u_xlat46;
              
              u_xlat10.xy = u_xlat29.xy * float2(0.5, 0.5) + u_xlat27.xy;
              
              u_xlat10.xy = u_xlat7.yz * u_xlat4.xx + u_xlat10.xy;
              
              u_xlat36.xy = u_xlat9.xy * float2(u_xlat46) + u_xlat2.xy;
              
              u_xlat10.yz = (int(u_xlatb35)) ? u_xlat10.xy : u_xlat36.xy;
              
              u_xlat35.xy = u_xlat2.xy + (-u_xlat10.yz);
              
              u_xlat46 = dot(u_xlat29.xy, u_xlat35.xy);
              
              u_xlat46 = u_xlat46 / u_xlat39;
              
              u_xlat35.x = (-u_xlat5.x) + u_xlat26.x;
              
              u_xlat10.x = u_xlat46 * u_xlat35.x + u_xlat5.x;
              
              u_xlat11.xyz = in_v.texcoord3.xyz * _Color.xyz + (-u_xlat6.xyz);
              
              u_xlat11.w = 0.0;
              
              u_xlat11 = float4(u_xlat46) * u_xlat11 + u_xlat6;
              
              u_xlat11 = (int(u_xlatb17)) ? u_xlat11 : u_xlat6;
              
              u_xlat10.xyz = (int(u_xlatb17)) ? u_xlat10.xyz : u_xlat5.xyz;
              
              out_v.color = (int(u_xlatb13)) ? u_xlat6 : u_xlat11;
              
              u_xlat10.xyz = (int(u_xlatb13)) ? u_xlat5.xyz : u_xlat10.xyz;
              
              u_xlat11 = u_xlat10.zzzz * unity_ObjectToWorld[1];
              
              u_xlat11 = unity_ObjectToWorld[0] * u_xlat10.yyyy + u_xlat11;
              
              u_xlat11 = unity_ObjectToWorld[2] * u_xlat2.zzzz + u_xlat11;
              
              u_xlat11 = u_xlat11 + unity_ObjectToWorld[3];
              
              u_xlat12 = u_xlat11.yyyy * unity_MatrixVP[1];
              
              u_xlat12 = unity_MatrixVP[0] * u_xlat11.xxxx + u_xlat12;
              
              u_xlat12 = unity_MatrixVP[2] * u_xlat11.zzzz + u_xlat12;
              
              out_v.vertex = unity_MatrixVP[3] * u_xlat11.wwww + u_xlat12;
              
              u_xlat10.w = u_xlat3.y;
              
              out_v.texcoord.xyz = u_xlat10.xww;
              
              out_v.texcoord1.x = 0.0;
              
              out_v.texcoord1.y = u_xlat4.x;
              
              return;
      
      }
          
          u_xlatb17 = u_xlati0==int(0xFFFFFFFDu);
          
          if(u_xlatb17)
      {
              
              u_xlat35.xy = (-u_xlat8.xy) * u_xlat4.xx + u_xlat2.xy;
              
              u_xlatb17 = 0<u_xlati47;
              
              u_xlat10.xy = u_xlat9.xy * u_xlat4.xx + u_xlat2.xy;
              
              u_xlat10.xy = (int(u_xlatb17)) ? u_xlat10.xy : u_xlat2.xy;
              
              u_xlat35.xy = (int(u_xlatb13)) ? u_xlat35.xy : u_xlat10.xy;
              
              u_xlat10 = u_xlat35.yyyy * unity_ObjectToWorld[1];
              
              u_xlat10 = unity_ObjectToWorld[0] * u_xlat35.xxxx + u_xlat10;
              
              u_xlat10 = unity_ObjectToWorld[2] * u_xlat2.zzzz + u_xlat10;
              
              u_xlat10 = u_xlat10 + unity_ObjectToWorld[3];
              
              u_xlat11 = u_xlat10.yyyy * unity_MatrixVP[1];
              
              u_xlat11 = unity_MatrixVP[0] * u_xlat10.xxxx + u_xlat11;
              
              u_xlat11 = unity_MatrixVP[2] * u_xlat10.zzzz + u_xlat11;
              
              out_v.vertex = unity_MatrixVP[3] * u_xlat10.wwww + u_xlat11;
              
              out_v.color = u_xlat6;
              
              u_xlat5.w = u_xlat3.x;
              
              out_v.texcoord.xyz = u_xlat5.xww;
              
              out_v.texcoord1.x = 0.0;
              
              out_v.texcoord1.y = u_xlat4.x;
              
              return;
      
      }
          
          u_xlatb17 = u_xlati0==3;
          
          if(u_xlatb17)
      {
              
              u_xlat35.xy = u_xlat7.xy * u_xlat4.xx + u_xlat2.xy;
              
              u_xlatb17 = 0<u_xlati47;
              
              u_xlat10.xy = u_xlat9.xy * u_xlat4.xx + u_xlat2.xy;
              
              u_xlat10.xy = (int(u_xlatb17)) ? u_xlat10.xy : u_xlat2.xy;
              
              u_xlat35.xy = (int(u_xlatb13)) ? u_xlat35.xy : u_xlat10.xy;
              
              u_xlat10 = u_xlat35.yyyy * unity_ObjectToWorld[1];
              
              u_xlat10 = unity_ObjectToWorld[0] * u_xlat35.xxxx + u_xlat10;
              
              u_xlat10 = unity_ObjectToWorld[2] * u_xlat2.zzzz + u_xlat10;
              
              u_xlat10 = u_xlat10 + unity_ObjectToWorld[3];
              
              u_xlat11 = u_xlat10.yyyy * unity_MatrixVP[1];
              
              u_xlat11 = unity_MatrixVP[0] * u_xlat10.xxxx + u_xlat11;
              
              u_xlat11 = unity_MatrixVP[2] * u_xlat10.zzzz + u_xlat11;
              
              out_v.vertex = unity_MatrixVP[3] * u_xlat10.wwww + u_xlat11;
              
              out_v.color = u_xlat6;
              
              out_v.texcoord.x = u_xlat5.x;
              
              out_v.texcoord.yz = u_xlat3.yy;
              
              out_v.texcoord1.x = 0.0;
              
              out_v.texcoord1.y = u_xlat4.x;
              
              return;
      
      }
          
          u_xlatb17 = u_xlati0==int(0xFFFFFFFCu);
          
          if(u_xlatb17)
      {
              
              u_xlat5.yz = (-u_xlat8.yz) * u_xlat4.xx + u_xlat2.xy;
              
              u_xlatb17 = u_xlati47<0;
              
              u_xlat44 = dot(u_xlat9.xy, u_xlat7.yz);
              
              u_xlat44 = float(1.0) / u_xlat44;
              
              u_xlat44 = u_xlat4.x * u_xlat44;
              
              u_xlat43 = u_xlat43 * 0.5;
              
              u_xlat46 = u_xlat4.x * u_xlat4.x;
              
              u_xlat43 = u_xlat43 * u_xlat43 + u_xlat46;
              
              u_xlat43 = sqrt(u_xlat43);
              
              u_xlatb43 = u_xlat43<u_xlat44;
              
              u_xlat35.xy = u_xlat1.xy * float2(0.5, 0.5) + u_xlat2.xy;
              
              u_xlat35.xy = (-u_xlat8.yz) * u_xlat4.xx + u_xlat35.xy;
              
              u_xlat10.xy = (-u_xlat9.xy) * float2(u_xlat44) + u_xlat2.xy;
              
              u_xlat10.yz = (int(u_xlatb43)) ? u_xlat35.xy : u_xlat10.xy;
              
              u_xlat35.xy = u_xlat2.xy + (-u_xlat10.yz);
              
              u_xlat1.x = dot((-u_xlat1.xy), u_xlat35.xy);
              
              u_xlat1.x = u_xlat1.x / u_xlat30.x;
              
              u_xlat14.x = (-u_xlat5.x) + u_xlat26.x;
              
              u_xlat10.x = u_xlat1.x * u_xlat14.x + u_xlat5.x;
              
              u_xlat11.xyz = in_v.texcoord3.xyz * _Color.xyz + (-u_xlat6.xyz);
              
              u_xlat11.w = 0.0;
              
              u_xlat11 = u_xlat1.xxxx * u_xlat11 + u_xlat6;
              
              u_xlatb1 = u_xlatb13 || u_xlatb17;
              
              out_v.color = (int(u_xlatb1)) ? u_xlat6 : u_xlat11;
              
              u_xlat17.xyz = (int(u_xlatb1)) ? u_xlat5.xyz : u_xlat10.xyz;
              
              u_xlat10 = u_xlat17.zzzz * unity_ObjectToWorld[1];
              
              u_xlat10 = unity_ObjectToWorld[0] * u_xlat17.yyyy + u_xlat10;
              
              u_xlat10 = unity_ObjectToWorld[2] * u_xlat2.zzzz + u_xlat10;
              
              u_xlat10 = u_xlat10 + unity_ObjectToWorld[3];
              
              u_xlat11 = u_xlat10.yyyy * unity_MatrixVP[1];
              
              u_xlat11 = unity_MatrixVP[0] * u_xlat10.xxxx + u_xlat11;
              
              u_xlat11 = unity_MatrixVP[2] * u_xlat10.zzzz + u_xlat11;
              
              out_v.vertex = unity_MatrixVP[3] * u_xlat10.wwww + u_xlat11;
              
              out_v.texcoord.x = u_xlat17.x;
              
              out_v.texcoord.y = 0.0;
              
              out_v.texcoord.z = u_xlat3.x;
              
              out_v.texcoord1.x = 0.0;
              
              out_v.texcoord1.y = u_xlat4.x;
              
              return;
      
      }
          
          u_xlatb1 = u_xlati0==4;
          
          if(u_xlatb1)
      {
              
              u_xlat5.yz = (-u_xlat7.yz) * u_xlat4.xx + u_xlat2.xy;
              
              u_xlatb1 = u_xlati47<0;
              
              u_xlat14.x = dot(u_xlat9.xy, u_xlat7.yz);
              
              u_xlat14.x = float(1.0) / u_xlat14.x;
              
              u_xlat14.x = u_xlat4.x * u_xlat14.x;
              
              u_xlat41 = u_xlat41 * 0.5;
              
              u_xlat17.x = u_xlat4.x * u_xlat4.x;
              
              u_xlat41 = u_xlat41 * u_xlat41 + u_xlat17.x;
              
              u_xlat41 = sqrt(u_xlat41);
              
              u_xlatb41 = u_xlat41<u_xlat14.x;
              
              u_xlat27.xy = u_xlat29.xy * float2(0.5, 0.5) + u_xlat27.xy;
              
              u_xlat27.xy = (-u_xlat7.yz) * u_xlat4.xx + u_xlat27.xy;
              
              u_xlat17.xy = (-u_xlat9.xy) * u_xlat14.xx + u_xlat2.xy;
              
              u_xlat10.yz = (int(u_xlatb41)) ? u_xlat27.xy : u_xlat17.xy;
              
              u_xlat14.xy = u_xlat2.xy + (-u_xlat10.yz);
              
              u_xlat14.x = dot(u_xlat29.xy, u_xlat14.xy);
              
              u_xlat39 = u_xlat14.x / u_xlat39;
              
              u_xlat26.x = (-u_xlat5.x) + u_xlat26.x;
              
              u_xlat10.x = u_xlat39 * u_xlat26.x + u_xlat5.x;
              
              u_xlat11.xyz = in_v.texcoord3.xyz * _Color.xyz + (-u_xlat6.xyz);
              
              u_xlat11.w = 0.0;
              
              u_xlat11 = float4(u_xlat39) * u_xlat11 + u_xlat6;
              
              u_xlatb26 = u_xlatb13 || u_xlatb1;
              
              out_v.color = (int(u_xlatb26)) ? u_xlat6 : u_xlat11;
              
              u_xlat1.xyz = (int(u_xlatb26)) ? u_xlat5.xyz : u_xlat10.xyz;
              
              u_xlat10 = u_xlat1.zzzz * unity_ObjectToWorld[1];
              
              u_xlat10 = unity_ObjectToWorld[0] * u_xlat1.yyyy + u_xlat10;
              
              u_xlat10 = unity_ObjectToWorld[2] * u_xlat2.zzzz + u_xlat10;
              
              u_xlat10 = u_xlat10 + unity_ObjectToWorld[3];
              
              u_xlat11 = u_xlat10.yyyy * unity_MatrixVP[1];
              
              u_xlat11 = unity_MatrixVP[0] * u_xlat10.xxxx + u_xlat11;
              
              u_xlat11 = unity_MatrixVP[2] * u_xlat10.zzzz + u_xlat11;
              
              out_v.vertex = unity_MatrixVP[3] * u_xlat10.wwww + u_xlat11;
              
              out_v.texcoord.x = u_xlat1.x;
              
              out_v.texcoord.y = 0.0;
              
              out_v.texcoord.z = u_xlat3.y;
              
              out_v.texcoord1.x = 0.0;
              
              out_v.texcoord1.y = u_xlat4.x;
              
              return;
      
      }
          
          u_xlatb26 = u_xlati0==int(0xFFFFFFFBu);
          
          if(u_xlatb26)
      {
              
              u_xlat26.xy = (-u_xlat8.xy) * u_xlat4.xx + u_xlat2.xy;
              
              u_xlatb1 = u_xlati47<0;
              
              u_xlat14.xy = (-u_xlat9.xy) * u_xlat4.xx + u_xlat2.xy;
              
              u_xlat1.xy = (int(u_xlatb1)) ? u_xlat14.xy : u_xlat2.xy;
              
              u_xlat26.xy = (int(u_xlatb13)) ? u_xlat26.xy : u_xlat1.xy;
              
              u_xlat1 = u_xlat26.yyyy * unity_ObjectToWorld[1];
              
              u_xlat1 = unity_ObjectToWorld[0] * u_xlat26.xxxx + u_xlat1;
              
              u_xlat1 = unity_ObjectToWorld[2] * u_xlat2.zzzz + u_xlat1;
              
              u_xlat1 = u_xlat1 + unity_ObjectToWorld[3];
              
              u_xlat10 = u_xlat1.yyyy * unity_MatrixVP[1];
              
              u_xlat10 = unity_MatrixVP[0] * u_xlat1.xxxx + u_xlat10;
              
              u_xlat10 = unity_MatrixVP[2] * u_xlat1.zzzz + u_xlat10;
              
              out_v.vertex = unity_MatrixVP[3] * u_xlat1.wwww + u_xlat10;
              
              out_v.color = u_xlat6;
              
              out_v.texcoord.x = u_xlat5.x;
              
              out_v.texcoord.y = 0.0;
              
              out_v.texcoord.z = u_xlat3.x;
              
              out_v.texcoord1.x = 0.0;
              
              out_v.texcoord1.y = u_xlat4.x;
              
              return;
      
      }
          
          u_xlatb0 = u_xlati0==5;
          
          if(u_xlatb0)
      {
              
              u_xlat0.xz = u_xlat7.xy * u_xlat4.xx + u_xlat2.xy;
              
              u_xlatb39 = u_xlati47<0;
              
              u_xlat1.xy = (-u_xlat9.xy) * u_xlat4.xx + u_xlat2.xy;
              
              u_xlat1.xy = (int(u_xlatb39)) ? u_xlat1.xy : u_xlat2.xy;
              
              u_xlat0.xy = (int(u_xlatb13)) ? u_xlat0.xz : u_xlat1.xy;
              
              u_xlat1 = u_xlat0.yyyy * unity_ObjectToWorld[1];
              
              u_xlat0 = unity_ObjectToWorld[0] * u_xlat0.xxxx + u_xlat1;
              
              u_xlat0 = unity_ObjectToWorld[2] * u_xlat2.zzzz + u_xlat0;
              
              u_xlat0 = u_xlat0 + unity_ObjectToWorld[3];
              
              u_xlat1 = u_xlat0.yyyy * unity_MatrixVP[1];
              
              u_xlat1 = unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
              
              u_xlat1 = unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
              
              out_v.vertex = unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
              
              out_v.color = u_xlat6;
              
              out_v.texcoord.x = u_xlat5.x;
              
              out_v.texcoord.y = 0.0;
              
              out_v.texcoord.z = u_xlat3.y;
              
              out_v.texcoord1.x = 0.0;
              
              out_v.texcoord1.y = u_xlat4.x;
              
              return;
      
      }
          
          u_xlat0 = u_xlat2.yyyy * unity_ObjectToWorld[1];
          
          u_xlat0 = unity_ObjectToWorld[0] * u_xlat2.xxxx + u_xlat0;
          
          u_xlat0 = unity_ObjectToWorld[2] * u_xlat2.zzzz + u_xlat0;
          
          u_xlat0 = u_xlat0 + unity_ObjectToWorld[3];
          
          u_xlat1 = u_xlat0.yyyy * unity_MatrixVP[1];
          
          u_xlat1 = unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
          
          u_xlat1 = unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
          
          out_v.vertex = unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
          
          out_v.color = u_xlat6;
          
          out_v.texcoord.xyz = float3(0.0, 0.0, 0.0);
          
          out_v.texcoord1.x = 0.0;
          
          out_v.texcoord1.y = u_xlat4.x;
          
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
