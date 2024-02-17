using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Height : MonoBehaviour
{
    public float heightChange;
    private Vector3 initialHeight;
    // Start is called before the first frame update
    void Start()
    {
        heightChange = 0;
        initialHeight = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(initialHeight.x, initialHeight.y + heightChange, initialHeight.z);
    }
}
