using UnityEngine;

public class RaycastManager : MonoBehaviour
{
    void Update() {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);

        if (Physics.Raycast(transform.position, forward, out hit)) {
            if (hit.collider.CompareTag("Mirror")) {
                Debug.Log("Looking at mirror");
                // Calculate reflection
                Vector3 reflectDir = Vector3.Reflect(forward, hit.normal);
                Debug.DrawRay(hit.point, reflectDir, Color.blue);
                // Cast another ray in the reflected direction
            } else if (!hit.collider.CompareTag("Door")) {
                // Door is not being looked at directly
                Debug.Log("Looking at door");
            }
        }
    }
}
