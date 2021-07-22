using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletspeed;
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0,1) * bulletspeed, ForceMode2D.Impulse); // 총알이 생성될때 정면으로 힘을 가해 보내는 명령
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Border"){
            Destroy(gameObject);
        }
    }
}
