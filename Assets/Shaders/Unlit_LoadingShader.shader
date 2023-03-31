Shader "Unlit/LoadingShader"
{
  Properties
  {
    [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
    _Color ("Tint", Color) = (1,1,1,1)
    _StencilComp ("Stencil Comparison", float) = 8
    _Stencil ("Stencil ID", float) = 0
    _StencilOp ("Stencil Operation", float) = 0
    _StencilWriteMask ("Stencil Write Mask", float) = 255
    _StencilReadMask ("Stencil Read Mask", float) = 255
    _ColorMask ("Color Mask", float) = 15
    [Toggle(UNITY_UI_ALPHACLIP)] _UseUIAlphaClip ("Use Alpha Clip", float) = 0
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
    Pass // ind: 1, name: Default
    {
      Name "Default"
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
      Stencil
      { 
        Ref 0
        ReadMask 0
        WriteMask 0
        Pass Keep
        Fail Keep
        ZFail Keep
        PassFront Keep
        FailFront Keep
        ZFailFront Keep
        PassBack Keep
        FailBack Keep
        ZFailBack Keep
      } 
      Blend SrcAlpha OneMinusSrcAlpha
      ColorMask 0
      // m_ProgramMask = 6
      CGPROGRAM
      //#pragma target 4.0
      
      #pragma vertex vert
      #pragma fragment frag
      
      #include "UnityCG.cginc"
      
      
      #define CODE_BLOCK_VERTEX
      //uniform float4x4 unity_ObjectToWorld;
      //uniform float4x4 unity_MatrixVP;
      uniform float4 _Color;
      uniform float4 _MainTex_ST;
      //uniform float4 _Time;
      uniform float4 _TextureSampleAdd;
      uniform sampler2D _MainTex;
      struct appdata_t
      {
          float4 vertex :POSITION0;
          float4 color :COLOR0;
          float2 texcoord :TEXCOORD0;
      };
      
      struct OUT_Data_Vert
      {
          float4 color :COLOR0;
          float2 texcoord :TEXCOORD0;
          float4 texcoord1 :TEXCOORD1;
          float4 vertex :SV_POSITION;
      };
      
      struct v2f
      {
          float4 color :COLOR0;
          float2 texcoord :TEXCOORD0;
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
          out_v.vertex = UnityObjectToClipPos(in_v.vertex);
          out_v.color = (in_v.color * _Color);
          out_v.texcoord.xy = TRANSFORM_TEX(in_v.texcoord.xy, _MainTex);
          out_v.texcoord1 = in_v.vertex;
          return out_v;
      }
      
      #define CODE_BLOCK_FRAGMENT
      float4 u_xlat0_d;
      int u_xlatb0;
      float4 u_xlat1_d;
      float u_xlat2;
      float u_xlat4;
      int u_xlatb4;
      float u_xlat6;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlat0_d = tex2D(_MainTex, in_f.texcoord.xy);
          u_xlat0_d.xyz = (u_xlat0_d.xyz + _TextureSampleAdd.xyz);
          u_xlat4 = (u_xlat0_d.z + (-0.5));
          u_xlatb4 = (u_xlat4<0);
          if(((int(u_xlatb4) * int(4294967295))!=0))
          {
              discard;
          }
          u_xlat0_d.xy = ((u_xlat0_d.xy * float2(2, 2)) + float2(-1, (-1)));
          u_xlatb4 = (0.5<u_xlat0_d.x);
          if(u_xlatb4)
          {
              u_xlat4 = (in_f.texcoord.y + 2);
              u_xlat4 = (u_xlat4 * 1.57079637);
              u_xlat4 = ((_Time.z * 4) + u_xlat4);
              u_xlat4 = sin(u_xlat4);
              u_xlat4 = ((u_xlat4 * 0.5) + 0.5);
              u_xlat4 = log2(u_xlat4);
              u_xlat4 = (u_xlat4 * 24);
              u_xlat4 = exp2(u_xlat4);
              u_xlat4 = (u_xlat4 + (-0.400000006));
              u_xlat4 = (u_xlat4 * 20.0000076);
              u_xlat4 = clamp(u_xlat4, 0, 1);
              u_xlat6 = ((u_xlat4 * (-2)) + 3);
              u_xlat4 = (u_xlat4 * u_xlat4);
              u_xlat4 = (u_xlat4 * u_xlat6);
              u_xlatb4 = (float4(0, 0, 0, 0).x != float4(u_xlat4, u_xlat4, u_xlat4, u_xlat4).x && float4(0, 0, 0, 0).y != float4(u_xlat4, u_xlat4, u_xlat4, u_xlat4).y && float4(0, 0, 0, 0).z != float4(u_xlat4, u_xlat4, u_xlat4, u_xlat4).z && float4(0, 0, 0, 0).w != float4(u_xlat4, u_xlat4, u_xlat4, u_xlat4).w);
              u_xlat1_d = (int(u_xlatb4))?(float4(1, 1, 1, 1)):(float4(0, 0, 0, 0.699999988));
              out_f.color = (u_xlat1_d * in_f.color);
              return out_f;
          }
          u_xlatb0 = (u_xlat0_d.x<(-0.5));
          if(u_xlatb0)
          {
              u_xlat0_d.x = ((-in_f.texcoord.y) + 1);
              u_xlat0_d.x = (u_xlat0_d.x * 1.57079637);
              u_xlat0_d.x = ((_Time.z * 4) + u_xlat0_d.x);
              u_xlat0_d.x = sin(u_xlat0_d.x);
              u_xlat0_d.x = ((u_xlat0_d.x * 0.5) + 0.5);
              u_xlat0_d.x = log2(u_xlat0_d.x);
              u_xlat0_d.x = (u_xlat0_d.x * 24);
              u_xlat0_d.x = exp2(u_xlat0_d.x);
              u_xlat0_d.x = (u_xlat0_d.x + (-0.400000006));
              u_xlat0_d.x = (u_xlat0_d.x * 20.0000076);
              u_xlat0_d.x = clamp(u_xlat0_d.x, 0, 1);
              u_xlat4 = ((u_xlat0_d.x * (-2)) + 3);
              u_xlat0_d.x = (u_xlat0_d.x * u_xlat0_d.x);
              u_xlat0_d.x = (u_xlat0_d.x * u_xlat4);
              float _tmp_dvx_2 = u_xlat0_d.x;
              u_xlatb0 = (float4(0, 0, 0, 0).x != float4(_tmp_dvx_2, _tmp_dvx_2, _tmp_dvx_2, _tmp_dvx_2).x && float4(0, 0, 0, 0).y != float4(_tmp_dvx_2, _tmp_dvx_2, _tmp_dvx_2, _tmp_dvx_2).y && float4(0, 0, 0, 0).z != float4(_tmp_dvx_2, _tmp_dvx_2, _tmp_dvx_2, _tmp_dvx_2).z && float4(0, 0, 0, 0).w != float4(_tmp_dvx_2, _tmp_dvx_2, _tmp_dvx_2, _tmp_dvx_2).w);
              u_xlat1_d = (int(u_xlatb0))?(float4(1, 1, 1, 1)):(float4(0, 0, 0, 0.699999988));
              out_f.color = (u_xlat1_d * in_f.color);
              return out_f;
          }
          u_xlatb0 = (0.5<u_xlat0_d.y);
          if(u_xlatb0)
          {
              u_xlat0_d.x = ((-in_f.texcoord.x) + 4);
              u_xlat0_d.x = (u_xlat0_d.x * 1.57079637);
              u_xlat0_d.x = ((_Time.z * 4) + u_xlat0_d.x);
              u_xlat0_d.x = sin(u_xlat0_d.x);
              u_xlat0_d.x = ((u_xlat0_d.x * 0.5) + 0.5);
              u_xlat0_d.x = log2(u_xlat0_d.x);
              u_xlat0_d.x = (u_xlat0_d.x * 24);
              u_xlat0_d.x = exp2(u_xlat0_d.x);
              u_xlat0_d.x = (u_xlat0_d.x + (-0.400000006));
              u_xlat0_d.x = (u_xlat0_d.x * 20.0000076);
              u_xlat0_d.x = clamp(u_xlat0_d.x, 0, 1);
              u_xlat4 = ((u_xlat0_d.x * (-2)) + 3);
              u_xlat0_d.x = (u_xlat0_d.x * u_xlat0_d.x);
              u_xlat0_d.x = (u_xlat0_d.x * u_xlat4);
              float _tmp_dvx_3 = u_xlat0_d.x;
              u_xlatb0 = (float4(0, 0, 0, 0).x != float4(_tmp_dvx_3, _tmp_dvx_3, _tmp_dvx_3, _tmp_dvx_3).x && float4(0, 0, 0, 0).y != float4(_tmp_dvx_3, _tmp_dvx_3, _tmp_dvx_3, _tmp_dvx_3).y && float4(0, 0, 0, 0).z != float4(_tmp_dvx_3, _tmp_dvx_3, _tmp_dvx_3, _tmp_dvx_3).z && float4(0, 0, 0, 0).w != float4(_tmp_dvx_3, _tmp_dvx_3, _tmp_dvx_3, _tmp_dvx_3).w);
              u_xlat1_d = (int(u_xlatb0))?(float4(1, 1, 1, 1)):(float4(0, 0, 0, 0.699999988));
              out_f.color = (u_xlat1_d * in_f.color);
              return out_f;
          }
          u_xlatb0 = (u_xlat0_d.y<(-0.5));
          if(u_xlatb0)
          {
              u_xlat0_d.x = (in_f.texcoord.x + 1);
              u_xlat0_d.x = (u_xlat0_d.x * 1.57079637);
              u_xlat0_d.x = ((_Time.z * 4) + u_xlat0_d.x);
              u_xlat0_d.x = sin(u_xlat0_d.x);
              u_xlat0_d.x = ((u_xlat0_d.x * 0.5) + 0.5);
              u_xlat0_d.x = log2(u_xlat0_d.x);
              u_xlat0_d.x = (u_xlat0_d.x * 24);
              u_xlat0_d.x = exp2(u_xlat0_d.x);
              u_xlat0_d.x = (u_xlat0_d.x + (-0.400000006));
              u_xlat0_d.x = (u_xlat0_d.x * 20.0000076);
              u_xlat0_d.x = clamp(u_xlat0_d.x, 0, 1);
              u_xlat2 = ((u_xlat0_d.x * (-2)) + 3);
              u_xlat0_d.x = (u_xlat0_d.x * u_xlat0_d.x);
              u_xlat0_d.x = (u_xlat0_d.x * u_xlat2);
              float _tmp_dvx_4 = u_xlat0_d.x;
              u_xlatb0 = (float4(0, 0, 0, 0).x != float4(_tmp_dvx_4, _tmp_dvx_4, _tmp_dvx_4, _tmp_dvx_4).x && float4(0, 0, 0, 0).y != float4(_tmp_dvx_4, _tmp_dvx_4, _tmp_dvx_4, _tmp_dvx_4).y && float4(0, 0, 0, 0).z != float4(_tmp_dvx_4, _tmp_dvx_4, _tmp_dvx_4, _tmp_dvx_4).z && float4(0, 0, 0, 0).w != float4(_tmp_dvx_4, _tmp_dvx_4, _tmp_dvx_4, _tmp_dvx_4).w);
              u_xlat0_d = (int(u_xlatb0))?(float4(1, 1, 1, 1)):(float4(0, 0, 0, 0.699999988));
              out_f.color = (u_xlat0_d * in_f.color);
              return out_f;
          }
          out_f.color = float4(0, 0, 0, 0);
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
