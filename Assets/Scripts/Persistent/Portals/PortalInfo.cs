using UnityEngine;

namespace Portals
{
    [CreateAssetMenu(fileName = "PortalInfoData", menuName = "Portals/PortalInfoData", order = 1)]
    public class PortalInfo : ScriptableObject
    {
        [Header("Portal")]
        public PortalTag source;
        public PortalTag destination;

        [Header("Skybox")]
        public Color tint;
        public Color ground;
        public string GetEditorText() => source + " --> " + destination;

    }

    public enum PortalTag
    {
        None,
        Entry,
        LevelMain,
        LevelHeight,
        LevelMirror,
        LevelImpatient,
        LevelLight
    }
}