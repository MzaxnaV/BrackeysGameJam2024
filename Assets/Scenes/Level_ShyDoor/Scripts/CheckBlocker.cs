using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class CheckBlocker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door") && Mirrors.Instance.CheckAllConditions())
        {
            Destroy(other.gameObject);
        }
    }
}
