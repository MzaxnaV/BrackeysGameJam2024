using Portals;
using UnityEngine;

namespace Utils
{
    public class SetupAfterLoad : MonoBehaviour
    {
        [Header("Loading Scene")]
        [SerializeField] private Portal thisPortal;

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
        }
    }
}
