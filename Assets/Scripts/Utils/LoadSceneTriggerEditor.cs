using UnityEditor;
using UnityEngine;

namespace Utils
{
    [CustomEditor(typeof(LoadSceneTrigger))]
    public class LoadSceneTriggerEditor : Editor
    {
        void OnSceneGUI()
        {
            var trigger = (LoadSceneTrigger)target;

            if (trigger.portalExit != null)
            {
                Handles.color = Color.black; // Set the color of the line

                Handles.DrawDottedLine(trigger.transform.position, trigger.portalExit.transform.position, 5f);
            }
        }
    }
}