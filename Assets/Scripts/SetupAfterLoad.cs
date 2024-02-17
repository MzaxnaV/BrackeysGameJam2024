using Portals;
using UnityEngine;

public class SetupAfterLoad : MonoBehaviour
{
    [Header("Loading Scene")]
    [SerializeField] private Portal entryPortal;
        
    [Header("Cleanup")] 
    [SerializeField] private GameObject[] objects;

    [SerializeField] private bool destroySelf;

    [SerializeField] private bool goBack = false;
        
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
        if (!destroySelf)
        {
            var transitionManager = TransitionSceneManager.Instance;

            transitionManager.portalTo = entryPortal;
            transitionManager.Transition(goBack);

            foreach (var o in objects)
            {
                Destroy(o);
            }
                
            gameObject.SetActive(false);
        }
    }
}