using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObstacles : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform instantiatePoint;
    public float speed = 5f;
    public float minX = -5.0f; 
    public float maxX = 5.0f;  
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreatePrefab", 0f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (transform.position.x <= minX || transform.position.x >= maxX)
        {
            speed *= -1;
        }
    }

    void CreatePrefab()
    {
        Instantiate(obstaclePrefab, instantiatePoint.position, instantiatePoint.rotation);
    }
}
