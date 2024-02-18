using System;
using UnityEngine;

public class DivaPivot : MonoBehaviour
{
    private Vector3 closedPos;
    private Quaternion closedRot;
    
    private Vector3 openPos = new (-996.176025390625f, 3.390000104904175f, -4.791999816894531f);
    private Quaternion openRot = new (0, -0.3675742447376251f, 0, -0.9299942255020142f);

    [Header("Exit condition")] 
    [SerializeField] private Mirror leftLamp;
    [SerializeField] private Mirror rightLamp;

    private void Start()
    {
        closedPos = transform.position;
        closedRot = transform.rotation;
    }

    private void Update()
    {
        if (leftLamp.senseDoor && rightLamp.senseDoor)
        {
            transform.position = openPos;
            transform.rotation = openRot;
        }
        else
        {
            transform.position = closedPos;
            transform.rotation = closedRot;
        }
    }
}
