using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOfWeight : MonoBehaviour
{
    public GameObject triggerPlatform;
    public float currentWeight;
    public float targetWeight;
    // Start is called before the first frame update
    void Start()
    {
        currentWeight = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentWeight = Mathf.Lerp(currentWeight, targetWeight, 1f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ItemWithWeight"))
        {
            targetWeight += 20;
        }
        if (other.CompareTag("Player"))
        {
            targetWeight += 25;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ItemWithWeight"))
        {
            targetWeight -= 20;
        }
        if (other.CompareTag("Player"))
        {
            targetWeight -= 25;
        }
    }
}
