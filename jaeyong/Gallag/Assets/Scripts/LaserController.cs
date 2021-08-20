using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D[] laser;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject enemy;
    private float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void shoot(int level, GameObject go)
    {
        Vector3 v = go.transform.position;
        if (level == 1)
        {
            Rigidbody2D PrefabInstance = Instantiate(laser[0], go.transform);
            PrefabInstance.velocity = new Vector3(0, 1.5f, 0) * speed;
        }
        if (level == 2)
        {
            Rigidbody2D PrefabInstance = Instantiate(laser[0], go.transform);
            PrefabInstance.transform.position = new Vector3(go.transform.position.x - 0.3f, go.transform.position.y, go.transform.position.z);
            PrefabInstance.velocity = new Vector3(0, 1.8f, 0) * speed;
            PrefabInstance = Instantiate(laser[0], go.transform);
            PrefabInstance.transform.position = new Vector3(go.transform.position.x + 0.3f, go.transform.position.y, go.transform.position.z);
            PrefabInstance.velocity = new Vector3(0, 1.8f, 0) * speed;
        }
        if (level == 3)
        {
            Rigidbody2D PrefabInstance = Instantiate(laser[1], go.transform);
            PrefabInstance.velocity = new Vector3(0, 2f, 0) * speed;
        }
        if (level == 4)
        {
            Rigidbody2D PrefabInstance = Instantiate(laser[1], go.transform);
            PrefabInstance.velocity = new Vector3(0, 2.5f, 0) * speed;
            PrefabInstance.transform.position = new Vector3(go.transform.position.x - 0.3f, go.transform.position.y, go.transform.position.z);
            PrefabInstance = Instantiate(laser[1], go.transform);
            PrefabInstance.velocity = new Vector3(0, 2.5f, 0) * speed;
            PrefabInstance.transform.position = new Vector3(go.transform.position.x + 0.3f, go.transform.position.y, go.transform.position.z);
        }
        if (level == 5)
        {
            Rigidbody2D PrefabInstance = Instantiate(laser[2], go.transform);
            PrefabInstance.velocity = new Vector3(0, 4f, 0) * speed;
        }
        if (level >= 6)
        {
            Rigidbody2D PrefabInstance = Instantiate(laser[2], go.transform);
            PrefabInstance.velocity = new Vector3(0, 3f, 0) * speed;
            PrefabInstance.transform.position = new Vector3(go.transform.position.x - 0.3f, go.transform.position.y, go.transform.position.z);
            PrefabInstance = Instantiate(laser[2], go.transform);
            PrefabInstance.velocity = new Vector3(0, 3f, 0) * speed;
            PrefabInstance.transform.position = new Vector3(go.transform.position.x + 0.3f, go.transform.position.y, go.transform.position.z);
        }
        // if (level == 7)
        // {
        //    Rigidbody2D PrefabInstance = Instantiate(laser[3], go.transform);
        //    PrefabInstance.velocity = new Vector3(0, 3f, 0) * speed;
        // }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
