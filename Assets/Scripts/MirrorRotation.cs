using System;
using UnityEngine;

[RequireComponent((typeof(BoxCollider)))]
public class MirrorRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 75f;

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
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.blue);
        if (Physics.Raycast(transform.position, forward, out hit, Mathf.Infinity)) {
            if (hit.collider.CompareTag("Door")) {
                Debug.Log("Mirror looks at shy door!");
            }
        } else
        {
            Debug.Log("Mirror looks away from shy door!");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            RotateMirror();
        }
    }

    void RotateMirror()
    {
        var rot = transform.rotation;

        Quaternion rotationDelta = Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
        rot *= rotationDelta;
        transform.rotation = rot;
    }
}
