using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody Rigid;
    private float JumpForce = 4f;
    // Start is called before the first frame update
    void Start()
    {
        Rigid = GetComponent<Rigidbody>();
    }
    bool CheckJump()
    {
        if (Rigid.velocity.y == 0) return true;
        else return false;
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("velocity y : " + Rigid.velocity.y);
        if (Input.GetKey(KeyCode.Space) && CheckJump())
        {
            Rigid.velocity = transform.up * JumpForce;
        }
    }
}
