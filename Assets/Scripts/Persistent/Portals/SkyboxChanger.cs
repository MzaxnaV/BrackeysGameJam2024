using Portals.Utility;
using UnityEngine;

public class SkyboxChanger : MonoBehaviourSingleton<SkyboxChanger>
{
    [SerializeField] private Material skybox; // Skybox/CubeMap
    private static readonly int TintColor = Shader.PropertyToID("_Tint");

    public void ChangeColour(Color colour)
    {
        if (skybox != null)
        {
            Debug.Log("Changing Skybox Colour");
            skybox.SetColor(TintColor, colour);
            DynamicGI.UpdateEnvironment(); // Update global illumination to reflect the new skybox color
        }
        else
        {
            Debug.LogError("Skybox material is null. Cannot change colour.");
        }
    }
}
