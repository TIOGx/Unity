using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Transform playertr;
    Vector3 offset;
    private void Awake()
    {
        playertr = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - playertr.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = playertr.position + offset;
    }
}
