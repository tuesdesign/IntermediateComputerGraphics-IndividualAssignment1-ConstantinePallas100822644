Shader "Custom/Specular"
{
    Properties
    {
        _Color("Color", Color) = (1,1,1,1)
        _SpecColor("Color", Color) = (1.0,1.0,1.0,1.0)
        _Shininess("Shininess", Float) = 10
    }
        SubShader
    {
        Pass
        {
            Tags{"LightMode" = "ForwardBase"}

            CGPROGRAM
        #pragma vertex vert
        #pragma fragment frag
         uniform float4 Color;
         uniform float4 SpecColor;
         uniform float Shininess;

         uniform float4 LightColor0;

         struct vertexInput
         {
             float4 vertex : POSITION;
             float3 normal : NORMAL;
         };

         struct vertexOutput
         {
             float4 pos : SV_POSITION;
             float4 posWorld : TEXCOORD0;
             float4 normalDir : TEXCOORD1;
         };

         vertexOutput vert(vertexInput v)
         {
             vertexOutput o;
             o.posWorld = mul(unity_ObjectToWorld, v.vertex);
             o.normalDir = normalize(mul(float4(v.normal, 0.0), unity_WorldToObject));
             o.pos = UnityObjectToClipPos(v.vertex);
             return o;
         }

         float4 frag(vertexOutput i) : COLOR
         {
             float3 normalDirection = i.normalDir;
             float atten = 0;

             float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
             float3 diffuseReflection = atten * LightColor0.xyz * max(0.0, dot(normalDirection, lightDirection));
             float3 lightReflectionDirection = reflect(-lightDirection, normalDirection);
             float3 viewDirection = normalize(float3(float4(_WorldSpaceCameraPos.xyz, 1.0) - i.posWorld.xyz));
             float3 lightSeeDirecton = max(0.0, dot(lightReflectionDirection, viewDirection));
             float3 shininessPower = pow(lightSeeDirecton, Shininess);
             float3 specularReflection = atten * SpecColor.rgb * shininessPower;
             float3 lightFinal = diffuseReflection + specularReflection + UNITY_LIGHTMODEL_AMBIENT;
             return float4(lightFinal * Color.rgb, 1.0);
         }

            ENDCG
        }
    }
        //FallBack "Diffuse"
}
