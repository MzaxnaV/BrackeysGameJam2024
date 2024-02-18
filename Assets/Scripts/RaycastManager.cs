using System;
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
        
        // TODO: the issue we have is that forward vector rapidly changes it's values, can you
        // smooth this over a few frames (1-2 seconds) so it remains stable
        Vector3 forward = transform.TransformDirection(Vector3.forward).normalized;
        
        Debug.DrawRay(transform.position, forward, Color.green);
        
        if (Physics.Raycast(transform.position, forward, out hit, Mathf.Infinity, layerMask)) {
            meshRenderer = hit.collider.gameObject.transform.parent.GetComponent<MeshRenderer>();
            if (meshRenderer != null) {
                meshRenderer.enabled = true;
            }
        } else {
            if (meshRenderer != null) {
                Debug.Log("Disable MeshRenderer, change this!!!");
                meshRenderer.enabled = false;
                meshRenderer = null;
            }
        }
    }
}   