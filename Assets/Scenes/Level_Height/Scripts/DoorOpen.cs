using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    private float initialX;
    private float targetX;
    float movingX;
    // Start is called before the first frame update
    void Start()
    {
        initialX = transform.position.x;
        targetX = initialX;
    }

    // Update is called once per frame
    void Update()
    {
        movingX = Mathf.Lerp(initialX, targetX, 1f * Time.deltaTime);
        transform.position = new Vector3(movingX, transform.position.y, transform.position.z);
    }

    void OpenTheDoor()
    {
        targetX = -1;
    }
}
