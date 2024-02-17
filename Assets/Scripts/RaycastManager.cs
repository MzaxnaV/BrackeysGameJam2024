using UnityEngine;

public class RaycastManager : MonoBehaviour
{
    void Update() {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
        
        // Infinity Raycast
        if (Physics.Raycast(transform.position, forward, out hit, Mathf.Infinity)) {
            if (hit.collider.CompareTag("Door")) {
                // Debug.Log("Shy door closed!");
            }
            else
            {
                // Debug.Log("Shy door opens!");
            }
        }
    }
}   