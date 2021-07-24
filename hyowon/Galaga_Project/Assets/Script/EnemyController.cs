using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{   
    
    public float hp;
    private float dropProb;
    public GameObject[] HaveItem;
    void Start()
    {
        
    }

    void Update()
    {
        Die();
    
    }



///////////////////////////////////////////////////////////////////////////////////////////
    void Die(){
        if(hp <= 0){
            GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySound("Die");
            DropItem(); //죽을때 아이템 드롭

            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "PlayerBullet"){
            GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySound("Hit"); // 소리 재생 및 데미지
            Damaged(collision.gameObject.GetComponent<BulletController>().bulletdmg);// 데미지 계산
        }
    }

    void Damaged(float dmg){
        hp -= dmg;
    }

    void DropItem(){
        dropProb = Random.Range(0f,1f);
        if(dropProb < 0.4){
            return;
        }
        else if(dropProb<0.6){ // 20프로 확률로 폭탄 아이템 드랍.
            Instantiate(HaveItem[0], transform.position ,Quaternion.Euler(0,0,0));
            return;
        }
        else if(dropProb<0.8){ // 20프로 확률로 파워업 아이템 드랍.
            Instantiate(HaveItem[1], transform.position ,Quaternion.Euler(0,0,0));
            return;
        }
        else if(dropProb<0.9){ // 10프로 확률로 HP 회복 아이템 드랍.
            Instantiate(HaveItem[2], transform.position ,Quaternion.Euler(0,0,0));
            return;
        }
        else{ // 10프로확률로 펫 획득 아이템 드랍.
            return;
        }
    }
}
