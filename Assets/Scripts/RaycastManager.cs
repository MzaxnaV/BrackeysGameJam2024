using UnityEngine;

public class RaycastManager : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private static readonly int DoorlsShy = Animator.StringToHash("doorlsShy");

    private int layerMask;

    private void Awake()
    {
        layerMask = 1 << LayerMask.NameToLayer("Door");
    }

    void Update() {
        RaycastHit hit;
        
        Vector3 forward = transform.TransformDirection(Vector3.forward).normalized;
        
        if (Physics.Raycast(transform.position, forward, out hit, Mathf.Infinity, layerMask)) {
            meshRenderer = hit.collider.gameObject.transform.parent.GetComponent<MeshRenderer>();
            if (meshRenderer != null) 
            {
                meshRenderer.enabled = true;
                Mirrors.Instance.UpdatePlayerCondition(true);
            }
        } else {
            if (meshRenderer != null) {
                meshRenderer.enabled = false;
                Mirrors.Instance.UpdatePlayerCondition(false);
                meshRenderer = null;
            }
        }
    }
}   