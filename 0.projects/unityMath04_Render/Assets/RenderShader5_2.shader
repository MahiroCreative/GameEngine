Shader "Unlit/RenderShader5_2"
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
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				const float fTime_T1 = 10.0, fTime_T2 = 5.0;
				float2 uv_c = i.uv - float2(0.5, 0.5);
				float fAngle = 2.0 * 3.1416 * (_Time.w / fTime_T1
							   - length(uv_c) * 0.5 * sin(2.0 * 3.1416 * (_Time.w / fTime_T2)));
				float2 uv_t = float2(uv_c.x * cos(fAngle) - uv_c.y * sin(fAngle),
									 uv_c.x * sin(fAngle) + uv_c.y * cos(fAngle));
				uv_t += float2(0.5, 0.5);
				fixed4 col = tex2D(_MainTex, uv_t);
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG
		}
	}
}
