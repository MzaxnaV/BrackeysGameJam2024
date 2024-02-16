using Portals;
using UnityEngine;

namespace Utils
{
    public class SetupAfterLoad : MonoBehaviour
    {
        [Header("Loading Scene")]
        [SerializeField] private Portal entryPortal;

        [Header("Cleanup")] [SerializeField] private GameObject[] objects;

        private void Awake()
        {
            if (entryPortal == null)
            {
                Debug.LogError("SET THIS PORTAL!!");
            }
        }

        private void OnEnable()
        {
            Debug.Assert(entryPortal != null);

            var transitionManager = TransitionSceneManager.Instance;

            transitionManager.portalTo = entryPortal;
            transitionManager.Transition(true);

            foreach (var o in objects)
            {
                Destroy(o);
            }
        }
    }
}
