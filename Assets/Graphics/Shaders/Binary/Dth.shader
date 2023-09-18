Shader "Unlit/Dth"
{
    Properties
    {
        _MainTex("", 2D) = "white" {}
        _DitherTex("", 2D) = "white" {}
        _Color0("", Color) = (0, 0, 0)
        _Color1("", Color) = (1, 1, 1)
        _Color2("", Color) = (1, 1, 1) 
        [Gamma] _Opacity("", Range(0, 1)) = 1
    }
       
    CGINCLUDE

    #include "UnityCG.cginc"

    sampler2D _MainTex;
    float2 _MainTex_TexelSize;

    sampler2D _DitherTex;
    float2 _DitherTex_TexelSize;

    half _Scale;
    half3 _Color0;
    half3 _Color1;
    half3 _Color2;
    half _Opacity;

    struct appdata
    {
        float4 vertex : POSITION;
        float2 uv : TEXCOORD0;
    };

    struct v2f
    {
        float4 position : SV_POSITION;
        float2 uv : TEXCOORD0;
        float4 screenPosition : TEXCOORD1;
    };

    v2f Vert(appdata v)
    {
        v2f o;
        o.position = UnityObjectToClipPos(v.vertex);
        o.uv = v.uv;
        o.screenPosition = ComputeScreenPos(o.position);
        return o;
    }

    half4 frag(v2f i) : SV_Target
    {
        half4 source = tex2D(_MainTex, i.uv);

        // Dither pattern sample
        float2 dither_uv = i.uv * _DitherTex_TexelSize;
        dither_uv /= _MainTex_TexelSize * _Scale;
        half dither = tex2D(_DitherTex, dither_uv).a + 0.5 / 256;

        // Relative luminance in linear RGB space
    #ifdef UNITY_COLORSPACE_GAMMA
        half rlum = LinearRgbToLuminance(GammaToLinearSpace(saturate(source.rgb)));
    #else
        half rlum = LinearRgbToLuminance(source.rgb);
    #endif

    half3 rgb;
    if(rlum < dither) rgb = _Color0;
    else if (rlum < dither + 0.2) rgb = _Color1;
    else rgb = _Color2;


        // Blending
        //half3 rgb = rlum < dither ? _Color0 : _Color1;
        return half4(lerp(source.rgb, rgb, _Opacity), source.a);
    }

    ENDCG

    SubShader
    {
        Cull Off ZWrite Off ZTest Always
        Tags { "RenderPipeline" = "UniversalPipeline"}
        Pass
        {
            CGPROGRAM
                #pragma multi_compile _ UNITY_COLORSPACE_GAMMA
                #pragma vertex Vert
                #pragma fragment frag
            ENDCG
        }
    }
}
