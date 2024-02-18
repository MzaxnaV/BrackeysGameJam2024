using UnityEngine;

public class PlayerReset : MonoBehaviour
{
    public Transform resetTransform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            var player = other.gameObject;
            var controller = player.GetComponent<CharacterController>();
            if (controller != null)
            {
                controller.enabled = false;

                transform.SetPositionAndRotation(resetTransform.position, resetTransform.rotation);

                controller.enabled = true;
            }
            else
            {
                Debug.LogWarning("Player must have Character controller");
            }
        }
    }
}
