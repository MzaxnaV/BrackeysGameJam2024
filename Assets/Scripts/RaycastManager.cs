using UnityEngine;

public class RaycastManager : MonoBehaviour
{
    private Animation anim;
    private int layerMask;
    private bool toggle = true;

    [Header("Pickup")] 
    [SerializeField] private GameObject pickUp;
    [SerializeField] private Transform holder;
    [SerializeField] private LayerMask pickUpLayer;
    [SerializeField] private float range = 3f;

    private bool isPickedUp;

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
        
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (!isPickedUp)
            {
                if (Physics.Raycast(transform.position, forward, out hit, range, pickUpLayer))
                {
                    if (hit.collider.CompareTag("ItemWithWeight"))
                    {
                        pickUp = hit.collider.gameObject;
                        if (pickUp)
                        {
                            pickUp.transform.SetParent(holder);
                            pickUp.GetComponent<Rigidbody>().isKinematic = true;
                            isPickedUp = true; // Update flag
                        }
                    }
                }
            }
            else
            {
                if (pickUp != null)
                {
                    pickUp.transform.SetParent(null);
                    pickUp.GetComponent<Rigidbody>().isKinematic = false;
                    isPickedUp = false;
                    pickUp = null; 
                }
            }
        }
    }
}