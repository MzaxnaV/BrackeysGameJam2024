using System;
using Portals;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

[RequireComponent(typeof(BoxCollider))]
public class LoadSceneTrigger : MonoBehaviour
{
    [Header("Loading Scene")]
    [SerializeField] private SceneField sceneToLoad;
    public Portal portalExit;
    
    [Header("Cleanup")]
    [SerializeField] private SceneField[] sceneToUnload;
    [SerializeField] private GameObject blockerObject;

    private bool loadOnce = true;

    private void OnTriggerEnter(Collider other)
    {
        if (sceneToLoad != null && loadOnce && other.CompareTag("Player") )
        {
            loadOnce = false;
            TransitionSceneManager.Instance.portalFrom = portalExit;
            SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);
            if (blockerObject != null)
            {
                blockerObject.SetActive(true);
            }

            foreach (var scene in sceneToUnload)
            {
                Debug.Log("Unloading: " + scene);
                SceneManager.UnloadSceneAsync(scene);
            }
            
            Destroy(gameObject);
        }
    }
}
