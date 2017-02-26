Shader "Snake 3D/Planet" {
	Properties {
		[NoScaleOffset]
		_HeightCubemap ("Height Cubemap", Cube) = "white" {}
		_AlbedoColor ("Albedo Color", Color) = (1, 1, 1, 1)
	}

	SubShader {
		Tags {
			"RenderType" = "Opaque"
		}

		CGPROGRAM
		#pragma surface surf Lambert vertex:vert
		
		struct Input {
			float4 color : COLOR;
			half3 position;
		};

		void vert (inout appdata_full v, out Input o) {
			UNITY_INITIALIZE_OUTPUT(Input,o);
			o.position = v.vertex.xyz;
		}

		samplerCUBE _HeightCubemap;
		float4 _AlbedoColor;

		void surf (Input IN, inout SurfaceOutput o) {
			o.Albedo = _AlbedoColor.rgb * texCUBE(_HeightCubemap, IN.position).rgb;
		}
		ENDCG
	}
	Fallback "Diffuse"
}
