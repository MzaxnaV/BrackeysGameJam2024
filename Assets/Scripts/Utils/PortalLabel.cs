using Portals;
using UnityEditor;
using UnityEngine;

namespace Utils
{
    // [CustomEditor(typeof(Portal))]
    // public class PortalSelection : Editor
    // {
    //     private static GUIStyle _labelStyle;
    //     private static readonly Vector3 Offset = new (0f, 4f, 0f);
    //
    //     private void OnEnable()
    //     {
    //         _labelStyle = new GUIStyle
    //         {
    //             normal =
    //             {
    //                 textColor = Color.black
    //             },
    //             alignment = TextAnchor.MiddleCenter
    //         };
    //     }
    //
    //     private void OnSceneGUI()
    //     {
    //         var portal = (Portal)target;
    //         
    //         Handles.BeginGUI();
    //         Handles.Label(portal.transform.position + Offset, portal.info.GetEditorText(), _labelStyle);
    //         Handles.EndGUI();
    //     }
    // }
}
