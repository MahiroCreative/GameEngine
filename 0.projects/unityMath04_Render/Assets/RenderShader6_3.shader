Shader "Unlit/RenderShader6_3"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_DeltaTex ("Texture", 2D) = "white" {}
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
			sampler2D _DeltaTex;
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
				float fAngle = 2.0f * 3.1416 * _Time.w / 30.0f;
				float2 CenOrg = float2(i.uv.x - 0.5f, i.uv.y - 0.5f) * 0.8f;
				float2 RotSamp = float2(CenOrg.x * cos(fAngle) - CenOrg.y * sin(fAngle),
										CenOrg.x * sin(fAngle) + CenOrg.y * cos(fAngle));
				RotSamp += float2(0.5f, 0.5f);
				float4 DeltaTex = tex2D(_DeltaTex, RotSamp) - float4(0.5f, 0.5f, 0.0f, 0.0f);
				DeltaTex = float4(DeltaTex.x * cos(fAngle) - DeltaTex.y * sin(fAngle),
								  DeltaTex.x * sin(fAngle) + DeltaTex.y * cos(fAngle),
								  DeltaTex.z, DeltaTex.w);
				float2 samp = i.uv + 0.2f * float2(DeltaTex.x, DeltaTex.y);
				// sample the texture
				fixed4 col = ( 0.3f * DeltaTex.z + 0.7f ) * tex2D(_MainTex, samp);
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG
		}
	}
}
