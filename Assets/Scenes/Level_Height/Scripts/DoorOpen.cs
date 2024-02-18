using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    private float initialX;
    private float targetX;
    float movingX;
    public TriggerOfWeight weightScript;
    public GameObject weightTrigger;
    // Start is called before the first frame update
    void Start()
    {
        weightScript = weightTrigger.GetComponent<TriggerOfWeight>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (weightScript.currentWeight > 84)
        {
            OpenTheDoor();
        }
        
    }

    void OpenTheDoor()
    {
        Debug.Log("open");
        Destroy(gameObject);
    }
}
