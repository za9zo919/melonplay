Shader "Hidden/PostProcessing/SubpixelMorphologicalAntialiasing"
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
      
      
      uniform float4 _MainTex_TexelSize;
      
      uniform sampler2D _MainTex;
      
      
      
      struct appdata_t
      {
          
          float3 vertex : POSITION0;
      
      };
      
      
      struct OUT_Data_Vert
      {
          
          float2 texcoord : TEXCOORD0;
          
          float4 texcoord1 : TEXCOORD1;
          
          float4 texcoord2 : TEXCOORD2;
          
          float4 texcoord3 : TEXCOORD3;
          
          float4 vertex : SV_POSITION;
      
      };
      
      
      struct v2f
      {
          
          float2 texcoord : TEXCOORD0;
          
          float4 texcoord1 : TEXCOORD1;
          
          float4 texcoord2 : TEXCOORD2;
          
          float4 texcoord3 : TEXCOORD3;
      
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
          
          out_v.texcoord.xy = u_xlat0.xy;
          
          out_v.texcoord1 = _MainTex_TexelSize.xyxy * float4(-1.0, 0.0, 0.0, -1.0) + u_xlat0.xyxy;
          
          out_v.texcoord2 = _MainTex_TexelSize.xyxy * float4(1.0, 0.0, 0.0, 1.0) + u_xlat0.xyxy;
          
          out_v.texcoord3 = _MainTex_TexelSize.xyxy * float4(-2.0, 0.0, 0.0, -2.0) + u_xlat0.xyxy;
          
          return;
      
      }
      
      
      #define CODE_BLOCK_FRAGMENT
      
      float4 u_xlat0_d;
      
      bool2 u_xlatb0;
      
      float4 u_xlat1;
      
      float3 u_xlat2;
      
      float4 u_xlat3;
      
      float4 u_xlat4;
      
      float4 u_xlat5;
      
      float2 u_xlat6;
      
      float u_xlat12;
      
      float2 u_xlat14;
      
      bool2 u_xlatb14;
      
      float u_xlat18;
      
      int u_xlatb18;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = texture(_MainTex, in_f.texcoord.xy);
          
          u_xlat1 = texture(_MainTex, in_f.texcoord1.xy);
          
          u_xlat2.xyz = u_xlat0_d.xyz + (-u_xlat1.xyz);
          
          u_xlat18 = max(abs(u_xlat2.y), abs(u_xlat2.x));
          
          u_xlat2.x = max(abs(u_xlat2.z), u_xlat18);
          
          u_xlat3 = texture(_MainTex, in_f.texcoord1.zw);
          
          u_xlat4.xyz = u_xlat0_d.xyz + (-u_xlat3.xyz);
          
          u_xlat18 = max(abs(u_xlat4.y), abs(u_xlat4.x));
          
          u_xlat2.y = max(abs(u_xlat4.z), u_xlat18);
          
          u_xlatb14.xy = greaterThanEqual(u_xlat2.xyxy, float4(0.150000006, 0.150000006, 0.150000006, 0.150000006)).xy;
          
          u_xlat14.x = u_xlatb14.x ? float(1.0) : 0.0;
          
          u_xlat14.y = u_xlatb14.y ? float(1.0) : 0.0;
      
      ;
          
          u_xlat18 = dot(u_xlat14.xy, float2(1.0, 1.0));
          
          u_xlatb18 = u_xlat18==0.0;
          
          if(((int(u_xlatb18) * int(0xffffffffu)))!=0)
      {
              discard;
      }
          
          u_xlat4 = texture(_MainTex, in_f.texcoord2.xy);
          
          u_xlat4.xyz = u_xlat0_d.xyz + (-u_xlat4.xyz);
          
          u_xlat18 = max(abs(u_xlat4.y), abs(u_xlat4.x));
          
          u_xlat4.x = max(abs(u_xlat4.z), u_xlat18);
          
          u_xlat5 = texture(_MainTex, in_f.texcoord2.zw);
          
          u_xlat0_d.xyz = u_xlat0_d.xyz + (-u_xlat5.xyz);
          
          u_xlat0_d.x = max(abs(u_xlat0_d.y), abs(u_xlat0_d.x));
          
          u_xlat4.y = max(abs(u_xlat0_d.z), u_xlat0_d.x);
          
          u_xlat0_d.xy = max(u_xlat2.xy, u_xlat4.xy);
          
          u_xlat4 = texture(_MainTex, in_f.texcoord3.xy);
          
          u_xlat1.xyz = u_xlat1.xyz + (-u_xlat4.xyz);
          
          u_xlat12 = max(abs(u_xlat1.y), abs(u_xlat1.x));
          
          u_xlat1.x = max(abs(u_xlat1.z), u_xlat12);
          
          u_xlat4 = texture(_MainTex, in_f.texcoord3.zw);
          
          u_xlat3.xyz = u_xlat3.xyz + (-u_xlat4.xyz);
          
          u_xlat12 = max(abs(u_xlat3.y), abs(u_xlat3.x));
          
          u_xlat1.y = max(abs(u_xlat3.z), u_xlat12);
          
          u_xlat0_d.xy = max(u_xlat0_d.xy, u_xlat1.xy);
          
          u_xlat0_d.x = max(u_xlat0_d.y, u_xlat0_d.x);
          
          u_xlat6.xy = u_xlat2.xy + u_xlat2.xy;
          
          u_xlatb0.xy = greaterThanEqual(u_xlat6.xyxx, u_xlat0_d.xxxx).xy;
          
          u_xlat0_d.x = u_xlatb0.x ? float(1.0) : 0.0;
          
          u_xlat0_d.y = u_xlatb0.y ? float(1.0) : 0.0;
      
      ;
          
          u_xlat0_d.xy = u_xlat0_d.xy * u_xlat14.xy;
          
          out_f.color.xy = u_xlat0_d.xy;
          
          out_f.color.zw = float2(0.0, 0.0);
          
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
      
      
      uniform float4 _MainTex_TexelSize;
      
      uniform sampler2D _MainTex;
      
      
      
      struct appdata_t
      {
          
          float3 vertex : POSITION0;
      
      };
      
      
      struct OUT_Data_Vert
      {
          
          float2 texcoord : TEXCOORD0;
          
          float4 texcoord1 : TEXCOORD1;
          
          float4 texcoord2 : TEXCOORD2;
          
          float4 texcoord3 : TEXCOORD3;
          
          float4 vertex : SV_POSITION;
      
      };
      
      
      struct v2f
      {
          
          float2 texcoord : TEXCOORD0;
          
          float4 texcoord1 : TEXCOORD1;
          
          float4 texcoord2 : TEXCOORD2;
          
          float4 texcoord3 : TEXCOORD3;
      
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
          
          out_v.texcoord.xy = u_xlat0.xy;
          
          out_v.texcoord1 = _MainTex_TexelSize.xyxy * float4(-1.0, 0.0, 0.0, -1.0) + u_xlat0.xyxy;
          
          out_v.texcoord2 = _MainTex_TexelSize.xyxy * float4(1.0, 0.0, 0.0, 1.0) + u_xlat0.xyxy;
          
          out_v.texcoord3 = _MainTex_TexelSize.xyxy * float4(-2.0, 0.0, 0.0, -2.0) + u_xlat0.xyxy;
          
          return;
      
      }
      
      
      #define CODE_BLOCK_FRAGMENT
      
      float4 u_xlat0_d;
      
      bool2 u_xlatb0;
      
      float4 u_xlat1;
      
      float3 u_xlat2;
      
      float4 u_xlat3;
      
      float4 u_xlat4;
      
      float4 u_xlat5;
      
      float2 u_xlat6;
      
      float u_xlat12;
      
      float2 u_xlat14;
      
      bool2 u_xlatb14;
      
      float u_xlat18;
      
      int u_xlatb18;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = texture(_MainTex, in_f.texcoord.xy);
          
          u_xlat1 = texture(_MainTex, in_f.texcoord1.xy);
          
          u_xlat2.xyz = u_xlat0_d.xyz + (-u_xlat1.xyz);
          
          u_xlat18 = max(abs(u_xlat2.y), abs(u_xlat2.x));
          
          u_xlat2.x = max(abs(u_xlat2.z), u_xlat18);
          
          u_xlat3 = texture(_MainTex, in_f.texcoord1.zw);
          
          u_xlat4.xyz = u_xlat0_d.xyz + (-u_xlat3.xyz);
          
          u_xlat18 = max(abs(u_xlat4.y), abs(u_xlat4.x));
          
          u_xlat2.y = max(abs(u_xlat4.z), u_xlat18);
          
          u_xlatb14.xy = greaterThanEqual(u_xlat2.xyxy, float4(0.100000001, 0.100000001, 0.100000001, 0.100000001)).xy;
          
          u_xlat14.x = u_xlatb14.x ? float(1.0) : 0.0;
          
          u_xlat14.y = u_xlatb14.y ? float(1.0) : 0.0;
      
      ;
          
          u_xlat18 = dot(u_xlat14.xy, float2(1.0, 1.0));
          
          u_xlatb18 = u_xlat18==0.0;
          
          if(((int(u_xlatb18) * int(0xffffffffu)))!=0)
      {
              discard;
      }
          
          u_xlat4 = texture(_MainTex, in_f.texcoord2.xy);
          
          u_xlat4.xyz = u_xlat0_d.xyz + (-u_xlat4.xyz);
          
          u_xlat18 = max(abs(u_xlat4.y), abs(u_xlat4.x));
          
          u_xlat4.x = max(abs(u_xlat4.z), u_xlat18);
          
          u_xlat5 = texture(_MainTex, in_f.texcoord2.zw);
          
          u_xlat0_d.xyz = u_xlat0_d.xyz + (-u_xlat5.xyz);
          
          u_xlat0_d.x = max(abs(u_xlat0_d.y), abs(u_xlat0_d.x));
          
          u_xlat4.y = max(abs(u_xlat0_d.z), u_xlat0_d.x);
          
          u_xlat0_d.xy = max(u_xlat2.xy, u_xlat4.xy);
          
          u_xlat4 = texture(_MainTex, in_f.texcoord3.xy);
          
          u_xlat1.xyz = u_xlat1.xyz + (-u_xlat4.xyz);
          
          u_xlat12 = max(abs(u_xlat1.y), abs(u_xlat1.x));
          
          u_xlat1.x = max(abs(u_xlat1.z), u_xlat12);
          
          u_xlat4 = texture(_MainTex, in_f.texcoord3.zw);
          
          u_xlat3.xyz = u_xlat3.xyz + (-u_xlat4.xyz);
          
          u_xlat12 = max(abs(u_xlat3.y), abs(u_xlat3.x));
          
          u_xlat1.y = max(abs(u_xlat3.z), u_xlat12);
          
          u_xlat0_d.xy = max(u_xlat0_d.xy, u_xlat1.xy);
          
          u_xlat0_d.x = max(u_xlat0_d.y, u_xlat0_d.x);
          
          u_xlat6.xy = u_xlat2.xy + u_xlat2.xy;
          
          u_xlatb0.xy = greaterThanEqual(u_xlat6.xyxx, u_xlat0_d.xxxx).xy;
          
          u_xlat0_d.x = u_xlatb0.x ? float(1.0) : 0.0;
          
          u_xlat0_d.y = u_xlatb0.y ? float(1.0) : 0.0;
      
      ;
          
          u_xlat0_d.xy = u_xlat0_d.xy * u_xlat14.xy;
          
          out_f.color.xy = u_xlat0_d.xy;
          
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
      
      
      uniform float4 _MainTex_TexelSize;
      
      uniform sampler2D _MainTex;
      
      
      
      struct appdata_t
      {
          
          float3 vertex : POSITION0;
      
      };
      
      
      struct OUT_Data_Vert
      {
          
          float2 texcoord : TEXCOORD0;
          
          float4 texcoord1 : TEXCOORD1;
          
          float4 texcoord2 : TEXCOORD2;
          
          float4 texcoord3 : TEXCOORD3;
          
          float4 vertex : SV_POSITION;
      
      };
      
      
      struct v2f
      {
          
          float2 texcoord : TEXCOORD0;
          
          float4 texcoord1 : TEXCOORD1;
          
          float4 texcoord2 : TEXCOORD2;
          
          float4 texcoord3 : TEXCOORD3;
      
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
          
          out_v.texcoord.xy = u_xlat0.xy;
          
          out_v.texcoord1 = _MainTex_TexelSize.xyxy * float4(-1.0, 0.0, 0.0, -1.0) + u_xlat0.xyxy;
          
          out_v.texcoord2 = _MainTex_TexelSize.xyxy * float4(1.0, 0.0, 0.0, 1.0) + u_xlat0.xyxy;
          
          out_v.texcoord3 = _MainTex_TexelSize.xyxy * float4(-2.0, 0.0, 0.0, -2.0) + u_xlat0.xyxy;
          
          return;
      
      }
      
      
      #define CODE_BLOCK_FRAGMENT
      
      float4 u_xlat0_d;
      
      bool2 u_xlatb0;
      
      float4 u_xlat1;
      
      float3 u_xlat2;
      
      float4 u_xlat3;
      
      float4 u_xlat4;
      
      float4 u_xlat5;
      
      float2 u_xlat6;
      
      float u_xlat12;
      
      float2 u_xlat14;
      
      bool2 u_xlatb14;
      
      float u_xlat18;
      
      int u_xlatb18;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = texture(_MainTex, in_f.texcoord.xy);
          
          u_xlat1 = texture(_MainTex, in_f.texcoord1.xy);
          
          u_xlat2.xyz = u_xlat0_d.xyz + (-u_xlat1.xyz);
          
          u_xlat18 = max(abs(u_xlat2.y), abs(u_xlat2.x));
          
          u_xlat2.x = max(abs(u_xlat2.z), u_xlat18);
          
          u_xlat3 = texture(_MainTex, in_f.texcoord1.zw);
          
          u_xlat4.xyz = u_xlat0_d.xyz + (-u_xlat3.xyz);
          
          u_xlat18 = max(abs(u_xlat4.y), abs(u_xlat4.x));
          
          u_xlat2.y = max(abs(u_xlat4.z), u_xlat18);
          
          u_xlatb14.xy = greaterThanEqual(u_xlat2.xyxy, float4(0.100000001, 0.100000001, 0.100000001, 0.100000001)).xy;
          
          u_xlat14.x = u_xlatb14.x ? float(1.0) : 0.0;
          
          u_xlat14.y = u_xlatb14.y ? float(1.0) : 0.0;
      
      ;
          
          u_xlat18 = dot(u_xlat14.xy, float2(1.0, 1.0));
          
          u_xlatb18 = u_xlat18==0.0;
          
          if(((int(u_xlatb18) * int(0xffffffffu)))!=0)
      {
              discard;
      }
          
          u_xlat4 = texture(_MainTex, in_f.texcoord2.xy);
          
          u_xlat4.xyz = u_xlat0_d.xyz + (-u_xlat4.xyz);
          
          u_xlat18 = max(abs(u_xlat4.y), abs(u_xlat4.x));
          
          u_xlat4.x = max(abs(u_xlat4.z), u_xlat18);
          
          u_xlat5 = texture(_MainTex, in_f.texcoord2.zw);
          
          u_xlat0_d.xyz = u_xlat0_d.xyz + (-u_xlat5.xyz);
          
          u_xlat0_d.x = max(abs(u_xlat0_d.y), abs(u_xlat0_d.x));
          
          u_xlat4.y = max(abs(u_xlat0_d.z), u_xlat0_d.x);
          
          u_xlat0_d.xy = max(u_xlat2.xy, u_xlat4.xy);
          
          u_xlat4 = texture(_MainTex, in_f.texcoord3.xy);
          
          u_xlat1.xyz = u_xlat1.xyz + (-u_xlat4.xyz);
          
          u_xlat12 = max(abs(u_xlat1.y), abs(u_xlat1.x));
          
          u_xlat1.x = max(abs(u_xlat1.z), u_xlat12);
          
          u_xlat4 = texture(_MainTex, in_f.texcoord3.zw);
          
          u_xlat3.xyz = u_xlat3.xyz + (-u_xlat4.xyz);
          
          u_xlat12 = max(abs(u_xlat3.y), abs(u_xlat3.x));
          
          u_xlat1.y = max(abs(u_xlat3.z), u_xlat12);
          
          u_xlat0_d.xy = max(u_xlat0_d.xy, u_xlat1.xy);
          
          u_xlat0_d.x = max(u_xlat0_d.y, u_xlat0_d.x);
          
          u_xlat6.xy = u_xlat2.xy + u_xlat2.xy;
          
          u_xlatb0.xy = greaterThanEqual(u_xlat6.xyxx, u_xlat0_d.xxxx).xy;
          
          u_xlat0_d.x = u_xlatb0.x ? float(1.0) : 0.0;
          
          u_xlat0_d.y = u_xlatb0.y ? float(1.0) : 0.0;
      
      ;
          
          u_xlat0_d.xy = u_xlat0_d.xy * u_xlat14.xy;
          
          out_f.color.xy = u_xlat0_d.xy;
          
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
      
      
      uniform float4 _MainTex_TexelSize;
      
      uniform sampler2D _MainTex;
      
      uniform sampler2D _SearchTex;
      
      uniform sampler2D _AreaTex;
      
      
      
      struct appdata_t
      {
          
          float3 vertex : POSITION0;
      
      };
      
      
      struct OUT_Data_Vert
      {
          
          float2 texcoord : TEXCOORD0;
          
          float2 texcoord1 : TEXCOORD1;
          
          float4 texcoord2 : TEXCOORD2;
          
          float4 texcoord3 : TEXCOORD3;
          
          float4 texcoord4 : TEXCOORD4;
          
          float4 vertex : SV_POSITION;
      
      };
      
      
      struct v2f
      {
          
          float2 texcoord : TEXCOORD0;
          
          float2 texcoord1 : TEXCOORD1;
          
          float4 texcoord2 : TEXCOORD2;
          
          float4 texcoord3 : TEXCOORD3;
          
          float4 texcoord4 : TEXCOORD4;
      
      };
      
      
      struct OUT_Data_Frag
      {
          
          float4 color : SV_Target0;
      
      };
      
      
      float4 u_xlat0;
      
      float4 u_xlat1;
      
      OUT_Data_Vert vert(appdata_t in_v)
      {
          
          out_v.vertex.xy = in_v.vertex.xy;
          
          out_v.vertex.zw = float2(0.0, 1.0);
          
          out_v.texcoord.xy = in_v.vertex.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
          
          u_xlat0 = in_v.vertex.xyxy + float4(1.0, 1.0, 1.0, 1.0);
          
          u_xlat0 = u_xlat0 * float4(0.5, 0.5, 0.5, 0.5);
          
          out_v.texcoord1.xy = u_xlat0.zw * _MainTex_TexelSize.zw;
          
          u_xlat1 = _MainTex_TexelSize.xxyy * float4(-0.25, 1.25, -0.125, -0.125) + u_xlat0.zzww;
          
          u_xlat0 = _MainTex_TexelSize.xyxy * float4(-0.125, -0.25, -0.125, 1.25) + u_xlat0;
          
          out_v.texcoord2 = u_xlat1.xzyw;
          
          out_v.texcoord3 = u_xlat0;
          
          u_xlat1.zw = u_xlat0.yw;
          
          out_v.texcoord4 = _MainTex_TexelSize.xxyy * float4(-8.0, 8.0, -8.0, 8.0) + u_xlat1;
          
          return;
      
      }
      
      
      #define CODE_BLOCK_FRAGMENT
      
      float4 u_xlat0_d;
      
      bool2 u_xlatb0;
      
      float4 u_xlat1_d;
      
      int u_xlatb1;
      
      float4 u_xlat2;
      
      int u_xlatb2;
      
      float4 u_xlat3;
      
      float4 u_xlat4;
      
      float2 u_xlat5;
      
      int u_xlatb10;
      
      float u_xlat15;
      
      int u_xlatb15;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = texture(_MainTex, in_f.texcoord.xy);
          
          u_xlatb0.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), u_xlat0_d.yxyy).xy;
          
          if(u_xlatb0.x)
      {
              
              u_xlat1_d.xy = in_f.texcoord2.xy;
              
              u_xlat1_d.z = 1.0;
              
              u_xlat2.x = 0.0;
              
              while(true)
      {
                  
                  u_xlatb0.x = in_f.texcoord4.x<u_xlat1_d.x;
                  
                  u_xlatb10 = 0.828100026<u_xlat1_d.z;
                  
                  u_xlatb0.x = u_xlatb10 && u_xlatb0.x;
                  
                  u_xlatb10 = u_xlat2.x==0.0;
                  
                  u_xlatb0.x = u_xlatb10 && u_xlatb0.x;
                  
                  if(!u_xlatb0.x)
      {
                      break;
      }
                  
                  u_xlat2 = textureLod(_MainTex, u_xlat1_d.xy, 0.0);
                  
                  u_xlat1_d.xy = _MainTex_TexelSize.xy * float2(-2.0, -0.0) + u_xlat1_d.xy;
                  
                  u_xlat1_d.z = u_xlat2.y;
      
      }
              
              u_xlat2.yz = u_xlat1_d.xz;
              
              u_xlat0_d.xz = u_xlat2.xz * float2(0.5, -2.0) + float2(0.0078125, 2.03125);
              
              u_xlat1_d = textureLod(_SearchTex, u_xlat0_d.xz, 0.0);
              
              u_xlat0_d.x = u_xlat1_d.w * -2.00787401 + 3.25;
              
              u_xlat1_d.x = _MainTex_TexelSize.x * u_xlat0_d.x + u_xlat2.y;
              
              u_xlat1_d.y = in_f.texcoord3.y;
              
              u_xlat2 = textureLod(_MainTex, u_xlat1_d.xy, 0.0);
              
              u_xlat3.xy = in_f.texcoord2.zw;
              
              u_xlat3.z = 1.0;
              
              u_xlat4.x = 0.0;
              
              while(true)
      {
                  
                  u_xlatb0.x = u_xlat3.x<in_f.texcoord4.y;
                  
                  u_xlatb10 = 0.828100026<u_xlat3.z;
                  
                  u_xlatb0.x = u_xlatb10 && u_xlatb0.x;
                  
                  u_xlatb10 = u_xlat4.x==0.0;
                  
                  u_xlatb0.x = u_xlatb10 && u_xlatb0.x;
                  
                  if(!u_xlatb0.x)
      {
                      break;
      }
                  
                  u_xlat4 = textureLod(_MainTex, u_xlat3.xy, 0.0);
                  
                  u_xlat3.xy = _MainTex_TexelSize.xy * float2(2.0, 0.0) + u_xlat3.xy;
                  
                  u_xlat3.z = u_xlat4.y;
      
      }
              
              u_xlat4.yz = u_xlat3.xz;
              
              u_xlat0_d.xz = u_xlat4.xz * float2(0.5, -2.0) + float2(0.5234375, 2.03125);
              
              u_xlat3 = textureLod(_SearchTex, u_xlat0_d.xz, 0.0);
              
              u_xlat0_d.x = u_xlat3.w * -2.00787401 + 3.25;
              
              u_xlat1_d.z = (-_MainTex_TexelSize.x) * u_xlat0_d.x + u_xlat4.y;
              
              u_xlat0_d.xz = _MainTex_TexelSize.zz * u_xlat1_d.xz + (-in_f.texcoord1.xx);
              
              u_xlat0_d.xz = roundEven(u_xlat0_d.xz);
              
              u_xlat0_d.xz = sqrt(abs(u_xlat0_d.xz));
              
              u_xlat1_d.xy = _MainTex_TexelSize.xy * float2(1.0, 0.0) + u_xlat1_d.zy;
              
              u_xlat1_d = textureLod(_MainTex, u_xlat1_d.xy, 0.0).yxzw;
              
              u_xlat1_d.x = u_xlat2.x;
              
              u_xlat1_d.xy = u_xlat1_d.xy * float2(4.0, 4.0);
              
              u_xlat1_d.xy = roundEven(u_xlat1_d.xy);
              
              u_xlat0_d.xz = u_xlat1_d.xy * float2(16.0, 16.0) + u_xlat0_d.xz;
              
              u_xlat0_d.xz = u_xlat0_d.xz * float2(0.00625000009, 0.0017857143) + float2(0.00312500005, 0.000892857148);
              
              u_xlat1_d = textureLod(_AreaTex, u_xlat0_d.xz, 0.0);
              
              out_f.color.xy = u_xlat1_d.xy;
      
      }
          else
          
              {
              
              out_f.color.xy = float2(0.0, 0.0);
      
      }
          
          if(u_xlatb0.y)
      {
              
              u_xlat0_d.xy = in_f.texcoord3.xy;
              
              u_xlat0_d.z = 1.0;
              
              u_xlat1_d.x = 0.0;
              
              while(true)
      {
                  
                  u_xlatb15 = in_f.texcoord4.z<u_xlat0_d.y;
                  
                  u_xlatb2 = 0.828100026<u_xlat0_d.z;
                  
                  u_xlatb15 = u_xlatb15 && u_xlatb2;
                  
                  u_xlatb2 = u_xlat1_d.x==0.0;
                  
                  u_xlatb15 = u_xlatb15 && u_xlatb2;
                  
                  if(!u_xlatb15)
      {
                      break;
      }
                  
                  u_xlat1_d = textureLod(_MainTex, u_xlat0_d.xy, 0.0).yxzw;
                  
                  u_xlat0_d.xy = _MainTex_TexelSize.xy * float2(-0.0, -2.0) + u_xlat0_d.xy;
                  
                  u_xlat0_d.z = u_xlat1_d.y;
      
      }
              
              u_xlat1_d.yz = u_xlat0_d.yz;
              
              u_xlat0_d.xy = u_xlat1_d.xz * float2(0.5, -2.0) + float2(0.0078125, 2.03125);
              
              u_xlat0_d = textureLod(_SearchTex, u_xlat0_d.xy, 0.0);
              
              u_xlat0_d.x = u_xlat0_d.w * -2.00787401 + 3.25;
              
              u_xlat0_d.x = _MainTex_TexelSize.y * u_xlat0_d.x + u_xlat1_d.y;
              
              u_xlat0_d.y = in_f.texcoord2.x;
              
              u_xlat1_d = textureLod(_MainTex, u_xlat0_d.yx, 0.0);
              
              u_xlat2.xy = in_f.texcoord3.zw;
              
              u_xlat2.z = 1.0;
              
              u_xlat3.x = 0.0;
              
              while(true)
      {
                  
                  u_xlatb15 = u_xlat2.y<in_f.texcoord4.w;
                  
                  u_xlatb1 = 0.828100026<u_xlat2.z;
                  
                  u_xlatb15 = u_xlatb15 && u_xlatb1;
                  
                  u_xlatb1 = u_xlat3.x==0.0;
                  
                  u_xlatb15 = u_xlatb15 && u_xlatb1;
                  
                  if(!u_xlatb15)
      {
                      break;
      }
                  
                  u_xlat3 = textureLod(_MainTex, u_xlat2.xy, 0.0).yxzw;
                  
                  u_xlat2.xy = _MainTex_TexelSize.xy * float2(0.0, 2.0) + u_xlat2.xy;
                  
                  u_xlat2.z = u_xlat3.y;
      
      }
              
              u_xlat3.yz = u_xlat2.yz;
              
              u_xlat1_d.xz = u_xlat3.xz * float2(0.5, -2.0) + float2(0.5234375, 2.03125);
              
              u_xlat2 = textureLod(_SearchTex, u_xlat1_d.xz, 0.0);
              
              u_xlat15 = u_xlat2.w * -2.00787401 + 3.25;
              
              u_xlat0_d.z = (-_MainTex_TexelSize.y) * u_xlat15 + u_xlat3.y;
              
              u_xlat0_d.xw = _MainTex_TexelSize.ww * u_xlat0_d.xz + (-in_f.texcoord1.yy);
              
              u_xlat0_d.xw = roundEven(u_xlat0_d.xw);
              
              u_xlat0_d.xw = sqrt(abs(u_xlat0_d.xw));
              
              u_xlat5.xy = _MainTex_TexelSize.xy * float2(0.0, 1.0) + u_xlat0_d.yz;
              
              u_xlat2 = textureLod(_MainTex, u_xlat5.xy, 0.0);
              
              u_xlat2.x = u_xlat1_d.y;
              
              u_xlat5.xy = u_xlat2.xy * float2(4.0, 4.0);
              
              u_xlat5.xy = roundEven(u_xlat5.xy);
              
              u_xlat0_d.xy = u_xlat5.xy * float2(16.0, 16.0) + u_xlat0_d.xw;
              
              u_xlat0_d.xy = u_xlat0_d.xy * float2(0.00625000009, 0.0017857143) + float2(0.00312500005, 0.000892857148);
              
              u_xlat0_d = textureLod(_AreaTex, u_xlat0_d.xy, 0.0);
              
              out_f.color.zw = u_xlat0_d.xy;
      
      }
          else
          
              {
              
              out_f.color.zw = float2(0.0, 0.0);
      
      }
          
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
      
      
      uniform float4 _MainTex_TexelSize;
      
      uniform sampler2D _MainTex;
      
      uniform sampler2D _SearchTex;
      
      uniform sampler2D _AreaTex;
      
      
      
      struct appdata_t
      {
          
          float3 vertex : POSITION0;
      
      };
      
      
      struct OUT_Data_Vert
      {
          
          float2 texcoord : TEXCOORD0;
          
          float2 texcoord1 : TEXCOORD1;
          
          float4 texcoord2 : TEXCOORD2;
          
          float4 texcoord3 : TEXCOORD3;
          
          float4 texcoord4 : TEXCOORD4;
          
          float4 vertex : SV_POSITION;
      
      };
      
      
      struct v2f
      {
          
          float2 texcoord : TEXCOORD0;
          
          float2 texcoord1 : TEXCOORD1;
          
          float4 texcoord2 : TEXCOORD2;
          
          float4 texcoord3 : TEXCOORD3;
          
          float4 texcoord4 : TEXCOORD4;
      
      };
      
      
      struct OUT_Data_Frag
      {
          
          float4 color : SV_Target0;
      
      };
      
      
      float4 u_xlat0;
      
      float4 u_xlat1;
      
      OUT_Data_Vert vert(appdata_t in_v)
      {
          
          out_v.vertex.xy = in_v.vertex.xy;
          
          out_v.vertex.zw = float2(0.0, 1.0);
          
          out_v.texcoord.xy = in_v.vertex.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
          
          u_xlat0 = in_v.vertex.xyxy + float4(1.0, 1.0, 1.0, 1.0);
          
          u_xlat0 = u_xlat0 * float4(0.5, 0.5, 0.5, 0.5);
          
          out_v.texcoord1.xy = u_xlat0.zw * _MainTex_TexelSize.zw;
          
          u_xlat1 = _MainTex_TexelSize.xxyy * float4(-0.25, 1.25, -0.125, -0.125) + u_xlat0.zzww;
          
          u_xlat0 = _MainTex_TexelSize.xyxy * float4(-0.125, -0.25, -0.125, 1.25) + u_xlat0;
          
          out_v.texcoord2 = u_xlat1.xzyw;
          
          out_v.texcoord3 = u_xlat0;
          
          u_xlat1.zw = u_xlat0.yw;
          
          out_v.texcoord4 = _MainTex_TexelSize.xxyy * float4(-16.0, 16.0, -16.0, 16.0) + u_xlat1;
          
          return;
      
      }
      
      
      #define CODE_BLOCK_FRAGMENT
      
      float4 u_xlat0_d;
      
      bool2 u_xlatb0;
      
      float4 u_xlat1_d;
      
      int u_xlatb1;
      
      float4 u_xlat2;
      
      int u_xlatb2;
      
      float4 u_xlat3;
      
      float4 u_xlat4;
      
      float2 u_xlat5;
      
      int u_xlatb10;
      
      float u_xlat15;
      
      int u_xlatb15;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = texture(_MainTex, in_f.texcoord.xy);
          
          u_xlatb0.xy = lessThan(float4(0.0, 0.0, 0.0, 0.0), u_xlat0_d.yxyy).xy;
          
          if(u_xlatb0.x)
      {
              
              u_xlat1_d.xy = in_f.texcoord2.xy;
              
              u_xlat1_d.z = 1.0;
              
              u_xlat2.x = 0.0;
              
              while(true)
      {
                  
                  u_xlatb0.x = in_f.texcoord4.x<u_xlat1_d.x;
                  
                  u_xlatb10 = 0.828100026<u_xlat1_d.z;
                  
                  u_xlatb0.x = u_xlatb10 && u_xlatb0.x;
                  
                  u_xlatb10 = u_xlat2.x==0.0;
                  
                  u_xlatb0.x = u_xlatb10 && u_xlatb0.x;
                  
                  if(!u_xlatb0.x)
      {
                      break;
      }
                  
                  u_xlat2 = textureLod(_MainTex, u_xlat1_d.xy, 0.0);
                  
                  u_xlat1_d.xy = _MainTex_TexelSize.xy * float2(-2.0, -0.0) + u_xlat1_d.xy;
                  
                  u_xlat1_d.z = u_xlat2.y;
      
      }
              
              u_xlat2.yz = u_xlat1_d.xz;
              
              u_xlat0_d.xz = u_xlat2.xz * float2(0.5, -2.0) + float2(0.0078125, 2.03125);
              
              u_xlat1_d = textureLod(_SearchTex, u_xlat0_d.xz, 0.0);
              
              u_xlat0_d.x = u_xlat1_d.w * -2.00787401 + 3.25;
              
              u_xlat1_d.x = _MainTex_TexelSize.x * u_xlat0_d.x + u_xlat2.y;
              
              u_xlat1_d.y = in_f.texcoord3.y;
              
              u_xlat2 = textureLod(_MainTex, u_xlat1_d.xy, 0.0);
              
              u_xlat3.xy = in_f.texcoord2.zw;
              
              u_xlat3.z = 1.0;
              
              u_xlat4.x = 0.0;
              
              while(true)
      {
                  
                  u_xlatb0.x = u_xlat3.x<in_f.texcoord4.y;
                  
                  u_xlatb10 = 0.828100026<u_xlat3.z;
                  
                  u_xlatb0.x = u_xlatb10 && u_xlatb0.x;
                  
                  u_xlatb10 = u_xlat4.x==0.0;
                  
                  u_xlatb0.x = u_xlatb10 && u_xlatb0.x;
                  
                  if(!u_xlatb0.x)
      {
                      break;
      }
                  
                  u_xlat4 = textureLod(_MainTex, u_xlat3.xy, 0.0);
                  
                  u_xlat3.xy = _MainTex_TexelSize.xy * float2(2.0, 0.0) + u_xlat3.xy;
                  
                  u_xlat3.z = u_xlat4.y;
      
      }
              
              u_xlat4.yz = u_xlat3.xz;
              
              u_xlat0_d.xz = u_xlat4.xz * float2(0.5, -2.0) + float2(0.5234375, 2.03125);
              
              u_xlat3 = textureLod(_SearchTex, u_xlat0_d.xz, 0.0);
              
              u_xlat0_d.x = u_xlat3.w * -2.00787401 + 3.25;
              
              u_xlat1_d.z = (-_MainTex_TexelSize.x) * u_xlat0_d.x + u_xlat4.y;
              
              u_xlat0_d.xz = _MainTex_TexelSize.zz * u_xlat1_d.xz + (-in_f.texcoord1.xx);
              
              u_xlat0_d.xz = roundEven(u_xlat0_d.xz);
              
              u_xlat0_d.xz = sqrt(abs(u_xlat0_d.xz));
              
              u_xlat1_d.xy = _MainTex_TexelSize.xy * float2(1.0, 0.0) + u_xlat1_d.zy;
              
              u_xlat1_d = textureLod(_MainTex, u_xlat1_d.xy, 0.0).yxzw;
              
              u_xlat1_d.x = u_xlat2.x;
              
              u_xlat1_d.xy = u_xlat1_d.xy * float2(4.0, 4.0);
              
              u_xlat1_d.xy = roundEven(u_xlat1_d.xy);
              
              u_xlat0_d.xz = u_xlat1_d.xy * float2(16.0, 16.0) + u_xlat0_d.xz;
              
              u_xlat0_d.xz = u_xlat0_d.xz * float2(0.00625000009, 0.0017857143) + float2(0.00312500005, 0.000892857148);
              
              u_xlat1_d = textureLod(_AreaTex, u_xlat0_d.xz, 0.0);
              
              out_f.color.xy = u_xlat1_d.xy;
      
      }
          else
          
              {
              
              out_f.color.xy = float2(0.0, 0.0);
      
      }
          
          if(u_xlatb0.y)
      {
              
              u_xlat0_d.xy = in_f.texcoord3.xy;
              
              u_xlat0_d.z = 1.0;
              
              u_xlat1_d.x = 0.0;
              
              while(true)
      {
                  
                  u_xlatb15 = in_f.texcoord4.z<u_xlat0_d.y;
                  
                  u_xlatb2 = 0.828100026<u_xlat0_d.z;
                  
                  u_xlatb15 = u_xlatb15 && u_xlatb2;
                  
                  u_xlatb2 = u_xlat1_d.x==0.0;
                  
                  u_xlatb15 = u_xlatb15 && u_xlatb2;
                  
                  if(!u_xlatb15)
      {
                      break;
      }
                  
                  u_xlat1_d = textureLod(_MainTex, u_xlat0_d.xy, 0.0).yxzw;
                  
                  u_xlat0_d.xy = _MainTex_TexelSize.xy * float2(-0.0, -2.0) + u_xlat0_d.xy;
                  
                  u_xlat0_d.z = u_xlat1_d.y;
      
      }
              
              u_xlat1_d.yz = u_xlat0_d.yz;
              
              u_xlat0_d.xy = u_xlat1_d.xz * float2(0.5, -2.0) + float2(0.0078125, 2.03125);
              
              u_xlat0_d = textureLod(_SearchTex, u_xlat0_d.xy, 0.0);
              
              u_xlat0_d.x = u_xlat0_d.w * -2.00787401 + 3.25;
              
              u_xlat0_d.x = _MainTex_TexelSize.y * u_xlat0_d.x + u_xlat1_d.y;
              
              u_xlat0_d.y = in_f.texcoord2.x;
              
              u_xlat1_d = textureLod(_MainTex, u_xlat0_d.yx, 0.0);
              
              u_xlat2.xy = in_f.texcoord3.zw;
              
              u_xlat2.z = 1.0;
              
              u_xlat3.x = 0.0;
              
              while(true)
      {
                  
                  u_xlatb15 = u_xlat2.y<in_f.texcoord4.w;
                  
                  u_xlatb1 = 0.828100026<u_xlat2.z;
                  
                  u_xlatb15 = u_xlatb15 && u_xlatb1;
                  
                  u_xlatb1 = u_xlat3.x==0.0;
                  
                  u_xlatb15 = u_xlatb15 && u_xlatb1;
                  
                  if(!u_xlatb15)
      {
                      break;
      }
                  
                  u_xlat3 = textureLod(_MainTex, u_xlat2.xy, 0.0).yxzw;
                  
                  u_xlat2.xy = _MainTex_TexelSize.xy * float2(0.0, 2.0) + u_xlat2.xy;
                  
                  u_xlat2.z = u_xlat3.y;
      
      }
              
              u_xlat3.yz = u_xlat2.yz;
              
              u_xlat1_d.xz = u_xlat3.xz * float2(0.5, -2.0) + float2(0.5234375, 2.03125);
              
              u_xlat2 = textureLod(_SearchTex, u_xlat1_d.xz, 0.0);
              
              u_xlat15 = u_xlat2.w * -2.00787401 + 3.25;
              
              u_xlat0_d.z = (-_MainTex_TexelSize.y) * u_xlat15 + u_xlat3.y;
              
              u_xlat0_d.xw = _MainTex_TexelSize.ww * u_xlat0_d.xz + (-in_f.texcoord1.yy);
              
              u_xlat0_d.xw = roundEven(u_xlat0_d.xw);
              
              u_xlat0_d.xw = sqrt(abs(u_xlat0_d.xw));
              
              u_xlat5.xy = _MainTex_TexelSize.xy * float2(0.0, 1.0) + u_xlat0_d.yz;
              
              u_xlat2 = textureLod(_MainTex, u_xlat5.xy, 0.0);
              
              u_xlat2.x = u_xlat1_d.y;
              
              u_xlat5.xy = u_xlat2.xy * float2(4.0, 4.0);
              
              u_xlat5.xy = roundEven(u_xlat5.xy);
              
              u_xlat0_d.xy = u_xlat5.xy * float2(16.0, 16.0) + u_xlat0_d.xw;
              
              u_xlat0_d.xy = u_xlat0_d.xy * float2(0.00625000009, 0.0017857143) + float2(0.00312500005, 0.000892857148);
              
              u_xlat0_d = textureLod(_AreaTex, u_xlat0_d.xy, 0.0);
              
              out_f.color.zw = u_xlat0_d.xy;
      
      }
          else
          
              {
              
              out_f.color.zw = float2(0.0, 0.0);
      
      }
          
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
      
      
      uniform float4 _MainTex_TexelSize;
      
      uniform sampler2D _MainTex;
      
      uniform sampler2D _AreaTex;
      
      uniform sampler2D _SearchTex;
      
      
      
      struct appdata_t
      {
          
          float3 vertex : POSITION0;
      
      };
      
      
      struct OUT_Data_Vert
      {
          
          float2 texcoord : TEXCOORD0;
          
          float2 texcoord1 : TEXCOORD1;
          
          float4 texcoord2 : TEXCOORD2;
          
          float4 texcoord3 : TEXCOORD3;
          
          float4 texcoord4 : TEXCOORD4;
          
          float4 vertex : SV_POSITION;
      
      };
      
      
      struct v2f
      {
          
          float2 texcoord : TEXCOORD0;
          
          float2 texcoord1 : TEXCOORD1;
          
          float4 texcoord2 : TEXCOORD2;
          
          float4 texcoord3 : TEXCOORD3;
          
          float4 texcoord4 : TEXCOORD4;
      
      };
      
      
      struct OUT_Data_Frag
      {
          
          float4 color : SV_Target0;
      
      };
      
      
      float4 u_xlat0;
      
      float4 u_xlat1;
      
      OUT_Data_Vert vert(appdata_t in_v)
      {
          
          out_v.vertex.xy = in_v.vertex.xy;
          
          out_v.vertex.zw = float2(0.0, 1.0);
          
          out_v.texcoord.xy = in_v.vertex.xy * float2(0.5, 0.5) + float2(0.5, 0.5);
          
          u_xlat0 = in_v.vertex.xyxy + float4(1.0, 1.0, 1.0, 1.0);
          
          u_xlat0 = u_xlat0 * float4(0.5, 0.5, 0.5, 0.5);
          
          out_v.texcoord1.xy = u_xlat0.zw * _MainTex_TexelSize.zw;
          
          u_xlat1 = _MainTex_TexelSize.xxyy * float4(-0.25, 1.25, -0.125, -0.125) + u_xlat0.zzww;
          
          u_xlat0 = _MainTex_TexelSize.xyxy * float4(-0.125, -0.25, -0.125, 1.25) + u_xlat0;
          
          out_v.texcoord2 = u_xlat1.xzyw;
          
          out_v.texcoord3 = u_xlat0;
          
          u_xlat1.zw = u_xlat0.yw;
          
          out_v.texcoord4 = _MainTex_TexelSize.xxyy * float4(-32.0, 32.0, -32.0, 32.0) + u_xlat1;
          
          return;
      
      }
      
      
      #define CODE_BLOCK_FRAGMENT
      
      float4 u_xlat0_d;
      
      int u_xlatb0;
      
      float4 u_xlat1_d;
      
      int u_xlatb1;
      
      float4 u_xlat2;
      
      bool4 u_xlatb2;
      
      float4 u_xlat3;
      
      int u_xlatb3;
      
      float4 u_xlat4;
      
      bool4 u_xlatb4;
      
      float4 u_xlat5;
      
      float4 u_xlat6;
      
      float3 u_xlat7;
      
      int u_xlatb7;
      
      float3 u_xlat8;
      
      bool3 u_xlatb8;
      
      float3 u_xlat10;
      
      int u_xlatb10;
      
      float2 u_xlat14;
      
      int u_xlatb14;
      
      float2 u_xlat15;
      
      bool2 u_xlatb15;
      
      float2 u_xlat16;
      
      float u_xlat21;
      
      int u_xlatb21;
      
      int u_xlatb22;
      
      float u_xlat23;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = texture(_MainTex, in_f.texcoord.xy);
          
          u_xlatb7 = 0.0<u_xlat0_d.y;
          
          if(u_xlatb7)
      {
              
              u_xlatb7 = 0.0<u_xlat0_d.x;
              
              if(u_xlatb7)
      {
                  
                  u_xlat1_d.xy = _MainTex_TexelSize.xy * float2(-1.0, 1.0);
                  
                  u_xlat1_d.z = 1.0;
                  
                  u_xlat2.xy = in_f.texcoord.xy;
                  
                  u_xlat3.x = 0.0;
                  
                  u_xlat2.z = -1.0;
                  
                  u_xlat4.x = 1.0;
                  
                  while(true)
      {
                      
                      u_xlatb7 = u_xlat2.z<7.0;
                      
                      u_xlatb14 = 0.899999976<u_xlat4.x;
                      
                      u_xlatb7 = u_xlatb14 && u_xlatb7;
                      
                      if(!u_xlatb7)
      {
                          break;
      }
                      
                      u_xlat2.xyz = u_xlat1_d.xyz + u_xlat2.xyz;
                      
                      u_xlat3 = textureLod(_MainTex, u_xlat2.xy, 0.0).yxzw;
                      
                      u_xlat4.x = dot(u_xlat3.yx, float2(0.5, 0.5));
      
      }
                  
                  u_xlatb7 = 0.899999976<u_xlat3.x;
                  
                  u_xlat7.x = u_xlatb7 ? 1.0 : float(0.0);
                  
                  u_xlat1_d.x = u_xlat7.x + u_xlat2.z;
      
      }
              else
              
                  {
                  
                  u_xlat1_d.x = 0.0;
                  
                  u_xlat4.x = 0.0;
      
      }
              
              u_xlat7.xy = _MainTex_TexelSize.xy * float2(1.0, -1.0);
              
              u_xlat7.z = 1.0;
              
              u_xlat2.yz = in_f.texcoord.xy;
              
              u_xlat2.x = float(-1.0);
              
              u_xlat23 = float(1.0);
              
              while(true)
      {
                  
                  u_xlatb3 = u_xlat2.x<7.0;
                  
                  u_xlatb10 = 0.899999976<u_xlat23;
                  
                  u_xlatb3 = u_xlatb10 && u_xlatb3;
                  
                  if(!u_xlatb3)
      {
                      break;
      }
                  
                  u_xlat2.xyz = u_xlat7.zxy + u_xlat2.xyz;
                  
                  u_xlat3 = textureLod(_MainTex, u_xlat2.yz, 0.0);
                  
                  u_xlat23 = dot(u_xlat3.xy, float2(0.5, 0.5));
      
      }
              
              u_xlat4.y = u_xlat23;
              
              u_xlat7.x = u_xlat1_d.x + u_xlat2.x;
              
              u_xlatb7 = 2.0<u_xlat7.x;
              
              if(u_xlatb7)
      {
                  
                  u_xlat1_d.y = (-u_xlat1_d.x) + 0.25;
                  
                  u_xlat1_d.zw = u_xlat2.xx * float2(1.0, -1.0) + float2(0.0, -0.25);
                  
                  u_xlat2 = u_xlat1_d.yxzw * _MainTex_TexelSize.xyxy + in_f.texcoord.xyxy;
                  
                  u_xlat2 = _MainTex_TexelSize.xyxy * float4(-1.0, 0.0, 1.0, 0.0) + u_xlat2;
                  
                  u_xlat3 = textureLod(_MainTex, u_xlat2.xy, 0.0);
                  
                  u_xlat2 = textureLod(_MainTex, u_xlat2.zw, 0.0);
                  
                  u_xlat3.z = u_xlat2.x;
                  
                  u_xlat7.xy = u_xlat3.xz * float2(5.0, 5.0) + float2(-3.75, -3.75);
                  
                  u_xlat7.xy = abs(u_xlat7.xy) * u_xlat3.xz;
                  
                  u_xlat7.xy = roundEven(u_xlat7.xy);
                  
                  u_xlat8.x = roundEven(u_xlat3.y);
                  
                  u_xlat8.z = roundEven(u_xlat2.y);
                  
                  u_xlat7.xy = u_xlat8.xz * float2(2.0, 2.0) + u_xlat7.xy;
                  
                  u_xlatb8.xz = greaterThanEqual(u_xlat4.xxyy, float4(0.899999976, 0.0, 0.899999976, 0.899999976)).xz;
                  
                  
                      {
                      
                      float3 hlslcc_movcTemp = u_xlat7;
                      
                      hlslcc_movcTemp.x = (u_xlatb8.x) ? float(0.0) : u_xlat7.x;
                      
                      hlslcc_movcTemp.y = (u_xlatb8.z) ? float(0.0) : u_xlat7.y;
                      
                      u_xlat7 = hlslcc_movcTemp;
      
      }
                  
                  u_xlat7.xy = u_xlat7.xy * float2(20.0, 20.0) + u_xlat1_d.xz;
                  
                  u_xlat7.xy = u_xlat7.xy * float2(0.00625000009, 0.0017857143) + float2(0.503125012, 0.000892857148);
                  
                  u_xlat1_d = textureLod(_AreaTex, u_xlat7.xy, 0.0);
      
      }
              else
              
                  {
                  
                  u_xlat1_d.x = float(0.0);
                  
                  u_xlat1_d.y = float(0.0);
      
      }
              
              u_xlat7.x = _MainTex_TexelSize.x * 0.25 + in_f.texcoord.x;
              
              u_xlat2.xy = (-_MainTex_TexelSize.xy);
              
              u_xlat2.z = 1.0;
              
              u_xlat10.x = u_xlat7.x;
              
              u_xlat10.y = in_f.texcoord.y;
              
              u_xlat3.x = float(1.0);
              
              u_xlat10.z = float(-1.0);
              
              while(true)
      {
                  
                  u_xlatb14 = u_xlat10.z<7.0;
                  
                  u_xlatb21 = 0.899999976<u_xlat3.x;
                  
                  u_xlatb14 = u_xlatb21 && u_xlatb14;
                  
                  if(!u_xlatb14)
      {
                      break;
      }
                  
                  u_xlat10.xyz = u_xlat2.xyz + u_xlat10.xyz;
                  
                  u_xlat4 = textureLod(_MainTex, u_xlat10.xy, 0.0);
                  
                  u_xlat14.x = u_xlat4.x * 5.0 + -3.75;
                  
                  u_xlat14.x = abs(u_xlat14.x) * u_xlat4.x;
                  
                  u_xlat5.x = roundEven(u_xlat14.x);
                  
                  u_xlat5.y = roundEven(u_xlat4.y);
                  
                  u_xlat3.x = dot(u_xlat5.xy, float2(0.5, 0.5));
      
      }
              
              u_xlat2.x = u_xlat10.z;
              
              u_xlat14.xy = _MainTex_TexelSize.xy * float2(1.0, 0.0) + in_f.texcoord.xy;
              
              u_xlat4 = textureLod(_MainTex, u_xlat14.xy, 0.0);
              
              u_xlatb14 = 0.0<u_xlat4.x;
              
              if(u_xlatb14)
      {
                  
                  u_xlat4.xy = _MainTex_TexelSize.xy;
                  
                  u_xlat4.z = 1.0;
                  
                  u_xlat5.x = u_xlat7.x;
                  
                  u_xlat5.y = in_f.texcoord.y;
                  
                  u_xlat14.x = 0.0;
                  
                  u_xlat5.z = -1.0;
                  
                  u_xlat3.y = 1.0;
                  
                  while(true)
      {
                      
                      u_xlatb15.x = u_xlat5.z<7.0;
                      
                      u_xlatb22 = 0.899999976<u_xlat3.y;
                      
                      u_xlatb15.x = u_xlatb22 && u_xlatb15.x;
                      
                      if(!u_xlatb15.x)
      {
                          break;
      }
                      
                      u_xlat5.xyz = u_xlat4.xyz + u_xlat5.xyz;
                      
                      u_xlat6 = textureLod(_MainTex, u_xlat5.xy, 0.0);
                      
                      u_xlat15.x = u_xlat6.x * 5.0 + -3.75;
                      
                      u_xlat15.x = abs(u_xlat15.x) * u_xlat6.x;
                      
                      u_xlat14.y = roundEven(u_xlat15.x);
                      
                      u_xlat14.x = roundEven(u_xlat6.y);
                      
                      u_xlat3.y = dot(u_xlat14.yx, float2(0.5, 0.5));
      
      }
                  
                  u_xlatb7 = 0.899999976<u_xlat14.x;
                  
                  u_xlat7.x = u_xlatb7 ? 1.0 : float(0.0);
                  
                  u_xlat2.z = u_xlat7.x + u_xlat5.z;
      
      }
              else
              
                  {
                  
                  u_xlat2.z = 0.0;
                  
                  u_xlat3.y = 0.0;
      
      }
              
              u_xlat7.x = u_xlat2.z + u_xlat2.x;
              
              u_xlatb7 = 2.0<u_xlat7.x;
              
              if(u_xlatb7)
      {
                  
                  u_xlat2.y = (-u_xlat2.x);
                  
                  u_xlat4 = u_xlat2.yyzz * _MainTex_TexelSize.xyxy + in_f.texcoord.xyxy;
                  
                  u_xlat5 = _MainTex_TexelSize.xyxy * float4(-1.0, 0.0, 0.0, -1.0) + u_xlat4.xyxy;
                  
                  u_xlat6 = textureLod(_MainTex, u_xlat5.xy, 0.0);
                  
                  u_xlat5 = textureLod(_MainTex, u_xlat5.zw, 0.0).yzxw;
                  
                  u_xlat7.xy = _MainTex_TexelSize.xy * float2(1.0, 0.0) + u_xlat4.zw;
                  
                  u_xlat4 = textureLod(_MainTex, u_xlat7.xy, 0.0);
                  
                  u_xlat5.x = u_xlat6.y;
                  
                  u_xlat5.yw = u_xlat4.yx;
                  
                  u_xlat7.xy = u_xlat5.xy * float2(2.0, 2.0) + u_xlat5.zw;
                  
                  u_xlatb15.xy = greaterThanEqual(u_xlat3.xyxy, float4(0.899999976, 0.899999976, 0.899999976, 0.899999976)).xy;
                  
                  
                      {
                      
                      float3 hlslcc_movcTemp = u_xlat7;
                      
                      hlslcc_movcTemp.x = (u_xlatb15.x) ? float(0.0) : u_xlat7.x;
                      
                      hlslcc_movcTemp.y = (u_xlatb15.y) ? float(0.0) : u_xlat7.y;
                      
                      u_xlat7 = hlslcc_movcTemp;
      
      }
                  
                  u_xlat7.xy = u_xlat7.xy * float2(20.0, 20.0) + u_xlat2.xz;
                  
                  u_xlat7.xy = u_xlat7.xy * float2(0.00625000009, 0.0017857143) + float2(0.503125012, 0.000892857148);
                  
                  u_xlat2 = textureLod(_AreaTex, u_xlat7.xy, 0.0);
                  
                  u_xlat1_d.xy = u_xlat1_d.xy + u_xlat2.yx;
      
      }
              
              u_xlatb7 = (-u_xlat1_d.y)==u_xlat1_d.x;
              
              if(u_xlatb7)
      {
                  
                  u_xlat2.xy = in_f.texcoord2.xy;
                  
                  u_xlat2.z = 1.0;
                  
                  u_xlat3.x = 0.0;
                  
                  while(true)
      {
                      
                      u_xlatb7 = in_f.texcoord4.x<u_xlat2.x;
                      
                      u_xlatb14 = 0.828100026<u_xlat2.z;
                      
                      u_xlatb7 = u_xlatb14 && u_xlatb7;
                      
                      u_xlatb14 = u_xlat3.x==0.0;
                      
                      u_xlatb7 = u_xlatb14 && u_xlatb7;
                      
                      if(!u_xlatb7)
      {
                          break;
      }
                      
                      u_xlat3 = textureLod(_MainTex, u_xlat2.xy, 0.0);
                      
                      u_xlat2.xy = _MainTex_TexelSize.xy * float2(-2.0, -0.0) + u_xlat2.xy;
                      
                      u_xlat2.z = u_xlat3.y;
      
      }
                  
                  u_xlat3.yz = u_xlat2.xz;
                  
                  u_xlat7.xy = u_xlat3.xz * float2(0.5, -2.0) + float2(0.0078125, 2.03125);
                  
                  u_xlat2 = textureLod(_SearchTex, u_xlat7.xy, 0.0);
                  
                  u_xlat7.x = u_xlat2.w * -2.00787401 + 3.25;
                  
                  u_xlat2.x = _MainTex_TexelSize.x * u_xlat7.x + u_xlat3.y;
                  
                  u_xlat2.y = in_f.texcoord3.y;
                  
                  u_xlat3 = textureLod(_MainTex, u_xlat2.xy, 0.0);
                  
                  u_xlat4.xy = in_f.texcoord2.zw;
                  
                  u_xlat4.z = 1.0;
                  
                  u_xlat5.x = 0.0;
                  
                  while(true)
      {
                      
                      u_xlatb7 = u_xlat4.x<in_f.texcoord4.y;
                      
                      u_xlatb14 = 0.828100026<u_xlat4.z;
                      
                      u_xlatb7 = u_xlatb14 && u_xlatb7;
                      
                      u_xlatb14 = u_xlat5.x==0.0;
                      
                      u_xlatb7 = u_xlatb14 && u_xlatb7;
                      
                      if(!u_xlatb7)
      {
                          break;
      }
                      
                      u_xlat5 = textureLod(_MainTex, u_xlat4.xy, 0.0);
                      
                      u_xlat4.xy = _MainTex_TexelSize.xy * float2(2.0, 0.0) + u_xlat4.xy;
                      
                      u_xlat4.z = u_xlat5.y;
      
      }
                  
                  u_xlat5.yz = u_xlat4.xz;
                  
                  u_xlat7.xy = u_xlat5.xz * float2(0.5, -2.0) + float2(0.5234375, 2.03125);
                  
                  u_xlat4 = textureLod(_SearchTex, u_xlat7.xy, 0.0);
                  
                  u_xlat7.x = u_xlat4.w * -2.00787401 + 3.25;
                  
                  u_xlat2.z = (-_MainTex_TexelSize.x) * u_xlat7.x + u_xlat5.y;
                  
                  u_xlat4 = _MainTex_TexelSize.zzzz * u_xlat2.zxzx + (-in_f.texcoord1.xxxx);
                  
                  u_xlat4 = roundEven(u_xlat4);
                  
                  u_xlat7.xy = sqrt(abs(u_xlat4.wz));
                  
                  u_xlat15.xy = _MainTex_TexelSize.xy * float2(1.0, 0.0) + u_xlat2.zy;
                  
                  u_xlat5 = textureLod(_MainTex, u_xlat15.xy, 0.0).yxzw;
                  
                  u_xlat5.x = u_xlat3.x;
                  
                  u_xlat15.xy = u_xlat5.xy * float2(4.0, 4.0);
                  
                  u_xlat15.xy = roundEven(u_xlat15.xy);
                  
                  u_xlat7.xy = u_xlat15.xy * float2(16.0, 16.0) + u_xlat7.xy;
                  
                  u_xlat7.xy = u_xlat7.xy * float2(0.00625000009, 0.0017857143) + float2(0.00312500005, 0.000892857148);
                  
                  u_xlat3 = textureLod(_AreaTex, u_xlat7.xy, 0.0);
                  
                  u_xlatb4 = greaterThanEqual(abs(u_xlat4), abs(u_xlat4.wzwz));
                  
                  u_xlat4.x = u_xlatb4.x ? float(1.0) : 0.0;
                  
                  u_xlat4.y = u_xlatb4.y ? float(1.0) : 0.0;
                  
                  u_xlat4.z = u_xlatb4.z ? float(0.75) : 0.0;
                  
                  u_xlat4.w = u_xlatb4.w ? float(0.75) : 0.0;
      
      ;
                  
                  u_xlat7.x = u_xlat4.y + u_xlat4.x;
                  
                  u_xlat7.xy = u_xlat4.zw / u_xlat7.xx;
                  
                  u_xlat2.w = in_f.texcoord.y;
                  
                  u_xlat15.xy = _MainTex_TexelSize.xy * float2(0.0, 1.0) + u_xlat2.xw;
                  
                  u_xlat4 = textureLod(_MainTex, u_xlat15.xy, 0.0);
                  
                  u_xlat21 = (-u_xlat7.x) * u_xlat4.x + 1.0;
                  
                  u_xlat15.xy = u_xlat2.zw + _MainTex_TexelSize.xy;
                  
                  u_xlat4 = textureLod(_MainTex, u_xlat15.xy, 0.0);
                  
                  u_xlat4.x = (-u_xlat7.y) * u_xlat4.x + u_xlat21;
                  
                  u_xlat4.x = clamp(u_xlat4.x, 0.0, 1.0);
                  
                  u_xlat2 = _MainTex_TexelSize.xyxy * float4(0.0, -2.0, 1.0, -2.0) + u_xlat2.xwzw;
                  
                  u_xlat5 = textureLod(_MainTex, u_xlat2.xy, 0.0);
                  
                  u_xlat7.x = (-u_xlat7.x) * u_xlat5.x + 1.0;
                  
                  u_xlat2 = textureLod(_MainTex, u_xlat2.zw, 0.0);
                  
                  u_xlat4.y = (-u_xlat7.y) * u_xlat2.x + u_xlat7.x;
                  
                  u_xlat4.y = clamp(u_xlat4.y, 0.0, 1.0);
                  
                  out_f.color.xy = u_xlat3.xy * u_xlat4.xy;
      
      }
              else
              
                  {
                  
                  out_f.color.xy = u_xlat1_d.xy;
                  
                  u_xlat0_d.x = 0.0;
      
      }
      
      }
          else
          
              {
              
              out_f.color.xy = float2(0.0, 0.0);
      
      }
          
          u_xlatb0 = 0.0<u_xlat0_d.x;
          
          if(u_xlatb0)
      {
              
              u_xlat0_d.xy = in_f.texcoord3.xy;
              
              u_xlat0_d.z = 1.0;
              
              u_xlat1_d.x = 0.0;
              
              while(true)
      {
                  
                  u_xlatb21 = in_f.texcoord4.z<u_xlat0_d.y;
                  
                  u_xlatb2.x = 0.828100026<u_xlat0_d.z;
                  
                  u_xlatb21 = u_xlatb21 && u_xlatb2.x;
                  
                  u_xlatb2.x = u_xlat1_d.x==0.0;
                  
                  u_xlatb21 = u_xlatb21 && u_xlatb2.x;
                  
                  if(!u_xlatb21)
      {
                      break;
      }
                  
                  u_xlat1_d = textureLod(_MainTex, u_xlat0_d.xy, 0.0).yxzw;
                  
                  u_xlat0_d.xy = _MainTex_TexelSize.xy * float2(-0.0, -2.0) + u_xlat0_d.xy;
                  
                  u_xlat0_d.z = u_xlat1_d.y;
      
      }
              
              u_xlat1_d.yz = u_xlat0_d.yz;
              
              u_xlat0_d.xy = u_xlat1_d.xz * float2(0.5, -2.0) + float2(0.0078125, 2.03125);
              
              u_xlat0_d = textureLod(_SearchTex, u_xlat0_d.xy, 0.0);
              
              u_xlat0_d.x = u_xlat0_d.w * -2.00787401 + 3.25;
              
              u_xlat0_d.x = _MainTex_TexelSize.y * u_xlat0_d.x + u_xlat1_d.y;
              
              u_xlat0_d.y = in_f.texcoord2.x;
              
              u_xlat1_d = textureLod(_MainTex, u_xlat0_d.yx, 0.0);
              
              u_xlat2.xy = in_f.texcoord3.zw;
              
              u_xlat2.z = 1.0;
              
              u_xlat3.x = 0.0;
              
              while(true)
      {
                  
                  u_xlatb1 = u_xlat2.y<in_f.texcoord4.w;
                  
                  u_xlatb15.x = 0.828100026<u_xlat2.z;
                  
                  u_xlatb1 = u_xlatb15.x && u_xlatb1;
                  
                  u_xlatb15.x = u_xlat3.x==0.0;
                  
                  u_xlatb1 = u_xlatb15.x && u_xlatb1;
                  
                  if(!u_xlatb1)
      {
                      break;
      }
                  
                  u_xlat3 = textureLod(_MainTex, u_xlat2.xy, 0.0).yxzw;
                  
                  u_xlat2.xy = _MainTex_TexelSize.xy * float2(0.0, 2.0) + u_xlat2.xy;
                  
                  u_xlat2.z = u_xlat3.y;
      
      }
              
              u_xlat3.yz = u_xlat2.yz;
              
              u_xlat1_d.xz = u_xlat3.xz * float2(0.5, -2.0) + float2(0.5234375, 2.03125);
              
              u_xlat2 = textureLod(_SearchTex, u_xlat1_d.xz, 0.0);
              
              u_xlat1_d.x = u_xlat2.w * -2.00787401 + 3.25;
              
              u_xlat0_d.z = (-_MainTex_TexelSize.y) * u_xlat1_d.x + u_xlat3.y;
              
              u_xlat2 = _MainTex_TexelSize.wwww * u_xlat0_d.zxzx + (-in_f.texcoord1.yyyy);
              
              u_xlat2 = roundEven(u_xlat2);
              
              u_xlat1_d.xz = sqrt(abs(u_xlat2.wz));
              
              u_xlat3.xy = _MainTex_TexelSize.xy * float2(0.0, 1.0) + u_xlat0_d.yz;
              
              u_xlat3 = textureLod(_MainTex, u_xlat3.xy, 0.0);
              
              u_xlat3.x = u_xlat1_d.y;
              
              u_xlat8.xz = u_xlat3.xy * float2(4.0, 4.0);
              
              u_xlat8.xz = roundEven(u_xlat8.xz);
              
              u_xlat1_d.xy = u_xlat8.xz * float2(16.0, 16.0) + u_xlat1_d.xz;
              
              u_xlat1_d.xy = u_xlat1_d.xy * float2(0.00625000009, 0.0017857143) + float2(0.00312500005, 0.000892857148);
              
              u_xlat1_d = textureLod(_AreaTex, u_xlat1_d.xy, 0.0);
              
              u_xlatb2 = greaterThanEqual(abs(u_xlat2), abs(u_xlat2.wzwz));
              
              u_xlat2.x = u_xlatb2.x ? float(1.0) : 0.0;
              
              u_xlat2.y = u_xlatb2.y ? float(1.0) : 0.0;
              
              u_xlat2.z = u_xlatb2.z ? float(0.75) : 0.0;
              
              u_xlat2.w = u_xlatb2.w ? float(0.75) : 0.0;
      
      ;
              
              u_xlat7.x = u_xlat2.y + u_xlat2.x;
              
              u_xlat15.xy = u_xlat2.zw / u_xlat7.xx;
              
              u_xlat0_d.w = in_f.texcoord.x;
              
              u_xlat2.xy = _MainTex_TexelSize.xy * float2(1.0, 0.0) + u_xlat0_d.wx;
              
              u_xlat2 = textureLod(_MainTex, u_xlat2.xy, 0.0);
              
              u_xlat7.x = (-u_xlat15.x) * u_xlat2.y + 1.0;
              
              u_xlat2.xy = u_xlat0_d.wz + _MainTex_TexelSize.xy;
              
              u_xlat2 = textureLod(_MainTex, u_xlat2.xy, 0.0);
              
              u_xlat16.x = (-u_xlat15.y) * u_xlat2.y + u_xlat7.x;
              
              u_xlat16.x = clamp(u_xlat16.x, 0.0, 1.0);
              
              u_xlat0_d = _MainTex_TexelSize.xyxy * float4(-2.0, 0.0, -2.0, 1.0) + u_xlat0_d.wxwz;
              
              u_xlat3 = textureLod(_MainTex, u_xlat0_d.xy, 0.0);
              
              u_xlat0_d.x = (-u_xlat15.x) * u_xlat3.y + 1.0;
              
              u_xlat3 = textureLod(_MainTex, u_xlat0_d.zw, 0.0);
              
              u_xlat16.y = (-u_xlat15.y) * u_xlat3.y + u_xlat0_d.x;
              
              u_xlat16.y = clamp(u_xlat16.y, 0.0, 1.0);
              
              out_f.color.zw = u_xlat1_d.xy * u_xlat16.xy;
      
      }
          else
          
              {
              
              out_f.color.zw = float2(0.0, 0.0);
      
      }
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
    Pass // ind: 7, name: 
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
      
      
      uniform float4 _MainTex_TexelSize;
      
      uniform sampler2D _BlendTex;
      
      uniform sampler2D _MainTex;
      
      
      
      struct appdata_t
      {
          
          float3 vertex : POSITION0;
      
      };
      
      
      struct OUT_Data_Vert
      {
          
          float2 texcoord : TEXCOORD0;
          
          float4 texcoord1 : TEXCOORD1;
          
          float4 vertex : SV_POSITION;
      
      };
      
      
      struct v2f
      {
          
          float2 texcoord : TEXCOORD0;
          
          float4 texcoord1 : TEXCOORD1;
      
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
          
          out_v.texcoord.xy = u_xlat0.xy;
          
          out_v.texcoord1 = _MainTex_TexelSize.xyxy * float4(1.0, 0.0, 0.0, 1.0) + u_xlat0.xyxy;
          
          return;
      
      }
      
      
      #define CODE_BLOCK_FRAGMENT
      
      float4 u_xlat0_d;
      
      int u_xlatb0;
      
      float4 u_xlat1;
      
      float4 u_xlat2;
      
      float u_xlat3;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d = texture(_BlendTex, in_f.texcoord1.xy);
          
          u_xlat1 = texture(_BlendTex, in_f.texcoord1.zw);
          
          u_xlat2 = texture(_BlendTex, in_f.texcoord.xy).ywzx;
          
          u_xlat2.x = u_xlat0_d.w;
          
          u_xlat2.y = u_xlat1.y;
          
          u_xlat0_d.x = dot(u_xlat2, float4(1.0, 1.0, 1.0, 1.0));
          
          u_xlatb0 = u_xlat0_d.x<9.99999975e-06;
          
          if(u_xlatb0)
      {
              
              out_f.color = textureLod(_MainTex, in_f.texcoord.xy, 0.0);
      
      }
          else
          
              {
              
              u_xlat0_d.x = max(u_xlat0_d.w, u_xlat2.z);
              
              u_xlat3 = max(u_xlat2.w, u_xlat2.y);
              
              u_xlatb0 = u_xlat3<u_xlat0_d.x;
              
              u_xlat1.x = u_xlatb0 ? u_xlat0_d.w : float(0.0);
              
              u_xlat1.z = u_xlatb0 ? u_xlat2.z : float(0.0);
              
              u_xlat1.yw = (int(u_xlatb0)) ? float2(0.0, 0.0) : u_xlat2.yw;
              
              u_xlat2.x = (u_xlatb0) ? u_xlat0_d.w : u_xlat2.y;
              
              u_xlat2.y = (u_xlatb0) ? u_xlat2.z : u_xlat2.w;
              
              u_xlat0_d.x = dot(u_xlat2.xy, float2(1.0, 1.0));
              
              u_xlat0_d.xy = u_xlat2.xy / u_xlat0_d.xx;
              
              u_xlat2 = _MainTex_TexelSize.xyxy * float4(1.0, 1.0, -1.0, -1.0);
              
              u_xlat1 = u_xlat1 * u_xlat2 + in_f.texcoord.xyxy;
              
              u_xlat2 = textureLod(_MainTex, u_xlat1.xy, 0.0);
              
              u_xlat1 = textureLod(_MainTex, u_xlat1.zw, 0.0);
              
              u_xlat1 = u_xlat0_d.yyyy * u_xlat1;
              
              out_f.color = u_xlat0_d.xxxx * u_xlat2 + u_xlat1;
      
      }
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
