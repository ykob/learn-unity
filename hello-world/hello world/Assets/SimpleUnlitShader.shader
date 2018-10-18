Shader "Unlit/SimpleUnlitShader"
{
	Properties
	{
		_Color("Color", Color) = (1.0, 0.0, 1.0, 1)
	}
	SubShader
	{
		Tags { "RenderType" = "Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			// このシェーダで利用する関数の定義

			// 頂点シェーダとして利用するvert関数
			#pragma vertex vert

			// フラグメントシェーダとして利用するfrag関数
			#pragma fragment frag

			// Unityの便利なユーティリティのインクルード
			#include "UnityCG.cginc"

			float4 _Color;

			// 頂点シェーダに提供する各頂点の構造体
			struct appdata
			{
				// ワールド空間における頂点の位置
				float4 vertex : POSITION;
			};

			// フラグメントシェーダに提供する各フラグメントの構造体
			struct v2f
			{
				// スクリーン空間におけるフラグメントの位置
				float4 vertex : SV_POSITION;
			};
			
			// 与えられた頂点を変換
			v2f vert (appdata v)
			{
				v2f o;

				// Unity(UnityCG.cginc)が提供する行列と乗算することでワールド空間からビュー空間に頂点を変換する
				o.vertex = UnityObjectToClipPos(v.vertex);
				
				return o;
			}
			
			// 隣接した頂点の補間情報が与えられ、最終的な色を返す
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col;

				col = _Color;

				col *= abs(_SinTime[3]);

				return col;
			}
			ENDCG
		}
	}
}
