Shader "Hidden/PostProcessing/MotionBlur"
{
  Properties
  {
  }
  SubShader
  {
    Tags
    { 
    }
    Pass // ind: 1, name: 
    {
      Tags
      { 
      }
      ZTest Always
      ZWrite Off
      Cull Off
      // m_ProgramMask = 6
      CGPROGRAM
      //#pragma target 4.0
      
      #pragma vertex vert
      #pragma fragment frag
      
      #include "UnityCG.cginc"
      
      
      #define CODE_BLOCK_VERTEX
      
      
      uniform float _RenderViewportScaleFactor;
      
      uniform float4 unity_OrthoParams;
      
      uniform float4 _ZBufferParams;
      
      uniform float4 _CameraMotionVectorsTexture_TexelSize;
      
      uniform float _VelocityScale;
      
      uniform float _RcpMaxBlurRadius;
      
      uniform sampler2D _CameraMotionVectorsTexture;
      
      uniform sampler2D _CameraDepthTexture;
      
      
      
      struct appdata_t
      {
          
          float3 vertex : POSITION0;
      
      };
      
      
      struct OUT_Data_Vert
      {
          
          float2 texcoord : TEXCOORD0;
          
          float2 texcoord1 : TEXCOORD1;
          
          float4 vertex : SV_POSITION;
      
      };
      
      
      struct v2f
      {
          
          float2 texcoord : TEXCOORD0;
      
      };
      
      
      struct OUT_Data_Frag
      {
          
          float4 color : SV_Target0;
      
      };
      
      
      float2 u_xlat0;
      
      OUT_Data_Vert vert(appdata_t in_v)
      {
          
          out_v.vertex.xy = in_v.vertex.xy;
          
          out_v.vertex.zw = float2(0.0, 1.0);
          
          u_xlat0.xy = in_v.vertex.xy + float2(1.0, 1.0);
          
          u_xlat0.xy = u_xlat0.xy * float2(0.5, 0.5);
          
          out_v.texcoord1.xy = u_xlat0.xy * float2(_RenderViewportScaleFactor);
          
          out_v.texcoord.xy = in_v.vertex.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
          
          return;
      
      }
      
      
      #define CODE_BLOCK_FRAGMENT
      
      float2 u_xlat0_d;
      
      float4 u_xlat1;
      
      float u_xlat2;
      
      float u_xlat4;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d.x = _VelocityScale * 0.5;
          
          u_xlat0_d.xy = u_xlat0_d.xx * _CameraMotionVectorsTexture_TexelSize.zw;
          
          u_xlat1 = texture(_CameraMotionVectorsTexture, in_f.texcoord.xy);
          
          u_xlat0_d.xy = u_xlat0_d.xy * u_xlat1.xy;
          
          u_xlat4 = dot(u_xlat0_d.xy, u_xlat0_d.xy);
          
          u_xlat4 = sqrt(u_xlat4);
          
          u_xlat4 = u_xlat4 * _RcpMaxBlurRadius;
          
          u_xlat4 = max(u_xlat4, 1.0);
          
          u_xlat0_d.xy = u_xlat0_d.xy / float2(u_xlat4);
          
          u_xlat0_d.xy = u_xlat0_d.xy * float2(float2(_RcpMaxBlurRadius, _RcpMaxBlurRadius)) + float2(1.0, 1.0);
          
          out_f.color.xy = u_xlat0_d.xy * float2(0.5, 0.5);
          
          u_xlat0_d.x = (-unity_OrthoParams.w) + 1.0;
          
          u_xlat1 = texture(_CameraDepthTexture, in_f.texcoord.xy);
          
          u_xlat2 = u_xlat1.x * _ZBufferParams.x;
          
          u_xlat0_d.x = u_xlat0_d.x * u_xlat2 + _ZBufferParams.y;
          
          u_xlat2 = (-unity_OrthoParams.w) * u_xlat2 + 1.0;
          
          out_f.color.z = u_xlat2 / u_xlat0_d.x;
          
          out_f.color.w = 0.0;
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
    Pass // ind: 2, name: 
    {
      Tags
      { 
      }
      ZTest Always
      ZWrite Off
      Cull Off
      // m_ProgramMask = 6
      CGPROGRAM
      //#pragma target 4.0
      
      #pragma vertex vert
      #pragma fragment frag
      
      #include "UnityCG.cginc"
      
      
      #define CODE_BLOCK_VERTEX
      
      
      uniform float _RenderViewportScaleFactor;
      
      uniform float4 _MainTex_TexelSize;
      
      uniform float _MaxBlurRadius;
      
      uniform sampler2D _MainTex;
      
      
      
      struct appdata_t
      {
          
          float3 vertex : POSITION0;
      
      };
      
      
      struct OUT_Data_Vert
      {
          
          float2 texcoord : TEXCOORD0;
          
          float2 texcoord1 : TEXCOORD1;
          
          float4 vertex : SV_POSITION;
      
      };
      
      
      struct v2f
      {
          
          float2 texcoord : TEXCOORD0;
      
      };
      
      
      struct OUT_Data_Frag
      {
          
          float4 color : SV_Target0;
      
      };
      
      
      float2 u_xlat0;
      
      OUT_Data_Vert vert(appdata_t in_v)
      {
          
          out_v.vertex.xy = in_v.vertex.xy;
          
          out_v.vertex.zw = float2(0.0, 1.0);
          
          u_xlat0.xy = in_v.vertex.xy + float2(1.0, 1.0);
          
          u_xlat0.xy = u_xlat0.xy * float2(0.5, 0.5);
          
          out_v.texcoord1.xy = u_xlat0.xy * float2(_RenderViewportScaleFactor);
          
          out_v.texcoord.xy = in_v.vertex.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
          
          return;
      
      }
      
      
      #define CODE_BLOCK_FRAGMENT
      
      float4 u_xlat0_d;
      
      float4 u_xlat1;
      
      int u_xlatb1;
      
      float4 u_xlat2;
      
      float u_xlat4;
      
      float u_xlat6;
      
      int u_xlatb6;
      
      float u_xlat9;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = _MainTex_TexelSize.xyxy * float4(-0.5, -0.5, 0.5, -0.5) + in_f.texcoord.xyxy;
          
          u_xlat1 = texture(_MainTex, u_xlat0_d.xy);
          
          u_xlat0_d = texture(_MainTex, u_xlat0_d.zw);
          
          u_xlat0_d.xy = u_xlat0_d.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
          
          u_xlat0_d.zw = u_xlat1.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
          
          u_xlat0_d = u_xlat0_d * float4(_MaxBlurRadius);
          
          u_xlat1.x = dot(u_xlat0_d.zw, u_xlat0_d.zw);
          
          u_xlat4 = dot(u_xlat0_d.xy, u_xlat0_d.xy);
          
          u_xlatb1 = u_xlat1.x<u_xlat4;
          
          u_xlat0_d.xy = (int(u_xlatb1)) ? u_xlat0_d.xy : u_xlat0_d.zw;
          
          u_xlat6 = dot(u_xlat0_d.xy, u_xlat0_d.xy);
          
          u_xlat1 = _MainTex_TexelSize.xyxy * float4(-0.5, 0.5, 0.5, 0.5) + in_f.texcoord.xyxy;
          
          u_xlat2 = texture(_MainTex, u_xlat1.xy);
          
          u_xlat1 = texture(_MainTex, u_xlat1.zw);
          
          u_xlat1.xy = u_xlat1.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
          
          u_xlat1.zw = u_xlat2.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
          
          u_xlat1 = u_xlat1 * float4(_MaxBlurRadius);
          
          u_xlat9 = dot(u_xlat1.zw, u_xlat1.zw);
          
          u_xlatb6 = u_xlat6<u_xlat9;
          
          u_xlat0_d.xy = (int(u_xlatb6)) ? u_xlat1.zw : u_xlat0_d.xy;
          
          u_xlat6 = dot(u_xlat0_d.xy, u_xlat0_d.xy);
          
          u_xlat9 = dot(u_xlat1.xy, u_xlat1.xy);
          
          u_xlatb6 = u_xlat6<u_xlat9;
          
          out_f.color.xy = (int(u_xlatb6)) ? u_xlat1.xy : u_xlat0_d.xy;
          
          out_f.color.zw = float2(0.0, 0.0);
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
    Pass // ind: 3, name: 
    {
      Tags
      { 
      }
      ZTest Always
      ZWrite Off
      Cull Off
      // m_ProgramMask = 6
      CGPROGRAM
      //#pragma target 4.0
      
      #pragma vertex vert
      #pragma fragment frag
      
      #include "UnityCG.cginc"
      
      
      #define CODE_BLOCK_VERTEX
      
      
      uniform float _RenderViewportScaleFactor;
      
      uniform float4 _MainTex_TexelSize;
      
      uniform sampler2D _MainTex;
      
      
      
      struct appdata_t
      {
          
          float3 vertex : POSITION0;
      
      };
      
      
      struct OUT_Data_Vert
      {
          
          float2 texcoord : TEXCOORD0;
          
          float2 texcoord1 : TEXCOORD1;
          
          float4 vertex : SV_POSITION;
      
      };
      
      
      struct v2f
      {
          
          float2 texcoord : TEXCOORD0;
      
      };
      
      
      struct OUT_Data_Frag
      {
          
          float4 color : SV_Target0;
      
      };
      
      
      float2 u_xlat0;
      
      OUT_Data_Vert vert(appdata_t in_v)
      {
          
          out_v.vertex.xy = in_v.vertex.xy;
          
          out_v.vertex.zw = float2(0.0, 1.0);
          
          u_xlat0.xy = in_v.vertex.xy + float2(1.0, 1.0);
          
          u_xlat0.xy = u_xlat0.xy * float2(0.5, 0.5);
          
          out_v.texcoord1.xy = u_xlat0.xy * float2(_RenderViewportScaleFactor);
          
          out_v.texcoord.xy = in_v.vertex.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
          
          return;
      
      }
      
      
      #define CODE_BLOCK_FRAGMENT
      
      float4 u_xlat0_d;
      
      float4 u_xlat1;
      
      float4 u_xlat2;
      
      float u_xlat6;
      
      int u_xlatb6;
      
      float u_xlat9;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = _MainTex_TexelSize.xyxy * float4(-0.5, -0.5, 0.5, -0.5) + in_f.texcoord.xyxy;
          
          u_xlat1 = texture(_MainTex, u_xlat0_d.xy);
          
          u_xlat0_d = texture(_MainTex, u_xlat0_d.zw);
          
          u_xlat6 = dot(u_xlat1.xy, u_xlat1.xy);
          
          u_xlat9 = dot(u_xlat0_d.xy, u_xlat0_d.xy);
          
          u_xlatb6 = u_xlat6<u_xlat9;
          
          u_xlat0_d.xy = (int(u_xlatb6)) ? u_xlat0_d.xy : u_xlat1.xy;
          
          u_xlat6 = dot(u_xlat0_d.xy, u_xlat0_d.xy);
          
          u_xlat1 = _MainTex_TexelSize.xyxy * float4(-0.5, 0.5, 0.5, 0.5) + in_f.texcoord.xyxy;
          
          u_xlat2 = texture(_MainTex, u_xlat1.xy);
          
          u_xlat1 = texture(_MainTex, u_xlat1.zw);
          
          u_xlat9 = dot(u_xlat2.xy, u_xlat2.xy);
          
          u_xlatb6 = u_xlat6<u_xlat9;
          
          u_xlat0_d.xy = (int(u_xlatb6)) ? u_xlat2.xy : u_xlat0_d.xy;
          
          u_xlat6 = dot(u_xlat0_d.xy, u_xlat0_d.xy);
          
          u_xlat9 = dot(u_xlat1.xy, u_xlat1.xy);
          
          u_xlatb6 = u_xlat6<u_xlat9;
          
          out_f.color.xy = (int(u_xlatb6)) ? u_xlat1.xy : u_xlat0_d.xy;
          
          out_f.color.zw = float2(0.0, 0.0);
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
    Pass // ind: 4, name: 
    {
      Tags
      { 
      }
      ZTest Always
      ZWrite Off
      Cull Off
      // m_ProgramMask = 6
      CGPROGRAM
      //#pragma target 4.0
      
      #pragma vertex vert
      #pragma fragment frag
      
      #include "UnityCG.cginc"
      
      
      #define CODE_BLOCK_VERTEX
      
      
      uniform float _RenderViewportScaleFactor;
      
      uniform float4 _MainTex_TexelSize;
      
      uniform int _TileMaxLoop;
      
      uniform float2 _TileMaxOffs;
      
      uniform sampler2D _MainTex;
      
      
      
      struct appdata_t
      {
          
          float3 vertex : POSITION0;
      
      };
      
      
      struct OUT_Data_Vert
      {
          
          float2 texcoord : TEXCOORD0;
          
          float2 texcoord1 : TEXCOORD1;
          
          float4 vertex : SV_POSITION;
      
      };
      
      
      struct v2f
      {
          
          float2 texcoord : TEXCOORD0;
      
      };
      
      
      struct OUT_Data_Frag
      {
          
          float4 color : SV_Target0;
      
      };
      
      
      float2 u_xlat0;
      
      OUT_Data_Vert vert(appdata_t in_v)
      {
          
          out_v.vertex.xy = in_v.vertex.xy;
          
          out_v.vertex.zw = float2(0.0, 1.0);
          
          u_xlat0.xy = in_v.vertex.xy + float2(1.0, 1.0);
          
          u_xlat0.xy = u_xlat0.xy * float2(0.5, 0.5);
          
          out_v.texcoord1.xy = u_xlat0.xy * float2(_RenderViewportScaleFactor);
          
          out_v.texcoord.xy = in_v.vertex.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
          
          return;
      
      }
      
      
      #define CODE_BLOCK_FRAGMENT
      
      float2 u_xlat0_d;
      
      float4 u_xlat1;
      
      int u_xlati2;
      
      float2 u_xlat3;
      
      float4 u_xlat4;
      
      float2 u_xlat7;
      
      int u_xlatb7;
      
      float2 u_xlat10;
      
      float2 u_xlat13;
      
      int u_xlatb13;
      
      int u_xlati17;
      
      float u_xlat18;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d.xy = _MainTex_TexelSize.xy * float2(_TileMaxOffs.x, _TileMaxOffs.y) + in_f.texcoord.xy;
          
          u_xlat1.y = float(0.0);
          
          u_xlat1.z = float(0.0);
          
          u_xlat1.xw = _MainTex_TexelSize.xy;
          
          u_xlat10.x = float(0.0);
          
          u_xlat10.y = float(0.0);
          
          for(int u_xlati_loop_1 = 0 ; u_xlati_loop_1<_TileMaxLoop ; u_xlati_loop_1++)
      
          
              {
              
              u_xlat7.x = float(u_xlati_loop_1);
              
              u_xlat7.xy = u_xlat1.xy * u_xlat7.xx + u_xlat0_d.xy;
              
              u_xlat3.xy = u_xlat10.xy;
              
              for(int u_xlati_loop_2 = 0 ; u_xlati_loop_2<_TileMaxLoop ; u_xlati_loop_2++)
      
              
                  {
                  
                  u_xlat13.x = float(u_xlati_loop_2);
                  
                  u_xlat13.xy = u_xlat1.zw * u_xlat13.xx + u_xlat7.xy;
                  
                  u_xlat4 = texture(_MainTex, u_xlat13.xy);
                  
                  u_xlat13.x = dot(u_xlat3.xy, u_xlat3.xy);
                  
                  u_xlat18 = dot(u_xlat4.xy, u_xlat4.xy);
                  
                  u_xlatb13 = u_xlat13.x<u_xlat18;
                  
                  u_xlat3.xy = (int(u_xlatb13)) ? u_xlat4.xy : u_xlat3.xy;
      
      }
              
              u_xlat10.xy = u_xlat3.xy;
      
      }
          
          out_f.color.xy = u_xlat10.xy;
          
          out_f.color.zw = float2(0.0, 0.0);
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
    Pass // ind: 5, name: 
    {
      Tags
      { 
      }
      ZTest Always
      ZWrite Off
      Cull Off
      // m_ProgramMask = 6
      CGPROGRAM
      //#pragma target 4.0
      
      #pragma vertex vert
      #pragma fragment frag
      
      #include "UnityCG.cginc"
      
      
      #define CODE_BLOCK_VERTEX
      
      
      uniform float _RenderViewportScaleFactor;
      
      uniform float4 _MainTex_TexelSize;
      
      uniform sampler2D _MainTex;
      
      
      
      struct appdata_t
      {
          
          float3 vertex : POSITION0;
      
      };
      
      
      struct OUT_Data_Vert
      {
          
          float2 texcoord : TEXCOORD0;
          
          float2 texcoord1 : TEXCOORD1;
          
          float4 vertex : SV_POSITION;
      
      };
      
      
      struct v2f
      {
          
          float2 texcoord : TEXCOORD0;
      
      };
      
      
      struct OUT_Data_Frag
      {
          
          float4 color : SV_Target0;
      
      };
      
      
      float2 u_xlat0;
      
      OUT_Data_Vert vert(appdata_t in_v)
      {
          
          out_v.vertex.xy = in_v.vertex.xy;
          
          out_v.vertex.zw = float2(0.0, 1.0);
          
          u_xlat0.xy = in_v.vertex.xy + float2(1.0, 1.0);
          
          u_xlat0.xy = u_xlat0.xy * float2(0.5, 0.5);
          
          out_v.texcoord1.xy = u_xlat0.xy * float2(_RenderViewportScaleFactor);
          
          out_v.texcoord.xy = in_v.vertex.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
          
          return;
      
      }
      
      
      #define CODE_BLOCK_FRAGMENT
      
      float4 u_xlat0_d;
      
      float4 u_xlat1;
      
      float4 u_xlat2;
      
      float4 u_xlat3;
      
      float u_xlat8;
      
      int u_xlatb8;
      
      float2 u_xlat9;
      
      float u_xlat12;
      
      int u_xlatb12;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = _MainTex_TexelSize.yyxy * float4(0.0, 1.0, 1.0, 1.0) + in_f.texcoord.xyxy;
          
          u_xlat1 = texture(_MainTex, u_xlat0_d.xy);
          
          u_xlat0_d = texture(_MainTex, u_xlat0_d.zw);
          
          u_xlat8 = dot(u_xlat1.xy, u_xlat1.xy);
          
          u_xlat12 = dot(u_xlat0_d.xy, u_xlat0_d.xy);
          
          u_xlatb8 = u_xlat8<u_xlat12;
          
          u_xlat0_d.xy = (int(u_xlatb8)) ? u_xlat0_d.xy : u_xlat1.xy;
          
          u_xlat8 = dot(u_xlat0_d.xy, u_xlat0_d.xy);
          
          u_xlat1 = _MainTex_TexelSize.xyxy * float4(1.0, 0.0, -1.0, 1.0) + in_f.texcoord.xyxy;
          
          u_xlat2 = texture(_MainTex, u_xlat1.zw);
          
          u_xlat1 = texture(_MainTex, u_xlat1.xy);
          
          u_xlat12 = dot(u_xlat2.xy, u_xlat2.xy);
          
          u_xlatb8 = u_xlat12<u_xlat8;
          
          u_xlat0_d.xy = (int(u_xlatb8)) ? u_xlat0_d.xy : u_xlat2.xy;
          
          u_xlat8 = dot(u_xlat0_d.xy, u_xlat0_d.xy);
          
          u_xlat12 = dot(u_xlat1.xy, u_xlat1.xy);
          
          u_xlat2 = texture(_MainTex, in_f.texcoord.xy);
          
          u_xlat9.xy = u_xlat2.xy * float2(1.00999999, 1.00999999);
          
          u_xlat2.x = dot(u_xlat9.xy, u_xlat9.xy);
          
          u_xlatb12 = u_xlat2.x<u_xlat12;
          
          u_xlat1.xy = (int(u_xlatb12)) ? u_xlat1.xy : u_xlat9.xy;
          
          u_xlat12 = dot(u_xlat1.xy, u_xlat1.xy);
          
          u_xlat2 = (-_MainTex_TexelSize.xyxy) * float4(-1.0, 1.0, 1.0, 0.0) + in_f.texcoord.xyxy;
          
          u_xlat3 = texture(_MainTex, u_xlat2.zw);
          
          u_xlat2 = texture(_MainTex, u_xlat2.xy);
          
          u_xlat9.x = dot(u_xlat3.xy, u_xlat3.xy);
          
          u_xlatb12 = u_xlat9.x<u_xlat12;
          
          u_xlat1.xy = (int(u_xlatb12)) ? u_xlat1.xy : u_xlat3.xy;
          
          u_xlat12 = dot(u_xlat1.xy, u_xlat1.xy);
          
          u_xlatb8 = u_xlat12<u_xlat8;
          
          u_xlat0_d.xy = (int(u_xlatb8)) ? u_xlat0_d.xy : u_xlat1.xy;
          
          u_xlat8 = dot(u_xlat0_d.xy, u_xlat0_d.xy);
          
          u_xlat12 = dot(u_xlat2.xy, u_xlat2.xy);
          
          u_xlat1 = (-_MainTex_TexelSize.xyyy) * float4(1.0, 1.0, 0.0, 1.0) + in_f.texcoord.xyxy;
          
          u_xlat3 = texture(_MainTex, u_xlat1.zw);
          
          u_xlat1 = texture(_MainTex, u_xlat1.xy);
          
          u_xlat9.x = dot(u_xlat3.xy, u_xlat3.xy);
          
          u_xlatb12 = u_xlat9.x<u_xlat12;
          
          u_xlat9.xy = (int(u_xlatb12)) ? u_xlat2.xy : u_xlat3.xy;
          
          u_xlat12 = dot(u_xlat9.xy, u_xlat9.xy);
          
          u_xlat2.x = dot(u_xlat1.xy, u_xlat1.xy);
          
          u_xlatb12 = u_xlat2.x<u_xlat12;
          
          u_xlat1.xy = (int(u_xlatb12)) ? u_xlat9.xy : u_xlat1.xy;
          
          u_xlat12 = dot(u_xlat1.xy, u_xlat1.xy);
          
          u_xlatb8 = u_xlat12<u_xlat8;
          
          u_xlat0_d.xy = (int(u_xlatb8)) ? u_xlat0_d.xy : u_xlat1.xy;
          
          out_f.color.xy = u_xlat0_d.xy * float2(0.990099013, 0.990099013);
          
          out_f.color.zw = float2(0.0, 0.0);
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
    Pass // ind: 6, name: 
    {
      Tags
      { 
      }
      ZTest Always
      ZWrite Off
      Cull Off
      // m_ProgramMask = 6
      CGPROGRAM
      //#pragma target 4.0
      
      #pragma vertex vert
      #pragma fragment frag
      
      #include "UnityCG.cginc"
      
      
      #define CODE_BLOCK_VERTEX
      
      
      uniform float _RenderViewportScaleFactor;
      
      uniform float4 _ScreenParams;
      
      uniform float4 _MainTex_TexelSize;
      
      uniform float2 _VelocityTex_TexelSize;
      
      uniform float2 _NeighborMaxTex_TexelSize;
      
      uniform float _MaxBlurRadius;
      
      uniform float _LoopCount;
      
      uniform sampler2D _MainTex;
      
      uniform sampler2D _VelocityTex;
      
      uniform sampler2D _NeighborMaxTex;
      
      
      
      struct appdata_t
      {
          
          float3 vertex : POSITION0;
      
      };
      
      
      struct OUT_Data_Vert
      {
          
          float2 texcoord : TEXCOORD0;
          
          float2 texcoord1 : TEXCOORD1;
          
          float4 vertex : SV_POSITION;
      
      };
      
      
      struct v2f
      {
          
          float2 texcoord : TEXCOORD0;
      
      };
      
      
      struct OUT_Data_Frag
      {
          
          float4 color : SV_Target0;
      
      };
      
      
      float2 u_xlat0;
      
      OUT_Data_Vert vert(appdata_t in_v)
      {
          
          out_v.vertex.xy = in_v.vertex.xy;
          
          out_v.vertex.zw = float2(0.0, 1.0);
          
          u_xlat0.xy = in_v.vertex.xy + float2(1.0, 1.0);
          
          u_xlat0.xy = u_xlat0.xy * float2(0.5, 0.5);
          
          out_v.texcoord1.xy = u_xlat0.xy * float2(_RenderViewportScaleFactor);
          
          out_v.texcoord.xy = in_v.vertex.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
          
          return;
      
      }
      
      
      #define CODE_BLOCK_FRAGMENT
      
      float4 u_xlat0_d;
      
      float4 u_xlat1;
      
      float4 u_xlat2;
      
      float3 u_xlat3;
      
      float u_xlat4;
      
      float4 u_xlat5;
      
      float4 u_xlat6;
      
      float3 u_xlat7;
      
      bool2 u_xlatb7;
      
      float4 u_xlat8;
      
      float4 u_xlat9;
      
      float u_xlat14;
      
      float u_xlat21;
      
      float2 u_xlat23;
      
      float u_xlat24;
      
      float u_xlat27;
      
      float u_xlat31;
      
      int u_xlatb31;
      
      float u_xlat32;
      
      int u_xlatb32;
      
      float u_xlat34;
      
      float u_xlat37;
      
      float u_xlat38;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = texture(_MainTex, in_f.texcoord.xy);
          
          u_xlat1.xy = in_f.texcoord.xy + float2(2.0, 0.0);
          
          u_xlat1.xy = u_xlat1.xy * _ScreenParams.xy;
          
          u_xlat1.xy = floor(u_xlat1.xy);
          
          u_xlat1.x = dot(float2(0.0671105608, 0.00583714992), u_xlat1.xy);
          
          u_xlat1.x = fract(u_xlat1.x);
          
          u_xlat1.x = u_xlat1.x * 52.9829178;
          
          u_xlat1.x = fract(u_xlat1.x);
          
          u_xlat1.x = u_xlat1.x * 6.28318548;
          
          u_xlat2.x = cos(u_xlat1.x);
          
          u_xlat1.x = sin(u_xlat1.x);
          
          u_xlat2.y = u_xlat1.x;
          
          u_xlat1.xy = u_xlat2.xy * float2(_NeighborMaxTex_TexelSize.x, _NeighborMaxTex_TexelSize.y);
          
          u_xlat1.xy = u_xlat1.xy * float2(0.25, 0.25) + in_f.texcoord.xy;
          
          u_xlat1 = texture(_NeighborMaxTex, u_xlat1.xy);
          
          u_xlat21 = dot(u_xlat1.xy, u_xlat1.xy);
          
          u_xlat21 = sqrt(u_xlat21);
          
          u_xlatb31 = u_xlat21<2.0;
          
          if(u_xlatb31)
      {
              
              out_f.color = u_xlat0_d;
              
              return;
      
      }
          
          u_xlat2 = textureLod(_VelocityTex, in_f.texcoord.xy, 0.0);
          
          u_xlat2.xy = u_xlat2.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
          
          u_xlat2.xy = u_xlat2.xy * float2(_MaxBlurRadius);
          
          u_xlat31 = dot(u_xlat2.xy, u_xlat2.xy);
          
          u_xlat31 = sqrt(u_xlat31);
          
          u_xlat3.xy = max(float2(u_xlat31), float2(0.5, 1.0));
          
          u_xlat31 = float(1.0) / u_xlat2.z;
          
          u_xlat32 = u_xlat3.x + u_xlat3.x;
          
          u_xlatb32 = u_xlat21<u_xlat32;
          
          u_xlat3.x = u_xlat21 / u_xlat3.x;
          
          u_xlat2.xy = u_xlat2.xy * u_xlat3.xx;
          
          u_xlat2.xy = (int(u_xlatb32)) ? u_xlat2.xy : u_xlat1.xy;
          
          u_xlat32 = u_xlat21 * 0.5;
          
          u_xlat32 = min(u_xlat32, _LoopCount);
          
          u_xlat32 = floor(u_xlat32);
          
          u_xlat3.x = float(1.0) / u_xlat32;
          
          u_xlat23.xy = in_f.texcoord.xy * _ScreenParams.xy;
          
          u_xlat23.xy = floor(u_xlat23.xy);
          
          u_xlat23.x = dot(float2(0.0671105608, 0.00583714992), u_xlat23.xy);
          
          u_xlat3.z = fract(u_xlat23.x);
          
          u_xlat23.xy = u_xlat3.zx * float2(52.9829178, 0.25);
          
          u_xlat23.x = fract(u_xlat23.x);
          
          u_xlat23.x = u_xlat23.x + -0.5;
          
          u_xlat4 = (-u_xlat3.x) * 0.5 + 1.0;
          
          u_xlat5.w = 1.0;
          
          u_xlat6.x = float(0.0);
          
          u_xlat6.y = float(0.0);
          
          u_xlat6.z = float(0.0);
          
          u_xlat6.w = float(0.0);
          
          u_xlat14 = u_xlat4;
          
          u_xlat24 = 0.0;
          
          u_xlat34 = u_xlat3.y;
          
          while(true)
      {
              
              u_xlatb7.x = u_xlat23.y>=u_xlat14;
              
              if(u_xlatb7.x)
      {
                  break;
      }
              
              u_xlat7.xy = float2(u_xlat24) * float2(0.25, 0.5);
              
              u_xlat7.xy = fract(u_xlat7.xy);
              
              u_xlatb7.xy = lessThan(float4(0.499000013, 0.499000013, 0.0, 0.0), u_xlat7.xyxx).xy;
              
              u_xlat7.xz = (u_xlatb7.x) ? u_xlat2.xy : u_xlat1.xy;
              
              u_xlat37 = (u_xlatb7.y) ? (-u_xlat14) : u_xlat14;
              
              u_xlat37 = u_xlat23.x * u_xlat3.x + u_xlat37;
              
              u_xlat7.xz = float2(u_xlat37) * u_xlat7.xz;
              
              u_xlat8.xy = u_xlat7.xz * _MainTex_TexelSize.xy + in_f.texcoord.xy;
              
              u_xlat7.xz = u_xlat7.xz * _VelocityTex_TexelSize.xy + in_f.texcoord.xy;
              
              u_xlat8 = textureLod(_MainTex, u_xlat8.xy, 0.0);
              
              u_xlat9 = textureLod(_VelocityTex, u_xlat7.xz, 0.0);
              
              u_xlat7.xz = u_xlat9.xy * float2(2.0, 2.0) + float2(-1.0, -1.0);
              
              u_xlat7.xz = u_xlat7.xz * float2(_MaxBlurRadius);
              
              u_xlat38 = u_xlat2.z + (-u_xlat9.z);
              
              u_xlat38 = u_xlat31 * u_xlat38;
              
              u_xlat38 = u_xlat38 * 20.0;
              
              u_xlat38 = clamp(u_xlat38, 0.0, 1.0);
              
              u_xlat7.x = dot(u_xlat7.xz, u_xlat7.xz);
              
              u_xlat7.x = sqrt(u_xlat7.x);
              
              u_xlat7.x = (-u_xlat34) + u_xlat7.x;
              
              u_xlat7.x = u_xlat38 * u_xlat7.x + u_xlat34;
              
              u_xlat27 = (-u_xlat21) * abs(u_xlat37) + u_xlat7.x;
              
              u_xlat27 = clamp(u_xlat27, 0.0, 1.0);
              
              u_xlat27 = u_xlat27 / u_xlat7.x;
              
              u_xlat37 = (-u_xlat14) + 1.20000005;
              
              u_xlat27 = u_xlat37 * u_xlat27;
              
              u_xlat5.xyz = u_xlat8.xyz;
              
              u_xlat6 = u_xlat5 * float4(u_xlat27) + u_xlat6;
              
              u_xlat34 = max(u_xlat34, u_xlat7.x);
              
              u_xlat5.x = (-u_xlat3.x) + u_xlat14;
              
              u_xlat14 = (u_xlatb7.y) ? u_xlat5.x : u_xlat14;
              
              u_xlat24 = u_xlat24 + 1.0;
      
      }
          
          u_xlat1.x = dot(float2(u_xlat34), float2(u_xlat32));
          
          u_xlat1.x = 1.20000005 / u_xlat1.x;
          
          u_xlat2.xyz = u_xlat0_d.xyz;
          
          u_xlat2.w = 1.0;
          
          u_xlat1 = u_xlat2 * u_xlat1.xxxx + u_xlat6;
          
          out_f.color.xyz = u_xlat1.xyz / u_xlat1.www;
          
          out_f.color.w = u_xlat0_d.w;
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
