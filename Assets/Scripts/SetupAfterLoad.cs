using Portals;
using UnityEngine;

namespace Utils
{
    public class SetupAfterLoad : MonoBehaviour
    {
        [Header("Loading Scene")]
        [SerializeField] private Portal entryPortal;
        
        [Header("Cleanup")] 
        [SerializeField] private GameObject[] objects;

        [SerializeField] private bool destroySelf;
        
        private void Start()
        {
            if (!destroySelf && entryPortal == null)
            {
                Debug.LogError("SET THIS PORTAL!!");
            } else if (destroySelf)
            {
                Destroy(gameObject);
            }
        }

        private void OnEnable()
        {
            var transitionManager = TransitionSceneManager.Instance;

            transitionManager.portalTo = entryPortal;
            transitionManager.Transition(true);

            foreach (var o in objects)
            {
                Destroy(o);
            }
            
            gameObject.SetActive(false);
        }
    }
}
