Shader "Unlit/RenderShader3_2"
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
				// make the color
				fixed4 col = fixed4(0.0, 0.0, 1.0, 1.0);
				const float r = 0.4;
				const float3 s_light = float3(-1.0 / 1.732, 1.0 / 1.732, 1.0 / 1.732);
				float3 cp = float3(i.uv.x - 0.5, i.uv.y - 0.5, 0.0);
				float zsq = r * r - cp.x * cp.x - cp.y * cp.y;
				if (zsq > 0.0) {
					cp.z = sqrt(zsq);
					float3 norm = cp / r;
					float d_bright = max(dot(norm, s_light), 0.0);
					col.rgb = 0.3 + 0.7 * pow(d_bright, 2.0);
				}
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG
		}
	}
}
