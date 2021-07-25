using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletdmg;
    public float bulletspeed;
    Transform playerPos; 
    Vector2 dir;

    void Start()
    {
        // 태그가 플레이어일 떄 총알 컨트롤
        if (gameObject.tag == "PlayerBullet"){ // 플레이어 총알일떄
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0,1) * bulletspeed, ForceMode2D.Impulse); // 총알이 생성될때 정면으로 힘을 가해 보내는 명령
        }
        else if(gameObject.tag == "EnemyBullet"){ // 적총알 일때
            playerPos = GameObject.Find("Player_1").GetComponent<Transform>();
            dir = playerPos.position - transform.position; // 총알 생성시 플레이어와 적 사이의 벡터 값 구하기 (방향)
            GetComponent<Rigidbody2D>().AddForce(dir * bulletspeed, ForceMode2D.Impulse);
        }
    }
    void Update()
    {
    }
    
    
///////////////////////////////////////////////////////////////////////////////////////////
    void OnTriggerEnter2D(Collider2D collision){
        if (gameObject.tag == "PlayerBullet"){
            if(collision.gameObject.tag == "Border"){
                Destroy(gameObject);
            }
            else if(collision.gameObject.tag == "Enemy"){
                Destroy(gameObject);
            }
        }
        
        else if(gameObject.tag == "EnemyBullet"){
            if(collision.gameObject.tag == "Player"){
                GameObject.Find("Player_1").GetComponent<PlayerController>().playerHP -= 1;
                Destroy(gameObject);
                Debug.Log("아야아야 아파요");
            }
            else if(collision.gameObject.tag == "Border"){
                Destroy(gameObject);
            }
        }
    }
}
