Shader "Unlit/RenderShader3_3"
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
				//ベース色
				fixed4 col = fixed4(0.0, 0.0, 1.0, 1.0);
				// 円周率
				const float PI = 3.14159;
				//半径
				const float r = 0.4;
				//光源に向かう単位ベクトル
				const float3 s_light = float3(-1.0 / 1.732, 1.0 / 1.732, 1.0 / 1.732);
				//レンダリング位置のベクトル(初期値は中央)
				float3 cp = float3(i.uv.x - 0.5, i.uv.y - 0.5, 0.0);
				//z^2
				float zsq = r * r - cp.x * cp.x - cp.y * cp.y;

				if (zsq > 0.0) {
					//z座標(正面から見たときのみ)
					cp.z = sqrt(zsq);
					//描画位置の法線ベクトル
					float3 norm = cp / r;
					//ディレクショナルライト
					float d_bright = max(dot(norm, s_light), 0.0);
					//最終的な明るさ
					float fBright = 0.3 + 0.7 * d_bright * d_bright;
					//アークタンジェントで現在の角度を出している
					//角度(xy平面に対する角度)
					float fAngle = atan2(cp.z, cp.x);
					//マイナスの角度をプラスに変換
					if (fAngle < 0.0f) fAngle += 2.0 * PI;

					//何らかの計算
					if ((int)(fAngle / (2.0 * PI) * 16) & 1) {
						col.rgb = float3(fBright, fBright, fBright);
					}
					else {
						//col.rgb = float3(fBright, 0.0, fBright);
//						col.rgb = float3(fBright, 0.0, 0.0);
						col.rgb = float3(0.0, fBright, fBright);
					}
				}
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG
		}
	}
}
