Shader "Custom/Bola"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Color2 ("Color2", Color) = (1,1,1,1)
        _Emission("Emission", Color) = (0,0,0,0)
    }
    SubShader
    {   
        Pass {
            ZTest LEqual
            Material {
                Diffuse[_Color]
                Ambient(1,1,1)
                Shininess 1
                Specular (1,1,1,0)
                Emission[_Emission]
            }
            Lighting On
            SeparateSpecular On
            SetTexture[_MainTex]{
                combine texture * previous
            }
        }
        Pass {
            ZTest Greater
            Color[_Color2]
        }
    }
    FallBack "Diffuse"
}