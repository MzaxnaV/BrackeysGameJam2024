using Portals;
using UnityEngine;

namespace Utils
{
    public class SetupAfterLoad : MonoBehaviour
    {
        [Header("Loading Scene")]
        [SerializeField] private Portal thisPortal;

        [Header("Cleanup")] [SerializeField] private GameObject[] objects;

        private void Awake()
        {
            if (thisPortal == null)
            {
                Debug.LogError("SET THIS PORTAL!!");
            }
        }

        private void OnEnable()
        {
            Debug.Assert(thisPortal != null);

            var transitionManager = TransitionSceneManager.Instance;

            transitionManager.portalTo = thisPortal;
            transitionManager.Transition(true);

            foreach (var o in objects)
            {
                Destroy(o);
            }
        }
    }
}
