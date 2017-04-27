Shader "Toon/Lit Outline DoF" {
	Properties {
		_Color ("Main Color", Color) = (0.5,0.5,0.5,1)
		_OutlineColor ("Outline Color", Color) = (0,0,0,1)
		_Outline ("Outline width", Range (.002, 0.03)) = .005
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Ramp ("Toon Ramp (RGB)", 2D) = "gray" {} 
	}

	SubShader {
		Tags { "RenderType"="Opaque" }

		Pass {
			Lighting Off Fog { Mode Off }
			Cull Front

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma fragmentoption ARB_precision_hint_fastest

			fixed4 _EdgeColor;
			fixed _EdgeWidth;

			struct a2v {
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};

			struct v2f {
				float4 Pos : POSITION;
			};

			v2f vert(a2v v) {
				v2f o;
				o.Pos = mul(UNITY_MATRIX_MVP, v.vertex);
				fixed3 norm = mul((float3x3)UNITY_MATRIX_MV, v.normal);
				norm.x *= UNITY_MATRIX_P[0][0];
				norm.y *= UNITY_MATRIX_P[1][1];
				o.Pos.xy += norm.xy * _EdgeWidth;
				return o;
			}

			half4 frag(v2f i) : COLOR {
				return _EdgeColor;
			}
			ENDCG
		}
		UsePass "Toon/Lit/FORWARD"
		UsePass "Toon/Basic Outline/OUTLINE"

		//Edge detection pass

	} 
	
	Fallback "Toon/Lit"
}
