#ifndef CUSTOM_LIGHTING_ALL_INCLUDED
#define CUSTOM_LIGHTING_ALL_INCLUDED

void CalculateMainLight_float(float3 WorldPos, float3 Normal, out float3 Direction, out float3 Color){
    #if SHADERGRAPH_PREVIEW
    Direction = float3(0.5, 0.5, 0);
    Color = 1;
    #else
    //float4 sCoord = TransformWorldToShadowCoord(WorldPos);
    
    //Light mainLight = GetMainLight(0);
    //Direction = mainLight.direction;
    //Color = mainLight.color;
    Direction = float3(0, 0, 0);
    Color = float3(0, 0, 0);

    int additionalLightsCount = _AdditionalLightsCount;

    for (int i = 0; i < additionalLightsCount; i++)
    {
        Light additionalLight = GetAdditionalLight(i, WorldPos);

        // Calculate lighting contribution
        float NdotL = dot(Normal, additionalLight.direction);
        if (NdotL > 0)
        {
            // Use the light's intensity to infer an attenuation
            float intensity = length(additionalLight.color);
            float falloff = 1.0 / max(intensity, 1e-4); // avoid divide by zero
            
            Color += additionalLight.color * NdotL * falloff;
            Direction += additionalLight.direction * NdotL * falloff;
        }
    }

    // Normalize Direction
    Direction = normalize(Direction);
#endif
}

#endif