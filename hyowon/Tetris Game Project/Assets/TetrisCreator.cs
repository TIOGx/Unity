using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisCreator : MonoBehaviour
{
    public GameObject [] obj;
    public void CreatBlock()
    {
        Instantiate(obj[Random.Range(0,obj.Length)], transform.position, Quaternion.identity);
    }
    // Start is called before the first frame update
    void Start()
    {
        CreatBlock();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
