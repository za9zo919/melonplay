// Upgrade NOTE: commented out 'float3 _WorldSpaceCameraPos', a built-in variable

Shader "Hidden/Linefy/LinesWorldspaceXY"
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
      
      uniform float4 unity_ObjectToWorld[4];
      
      uniform float4 unity_WorldToObject[4];
      
      uniform float4 unity_MatrixVP[4];
      
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
      
      
      float4 u_xlat0;
      
      int u_xlati0;
      
      int u_xlatb0;
      
      float4 u_xlat1;
      
      float4 u_xlat2;
      
      float4 u_xlat3;
      
      float4 u_xlat4;
      
      float4 u_xlat5;
      
      float4 u_xlat6;
      
      float3 u_xlat7;
      
      float2 u_xlat14;
      
      int u_xlatb14;
      
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
          
          u_xlati0 = int(in_v.texcoord1.x);
          
          u_xlat7.xyz = _WorldSpaceCameraPos.yyy * unity_WorldToObject[1].xyz;
          
          u_xlat7.xyz = unity_WorldToObject[0].xyz * _WorldSpaceCameraPos.xxx + u_xlat7.xyz;
          
          u_xlat7.xyz = unity_WorldToObject[2].xyz * _WorldSpaceCameraPos.zzz + u_xlat7.xyz;
          
          u_xlat7.xyz = u_xlat7.xyz + unity_WorldToObject[3].xyz;
          
          u_xlat7.xyz = u_xlat7.xyz + (-in_v.vertex.xyz);
          
          u_xlat7.x = dot(u_xlat7.xyz, u_xlat7.xyz);
          
          u_xlat7.x = sqrt(u_xlat7.x);
          
          u_xlat14.xy = (-in_v.vertex.xy) + in_v.normal.xy;
          
          u_xlat1.x = dot(u_xlat14.xy, u_xlat14.xy);
          
          u_xlat1.x = sqrt(u_xlat1.x);
          
          u_xlat2.xy = u_xlat14.xy / u_xlat1.xx;
          
          u_xlat3 = in_v.color * _Color;
          
          u_xlat1.y = in_v.texcoord.y * _WidthMultiplier;
          
          u_xlat4.z = u_xlat1.y * 0.5;
          
          u_xlat7.x = u_xlat7.x + (-_FadeAlphaDistanceFrom);
          
          u_xlat14.x = (-_FadeAlphaDistanceFrom) + _FadeAlphaDistanceTo;
          
          u_xlat7.x = u_xlat7.x / u_xlat14.x;
          
          u_xlat7.x = clamp(u_xlat7.x, 0.0, 1.0);
          
          u_xlat7.x = (-u_xlat7.x) + 1.0;
          
          u_xlat7.x = u_xlat7.x * u_xlat3.w;
          
          if(u_xlati0 == 0)
      {
              
              u_xlat4.y = in_v.texcoord.x * _TextureScale + _TextureOffset;
              
              u_xlat2.z = (-u_xlat2.x);
              
              u_xlat14.xy = (-u_xlat2.yz) * u_xlat4.zz + in_v.vertex.xy;
              
              u_xlat5 = u_xlat14.yyyy * unity_ObjectToWorld[1];
              
              u_xlat5 = unity_ObjectToWorld[0] * u_xlat14.xxxx + u_xlat5;
              
              u_xlat5 = unity_ObjectToWorld[2] * in_v.vertex.zzzz + u_xlat5;
              
              u_xlat5 = u_xlat5 + unity_ObjectToWorld[3];
              
              u_xlat6 = u_xlat5.yyyy * unity_MatrixVP[1];
              
              u_xlat6 = unity_MatrixVP[0] * u_xlat5.xxxx + u_xlat6;
              
              u_xlat6 = unity_MatrixVP[2] * u_xlat5.zzzz + u_xlat6;
              
              out_v.vertex = unity_MatrixVP[3] * u_xlat5.wwww + u_xlat6;
              
              out_v.color.xyz = u_xlat3.xyz;
              
              out_v.color.w = u_xlat7.x;
              
              u_xlat4.w = 0.0;
              
              out_v.texcoord.xyz = u_xlat4.ywz;
              
              u_xlat1.z = 0.0;
              
              out_v.texcoord1.xy = u_xlat1.zy;
              
              return;
      
      }
          
          u_xlatb14 = u_xlati0==1;
          
          if(u_xlatb14)
      {
              
              u_xlat4.x = in_v.texcoord.x * _TextureScale + _TextureOffset;
              
              u_xlat2.w = (-u_xlat2.x);
              
              u_xlat14.xy = u_xlat2.yw * u_xlat4.zz + in_v.vertex.xy;
              
              u_xlat5 = u_xlat14.yyyy * unity_ObjectToWorld[1];
              
              u_xlat5 = unity_ObjectToWorld[0] * u_xlat14.xxxx + u_xlat5;
              
              u_xlat5 = unity_ObjectToWorld[2] * in_v.vertex.zzzz + u_xlat5;
              
              u_xlat5 = u_xlat5 + unity_ObjectToWorld[3];
              
              u_xlat6 = u_xlat5.yyyy * unity_MatrixVP[1];
              
              u_xlat6 = unity_MatrixVP[0] * u_xlat5.xxxx + u_xlat6;
              
              u_xlat6 = unity_MatrixVP[2] * u_xlat5.zzzz + u_xlat6;
              
              out_v.vertex = unity_MatrixVP[3] * u_xlat5.wwww + u_xlat6;
              
              out_v.color.xyz = u_xlat3.xyz;
              
              out_v.color.w = u_xlat7.x;
              
              out_v.texcoord.xyz = u_xlat4.xzz;
              
              u_xlat1.w = 0.0;
              
              out_v.texcoord1.xy = u_xlat1.wy;
              
              return;
      
      }
          
          u_xlatb0 = u_xlati0==2;
          
          if(u_xlatb0)
      {
              
              u_xlat0.xzw = in_v.vertex.xyz + (-in_v.normal.xyz);
              
              u_xlat0.x = dot(u_xlat0.xzw, u_xlat0.xzw);
              
              u_xlat0.x = sqrt(u_xlat0.x);
              
              u_xlat0.x = u_xlat0.x * _AutoTextureOffset + in_v.texcoord.x;
              
              out_v.texcoord.x = u_xlat0.x * _TextureScale + _TextureOffset;
              
              u_xlat0.xz = u_xlat2.yx * float2(1.0, -1.0);
              
              u_xlat0.xz = (-u_xlat0.xz) * u_xlat4.zz + in_v.vertex.xy;
              
              u_xlat5 = u_xlat0.zzzz * unity_ObjectToWorld[1];
              
              u_xlat5 = unity_ObjectToWorld[0] * u_xlat0.xxxx + u_xlat5;
              
              u_xlat5 = unity_ObjectToWorld[2] * in_v.vertex.zzzz + u_xlat5;
              
              u_xlat5 = u_xlat5 + unity_ObjectToWorld[3];
              
              u_xlat6 = u_xlat5.yyyy * unity_MatrixVP[1];
              
              u_xlat6 = unity_MatrixVP[0] * u_xlat5.xxxx + u_xlat6;
              
              u_xlat6 = unity_MatrixVP[2] * u_xlat5.zzzz + u_xlat6;
              
              out_v.vertex = unity_MatrixVP[3] * u_xlat5.wwww + u_xlat6;
              
              out_v.color.xyz = u_xlat3.xyz;
              
              out_v.color.w = u_xlat7.x;
              
              out_v.texcoord.yz = u_xlat4.zz;
              
              out_v.texcoord1.xy = u_xlat1.xy;
              
              return;
      
      }
          
          u_xlat0.xzw = in_v.vertex.xyz + (-in_v.normal.xyz);
          
          u_xlat0.x = dot(u_xlat0.xzw, u_xlat0.xzw);
          
          u_xlat0.x = sqrt(u_xlat0.x);
          
          u_xlat0.x = u_xlat0.x * _AutoTextureOffset + in_v.texcoord.x;
          
          out_v.texcoord.x = u_xlat0.x * _TextureScale + _TextureOffset;
          
          u_xlat0.xz = u_xlat2.yx * float2(1.0, -1.0);
          
          u_xlat0.xz = u_xlat0.xz * u_xlat4.zz + in_v.vertex.xy;
          
          u_xlat2 = u_xlat0.zzzz * unity_ObjectToWorld[1];
          
          u_xlat2 = unity_ObjectToWorld[0] * u_xlat0.xxxx + u_xlat2;
          
          u_xlat2 = unity_ObjectToWorld[2] * in_v.vertex.zzzz + u_xlat2;
          
          u_xlat2 = u_xlat2 + unity_ObjectToWorld[3];
          
          u_xlat5 = u_xlat2.yyyy * unity_MatrixVP[1];
          
          u_xlat5 = unity_MatrixVP[0] * u_xlat2.xxxx + u_xlat5;
          
          u_xlat5 = unity_MatrixVP[2] * u_xlat2.zzzz + u_xlat5;
          
          out_v.vertex = unity_MatrixVP[3] * u_xlat2.wwww + u_xlat5;
          
          out_v.color.xyz = u_xlat3.xyz;
          
          out_v.color.w = u_xlat7.x;
          
          out_v.texcoord.y = 0.0;
          
          out_v.texcoord.z = u_xlat4.z;
          
          out_v.texcoord1.xy = u_xlat1.xy;
          
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
