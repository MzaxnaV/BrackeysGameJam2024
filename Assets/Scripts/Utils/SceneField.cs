using System;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Utils
{
    [Serializable]
    public class SceneField
    {
        [SerializeField] private Object sceneAsset;

        [SerializeField] private string sceneName;

        public string SceneName => sceneName;

        public static implicit operator string(SceneField sceneField)
        {
            return sceneField.SceneName;
        }
    
#if UNITY_EDITOR
        [CustomPropertyDrawer(typeof(SceneField))]
        public class SceneFieldPropertyDrawer : PropertyDrawer
        {
            public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
            {
                EditorGUI.BeginProperty(position, GUIContent.none, property);
                var asset = property.FindPropertyRelative("sceneAsset");
                var name = property.FindPropertyRelative("sceneName");
                position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

                if (asset != null)
                {
                    asset.objectReferenceValue = EditorGUI.ObjectField(position, asset.objectReferenceValue,
                        typeof(SceneAsset), false);

                    if (asset.objectReferenceValue != null)
                    {
                        name.stringValue = (asset.objectReferenceValue as SceneAsset)!.name;
                    }
                }
                
                EditorGUI.EndProperty();
            }
        }
#endif
    }
}
