Shader "Hidden/PostProcessing/Lut2DBaker"
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
      
      uniform float4 _Lut2D_Params;
      
      uniform float3 _ColorBalance;
      
      uniform float3 _ColorFilter;
      
      uniform float3 _HueSatCon;
      
      uniform float _Brightness;
      
      uniform float3 _ChannelMixerRed;
      
      uniform float3 _ChannelMixerGreen;
      
      uniform float3 _ChannelMixerBlue;
      
      uniform float3 _Lift;
      
      uniform float3 _InvGamma;
      
      uniform float3 _Gain;
      
      uniform sampler2D _Curves;
      
      
      
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
          
          float2 texcoord1 : TEXCOORD1;
      
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
      
      float4 u_xlat4;
      
      float4 u_xlat5;
      
      float3 u_xlat6;
      
      int u_xlatb6;
      
      float u_xlat7;
      
      int u_xlatb7;
      
      float2 u_xlat14;
      
      float2 u_xlat15;
      
      float u_xlat18;
      
      int u_xlatb18;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d.yz = in_f.texcoord1.xy + (-_Lut2D_Params.yz);
          
          u_xlat1.x = u_xlat0_d.y * _Lut2D_Params.x;
          
          u_xlat0_d.x = fract(u_xlat1.x);
          
          u_xlat1.x = u_xlat0_d.x / _Lut2D_Params.x;
          
          u_xlat0_d.w = u_xlat0_d.y + (-u_xlat1.x);
          
          u_xlat0_d.xyz = u_xlat0_d.xzw * _Lut2D_Params.www;
          
          u_xlat0_d.xyz = u_xlat0_d.xyz * float3(float3(_Brightness, _Brightness, _Brightness)) + float3(-0.217637643, -0.217637643, -0.217637643);
          
          u_xlat0_d.xyz = u_xlat0_d.xyz * _HueSatCon.zzz + float3(0.217637643, 0.217637643, 0.217637643);
          
          u_xlat1.x = dot(float3(0.390404999, 0.549941003, 0.00892631989), u_xlat0_d.xyz);
          
          u_xlat1.y = dot(float3(0.070841603, 0.963172019, 0.00135775004), u_xlat0_d.xyz);
          
          u_xlat1.z = dot(float3(0.0231081992, 0.128021002, 0.936245024), u_xlat0_d.xyz);
          
          u_xlat0_d.xyz = u_xlat1.xyz * _ColorBalance.xyz;
          
          u_xlat1.x = dot(float3(2.85846996, -1.62879002, -0.0248910002), u_xlat0_d.xyz);
          
          u_xlat1.y = dot(float3(-0.210181996, 1.15820003, 0.000324280991), u_xlat0_d.xyz);
          
          u_xlat1.z = dot(float3(-0.0418119989, -0.118169002, 1.06867003), u_xlat0_d.xyz);
          
          u_xlat0_d.xyz = u_xlat1.xyz * _ColorFilter.xyz;
          
          u_xlat1.x = dot(u_xlat0_d.xyz, _ChannelMixerRed.xyz);
          
          u_xlat1.y = dot(u_xlat0_d.xyz, _ChannelMixerGreen.xyz);
          
          u_xlat1.z = dot(u_xlat0_d.xyz, _ChannelMixerBlue.xyz);
          
          u_xlat0_d.xyz = u_xlat1.xyz * _Gain.xyz + _Lift.xyz;
          
          u_xlat1.xyz = log2(abs(u_xlat0_d.xyz));
          
          u_xlat0_d.xyz = u_xlat0_d.xyz * float3(3.40282347e+38, 3.40282347e+38, 3.40282347e+38) + float3(0.5, 0.5, 0.5);
          
          u_xlat0_d.xyz = clamp(u_xlat0_d.xyz, 0.0, 1.0);
          
          u_xlat0_d.xyz = u_xlat0_d.xyz * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
          
          u_xlat1.xyz = u_xlat1.xyz * _InvGamma.xyz;
          
          u_xlat1.xyz = exp2(u_xlat1.xyz);
          
          u_xlat0_d.xyz = u_xlat0_d.xyz * u_xlat1.xyz;
          
          u_xlat0_d.xyz = max(u_xlat0_d.xyz, float3(0.0, 0.0, 0.0));
          
          u_xlatb18 = u_xlat0_d.y>=u_xlat0_d.z;
          
          u_xlat18 = u_xlatb18 ? 1.0 : float(0.0);
          
          u_xlat1.xy = u_xlat0_d.zy;
          
          u_xlat2.xy = u_xlat0_d.yz + (-u_xlat1.xy);
          
          u_xlat1.z = float(-1.0);
          
          u_xlat1.w = float(0.666666687);
          
          u_xlat2.z = float(1.0);
          
          u_xlat2.w = float(-1.0);
          
          u_xlat1 = float4(u_xlat18) * u_xlat2.xywz + u_xlat1.xywz;
          
          u_xlatb18 = u_xlat0_d.x>=u_xlat1.x;
          
          u_xlat18 = u_xlatb18 ? 1.0 : float(0.0);
          
          u_xlat2.z = u_xlat1.w;
          
          u_xlat1.w = u_xlat0_d.x;
          
          u_xlat3.x = dot(u_xlat0_d.xyz, float3(0.212672904, 0.715152204, 0.0721750036));
          
          u_xlat2.xyw = u_xlat1.wyx;
          
          u_xlat2 = (-u_xlat1) + u_xlat2;
          
          u_xlat0_d = float4(u_xlat18) * u_xlat2 + u_xlat1;
          
          u_xlat1.x = min(u_xlat0_d.y, u_xlat0_d.w);
          
          u_xlat1.x = u_xlat0_d.x + (-u_xlat1.x);
          
          u_xlat7 = u_xlat1.x * 6.0 + 9.99999975e-05;
          
          u_xlat6.x = (-u_xlat0_d.y) + u_xlat0_d.w;
          
          u_xlat6.x = u_xlat6.x / u_xlat7;
          
          u_xlat6.x = u_xlat6.x + u_xlat0_d.z;
          
          u_xlat2.x = abs(u_xlat6.x);
          
          u_xlat15.x = u_xlat2.x + _HueSatCon.x;
          
          u_xlat3.y = float(0.25);
          
          u_xlat15.y = float(0.25);
          
          u_xlat4 = textureLod(_Curves, u_xlat15.xy, 0.0);
          
          u_xlat5 = textureLod(_Curves, u_xlat3.xy, 0.0).wxyz;
          
          u_xlat5.x = u_xlat5.x;
          
          u_xlat5.x = clamp(u_xlat5.x, 0.0, 1.0);
          
          u_xlat4.x = u_xlat4.x;
          
          u_xlat4.x = clamp(u_xlat4.x, 0.0, 1.0);
          
          u_xlat6.x = u_xlat15.x + u_xlat4.x;
          
          u_xlat6.xyz = u_xlat6.xxx + float3(-0.5, 0.5, -1.5);
          
          u_xlatb7 = 1.0<u_xlat6.x;
          
          u_xlat18 = (u_xlatb7) ? u_xlat6.z : u_xlat6.x;
          
          u_xlatb6 = u_xlat6.x<0.0;
          
          u_xlat6.x = (u_xlatb6) ? u_xlat6.y : u_xlat18;
          
          u_xlat6.xyz = u_xlat6.xxx + float3(1.0, 0.666666687, 0.333333343);
          
          u_xlat6.xyz = fract(u_xlat6.xyz);
          
          u_xlat6.xyz = u_xlat6.xyz * float3(6.0, 6.0, 6.0) + float3(-3.0, -3.0, -3.0);
          
          u_xlat6.xyz = abs(u_xlat6.xyz) + float3(-1.0, -1.0, -1.0);
          
          u_xlat6.xyz = clamp(u_xlat6.xyz, 0.0, 1.0);
          
          u_xlat6.xyz = u_xlat6.xyz + float3(-1.0, -1.0, -1.0);
          
          u_xlat7 = u_xlat0_d.x + 9.99999975e-05;
          
          u_xlat14.x = u_xlat1.x / u_xlat7;
          
          u_xlat6.xyz = u_xlat14.xxx * u_xlat6.xyz + float3(1.0, 1.0, 1.0);
          
          u_xlat1.xyz = u_xlat6.xyz * u_xlat0_d.xxx;
          
          u_xlat1.x = dot(u_xlat1.xyz, float3(0.212672904, 0.715152204, 0.0721750036));
          
          u_xlat0_d.xyz = u_xlat0_d.xxx * u_xlat6.xyz + (-u_xlat1.xxx);
          
          u_xlat2.y = float(0.25);
          
          u_xlat14.y = float(0.25);
          
          u_xlat3 = textureLod(_Curves, u_xlat2.xy, 0.0).yxzw;
          
          u_xlat2 = textureLod(_Curves, u_xlat14.xy, 0.0).zxyw;
          
          u_xlat2.x = u_xlat2.x;
          
          u_xlat2.x = clamp(u_xlat2.x, 0.0, 1.0);
          
          u_xlat3.x = u_xlat3.x;
          
          u_xlat3.x = clamp(u_xlat3.x, 0.0, 1.0);
          
          u_xlat18 = u_xlat3.x + u_xlat3.x;
          
          u_xlat18 = dot(u_xlat2.xx, float2(u_xlat18));
          
          u_xlat18 = u_xlat18 * u_xlat5.x;
          
          u_xlat18 = dot(_HueSatCon.yy, float2(u_xlat18));
          
          u_xlat0_d.xyz = float3(u_xlat18) * u_xlat0_d.xyz + u_xlat1.xxx;
          
          u_xlat0_d.xyz = clamp(u_xlat0_d.xyz, 0.0, 1.0);
          
          u_xlat0_d.xyz = u_xlat0_d.xyz + float3(0.00390625, 0.00390625, 0.00390625);
          
          u_xlat0_d.w = 0.75;
          
          u_xlat1 = texture(_Curves, u_xlat0_d.xw).wxyz;
          
          u_xlat1.x = u_xlat1.x;
          
          u_xlat1.x = clamp(u_xlat1.x, 0.0, 1.0);
          
          u_xlat2 = texture(_Curves, u_xlat0_d.yw);
          
          u_xlat0_d = texture(_Curves, u_xlat0_d.zw);
          
          u_xlat1.z = u_xlat0_d.w;
          
          u_xlat1.z = clamp(u_xlat1.z, 0.0, 1.0);
          
          u_xlat1.y = u_xlat2.w;
          
          u_xlat1.y = clamp(u_xlat1.y, 0.0, 1.0);
          
          u_xlat0_d.xyz = u_xlat1.xyz + float3(0.00390625, 0.00390625, 0.00390625);
          
          u_xlat0_d.w = 0.75;
          
          u_xlat1 = texture(_Curves, u_xlat0_d.xw);
          
          out_f.color.x = u_xlat1.x;
          
          out_f.color.x = clamp(out_f.color.x, 0.0, 1.0);
          
          u_xlat1 = texture(_Curves, u_xlat0_d.yw);
          
          u_xlat0_d = texture(_Curves, u_xlat0_d.zw);
          
          out_f.color.z = u_xlat0_d.z;
          
          out_f.color.z = clamp(out_f.color.z, 0.0, 1.0);
          
          out_f.color.y = u_xlat1.y;
          
          out_f.color.y = clamp(out_f.color.y, 0.0, 1.0);
          
          out_f.color.w = 1.0;
          
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
      
      uniform float4 _Lut2D_Params;
      
      uniform float4 _UserLut2D_Params;
      
      uniform float3 _ColorBalance;
      
      uniform float3 _ColorFilter;
      
      uniform float3 _HueSatCon;
      
      uniform float _Brightness;
      
      uniform float3 _ChannelMixerRed;
      
      uniform float3 _ChannelMixerGreen;
      
      uniform float3 _ChannelMixerBlue;
      
      uniform float3 _Lift;
      
      uniform float3 _InvGamma;
      
      uniform float3 _Gain;
      
      uniform sampler2D _MainTex;
      
      uniform sampler2D _Curves;
      
      
      
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
          
          float2 texcoord1 : TEXCOORD1;
      
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
      
      int u_xlatb0;
      
      float4 u_xlat1;
      
      float4 u_xlat2;
      
      float4 u_xlat3;
      
      float4 u_xlat4;
      
      float4 u_xlat5;
      
      float3 u_xlat6;
      
      int u_xlatb6;
      
      float u_xlat7;
      
      int u_xlatb7;
      
      float u_xlat8;
      
      float2 u_xlat12;
      
      float2 u_xlat13;
      
      float u_xlat18;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d.x = _UserLut2D_Params.y;
          
          u_xlat1.yz = in_f.texcoord1.xy + (-_Lut2D_Params.yz);
          
          u_xlat2.x = u_xlat1.y * _Lut2D_Params.x;
          
          u_xlat1.x = fract(u_xlat2.x);
          
          u_xlat2.x = u_xlat1.x / _Lut2D_Params.x;
          
          u_xlat1.w = u_xlat1.y + (-u_xlat2.x);
          
          u_xlat2.xyz = u_xlat1.xzw * _Lut2D_Params.www;
          
          u_xlat3.xyz = u_xlat2.zxy * _UserLut2D_Params.zzz;
          
          u_xlat7 = floor(u_xlat3.x);
          
          u_xlat3.xw = _UserLut2D_Params.xy * float2(0.5, 0.5);
          
          u_xlat3.yz = u_xlat3.yz * _UserLut2D_Params.xy + u_xlat3.xw;
          
          u_xlat3.x = u_xlat7 * _UserLut2D_Params.y + u_xlat3.y;
          
          u_xlat7 = u_xlat2.z * _UserLut2D_Params.z + (-u_xlat7);
          
          u_xlat0_d.y = float(0.0);
          
          u_xlat12.y = float(0.25);
          
          u_xlat0_d.xy = u_xlat0_d.xy + u_xlat3.xz;
          
          u_xlat3 = texture(_MainTex, u_xlat3.xz);
          
          u_xlat4 = texture(_MainTex, u_xlat0_d.xy);
          
          u_xlat4.xyz = (-u_xlat3.xyz) + u_xlat4.xyz;
          
          u_xlat3.xyz = float3(u_xlat7) * u_xlat4.xyz + u_xlat3.xyz;
          
          u_xlat1.xyz = (-u_xlat1.xzw) * _Lut2D_Params.www + u_xlat3.xyz;
          
          u_xlat1.xyz = _UserLut2D_Params.www * u_xlat1.xyz + u_xlat2.xyz;
          
          u_xlat1.xyz = u_xlat1.xyz * float3(float3(_Brightness, _Brightness, _Brightness)) + float3(-0.217637643, -0.217637643, -0.217637643);
          
          u_xlat1.xyz = u_xlat1.xyz * _HueSatCon.zzz + float3(0.217637643, 0.217637643, 0.217637643);
          
          u_xlat2.x = dot(float3(0.390404999, 0.549941003, 0.00892631989), u_xlat1.xyz);
          
          u_xlat2.y = dot(float3(0.070841603, 0.963172019, 0.00135775004), u_xlat1.xyz);
          
          u_xlat2.z = dot(float3(0.0231081992, 0.128021002, 0.936245024), u_xlat1.xyz);
          
          u_xlat1.xyz = u_xlat2.xyz * _ColorBalance.xyz;
          
          u_xlat2.x = dot(float3(2.85846996, -1.62879002, -0.0248910002), u_xlat1.xyz);
          
          u_xlat2.y = dot(float3(-0.210181996, 1.15820003, 0.000324280991), u_xlat1.xyz);
          
          u_xlat2.z = dot(float3(-0.0418119989, -0.118169002, 1.06867003), u_xlat1.xyz);
          
          u_xlat1.xyz = u_xlat2.xyz * _ColorFilter.xyz;
          
          u_xlat2.x = dot(u_xlat1.xyz, _ChannelMixerRed.xyz);
          
          u_xlat2.y = dot(u_xlat1.xyz, _ChannelMixerGreen.xyz);
          
          u_xlat2.z = dot(u_xlat1.xyz, _ChannelMixerBlue.xyz);
          
          u_xlat1.xyz = u_xlat2.xyz * _Gain.xyz + _Lift.xyz;
          
          u_xlat2.xyz = log2(abs(u_xlat1.xyz));
          
          u_xlat1.xyz = u_xlat1.xyz * float3(3.40282347e+38, 3.40282347e+38, 3.40282347e+38) + float3(0.5, 0.5, 0.5);
          
          u_xlat1.xyz = clamp(u_xlat1.xyz, 0.0, 1.0);
          
          u_xlat1.xyz = u_xlat1.xyz * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
          
          u_xlat2.xyz = u_xlat2.xyz * _InvGamma.xyz;
          
          u_xlat2.xyz = exp2(u_xlat2.xyz);
          
          u_xlat1.xyz = u_xlat1.xyz * u_xlat2.xyz;
          
          u_xlat1.xyz = max(u_xlat1.xyz, float3(0.0, 0.0, 0.0));
          
          u_xlatb0 = u_xlat1.y>=u_xlat1.z;
          
          u_xlat0_d.x = u_xlatb0 ? 1.0 : float(0.0);
          
          u_xlat2.xy = u_xlat1.zy;
          
          u_xlat3.xy = u_xlat1.yz + (-u_xlat2.xy);
          
          u_xlat2.z = float(-1.0);
          
          u_xlat2.w = float(0.666666687);
          
          u_xlat3.z = float(1.0);
          
          u_xlat3.w = float(-1.0);
          
          u_xlat2 = u_xlat0_d.xxxx * u_xlat3.xywz + u_xlat2.xywz;
          
          u_xlatb0 = u_xlat1.x>=u_xlat2.x;
          
          u_xlat0_d.x = u_xlatb0 ? 1.0 : float(0.0);
          
          u_xlat3.z = u_xlat2.w;
          
          u_xlat2.w = u_xlat1.x;
          
          u_xlat13.x = dot(u_xlat1.xyz, float3(0.212672904, 0.715152204, 0.0721750036));
          
          u_xlat3.xyw = u_xlat2.wyx;
          
          u_xlat3 = (-u_xlat2) + u_xlat3;
          
          u_xlat2 = u_xlat0_d.xxxx * u_xlat3 + u_xlat2;
          
          u_xlat0_d.x = min(u_xlat2.y, u_xlat2.w);
          
          u_xlat0_d.x = (-u_xlat0_d.x) + u_xlat2.x;
          
          u_xlat6.x = u_xlat0_d.x * 6.0 + 9.99999975e-05;
          
          u_xlat8 = (-u_xlat2.y) + u_xlat2.w;
          
          u_xlat6.x = u_xlat8 / u_xlat6.x;
          
          u_xlat6.x = u_xlat6.x + u_xlat2.z;
          
          u_xlat12.x = abs(u_xlat6.x);
          
          u_xlat3 = textureLod(_Curves, u_xlat12.xy, 0.0).yxzw;
          
          u_xlat4.x = u_xlat12.x + _HueSatCon.x;
          
          u_xlat3.x = u_xlat3.x;
          
          u_xlat3.x = clamp(u_xlat3.x, 0.0, 1.0);
          
          u_xlat6.x = u_xlat3.x + u_xlat3.x;
          
          u_xlat12.x = u_xlat2.x + 9.99999975e-05;
          
          u_xlat1.x = u_xlat0_d.x / u_xlat12.x;
          
          u_xlat1.y = float(0.25);
          
          u_xlat13.y = float(0.25);
          
          u_xlat3 = textureLod(_Curves, u_xlat1.xy, 0.0).zxyw;
          
          u_xlat5 = textureLod(_Curves, u_xlat13.xy, 0.0).wxyz;
          
          u_xlat5.x = u_xlat5.x;
          
          u_xlat5.x = clamp(u_xlat5.x, 0.0, 1.0);
          
          u_xlat3.x = u_xlat3.x;
          
          u_xlat3.x = clamp(u_xlat3.x, 0.0, 1.0);
          
          u_xlat0_d.x = dot(u_xlat3.xx, u_xlat6.xx);
          
          u_xlat0_d.x = u_xlat0_d.x * u_xlat5.x;
          
          u_xlat0_d.x = dot(_HueSatCon.yy, u_xlat0_d.xx);
          
          u_xlat4.y = 0.25;
          
          u_xlat3 = textureLod(_Curves, u_xlat4.xy, 0.0);
          
          u_xlat3.x = u_xlat3.x;
          
          u_xlat3.x = clamp(u_xlat3.x, 0.0, 1.0);
          
          u_xlat6.x = u_xlat4.x + u_xlat3.x;
          
          u_xlat6.xyz = u_xlat6.xxx + float3(-0.5, 0.5, -1.5);
          
          u_xlatb7 = 1.0<u_xlat6.x;
          
          u_xlat18 = (u_xlatb7) ? u_xlat6.z : u_xlat6.x;
          
          u_xlatb6 = u_xlat6.x<0.0;
          
          u_xlat6.x = (u_xlatb6) ? u_xlat6.y : u_xlat18;
          
          u_xlat6.xyz = u_xlat6.xxx + float3(1.0, 0.666666687, 0.333333343);
          
          u_xlat6.xyz = fract(u_xlat6.xyz);
          
          u_xlat6.xyz = u_xlat6.xyz * float3(6.0, 6.0, 6.0) + float3(-3.0, -3.0, -3.0);
          
          u_xlat6.xyz = abs(u_xlat6.xyz) + float3(-1.0, -1.0, -1.0);
          
          u_xlat6.xyz = clamp(u_xlat6.xyz, 0.0, 1.0);
          
          u_xlat6.xyz = u_xlat6.xyz + float3(-1.0, -1.0, -1.0);
          
          u_xlat6.xyz = u_xlat1.xxx * u_xlat6.xyz + float3(1.0, 1.0, 1.0);
          
          u_xlat1.xyz = u_xlat6.xyz * u_xlat2.xxx;
          
          u_xlat1.x = dot(u_xlat1.xyz, float3(0.212672904, 0.715152204, 0.0721750036));
          
          u_xlat6.xyz = u_xlat2.xxx * u_xlat6.xyz + (-u_xlat1.xxx);
          
          u_xlat0_d.xyz = u_xlat0_d.xxx * u_xlat6.xyz + u_xlat1.xxx;
          
          u_xlat0_d.xyz = clamp(u_xlat0_d.xyz, 0.0, 1.0);
          
          u_xlat0_d.xyz = u_xlat0_d.xyz + float3(0.00390625, 0.00390625, 0.00390625);
          
          u_xlat0_d.w = 0.75;
          
          u_xlat1 = texture(_Curves, u_xlat0_d.xw).wxyz;
          
          u_xlat1.x = u_xlat1.x;
          
          u_xlat1.x = clamp(u_xlat1.x, 0.0, 1.0);
          
          u_xlat2 = texture(_Curves, u_xlat0_d.yw);
          
          u_xlat0_d = texture(_Curves, u_xlat0_d.zw);
          
          u_xlat1.z = u_xlat0_d.w;
          
          u_xlat1.z = clamp(u_xlat1.z, 0.0, 1.0);
          
          u_xlat1.y = u_xlat2.w;
          
          u_xlat1.y = clamp(u_xlat1.y, 0.0, 1.0);
          
          u_xlat0_d.xyz = u_xlat1.xyz + float3(0.00390625, 0.00390625, 0.00390625);
          
          u_xlat0_d.w = 0.75;
          
          u_xlat1 = texture(_Curves, u_xlat0_d.xw);
          
          out_f.color.x = u_xlat1.x;
          
          out_f.color.x = clamp(out_f.color.x, 0.0, 1.0);
          
          u_xlat1 = texture(_Curves, u_xlat0_d.yw);
          
          u_xlat0_d = texture(_Curves, u_xlat0_d.zw);
          
          out_f.color.z = u_xlat0_d.z;
          
          out_f.color.z = clamp(out_f.color.z, 0.0, 1.0);
          
          out_f.color.y = u_xlat1.y;
          
          out_f.color.y = clamp(out_f.color.y, 0.0, 1.0);
          
          out_f.color.w = 1.0;
          
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
      
      uniform float4 _Lut2D_Params;
      
      uniform float3 _ColorBalance;
      
      uniform float3 _ColorFilter;
      
      uniform float3 _HueSatCon;
      
      uniform float3 _ChannelMixerRed;
      
      uniform float3 _ChannelMixerGreen;
      
      uniform float3 _ChannelMixerBlue;
      
      uniform float3 _Lift;
      
      uniform float3 _InvGamma;
      
      uniform float3 _Gain;
      
      uniform sampler2D _Curves;
      
      
      
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
      
      float4 u_xlat4;
      
      float4 u_xlat5;
      
      float3 u_xlat6;
      
      int u_xlatb6;
      
      float u_xlat7;
      
      int u_xlatb7;
      
      float2 u_xlat14;
      
      float2 u_xlat15;
      
      float u_xlat18;
      
      int u_xlatb18;
      
      OUT_Data_Frag frag(v2f in_f)
      {
          
          u_xlat0_d.yz = in_f.texcoord.xy + (-_Lut2D_Params.yz);
          
          u_xlat1.x = u_xlat0_d.y * _Lut2D_Params.x;
          
          u_xlat0_d.x = fract(u_xlat1.x);
          
          u_xlat1.x = u_xlat0_d.x / _Lut2D_Params.x;
          
          u_xlat0_d.w = u_xlat0_d.y + (-u_xlat1.x);
          
          u_xlat0_d.xyz = u_xlat0_d.xzw * _Lut2D_Params.www + float3(-0.413588405, -0.413588405, -0.413588405);
          
          u_xlat0_d.xyz = u_xlat0_d.xyz * _HueSatCon.zzz + float3(0.0275523961, 0.0275523961, 0.0275523961);
          
          u_xlat0_d.xyz = u_xlat0_d.xyz * float3(13.6054821, 13.6054821, 13.6054821);
          
          u_xlat0_d.xyz = exp2(u_xlat0_d.xyz);
          
          u_xlat0_d.xyz = u_xlat0_d.xyz + float3(-0.0479959995, -0.0479959995, -0.0479959995);
          
          u_xlat0_d.xyz = u_xlat0_d.xyz * float3(0.179999992, 0.179999992, 0.179999992);
          
          u_xlat1.x = dot(float3(0.390404999, 0.549941003, 0.00892631989), u_xlat0_d.xyz);
          
          u_xlat1.y = dot(float3(0.070841603, 0.963172019, 0.00135775004), u_xlat0_d.xyz);
          
          u_xlat1.z = dot(float3(0.0231081992, 0.128021002, 0.936245024), u_xlat0_d.xyz);
          
          u_xlat0_d.xyz = u_xlat1.xyz * _ColorBalance.xyz;
          
          u_xlat1.x = dot(float3(2.85846996, -1.62879002, -0.0248910002), u_xlat0_d.xyz);
          
          u_xlat1.y = dot(float3(-0.210181996, 1.15820003, 0.000324280991), u_xlat0_d.xyz);
          
          u_xlat1.z = dot(float3(-0.0418119989, -0.118169002, 1.06867003), u_xlat0_d.xyz);
          
          u_xlat0_d.xyz = u_xlat1.xyz * _ColorFilter.xyz;
          
          u_xlat1.x = dot(u_xlat0_d.xyz, _ChannelMixerRed.xyz);
          
          u_xlat1.y = dot(u_xlat0_d.xyz, _ChannelMixerGreen.xyz);
          
          u_xlat1.z = dot(u_xlat0_d.xyz, _ChannelMixerBlue.xyz);
          
          u_xlat0_d.xyz = u_xlat1.xyz * _Gain.xyz + _Lift.xyz;
          
          u_xlat1.xyz = log2(abs(u_xlat0_d.xyz));
          
          u_xlat0_d.xyz = u_xlat0_d.xyz * float3(3.40282347e+38, 3.40282347e+38, 3.40282347e+38) + float3(0.5, 0.5, 0.5);
          
          u_xlat0_d.xyz = clamp(u_xlat0_d.xyz, 0.0, 1.0);
          
          u_xlat0_d.xyz = u_xlat0_d.xyz * float3(2.0, 2.0, 2.0) + float3(-1.0, -1.0, -1.0);
          
          u_xlat1.xyz = u_xlat1.xyz * _InvGamma.xyz;
          
          u_xlat1.xyz = exp2(u_xlat1.xyz);
          
          u_xlat0_d.xyz = u_xlat0_d.xyz * u_xlat1.xyz;
          
          u_xlat0_d.xyz = max(u_xlat0_d.xyz, float3(0.0, 0.0, 0.0));
          
          u_xlatb18 = u_xlat0_d.y>=u_xlat0_d.z;
          
          u_xlat18 = u_xlatb18 ? 1.0 : float(0.0);
          
          u_xlat1.xy = u_xlat0_d.zy;
          
          u_xlat2.xy = u_xlat0_d.yz + (-u_xlat1.xy);
          
          u_xlat1.z = float(-1.0);
          
          u_xlat1.w = float(0.666666687);
          
          u_xlat2.z = float(1.0);
          
          u_xlat2.w = float(-1.0);
          
          u_xlat1 = float4(u_xlat18) * u_xlat2.xywz + u_xlat1.xywz;
          
          u_xlatb18 = u_xlat0_d.x>=u_xlat1.x;
          
          u_xlat18 = u_xlatb18 ? 1.0 : float(0.0);
          
          u_xlat2.z = u_xlat1.w;
          
          u_xlat1.w = u_xlat0_d.x;
          
          u_xlat3.x = dot(u_xlat0_d.xyz, float3(0.212672904, 0.715152204, 0.0721750036));
          
          u_xlat2.xyw = u_xlat1.wyx;
          
          u_xlat2 = (-u_xlat1) + u_xlat2;
          
          u_xlat0_d = float4(u_xlat18) * u_xlat2 + u_xlat1;
          
          u_xlat1.x = min(u_xlat0_d.y, u_xlat0_d.w);
          
          u_xlat1.x = u_xlat0_d.x + (-u_xlat1.x);
          
          u_xlat7 = u_xlat1.x * 6.0 + 9.99999975e-05;
          
          u_xlat6.x = (-u_xlat0_d.y) + u_xlat0_d.w;
          
          u_xlat6.x = u_xlat6.x / u_xlat7;
          
          u_xlat6.x = u_xlat6.x + u_xlat0_d.z;
          
          u_xlat2.x = abs(u_xlat6.x);
          
          u_xlat15.x = u_xlat2.x + _HueSatCon.x;
          
          u_xlat3.y = float(0.25);
          
          u_xlat15.y = float(0.25);
          
          u_xlat4 = textureLod(_Curves, u_xlat15.xy, 0.0);
          
          u_xlat5 = textureLod(_Curves, u_xlat3.xy, 0.0).wxyz;
          
          u_xlat5.x = u_xlat5.x;
          
          u_xlat5.x = clamp(u_xlat5.x, 0.0, 1.0);
          
          u_xlat4.x = u_xlat4.x;
          
          u_xlat4.x = clamp(u_xlat4.x, 0.0, 1.0);
          
          u_xlat6.x = u_xlat15.x + u_xlat4.x;
          
          u_xlat6.xyz = u_xlat6.xxx + float3(-0.5, 0.5, -1.5);
          
          u_xlatb7 = 1.0<u_xlat6.x;
          
          u_xlat18 = (u_xlatb7) ? u_xlat6.z : u_xlat6.x;
          
          u_xlatb6 = u_xlat6.x<0.0;
          
          u_xlat6.x = (u_xlatb6) ? u_xlat6.y : u_xlat18;
          
          u_xlat6.xyz = u_xlat6.xxx + float3(1.0, 0.666666687, 0.333333343);
          
          u_xlat6.xyz = fract(u_xlat6.xyz);
          
          u_xlat6.xyz = u_xlat6.xyz * float3(6.0, 6.0, 6.0) + float3(-3.0, -3.0, -3.0);
          
          u_xlat6.xyz = abs(u_xlat6.xyz) + float3(-1.0, -1.0, -1.0);
          
          u_xlat6.xyz = clamp(u_xlat6.xyz, 0.0, 1.0);
          
          u_xlat6.xyz = u_xlat6.xyz + float3(-1.0, -1.0, -1.0);
          
          u_xlat7 = u_xlat0_d.x + 9.99999975e-05;
          
          u_xlat14.x = u_xlat1.x / u_xlat7;
          
          u_xlat6.xyz = u_xlat14.xxx * u_xlat6.xyz + float3(1.0, 1.0, 1.0);
          
          u_xlat1.xyz = u_xlat6.xyz * u_xlat0_d.xxx;
          
          u_xlat1.x = dot(u_xlat1.xyz, float3(0.212672904, 0.715152204, 0.0721750036));
          
          u_xlat0_d.xyz = u_xlat0_d.xxx * u_xlat6.xyz + (-u_xlat1.xxx);
          
          u_xlat2.y = float(0.25);
          
          u_xlat14.y = float(0.25);
          
          u_xlat3 = textureLod(_Curves, u_xlat2.xy, 0.0).yxzw;
          
          u_xlat2 = textureLod(_Curves, u_xlat14.xy, 0.0).zxyw;
          
          u_xlat2.x = u_xlat2.x;
          
          u_xlat2.x = clamp(u_xlat2.x, 0.0, 1.0);
          
          u_xlat3.x = u_xlat3.x;
          
          u_xlat3.x = clamp(u_xlat3.x, 0.0, 1.0);
          
          u_xlat18 = u_xlat3.x + u_xlat3.x;
          
          u_xlat18 = dot(u_xlat2.xx, float2(u_xlat18));
          
          u_xlat18 = u_xlat18 * u_xlat5.x;
          
          u_xlat18 = dot(_HueSatCon.yy, float2(u_xlat18));
          
          u_xlat0_d.xyz = float3(u_xlat18) * u_xlat0_d.xyz + u_xlat1.xxx;
          
          out_f.color.xyz = max(u_xlat0_d.xyz, float3(0.0, 0.0, 0.0));
          
          out_f.color.w = 1.0;
          
          return;
      
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
