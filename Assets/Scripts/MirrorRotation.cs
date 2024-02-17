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

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Inside trigger");

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
