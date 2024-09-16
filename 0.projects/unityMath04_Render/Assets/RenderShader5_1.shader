Shader "Unlit/RenderShader5_1"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			
			v2f vert (appdata v)
			{
				//バーテックスシェーダの取得
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);


				const float fTime_T = 10.0;
				float fAngle = 2.0 * 3.1416 * _Time.w / fTime_T;
				float2 uv_c = v.uv - float2(0.5, 0.5);
				float2 uv_t = float2(uv_c.x * cos(fAngle) - uv_c.y * sin(fAngle),
									 uv_c.x * sin(fAngle) + uv_c.y * cos(fAngle));
				uv_t += float2(0.5, 0.5);
				o.uv = TRANSFORM_TEX(uv_t, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG
		}
	}
}
