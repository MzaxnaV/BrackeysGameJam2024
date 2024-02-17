using UnityEngine;

namespace Portals
{
    [CreateAssetMenu(fileName = "PortalInfoData", menuName = "Portals/PortalInfoData", order = 1)]
    public class PortalInfo : ScriptableObject
    {
        public PortalTag source;
        public PortalTag destination;
        
        public string GetEditorText() => source + " --> " + destination;

    }

    public enum PortalTag
    {
        None,
        Entry,
        LevelMain,
        LevelHeight,
        LevelMirror,
        LevelLight
    }
}