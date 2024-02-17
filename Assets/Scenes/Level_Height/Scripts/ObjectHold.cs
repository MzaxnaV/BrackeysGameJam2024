using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHold : MonoBehaviour
{
    public GameObject pickObject;
    public Camera mCamera;
    public float range = 3f;
    public float go = 100f;
    public Transform playerTransform;
    public LayerMask pickupLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartPickUp();
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            Drop();
        }
    }

    void StartPickUp()
    {
        RaycastHit hit;
        if(Physics.Raycast(mCamera.transform.position,mCamera.transform.forward,out hit, range,pickupLayer))
        {
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.CompareTag("ItemWithWeight"))
            {
                pickObject = hit.collider.gameObject;
                if (pickObject != null)
                {
                    PickUp();
                }
                
                
            }
            
        }
    }

    void PickUp()
    {
        if (pickObject != null)
        {
            pickObject.transform.SetParent(playerTransform);
            pickObject.GetComponent<Rigidbody>().isKinematic = true;
        }
       
    }
    void Drop()
    {
        playerTransform.DetachChildren();
        pickObject.GetComponent<Rigidbody>().isKinematic = false;
    }
}
