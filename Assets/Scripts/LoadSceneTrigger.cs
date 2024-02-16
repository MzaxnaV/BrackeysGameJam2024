using Portals;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

[RequireComponent(typeof(BoxCollider))]
public class LoadSceneTrigger : MonoBehaviour
{
    [Header("Loading Scene")]
    [SerializeField] private SceneField sceneToLoad;
    [SerializeField] private Portal portalExit;
    
    [Header("Unload")]
    [SerializeField] private SceneField[] sceneToUnload;

    private bool loadOnce = true;

    private void OnTriggerEnter(Collider other)
    {
        if (sceneToLoad != null && loadOnce && other.CompareTag("Player") )
        {
            // check if scene to be loaded isn't this
            Debug.Log("Loading scene: " + sceneToLoad);
            loadOnce = false;
            TransitionSceneManager.Instance.portalFrom = portalExit;
            SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);
            Destroy(gameObject);
        }
    }
}
