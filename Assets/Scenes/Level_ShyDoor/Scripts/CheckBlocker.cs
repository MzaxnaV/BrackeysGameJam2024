using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class CheckBlocker : MonoBehaviour
{
    private Vector3 openDoorPos = new (4.000000476837158f, 2.585200786590576f, -106.0f);
    private Quaternion openDoorRot = new (0.014146775007247925f, -0.773522138595581f, -0.5958209037780762f, 0.21554803848266602f);
    
    [Header("closedDoor")]
    [SerializeField] private Vector3 closedDoorPos = new (-0.19134420156478883f, 2.585200786590576f, -107.30628967285156f);
    [SerializeField] private Quaternion closedDoorRot = new (-0.5378775000572205f, 0.5419062376022339f, 0.25669413805007937f, 0.5925654172897339f);
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door") && Mirrors.Instance.CheckAllConditions())
        {
            var doorFrame = other.transform.parent.parent.GetChild(2);
            doorFrame.position = openDoorPos;
            doorFrame.rotation = openDoorRot;
            Destroy(other.gameObject);
        }
    }
}