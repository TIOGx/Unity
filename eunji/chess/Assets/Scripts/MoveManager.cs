using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager : MonoBehaviour
{
    bool InBoard()
    {
        float x = gameObject.transform.position.x;
        float z = gameObject.transform.position.z;
        //Debug.Log("x: "+x+" z: " +z);

        if (x < 0 || z < 0 || x > 7 || z > 7)
        {
            return false;
        }

        return true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            transform.position += new Vector3(-1, 0, 0);
            if (!InBoard())
            {
                transform.position += new Vector3(1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!InBoard())
            {
                transform.position += new Vector3(-1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, 0, 1);
            if (!InBoard())
            {
                transform.position += new Vector3(0, 0, -1);
            }
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, 0, -1);
            if (!InBoard())
            {
                transform.position += new Vector3(0, 0, 1);
            }
        }

    }
}
