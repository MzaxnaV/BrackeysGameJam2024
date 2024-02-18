using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerReset : MonoBehaviour
{
    public Transform resetTransform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.gameObject;
            var controller = player.GetComponent<FirstPersonController>();
            if (controller != null)
            {
                controller.enabled = false;

                Debug.Log("Disabled");
                other.transform.SetPositionAndRotation(resetTransform.position, resetTransform.rotation);
                
                controller.enabled = true;
            }
            else
            {
                Debug.LogWarning("Player must have Character controller");
            }
        }
    }
}
