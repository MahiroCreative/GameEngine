Shader "Unlit/RenderShader3_1"
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
				//球の半径
				const float r = 0.4;
				//s_lightの作成(光源の方向を向いた単位ベクトル)
				const float3 s_light = float3(-1.0 / 1.732, 1.0 / 1.732, 1.0 / 1.732);
				//cpの作成(レンダリングの中心)
				float3 cp = float3(i.uv.x - 0.5, i.uv.y - 0.5, 0.0);
				//zsqの作成(z^2)
				//x^2+y^2+z^2=r^2　から求めて以下になる。
				float zsq = r * r - cp.x * cp.x - cp.y * cp.y;
				//レンダリング条件
				if (zsq > 0.0) {
					//正面から見た場合のみを考えるので、
					//ｚが＋のときだけ考える。
					//なので、条件分けせず、普通にルートをとる
					cp.z = sqrt(zsq);
					//normは、円の中心から描画したい点までのベクトル(cp)を単位ベクトルにしたもの
					//つまり、描画したい点の法線ベクトル
					float3 norm = cp / r;
					//明るさの作成
					//描画したい点の法線ベクトルと、光源へのベクトルの内積(dot(norm,s_light))
					//結果が0.0よりも小さくならないようにmaxしている。
					//(maxは二つの値を見て、大きいほうをとる関数)
					float d_bright = max(dot(norm, s_light), 0.0);
					//レンダリング
					//ランバート反射式で計算
					col.rgb = 0.3 + 0.7 * pow(d_bright,2.0);
				}
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG
		}
	}
}
