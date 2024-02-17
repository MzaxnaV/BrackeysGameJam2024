using UnityEngine;

public class RemoveMeshRenderer : MonoBehaviour
{
    [SerializeField] private bool remove = true;

    private void Awake()
    {
        if (remove)
        {
            Destroy(GetComponent<Mesh>());
            Destroy(GetComponent<MeshRenderer>());
        }
    }
}
