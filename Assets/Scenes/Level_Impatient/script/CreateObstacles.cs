using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObstacles : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform instantiatePoint;
    public float randomPosX;  
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreatePrefab", 0f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreatePrefab()
    {
        randomPosX = Random.Range(instantiatePoint.position.x - 10, instantiatePoint.position.x + 10);
        Instantiate(obstaclePrefab, new Vector3(randomPosX,instantiatePoint.position.y,instantiatePoint.position.z), instantiatePoint.rotation);
        Debug.Log(new Vector3(randomPosX, instantiatePoint.position.y, instantiatePoint.position.z));
    }
}
