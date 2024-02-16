using Portals;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

[RequireComponent(typeof(BoxCollider))]
public class LoadSceneTrigger : MonoBehaviour
{
    [Header("Loading Scene")]
    [SerializeField] private SceneField sceneToLoad;
    [SerializeField] private Portal thisPortal;
    
    [Header("Unload")]
    [SerializeField] private SceneField[] sceneToUnload;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TransitionSceneManager.Instance.portalFrom = thisPortal;
            SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);
            Destroy(gameObject);
        }
    }
}
