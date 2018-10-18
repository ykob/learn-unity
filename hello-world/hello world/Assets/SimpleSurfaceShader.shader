Shader "Custom/SimpleSurfaceShader" {
	Properties {
		// オブジェクトの色
		_Color ("Color", Color) = (0.5,0.5,0.5,1)

		// オブジェクトを覆うテクスチャー、デフォルトを白に
		_MainTex ("Albedo (RGB)", 2D) = "white" {}

		// サーフェースの滑らかさを指定
		_Smoothness("Smoothness", Range(0,1)) = 0.5

		// サーフェースの金属度合いを指定
		_Metallic ("Metallic", Range(0,1)) = 0.0

		// リムライトの色
		_RimColor ("Rim Color", Color) = (1.0, 1.0, 1.0, 0.0)

		// リムライトの厚さ
		_RimPower ("Rim Power", Range(0.5, 0.8)) = 2.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		// 物理ベースの標準ライティングモデルを使って、すべてのライトタイプでシャドウを有効にする
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		// 以下のuniform変数は、すべてのピクセルに同じ値が使われる

		// アルベドに使用するテクスチャー
		sampler2D _MainTex;

		fixed4 _Color;

		half _Smoothness;
		half _Metallic;

		float4 _RimColor;
		float _RimPower;

		struct Input {
			float2 uv_MainTex;

			float3 viewDir;
		};

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;

			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Smoothness;
			o.Alpha = c.a;

			half rim =
				1.0 - saturate(dot(normalize(IN.viewDir), o.Normal));

			o.Emission = _RimColor.rgb * pow(rim, _RimPower);
		}
		ENDCG
	}
	FallBack "Diffuse"
}
