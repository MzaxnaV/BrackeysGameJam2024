using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

[RequireComponent(typeof(BoxCollider))]
public class LoadSceneTrigger : MonoBehaviour
{
    [SerializeField] private SceneField[] scenesToLoad;
    [SerializeField] private SceneField[] sceneToUnload;

    private bool loaded = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!loaded && other.CompareTag("Player"))
        {
            Debug.Log("Loading Scenes");
            foreach (var scene in scenesToLoad)
            {
                SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
            }
            
            loaded = true;
        }
    }
}
