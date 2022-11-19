using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private Transform carAgent;

    private float yOffset = 5f;
    private float zOffset = -15f;

    // Start is called before the first frame update
    void Start()
    {
        carAgent = GameObject.Find("CarDriver").transform;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(carAgent.position.x, carAgent.position.y + yOffset, carAgent.position.z + zOffset);
        
    }
}
