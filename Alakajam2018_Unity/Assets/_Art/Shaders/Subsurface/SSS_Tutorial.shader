Shader "Custom/SSS_Turotial" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _BumpMap ("Normal (Normal)", 2D) = "bump" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _Power ("Subsurface Power", Float) = 1.0
        _Distortion ("Subsurface Distortion", Float) = 0.0
        _Scale ("Subsurface Scale", Float) = 0.5
        _LocalThickness("LocalThickness",2D) = "white"{}
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf StandardTranslucent fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex,_LocalThickness,_BumpMap;

        struct Input {
            float2 uv_MainTex;
            float2 uv_BumpMap;
        };

        half _Glossiness;
        half _Metallic;
        float _Scale, _Power, _Distortion;
        fixed4 _Color;

        #include "UnityPBSLighting.cginc"

    inline fixed4 LightingStandardTranslucent(SurfaceOutputStandard s, fixed3 viewDir, UnityGI gi) {
        // Original colour
        fixed4 pbr = LightingStandard(s, viewDir, gi);
        
        // --- Translucency ---
        float3 L = gi.light.dir;
        float3 V = viewDir;
        float3 N = s.Normal;

        float3 H = normalize(L + N * _Distortion);


        float I = pow(saturate(dot(V, -H)), _Power) * _Scale;


        // Final add
        pbr.rgb = pbr.rgb + gi.light.color * I;
        return pbr;
    }

    void LightingStandardTranslucent_GI(SurfaceOutputStandard s, UnityGIInput data, inout UnityGI gi) {
        LightingStandard_GI(s, data, gi);       
    }

        /*
        //Old stuff
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)
        */

        float thickness;

        void surf (Input IN, inout SurfaceOutputStandard o) {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
            o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));

            thickness = tex2D (_LocalThickness, IN.uv_MainTex).r;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
