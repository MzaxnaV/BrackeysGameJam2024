using System;
using UnityEngine;

[RequireComponent((typeof(BoxCollider)))]
public class Mirror : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField] private float rotationSpeed = 75f;

    [Header("Detection")] 
    [SerializeField] private float distance = 10f;

    private bool sensePlayer;
    public bool senseDoor;
    
    private void Awake()
    {
        var boxCollider = GetComponent<BoxCollider>();
        if (!boxCollider.isTrigger)
        {
            Debug.LogError("Set " + gameObject.name + "'s collider to Trigger!");
        }
    }

    private void Update()
    {
        RaycastHit hit;
        var forward = transform.TransformDirection(Vector3.forward) * distance;
        Debug.DrawRay(transform.position, forward, Color.blue);
        
        if (Physics.Raycast(transform.position, forward, out hit)) {
            if (hit.collider.CompareTag("Door"))
            {
                senseDoor = true;
            }
        } else
        {
            senseDoor = false;
        }

        if (sensePlayer && Input.GetKey(KeyCode.E))
        {
            RotateMirror();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sensePlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sensePlayer = false;
        }
    }
    void RotateMirror()
    {
        var rot = transform.rotation;

        var rotationDelta = Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
        rot *= rotationDelta;
        transform.rotation = rot;
    }
}
