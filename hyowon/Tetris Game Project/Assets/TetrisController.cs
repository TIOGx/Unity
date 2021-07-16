using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-0.5f,0,0);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(0.5f,0,0);
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0,-0.5f,0);
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            transform.RotateAround(transform.position,new Vector3(0,0,1), 90);
        }
        // transform.position += new Vector3(0, -0.5f, 0);
    }
}
