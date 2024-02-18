using UnityEngine;

public class RaycastManager : MonoBehaviour
{
    private Animation anim;
    private int layerMask;
    private bool toggle = true;

    private void Awake()
    {
        layerMask = 1 << LayerMask.NameToLayer("Door");
    }

    void Update() {
        RaycastHit hit;
        
        Vector3 forward = transform.TransformDirection(Vector3.forward).normalized;
        
        if (Physics.Raycast(transform.position, forward, out hit, Mathf.Infinity, layerMask)) {
            anim = hit.collider.gameObject.transform.parent.GetComponent<Animation>();
            if (anim != null && toggle) 
            {
                anim.Play();
                toggle = false;
                Mirrors.Instance.UpdatePlayerCondition(true);
            }
        } else {
            if (anim != null && !toggle) {
                toggle = true;
                Mirrors.Instance.UpdatePlayerCondition(false);
                anim = null;
            }
        }
    }
}   